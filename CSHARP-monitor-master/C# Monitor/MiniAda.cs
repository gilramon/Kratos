using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor
{
    class MiniAda
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
            int VersionDay = int.Parse(i_Parsedframe.Data.Substring(8, 2), System.Globalization.NumberStyles.HexNumber);
            int VersionMonth = int.Parse(i_Parsedframe.Data.Substring(10, 2), System.Globalization.NumberStyles.HexNumber);
            int VersionYear = int.Parse(i_Parsedframe.Data.Substring(14, 2) + i_Parsedframe.Data.Substring(12, 2), System.Globalization.NumberStyles.HexNumber);  //Gil: because it is little endian so I need to reverse the bytes
            return String.Format("\n ICD major version [{0}]\n ICD minor version [{1}]\n Unit major version [{2}]\n Unit minor version [{3}]" +
                "\n Version day  [{4}]\n Version month [{5}]\n Version year [{6}]\n",
                ICDMajor, ICDMinor ,UnitMajorNumber, UnitMinorNumber, VersionDay, VersionMonth, VersionYear);
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
                }
            
            }

            return ret;

        }
    }
}
