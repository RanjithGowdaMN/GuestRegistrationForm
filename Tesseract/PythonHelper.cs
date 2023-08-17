using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.IO;

namespace TesseractOCR.Library
{
    public static class PythonHelper
    {
        public static string ApplyImageThreshold(string imagePath, int threshold, int idType)
        {
            //string json = File.ReadAllText("./ApplicationSettings.json.json");
            //JObject config = JObject.Parse(json);

            string pythonScriptPath = "D:\\VisitorData\\ScannedID\\ProcessedImage\\Interpolate_GaussBlur_Median.py";
            //string pythonScriptPath = (string)config["PyScriptSource"];


            // Create a new process to run the Python script
            Process process = new Process();
            process.StartInfo.FileName = "python"; // Assuming Python is added to the system's PATH
            process.StartInfo.Arguments = $"{pythonScriptPath} {imagePath} {threshold} {idType}";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            // Read the output of the Python script
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return output;
        }
    }
}
