using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using AxFiScnLib;

// Runs in a separate x86 STA process because the existing Fujitsu SDK is ActiveX.
internal class ScannerBridge : Form
{
    readonly AxFiScn scanner = new AxFiScn();
    readonly string[] args;
    bool opened;
    ScannerBridge(string[] arguments)
    {
        args = arguments;
        ShowInTaskbar = false; Opacity = 0; Width = 1; Height = 1;
        ((ISupportInitialize)scanner).BeginInit();
        Controls.Add(scanner);
        ((ISupportInitialize)scanner).EndInit();
        Shown += delegate { BeginInvoke(new Action(Execute)); };
    }
    static void Output(object value) { Console.WriteLine(new JavaScriptSerializer { MaxJsonLength = 24000000 }.Serialize(value)); }
    [STAThread]
    static int Main(string[] args)
    {
        try { Application.EnableVisualStyles(); Application.Run(new ScannerBridge(args)); return 0; }
        catch (Exception ex) { Output(new { available = false, error = "Fujitsu SDK could not start: " + ex.Message }); return 1; }
    }
    void Execute()
    {
        try
        {
            string source = null;
            for (int i = 0; i < scanner.GetSourceCount(); i++)
            {
                string name = scanner.GetSourceName(i);
                if (name.IndexOf("800R", StringComparison.OrdinalIgnoreCase) >= 0) { source = name; break; }
            }
            if (source == null) throw new InvalidOperationException("No fi-800R driver source found. Check USB, power and the PaperStream IP TWAIN driver.");
            if (scanner.SelectSourceName(source) == -1) throw new InvalidOperationException("Unable to select " + source);
            if (scanner.OpenScanner(Handle.ToInt32()) != 0) throw new InvalidOperationException("Cannot open fi-800R. Check connection or close other scanning apps. SDK code: 0x" + scanner.ErrorCode.ToString("X8"));
            opened = true;
            if (args.Length == 0 || args[0] == "status") { Output(new { available = true, source = source, message = "fi-800R connected and ready" }); return; }
            if (args.Length != 2 || args[0] != "scan") throw new InvalidOperationException("Invalid scanner command.");
            string directory = Path.GetFullPath(args[1]);
            string captured = null;
            scanner.ScanToFile += delegate(object sender, _DFiScnEvents_ScanToFileEvent e) { if (captured == null) captured = e.fileName; };
            scanner.ScanTo = 0; // FILE, constants from FI800Scan/ModuleScan.cs
            scanner.FileType = 0; // BMP; convert losslessly to PNG below
            scanner.FileName = Path.Combine(directory, "scan.bmp");
            scanner.ScanCount = 1;
            scanner.PaperSupply = 1; // ADF simplex: one side per explicit browser action
            scanner.ScanContinue = false;
            scanner.PixelType = 2; // RGB
            scanner.Resolution = 2; // 300 dpi
            scanner.ShowSourceUI = false;
            int result = scanner.StartScan(Handle.ToInt32());
            if (result != 0) throw new InvalidOperationException(result == 1 ? "Scan cancelled. Reinsert the document to try again." : "Scan failed. Check the document feed. SDK code: 0x" + scanner.ErrorCode.ToString("X8"));
            if (captured == null || !File.Exists(captured)) throw new InvalidOperationException("Scanner returned no image. Insert the document and try again.");
            if (!Path.GetFullPath(captured).StartsWith(directory + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase)) throw new InvalidOperationException("Scanner returned an unexpected output location.");
            using (var img = Image.FromFile(captured))
            using (var output = new MemoryStream())
            {
                img.Save(output, ImageFormat.Png);
                if (output.Length > 8000000) throw new InvalidOperationException("Scan is too large. Use a smaller document area.");
                Output(new { available = true, source = source, image = "data:image/png;base64," + Convert.ToBase64String(output.ToArray()) });
            }
        }
        catch (Exception ex) { Output(new { available = false, error = ex.Message }); }
        finally { if (opened) { try { scanner.CloseScanner(Handle.ToInt32()); } catch { } } Close(); }
    }
}
