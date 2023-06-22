using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.Diagnostics;

namespace Tesseract.Library
{
    public static class PythonHelper
    {
        public static string ApplyImageThreshold(string imagePath, int threshold)
        {
            string pythonScriptPath = "D:\\Images\\ProcessedImage\\Testscript.py";

            // Create a new process to run the Python script
            Process process = new Process();
            process.StartInfo.FileName = "python"; // Assuming Python is added to the system's PATH
            process.StartInfo.Arguments = $"{pythonScriptPath} {imagePath} {threshold}";
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
