using System;
using System.Web.Script.Serialization;
using Tesseract;
internal static class OcrBridge
{
    static int Main(string[] args)
    {
        var json = new JavaScriptSerializer();
        try {
            using (var engine = new TesseractEngine(args[1], "eng", EngineMode.Default))
            using (var image = Pix.LoadFromFile(args[0])) {
                if ((long)image.Width * image.Height > 25000000) throw new ArgumentException("Image too large");
                string text = ""; float confidence = 0;
                using (var page = engine.Process(image, PageSegMode.Auto)) { text=page.GetText();confidence=page.GetMeanConfidence(); }
                // A tightly cropped ID may not have enough whitespace for auto segmentation.
                if (confidence < .8f || string.IsNullOrWhiteSpace(text))
                    using (var page = engine.Process(image, PageSegMode.SingleBlock)) {
                        var alternate=page.GetText();var score=page.GetMeanConfidence();
                        if (score > confidence || string.IsNullOrWhiteSpace(text)) { text=alternate;confidence=score; }
                    }
                Console.WriteLine(json.Serialize(new { text=text, confidence=confidence }));
            }
            return 0;
        } catch { Console.WriteLine(json.Serialize(new { error = "Local OCR could not read this image. Check the image and language data." })); return 1; }
    }
}
