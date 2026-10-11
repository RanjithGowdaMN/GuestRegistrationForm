using System.Globalization;
using System.Text.RegularExpressions;
using GuestRegistrationDesktopUI.Library.TextProcessing;

// Qatar label rules ported from ProcessTextData; MRZ parser and country map are
// linked from the original project. Each parse gets fresh state.
public static class IdentityTextProcessor
{
    public static Dictionary<string, string> Extract(string text)
    {
        var fields = new Dictionary<string, string>();
        var sourceLines = text.Split('\n').Select(s => s.Trim()).Where(s => s.Length > 0).ToArray();
        for (int lineIndex = 0; lineIndex < sourceLines.Length; lineIndex++) {
            var line = sourceLines[lineIndex];
            // Some layouts place a label and its value on separate lines.
            if (Regex.IsMatch(line, @"^(?:Full\s+Name|Name|Nationality|ID\s*(?:No\.?|Number)?|QID|Passport\s*(?:No\.?|Number)|D[.\s]*[O0][.\s]*B|Date of Birth|Expiry|Date of Expiry)\s*[:.\-]?\s*$", RegexOptions.IgnoreCase) && lineIndex + 1 < sourceLines.Length)
                line += " " + sourceLines[lineIndex + 1];
            string Match(string pattern) => Regex.Match(line, pattern, RegexOptions.IgnoreCase).Groups[1].Value.Trim();
            var id = Match(@"^(?:QID|ID\s*(?:No\.?|Number)?|D\.No)\s*[:.\-]?\s*(\d[\d ]{9,15})\s*$");
            if (id.Length > 0) { id = Regex.Replace(id, @"\D", ""); if (id.Length == 11) fields["idNumber"] = id; }
            var passport = Match(@"^Passport\s*(?:No\.?|Number)\s*[:.\-]?\s*([A-Z0-9]{6,12})\s*$");
            if (passport.Length > 0) fields["idNumber"] = passport.ToUpperInvariant();
            var name = Match(@"^(?:Full\s+Name|Name)(?:\s*[:\-]\s*|\s+)([\p{L}][\p{L} .'-]+)$");
            if (name.Length > 0) fields["name"] = name;
            var nation = Match(@"^(?:Nationality|ionality)(?:\s*[:\-]\s*|\s+)([\p{L}][\p{L} .'-]+)$");
            if (nation.Length > 0) fields["nationality"] = nation;
            foreach (var (key, label) in new[] { ("dob", @"D[.\s]*[O0][.\s]*B|Date of Birth"), ("expiry", @"Expiry|xpiry|Date of Expiry") }) {
                if (!Regex.IsMatch(line, label, RegexOptions.IgnoreCase)) continue;
                var date = Regex.Match(line, @"\b(?:\d{1,2}[/.-]\d{1,2}[/.-]\d{4}|\d{4}-\d{2}-\d{2})\b").Value;
                if (DateTime.TryParseExact(date, new[] { "d/M/yyyy", "d-M-yyyy", "d.M.yyyy", "yyyy-MM-dd" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsed) && (key != "dob" || parsed.Date <= DateTime.Today)) fields[key] = parsed.ToString("yyyy-MM-dd");
            }
        }
        var lines = sourceLines.Select(s => Regex.Replace(s.ToUpperInvariant(), @"\s", "")).ToArray();
        for (int i = 0; i < lines.Length; i++) {
            foreach (var (width, count) in new[] { (44, 2), (36, 2), (30, 3) }) {
                var candidate = lines.Skip(i).Take(count).ToArray();
                if (candidate.Length != count || candidate.Any(s => s.Length != width || !Regex.IsMatch(s, @"^[A-Z0-9<]+$")) || !candidate[0].Contains('<')) continue;
                try {
                    var document = new Parser().DetectFields(string.Join("\n", candidate));
                    if (string.IsNullOrWhiteSpace(document.Number)) continue;
                    fields["name"] = (document.Name + " " + document.Surname).Trim();
                    fields["idNumber"] = document.Number;
                    fields["nationality"] = CountryAbbr.getCountryFullName(document.Nationality);
                    fields["dob"] = document.BirthDate.ToString("yyyy-MM-dd");
                    if (document.ExpirationDate.HasValue) fields["expiry"] = document.ExpirationDate.Value.ToString("yyyy-MM-dd");
                    return fields;
                } catch { /* Incomplete or failed-checksum MRZ: keep reviewed label extraction. */ }
            }
        }
        return fields;
    }
}
