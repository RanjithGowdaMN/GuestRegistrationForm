using AxFiScnLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fi800ScanLibrary.Scanner
{

    public class ScanDocument : IScanDocument
    {
        public IntPtr Handle { get; }
        public AxFiScn axFiScn;

        public ScanDocument()
        {

        }

        public void StartScan()
        {
            int status;
            int ErrorCode;

            //Scanning start
            status = axFiScn.StartScan(this.Handle.ToInt32());

        }

        public void OpenScanner()
        {

        }


    }
}
