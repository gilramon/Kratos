using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitor
{
    class KratosProtocolFrame
    {
        public string Preamble;
        public string Opcode;
        public string Data;
        public string DataLength;
    }

    class Kratos_Protocol
    {
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
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static string ByteArrayToString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "");
        }

        static public byte[] EncodeKratusProtocol(string i_Preamble, string i_Opcode, string i_Data)
        {
            try
            {
                List<byte> ListBytes = new List<byte>();

                ListBytes.AddRange(StringToByteArray(i_Preamble));

                ListBytes.AddRange(StringToByteArray(i_Opcode));

                byte[] DataBytes = StringToByteArray(i_Data);
                UInt32 Datalength = (UInt32)DataBytes.Length;
                byte[] intBytes = BitConverter.GetBytes(Datalength);
                ListBytes.AddRange(intBytes);


                ListBytes.AddRange(DataBytes);

                UInt16 CheckSum = 0;

                for (int i = 0; i < ListBytes.Count; i++)
                {
                    CheckSum += ListBytes[i];
                }
                intBytes = BitConverter.GetBytes(CheckSum);
                ListBytes.AddRange(intBytes);

                byte[] Ret = ListBytes.ToArray();

                return Ret;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        static public KratosProtocolFrame DecodeKratusProtocol(byte[] i_IncomingBytes)
        {
            KratosProtocolFrame Ret = new KratosProtocolFrame();

            try
            {
                byte[] DataLengthBytes = i_IncomingBytes.Skip(4).Take(4).ToArray();

                UInt32 FrameDataLength = BitConverter.ToUInt32(DataLengthBytes, 0);
                int CheckSumIndex = (int)FrameDataLength + 8;


                UInt16 CheckSumCalc = 0;

                for (int i = 0; i < CheckSumIndex; i++)
                {
                    CheckSumCalc += i_IncomingBytes[i];
                }

                byte[] CheckSumBytes = i_IncomingBytes.Skip(CheckSumIndex).Take(2).ToArray();
                UInt16 CheckSumSent = BitConverter.ToUInt16(CheckSumBytes, 0);

                if (CheckSumSent == CheckSumCalc)
                {
                    
                    Ret.Preamble = ByteArrayToString(i_IncomingBytes.Skip(0).Take(2).ToArray());

                    Ret.Opcode = ByteArrayToString(i_IncomingBytes.Skip(2).Take(2).ToArray());

                    Ret.Data = ByteArrayToString(i_IncomingBytes.Skip(8).Take((int)FrameDataLength).ToArray());

                    Ret.DataLength = FrameDataLength.ToString();
                    
                    return Ret;


                }
                else
                {
                    throw new Exception("Check sum failed!");

                }

            }
            catch
            {
                //MessageBox.Show(ex.Message);
                return null;
            }
        }

    }
}
