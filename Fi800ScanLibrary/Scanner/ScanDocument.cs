using FiScnUtildN;
using System;
using System.Collections;
using System.Drawing;

namespace Fi800ScanLibrary.Scanner
{

    public class ScanDocument : IScanDocument
    {
        public AxFiScnLib.AxFiScn axFiScn1;
        public ScanDocument scanDocument;
        public ArrayList resultList;

        public Hashtable aiqcResultHashTable;
        public Hashtable blankPageResultHashTable;
        public Hashtable multiResultHashTable;
        public Hashtable patchCodeHashTable;
        public Hashtable barcodeHashTable;
        public Hashtable barcodeRotationHashTable;

        public ScanDocument()
        {
            axFiScn1 = new AxFiScnLib.AxFiScn();
            ((System.ComponentModel.ISupportInitialize)axFiScn1).BeginInit();

            axFiScn1.Enabled = true;
            axFiScn1.Location = new System.Drawing.Point(789, 467);
            axFiScn1.Name = "axFiScn1";
            //axFiScn1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axFiScn1.OcxState")));

            axFiScn1.Size = new System.Drawing.Size(48, 48);
            axFiScn1.TabIndex = 8;
            axFiScn1.DetectJobSeparator += new System.EventHandler(axFiScn1_DetectJobSeparator);
            axFiScn1.NegotiateCapabilities += new System.EventHandler(axFiscn1_NegotiateCapabilities);
            axFiScn1.ScanToFile += new AxFiScnLib._DFiScnEvents_ScanToFileEventHandler(axFiScn1_ScanToFile);
            axFiScn1.DetectBarcode += new AxFiScnLib._DFiScnEvents_DetectBarcodeEventHandler(axFiScn1_DetectBarcode);
            axFiScn1.DetectPatchCode += new AxFiScnLib._DFiScnEvents_DetectPatchCodeEventHandler(axFiScn1_DetectPatchCode);
            axFiScn1.DetectBarcodeDetail += new AxFiScnLib._DFiScnEvents_DetectBarcodeDetailEventHandler(axFiScn1_DetectBarcodeDetail);
            axFiScn1.PagePartition += new System.EventHandler(axFiscn1_Pagepartition);
            axFiScn1.ScanToDibEx += new AxFiScnLib._DFiScnEvents_ScanToDibExEventHandler(axFiScn1_ScanToDibEx);
            axFiScn1.ScanToRawEx += new AxFiScnLib._DFiScnEvents_ScanToRawExEventHandler(axFiScn1_ScanToRawEx);
            axFiScn1.AutoProfileSelection += new AxFiScnLib._DFiScnEvents_AutoProfileSelectionEventHandler(axFiScn1_AutoProfileSelection);
            //axFiScn1.MultiStreamPropertySetting += new AxFiScnLib._DFiScnEvents_MultiStreamPropertySettingEventHandler(axFiScn1_MultiStreamPropertySetting);
            // 

            blankPageResultHashTable = new Hashtable();
            blankPageResultHashTable.Add(ModuleScan.BR_DETECTION, ModuleScan.BR_STR_DETECTION);
            blankPageResultHashTable.Add(ModuleScan.BR_NONDETECTION, ModuleScan.BR_STR_NONDETECTION);

            aiqcResultHashTable = new Hashtable();
            aiqcResultHashTable.Add(true, ModuleScan.AR_BADIMAGE);
            aiqcResultHashTable.Add(false, ModuleScan.AR_NOERROR);

            multiResultHashTable = new Hashtable();
            multiResultHashTable.Add(true, ModuleScan.MR_DETECT);
            multiResultHashTable.Add(false, ModuleScan.MR_NOT_DETECT);

            //initilize array list
            resultList = new ArrayList();

            patchCodeHashTable = new Hashtable();
            patchCodeHashTable.Add(ModuleScan.PA_PATCH1, ModuleScan.PA_STR_PATCH1);
            patchCodeHashTable.Add(ModuleScan.PA_PATCH2, ModuleScan.PA_STR_PATCH2);
            patchCodeHashTable.Add(ModuleScan.PA_PATCH3, ModuleScan.PA_STR_PATCH3);
            patchCodeHashTable.Add(ModuleScan.PA_PATCH4, ModuleScan.PA_STR_PATCH4);
            patchCodeHashTable.Add(ModuleScan.PA_PATCH6, ModuleScan.PA_STR_PATCH6);
            patchCodeHashTable.Add(ModuleScan.PA_PATCHT, ModuleScan.PA_STR_PATCHT);

            barcodeHashTable = new Hashtable();
            barcodeHashTable.Add(ModuleScan.BA_UNDEFINED, ModuleScan.BA_STR_UNDEFINED);
            barcodeHashTable.Add(ModuleScan.BA_EAN8, ModuleScan.BA_STR_EAN8);
            barcodeHashTable.Add(ModuleScan.BA_EAN13, ModuleScan.BA_STR_EAN13);
            barcodeHashTable.Add(ModuleScan.BA_CODE3OF9, ModuleScan.BA_STR_CODE3OF9);
            barcodeHashTable.Add(ModuleScan.BA_CODE128, ModuleScan.BA_STR_CODE128);
            barcodeHashTable.Add(ModuleScan.BA_ITF, ModuleScan.BA_STR_ITF);
            barcodeHashTable.Add(ModuleScan.BA_UPCA, ModuleScan.BA_STR_UPCA);
            barcodeHashTable.Add(ModuleScan.BA_CODABAR, ModuleScan.BA_STR_CODABAR);
            barcodeHashTable.Add(ModuleScan.BA_PDF417, ModuleScan.BA_STR_PDF417);
            barcodeHashTable.Add(ModuleScan.BA_QRCODE, ModuleScan.BA_STR_QRCODE);
            barcodeHashTable.Add(ModuleScan.BA_DATAMATRIX, ModuleScan.BA_STR_DATAMATRIX);
            barcodeHashTable.Add(ModuleScan.BA_AZTECCODE, ModuleScan.BA_STR_AZTECCODE);

            barcodeRotationHashTable = new Hashtable();
            barcodeRotationHashTable.Add(ModuleScan.BA_RT_0, ModuleScan.BA_RT_STR_0);
            barcodeRotationHashTable.Add(ModuleScan.BA_RT_90, ModuleScan.BA_RT_STR_90);
            barcodeRotationHashTable.Add(ModuleScan.BA_RT_180, ModuleScan.BA_RT_STR_180);
            barcodeRotationHashTable.Add(ModuleScan.BA_RT_270, ModuleScan.BA_RT_STR_270);
            barcodeRotationHashTable.Add(ModuleScan.BA_RT_X, ModuleScan.BA_RT_STR_X);
        }

        public void StartScan()
        {
            int status;
            int ErrorCode;

            status = axFiScn1.StartScan(axFiScn1.Handle.ToInt32());
        }

        public void OpenScanner()
        {
            axFiScn1.OpenScanner(axFiScn1.Handle.ToInt32());
        }

        public void axFiScn1_AutoProfileSelection(object sender, AxFiScnLib._DFiScnEvents_AutoProfileSelectionEvent e)
        {
            //if (this.MenuItemShowEvent.Checked)
            //{
            //    CreateShowEventMessage("AutoProfileSelection");
            //}
            //if (this.MenuItemOutputResult.Checked)
            //{
                System.IO.StreamWriter sw = new System.IO.StreamWriter(ModuleScan.strOutputResult, true);
                sw.WriteLine("AutoProfileSelection Event");
                sw.WriteLine("DistResult             : " + e.distResult);
                sw.WriteLine("FormName               : " + e.formName);
                sw.WriteLine("ProfileName            : " + e.profileName);
                sw.WriteLine("");
                sw.Close();
            //}
        }

        public void axFiScn1_DetectJobSeparator(object sender, System.EventArgs e)
        {
            //if (this.MenuItemShowEvent.Checked)
            //{
            //    MessageBox.Show("The special paper/Patch Code paper was detected.", "fiScanTest", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //}
        }

        public void axFiscn1_NegotiateCapabilities(object sender, EventArgs e)
        {
            //int iReturnCode;
            //int iItemValue;
            //iReturnCode = axFiScn1.SetCapability(ICAP_PIXELTYPE, TWTY_UINT16, TWPT_BW);
            //iReturnCode = axFiScn1.GetCapability(ICAP_PIXELTYPE, MSG_GETCURRENT, TWTY_UINT16, iItemValue);
            //if (this.MenuItemShowEvent.Checked)
            //{
            //    CreateShowEventMessage("NegotiateCapabilities");
            //}
        }

        public void axFiScn1_ScanToFile(object sender, AxFiScnLib._DFiScnEvents_ScanToFileEvent e)
        {
            if (true)//this.chkAIQCNotice.CheckState == CheckState.Checked)
            {
                String[] aiqcResult = { e.scanCount.ToString(), "", "", "", "", "", "", "", "", aiqcResultHashTable[axFiScn1.AIQCResult].ToString(), "", "" };
                resultList.Add(aiqcResult);
            }
            if (axFiScn1.BlankPageSkip != 0 && axFiScn1.BlankPageNotice == 1)
            {
                String[] blankPageResult = { e.scanCount.ToString(), "", "", "", "", "", "", "", "", "", blankPageResultHashTable[axFiScn1.BlankPageResult].ToString(), "" };
                resultList.Add(blankPageResult);
            }
            if ((axFiScn1.MultiFeed > 0) && (axFiScn1.MultiFeedNotice == true))
            {
                String[] multiResult = { e.scanCount.ToString(), "", "", "", "", "", "", "", "", "", "", multiResultHashTable[axFiScn1.MultiFeedResult].ToString() };
                resultList.Add(multiResult);
            }

            if (ModuleScan.bCancelScan)
            {
                axFiScn1.CancelScan();
                ModuleScan.bCancelScan = false;
            }
            //if (this.MenuItemShowEvent.Checked)
            //{
            //    CreateShowEventMessage("ScanToFile");
            //}

            if (true)//this.MenuItemOutputResult.Checked)
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(ModuleScan.strOutputResult, true);
                sw.WriteLine("ScanToFile Event");
                sw.WriteLine("ScanCount            : " + e.scanCount);
                sw.WriteLine("FileName             : " + e.fileName);
                sw.WriteLine("");
                sw.WriteLine("PageNumber Property");
                sw.WriteLine("value                : " + axFiScn1.PageNumber);
                sw.WriteLine("");
                sw.Close();
            }
        }

        public void axFiScn1_DetectBarcode(object sender, AxFiScnLib._DFiScnEvents_DetectBarcodeEvent e)
        {
            //if (this.MenuItemShowEvent.Checked)
            //{
            //    CreateShowEventMessage("DetectBarcode");
            //}
            if (true)//this.MenuItemOutputResult.Checked)
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(ModuleScan.strOutputResult, true);
                sw.WriteLine("DetectBarcode Event");
                sw.WriteLine("ReadCount              : " + e.readCount);
                sw.WriteLine("BarcodeType            : " + e.barcodeType);
                sw.WriteLine("BarcodeText            : " + e.barcodeText);
                sw.WriteLine("");
                sw.Close();
            }
        }
        public void axFiScn1_DetectPatchCode(object sender, AxFiScnLib._DFiScnEvents_DetectPatchCodeEvent e)
        {
            String[] patchCode = { e.readCount.ToString(), "", "", "", "", "", "", "", patchCodeHashTable[e.patchCodeType].ToString(), "", "", "" };
            resultList.Add(patchCode);
            //if (this.MenuItemShowEvent.Checked)
            //{
            //    CreateShowEventMessage("DetectPatchCode");
            //}
            if (true)//this.MenuItemOutputResult.Checked)
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(ModuleScan.strOutputResult, true);
                sw.WriteLine("DetectPatchCode Event");
                sw.WriteLine("ReadCount              : " + e.readCount);
                sw.WriteLine("PatchCodeType          : " + e.patchCodeType);
                sw.WriteLine("");
                sw.Close();
            }
        }
        public void axFiScn1_DetectBarcodeDetail(object sender, AxFiScnLib._DFiScnEvents_DetectBarcodeDetailEvent e)
        {
            String count = e.barcodeCount + "/" + e.barcodeTotalCount;
            String[] barcode = { e.readCount.ToString(), count, barcodeHashTable[e.barcodeType].ToString(), e.barcodeTextLength.ToString(), e.barcodeText, e.barcodeX.ToString(), e.barcodeY.ToString(), barcodeRotationHashTable[e.barcodeRotation].ToString(), "", "", "", "" };
            resultList.Add(barcode);
            //if (this.MenuItemShowEvent.Checked)
            //{
            //    CreateShowEventMessage("DetectBarcodeDetail");
            //}
            if (true)//this.MenuItemOutputResult.Checked)
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(ModuleScan.strOutputResult, true);
                sw.WriteLine("DetectBarcodeDetail Event");
                sw.WriteLine("ReadCount              : " + e.readCount);
                sw.WriteLine("BarcodeCount           : " + e.barcodeCount);
                sw.WriteLine("BarcodeTotalCount      : " + e.barcodeTotalCount);
                sw.WriteLine("BarcodeType            : " + e.barcodeType);
                sw.WriteLine("BarcodeTextLength      : " + e.barcodeTextLength);
                sw.WriteLine("BarcodeText            : " + e.barcodeText);
                sw.WriteLine("BarcodeX               : " + e.barcodeX);
                sw.WriteLine("BarcodeY               : " + e.barcodeY);
                sw.WriteLine("BarcodeRotation        : " + e.barcodeRotation);
                sw.WriteLine("BarcodeConfidence      : " + e.barcodeConfidence);
                sw.WriteLine("");
                sw.Close();
            }
        }

        public void axFiscn1_Pagepartition(object sender, EventArgs e)
        {
            //if (this.MenuItemShowEvent.Checked)
            //{
            //    CreateShowEventMessage("PagePartition");
            //}
        }

        public void axFiScn1_ScanToDibEx(object sender, AxFiScnLib._DFiScnEvents_ScanToDibExEvent e)
        {
            Bitmap BitMap;
            int fileCounter;
            String Path;
            ConvH2BM Conv = new ConvH2BM();

            if (true)//this.chkAIQCNotice.CheckState == CheckState.Checked)
            {
                String[] aiqcResult = { axFiScn1.PageCount.ToString(), "", "", "", "", "", "", "", "", aiqcResultHashTable[axFiScn1.AIQCResult].ToString(), "", "" };
                resultList.Add(aiqcResult);
            }
            if (axFiScn1.BlankPageSkip != 0 && axFiScn1.BlankPageNotice == 1)
            {
                String[] blankPageResult = { axFiScn1.PageCount.ToString(), "", "", "", "", "", "", "", "", "", blankPageResultHashTable[axFiScn1.BlankPageResult].ToString(), "" };
                resultList.Add(blankPageResult);
            }
            if ((axFiScn1.MultiFeed > 0) && (axFiScn1.MultiFeedNotice == true))
            {
                String[] multiResult = { axFiScn1.PageCount.ToString(), "", "", "", "", "", "", "", "", "", "", multiResultHashTable[axFiScn1.MultiFeedResult].ToString() };
                resultList.Add(multiResult);
            }

            //Path = SaveFileName();
            ModuleScan.GlobalLock((IntPtr)e.dib);

            // Converting the DIB handle into the Bitmap class
            BitMap = Conv.GetBitmapFromDIB(e.dib);
            if (BitMap == null)
            {
                //MessageBox.Show("An error occurred during conversion into the Bitmap class. \nError code of the GetBitmapFromDIB:" + HexString(Conv.ErrorCode), "fiScanTest");
                ModuleScan.GlobalUnlock((IntPtr)e.dib);
                ModuleScan.GlobalFree((IntPtr)e.dib);
                return;
            }
            //BitMap.Save(Path, System.Drawing.Imaging.ImageFormat.Bmp);
            BitMap.Dispose();
            ModuleScan.GlobalUnlock((IntPtr)e.dib);
            ModuleScan.GlobalFree((IntPtr)e.dib);

            // One value of FileCounter is increased.
            fileCounter = this.axFiScn1.FileCounter;
            if (fileCounter == 65535)
            {
                fileCounter = 1;
            }
            else if (fileCounter != -1)
            {
                fileCounter++;
            }
            this.axFiScn1.FileCounter = fileCounter;

            if (ModuleScan.bCancelScan)
            {
                axFiScn1.CancelScan();
                ModuleScan.bCancelScan = false;
            }
            //if (this.MenuItemShowEvent.Checked)
            //{
            //    CreateShowEventMessage("ScanToDibEx");
            //}

            if (true)//this.MenuItemOutputResult.Checked)
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(ModuleScan.strOutputResult, true);
                sw.WriteLine("ScanToDibEx Event");
                sw.WriteLine("Dib                    : " + e.dib);
                sw.WriteLine("");
                sw.WriteLine("PageNumber Property");
                sw.WriteLine("value                  : " + axFiScn1.PageNumber);
                sw.WriteLine("");
                sw.Close();
            }
        }

        public void axFiScn1_ScanToRawEx(object sender, AxFiScnLib._DFiScnEvents_ScanToRawExEvent e)
        {
            Bitmap BitMap;
            int fileCounter;
            String Path;
            ConvH2BM Conv = new ConvH2BM();

            if (true)//this.chkAIQCNotice.CheckState == CheckState.Checked)
            {
                String[] aiqcResult = { axFiScn1.PageCount.ToString(), "", "", "", "", "", "", "", "", aiqcResultHashTable[axFiScn1.AIQCResult].ToString(), "", "" };
                resultList.Add(aiqcResult);
            }
            if (axFiScn1.BlankPageSkip != 0 && axFiScn1.BlankPageNotice == 1)
            {
                String[] blankPageResult = { axFiScn1.PageCount.ToString(), "", "", "", "", "", "", "", "", "", blankPageResultHashTable[axFiScn1.BlankPageResult].ToString(), "" };
                resultList.Add(blankPageResult);
            }
            if ((axFiScn1.MultiFeed > 0) && (axFiScn1.MultiFeedNotice == true))
            {
                String[] multiResult = { axFiScn1.PageCount.ToString(), "", "", "", "", "", "", "", "", "", "", multiResultHashTable[axFiScn1.MultiFeedResult].ToString() };
                resultList.Add(multiResult);
            }

            //Path = SaveFileName();

            // Converting the memory handle into the Bitmap class
            BitMap = Conv.GetBitmapFromRAW(e.resolution, e.imageWidth, e.imageLength, e.bitPerPixel, e.compressionType, e.size, e.raw);
            if (BitMap == null)
            {
                //MessageBox.Show("An error occurred during conversion into the Bitmap class. \nError code of the GetBitmapFromRAW:" + HexString(Conv.ErrorCode), "fiScanTest");
                return;
            }
            //BitMap.Save(Path, System.Drawing.Imaging.ImageFormat.Bmp);
            BitMap.Dispose();

            // One value of FileCounter is increased.
            fileCounter = this.axFiScn1.FileCounter;
            if (fileCounter == 65535)
            {
                fileCounter = 1;
            }
            else if (fileCounter != -1)
            {
                fileCounter++;
            }
            this.axFiScn1.FileCounter = fileCounter;

            if (ModuleScan.bCancelScan)
            {
                axFiScn1.CancelScan();
                ModuleScan.bCancelScan = false;
            }
            //if (this.MenuItemShowEvent.Checked)
            //{
            //    CreateShowEventMessage("ScanToRawEx");
            //}

            if (true)//this.MenuItemOutputResult.Checked)
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(ModuleScan.strOutputResult, true);
                sw.WriteLine("ScanToRawEx Event");
                sw.WriteLine("Resolution             : " + e.resolution);
                sw.WriteLine("ImageWidth             : " + e.imageWidth);
                sw.WriteLine("ImageLength            : " + e.imageLength);
                sw.WriteLine("BitPerPixel            : " + e.bitPerPixel);
                sw.WriteLine("CompressionType        : " + e.compressionType);
                sw.WriteLine("Size                   : " + e.size);
                sw.WriteLine("hRaw                   : " + e.raw);
                sw.WriteLine("");
                sw.WriteLine("PageNumber Property");
                sw.WriteLine("value                  : " + axFiScn1.PageNumber);
                sw.WriteLine("");
                sw.Close();
            }
        }


    }
}
