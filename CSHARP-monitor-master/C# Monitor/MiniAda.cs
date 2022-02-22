using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor
{
    class MiniAda
    {
        static string GetSoftwareVertion(KratosProtocolFrame i_Parsedframe)
        {

             int ICDMajor = int.Parse(i_Parsedframe.Data.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
             int ICDMinor = int.Parse(i_Parsedframe.Data.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
            int UnitMajorNumber = int.Parse(i_Parsedframe.Data.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            int UnitMinorNumber = int.Parse(i_Parsedframe.Data.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
            int VersionDay = int.Parse(i_Parsedframe.Data.Substring(8, 2), System.Globalization.NumberStyles.HexNumber);
            int VersionMonth = int.Parse(i_Parsedframe.Data.Substring(10, 2), System.Globalization.NumberStyles.HexNumber);
            int VersionYear = int.Parse(i_Parsedframe.Data.Substring(14, 2) + i_Parsedframe.Data.Substring(12, 2), System.Globalization.NumberStyles.HexNumber);  //Gil: because it is little endian so I need to reverse the bytes
            return String.Format(" ICDMajor {0} \n ICDMinor {1} \n UnitMajorNumber {2} \n UnitMinorNumber {3} \n VersionDay {4} \n VersionMonth {5} \n VersionYear {6} \n ", ICDMajor, ICDMinor ,UnitMajorNumber, UnitMinorNumber, VersionDay, VersionMonth, VersionYear);
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
                }
            }

            return ret;

        }
    }
}
