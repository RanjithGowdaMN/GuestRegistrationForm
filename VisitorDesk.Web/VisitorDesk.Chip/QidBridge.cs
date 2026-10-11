using System;
using System.Globalization;
using System.Web.Script.Serialization;
using ReadQID.Library;
using System.Collections;
using SmartCardManager;

// Public calls supplied by the user in Lib/qIDReading.txt. Do not inspect the SDK.
internal static class QidBridge
{
    static string DateValue(string value)
    {
        DateTime parsed;
        return DateTime.TryParseExact(value, new[] { "dd/MM/yyyy", "dd-MM-yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsed) ? parsed.ToString("yyyy-MM-dd") : "";
    }
    [STAThread]
    static int Main()
    {
        var serializer = new JavaScriptSerializer { MaxJsonLength = 8000000 };
        // Avoid invoking the vendor library's cleanup on an absent card.
        try {
            bool present = false;
            using (var probe = new SmartCardManager.SmartCardManager()) {
                if (probe.EstablishContext(SCardContextScope.System)) {
                    try {
                        var names = new ArrayList();probe.ListReaders(names);
                        foreach (string name in names) {
                            try { present = probe.Connect(name, SCardAccessMode.Shared, SCardProtocolIdentifiers.T0 | SCardProtocolIdentifiers.T1); }
                            catch { }
                            finally { if (probe.IsConnected) probe.Disconnect(SCardDisposition.LeaveCard); }
                            if (present) break;
                        }
                    } finally { probe.ReleaseContext(); }
                }
            }
            if (!present) { Console.WriteLine(serializer.Serialize(new { error = "No accessible ID card. Insert the card in the connected reader and retry." }));return 1; }
        } catch { Console.WriteLine(serializer.Serialize(new { error = "Card reader is unavailable. Check its driver and Smart Card service." }));return 1; }
        var reader = new ReadQid();
        try
        {
            reader.ConnectReader();
            var data = reader.ReadQIDData();
            if (data == null) throw new InvalidOperationException();
            Console.WriteLine(serializer.Serialize(new {
                fields = new { name = data.Name_En, idNumber = data.QID_En, dob = DateValue(data.DateOfBirth), expiry = DateValue(data.DateOfExpiry), nationality = data.Nationality_En },
                portrait = data.Portrait == null ? "" : Convert.ToBase64String(data.Portrait),
                message = "Review the chip data against the ID before applying it."
            }));
            return 0;
        }
        catch { Console.WriteLine(serializer.Serialize(new { error = "Unable to read the ID chip. Check the reader, insert the ID and retry." })); return 1; }
        finally { try { reader.Disconnect(); } catch { } }
    }
}
