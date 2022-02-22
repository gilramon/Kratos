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

           // int ICDMajor = int.Parse(i_Parsedframe.Data.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
           // int ICDMinor = int.Parse(i_Parsedframe.Data.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
            int UnitMajorNumber = int.Parse(i_Parsedframe.Data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            int UnitMinorNumber = int.Parse(i_Parsedframe.Data.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            int VersionDay = int.Parse(i_Parsedframe.Data.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            int VersionMonth = int.Parse(i_Parsedframe.Data.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
            int VersionYear = int.Parse(i_Parsedframe.Data.Substring(8, 4), System.Globalization.NumberStyles.HexNumber);
            return String.Format(" UnitMajorNumber {0} \n UnitMinorNumber {1} \n VersionDay {2} \n VersionMonth {3} \n VersionYear {4} \n ",  UnitMajorNumber, UnitMinorNumber, VersionDay, VersionMonth, VersionYear);
        }
        static public string ParseKratosFrame(KratosProtocolFrame i_Parsedframe)
        {
            string ret = string.Empty ;
            int intValue = int.Parse(i_Parsedframe.Preamble, System.Globalization.NumberStyles.HexNumber);
            if (intValue != 0x5300)
            {
                return "Not a Miniada frame  " + i_Parsedframe.Preamble;
            }
            else
            {
                switch(i_Parsedframe.Opcode)
                {
                    case "7000":
                        ret = GetSoftwareVertion(i_Parsedframe);
                        
                        break;
                }
            }

            return ret;

        }
    }
}
