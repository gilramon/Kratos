using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor
{
    class MiniAda_Parser
    {
        public static string ConvertHex(String hexString)
        {
            try
            {
                string ascii = string.Empty;
                for (int i = 0; i < hexString.Length; i += 2)
                {
                    String hs = string.Empty;
                    hs = hexString.Substring(i, 2);
                    if (hs != "00")
                    {
                        uint decval = System.Convert.ToUInt32(hs, 16);
                        char character = System.Convert.ToChar(decval);
                        ascii += character;
                    }
                
                }
                return ascii;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return string.Empty;
        }


        public static float ConvertFloat(String hexString)
        {
            try
            {
                //string hexString = "43480170";
                uint num = uint.Parse(hexString, System.Globalization.NumberStyles.AllowHexSpecifier);
                byte[] floatVals = BitConverter.GetBytes(num).Reverse().ToArray();

                float f = BitConverter.ToSingle(floatVals, 0);
                return f;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return 0;
        }

        static byte[] StringToByteArray(string hex)
        {
            try
            {
                return Enumerable.Range(0, hex.Length)
                                 .Where(x => x % 2 == 0)
                                 .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                                 .ToArray();

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return null;
            }
        }


        
        static string GetUbloxData(KratosProtocolFrame i_Parsedframe)
        {

            return String.Format("\n Ublox data: [{0}] \n", ConvertHex(i_Parsedframe.Data));
        }

        static string SetRxChannelStateCal(KratosProtocolFrame i_Parsedframe)
        {
            return String.Format("\n RX channel state RX/CAL have been set \n");
        }
        static string RecordIQDaraSelectSource(KratosProtocolFrame i_Parsedframe)
        {
            return String.Format("\n Record IQ data source selected \n");
        }
        static string RecordIQData(KratosProtocolFrame i_Parsedframe)
        {
            byte[] DataBytes = StringToByteArray(i_Parsedframe.Data);
            return String.Format("\n IQ samples Data: [{0}]  Data Length: [{1}] Bytes\n", i_Parsedframe.Data, DataBytes.Length);
        }
        static string SetGPIOValue(KratosProtocolFrame i_Parsedframe)
        {
            return String.Format("\n GPIO value have been set \n");
        }

        static string GetGPIOValue(KratosProtocolFrame i_Parsedframe)
        {
            return String.Format("\n GPIO Value  [{0}]  \n", i_Parsedframe.Data);
        }
        static string SetGPIODirection(KratosProtocolFrame i_Parsedframe)
        {
            return String.Format("\n GPIO direction have been set \n");
        }

        static string GetGPIODirection(KratosProtocolFrame i_Parsedframe)
        {
            return String.Format("\n GPIO direction  [{0}]  \n", i_Parsedframe.Data);
        }
        static string TxGetRFPLLlockDetect(KratosProtocolFrame i_Parsedframe)
        {
            return String.Format("\n Tx Get RF PLL lock Detect [{0}]  \n", i_Parsedframe.Data);
        }
        static string RxGetRFPLLlockDetect(KratosProtocolFrame i_Parsedframe)
        {
            return String.Format("\n Rx Get RF PLL lock Detect [{0}]  \n", i_Parsedframe.Data);
        }
        static string GetDCA(KratosProtocolFrame i_Parsedframe)
        {
            return String.Format("\n DCA [{0}] dBm \n", ConvertFloat(i_Parsedframe.Data));
        }

        static string SetDCA(KratosProtocolFrame i_Parsedframe)
        {
            return String.Format("\n DCA has been set \n");
        }
        static string GetRXChannelGain(KratosProtocolFrame i_Parsedframe)
        {
            return String.Format("\n Rx channel Gain [{0}] \n", i_Parsedframe.Data);
        }
        static string SetRXChannelGain(KratosProtocolFrame i_Parsedframe)
        {
            byte[] DataBytes = StringToByteArray(i_Parsedframe.Data);
            return String.Format("\n RX Channel Gain has been set\n");
        }
        static string LoadDataInFlash(KratosProtocolFrame i_Parsedframe)
        {
            byte[] DataBytes = StringToByteArray(i_Parsedframe.Data);
            return String.Format("\n Loaded Data: [{0}]  Data Length: [{1}] Bytes\n", i_Parsedframe.Data, DataBytes.Length);
        }
        static string StoreDataInFlash(KratosProtocolFrame i_Parsedframe)
        {

            return String.Format("\n Data stored in the flash \n");
        }
        static string Write_FPGA_Data(KratosProtocolFrame i_Parsedframe)
        {

            return String.Format("\n FPGA value have been set \n");
        }

        static string Read_FPGA_Data(KratosProtocolFrame i_Parsedframe)
        {

            return String.Format("\n FPGA value [{0}] \n", i_Parsedframe.Data);
        }
        static string SetTXCO_ON_OFF(KratosProtocolFrame i_Parsedframe)
        {


            return String.Format("\n TCXO have been set \n");
        }
        static string GetOutputPower(KratosProtocolFrame i_Parsedframe)
        {

            return String.Format("\n Output Power [{0}] dBm \n", ConvertFloat(i_Parsedframe.Data));
        }
        static string SetOutputPower(KratosProtocolFrame i_Parsedframe)
        {

            return String.Format("\n System Output power havs been set \n");
        }
        static string GetSytemState(KratosProtocolFrame i_Parsedframe)
        {

            return String.Format("\n System State [{0}] \n", ConvertHex(i_Parsedframe.Data));
        }
        static string SetSytemState(KratosProtocolFrame i_Parsedframe)
        {

            return String.Format("\n System state have been changed \n");
        }
        static string DoSync(KratosProtocolFrame i_Parsedframe)
        {

            return String.Format("\n Sync received \n");
        }
        static string GetTxAD936X(KratosProtocolFrame i_Parsedframe)
        {
            return String.Format("\n Tx AD936X  [{0}] \n", i_Parsedframe.Data);

        }
        static string SetTxAD936X(KratosProtocolFrame i_Parsedframe)
        {

            return String.Format("\n Tx AD936X data Has been Set [OK] \n");
        }
        static string SetSynthesizerL2(KratosProtocolFrame i_Parsedframe)
        {

            return String.Format("\n Synthesizer L2 Has been Set [OK] \n");
        }
        static string SetSynthesizerL1(KratosProtocolFrame i_Parsedframe)
        {

            return String.Format("\n Synthesizer L1 Has been Set [OK] \n");

        }
        static string GetPSUCardInformation(KratosProtocolFrame i_Parsedframe)
        {

            return String.Format("\n PSU card Information [{0}] \n", ConvertHex(i_Parsedframe.Data));
        }

        static string SetPSUCardInformation(KratosProtocolFrame i_Parsedframe)
        {

            return String.Format("\n PSU card Information Has been Set [OK] \n");
        }

        static string GetRFCardInformation(KratosProtocolFrame i_Parsedframe)
        {

            return String.Format("\n RF card Information [{0}] \n", ConvertHex(i_Parsedframe.Data));
        }

        static string SetRFCardInformation(KratosProtocolFrame i_Parsedframe)
        {

            return String.Format("\n Core RF Information Has been Set [OK] \n");
        }
        
        static string SetCoreCardInformation(KratosProtocolFrame i_Parsedframe)
        {

            return String.Format("\n Core card Information Has been Set [OK] \n");
        }

        
        static string GetCoreCardInformation(KratosProtocolFrame i_Parsedframe)
        {

            return String.Format("\n Core card Information [{0}] \n", ConvertHex(i_Parsedframe.Data));
        }
        static string SetIdentityInformation(KratosProtocolFrame i_Parsedframe)
        {

            return String.Format("\n Identity Information Has been Set [OK] \n");
        }
        static string GetIdentityInformation(KratosProtocolFrame i_Parsedframe)
        {

            return String.Format("\n Identity Information [{0}] \n", ConvertHex(i_Parsedframe.Data));
        }
        static string GetSystemType(KratosProtocolFrame i_Parsedframe)
        {

            int SystemType = int.Parse(i_Parsedframe.Data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);

                return String.Format("\n System type [{0}] \n", SystemType);
        }

        static string IsSystemBusy(KratosProtocolFrame i_Parsedframe)
        {
            //2 bytes Serial number:
            //2 bytes - Serial number, range: 0 – 65535
            int BusyStatus = int.Parse(i_Parsedframe.Data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            //int SerialNumber = int.Parse(i_Parsedframe.Data.Substring(2, 2) + i_Parsedframe.Data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            if (BusyStatus == 0)
            {
                return String.Format("\n Ready [OK] [{0}] \n", BusyStatus);
            }
            else
            {
                return String.Format("\n Busy  [{0}] \n", BusyStatus);
            }
        }
        static string SetLogLevel(KratosProtocolFrame i_Parsedframe)
        {
            //2 bytes Serial number:
            //2 bytes - Serial number, range: 0 – 65535

            //int SerialNumber = int.Parse(i_Parsedframe.Data.Substring(2, 2) + i_Parsedframe.Data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);

            return String.Format("\n Log Level has been set. \n");
        }
        static string GetSerialNumber(KratosProtocolFrame i_Parsedframe)
        {
            //2 bytes Serial number:
            //2 bytes - Serial number, range: 0 – 65535

            int SerialNumber = int.Parse(i_Parsedframe.Data.Substring(2, 2) + i_Parsedframe.Data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);

            return String.Format("\n Serial Number :[{0}] hex:[{1}]\n", SerialNumber, i_Parsedframe.Data);
        }
        static string GetFirmwareVertion(KratosProtocolFrame i_Parsedframe)
        {
        //    Unit major version – 	1 byte
        //Unit minor version – 	1 byte
        //Version day –		1 bytes
        //Version month –	1 bytes
        //Version year –		2 bytes

            int UnitMajorVersion = int.Parse(i_Parsedframe.Data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            int UnitMinorVersion = int.Parse(i_Parsedframe.Data.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            int VersionDay = int.Parse(i_Parsedframe.Data.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            int VersionMonth = int.Parse(i_Parsedframe.Data.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
            int VersionYear = int.Parse(i_Parsedframe.Data.Substring(10, 2) + i_Parsedframe.Data.Substring(8, 2), System.Globalization.NumberStyles.HexNumber);  //Gil: because it is little endian so I need to reverse the bytes
            return String.Format("\n Unit major version [{0}]\n Unit minor version [{1}]\n " +
                "Version day [{2}]\n Version month [{3}]\n Version year [{4}]", 
                UnitMajorVersion, UnitMinorVersion, VersionDay, VersionMonth, VersionYear);
        }
        static string GetSoftwareVertion(KratosProtocolFrame i_Parsedframe)
        {
        //    ICD major version – 	1 byte
        //ICD minor version – 	1 byte
        //Unit major version – 	1 byte
        //Unit minor version – 	1 byte
        //Version day –		1 bytes
        //Version month –	1 bytes
        //Version year –		2 bytes


             int ICDMajor = int.Parse(i_Parsedframe.Data.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
             int ICDMinor = int.Parse(i_Parsedframe.Data.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
            int UnitMajorNumber = int.Parse(i_Parsedframe.Data.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            int UnitMinorNumber = int.Parse(i_Parsedframe.Data.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
            string VersionDateTime = ConvertHex(i_Parsedframe.Data.Substring(8));
            

            return string.Format("\n ICD major version [{0}]\n ICD minor version [{1}]\n Unit major version [{2}]\n Unit minor version [{3}]" +
    "\n Version date time  [{4}]\n ",
    ICDMajor, ICDMinor, UnitMajorNumber, UnitMinorNumber, VersionDateTime);
            //int VersionDay = int.Parse(i_Parsedframe.Data.Substring(8, 2), System.Globalization.NumberStyles.HexNumber);
            //int VersionMonth = int.Parse(i_Parsedframe.Data.Substring(10, 2), System.Globalization.NumberStyles.HexNumber);
            //int VersionYear = int.Parse(i_Parsedframe.Data.Substring(14, 2) + i_Parsedframe.Data.Substring(12, 2), System.Globalization.NumberStyles.HexNumber);  //Gil: because it is little endian so I need to reverse the bytes
            //return String.Format("\n ICD major version [{0}]\n ICD minor version [{1}]\n Unit major version [{2}]\n Unit minor version [{3}]" +
            //    "\n Version day  [{4}]\n Version month [{5}]\n Version year [{6}]\n",
            //    ICDMajor, ICDMinor ,UnitMajorNumber, UnitMinorNumber, VersionDay, VersionMonth, VersionYear);
        }
        static public string ParseKratosFrame(KratosProtocolFrame i_Parsedframe)
        {
            string ret = string.Empty ;

            if(i_Parsedframe == null )
            {
                return "frame received as null";
            }
            int intValue = int.Parse(i_Parsedframe.Preamble, System.Globalization.NumberStyles.HexNumber);
            if (intValue != 0x5300)
            {
                return "Not a Miniada frame  " + i_Parsedframe.Preamble;
            }
            else
            {
                switch(i_Parsedframe.Opcode)
                {
                    case "0100":
                        ret = GetSoftwareVertion(i_Parsedframe);
                        
                        break;

                    case "0200":
                        ret = GetFirmwareVertion(i_Parsedframe);

                        break;

                    case "0400":
                        ret = GetSerialNumber(i_Parsedframe);

                        break;

                    case "0600":
                        ret = SetLogLevel(i_Parsedframe);

                        break;

                    case "0700":
                        ret = IsSystemBusy(i_Parsedframe);

                        break;

                    case "0800":
                        ret = GetSystemType(i_Parsedframe);

                        break;

                    case "1000":
                        ret = GetIdentityInformation(i_Parsedframe);

                        break;

                    case "1100":
                        ret = SetIdentityInformation(i_Parsedframe);

                        break;

                    case "1200":
                        ret = GetCoreCardInformation(i_Parsedframe);

                        break;

                    case "1300":
                        ret = SetCoreCardInformation(i_Parsedframe);

                        break;

                    case "1400":
                        ret = GetRFCardInformation(i_Parsedframe);

                        break;

                    case "1500":
                        ret = SetRFCardInformation(i_Parsedframe);

                        break;

                    case "1600":
                        ret = GetPSUCardInformation(i_Parsedframe);

                        break;

                    case "1700":
                        ret = SetPSUCardInformation(i_Parsedframe);

                        break;

                    case "1E00":
                        ret = SetSynthesizerL1(i_Parsedframe);

                        break;

                    case "1F00":
                        ret = SetSynthesizerL2(i_Parsedframe);

                        break;

                    case "2000":
                        ret = SetTxAD936X(i_Parsedframe);

                        break;

                    case "2100":
                        ret = GetTxAD936X(i_Parsedframe);

                        break;

                    case "2600":
                        ret = DoSync(i_Parsedframe);

                        break;

                    case "2800":
                        ret = SetSytemState(i_Parsedframe);

                        break;

                    case "2900":
                        ret = GetSytemState(i_Parsedframe);

                        break;

                    case "3000":
                        ret = StoreDataInFlash(i_Parsedframe);

                        break;

                    case "3100":
                        ret = LoadDataInFlash(i_Parsedframe);

                        break;

                    case "5600":
                        ret = SetRXChannelGain(i_Parsedframe);

                        break;

                    case "5700":
                        ret = GetRXChannelGain(i_Parsedframe);

                        break;

                    case "5800":
                        ret = SetDCA(i_Parsedframe);

                        break;

                    case "5900":
                        ret = GetDCA(i_Parsedframe);

                        break;

                    case "5C00":
                        ret = RxGetRFPLLlockDetect(i_Parsedframe);

                        break;

                    case "5D00":
                        ret = TxGetRFPLLlockDetect(i_Parsedframe);

                        break;

                    case "2A00":
                        ret = SetOutputPower(i_Parsedframe);

                        break;

                    case "2B00":
                        ret = GetOutputPower(i_Parsedframe);

                        break;

                    case "2E00":
                        ret = SetTXCO_ON_OFF(i_Parsedframe);

                        break;

                    case "2F00":
                        ret = SetTXCO_ON_OFF(i_Parsedframe);

                        break;

                    case "7000":
                        ret = Read_FPGA_Data(i_Parsedframe);

                        break;

                    case "7100":
                        ret = Write_FPGA_Data(i_Parsedframe);

                        break;

                    case "7400":
                        ret = SetGPIODirection(i_Parsedframe);

                        break;

                    case "7500":
                        ret = GetGPIODirection(i_Parsedframe);

                        break;

                    case "7600":
                        ret = SetGPIOValue(i_Parsedframe);

                        break;

                    case "7700":
                        ret = GetGPIOValue(i_Parsedframe);

                        break;

                    case "8000":
                        ret = RecordIQData(i_Parsedframe);

                        break;

                    case "8100":
                        ret = RecordIQDaraSelectSource(i_Parsedframe);

                        break;

                    case "8700":
                        ret = SetRxChannelStateCal(i_Parsedframe);

                        break;

                    case "D000":
                        ret = GetUbloxData(i_Parsedframe);

                        break;
                }
            
            }

            return ret;

        }
    }
}
