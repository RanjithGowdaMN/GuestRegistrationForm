using Fargo.PrinterSDK;
using FargoEncodingPrinting.Library.Enums;
using SmartCardManager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FargoEncodingPrinting.Library.Lib
{
    public class EncodingAndPrinting
    {
        private PrintDocument m_printDocument;

        private Bitmap m_backBitmap;
        private Bitmap m_frontBitmap;

        private int m_iPageNumber;
        private int m_iNumPages = 1;

        // Set appropriately for dual sided printing.
        private bool m_dualSided = false;

        private SmartCardManager.SmartCardManager m_smartCardManager;

        private string m_selectedPrinter;

        /// <summary>
        /// Station to be used for the operation
        /// </summary>
        private Station m_station;

        public EncodingAndPrinting()
        {

        }


        private string updateCardStatus(CardStatus currentStatus)
        {
            switch (currentStatus)
            {
                case CardStatus.NoCardInPrinter:
                    return "Printer Empty";
                    
                case CardStatus.CardFeeding:
                    return "Card Feeding";
                    
                case CardStatus.CardDockedOk:
                    return "Card Docked";
                    
                case CardStatus.CardConnecting:
                    return "Card Connecting";
                    
                case CardStatus.CardConnected:
                    return "Card Connected";
                    
                case CardStatus.CardDisconnecting:
                    return "Card Disconnecting";
                    
                case CardStatus.CardDisconnected:
                    return "Card Disconnected";
                    
                case CardStatus.CardEjecting:
                    return "Card Ejecting";
                    
                case CardStatus.CardHasError:
                    return "Card Error";
                    
                case CardStatus.CardFeedError:
                    return "Card Feed Error";
                    
                case CardStatus.CardPrinting:
                    return "Card Printing";
                    
                default:
                    return "(Unknown)";
                    
            }
            //lblStatus.Refresh();
        }

        private void PrintAndUpdateStatus(string printerName)
        {
            Boolean cardIsOk;
            CardStatus cardStatus;
            PrinterInfo printerInfo;


            printerInfo = new PrinterInfo(printerName);
            string ribbonSerialNumber = printerInfo.RibbonSerialNumber;
            string filmSerialNumber = printerInfo.FilmSerialNumber;
            string lam1SerialNumber = printerInfo.LaminateSerialNumber(0);


            // Start the print job
            PrintCard();

            // Poll for it to start printing.
            cardIsOk = PollForPrinterPrinting(printerName);

            if (cardIsOk)
            {
                cardStatus = CardStatus.CardPrinting;
            }
            else
            {
                cardStatus = CardStatus.CardFeedError;
            }
            updateCardStatus(cardStatus);

            // Poll for the printer to go back to ready.
            cardIsOk = PollForPrinterReady(printerName);
            if (cardIsOk)
            {
                cardStatus = CardStatus.NoCardInPrinter;
            }
            else
            {
                cardStatus = CardStatus.CardFeedError;
            }
            updateCardStatus(cardStatus);
        }


        private Boolean DockAndUpdateStatus(string printerName)
        {
            Boolean cardWasDockedOk;
            CardStatus cardStatus;

            cardStatus = CardStatus.CardFeeding;
            updateCardStatus(cardStatus);

            cardWasDockedOk = DockTheCard(printerName);

            if (cardWasDockedOk)
            {
                cardStatus = CardStatus.CardDockedOk;
            }
            else
            {
                cardStatus = CardStatus.CardFeedError;
            }
            updateCardStatus(cardStatus);

            return (cardWasDockedOk);
        }


        private Boolean DockTheCard(string printerName)
        {
            Boolean returnCode;
            //Station targetStation;
            int inputHopper;

            Movement objMove = new Movement(printerName);
            PrinterInfo printerInfo = new PrinterInfo(printerName);

            // Specify the target encoder.  5121 usually is configured for both.

            //targetStation = Station.MIFARE;
            //targetStation = Station.iCLASS;

            inputHopper = cmbInputHopper.SelectedIndex;

            Debug.WriteLine("DockTheCard: Moving card to " + m_station.ToString());


            //// Move the hopper to attempt first to the specified one.
            //

            //switch (inputHopper)
            //{
            //    // First Available
            //    case 0:
            //        printerInfo.SendAPDU(11, 4, 0, 0, 0, null);
            //        break;
            //    // Top
            //    case 1:
            //        printerInfo.SendAPDU(11, 4, 0, 0, 0, null);
            //        break;
            //    // Bottom
            //    case 2:
            //        printerInfo.SendAPDU(11, 4, 1, 0, 0, null);
            //        break;
            //    // Kiosk.
            //    case 3:
            //        printerInfo.SendAPDU(11, 4, 3, 0, 0, null);
            //        break;
            //}

            switch (m_station)
            {
                // Bug in version 2.0 of the SDK.  Work around is to use direct SendAPDU call.  Fix ready in version 2.1
                case Station.Magnetic:
                    printerInfo.SendAPDU(15, 1, inputHopper, 0, 0, null);
                    break;

                default:
                    // Parameters
                    //
                    // destination
                    // Type: Fargo.PrinterSDK.Station
                    // The destination e-card encoding station or output bin.
                    //
                    // whichHopper
                    // Type: System.Int32
                    // The hopper to pull from or eject to 
                    // 0=first available, 
                    // 1=hopper 1(HDP8500)/left/top(HDP5000, DTC Line), 
                    // 2=hopper 2(HDP8500)/right/bottom(HDP5000, DTC Line), 
                    // 3=exception feed
                    // Ignored if a card is already in the printer. 
                    objMove.MoveTo(/*targetStation*/ m_station, inputHopper);
                    break;
            }
            returnCode = false;

            if (m_station == Station.Magnetic)
            {
                // Wait until "Holding" appears
                returnCode = true;
            }
            else
            {

                // Wait for LCD to indicate encoding

                // Assume will not be ok

                CurrentActivity currentActivity;

                int iStatusTries = 100;

                //
                // DTC1000/4000/4500
                //
                // DTC1000/4000/4500 does not support LCDInfo property
                if (printerName.Contains("DTC"))
                {
                    do
                    {
                        System.Threading.Thread.Sleep(1000);
                        currentActivity = printerInfo.CurrentActivity();
                        iStatusTries--;
                    } while (
                             (currentActivity != CurrentActivity.CurrentActivityException) &&
                             (currentActivity != CurrentActivity.CurrentActivityEncodeContact) &&
                             (currentActivity != CurrentActivity.CurrentActivityEncodeContactless) &&
                             (iStatusTries > 0)
                             );


                } // end if Neo


                // Check for HDP5000/HDPii
                else if (printerName.Contains("HDP"))
                {
                    returnCode = false;                 // Default to error
                    StationStatus stationStatus;
                    do
                    {
                        System.Threading.Thread.Sleep(1000);
                        stationStatus = printerInfo.StationStatus(/*targetStation*/ m_station);
                        currentActivity = printerInfo.CurrentActivity();

                        Debug.WriteLine("DockTheCard: Station Status " + stationStatus.ToString());
                        Debug.WriteLine("DockTheCard: Current Activity " + currentActivity.ToString());
                        iStatusTries--;
                    } while (
                            (currentActivity != CurrentActivity.CurrentActivityException) &&
                            (stationStatus != StationStatus.CardPresent) &&
                            (iStatusTries > 0)
                            );


                    //// Card DID make it to encoder in reasonable time.
                    //if ((iStatusTries != 0) && (currentActivity != CurrentActivity.CurrentActivityException))
                    //{
                    //    Debug.WriteLine("Card Docked OK");
                    //    returnCode = true;
                    //}
                }

                // Check for INK1000
                else if (printerName.Contains("INK"))
                {
                    // Note: The StationStatus function is not supported by the INK1000 printer model.
                    returnCode = false;                 // Default to error
                    do
                    {
                        System.Threading.Thread.Sleep(1000);
                        currentActivity = printerInfo.CurrentActivity();
                        Debug.WriteLine("DockTheCard: Current Activity " + currentActivity.ToString());
                        iStatusTries--;
                    } while (
                            (currentActivity != CurrentActivity.CurrentActivityEncodeContactless) &&
                            (iStatusTries > 0)
                            );
                }

                // Unknown printer type
                else
                {
                    currentActivity = CurrentActivity.CurrentActivityException;
                }

                if ((iStatusTries != 0) && (currentActivity != CurrentActivity.CurrentActivityException))
                {
                    Debug.WriteLine("DockTheCard: Card Docked OK");
                    returnCode = true;
                }
                else
                {
                    Debug.WriteLine("DockTheCard: Card NOT Docked");
                }

            }


            return (returnCode);
        }


        private Boolean PollForPrinterPrinting(string printerName)
        {
            Boolean returnCode;
            PrinterInfo printerInfo = new PrinterInfo(printerName);

            // Assume will work ok
            returnCode = true;

            int iStatusTries = 100;
            CurrentActivity currentActivity;

            do
            {
                System.Threading.Thread.Sleep(1000);
                currentActivity = printerInfo.CurrentActivity();
                iStatusTries--;
            } while ((currentActivity != CurrentActivity.CurrentActivityPrinting) &&
                     (iStatusTries > 0)
                     );


            // Card did not make it to encoder in reasonable time.
            if (iStatusTries == 0)
            {
                returnCode = false;
            }

            return (returnCode);
        }



        private Boolean PollForPrinterReady(string printerName)
        {
            Boolean returnCode;
            PrinterInfo printerInfo = new PrinterInfo(printerName);

            // Assume will work ok
            returnCode = true;

            int iStatusTries = 100;
            CurrentActivity currentActivity;

            do
            {
                System.Threading.Thread.Sleep(1000);
                currentActivity = printerInfo.CurrentActivity();
                iStatusTries--;
            } while ((currentActivity != CurrentActivity.CurrentActivityReady) &&
                     (iStatusTries > 0)
                     );


            // Card did not make it to encoder in reasonable time.
            if (iStatusTries == 0)
            {
                returnCode = false;
            }

            return (returnCode);
        }


        private Boolean EjectTheCard(string printerName)
        {
            Boolean returnCode;
            Movement objMove = new Movement(printerName);

            // Eject the card to the last hopper.  Currently only HDP8500 has dual output hopper.
            objMove.MoveTo(Station.Eject, 0);

            // Wait for it to return to ready
            returnCode = PollForPrinterReady(printerName);
            return (returnCode);
        }

        private bool PollForEncoderNotEmpty(string strReader)
        {
            // Create a state that hopefully the reader will be in when connect occurs.
            SCStateInfo StateInfo = new SCStateInfo();
            StateInfo.sReaderName = strReader;
            StateInfo.nCurrentState = SCStates.Unknown;
            StateInfo.nEventState = SCStates.Unknown;

            int iTotalStatusTries = 0;

            Debug.WriteLine("Start looking for Empty");

            // 10 seconds of looking for Empty to go false
            int iStatusTries = 100;
            do
            {
                System.Threading.Thread.Sleep(100);

                // Get the status of the card within the reader.
                m_smartCardManager.GetStatusChange(1000, ref StateInfo);

                iTotalStatusTries++;
                iStatusTries--;

                Debug.WriteLine("Polling For Empty: nEventState = " + StateInfo.nEventState.ToString("x") + " retrys left:" + iStatusTries.ToString());
            } while (((StateInfo.nEventState & SCStates.Empty) == SCStates.Empty) && iStatusTries >= 0);

            // Return true if not timed out
            return (iStatusTries > 0);
        }



        /// <summary>
        /// Look for the SCardConnect to return ok.
        /// </summary>
        /// <param name="strReader"></param>
        /// <returns></returns>
        private bool PollForEncoderConnect(string strReader)
        {
            bool bPresent = false;
            int iConnectTries = 100;

            //Debug.WriteLine("Start looking for Connect");

            // Attempt to connect to the driver with both T0 and T1 protocols. (shared)
            do
            {
                System.Threading.Thread.Sleep(100);

                // The SCardConnect function establishes a connection (using a specific resource manager context) between the calling application 
                // and a smart card contained by a specific reader. If no card exists in the specified reader, an error is returned.
                bPresent = m_smartCardManager.Connect(strReader, SCardAccessMode.Shared, SCardProtocolIdentifiers.T1 | SCardProtocolIdentifiers.T0);
                iConnectTries--;

                Debug.WriteLine("Attempting Connect: bPresent = " + bPresent.ToString() + " retrys left:" + iConnectTries.ToString());
            } while ((!bPresent) && (iConnectTries != 0));

            Debug.WriteLine("End Attempting Connect: bPresent = " + bPresent.ToString() + " retrys left:" + iConnectTries.ToString());

            return (bPresent);
        }



        /// <summary>
        /// Poll for the InUse flag
        /// </summary>
        /// <param name="strReader"></param>
        /// <returns></returns>
        private bool PollForEncoderInUse(string strReader)
        {
            // 10 seconds of looking for the InUse to go to true
            int iStatusTries = 100;

            int iTotalStatusTries = 0;

            // Create a state that hopefully the reader will be in when connect occurs.
            SCStateInfo StateInfo = new SCStateInfo();
            StateInfo.sReaderName = strReader;
            StateInfo.nCurrentState = SCStates.Unknown;
            StateInfo.nEventState = SCStates.Unknown;

            do
            {
                System.Threading.Thread.Sleep(100);

                // Get the status of the card within the reader.
                m_smartCardManager.GetStatusChange(1000, ref StateInfo);

                iTotalStatusTries++;
                iStatusTries--;

                Debug.WriteLine("Polling For InUse: nEventState = " + StateInfo.nEventState.ToString("x"));
            } while (((StateInfo.nEventState & SCStates.InUse) != SCStates.InUse) && iStatusTries >= 0);

            return (iStatusTries != 0);
        }

        /// <summary>
        /// Populate the combo box for the installed PCSC Readers.
        /// </summary>
        private void GetPCSCReaders()
        {
            // Clear the combo box for the Smart Card readers
            this.lstEncoderNames.Items.Clear();

            // Is the Smart Card service running?
            if (DoesSCServiceExist())
            {
                // Get the list of Smart Card readers
                ArrayList objReaderList = getReaderList();

                // If there are any Smart Card readers installed
                if (objReaderList.Count >= 1)
                {
                    // Populate the Smart Card readers combo box.
                    for (int i = 0; i < objReaderList.Count; i++)
                    {
                        lstEncoderNames.Items.Add(objReaderList[i].ToString());
                    }

                    // Pick the first one as default.
                    lstEncoderNames.SelectedIndex = 0;
                }
            }

            // Smart Card service is either not present or not running.
            else
            {
            }

        }



        /// <summary>
        /// Get the list of installed PC_SC readers
        /// </summary>
        /// <returns>
        /// ArrayList of 
        /// </returns>
        public ArrayList getReaderList()
        {
            ArrayList arrrayListRet = new ArrayList();


            // Obtain the list of installed readers
            try
            {
                // Establish the context of the reader to System.
                m_smartCardManager.EstablishContext(SmartCardManager.SCardContextScope.System);

                // Attempt to read the list (returns number of readers in the list)
                m_smartCardManager.ListReaders(arrrayListRet);

                // Release context
                m_smartCardManager.ReleaseContext();
            }
            catch (InvalidOperationException)
            {
            }

            // Return the list of readers
            return arrrayListRet;
        }

        /// <summary>
        /// Indicate if the SCardSvr service is running or not.
        /// </summary>
        /// <returns></returns>
        private bool DoesSCServiceExist()
        {
            using (ServiceController sc = new ServiceController("SCardSvr"))
            {
                // Is the Smart Card service running?
                return (sc.Status == ServiceControllerStatus.Running);
            }
        }


        /// <summary>
        /// Method to print the card from the sample bitmaps.
        /// </summary>
        private void PrintCard()
        {
            StandardPrintController spController = new StandardPrintController();

            // New document
            m_printDocument = new PrintDocument();

            // Subscribe to the print event
            m_printDocument.PrintPage += new PrintPageEventHandler(m_printDocument_PrintPage);

            m_printDocument.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);

            // Use selected printer.
            m_printDocument.PrinterSettings.PrinterName = m_selectedPrinter;

            //// To allow to change printer instance
            //// Pass the PrintDocument object in so that the dialog can update the printer name
            //// and devmode for this job.
            //PrintDialog dlgSettings = new PrintDialog();
            //dlgSettings.Document = m_printDocument;
            //dlgSettings.ShowDialog();


            m_iPageNumber = 1;
            m_iNumPages = 2;

            m_printDocument.DefaultPageSettings.Landscape = false;

            m_printDocument.QueryPageSettings += new QueryPageSettingsEventHandler(m_printDocument_QueryPageSettings);

            m_printDocument.PrinterSettings.Copies = 1;
            m_printDocument.PrintController = spController;

            m_iPageNumber = 0;

            m_printDocument.DocumentName = "Card";

            // Calling this method starts the printing process for this document
            m_printDocument.Print();


            //PrinterSettings printerSettings = new PrinterSettings();
            //printerSettings.GetHdevmode();
        }


        Boolean StartSession(string strReader)
        {
            Boolean bResult;
            Debug.WriteLine("StartSession: (**session start**)");
            // If the reader is a one wire encoder then start the session between the Omnikey
            // service and the printer firmware.
            if (strReader.ToUpper().Contains("LAN"))
            {
                // Default to failure
                bResult = false;

                byte[] inBuffer = new byte[512];
                byte[] outBuffer = new byte[512];

                // Prepare a 6 second timeout
                uint ConnectionTimeout = 6000;
                inBuffer = BitConverter.GetBytes(ConnectionTimeout);

                Debug.WriteLine("StartSession: Connecting for IOCTL (session start)");

                // Attempt to connect the Omnikey Ethernet Driver Monitor Service to the
                // printer firmware and establish the connection to the card in the reader.
                // The "undefined" protocol type indicates to the driver that this
                // connection is only for purposes of sending a control code to it (no protocol
                // negotiation occurs)
                if (m_smartCardManager.Connect(strReader, SCardAccessMode.Direct, SCardProtocolIdentifiers.Undefined))
                {
                    // Send a control code to the service (passes through driver) to start up the One-Wire 
                    // session (with a timeout of 6 seconds)
                    try
                    {
                        Debug.WriteLine("StartSession: Sending IOCTL for session start");

                        // Control code 3410 is start session.
                        m_smartCardManager.Control(SmartCardManager.SmartCardManager.SCardCtlCode(3410), inBuffer, out outBuffer);
                        bResult = true;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("StartSession: Exception while sending IOCTL session start:{0} {1}", ex.InnerException, ex.Message);
                        bResult = false;
                    }

                    // Wait for five seconds to allow the session to be established between the
                    // one-wire service and the printer firmware.
                    System.Threading.Thread.Sleep(5000);

                    Debug.WriteLine("StartSession: DisConnecting for IOCTL (start session)");

                    // Disconnect from the driver and leave the card in the reader.
                    m_smartCardManager.Disconnect(SCardDisposition.LeaveCard);
                }
                else
                {
                    Debug.WriteLine("StartSession: Connect failed");
                    bResult = false;
                }
            }
            else
            {
                Debug.WriteLine("StartSession: Encoder is not LAN");
                bResult = true;
            }
            return (bResult);
        }



        Boolean EndSession(string strReader)
        {
            Boolean bResult;

            // DisConnect the one wire session if needed?
            if (strReader.ToUpper().Contains("LAN"))
            {
                // Prepare buffers for the communication.
                byte[] inBuffer = new byte[512];
                byte[] outBuffer = new byte[512];

                uint ConnectionTimeout = 6000;
                inBuffer = BitConverter.GetBytes(ConnectionTimeout);

                Debug.WriteLine("EndSession: Connecting for IOCTL (session end)");

                // Default is all ok.
                bResult = true;

                // Connect to the One-Wire driver?
                if (m_smartCardManager.Connect(strReader, SCardAccessMode.Direct, SCardProtocolIdentifiers.Undefined))
                {
                    try
                    {
                        Debug.WriteLine("EndSession: Sending IOCTL for session end");

                        // Close the session between the One Wire service and the PTP service in the firmware (op code 3411)
                        m_smartCardManager.Control(SmartCardManager.SmartCardManager.SCardCtlCode(3411), inBuffer, out outBuffer);

                        bResult = true;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("EndSession: Exception while sending IOCTL session end:{0} {1}", ex.InnerException, ex.Message);
                        bResult = false;
                    }

                    Debug.WriteLine("EndSession: DisConnecting for IOCTL (session end)");

                    // Disconnect from the driver
                    m_smartCardManager.Disconnect(SCardDisposition.LeaveCard);
                }
                else
                {
                    Debug.WriteLine("EndSession: Connect failed");

                    // Connect failed
                    bResult = false;
                }
            } // end if One-wire.
            else
            {
                Debug.WriteLine("EndSession: not one-wire");
                bResult = true;
            }

            return (bResult);
        }




        /// <summary>
        /// Initialize the reader/encoder
        /// </summary>
        /// <param name="strReader">Name of the Smart Card reader to initialize.</param>
        /// <returns>Resource manager object associated with this reader.</returns>
        public Boolean ConnectReader(string strReader)
        {
            Boolean bSessionStarted;
            Boolean wasConnected = false;
            Boolean wasDocked = false;

            try
            {
                Debug.WriteLine("ConnectReader: Connecting to " + strReader);

                // Establish the context of the reader to System.
                Debug.WriteLine("ConnectReader: Establish Context");
                m_smartCardManager.EstablishContext(SmartCardManager.SCardContextScope.System);

                Debug.WriteLine("ConnectReader: Context established, starting One-Wire session if needed");
                bSessionStarted = StartSession(strReader);

                //// If the reader is a one wire encoder then start the session between the Omnikey
                //// service and the printer firmware.
                //if (strReader.ToUpper().Contains("LAN"))
                //{
                //    byte[] inBuffer = new byte[512];
                //    byte[] outBuffer = new byte[512];

                //    // Prepare a 6 second timeout
                //    uint ConnectionTimeout = 6000;
                //    inBuffer = BitConverter.GetBytes(ConnectionTimeout);

                //    Debug.WriteLine("Connecting for IOCTL (session start)");


                //    // Attempt to connect the Omnikey Ethernet Driver Monitor Service to the
                //    // printer firmware and establish the connection to the card in the reader.
                //    // The "undefined" protocol type indicates to the driver that this
                //    // connection is only for purposes of sending a control code to it (no protocol
                //    // negotiation occurs)
                //    if (m_smartCardManager.Connect(strReader, SCardAccessMode.Direct, SCardProtocolIdentifiers.Undefined))
                //    {
                //        // Send a control code to the service (passes through driver) to start up the One-Wire 
                //        // session (with a timeout of 6 seconds)
                //        try
                //        {
                //            Debug.WriteLine("Sending IOCTL for session start");

                //            // Control code 3410 is start session.
                //            m_smartCardManager.Control(SmartCardManager.SmartCardManager.SCardCtlCode(3410), inBuffer, out outBuffer);
                //        }
                //        catch (Exception ex)
                //        {
                //            Debug.WriteLine("Exception while sending IOCTL session start:{0} {1}", ex.InnerException, ex.Message);
                //        }

                //        // Wait for five seconds to allow the session to be established between the
                //        // one-wire service and the printer firmware.
                //        System.Threading.Thread.Sleep(5000);

                //        Debug.WriteLine("DisConnecting for IOCTL (start session)");

                //        // Disconnect from the driver and leave the card in the reader.
                //        m_smartCardManager.Disconnect(SCardDisposition.LeaveCard);
                //    }
                //}

                if (bSessionStarted)
                {
                    Debug.WriteLine("ConnectReader: One-Wire Session WAS started");

                    // Look for the reader to go NOT empty
                    wasDocked = PollForEncoderNotEmpty(strReader);

                    if (wasDocked)
                    {
                        Debug.WriteLine("ConnectReader: Card was found in reader");

                        // Wait for the SCardConnect to the card (not the "Direct" mode) to be successful
                        wasConnected = PollForEncoderConnect(strReader);
                    }
                    // Card never arrived.  Tear down session
                    else
                    {
                        Debug.WriteLine("ConnectReader: Ending Session");
                    }
                }
                else
                {
                    Debug.WriteLine("ConnectReader: One-Wire Session WAS NOT started");
                }

            }
            catch (System.InvalidOperationException ioEx)
            {
                //updateStatus(String.Format(Properties.Resources.SC_NoCardDetected, ioEx.Message, ioEx.InnerException));
                Debug.WriteLine("ConnectReader: - io exception: {0} {1}", ioEx.InnerException, ioEx.Message);
            }
            catch (Exception ex)
            {
                //Console.WriteLine("{0} {1}", ex.InnerException, ex.Message);
                Debug.WriteLine("ConnectReader: - other exception: {0} {1}", ex.InnerException, ex.Message);
            }

            return (wasConnected);
            //return mSCResMgr;

        }


        /// <summary>
        /// Close the reader/encoder
        /// </summary>
        public Boolean DisconnectReader(string strReader)
        {
            Boolean wasDisconnected = false;
            Boolean sessionEndedOk = true;

            Debug.WriteLine("DisconnectReader: Disconnecting from " + strReader);

            // if the underlying reader is connected then disconnect the session
            if (m_smartCardManager.IsConnected)
            {
                // Disconnect from the card
                m_smartCardManager.Disconnect(SCardDisposition.LeaveCard);

                // End the session
                sessionEndedOk = EndSession(strReader);

                //// DisConnect the one wire session if needed?
                //if (strReader.ToUpper().Contains("LAN"))
                //{
                //    // Prepare buffers for the communication.
                //    byte[] inBuffer = new byte[512];
                //    byte[] outBuffer = new byte[512];

                //    uint ConnectionTimeout = 6000;
                //    inBuffer = BitConverter.GetBytes(ConnectionTimeout);

                //    Debug.WriteLine("Connecting for IOCTL (session start)");


                //    // Connect to the One-Wire driver?
                //    if (m_smartCardManager.Connect(strReader, SCardAccessMode.Direct, SCardProtocolIdentifiers.Undefined))
                //    {
                //        try
                //        {
                //            Debug.WriteLine("Sending IOCTL for session end");

                //            // Close the session between the One Wire service and the PTP service in the firmware (op code 3411)
                //            m_smartCardManager.Control(SmartCardManager.SmartCardManager.SCardCtlCode(3411), inBuffer, out outBuffer);
                //        }
                //        catch (Exception ex)
                //        {
                //            Debug.WriteLine("Exception while sending IOCTL session end:{0} {1}", ex.InnerException, ex.Message);
                //        }

                //        Debug.WriteLine("DisConnecting for IOCTL (session end)");

                //        // Disconnect from the driver
                //        m_smartCardManager.Disconnect(SCardDisposition.LeaveCard);
                //    }
                //} // end if One-wire.


                Debug.WriteLine("DisconnectReader: Release Context");


                // All done.
                m_smartCardManager.ReleaseContext();

                wasDisconnected = true;
            }
            else
            {
                Debug.WriteLine("DisconnectReader: SmartCardReader was not connected");
                wasDisconnected = true;
            }

            return (wasDisconnected);
        }



        private Boolean ConnectAndUpdateStatus(string printerName)
        {
            Boolean cardConnected;
            CardStatus cardStatus;

            cardStatus = CardStatus.CardConnecting;
            updateCardStatus(cardStatus);

            cardConnected = ConnectReader(printerName);

            if (cardConnected)
            {
                cardStatus = CardStatus.CardConnected;
            }
            else
            {
                cardStatus = CardStatus.CardHasError;
            }
            updateCardStatus(cardStatus);

            return (cardConnected);
        }

        private void DisconnectAndUpdateStatus(string printerName)
        {
            Boolean cardDisconnected;
            CardStatus cardStatus;

            cardStatus = CardStatus.CardDisconnecting;
            updateCardStatus(cardStatus);

            cardDisconnected = DisconnectReader(printerName);

            if (cardDisconnected)
            {
                cardStatus = CardStatus.CardDisconnected;
            }
            else
            {
                cardStatus = CardStatus.CardHasError;
            }
            updateCardStatus(cardStatus);
        }


        private void EjectAndUpdateStatus(string printerName)
        {
            Boolean cardWasEjectedOk;
            CardStatus cardStatus;

            cardStatus = CardStatus.CardEjecting;
            updateCardStatus(cardStatus);

            cardWasEjectedOk = EjectTheCard(printerName);

            if (cardWasEjectedOk)
            {
                cardStatus = CardStatus.NoCardInPrinter;
            }
            else
            {
                cardStatus = CardStatus.CardFeedError;
            }
            updateCardStatus(cardStatus);
        }




    }
}
