using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using SmartCardManager;

// Uses the same SDK and context/list/connect sequence as EncodingAndPrinting.cs.
// This SDK exposes reader transport, not the government identity application.
internal static class ChipBridge
{
    static int Main()
    {
        var serializer = new JavaScriptSerializer();
        try
        {
            using (var manager = new SmartCardManager.SmartCardManager())
            {
                if (!manager.EstablishContext(SCardContextScope.System))
                    throw new InvalidOperationException("Smart Card service is unavailable. Connect the reader and check its driver.");
                try
                {
                    var names = new ArrayList();
                    manager.ListReaders(names);
                    var readers = new List<object>();
                    foreach (string name in names)
                    {
                        bool connected = false;
                        try
                        {
                            connected = manager.Connect(name, SCardAccessMode.Shared, SCardProtocolIdentifiers.T0 | SCardProtocolIdentifiers.T1);
                            readers.Add(new { name = name, cardConnected = connected });
                        }
                        catch { readers.Add(new { name = name, cardConnected = false }); }
                        finally { if (manager.IsConnected) manager.Disconnect(SCardDisposition.LeaveCard); }
                    }
                    Console.WriteLine(serializer.Serialize(new {
                        readers = readers, identityReadingAvailable = System.IO.File.Exists(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"VisitorDesk.Qid.exe")),
                        message = "Reader check complete. Insert the ID card and choose Read identity details."
                    }));
                }
                finally { manager.ReleaseContext(); }
            }
            return 0;
        }
        catch (Exception)
        {
            Console.WriteLine(serializer.Serialize(new { error = "Unable to query the card reader. Check the Smart Card service and reader driver." }));
            return 1;
        }
    }
}
