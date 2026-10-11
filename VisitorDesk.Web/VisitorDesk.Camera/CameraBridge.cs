using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using EOSDigital.API;
using EOSDigital.SDK;

// The supplied EDSDKLib is x86/.NET Framework. Keep it outside the web process.
internal static class CameraBridge
{
    static readonly object Sync = new object();
    static string failure;
    static string downloaded;
    static bool receiving;
    static void Fail(string message) { lock (Sync) { if (failure == null) failure = message; } }

    [STAThread]
    static int Main(string[] args)
    {
        object result;
        int exit = 0;
        try { result = Run(args); }
        catch (DllNotFoundException) { result = new { error = "Canon runtime dependency is missing. Run VisitorDesk.Camera/build.ps1 and install the runtime required by your Canon SDK package." }; exit = 1; }
        catch (BadImageFormatException) { result = new { error = "Canon DLL architecture mismatch. This helper requires the matching Windows x86 EDSDK, EdsImage and EDSDKLib DLLs." }; exit = 1; }
        catch (Exception ex) { result = new { error = ex.Message }; exit = 1; }
        Console.WriteLine(new JavaScriptSerializer { MaxJsonLength = 8 * 1024 * 1024 }.Serialize(result));
        return exit;
    }

    static object Run(string[] args)
    {
        if (args.Length == 0 || (args[0] != "status" && args[0] != "capture")) throw new ArgumentException("Use status or capture <output-directory>.");
        bool capture = args[0] == "capture";
        if (capture && args.Length != 2) throw new ArgumentException("Capture requires an output directory.");
        using (var mutex = new Mutex(false, "Local\\VISMA.CanonCamera"))
        {
            bool acquired;
            try { acquired = mutex.WaitOne(0); } catch (AbandonedMutexException) { acquired = true; }
            if (!acquired) throw new InvalidOperationException("Canon camera is busy with another request.");
            try { return UseCamera(capture, capture ? Path.GetFullPath(args[1]) : null); }
            finally { mutex.ReleaseMutex(); }
        }
    }

    static object UseCamera(bool capture, string directory)
    {
        ErrorHandler.SevereErrorHappened += (sender, ex) => Fail(ex.Message);
        ErrorHandler.NonSevereErrorHappened += (sender, code) => Fail("Canon SDK error: " + code + " (0x" + ((int)code).ToString("X") + "). Close EOS Utility, check USB, battery and camera focus, then retry.");
        using (var api = new CanonAPI())
        {
            var cameras = api.GetCameraList();
            if (failure != null) throw new InvalidOperationException(failure);
            string version = FileVersionInfo.GetVersionInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EDSDK.dll")).FileVersion;
            if (cameras.Count == 0)
            {
                if (capture) throw new InvalidOperationException("No Canon camera connected. Connect the EOS 4000D by USB, switch it on and close EOS Utility.");
                return new { ready = false, sdkLoaded = true, sdkVersion = version, architecture = "x86", message = "Canon SDK loaded. Waiting for EOS 4000D USB connection.", cameras = new string[0] };
            }
            var camera = cameras.FirstOrDefault(c => c.DeviceName.IndexOf("4000D", StringComparison.OrdinalIgnoreCase) >= 0) ?? cameras[0];
            if (cameras.Count > 1 && !cameras.Any(c => c.DeviceName.IndexOf("4000D", StringComparison.OrdinalIgnoreCase) >= 0))
                throw new InvalidOperationException("Multiple Canon cameras detected. Connect only the camera intended for visitor photos.");
            camera.OpenSession();
            try
            {
                if (failure != null) throw new InvalidOperationException(failure);
                if (!capture) return new { ready = true, sdkLoaded = true, sdkVersion = version, architecture = "x86", message = camera.DeviceName + " connected and session opened.", cameras = cameras.Select(c => c.DeviceName).ToArray() };
                Directory.CreateDirectory(directory);
                int originalSaveTo = camera.GetInt32Setting(PropertyID.SaveTo);
                camera.DownloadReady += (sender, info) => {
                    lock (Sync)
                    {
                        if (info.IsRAW || receiving) { sender.CancelDownload(info); return; }
                        receiving = true;
                        try {
                            string path = Path.Combine(directory, "capture.jpg");
                            sender.DownloadToFile(info, path);
                            downloaded = path;
                        } catch (Exception ex) { failure = ex.Message; }
                    }
                };
                try
                {
                    camera.SetSetting(PropertyID.SaveTo, (int)SaveTo.Host);
                    camera.SetCapacity(4096, int.MaxValue);
                    if (failure != null) throw new InvalidOperationException(failure);
                    camera.TakePhotoShutterAsync();
                    var timer = Stopwatch.StartNew();
                    string imagePath = null;
                    while (timer.Elapsed < TimeSpan.FromSeconds(35))
                    {
                        Application.DoEvents();
                        lock (Sync) {
                            if (failure != null) throw new InvalidOperationException(failure);
                            imagePath = downloaded;
                        }
                        if (imagePath != null) break;
                        Thread.Sleep(25);
                    }
                    if (imagePath == null) throw new TimeoutException("No JPEG received. Set the camera to JPEG or RAW+JPEG, check focus and battery, and retry.");
                    return new { image = Portrait(imagePath), source = camera.DeviceName, message = "Canon photo captured." };
                }
                finally { camera.SetSetting(PropertyID.SaveTo, originalSaveTo); }
            }
            finally { if (camera.SessionOpen) camera.CloseSession(); }
        }
    }

    static string Portrait(string path)
    {
        using (var image = Image.FromFile(path))
        {
            if (image.PropertyIdList.Contains(0x112)) {
                int orientation = BitConverter.ToUInt16(image.GetPropertyItem(0x112).Value, 0);
                var rotations = new[] { RotateFlipType.RotateNoneFlipNone, RotateFlipType.RotateNoneFlipNone, RotateFlipType.RotateNoneFlipX, RotateFlipType.Rotate180FlipNone, RotateFlipType.Rotate180FlipX, RotateFlipType.Rotate90FlipX, RotateFlipType.Rotate90FlipNone, RotateFlipType.Rotate270FlipX, RotateFlipType.Rotate270FlipNone };
                if (orientation >= 1 && orientation <= 8) image.RotateFlip(rotations[orientation]);
            }
            double scale = Math.Min(1, 1600.0 / Math.Max(image.Width, image.Height));
            using (var resized = new Bitmap(Math.Max(1, (int)(image.Width * scale)), Math.Max(1, (int)(image.Height * scale))))
            using (var graphics = Graphics.FromImage(resized))
            using (var output = new MemoryStream())
            using (var parameters = new EncoderParameters(1))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(image, 0, 0, resized.Width, resized.Height);
                parameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 85L);
                resized.Save(output, ImageCodecInfo.GetImageEncoders().First(c => c.MimeType == "image/jpeg"), parameters);
                return "data:image/jpeg;base64," + Convert.ToBase64String(output.ToArray());
            }
        }
    }
}
