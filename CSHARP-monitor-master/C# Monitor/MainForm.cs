using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Text.RegularExpressions;
using Monitor;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.Globalization;

namespace SocketServer
{


    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class MainForm : System.Windows.Forms.Form
    {
        /// <summary>
        /// 
        /// </summary>
		public AsyncCallback pfnWorkerCallBack;
        /// <summary>
        /// 
        /// </summary>
		public Socket m_socListener;
        /// <summary>
        /// 
        /// </summary>
		public Socket m_socWorker;
        private System.Windows.Forms.GroupBox groupBox_ServerSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPortNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDataTx;
        private System.Windows.Forms.Button button1;
        //TcpListener tcpListener;
        //private Thread listenThread;
        private CheckBox ListenBox;
        //NetworkStream clientStream;

        bool New_Line = false;
        bool Show_Time;
        private TabControl tabControl_Main;
        private TabPage tabPage_SerialPort;
        private ToolTip toolTip1;
        private IContainer components;
        private GroupBox groupBox5;
        private CheckBox checkBox_S1Pause;
        private Button txtS1_Clear;
        private RichTextBox SerialPortLogger_TextBox;
        private GroupBox S1_Configuration;
        private GroupBox groupBox12;
        private Button button13;
        private GroupBox groupBox22;
        private Button button19;
        private GroupBox groupBox28;
        private Button button25;
        private TextBox textBox_ModemPrimeryPort;
        private TextBox textBox_ModemPrimeryHost;
        private GroupBox groupBox30;
        private TextBox textBox_ForginPassword;
        private Button button27;
        private TextBox textBox_ForginAcessPoint;
        private TextBox textBox_ForginSecondaryDNS;
        private TextBox textBox_ForginUserName;
        private TextBox textBox_ForginPrimeryDNS;
        private GroupBox groupBox29;
        private TextBox textBox_HomePassword;
        private Button button26;
        private TextBox textBox_HomeAcessPoint;
        private TextBox textBox_HomeSecondaryDNS;
        private TextBox textBox_HomeUserName;
        private TextBox textBox_HomePrimeryDNS;
        private GroupBox groupBox27;
        private Button button24;
        private GroupBox groupBox26;
        private Button button23;
        private GroupBox groupBox25;
        private Button button22;
        private GroupBox groupBox24;
        private ComboBox comboBox_DispatchSpeed;
        private Button button21;
        private GroupBox groupBox23;
        private ComboBox comboBox_KillEngine;
        private Button button20;
        private GroupBox groupBox21;
        private ComboBox comboBox_TiltTowSensState;
        private Button button18;
        private GroupBox groupBox20;
        private ComboBox comboBox_HitState;
        private Button button17;
        private GroupBox groupBox19;
        private ComboBox comboBox_ShockState;
        private Button button16;
        private GroupBox groupBox18;
        private ComboBox comboBox1_TiltState;
        private Button button15;
        private GroupBox groupBox17;
        private Button button14;
        private GroupBox groupBox11;
        private ComboBox comboBox_SleepPolicy;
        private Button button12;
        private GroupBox groupBox10;
        private ComboBox comboBox_AlarmPilicy;
        private Button button11;
        private GroupBox groupBox9;
        private DateTimePicker dateTimePicker_SetTimeDate;
        private Button button10;
        private GroupBox groupBox8;
        private ComboBox comboBox_BatThreshold;
        private Button button9;
        private GroupBox groupBox7;
        private ComboBox comboBox_OutputNum;
        private ComboBox comboBox_OutputControl;
        private Button button8;
        private ComboBox comboBox_OutputPulseLevel;
        private GroupBox groupBox6;
        private ComboBox comboBox_InputNum1;
        private ComboBox comboBox_Interupt;
        private Button button7;
        private GroupBox groupBox13;
        private Button btn_ChangePassword;
        private TextBox textBox_NewPassword;
        private GroupBox groupBox14;
        private ComboBox comboBox_SMSControl;
        private Button button_SMSControl;
        private GroupBox groupBox15;
        private ComboBox comboBox_InputIndex;
        private Button button_SetFreeText;
        private GroupBox groupBox16;
        private Button button4;
        private TabPage tabPage5;
        private TextBox maskedTextBox3_Subscriber3;
        private TextBox maskedTextBox2_Subscriber2;
        private TextBox maskedTextBox1_Subscriber1;
        private TextBox maskedTextBox_OutputDuration;
        private TextBox maskedTextBox_InputDuration;
        private TextBox maskedTextBox1;
        private TextBox TextBox_NormalStatusDuration;
        private TextBox textBox_FreeText;
        private TextBox textBox_ModemSocket;
        private TextBox textBox_ModemRetries;
        private TextBox textBox_ModemTimeOut;
        private TextBox TextBox_Odometer;
        private TextBox maskedTextBox_TowDetectNum;
        private TextBox maskedTextBox_TowWindow;
        private TextBox maskedTextBox_TowAngle;
        private TextBox maskedTextBox_TiltDetectNum;
        private TextBox maskedTextBox_TiltWindow;
        private TextBox maskedTextBox_TiltAngle;
        private TextBox maskedTextBox_ShockDetectNum;
        private TextBox maskedTextBox_ShockWindow;
        private TextBox maskedTextBox_SpeedLimit2;
        private TextBox maskedTextBox_SpeedLimit3;
        private TextBox maskedTextBox_SpeedLimit1;
        private TextBox maskedTextBox_TiltTowSens;
        private TextBox maskedTextBox_HitSensitivity;
        private TabPage tabPage_Configuration;
        private OpenFileDialog openFileDialog1;
        private CheckBox checkBox_S1RecordLog;
        private System.Windows.Forms.Timer timer_General_100ms;
        private TextBox textBox_NumberOfOpenConnections;
        private System.Windows.Forms.Timer timer_General_1Second;
        private GroupBox gbPortSettings;
        private ComboBox cmbPortName;
        private ComboBox cmbBaudRate;
        private ComboBox cmbStopBits;
        private ComboBox cmbParity;
        private ComboBox cmbDataBits;
        private Label lblComPort;
        private Label lblStopBits;
        private Label lblBaudRate;
        private Label lblDataBits;
        private Label label3;
        private System.IO.Ports.SerialPort serialPort;
        private GroupBox groupBox_ConnectionTimedOut;
        private TextBox textBox_ConnectionTimedOut;
        private Button button_SetTimedOut;
        private TextBox textBox_CurrentTimeOut;
        private TextBox textBox_ServerOpen;
        private TabPage tabPage_ServerTCP;
        private TabPage tabPage4;
        private GroupBox groupBox36;
        private TextBox textBox_SMSPhoneNumber;
        private GroupBox groupBox_PhoneNumber;
        private ToolTip toolTip2;
        private CheckBox checkBox_EchoResponse;
        private GroupBox groupBox_FOTA;
        private Button button5;
        private TextBox textBox_FOTA;
        private TextBox textBox_TotalFrames1280Bytes;
        private Button button_StartFOTA;
        private Button button35;
        private ComboBox comboBox_ConnectionNumber;
        private GroupBox groupBox_SendSerialOrMonitorCommands;
        private Button button_SendSerialPort;
        private TabPage tabPage_SMS;
        private GroupBox groupBox33;
        private Button button_AddContact;
        private CheckedListBox checkedListBox_PhoneBook;
        private GroupBox groupBox34;
        private RichTextBox richTextBox_TextSendSMS;
        private Button button_ImportToXML;
        private Button button_ExportToXML;
        private Button button_RemoveContact;
        private GroupBox groupBox37;
        private RichTextBox richTextBox_SMSConsole;
        private CheckBox checkBox_RecordSMSConsole;
        private CheckBox checkBox_PauseSMSConsole;
        private Button button_ClearSMSConsole;
        private GroupBox groupBox35;
        private RichTextBox richTextBox_ModemStatus;
        private Button button_SendSelectedSMS;
        private Button button_SendAllCheckedSMS;
        private Button button33;
        private Button button36;
        private Label label_SMSSendCharacters;
        private TextBox textBox_SerialPortRecognizePattern;
        private RichTextBox textBox_MaximumNumberReceivedRequest;
        private TextBox textBox_TotalFileLength;
        private GroupBox groupBox39;
        private Button button37;
        private Button button38;
        private Button button39;
        private Button button40;
        private Button button41;
        private CheckBox checkBox_SendSMSAsIs;
        private CheckBox checkBox1;
        private Button button_StartFOTAProcess;
        private RichTextBox textBox_IDKey;
        private CheckBox checkBox_OpenPortSMS;
        private ComboBox comboBox_ComportSMS;
        private SerialPort serialPort_SMS;
        private CheckBox checkBox_DebugSMS;
        private RichTextBox richTextBox_ContactDetails;
        private CheckBox checkBox_SMSencrypted;
        private GroupBox GrooupBox_Encryption;
        private TextBox textBox_UnitIDForSMS;
        private Label label5;
        private TextBox textBox_CodeArrayForSMS;
        private Label label2;
        private TextBox textBox_SerialPortRecognizePattern2;
        private TextBox textBox_SerialPortRecognizePattern3;
        private Button button34;
        private Button button_Ring;
        private Button button_ReScanComPort;
        private Button button_StopwatchReset;
        private Button button_Stopwatch_Start_Stop;
        private TextBox textBox_StopWatch;
        private GroupBox groupBox_Stopwatch;
        private Button button_TimerLog;
        private CheckBox checkBox_ParseMessages;
        private GroupBox groupBox_Timer;
        private Button button_StartStopTimer;
        private Button button_ResetTimer;
        private TextBox textBox_SetTimerTime;
        private TextBox textBox_TimerTime;
        private GroupBox groupBox38;
        private Button button6;
        private Button button31;
        private RichTextBox textBox_SourceConfig;
        private Button button32;
        private Button button29;
        private Button button2;
        private Button button30;
        private Button button_OpenFolder;
        private CheckBox checkBox_DeleteCommand;
        private TabPage tabPage_charts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Button button_ScreenShot;
        private ListBox listBox_SMSCommands;
        private TextBox textBox_SendSerialPort;
        private TextBox textBox_graph_XY;
        private Button button_ResetGraphs;
        private Button Button_Export_excel;
        private Button button_GraphPause;
        private Button button_OpenFolder2;
        private TabPage tabPage_ClientTCP;
        private Button button43;
        private Button button_ClientClose;
        private Button button_ClientConnect;
        private Button button3;
        private RichTextBox richTextBox_ClientTx;
        private TextBox textBox_ClientPort;
        private TextBox textBox_ClientIP;
        private Label label8;
        private Label label7;
        private Label label10;
        private Label label9;
        private Button button_ClearRx;
        private RichTextBox richTextBox_ClientRx;
        private ListBox listBox_Charts;
        private Label Label_SerialPortRx;
        private Label label_SerialPortConnected;
        private Label Label_SerialPortTx;
        private GroupBox groupBox_SerialPort;
        private Button button28;
        private CheckBox checkBox_RxHex;
        private CheckBox checkBox_SendHexdata;
        private Button button_OpenPort;
        private ComboBox comboBox_ChartUpdateTime;
        private TextBox textBox1;
        private TabControl tabControl_systems;
        private TabPage tabPage11;
        private TabPage tabPage12;
        private Button button44;
        private Button button42;
        private GroupBox groupBox1;
        private TextBox textBox_InternalCLIoutput;
        private GroupBox groupBox4;
        private TextBox textBox_SystemStatus;
        private TabPage tabPage10;
        private TextBox textBox_Config4;
        private TextBox textBox_Config6;
        private TextBox textBox_Config8;
        private TextBox textBox_Config9;
        private TextBox textBox_Config10;
        private TextBox textBox_Config11;
        private TextBox textBox_Config12;
        private TextBox textBox_Config20;
        private TextBox textBox_Config21;
        private TextBox textBox_Config22;
        private TextBox textBox_Config36;
        private TextBox textBox_Config35;
        private PictureBox pictureBox1;
        private TabPage tabPage_GenericFrame;
        private Button button_SendProtocol;
        private TextBox textBox_data;
        private TextBox textBox_Opcode;
        private TextBox textBox_Preamble;
        private Label label11;
        private Label label6;
        private Label label4;
        private GroupBox groupBox_ClentTCPStatus;
        private Label label12;
        private Label label_ClientTCPConnected;
        private Label label14;
        private Button button_ClearServer;
        private GroupBox groupBox31;
        private Label label13;
        private TextBox textBox_RxClientPreamble;
        private TextBox textBox_RxClientOpcode;
        private TextBox textBox_RxClientData;
        private Label label15;
        private Label label16;
        private GroupBox groupBox_clientTX;
        private Label label_SerialPortStatus;
        private Label label_TCPClient;
        private TabPage tabPage_MiniAda;
        private GroupBox groupBox40;
        private Button button_GetSoftwareVersion;
        private GroupBox groupBox32;
        private RichTextBox richTextBox_MiniAda;
        private CheckBox checkBox_RecordMiniAda;
        private CheckBox checkBox_PauseMiniAda;
        private Button button_ClearMiniAda;
        private Label label17;
        private Label label18;
        private Button button45;
        private Button button46;
        private Button button47;
        private TextBox textBox_LogLevel;
        private Button button48;
        private Button button49;
        private Button button50;
        private TextBox textBox_SystemIdentify;
        private Button button51;
        private Button button52;
        private Button button53;
        private TabControl tabControl_MiniAda;
        private TabPage tabPage1;
        private TextBox textBox_SetCoreCardInformation;
        private Button button54;
        private TextBox textBox_SetRFCardInformation;
        private Button button55;
        private Button button56;
        private TextBox textBox_SetPSUCard;
        private Button button57;
        private Button button58;
        private TabPage tabPage2;
        private TextBox textBox_SetSynthesizerL1;
        private Button button59;
        private Label label19;
        private Label label20;
        private TextBox textBox_SetSynthesizerL2;
        private Button button60;
        private Label label21;
        private TextBox textBox_SetTxAD936X;
        private Button button61;
        private Button button62;
        private Label label22;
        private TextBox textBox_GetTxAD936X;
        private TextBox textBox_RxClientDataLength;
        private Label label23;
        private Label label24;
        private GroupBox groupBox3;
        private CheckBox checkBox_StopLogging;
        private RichTextBox TextBox_Server;
        private CheckBox checkBox_RecordGeneral;
        private CheckBox PauseCheck;
        private Button Clear_btn;
        private Button button63;
        private Label label25;
        private TextBox textBox_SetSyestemState;
        private Button button64;
        private Button button65;
        private Label label26;
        private TextBox textBox_SetSystemOutputPower;
        private Button button66;
        private Button button67;
        private Button button68;
        private Label label27;
        private TextBox textBox_TCXOOnOff;
        private TextBox textBox_ServerActive;
        private Label label28;
        private TextBox textBox_SetTCXOTrim;
        private Button button69;
        private TabPage tabPage3;
        private Label label29;
        private TextBox textBox_WriteFPGARegister;
        private Button button70;
        private Label label30;
        private TextBox textBox_ReadFPGARegister;
        private Button button71;
        private Button button_Ping;
        private TextBox textBox_LoadDatainFlash;
        private Button button73;
        private TextBox textBox_StoreDatainFlash;
        private Button button72;
        private TabPage tabPage6;
        private Button button79;
        private Button button78;
        private Button button74;
        private TextBox textBox_SetDCA;
        private Button button75;
        private Button button76;
        private TextBox textBox_SetRXChannelGain;
        private Button button77;
        private TextBox textBox_GetRXChannelGain;
        private TextBox textBox_TxRFPLL;
        private TextBox textBox_RxRFPLL;
        private Label label31;
        private TextBox textBox_SetDCAHex;
        private TextBox textBox_GetGPIOVal;
        private Button button82;
        private TextBox textBox_SetGPIOVal;
        private Button button83;
        private TextBox textBox_GetGPIODir;
        private Button button80;
        private TextBox textBox_SetGPIODir;
        private Button button81;
        private TabPage tabPage7;
        private TextBox textBox_RecordIQData;
        private Button button_RecordIQData;
        private Label label32;
        private Label label33;
        private TextBox textBox_RecordIQSourceSealect;
        private Button button84;
        private Label label34;
        private TextBox textBox_SetRxChannelState;
        private Button button85;
        private TabPage tabPage8;
        private CheckBox checkBox_ServerRecord;
        private CheckBox checkBox_ServerPause;
        private TabPage tabPage9;
        private Button button86;
        static readonly string MINIADA_HEADER = "53 00";
        //bool m_Exit = false;

        ///// <summary> Convert a string of hex digits (ex: E4 CA B2) to a byte array. </summary>
        ///// <param name="s"> The string containing the hex digits (with or without spaces). </param>
        ///// <returns> Returns an array of bytes. </returns>
        //private byte[] HexStringToByteArray(string s)
        //{
        //    s = s.Replace(" ", "");
        //    byte[] buffer = new byte[s.Length / 2];
        //    for (int i = 0; i < s.Length; i += 2)
        //    {
        //        buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
        //    }
        //    return buffer;
        //}

        ///// <summary> Converts an array of bytes into a formatted string of hex digits (ex: E4 CA B2)</summary>
        ///// <param name="data"> The array of bytes to be translated into a string of hex digits. </param>
        ///// <returns> Returns a well formatted string of hex digits with spacing. </returns>
        //private string ByteArrayToHexString(byte[] data)
        //{
        //    StringBuilder sb = new StringBuilder(data.Length * 3);
        //    foreach (byte b in data)
        //    {
        //        if (b == 0)
        //        {
        //            //sb.Append("00 ");
        //        }
        //        else
        //        {
        //            sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
        //        }
        //    }
        //    return sb.ToString().ToUpper();
        //}


        class LogClass
        {
            public string Msg { get; set; }
            public Color Log_Color { get; set; }
            public Color Log_TextBackgroundColor { get; set; }
        }







        /// <summary>
        /// 
        /// </summary>
        public MainForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            try
            {
                //if( disposing )
                //{
                //    //if (components != null) 
                //    //{
                //    //    components.Dispose();
                //    //}
                //}

                base.Dispose(disposing);

                //if (this.tcpListener != null)
                //{
                //    //this.tcpListener.Server.Disconnect(false);
                //    if (this.clientStream != null)
                //    {
                //        this.clientStream.Close();
                //    }
                //    this.tcpListener.Server.Close();
                //    this.tcpListener.Stop();

                //}

                //if (listenThread != null)
                //{
                //    listenThread.Abort();
                //    m_Exit = true;

                //}

                if (m_Server != null)
                {
                    m_Server.Close_Server();
                }


            }
            catch
            {
            }


        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series19 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series20 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series21 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox_ServerSettings = new System.Windows.Forms.GroupBox();
            this.textBox_ServerOpen = new System.Windows.Forms.TextBox();
            this.textBox_ServerActive = new System.Windows.Forms.TextBox();
            this.txtPortNo = new System.Windows.Forms.TextBox();
            this.textBox_NumberOfOpenConnections = new System.Windows.Forms.TextBox();
            this.ListenBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_ConnectionNumber = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtDataTx = new System.Windows.Forms.TextBox();
            this.tabControl_Main = new System.Windows.Forms.TabControl();
            this.tabPage_SMS = new System.Windows.Forms.TabPage();
            this.groupBox39 = new System.Windows.Forms.GroupBox();
            this.listBox_SMSCommands = new System.Windows.Forms.ListBox();
            this.button37 = new System.Windows.Forms.Button();
            this.button38 = new System.Windows.Forms.Button();
            this.button39 = new System.Windows.Forms.Button();
            this.button40 = new System.Windows.Forms.Button();
            this.button41 = new System.Windows.Forms.Button();
            this.groupBox37 = new System.Windows.Forms.GroupBox();
            this.richTextBox_SMSConsole = new System.Windows.Forms.RichTextBox();
            this.checkBox_RecordSMSConsole = new System.Windows.Forms.CheckBox();
            this.checkBox_PauseSMSConsole = new System.Windows.Forms.CheckBox();
            this.button_ClearSMSConsole = new System.Windows.Forms.Button();
            this.groupBox35 = new System.Windows.Forms.GroupBox();
            this.checkBox_DebugSMS = new System.Windows.Forms.CheckBox();
            this.checkBox_OpenPortSMS = new System.Windows.Forms.CheckBox();
            this.button36 = new System.Windows.Forms.Button();
            this.comboBox_ComportSMS = new System.Windows.Forms.ComboBox();
            this.richTextBox_ModemStatus = new System.Windows.Forms.RichTextBox();
            this.groupBox34 = new System.Windows.Forms.GroupBox();
            this.button_Ring = new System.Windows.Forms.Button();
            this.GrooupBox_Encryption = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_CodeArrayForSMS = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_UnitIDForSMS = new System.Windows.Forms.TextBox();
            this.checkBox_SMSencrypted = new System.Windows.Forms.CheckBox();
            this.checkBox_SendSMSAsIs = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label_SMSSendCharacters = new System.Windows.Forms.Label();
            this.button_SendSelectedSMS = new System.Windows.Forms.Button();
            this.button_SendAllCheckedSMS = new System.Windows.Forms.Button();
            this.richTextBox_TextSendSMS = new System.Windows.Forms.RichTextBox();
            this.groupBox33 = new System.Windows.Forms.GroupBox();
            this.button34 = new System.Windows.Forms.Button();
            this.richTextBox_ContactDetails = new System.Windows.Forms.RichTextBox();
            this.button33 = new System.Windows.Forms.Button();
            this.button_ImportToXML = new System.Windows.Forms.Button();
            this.button_ExportToXML = new System.Windows.Forms.Button();
            this.button_RemoveContact = new System.Windows.Forms.Button();
            this.button_AddContact = new System.Windows.Forms.Button();
            this.checkedListBox_PhoneBook = new System.Windows.Forms.CheckedListBox();
            this.tabPage_Configuration = new System.Windows.Forms.TabPage();
            this.tabControl_systems = new System.Windows.Forms.TabControl();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.textBox_Config4 = new System.Windows.Forms.TextBox();
            this.textBox_Config6 = new System.Windows.Forms.TextBox();
            this.textBox_Config8 = new System.Windows.Forms.TextBox();
            this.textBox_Config9 = new System.Windows.Forms.TextBox();
            this.textBox_Config10 = new System.Windows.Forms.TextBox();
            this.textBox_Config11 = new System.Windows.Forms.TextBox();
            this.textBox_Config12 = new System.Windows.Forms.TextBox();
            this.textBox_Config20 = new System.Windows.Forms.TextBox();
            this.textBox_Config21 = new System.Windows.Forms.TextBox();
            this.textBox_Config22 = new System.Windows.Forms.TextBox();
            this.textBox_Config36 = new System.Windows.Forms.TextBox();
            this.textBox_Config35 = new System.Windows.Forms.TextBox();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.button32 = new System.Windows.Forms.Button();
            this.groupBox38 = new System.Windows.Forms.GroupBox();
            this.button44 = new System.Windows.Forms.Button();
            this.button42 = new System.Windows.Forms.Button();
            this.button29 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button31 = new System.Windows.Forms.Button();
            this.textBox_SourceConfig = new System.Windows.Forms.RichTextBox();
            this.button30 = new System.Windows.Forms.Button();
            this.tabPage_charts = new System.Windows.Forms.TabPage();
            this.comboBox_ChartUpdateTime = new System.Windows.Forms.ComboBox();
            this.button28 = new System.Windows.Forms.Button();
            this.listBox_Charts = new System.Windows.Forms.ListBox();
            this.button_OpenFolder2 = new System.Windows.Forms.Button();
            this.button_GraphPause = new System.Windows.Forms.Button();
            this.Button_Export_excel = new System.Windows.Forms.Button();
            this.button_ResetGraphs = new System.Windows.Forms.Button();
            this.textBox_graph_XY = new System.Windows.Forms.TextBox();
            this.button_ScreenShot = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage_SerialPort = new System.Windows.Forms.TabPage();
            this.groupBox_SendSerialOrMonitorCommands = new System.Windows.Forms.GroupBox();
            this.checkBox_SendHexdata = new System.Windows.Forms.CheckBox();
            this.textBox_SendSerialPort = new System.Windows.Forms.TextBox();
            this.checkBox_DeleteCommand = new System.Windows.Forms.CheckBox();
            this.button_SendSerialPort = new System.Windows.Forms.Button();
            this.gbPortSettings = new System.Windows.Forms.GroupBox();
            this.button_OpenPort = new System.Windows.Forms.Button();
            this.button_ReScanComPort = new System.Windows.Forms.Button();
            this.cmbPortName = new System.Windows.Forms.ComboBox();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.cmbStopBits = new System.Windows.Forms.ComboBox();
            this.cmbParity = new System.Windows.Forms.ComboBox();
            this.cmbDataBits = new System.Windows.Forms.ComboBox();
            this.lblComPort = new System.Windows.Forms.Label();
            this.lblStopBits = new System.Windows.Forms.Label();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.lblDataBits = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox_Timer = new System.Windows.Forms.GroupBox();
            this.textBox_TimerTime = new System.Windows.Forms.TextBox();
            this.button_StartStopTimer = new System.Windows.Forms.Button();
            this.button_ResetTimer = new System.Windows.Forms.Button();
            this.textBox_SetTimerTime = new System.Windows.Forms.TextBox();
            this.groupBox_Stopwatch = new System.Windows.Forms.GroupBox();
            this.button_TimerLog = new System.Windows.Forms.Button();
            this.button_Stopwatch_Start_Stop = new System.Windows.Forms.Button();
            this.button_StopwatchReset = new System.Windows.Forms.Button();
            this.textBox_StopWatch = new System.Windows.Forms.TextBox();
            this.checkBox_RxHex = new System.Windows.Forms.CheckBox();
            this.textBox_SerialPortRecognizePattern3 = new System.Windows.Forms.TextBox();
            this.textBox_SerialPortRecognizePattern2 = new System.Windows.Forms.TextBox();
            this.textBox_SerialPortRecognizePattern = new System.Windows.Forms.TextBox();
            this.checkBox_S1RecordLog = new System.Windows.Forms.CheckBox();
            this.checkBox_S1Pause = new System.Windows.Forms.CheckBox();
            this.txtS1_Clear = new System.Windows.Forms.Button();
            this.SerialPortLogger_TextBox = new System.Windows.Forms.RichTextBox();
            this.tabPage_ServerTCP = new System.Windows.Forms.TabPage();
            this.button_ClearServer = new System.Windows.Forms.Button();
            this.checkBox_ParseMessages = new System.Windows.Forms.CheckBox();
            this.textBox_IDKey = new System.Windows.Forms.RichTextBox();
            this.groupBox_FOTA = new System.Windows.Forms.GroupBox();
            this.button_StartFOTAProcess = new System.Windows.Forms.Button();
            this.textBox_TotalFileLength = new System.Windows.Forms.TextBox();
            this.textBox_MaximumNumberReceivedRequest = new System.Windows.Forms.RichTextBox();
            this.button35 = new System.Windows.Forms.Button();
            this.button_StartFOTA = new System.Windows.Forms.Button();
            this.textBox_TotalFrames1280Bytes = new System.Windows.Forms.TextBox();
            this.textBox_FOTA = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.checkBox_EchoResponse = new System.Windows.Forms.CheckBox();
            this.groupBox_ConnectionTimedOut = new System.Windows.Forms.GroupBox();
            this.textBox_CurrentTimeOut = new System.Windows.Forms.TextBox();
            this.button_SetTimedOut = new System.Windows.Forms.Button();
            this.textBox_ConnectionTimedOut = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox_StopLogging = new System.Windows.Forms.CheckBox();
            this.TextBox_Server = new System.Windows.Forms.RichTextBox();
            this.checkBox_RecordGeneral = new System.Windows.Forms.CheckBox();
            this.PauseCheck = new System.Windows.Forms.CheckBox();
            this.Clear_btn = new System.Windows.Forms.Button();
            this.tabPage_ClientTCP = new System.Windows.Forms.TabPage();
            this.button_Ping = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button_ClearRx = new System.Windows.Forms.Button();
            this.richTextBox_ClientRx = new System.Windows.Forms.RichTextBox();
            this.button43 = new System.Windows.Forms.Button();
            this.button_ClientClose = new System.Windows.Forms.Button();
            this.button_ClientConnect = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.richTextBox_ClientTx = new System.Windows.Forms.RichTextBox();
            this.textBox_ClientPort = new System.Windows.Forms.TextBox();
            this.textBox_ClientIP = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage_GenericFrame = new System.Windows.Forms.TabPage();
            this.button52 = new System.Windows.Forms.Button();
            this.groupBox31 = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.textBox_RxClientDataLength = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_RxClientPreamble = new System.Windows.Forms.TextBox();
            this.textBox_RxClientOpcode = new System.Windows.Forms.TextBox();
            this.textBox_RxClientData = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox_clientTX = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Preamble = new System.Windows.Forms.TextBox();
            this.button_SendProtocol = new System.Windows.Forms.Button();
            this.textBox_Opcode = new System.Windows.Forms.TextBox();
            this.textBox_data = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage_MiniAda = new System.Windows.Forms.TabPage();
            this.groupBox40 = new System.Windows.Forms.GroupBox();
            this.tabControl_MiniAda = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label31 = new System.Windows.Forms.Label();
            this.textBox_SetPSUCard = new System.Windows.Forms.TextBox();
            this.button57 = new System.Windows.Forms.Button();
            this.button58 = new System.Windows.Forms.Button();
            this.textBox_SetRFCardInformation = new System.Windows.Forms.TextBox();
            this.button55 = new System.Windows.Forms.Button();
            this.button56 = new System.Windows.Forms.Button();
            this.textBox_SetCoreCardInformation = new System.Windows.Forms.TextBox();
            this.button54 = new System.Windows.Forms.Button();
            this.button_GetSoftwareVersion = new System.Windows.Forms.Button();
            this.button53 = new System.Windows.Forms.Button();
            this.button45 = new System.Windows.Forms.Button();
            this.textBox_SystemIdentify = new System.Windows.Forms.TextBox();
            this.button46 = new System.Windows.Forms.Button();
            this.button51 = new System.Windows.Forms.Button();
            this.button47 = new System.Windows.Forms.Button();
            this.button50 = new System.Windows.Forms.Button();
            this.textBox_LogLevel = new System.Windows.Forms.TextBox();
            this.button49 = new System.Windows.Forms.Button();
            this.button48 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox_LoadDatainFlash = new System.Windows.Forms.TextBox();
            this.button73 = new System.Windows.Forms.Button();
            this.textBox_StoreDatainFlash = new System.Windows.Forms.TextBox();
            this.button72 = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.textBox_SetTCXOTrim = new System.Windows.Forms.TextBox();
            this.button69 = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.textBox_TCXOOnOff = new System.Windows.Forms.TextBox();
            this.button68 = new System.Windows.Forms.Button();
            this.button67 = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.textBox_SetSystemOutputPower = new System.Windows.Forms.TextBox();
            this.button66 = new System.Windows.Forms.Button();
            this.button65 = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.textBox_SetSyestemState = new System.Windows.Forms.TextBox();
            this.button64 = new System.Windows.Forms.Button();
            this.button63 = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox_GetTxAD936X = new System.Windows.Forms.TextBox();
            this.button62 = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox_SetTxAD936X = new System.Windows.Forms.TextBox();
            this.button61 = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox_SetSynthesizerL2 = new System.Windows.Forms.TextBox();
            this.button60 = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox_SetSynthesizerL1 = new System.Windows.Forms.TextBox();
            this.button59 = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.textBox_SetDCAHex = new System.Windows.Forms.TextBox();
            this.textBox_TxRFPLL = new System.Windows.Forms.TextBox();
            this.textBox_RxRFPLL = new System.Windows.Forms.TextBox();
            this.textBox_GetRXChannelGain = new System.Windows.Forms.TextBox();
            this.button79 = new System.Windows.Forms.Button();
            this.button78 = new System.Windows.Forms.Button();
            this.button74 = new System.Windows.Forms.Button();
            this.textBox_SetDCA = new System.Windows.Forms.TextBox();
            this.button75 = new System.Windows.Forms.Button();
            this.button76 = new System.Windows.Forms.Button();
            this.textBox_SetRXChannelGain = new System.Windows.Forms.TextBox();
            this.button77 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBox_GetGPIOVal = new System.Windows.Forms.TextBox();
            this.button82 = new System.Windows.Forms.Button();
            this.textBox_SetGPIOVal = new System.Windows.Forms.TextBox();
            this.button83 = new System.Windows.Forms.Button();
            this.textBox_GetGPIODir = new System.Windows.Forms.TextBox();
            this.button80 = new System.Windows.Forms.Button();
            this.textBox_SetGPIODir = new System.Windows.Forms.TextBox();
            this.button81 = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.textBox_WriteFPGARegister = new System.Windows.Forms.TextBox();
            this.button70 = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.textBox_ReadFPGARegister = new System.Windows.Forms.TextBox();
            this.button71 = new System.Windows.Forms.Button();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.label34 = new System.Windows.Forms.Label();
            this.textBox_SetRxChannelState = new System.Windows.Forms.TextBox();
            this.button85 = new System.Windows.Forms.Button();
            this.label33 = new System.Windows.Forms.Label();
            this.textBox_RecordIQSourceSealect = new System.Windows.Forms.TextBox();
            this.button84 = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.textBox_RecordIQData = new System.Windows.Forms.TextBox();
            this.button_RecordIQData = new System.Windows.Forms.Button();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.groupBox32 = new System.Windows.Forms.GroupBox();
            this.richTextBox_MiniAda = new System.Windows.Forms.RichTextBox();
            this.checkBox_RecordMiniAda = new System.Windows.Forms.CheckBox();
            this.checkBox_PauseMiniAda = new System.Windows.Forms.CheckBox();
            this.button_ClearMiniAda = new System.Windows.Forms.Button();
            this.button_OpenFolder = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.S1_Configuration = new System.Windows.Forms.GroupBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.button13 = new System.Windows.Forms.Button();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.TextBox_Odometer = new System.Windows.Forms.TextBox();
            this.button19 = new System.Windows.Forms.Button();
            this.groupBox28 = new System.Windows.Forms.GroupBox();
            this.textBox_ModemSocket = new System.Windows.Forms.TextBox();
            this.textBox_ModemRetries = new System.Windows.Forms.TextBox();
            this.textBox_ModemTimeOut = new System.Windows.Forms.TextBox();
            this.button25 = new System.Windows.Forms.Button();
            this.textBox_ModemPrimeryPort = new System.Windows.Forms.TextBox();
            this.textBox_ModemPrimeryHost = new System.Windows.Forms.TextBox();
            this.groupBox30 = new System.Windows.Forms.GroupBox();
            this.textBox_ForginPassword = new System.Windows.Forms.TextBox();
            this.button27 = new System.Windows.Forms.Button();
            this.textBox_ForginAcessPoint = new System.Windows.Forms.TextBox();
            this.textBox_ForginSecondaryDNS = new System.Windows.Forms.TextBox();
            this.textBox_ForginUserName = new System.Windows.Forms.TextBox();
            this.textBox_ForginPrimeryDNS = new System.Windows.Forms.TextBox();
            this.groupBox29 = new System.Windows.Forms.GroupBox();
            this.textBox_HomePassword = new System.Windows.Forms.TextBox();
            this.button26 = new System.Windows.Forms.Button();
            this.textBox_HomeAcessPoint = new System.Windows.Forms.TextBox();
            this.textBox_HomeSecondaryDNS = new System.Windows.Forms.TextBox();
            this.textBox_HomeUserName = new System.Windows.Forms.TextBox();
            this.textBox_HomePrimeryDNS = new System.Windows.Forms.TextBox();
            this.groupBox27 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox1 = new System.Windows.Forms.TextBox();
            this.button24 = new System.Windows.Forms.Button();
            this.groupBox26 = new System.Windows.Forms.GroupBox();
            this.TextBox_NormalStatusDuration = new System.Windows.Forms.TextBox();
            this.button23 = new System.Windows.Forms.Button();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_SpeedLimit2 = new System.Windows.Forms.TextBox();
            this.maskedTextBox_SpeedLimit3 = new System.Windows.Forms.TextBox();
            this.maskedTextBox_SpeedLimit1 = new System.Windows.Forms.TextBox();
            this.button22 = new System.Windows.Forms.Button();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.comboBox_DispatchSpeed = new System.Windows.Forms.ComboBox();
            this.button21 = new System.Windows.Forms.Button();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.comboBox_KillEngine = new System.Windows.Forms.ComboBox();
            this.button20 = new System.Windows.Forms.Button();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_TiltTowSens = new System.Windows.Forms.TextBox();
            this.comboBox_TiltTowSensState = new System.Windows.Forms.ComboBox();
            this.button18 = new System.Windows.Forms.Button();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_HitSensitivity = new System.Windows.Forms.TextBox();
            this.comboBox_HitState = new System.Windows.Forms.ComboBox();
            this.button17 = new System.Windows.Forms.Button();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_ShockDetectNum = new System.Windows.Forms.TextBox();
            this.maskedTextBox_ShockWindow = new System.Windows.Forms.TextBox();
            this.comboBox_ShockState = new System.Windows.Forms.ComboBox();
            this.button16 = new System.Windows.Forms.Button();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_TiltDetectNum = new System.Windows.Forms.TextBox();
            this.maskedTextBox_TiltWindow = new System.Windows.Forms.TextBox();
            this.maskedTextBox_TiltAngle = new System.Windows.Forms.TextBox();
            this.comboBox1_TiltState = new System.Windows.Forms.ComboBox();
            this.button15 = new System.Windows.Forms.Button();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_TowDetectNum = new System.Windows.Forms.TextBox();
            this.maskedTextBox_TowWindow = new System.Windows.Forms.TextBox();
            this.maskedTextBox_TowAngle = new System.Windows.Forms.TextBox();
            this.button14 = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.comboBox_SleepPolicy = new System.Windows.Forms.ComboBox();
            this.button12 = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.comboBox_AlarmPilicy = new System.Windows.Forms.ComboBox();
            this.button11 = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker_SetTimeDate = new System.Windows.Forms.DateTimePicker();
            this.button10 = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.comboBox_BatThreshold = new System.Windows.Forms.ComboBox();
            this.button9 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_OutputDuration = new System.Windows.Forms.TextBox();
            this.comboBox_OutputNum = new System.Windows.Forms.ComboBox();
            this.comboBox_OutputControl = new System.Windows.Forms.ComboBox();
            this.button8 = new System.Windows.Forms.Button();
            this.comboBox_OutputPulseLevel = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_InputDuration = new System.Windows.Forms.TextBox();
            this.comboBox_InputNum1 = new System.Windows.Forms.ComboBox();
            this.comboBox_Interupt = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.btn_ChangePassword = new System.Windows.Forms.Button();
            this.textBox_NewPassword = new System.Windows.Forms.TextBox();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.comboBox_SMSControl = new System.Windows.Forms.ComboBox();
            this.button_SMSControl = new System.Windows.Forms.Button();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.textBox_FreeText = new System.Windows.Forms.TextBox();
            this.comboBox_InputIndex = new System.Windows.Forms.ComboBox();
            this.button_SetFreeText = new System.Windows.Forms.Button();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox3_Subscriber3 = new System.Windows.Forms.TextBox();
            this.maskedTextBox2_Subscriber2 = new System.Windows.Forms.TextBox();
            this.maskedTextBox1_Subscriber1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.textBox_SMSPhoneNumber = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer_General_100ms = new System.Windows.Forms.Timer(this.components);
            this.timer_General_1Second = new System.Windows.Forms.Timer(this.components);
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.groupBox36 = new System.Windows.Forms.GroupBox();
            this.groupBox_PhoneNumber = new System.Windows.Forms.GroupBox();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.serialPort_SMS = new System.IO.Ports.SerialPort(this.components);
            this.Label_SerialPortRx = new System.Windows.Forms.Label();
            this.label_SerialPortConnected = new System.Windows.Forms.Label();
            this.Label_SerialPortTx = new System.Windows.Forms.Label();
            this.groupBox_SerialPort = new System.Windows.Forms.GroupBox();
            this.label_SerialPortStatus = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_InternalCLIoutput = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox_SystemStatus = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox_ClentTCPStatus = new System.Windows.Forms.GroupBox();
            this.label_TCPClient = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label_ClientTCPConnected = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.checkBox_ServerPause = new System.Windows.Forms.CheckBox();
            this.checkBox_ServerRecord = new System.Windows.Forms.CheckBox();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.button86 = new System.Windows.Forms.Button();
            this.groupBox_ServerSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl_Main.SuspendLayout();
            this.tabPage_SMS.SuspendLayout();
            this.groupBox39.SuspendLayout();
            this.groupBox37.SuspendLayout();
            this.groupBox35.SuspendLayout();
            this.groupBox34.SuspendLayout();
            this.GrooupBox_Encryption.SuspendLayout();
            this.groupBox33.SuspendLayout();
            this.tabPage_Configuration.SuspendLayout();
            this.tabControl_systems.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.groupBox38.SuspendLayout();
            this.tabPage_charts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage_SerialPort.SuspendLayout();
            this.groupBox_SendSerialOrMonitorCommands.SuspendLayout();
            this.gbPortSettings.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox_Timer.SuspendLayout();
            this.groupBox_Stopwatch.SuspendLayout();
            this.tabPage_ServerTCP.SuspendLayout();
            this.groupBox_FOTA.SuspendLayout();
            this.groupBox_ConnectionTimedOut.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage_ClientTCP.SuspendLayout();
            this.tabPage_GenericFrame.SuspendLayout();
            this.groupBox31.SuspendLayout();
            this.groupBox_clientTX.SuspendLayout();
            this.tabPage_MiniAda.SuspendLayout();
            this.groupBox40.SuspendLayout();
            this.tabControl_MiniAda.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.groupBox32.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.S1_Configuration.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.groupBox28.SuspendLayout();
            this.groupBox30.SuspendLayout();
            this.groupBox29.SuspendLayout();
            this.groupBox27.SuspendLayout();
            this.groupBox26.SuspendLayout();
            this.groupBox25.SuspendLayout();
            this.groupBox24.SuspendLayout();
            this.groupBox23.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox_PhoneNumber.SuspendLayout();
            this.groupBox_SerialPort.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox_ClentTCPStatus.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_ServerSettings
            // 
            this.groupBox_ServerSettings.Controls.Add(this.textBox_ServerOpen);
            this.groupBox_ServerSettings.Controls.Add(this.textBox_ServerActive);
            this.groupBox_ServerSettings.Controls.Add(this.txtPortNo);
            this.groupBox_ServerSettings.Controls.Add(this.textBox_NumberOfOpenConnections);
            this.groupBox_ServerSettings.Controls.Add(this.ListenBox);
            this.groupBox_ServerSettings.Controls.Add(this.label1);
            this.groupBox_ServerSettings.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_ServerSettings.Location = new System.Drawing.Point(6, 3);
            this.groupBox_ServerSettings.Name = "groupBox_ServerSettings";
            this.groupBox_ServerSettings.Size = new System.Drawing.Size(414, 58);
            this.groupBox_ServerSettings.TabIndex = 0;
            this.groupBox_ServerSettings.TabStop = false;
            this.groupBox_ServerSettings.Text = "Server Settings";
            // 
            // textBox_ServerOpen
            // 
            this.textBox_ServerOpen.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ServerOpen.ForeColor = System.Drawing.Color.White;
            this.textBox_ServerOpen.Location = new System.Drawing.Point(276, 17);
            this.textBox_ServerOpen.Multiline = true;
            this.textBox_ServerOpen.Name = "textBox_ServerOpen";
            this.textBox_ServerOpen.ReadOnly = true;
            this.textBox_ServerOpen.Size = new System.Drawing.Size(89, 25);
            this.textBox_ServerOpen.TabIndex = 7;
            this.textBox_ServerOpen.Text = "Connected";
            this.toolTip1.SetToolTip(this.textBox_ServerOpen, "Number of open connections");
            // 
            // textBox_ServerActive
            // 
            this.textBox_ServerActive.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ServerActive.ForeColor = System.Drawing.Color.White;
            this.textBox_ServerActive.Location = new System.Drawing.Point(210, 17);
            this.textBox_ServerActive.Multiline = true;
            this.textBox_ServerActive.Name = "textBox_ServerActive";
            this.textBox_ServerActive.ReadOnly = true;
            this.textBox_ServerActive.Size = new System.Drawing.Size(60, 25);
            this.textBox_ServerActive.TabIndex = 6;
            this.textBox_ServerActive.Text = "Active";
            this.toolTip1.SetToolTip(this.textBox_ServerActive, "Number of open connections");
            // 
            // txtPortNo
            // 
            this.txtPortNo.Location = new System.Drawing.Point(86, 16);
            this.txtPortNo.Name = "txtPortNo";
            this.txtPortNo.Size = new System.Drawing.Size(40, 23);
            this.txtPortNo.TabIndex = 1;
            this.txtPortNo.Text = "7000";
            this.txtPortNo.TextChanged += new System.EventHandler(this.TxtPortNo_TextChanged);
            // 
            // textBox_NumberOfOpenConnections
            // 
            this.textBox_NumberOfOpenConnections.ForeColor = System.Drawing.Color.White;
            this.textBox_NumberOfOpenConnections.Location = new System.Drawing.Point(371, 17);
            this.textBox_NumberOfOpenConnections.Name = "textBox_NumberOfOpenConnections";
            this.textBox_NumberOfOpenConnections.ReadOnly = true;
            this.textBox_NumberOfOpenConnections.Size = new System.Drawing.Size(25, 23);
            this.textBox_NumberOfOpenConnections.TabIndex = 5;
            this.toolTip1.SetToolTip(this.textBox_NumberOfOpenConnections, "Number of open connections");
            this.textBox_NumberOfOpenConnections.TextChanged += new System.EventHandler(this.TextBox_NumberOfOpenConnections_TextChanged);
            // 
            // ListenBox
            // 
            this.ListenBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.ListenBox.AutoSize = true;
            this.ListenBox.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListenBox.Location = new System.Drawing.Point(132, 15);
            this.ListenBox.Name = "ListenBox";
            this.ListenBox.Size = new System.Drawing.Size(74, 28);
            this.ListenBox.TabIndex = 4;
            this.ListenBox.Text = "Listening";
            this.ListenBox.UseVisualStyleBackColor = true;
            this.ListenBox.CheckedChanged += new System.EventHandler(this.ListenBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port Number:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_ConnectionNumber);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.txtDataTx);
            this.groupBox2.Location = new System.Drawing.Point(3, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(273, 217);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Send Data";
            // 
            // comboBox_ConnectionNumber
            // 
            this.comboBox_ConnectionNumber.FormattingEnabled = true;
            this.comboBox_ConnectionNumber.Location = new System.Drawing.Point(84, 188);
            this.comboBox_ConnectionNumber.Name = "comboBox_ConnectionNumber";
            this.comboBox_ConnectionNumber.Size = new System.Drawing.Size(170, 26);
            this.comboBox_ConnectionNumber.TabIndex = 2;
            this.comboBox_ConnectionNumber.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(14, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 24);
            this.button1.TabIndex = 1;
            this.button1.Text = "Send";
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txtDataTx
            // 
            this.txtDataTx.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDataTx.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataTx.Location = new System.Drawing.Point(14, 19);
            this.txtDataTx.Multiline = true;
            this.txtDataTx.Name = "txtDataTx";
            this.txtDataTx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDataTx.Size = new System.Drawing.Size(257, 162);
            this.txtDataTx.TabIndex = 0;
            this.txtDataTx.TextChanged += new System.EventHandler(this.TxtDataTx_TextChanged);
            // 
            // tabControl_Main
            // 
            this.tabControl_Main.Controls.Add(this.tabPage_SMS);
            this.tabControl_Main.Controls.Add(this.tabPage_Configuration);
            this.tabControl_Main.Controls.Add(this.tabPage_charts);
            this.tabControl_Main.Controls.Add(this.tabPage_SerialPort);
            this.tabControl_Main.Controls.Add(this.tabPage_ServerTCP);
            this.tabControl_Main.Controls.Add(this.tabPage_ClientTCP);
            this.tabControl_Main.Controls.Add(this.tabPage_GenericFrame);
            this.tabControl_Main.Controls.Add(this.tabPage_MiniAda);
            this.tabControl_Main.Location = new System.Drawing.Point(4, 5);
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.SelectedIndex = 0;
            this.tabControl_Main.Size = new System.Drawing.Size(1555, 713);
            this.tabControl_Main.TabIndex = 8;
            this.tabControl_Main.TabStop = false;
            this.tabControl_Main.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabControl1_KeyDown);
            // 
            // tabPage_SMS
            // 
            this.tabPage_SMS.Controls.Add(this.groupBox39);
            this.tabPage_SMS.Controls.Add(this.groupBox37);
            this.tabPage_SMS.Controls.Add(this.groupBox35);
            this.tabPage_SMS.Controls.Add(this.groupBox34);
            this.tabPage_SMS.Controls.Add(this.groupBox33);
            this.tabPage_SMS.Location = new System.Drawing.Point(4, 27);
            this.tabPage_SMS.Name = "tabPage_SMS";
            this.tabPage_SMS.Size = new System.Drawing.Size(1547, 682);
            this.tabPage_SMS.TabIndex = 6;
            this.tabPage_SMS.Text = "SMS";
            this.tabPage_SMS.UseVisualStyleBackColor = true;
            // 
            // groupBox39
            // 
            this.groupBox39.Controls.Add(this.listBox_SMSCommands);
            this.groupBox39.Controls.Add(this.button37);
            this.groupBox39.Controls.Add(this.button38);
            this.groupBox39.Controls.Add(this.button39);
            this.groupBox39.Controls.Add(this.button40);
            this.groupBox39.Controls.Add(this.button41);
            this.groupBox39.Location = new System.Drawing.Point(476, 7);
            this.groupBox39.Name = "groupBox39";
            this.groupBox39.Size = new System.Drawing.Size(315, 429);
            this.groupBox39.TabIndex = 6;
            this.groupBox39.TabStop = false;
            this.groupBox39.Text = "SMS commands";
            this.groupBox39.Enter += new System.EventHandler(this.GroupBox39_Enter);
            // 
            // listBox_SMSCommands
            // 
            this.listBox_SMSCommands.FormattingEnabled = true;
            this.listBox_SMSCommands.ItemHeight = 18;
            this.listBox_SMSCommands.Location = new System.Drawing.Point(6, 17);
            this.listBox_SMSCommands.Name = "listBox_SMSCommands";
            this.listBox_SMSCommands.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_SMSCommands.Size = new System.Drawing.Size(303, 292);
            this.listBox_SMSCommands.TabIndex = 6;
            this.listBox_SMSCommands.SelectedIndexChanged += new System.EventHandler(this.ListBox_SMSCommands_SelectedIndexChanged_1);
            // 
            // button37
            // 
            this.button37.Location = new System.Drawing.Point(169, 359);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(75, 23);
            this.button37.TabIndex = 5;
            this.button37.Text = "Edit";
            this.button37.UseVisualStyleBackColor = true;
            this.button37.Click += new System.EventHandler(this.Button37_Click);
            // 
            // button38
            // 
            this.button38.Location = new System.Drawing.Point(88, 395);
            this.button38.Name = "button38";
            this.button38.Size = new System.Drawing.Size(75, 23);
            this.button38.TabIndex = 4;
            this.button38.Text = "Import";
            this.button38.UseVisualStyleBackColor = true;
            this.button38.Click += new System.EventHandler(this.Button38_Click);
            // 
            // button39
            // 
            this.button39.Location = new System.Drawing.Point(7, 395);
            this.button39.Name = "button39";
            this.button39.Size = new System.Drawing.Size(75, 23);
            this.button39.TabIndex = 3;
            this.button39.Text = "Export";
            this.button39.UseVisualStyleBackColor = true;
            this.button39.Click += new System.EventHandler(this.Button39_Click_1);
            // 
            // button40
            // 
            this.button40.Location = new System.Drawing.Point(88, 359);
            this.button40.Name = "button40";
            this.button40.Size = new System.Drawing.Size(75, 23);
            this.button40.TabIndex = 2;
            this.button40.Text = "Remove";
            this.button40.UseVisualStyleBackColor = true;
            this.button40.Click += new System.EventHandler(this.Button40_Click);
            // 
            // button41
            // 
            this.button41.Location = new System.Drawing.Point(7, 359);
            this.button41.Name = "button41";
            this.button41.Size = new System.Drawing.Size(75, 23);
            this.button41.TabIndex = 1;
            this.button41.Text = "Add";
            this.button41.UseVisualStyleBackColor = true;
            this.button41.Click += new System.EventHandler(this.Button41_Click);
            // 
            // groupBox37
            // 
            this.groupBox37.Controls.Add(this.richTextBox_SMSConsole);
            this.groupBox37.Controls.Add(this.checkBox_RecordSMSConsole);
            this.groupBox37.Controls.Add(this.checkBox_PauseSMSConsole);
            this.groupBox37.Controls.Add(this.button_ClearSMSConsole);
            this.groupBox37.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox37.Location = new System.Drawing.Point(797, 7);
            this.groupBox37.Name = "groupBox37";
            this.groupBox37.Size = new System.Drawing.Size(463, 656);
            this.groupBox37.TabIndex = 8;
            this.groupBox37.TabStop = false;
            this.groupBox37.Text = "SMS Console";
            // 
            // richTextBox_SMSConsole
            // 
            this.richTextBox_SMSConsole.EnableAutoDragDrop = true;
            this.richTextBox_SMSConsole.Location = new System.Drawing.Point(6, 17);
            this.richTextBox_SMSConsole.Name = "richTextBox_SMSConsole";
            this.richTextBox_SMSConsole.Size = new System.Drawing.Size(451, 607);
            this.richTextBox_SMSConsole.TabIndex = 0;
            this.richTextBox_SMSConsole.Text = "";
            // 
            // checkBox_RecordSMSConsole
            // 
            this.checkBox_RecordSMSConsole.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_RecordSMSConsole.AutoSize = true;
            this.checkBox_RecordSMSConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_RecordSMSConsole.Location = new System.Drawing.Point(222, 630);
            this.checkBox_RecordSMSConsole.Name = "checkBox_RecordSMSConsole";
            this.checkBox_RecordSMSConsole.Size = new System.Drawing.Size(99, 26);
            this.checkBox_RecordSMSConsole.TabIndex = 7;
            this.checkBox_RecordSMSConsole.Text = "Record Log";
            this.checkBox_RecordSMSConsole.UseVisualStyleBackColor = true;
            // 
            // checkBox_PauseSMSConsole
            // 
            this.checkBox_PauseSMSConsole.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_PauseSMSConsole.AutoSize = true;
            this.checkBox_PauseSMSConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_PauseSMSConsole.Location = new System.Drawing.Point(327, 630);
            this.checkBox_PauseSMSConsole.Name = "checkBox_PauseSMSConsole";
            this.checkBox_PauseSMSConsole.Size = new System.Drawing.Size(62, 26);
            this.checkBox_PauseSMSConsole.TabIndex = 5;
            this.checkBox_PauseSMSConsole.Text = "Pause";
            this.checkBox_PauseSMSConsole.UseVisualStyleBackColor = true;
            // 
            // button_ClearSMSConsole
            // 
            this.button_ClearSMSConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ClearSMSConsole.Location = new System.Drawing.Point(395, 630);
            this.button_ClearSMSConsole.Name = "button_ClearSMSConsole";
            this.button_ClearSMSConsole.Size = new System.Drawing.Size(62, 26);
            this.button_ClearSMSConsole.TabIndex = 6;
            this.button_ClearSMSConsole.Text = "Clear";
            this.button_ClearSMSConsole.UseVisualStyleBackColor = true;
            // 
            // groupBox35
            // 
            this.groupBox35.Controls.Add(this.checkBox_DebugSMS);
            this.groupBox35.Controls.Add(this.checkBox_OpenPortSMS);
            this.groupBox35.Controls.Add(this.button36);
            this.groupBox35.Controls.Add(this.comboBox_ComportSMS);
            this.groupBox35.Controls.Add(this.richTextBox_ModemStatus);
            this.groupBox35.Location = new System.Drawing.Point(8, 587);
            this.groupBox35.Name = "groupBox35";
            this.groupBox35.Size = new System.Drawing.Size(456, 147);
            this.groupBox35.TabIndex = 7;
            this.groupBox35.TabStop = false;
            this.groupBox35.Text = "Modem Status";
            // 
            // checkBox_DebugSMS
            // 
            this.checkBox_DebugSMS.AutoSize = true;
            this.checkBox_DebugSMS.Location = new System.Drawing.Point(390, 54);
            this.checkBox_DebugSMS.Name = "checkBox_DebugSMS";
            this.checkBox_DebugSMS.Size = new System.Drawing.Size(67, 22);
            this.checkBox_DebugSMS.TabIndex = 11;
            this.checkBox_DebugSMS.Text = "Debug";
            this.checkBox_DebugSMS.UseVisualStyleBackColor = true;
            // 
            // checkBox_OpenPortSMS
            // 
            this.checkBox_OpenPortSMS.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_OpenPortSMS.AutoSize = true;
            this.checkBox_OpenPortSMS.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_OpenPortSMS.Location = new System.Drawing.Point(363, 20);
            this.checkBox_OpenPortSMS.Name = "checkBox_OpenPortSMS";
            this.checkBox_OpenPortSMS.Size = new System.Drawing.Size(84, 29);
            this.checkBox_OpenPortSMS.TabIndex = 10;
            this.checkBox_OpenPortSMS.Text = "Open Port";
            this.checkBox_OpenPortSMS.UseVisualStyleBackColor = true;
            this.checkBox_OpenPortSMS.CheckedChanged += new System.EventHandler(this.CheckBox_OpenPortSMS_CheckedChanged);
            // 
            // button36
            // 
            this.button36.Location = new System.Drawing.Point(269, 109);
            this.button36.Name = "button36";
            this.button36.Size = new System.Drawing.Size(75, 23);
            this.button36.TabIndex = 6;
            this.button36.Text = "Clear";
            this.button36.UseVisualStyleBackColor = true;
            this.button36.Click += new System.EventHandler(this.Button36_Click);
            // 
            // comboBox_ComportSMS
            // 
            this.comboBox_ComportSMS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ComportSMS.FormattingEnabled = true;
            this.comboBox_ComportSMS.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6"});
            this.comboBox_ComportSMS.Location = new System.Drawing.Point(290, 22);
            this.comboBox_ComportSMS.Name = "comboBox_ComportSMS";
            this.comboBox_ComportSMS.Size = new System.Drawing.Size(67, 26);
            this.comboBox_ComportSMS.TabIndex = 9;
            this.comboBox_ComportSMS.Tag = "1";
            this.comboBox_ComportSMS.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged_2);
            // 
            // richTextBox_ModemStatus
            // 
            this.richTextBox_ModemStatus.Location = new System.Drawing.Point(7, 19);
            this.richTextBox_ModemStatus.Name = "richTextBox_ModemStatus";
            this.richTextBox_ModemStatus.Size = new System.Drawing.Size(256, 115);
            this.richTextBox_ModemStatus.TabIndex = 0;
            this.richTextBox_ModemStatus.Text = "";
            // 
            // groupBox34
            // 
            this.groupBox34.Controls.Add(this.button_Ring);
            this.groupBox34.Controls.Add(this.GrooupBox_Encryption);
            this.groupBox34.Controls.Add(this.checkBox_SMSencrypted);
            this.groupBox34.Controls.Add(this.checkBox_SendSMSAsIs);
            this.groupBox34.Controls.Add(this.checkBox1);
            this.groupBox34.Controls.Add(this.label_SMSSendCharacters);
            this.groupBox34.Controls.Add(this.button_SendSelectedSMS);
            this.groupBox34.Controls.Add(this.button_SendAllCheckedSMS);
            this.groupBox34.Controls.Add(this.richTextBox_TextSendSMS);
            this.groupBox34.Location = new System.Drawing.Point(8, 436);
            this.groupBox34.Name = "groupBox34";
            this.groupBox34.Size = new System.Drawing.Size(783, 147);
            this.groupBox34.TabIndex = 6;
            this.groupBox34.TabStop = false;
            this.groupBox34.Text = "SMS text";
            // 
            // button_Ring
            // 
            this.button_Ring.Location = new System.Drawing.Point(88, 112);
            this.button_Ring.Name = "button_Ring";
            this.button_Ring.Size = new System.Drawing.Size(141, 23);
            this.button_Ring.TabIndex = 14;
            this.button_Ring.Text = "Ring";
            this.toolTip1.SetToolTip(this.button_Ring, "Ring to contact");
            this.toolTip2.SetToolTip(this.button_Ring, "Ring to contact");
            this.button_Ring.UseVisualStyleBackColor = true;
            this.button_Ring.Click += new System.EventHandler(this.Button_Ring_Click);
            // 
            // GrooupBox_Encryption
            // 
            this.GrooupBox_Encryption.Controls.Add(this.label5);
            this.GrooupBox_Encryption.Controls.Add(this.textBox_CodeArrayForSMS);
            this.GrooupBox_Encryption.Controls.Add(this.label2);
            this.GrooupBox_Encryption.Controls.Add(this.textBox_UnitIDForSMS);
            this.GrooupBox_Encryption.Enabled = false;
            this.GrooupBox_Encryption.Location = new System.Drawing.Point(595, 38);
            this.GrooupBox_Encryption.Name = "GrooupBox_Encryption";
            this.GrooupBox_Encryption.Size = new System.Drawing.Size(184, 103);
            this.GrooupBox_Encryption.TabIndex = 13;
            this.GrooupBox_Encryption.TabStop = false;
            this.GrooupBox_Encryption.Text = "Encryption";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "Code";
            // 
            // textBox_CodeArrayForSMS
            // 
            this.textBox_CodeArrayForSMS.Location = new System.Drawing.Point(54, 46);
            this.textBox_CodeArrayForSMS.MaxLength = 4;
            this.textBox_CodeArrayForSMS.Name = "textBox_CodeArrayForSMS";
            this.textBox_CodeArrayForSMS.Size = new System.Drawing.Size(124, 26);
            this.textBox_CodeArrayForSMS.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "UnitID";
            // 
            // textBox_UnitIDForSMS
            // 
            this.textBox_UnitIDForSMS.Location = new System.Drawing.Point(54, 17);
            this.textBox_UnitIDForSMS.MaxLength = 16;
            this.textBox_UnitIDForSMS.Name = "textBox_UnitIDForSMS";
            this.textBox_UnitIDForSMS.Size = new System.Drawing.Size(124, 26);
            this.textBox_UnitIDForSMS.TabIndex = 0;
            // 
            // checkBox_SMSencrypted
            // 
            this.checkBox_SMSencrypted.AutoSize = true;
            this.checkBox_SMSencrypted.Location = new System.Drawing.Point(595, 20);
            this.checkBox_SMSencrypted.Name = "checkBox_SMSencrypted";
            this.checkBox_SMSencrypted.Size = new System.Drawing.Size(89, 22);
            this.checkBox_SMSencrypted.TabIndex = 12;
            this.checkBox_SMSencrypted.Text = "Encrypted";
            this.checkBox_SMSencrypted.UseVisualStyleBackColor = true;
            this.checkBox_SMSencrypted.CheckedChanged += new System.EventHandler(this.CheckBox_SMSencrypted_CheckedChanged);
            // 
            // checkBox_SendSMSAsIs
            // 
            this.checkBox_SendSMSAsIs.AutoSize = true;
            this.checkBox_SendSMSAsIs.Location = new System.Drawing.Point(240, 115);
            this.checkBox_SendSMSAsIs.Name = "checkBox_SendSMSAsIs";
            this.checkBox_SendSMSAsIs.Size = new System.Drawing.Size(116, 22);
            this.checkBox_SendSMSAsIs.TabIndex = 11;
            this.checkBox_SendSMSAsIs.Text = "Send SMS as is";
            this.checkBox_SendSMSAsIs.UseVisualStyleBackColor = true;
            this.checkBox_SendSMSAsIs.CheckedChanged += new System.EventHandler(this.CheckBox_SendSMSAsIs_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(145, 145);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(92, 22);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label_SMSSendCharacters
            // 
            this.label_SMSSendCharacters.AutoSize = true;
            this.label_SMSSendCharacters.Location = new System.Drawing.Point(12, 119);
            this.label_SMSSendCharacters.Name = "label_SMSSendCharacters";
            this.label_SMSSendCharacters.Size = new System.Drawing.Size(42, 18);
            this.label_SMSSendCharacters.TabIndex = 9;
            this.label_SMSSendCharacters.Text = "0/160";
            // 
            // button_SendSelectedSMS
            // 
            this.button_SendSelectedSMS.Location = new System.Drawing.Point(482, 115);
            this.button_SendSelectedSMS.Name = "button_SendSelectedSMS";
            this.button_SendSelectedSMS.Size = new System.Drawing.Size(107, 23);
            this.button_SendSelectedSMS.TabIndex = 8;
            this.button_SendSelectedSMS.Text = "Send SMS One";
            this.toolTip1.SetToolTip(this.button_SendSelectedSMS, "Send SMS to the selected contact");
            this.toolTip2.SetToolTip(this.button_SendSelectedSMS, "Send SMS to the selected contact");
            this.button_SendSelectedSMS.UseVisualStyleBackColor = true;
            this.button_SendSelectedSMS.Click += new System.EventHandler(this.Button_SendSelectedSMS_Click);
            // 
            // button_SendAllCheckedSMS
            // 
            this.button_SendAllCheckedSMS.Location = new System.Drawing.Point(353, 115);
            this.button_SendAllCheckedSMS.Name = "button_SendAllCheckedSMS";
            this.button_SendAllCheckedSMS.Size = new System.Drawing.Size(123, 23);
            this.button_SendAllCheckedSMS.TabIndex = 7;
            this.button_SendAllCheckedSMS.Text = "Send SMS Multi";
            this.toolTip1.SetToolTip(this.button_SendAllCheckedSMS, "Send SMS to all the checked contacts");
            this.toolTip2.SetToolTip(this.button_SendAllCheckedSMS, "Send SMS to all the checked contacts");
            this.button_SendAllCheckedSMS.UseVisualStyleBackColor = true;
            this.button_SendAllCheckedSMS.Click += new System.EventHandler(this.Button39_Click);
            // 
            // richTextBox_TextSendSMS
            // 
            this.richTextBox_TextSendSMS.AutoWordSelection = true;
            this.richTextBox_TextSendSMS.EnableAutoDragDrop = true;
            this.richTextBox_TextSendSMS.Location = new System.Drawing.Point(10, 18);
            this.richTextBox_TextSendSMS.Name = "richTextBox_TextSendSMS";
            this.richTextBox_TextSendSMS.Size = new System.Drawing.Size(579, 91);
            this.richTextBox_TextSendSMS.TabIndex = 2;
            this.richTextBox_TextSendSMS.Text = "";
            this.richTextBox_TextSendSMS.TextChanged += new System.EventHandler(this.RichTextBox_TextSendSMS_TextChanged);
            // 
            // groupBox33
            // 
            this.groupBox33.Controls.Add(this.button34);
            this.groupBox33.Controls.Add(this.richTextBox_ContactDetails);
            this.groupBox33.Controls.Add(this.button33);
            this.groupBox33.Controls.Add(this.button_ImportToXML);
            this.groupBox33.Controls.Add(this.button_ExportToXML);
            this.groupBox33.Controls.Add(this.button_RemoveContact);
            this.groupBox33.Controls.Add(this.button_AddContact);
            this.groupBox33.Controls.Add(this.checkedListBox_PhoneBook);
            this.groupBox33.Location = new System.Drawing.Point(8, 7);
            this.groupBox33.Name = "groupBox33";
            this.groupBox33.Size = new System.Drawing.Size(462, 429);
            this.groupBox33.TabIndex = 1;
            this.groupBox33.TabStop = false;
            this.groupBox33.Text = "Phone Book";
            this.groupBox33.Enter += new System.EventHandler(this.GroupBox33_Enter);
            // 
            // button34
            // 
            this.button34.Location = new System.Drawing.Point(169, 400);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(75, 23);
            this.button34.TabIndex = 7;
            this.button34.Text = "Backup";
            this.button34.UseVisualStyleBackColor = true;
            this.button34.Click += new System.EventHandler(this.Button34_Click_2);
            // 
            // richTextBox_ContactDetails
            // 
            this.richTextBox_ContactDetails.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox_ContactDetails.Location = new System.Drawing.Point(290, 19);
            this.richTextBox_ContactDetails.Name = "richTextBox_ContactDetails";
            this.richTextBox_ContactDetails.Size = new System.Drawing.Size(166, 328);
            this.richTextBox_ContactDetails.TabIndex = 6;
            this.richTextBox_ContactDetails.Text = "";
            this.richTextBox_ContactDetails.TextChanged += new System.EventHandler(this.RichTextBox_ContactDetails_TextChanged);
            // 
            // button33
            // 
            this.button33.Location = new System.Drawing.Point(169, 371);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(75, 23);
            this.button33.TabIndex = 5;
            this.button33.Text = "Edit";
            this.button33.UseVisualStyleBackColor = true;
            this.button33.Click += new System.EventHandler(this.Button33_Click_2);
            // 
            // button_ImportToXML
            // 
            this.button_ImportToXML.Location = new System.Drawing.Point(88, 400);
            this.button_ImportToXML.Name = "button_ImportToXML";
            this.button_ImportToXML.Size = new System.Drawing.Size(75, 23);
            this.button_ImportToXML.TabIndex = 4;
            this.button_ImportToXML.Text = "Import";
            this.button_ImportToXML.UseVisualStyleBackColor = true;
            this.button_ImportToXML.Click += new System.EventHandler(this.Button_ImportToXML_Click);
            // 
            // button_ExportToXML
            // 
            this.button_ExportToXML.Location = new System.Drawing.Point(7, 400);
            this.button_ExportToXML.Name = "button_ExportToXML";
            this.button_ExportToXML.Size = new System.Drawing.Size(75, 23);
            this.button_ExportToXML.TabIndex = 3;
            this.button_ExportToXML.Text = "Export";
            this.button_ExportToXML.UseVisualStyleBackColor = true;
            this.button_ExportToXML.Click += new System.EventHandler(this.Button_ExportToXML_Click);
            // 
            // button_RemoveContact
            // 
            this.button_RemoveContact.Location = new System.Drawing.Point(88, 371);
            this.button_RemoveContact.Name = "button_RemoveContact";
            this.button_RemoveContact.Size = new System.Drawing.Size(75, 23);
            this.button_RemoveContact.TabIndex = 2;
            this.button_RemoveContact.Text = "Remove";
            this.button_RemoveContact.UseVisualStyleBackColor = true;
            this.button_RemoveContact.Click += new System.EventHandler(this.Button_RemoveContact_Click);
            // 
            // button_AddContact
            // 
            this.button_AddContact.Location = new System.Drawing.Point(7, 371);
            this.button_AddContact.Name = "button_AddContact";
            this.button_AddContact.Size = new System.Drawing.Size(75, 23);
            this.button_AddContact.TabIndex = 1;
            this.button_AddContact.Text = "Add";
            this.button_AddContact.UseVisualStyleBackColor = true;
            this.button_AddContact.Click += new System.EventHandler(this.Button33_Click_1);
            // 
            // checkedListBox_PhoneBook
            // 
            this.checkedListBox_PhoneBook.FormattingEnabled = true;
            this.checkedListBox_PhoneBook.Location = new System.Drawing.Point(5, 19);
            this.checkedListBox_PhoneBook.Name = "checkedListBox_PhoneBook";
            this.checkedListBox_PhoneBook.Size = new System.Drawing.Size(279, 298);
            this.checkedListBox_PhoneBook.TabIndex = 0;
            this.checkedListBox_PhoneBook.SelectedIndexChanged += new System.EventHandler(this.CheckedListBox_PhoneBook_SelectedIndexChanged);
            this.checkedListBox_PhoneBook.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CheckedListBox_PhoneBook_KeyDown);
            this.checkedListBox_PhoneBook.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CheckedListBox_PhoneBook_MouseDown);
            // 
            // tabPage_Configuration
            // 
            this.tabPage_Configuration.Controls.Add(this.tabControl_systems);
            this.tabPage_Configuration.Controls.Add(this.button32);
            this.tabPage_Configuration.Controls.Add(this.groupBox38);
            this.tabPage_Configuration.Controls.Add(this.button30);
            this.tabPage_Configuration.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage_Configuration.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Configuration.Name = "tabPage_Configuration";
            this.tabPage_Configuration.Size = new System.Drawing.Size(1547, 687);
            this.tabPage_Configuration.TabIndex = 5;
            this.tabPage_Configuration.Text = "Configuration";
            this.tabPage_Configuration.UseVisualStyleBackColor = true;
            this.tabPage_Configuration.Click += new System.EventHandler(this.TabPage6_Click);
            // 
            // tabControl_systems
            // 
            this.tabControl_systems.Controls.Add(this.tabPage10);
            this.tabControl_systems.Controls.Add(this.tabPage11);
            this.tabControl_systems.Controls.Add(this.tabPage12);
            this.tabControl_systems.Location = new System.Drawing.Point(5, 183);
            this.tabControl_systems.Name = "tabControl_systems";
            this.tabControl_systems.SelectedIndex = 0;
            this.tabControl_systems.Size = new System.Drawing.Size(1539, 545);
            this.tabControl_systems.TabIndex = 125;
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.textBox_Config4);
            this.tabPage10.Controls.Add(this.textBox_Config6);
            this.tabPage10.Controls.Add(this.textBox_Config8);
            this.tabPage10.Controls.Add(this.textBox_Config9);
            this.tabPage10.Controls.Add(this.textBox_Config10);
            this.tabPage10.Controls.Add(this.textBox_Config11);
            this.tabPage10.Controls.Add(this.textBox_Config12);
            this.tabPage10.Controls.Add(this.textBox_Config20);
            this.tabPage10.Controls.Add(this.textBox_Config21);
            this.tabPage10.Controls.Add(this.textBox_Config22);
            this.tabPage10.Controls.Add(this.textBox_Config36);
            this.tabPage10.Controls.Add(this.textBox_Config35);
            this.tabPage10.Location = new System.Drawing.Point(4, 28);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(1531, 513);
            this.tabPage10.TabIndex = 0;
            this.tabPage10.Text = "System 1";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // textBox_Config4
            // 
            this.textBox_Config4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config4.Location = new System.Drawing.Point(131, 11);
            this.textBox_Config4.Name = "textBox_Config4";
            this.textBox_Config4.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config4.TabIndex = 0;
            this.toolTip2.SetToolTip(this.textBox_Config4, "Description:\r\nchange the password for the unit.\r\nValid Data:\r\nstring  Max 15");
            this.toolTip1.SetToolTip(this.textBox_Config4, "Description:\r\nchange the password for the unit.\r\n\r\nValid Input Data:\r\nstring  Max" +
        " 15\r\n\r\n\r\n");
            this.textBox_Config4.TextChanged += new System.EventHandler(this.TextBox_Config4_TextChanged);
            // 
            // textBox_Config6
            // 
            this.textBox_Config6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config6.Location = new System.Drawing.Point(131, 244);
            this.textBox_Config6.Name = "textBox_Config6";
            this.textBox_Config6.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config6.TabIndex = 5;
            this.toolTip2.SetToolTip(this.textBox_Config6, "Description:\r\nModem Port for IP2 For communicate with the Server\r\nValid data:\r\nVa" +
        "lid Port 0-99999");
            this.toolTip1.SetToolTip(this.textBox_Config6, "Description:\r\nModem Port for IP2 For communicate with the Server\r\nValid data:\r\nVa" +
        "lid Port 0-99999\r\n\r\n");
            this.textBox_Config6.TextChanged += new System.EventHandler(this.TextBox_Config6_TextChanged);
            // 
            // textBox_Config8
            // 
            this.textBox_Config8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config8.Location = new System.Drawing.Point(131, 378);
            this.textBox_Config8.Name = "textBox_Config8";
            this.textBox_Config8.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config8.TabIndex = 9;
            this.toolTip2.SetToolTip(this.textBox_Config8, "Description:\r\nan option to set time interval of status message which will be sent" +
        " to remote server. \r\nValid data:\r\nnumber\r\n");
            this.toolTip1.SetToolTip(this.textBox_Config8, "Description:\r\nan option to set time interval of status message which will be sent" +
        " to remote server. \r\nValid data:\r\nnumber\r\n");
            this.textBox_Config8.TextChanged += new System.EventHandler(this.TextBox_Config8_TextChanged);
            // 
            // textBox_Config9
            // 
            this.textBox_Config9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config9.Location = new System.Drawing.Point(131, 44);
            this.textBox_Config9.Name = "textBox_Config9";
            this.textBox_Config9.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config9.TabIndex = 1;
            this.toolTip2.SetToolTip(this.textBox_Config9, "Description:\r\nan option to set SIM card details according to cellular provider op" +
        "erator. \r\nValid Data:\r\nstring");
            this.toolTip1.SetToolTip(this.textBox_Config9, "Description:\r\nan option to set SIM card details according to cellular provider op" +
        "erator. \r\nValid Data:\r\nstring");
            this.textBox_Config9.TextChanged += new System.EventHandler(this.TextBox_Config9_TextChanged);
            // 
            // textBox_Config10
            // 
            this.textBox_Config10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config10.Location = new System.Drawing.Point(131, 141);
            this.textBox_Config10.Name = "textBox_Config10";
            this.textBox_Config10.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config10.TabIndex = 2;
            this.toolTip2.SetToolTip(this.textBox_Config10, "Description:\r\nModem IP1 For communicate with the Server\r\nValid data:\r\nValid TCP/I" +
        "P address\r\n\r\n\r\n");
            this.toolTip1.SetToolTip(this.textBox_Config10, "Description:\r\nModem IP1 For communicate with the Server\r\nValid data:\r\nValid TCP/I" +
        "P address\r\n\r\n");
            this.textBox_Config10.TextChanged += new System.EventHandler(this.TextBox_Config10_TextChanged);
            // 
            // textBox_Config11
            // 
            this.textBox_Config11.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config11.Location = new System.Drawing.Point(131, 208);
            this.textBox_Config11.Name = "textBox_Config11";
            this.textBox_Config11.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config11.TabIndex = 4;
            this.toolTip2.SetToolTip(this.textBox_Config11, "Description:\r\nModem IP2 For communicate with the Server\r\nValid data:\r\nValid TCP/I" +
        "P address");
            this.toolTip1.SetToolTip(this.textBox_Config11, "Description:\r\nModem IP2 For communicate with the Server\r\nValid data:\r\nValid TCP/I" +
        "P address\r\n");
            this.textBox_Config11.TextChanged += new System.EventHandler(this.TextBox_Config11_TextChanged);
            // 
            // textBox_Config12
            // 
            this.textBox_Config12.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config12.Location = new System.Drawing.Point(131, 174);
            this.textBox_Config12.Name = "textBox_Config12";
            this.textBox_Config12.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config12.TabIndex = 3;
            this.toolTip2.SetToolTip(this.textBox_Config12, "Description:\r\nModem Port for IP1 For communicate with the Server\r\nValid data:\r\nVa" +
        "lid Port 0-99999\r\n\r\n\r\n");
            this.toolTip1.SetToolTip(this.textBox_Config12, "Description:\r\nModem Port for IP1 For communicate with the Server\r\nValid data:\r\nVa" +
        "lid Port 0-99999\r\n\r\n");
            this.textBox_Config12.TextChanged += new System.EventHandler(this.TextBox_Config12_TextChanged);
            // 
            // textBox_Config20
            // 
            this.textBox_Config20.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config20.Location = new System.Drawing.Point(131, 344);
            this.textBox_Config20.Name = "textBox_Config20";
            this.textBox_Config20.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config20.TabIndex = 8;
            this.toolTip2.SetToolTip(this.textBox_Config20, "Description:\r\nIn case of deviation from traffic lane to preconfigured degrees, un" +
        "it will send position message. \r\nValid data:\r\n0-360\r\n");
            this.toolTip1.SetToolTip(this.textBox_Config20, "Description:\r\nIn case of deviation from traffic lane to preconfigured degrees, un" +
        "it will send position message. \r\nValid data:\r\n0-360");
            this.textBox_Config20.TextChanged += new System.EventHandler(this.TextBox_Config20_TextChanged);
            // 
            // textBox_Config21
            // 
            this.textBox_Config21.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config21.Location = new System.Drawing.Point(131, 312);
            this.textBox_Config21.Name = "textBox_Config21";
            this.textBox_Config21.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config21.TabIndex = 7;
            this.toolTip2.SetToolTip(this.textBox_Config21, "Description:\r\nan option to send POS message every predefined distance value. \r\nVa" +
        "lid data:\r\nnumber");
            this.toolTip1.SetToolTip(this.textBox_Config21, "Description:\r\nan option to send POS message every predefined distance value. \r\nVa" +
        "lid data:\r\nnumber");
            this.textBox_Config21.TextChanged += new System.EventHandler(this.TextBox_Config21_TextChanged);
            // 
            // textBox_Config22
            // 
            this.textBox_Config22.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config22.Location = new System.Drawing.Point(132, 279);
            this.textBox_Config22.Name = "textBox_Config22";
            this.textBox_Config22.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config22.TabIndex = 6;
            this.toolTip2.SetToolTip(this.textBox_Config22, "Description:\r\nan option to set time interval of position message which will be se" +
        "nt to remote server. \r\nValid data:\r\nnumber");
            this.toolTip1.SetToolTip(this.textBox_Config22, "Description:\r\nan option to set time interval of position message which will be se" +
        "nt to remote server. \r\nValid data:\r\nnumber\r\n");
            this.textBox_Config22.TextChanged += new System.EventHandler(this.TextBox_Config22_TextChanged);
            // 
            // textBox_Config36
            // 
            this.textBox_Config36.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config36.Location = new System.Drawing.Point(131, 108);
            this.textBox_Config36.Name = "textBox_Config36";
            this.textBox_Config36.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config36.TabIndex = 105;
            this.toolTip2.SetToolTip(this.textBox_Config36, "Description:\r\nAPN password.\r\nan option to set SIM card details according to cellu" +
        "lar provider operator. \r\nValid Data:\r\nstring");
            this.toolTip1.SetToolTip(this.textBox_Config36, "Description:\r\nAPN password.\r\nan option to set SIM card details according to cellu" +
        "lar provider operator. \r\nValid Data:\r\nstring");
            this.textBox_Config36.TextChanged += new System.EventHandler(this.TextBox_Config36_TextChanged);
            // 
            // textBox_Config35
            // 
            this.textBox_Config35.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config35.Location = new System.Drawing.Point(131, 75);
            this.textBox_Config35.Name = "textBox_Config35";
            this.textBox_Config35.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config35.TabIndex = 104;
            this.toolTip2.SetToolTip(this.textBox_Config35, "Description:\r\nAPN username.\r\nan option to set SIM card details according to cellu" +
        "lar provider operator. \r\nValid Data:\r\nstring");
            this.toolTip1.SetToolTip(this.textBox_Config35, "Description:\r\nAPN username.\r\nan option to set SIM card details according to cellu" +
        "lar provider operator. \r\nValid Data:\r\nstring\r\n");
            this.textBox_Config35.TextChanged += new System.EventHandler(this.TextBox_Config35_TextChanged);
            // 
            // tabPage11
            // 
            this.tabPage11.Location = new System.Drawing.Point(4, 28);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(1531, 513);
            this.tabPage11.TabIndex = 1;
            this.tabPage11.Text = "System 2";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // tabPage12
            // 
            this.tabPage12.Location = new System.Drawing.Point(4, 28);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Size = new System.Drawing.Size(1531, 513);
            this.tabPage12.TabIndex = 2;
            this.tabPage12.Text = "System 3";
            this.tabPage12.UseVisualStyleBackColor = true;
            // 
            // button32
            // 
            this.button32.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button32.Location = new System.Drawing.Point(661, 149);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(140, 27);
            this.button32.TabIndex = 96;
            this.button32.Text = "Lock Config";
            this.button32.UseVisualStyleBackColor = true;
            // 
            // groupBox38
            // 
            this.groupBox38.Controls.Add(this.button44);
            this.groupBox38.Controls.Add(this.button42);
            this.groupBox38.Controls.Add(this.button29);
            this.groupBox38.Controls.Add(this.button6);
            this.groupBox38.Controls.Add(this.button2);
            this.groupBox38.Controls.Add(this.button31);
            this.groupBox38.Controls.Add(this.textBox_SourceConfig);
            this.groupBox38.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox38.Location = new System.Drawing.Point(4, 5);
            this.groupBox38.Name = "groupBox38";
            this.groupBox38.Size = new System.Drawing.Size(505, 175);
            this.groupBox38.TabIndex = 102;
            this.groupBox38.TabStop = false;
            this.groupBox38.Text = "Configuration Load/Save";
            // 
            // button44
            // 
            this.button44.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button44.Location = new System.Drawing.Point(233, 58);
            this.button44.Name = "button44";
            this.button44.Size = new System.Drawing.Size(120, 32);
            this.button44.TabIndex = 65;
            this.button44.Text = "Set Remote";
            this.button44.UseVisualStyleBackColor = true;
            // 
            // button42
            // 
            this.button42.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button42.Location = new System.Drawing.Point(233, 25);
            this.button42.Name = "button42";
            this.button42.Size = new System.Drawing.Size(120, 32);
            this.button42.TabIndex = 64;
            this.button42.Text = "Get Remote";
            this.button42.UseVisualStyleBackColor = true;
            // 
            // button29
            // 
            this.button29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button29.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button29.Location = new System.Drawing.Point(129, 58);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(98, 32);
            this.button29.TabIndex = 63;
            this.button29.Text = "Save File";
            this.button29.UseVisualStyleBackColor = true;
            this.button29.Click += new System.EventHandler(this.Button29_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(6, 24);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(120, 32);
            this.button6.TabIndex = 25;
            this.button6.Text = "Get Serial Port";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6_Click_2);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(6, 58);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 32);
            this.button2.TabIndex = 62;
            this.button2.Text = "Set Serial Port";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click_2);
            // 
            // button31
            // 
            this.button31.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button31.Location = new System.Drawing.Point(129, 25);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(98, 32);
            this.button31.TabIndex = 22;
            this.button31.Text = "Load File";
            this.button31.UseVisualStyleBackColor = true;
            this.button31.Click += new System.EventHandler(this.Button31_Click);
            // 
            // textBox_SourceConfig
            // 
            this.textBox_SourceConfig.Location = new System.Drawing.Point(2, 95);
            this.textBox_SourceConfig.Name = "textBox_SourceConfig";
            this.textBox_SourceConfig.ReadOnly = true;
            this.textBox_SourceConfig.Size = new System.Drawing.Size(496, 62);
            this.textBox_SourceConfig.TabIndex = 28;
            this.textBox_SourceConfig.Text = "";
            this.textBox_SourceConfig.TextChanged += new System.EventHandler(this.TextBox_SourceConfig_TextChanged);
            // 
            // button30
            // 
            this.button30.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button30.Location = new System.Drawing.Point(515, 150);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(140, 27);
            this.button30.TabIndex = 87;
            this.button30.Text = "Clear Config";
            this.button30.UseVisualStyleBackColor = true;
            // 
            // tabPage_charts
            // 
            this.tabPage_charts.Controls.Add(this.comboBox_ChartUpdateTime);
            this.tabPage_charts.Controls.Add(this.button28);
            this.tabPage_charts.Controls.Add(this.listBox_Charts);
            this.tabPage_charts.Controls.Add(this.button_OpenFolder2);
            this.tabPage_charts.Controls.Add(this.button_GraphPause);
            this.tabPage_charts.Controls.Add(this.Button_Export_excel);
            this.tabPage_charts.Controls.Add(this.button_ResetGraphs);
            this.tabPage_charts.Controls.Add(this.textBox_graph_XY);
            this.tabPage_charts.Controls.Add(this.button_ScreenShot);
            this.tabPage_charts.Controls.Add(this.chart1);
            this.tabPage_charts.Location = new System.Drawing.Point(4, 22);
            this.tabPage_charts.Name = "tabPage_charts";
            this.tabPage_charts.Size = new System.Drawing.Size(1547, 687);
            this.tabPage_charts.TabIndex = 7;
            this.tabPage_charts.Text = "Charts";
            this.tabPage_charts.UseVisualStyleBackColor = true;
            // 
            // comboBox_ChartUpdateTime
            // 
            this.comboBox_ChartUpdateTime.FormattingEnabled = true;
            this.comboBox_ChartUpdateTime.Items.AddRange(new object[] {
            "100",
            "200",
            "500",
            "1000",
            "2000",
            "5000",
            "10000"});
            this.comboBox_ChartUpdateTime.Location = new System.Drawing.Point(5, 612);
            this.comboBox_ChartUpdateTime.Name = "comboBox_ChartUpdateTime";
            this.comboBox_ChartUpdateTime.Size = new System.Drawing.Size(184, 26);
            this.comboBox_ChartUpdateTime.TabIndex = 80;
            this.comboBox_ChartUpdateTime.Text = "Update time ms";
            this.comboBox_ChartUpdateTime.SelectedIndexChanged += new System.EventHandler(this.ComboBox_ChartUpdateTime_SelectedIndexChanged);
            // 
            // button28
            // 
            this.button28.Location = new System.Drawing.Point(3, 555);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(186, 23);
            this.button28.TabIndex = 79;
            this.button28.Text = "Reset X point";
            this.button28.UseVisualStyleBackColor = true;
            this.button28.Click += new System.EventHandler(this.Button28_Click_2);
            // 
            // listBox_Charts
            // 
            this.listBox_Charts.FormattingEnabled = true;
            this.listBox_Charts.ItemHeight = 18;
            this.listBox_Charts.Location = new System.Drawing.Point(5, 244);
            this.listBox_Charts.Name = "listBox_Charts";
            this.listBox_Charts.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_Charts.Size = new System.Drawing.Size(184, 184);
            this.listBox_Charts.TabIndex = 78;
            this.listBox_Charts.SelectedIndexChanged += new System.EventHandler(this.ListBox_Charts_SelectedIndexChanged);
            // 
            // button_OpenFolder2
            // 
            this.button_OpenFolder2.Location = new System.Drawing.Point(4, 434);
            this.button_OpenFolder2.Name = "button_OpenFolder2";
            this.button_OpenFolder2.Size = new System.Drawing.Size(185, 26);
            this.button_OpenFolder2.TabIndex = 77;
            this.button_OpenFolder2.Text = "Open Local Folder";
            this.button_OpenFolder2.UseVisualStyleBackColor = true;
            this.button_OpenFolder2.Click += new System.EventHandler(this.Button_OpenFolder2_Click);
            // 
            // button_GraphPause
            // 
            this.button_GraphPause.Location = new System.Drawing.Point(3, 583);
            this.button_GraphPause.Name = "button_GraphPause";
            this.button_GraphPause.Size = new System.Drawing.Size(186, 23);
            this.button_GraphPause.TabIndex = 8;
            this.button_GraphPause.Text = "Pause";
            this.button_GraphPause.UseVisualStyleBackColor = true;
            this.button_GraphPause.Click += new System.EventHandler(this.Button_GraphPause_Click);
            // 
            // Button_Export_excel
            // 
            this.Button_Export_excel.Location = new System.Drawing.Point(3, 466);
            this.Button_Export_excel.Name = "Button_Export_excel";
            this.Button_Export_excel.Size = new System.Drawing.Size(186, 23);
            this.Button_Export_excel.TabIndex = 7;
            this.Button_Export_excel.Text = "Export to excel";
            this.Button_Export_excel.UseVisualStyleBackColor = true;
            this.Button_Export_excel.Click += new System.EventHandler(this.Button_Export_excel_Click);
            // 
            // button_ResetGraphs
            // 
            this.button_ResetGraphs.Location = new System.Drawing.Point(3, 525);
            this.button_ResetGraphs.Name = "button_ResetGraphs";
            this.button_ResetGraphs.Size = new System.Drawing.Size(186, 23);
            this.button_ResetGraphs.TabIndex = 6;
            this.button_ResetGraphs.Text = "Reset chart data";
            this.button_ResetGraphs.UseVisualStyleBackColor = true;
            this.button_ResetGraphs.Click += new System.EventHandler(this.Button_ResetGraphs_Click);
            // 
            // textBox_graph_XY
            // 
            this.textBox_graph_XY.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_graph_XY.Location = new System.Drawing.Point(4, 8);
            this.textBox_graph_XY.Multiline = true;
            this.textBox_graph_XY.Name = "textBox_graph_XY";
            this.textBox_graph_XY.ReadOnly = true;
            this.textBox_graph_XY.Size = new System.Drawing.Size(185, 232);
            this.textBox_graph_XY.TabIndex = 4;
            this.textBox_graph_XY.Text = "Message box ";
            this.textBox_graph_XY.TextChanged += new System.EventHandler(this.TextBox_graph_XY_TextChanged);
            // 
            // button_ScreenShot
            // 
            this.button_ScreenShot.Location = new System.Drawing.Point(3, 494);
            this.button_ScreenShot.Name = "button_ScreenShot";
            this.button_ScreenShot.Size = new System.Drawing.Size(186, 23);
            this.button_ScreenShot.TabIndex = 1;
            this.button_ScreenShot.Text = "Take screen shot";
            this.button_ScreenShot.UseVisualStyleBackColor = true;
            this.button_ScreenShot.Click += new System.EventHandler(this.Button_ScreenShot_Click);
            // 
            // chart1
            // 
            chartArea7.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea7);
            legend7.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend7.IsTextAutoFit = false;
            legend7.Name = "Legend1";
            this.chart1.Legends.Add(legend7);
            this.chart1.Location = new System.Drawing.Point(194, 2);
            this.chart1.Name = "chart1";
            series19.ChartArea = "ChartArea1";
            series19.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series19.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series19.Legend = "Legend1";
            series19.Name = "Data 1";
            series20.ChartArea = "ChartArea1";
            series20.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series20.Font = new System.Drawing.Font("Calibri", 14.25F);
            series20.Legend = "Legend1";
            series20.Name = "Data 2";
            series21.ChartArea = "ChartArea1";
            series21.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series21.Font = new System.Drawing.Font("Calibri", 14.25F);
            series21.Legend = "Legend1";
            series21.Name = "Data 3";
            this.chart1.Series.Add(series19);
            this.chart1.Series.Add(series20);
            this.chart1.Series.Add(series21);
            this.chart1.Size = new System.Drawing.Size(1350, 665);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // tabPage_SerialPort
            // 
            this.tabPage_SerialPort.Controls.Add(this.groupBox_SendSerialOrMonitorCommands);
            this.tabPage_SerialPort.Controls.Add(this.gbPortSettings);
            this.tabPage_SerialPort.Controls.Add(this.groupBox5);
            this.tabPage_SerialPort.Location = new System.Drawing.Point(4, 27);
            this.tabPage_SerialPort.Name = "tabPage_SerialPort";
            this.tabPage_SerialPort.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_SerialPort.Size = new System.Drawing.Size(1547, 682);
            this.tabPage_SerialPort.TabIndex = 1;
            this.tabPage_SerialPort.Text = "Serial Port";
            this.tabPage_SerialPort.UseVisualStyleBackColor = true;
            // 
            // groupBox_SendSerialOrMonitorCommands
            // 
            this.groupBox_SendSerialOrMonitorCommands.Controls.Add(this.checkBox_SendHexdata);
            this.groupBox_SendSerialOrMonitorCommands.Controls.Add(this.textBox_SendSerialPort);
            this.groupBox_SendSerialOrMonitorCommands.Controls.Add(this.checkBox_DeleteCommand);
            this.groupBox_SendSerialOrMonitorCommands.Controls.Add(this.button_SendSerialPort);
            this.groupBox_SendSerialOrMonitorCommands.Location = new System.Drawing.Point(4, 6);
            this.groupBox_SendSerialOrMonitorCommands.Name = "groupBox_SendSerialOrMonitorCommands";
            this.groupBox_SendSerialOrMonitorCommands.Size = new System.Drawing.Size(626, 93);
            this.groupBox_SendSerialOrMonitorCommands.TabIndex = 69;
            this.groupBox_SendSerialOrMonitorCommands.TabStop = false;
            this.groupBox_SendSerialOrMonitorCommands.Text = "Send Data to Serial Port";
            // 
            // checkBox_SendHexdata
            // 
            this.checkBox_SendHexdata.AutoSize = true;
            this.checkBox_SendHexdata.Location = new System.Drawing.Point(262, 60);
            this.checkBox_SendHexdata.Name = "checkBox_SendHexdata";
            this.checkBox_SendHexdata.Size = new System.Drawing.Size(115, 22);
            this.checkBox_SendHexdata.TabIndex = 5;
            this.checkBox_SendHexdata.Text = "Send Hex data";
            this.toolTip1.SetToolTip(this.checkBox_SendHexdata, "Example:\r\n11 22 33 44 is 0x11 0x22 0x33 0x44\r\n");
            this.checkBox_SendHexdata.UseVisualStyleBackColor = true;
            this.checkBox_SendHexdata.CheckedChanged += new System.EventHandler(this.CheckBox_SendHexdata_CheckedChanged);
            // 
            // textBox_SendSerialPort
            // 
            this.textBox_SendSerialPort.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox_SendSerialPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_SendSerialPort.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SendSerialPort.Location = new System.Drawing.Point(9, 21);
            this.textBox_SendSerialPort.Name = "textBox_SendSerialPort";
            this.textBox_SendSerialPort.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_SendSerialPort.Size = new System.Drawing.Size(611, 31);
            this.textBox_SendSerialPort.TabIndex = 0;
            this.toolTip1.SetToolTip(this.textBox_SendSerialPort, "Press help");
            this.textBox_SendSerialPort.TextChanged += new System.EventHandler(this.TextBox_SendSerialPort_TextChanged_1);
            this.textBox_SendSerialPort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_SendSerialPort_KeyDown);
            // 
            // checkBox_DeleteCommand
            // 
            this.checkBox_DeleteCommand.AutoSize = true;
            this.checkBox_DeleteCommand.Checked = true;
            this.checkBox_DeleteCommand.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_DeleteCommand.Location = new System.Drawing.Point(126, 61);
            this.checkBox_DeleteCommand.Name = "checkBox_DeleteCommand";
            this.checkBox_DeleteCommand.Size = new System.Drawing.Size(135, 22);
            this.checkBox_DeleteCommand.TabIndex = 4;
            this.checkBox_DeleteCommand.Text = "Delete after Send";
            this.toolTip1.SetToolTip(this.checkBox_DeleteCommand, "Delete after Send");
            this.checkBox_DeleteCommand.UseVisualStyleBackColor = true;
            // 
            // button_SendSerialPort
            // 
            this.button_SendSerialPort.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_SendSerialPort.Location = new System.Drawing.Point(9, 58);
            this.button_SendSerialPort.Name = "button_SendSerialPort";
            this.button_SendSerialPort.Size = new System.Drawing.Size(105, 24);
            this.button_SendSerialPort.TabIndex = 1;
            this.button_SendSerialPort.Text = "Send";
            this.button_SendSerialPort.Click += new System.EventHandler(this.Button2_Click_1);
            // 
            // gbPortSettings
            // 
            this.gbPortSettings.Controls.Add(this.button_OpenPort);
            this.gbPortSettings.Controls.Add(this.button_ReScanComPort);
            this.gbPortSettings.Controls.Add(this.cmbPortName);
            this.gbPortSettings.Controls.Add(this.cmbBaudRate);
            this.gbPortSettings.Controls.Add(this.cmbStopBits);
            this.gbPortSettings.Controls.Add(this.cmbParity);
            this.gbPortSettings.Controls.Add(this.cmbDataBits);
            this.gbPortSettings.Controls.Add(this.lblComPort);
            this.gbPortSettings.Controls.Add(this.lblStopBits);
            this.gbPortSettings.Controls.Add(this.lblBaudRate);
            this.gbPortSettings.Controls.Add(this.lblDataBits);
            this.gbPortSettings.Controls.Add(this.label3);
            this.gbPortSettings.Location = new System.Drawing.Point(636, 6);
            this.gbPortSettings.Name = "gbPortSettings";
            this.gbPortSettings.Size = new System.Drawing.Size(905, 92);
            this.gbPortSettings.TabIndex = 10;
            this.gbPortSettings.TabStop = false;
            this.gbPortSettings.Text = "COM Serial Port Settings";
            // 
            // button_OpenPort
            // 
            this.button_OpenPort.Location = new System.Drawing.Point(507, 34);
            this.button_OpenPort.Name = "button_OpenPort";
            this.button_OpenPort.Size = new System.Drawing.Size(91, 33);
            this.button_OpenPort.TabIndex = 11;
            this.button_OpenPort.Text = "Open ";
            this.button_OpenPort.UseVisualStyleBackColor = true;
            this.button_OpenPort.Click += new System.EventHandler(this.Button_OpenPort_Click);
            // 
            // button_ReScanComPort
            // 
            this.button_ReScanComPort.AutoSize = true;
            this.button_ReScanComPort.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ReScanComPort.Location = new System.Drawing.Point(414, 34);
            this.button_ReScanComPort.Name = "button_ReScanComPort";
            this.button_ReScanComPort.Size = new System.Drawing.Size(87, 34);
            this.button_ReScanComPort.TabIndex = 10;
            this.button_ReScanComPort.Text = "ReScan";
            this.button_ReScanComPort.UseVisualStyleBackColor = true;
            this.button_ReScanComPort.Click += new System.EventHandler(this.Button_ReScanComPort_Click);
            // 
            // cmbPortName
            // 
            this.cmbPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPortName.FormattingEnabled = true;
            this.cmbPortName.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6"});
            this.cmbPortName.Location = new System.Drawing.Point(8, 38);
            this.cmbPortName.Name = "cmbPortName";
            this.cmbPortName.Size = new System.Drawing.Size(67, 26);
            this.cmbPortName.TabIndex = 1;
            this.cmbPortName.Tag = "1";
            this.cmbPortName.SelectedIndexChanged += new System.EventHandler(this.CmbPortName_SelectedIndexChanged);
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cmbBaudRate.Location = new System.Drawing.Point(81, 38);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(89, 26);
            this.cmbBaudRate.TabIndex = 3;
            this.cmbBaudRate.Text = "115200";
            this.cmbBaudRate.SelectedIndexChanged += new System.EventHandler(this.CmbBaudRate_SelectedIndexChanged);
            // 
            // cmbStopBits
            // 
            this.cmbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStopBits.FormattingEnabled = true;
            this.cmbStopBits.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cmbStopBits.Location = new System.Drawing.Point(308, 37);
            this.cmbStopBits.Name = "cmbStopBits";
            this.cmbStopBits.Size = new System.Drawing.Size(88, 26);
            this.cmbStopBits.TabIndex = 9;
            // 
            // cmbParity
            // 
            this.cmbParity.DisplayMember = "1";
            this.cmbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
            this.cmbParity.Location = new System.Drawing.Point(176, 37);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(60, 26);
            this.cmbParity.TabIndex = 5;
            this.cmbParity.Tag = "1";
            // 
            // cmbDataBits
            // 
            this.cmbDataBits.FormattingEnabled = true;
            this.cmbDataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cmbDataBits.Location = new System.Drawing.Point(241, 37);
            this.cmbDataBits.Name = "cmbDataBits";
            this.cmbDataBits.Size = new System.Drawing.Size(60, 26);
            this.cmbDataBits.TabIndex = 7;
            this.cmbDataBits.Text = "8";
            // 
            // lblComPort
            // 
            this.lblComPort.AutoSize = true;
            this.lblComPort.Location = new System.Drawing.Point(7, 22);
            this.lblComPort.Name = "lblComPort";
            this.lblComPort.Size = new System.Drawing.Size(71, 18);
            this.lblComPort.TabIndex = 0;
            this.lblComPort.Text = "COM Port:";
            // 
            // lblStopBits
            // 
            this.lblStopBits.AutoSize = true;
            this.lblStopBits.Location = new System.Drawing.Point(310, 21);
            this.lblStopBits.Name = "lblStopBits";
            this.lblStopBits.Size = new System.Drawing.Size(66, 18);
            this.lblStopBits.TabIndex = 8;
            this.lblStopBits.Text = "Stop Bits:";
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Location = new System.Drawing.Point(80, 22);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(74, 18);
            this.lblBaudRate.TabIndex = 2;
            this.lblBaudRate.Text = "Baud Rate:";
            // 
            // lblDataBits
            // 
            this.lblDataBits.AutoSize = true;
            this.lblDataBits.Location = new System.Drawing.Point(244, 21);
            this.lblDataBits.Name = "lblDataBits";
            this.lblDataBits.Size = new System.Drawing.Size(66, 18);
            this.lblDataBits.TabIndex = 6;
            this.lblDataBits.Text = "Data Bits:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Parity:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox_Timer);
            this.groupBox5.Controls.Add(this.groupBox_Stopwatch);
            this.groupBox5.Controls.Add(this.checkBox_RxHex);
            this.groupBox5.Controls.Add(this.textBox_SerialPortRecognizePattern3);
            this.groupBox5.Controls.Add(this.textBox_SerialPortRecognizePattern2);
            this.groupBox5.Controls.Add(this.textBox_SerialPortRecognizePattern);
            this.groupBox5.Controls.Add(this.checkBox_S1RecordLog);
            this.groupBox5.Controls.Add(this.checkBox_S1Pause);
            this.groupBox5.Controls.Add(this.txtS1_Clear);
            this.groupBox5.Controls.Add(this.SerialPortLogger_TextBox);
            this.groupBox5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(4, 105);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1537, 571);
            this.groupBox5.TabIndex = 68;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Serial Port Console";
            this.groupBox5.Enter += new System.EventHandler(this.GroupBox5_Enter);
            // 
            // groupBox_Timer
            // 
            this.groupBox_Timer.Controls.Add(this.textBox_TimerTime);
            this.groupBox_Timer.Controls.Add(this.button_StartStopTimer);
            this.groupBox_Timer.Controls.Add(this.button_ResetTimer);
            this.groupBox_Timer.Controls.Add(this.textBox_SetTimerTime);
            this.groupBox_Timer.Location = new System.Drawing.Point(41, 727);
            this.groupBox_Timer.Name = "groupBox_Timer";
            this.groupBox_Timer.Size = new System.Drawing.Size(270, 111);
            this.groupBox_Timer.TabIndex = 107;
            this.groupBox_Timer.TabStop = false;
            this.groupBox_Timer.Text = "Timer";
            this.groupBox_Timer.Visible = false;
            // 
            // textBox_TimerTime
            // 
            this.textBox_TimerTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_TimerTime.Location = new System.Drawing.Point(119, 66);
            this.textBox_TimerTime.Name = "textBox_TimerTime";
            this.textBox_TimerTime.ReadOnly = true;
            this.textBox_TimerTime.Size = new System.Drawing.Size(70, 31);
            this.textBox_TimerTime.TabIndex = 106;
            this.textBox_TimerTime.Text = "0";
            // 
            // button_StartStopTimer
            // 
            this.button_StartStopTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_StartStopTimer.Location = new System.Drawing.Point(9, 23);
            this.button_StartStopTimer.Name = "button_StartStopTimer";
            this.button_StartStopTimer.Size = new System.Drawing.Size(110, 37);
            this.button_StartStopTimer.TabIndex = 104;
            this.button_StartStopTimer.Text = "Start/Stop";
            this.button_StartStopTimer.UseVisualStyleBackColor = true;
            this.button_StartStopTimer.Click += new System.EventHandler(this.Button_StartStopTimer_Click);
            // 
            // button_ResetTimer
            // 
            this.button_ResetTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ResetTimer.Location = new System.Drawing.Point(119, 23);
            this.button_ResetTimer.Name = "button_ResetTimer";
            this.button_ResetTimer.Size = new System.Drawing.Size(110, 37);
            this.button_ResetTimer.TabIndex = 105;
            this.button_ResetTimer.Text = "Reset (0)";
            this.button_ResetTimer.UseVisualStyleBackColor = true;
            this.button_ResetTimer.Click += new System.EventHandler(this.Button_ResetTimer_Click);
            // 
            // textBox_SetTimerTime
            // 
            this.textBox_SetTimerTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SetTimerTime.Location = new System.Drawing.Point(9, 66);
            this.textBox_SetTimerTime.Name = "textBox_SetTimerTime";
            this.textBox_SetTimerTime.Size = new System.Drawing.Size(104, 31);
            this.textBox_SetTimerTime.TabIndex = 103;
            this.textBox_SetTimerTime.Text = "0";
            // 
            // groupBox_Stopwatch
            // 
            this.groupBox_Stopwatch.Controls.Add(this.button_TimerLog);
            this.groupBox_Stopwatch.Controls.Add(this.button_Stopwatch_Start_Stop);
            this.groupBox_Stopwatch.Controls.Add(this.button_StopwatchReset);
            this.groupBox_Stopwatch.Controls.Add(this.textBox_StopWatch);
            this.groupBox_Stopwatch.Location = new System.Drawing.Point(41, 609);
            this.groupBox_Stopwatch.Name = "groupBox_Stopwatch";
            this.groupBox_Stopwatch.Size = new System.Drawing.Size(270, 111);
            this.groupBox_Stopwatch.TabIndex = 106;
            this.groupBox_Stopwatch.TabStop = false;
            this.groupBox_Stopwatch.Text = "Stopwatch";
            this.groupBox_Stopwatch.Visible = false;
            // 
            // button_TimerLog
            // 
            this.button_TimerLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_TimerLog.Location = new System.Drawing.Point(189, 23);
            this.button_TimerLog.Name = "button_TimerLog";
            this.button_TimerLog.Size = new System.Drawing.Size(75, 37);
            this.button_TimerLog.TabIndex = 106;
            this.button_TimerLog.Text = "Log ->";
            this.toolTip1.SetToolTip(this.button_TimerLog, "Print the elapsed time to the terminal ");
            this.toolTip2.SetToolTip(this.button_TimerLog, "Print the elapsed time to the terminal");
            this.button_TimerLog.UseVisualStyleBackColor = true;
            this.button_TimerLog.Click += new System.EventHandler(this.Button_TimerLog_Click);
            // 
            // button_Stopwatch_Start_Stop
            // 
            this.button_Stopwatch_Start_Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Stopwatch_Start_Stop.Location = new System.Drawing.Point(9, 23);
            this.button_Stopwatch_Start_Stop.Name = "button_Stopwatch_Start_Stop";
            this.button_Stopwatch_Start_Stop.Size = new System.Drawing.Size(110, 37);
            this.button_Stopwatch_Start_Stop.TabIndex = 104;
            this.button_Stopwatch_Start_Stop.Text = "Start/Stop";
            this.button_Stopwatch_Start_Stop.UseVisualStyleBackColor = true;
            this.button_Stopwatch_Start_Stop.Click += new System.EventHandler(this.Button_Stopwatch_Start_Stop_Click);
            // 
            // button_StopwatchReset
            // 
            this.button_StopwatchReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_StopwatchReset.Location = new System.Drawing.Point(119, 23);
            this.button_StopwatchReset.Name = "button_StopwatchReset";
            this.button_StopwatchReset.Size = new System.Drawing.Size(70, 37);
            this.button_StopwatchReset.TabIndex = 105;
            this.button_StopwatchReset.Text = "Reset";
            this.button_StopwatchReset.UseVisualStyleBackColor = true;
            this.button_StopwatchReset.Click += new System.EventHandler(this.Button_StopwatchReset_Click);
            // 
            // textBox_StopWatch
            // 
            this.textBox_StopWatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_StopWatch.Location = new System.Drawing.Point(9, 66);
            this.textBox_StopWatch.Name = "textBox_StopWatch";
            this.textBox_StopWatch.ReadOnly = true;
            this.textBox_StopWatch.Size = new System.Drawing.Size(200, 31);
            this.textBox_StopWatch.TabIndex = 103;
            this.textBox_StopWatch.Text = "0";
            this.textBox_StopWatch.TextChanged += new System.EventHandler(this.TextBox_StopWatch_TextChanged);
            // 
            // checkBox_RxHex
            // 
            this.checkBox_RxHex.AutoSize = true;
            this.checkBox_RxHex.Location = new System.Drawing.Point(1194, 20);
            this.checkBox_RxHex.Name = "checkBox_RxHex";
            this.checkBox_RxHex.Size = new System.Drawing.Size(111, 23);
            this.checkBox_RxHex.TabIndex = 6;
            this.checkBox_RxHex.Text = "Show Rx Hex";
            this.checkBox_RxHex.UseVisualStyleBackColor = true;
            // 
            // textBox_SerialPortRecognizePattern3
            // 
            this.textBox_SerialPortRecognizePattern3.Location = new System.Drawing.Point(252, 17);
            this.textBox_SerialPortRecognizePattern3.Name = "textBox_SerialPortRecognizePattern3";
            this.textBox_SerialPortRecognizePattern3.Size = new System.Drawing.Size(117, 27);
            this.textBox_SerialPortRecognizePattern3.TabIndex = 75;
            this.toolTip2.SetToolTip(this.textBox_SerialPortRecognizePattern3, "Recognize Pattern by string");
            this.toolTip1.SetToolTip(this.textBox_SerialPortRecognizePattern3, "Recognize Pattern by string");
            // 
            // textBox_SerialPortRecognizePattern2
            // 
            this.textBox_SerialPortRecognizePattern2.Location = new System.Drawing.Point(129, 18);
            this.textBox_SerialPortRecognizePattern2.Name = "textBox_SerialPortRecognizePattern2";
            this.textBox_SerialPortRecognizePattern2.Size = new System.Drawing.Size(117, 27);
            this.textBox_SerialPortRecognizePattern2.TabIndex = 74;
            this.toolTip2.SetToolTip(this.textBox_SerialPortRecognizePattern2, "Recognize Pattern by string");
            this.toolTip1.SetToolTip(this.textBox_SerialPortRecognizePattern2, "Recognize Pattern by string");
            // 
            // textBox_SerialPortRecognizePattern
            // 
            this.textBox_SerialPortRecognizePattern.Location = new System.Drawing.Point(6, 18);
            this.textBox_SerialPortRecognizePattern.Name = "textBox_SerialPortRecognizePattern";
            this.textBox_SerialPortRecognizePattern.Size = new System.Drawing.Size(117, 27);
            this.textBox_SerialPortRecognizePattern.TabIndex = 73;
            this.toolTip2.SetToolTip(this.textBox_SerialPortRecognizePattern, "Recognize Pattern by string");
            this.toolTip1.SetToolTip(this.textBox_SerialPortRecognizePattern, "Recognize Pattern by string");
            // 
            // checkBox_S1RecordLog
            // 
            this.checkBox_S1RecordLog.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_S1RecordLog.AutoSize = true;
            this.checkBox_S1RecordLog.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_S1RecordLog.Location = new System.Drawing.Point(1311, 17);
            this.checkBox_S1RecordLog.Name = "checkBox_S1RecordLog";
            this.checkBox_S1RecordLog.Size = new System.Drawing.Size(83, 29);
            this.checkBox_S1RecordLog.TabIndex = 69;
            this.checkBox_S1RecordLog.Text = "Log to file";
            this.checkBox_S1RecordLog.UseVisualStyleBackColor = true;
            this.checkBox_S1RecordLog.CheckedChanged += new System.EventHandler(this.CheckBox_S1RecordLog_CheckedChanged);
            // 
            // checkBox_S1Pause
            // 
            this.checkBox_S1Pause.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_S1Pause.AutoSize = true;
            this.checkBox_S1Pause.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_S1Pause.Location = new System.Drawing.Point(1403, 17);
            this.checkBox_S1Pause.Name = "checkBox_S1Pause";
            this.checkBox_S1Pause.Size = new System.Drawing.Size(58, 29);
            this.checkBox_S1Pause.TabIndex = 70;
            this.checkBox_S1Pause.Text = "Pause";
            this.checkBox_S1Pause.UseVisualStyleBackColor = true;
            this.checkBox_S1Pause.CheckedChanged += new System.EventHandler(this.CheckBox_S1Pause_CheckedChanged);
            // 
            // txtS1_Clear
            // 
            this.txtS1_Clear.Font = new System.Drawing.Font("Calibri", 12F);
            this.txtS1_Clear.Location = new System.Drawing.Point(1468, 17);
            this.txtS1_Clear.Name = "txtS1_Clear";
            this.txtS1_Clear.Size = new System.Drawing.Size(62, 26);
            this.txtS1_Clear.TabIndex = 69;
            this.txtS1_Clear.Text = "Clear";
            this.txtS1_Clear.UseVisualStyleBackColor = true;
            this.txtS1_Clear.Click += new System.EventHandler(this.txtS1_Clear_Click);
            // 
            // SerialPortLogger_TextBox
            // 
            this.SerialPortLogger_TextBox.BackColor = System.Drawing.Color.LightGray;
            this.SerialPortLogger_TextBox.EnableAutoDragDrop = true;
            this.SerialPortLogger_TextBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SerialPortLogger_TextBox.Location = new System.Drawing.Point(4, 49);
            this.SerialPortLogger_TextBox.Name = "SerialPortLogger_TextBox";
            this.SerialPortLogger_TextBox.Size = new System.Drawing.Size(1536, 516);
            this.SerialPortLogger_TextBox.TabIndex = 0;
            this.SerialPortLogger_TextBox.Text = "";
            this.SerialPortLogger_TextBox.TextChanged += new System.EventHandler(this.SerialPortLogger_TextBox_TextChanged);
            // 
            // tabPage_ServerTCP
            // 
            this.tabPage_ServerTCP.Controls.Add(this.checkBox_ParseMessages);
            this.tabPage_ServerTCP.Controls.Add(this.textBox_IDKey);
            this.tabPage_ServerTCP.Controls.Add(this.groupBox_FOTA);
            this.tabPage_ServerTCP.Controls.Add(this.checkBox_EchoResponse);
            this.tabPage_ServerTCP.Controls.Add(this.groupBox_ServerSettings);
            this.tabPage_ServerTCP.Controls.Add(this.groupBox_ConnectionTimedOut);
            this.tabPage_ServerTCP.Controls.Add(this.groupBox2);
            this.tabPage_ServerTCP.Controls.Add(this.groupBox3);
            this.tabPage_ServerTCP.Location = new System.Drawing.Point(4, 27);
            this.tabPage_ServerTCP.Name = "tabPage_ServerTCP";
            this.tabPage_ServerTCP.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ServerTCP.Size = new System.Drawing.Size(1547, 682);
            this.tabPage_ServerTCP.TabIndex = 0;
            this.tabPage_ServerTCP.Text = "Server TCP";
            this.tabPage_ServerTCP.UseVisualStyleBackColor = true;
            // 
            // button_ClearServer
            // 
            this.button_ClearServer.Location = new System.Drawing.Point(6, 578);
            this.button_ClearServer.Name = "button_ClearServer";
            this.button_ClearServer.Size = new System.Drawing.Size(75, 23);
            this.button_ClearServer.TabIndex = 104;
            this.button_ClearServer.Text = "Clear";
            this.button_ClearServer.UseVisualStyleBackColor = true;
            // 
            // checkBox_ParseMessages
            // 
            this.checkBox_ParseMessages.AutoSize = true;
            this.checkBox_ParseMessages.Location = new System.Drawing.Point(116, 343);
            this.checkBox_ParseMessages.Name = "checkBox_ParseMessages";
            this.checkBox_ParseMessages.Size = new System.Drawing.Size(124, 22);
            this.checkBox_ParseMessages.TabIndex = 103;
            this.checkBox_ParseMessages.Text = "Parse messages";
            this.checkBox_ParseMessages.UseVisualStyleBackColor = true;
            this.checkBox_ParseMessages.CheckedChanged += new System.EventHandler(this.CheckBox_ParseMessages_CheckedChanged);
            // 
            // textBox_IDKey
            // 
            this.textBox_IDKey.Location = new System.Drawing.Point(1224, 78);
            this.textBox_IDKey.Name = "textBox_IDKey";
            this.textBox_IDKey.Size = new System.Drawing.Size(317, 152);
            this.textBox_IDKey.TabIndex = 102;
            this.textBox_IDKey.Text = "";
            this.textBox_IDKey.Visible = false;
            // 
            // groupBox_FOTA
            // 
            this.groupBox_FOTA.Controls.Add(this.button_StartFOTAProcess);
            this.groupBox_FOTA.Controls.Add(this.textBox_TotalFileLength);
            this.groupBox_FOTA.Controls.Add(this.textBox_MaximumNumberReceivedRequest);
            this.groupBox_FOTA.Controls.Add(this.button35);
            this.groupBox_FOTA.Controls.Add(this.button_StartFOTA);
            this.groupBox_FOTA.Controls.Add(this.textBox_TotalFrames1280Bytes);
            this.groupBox_FOTA.Controls.Add(this.textBox_FOTA);
            this.groupBox_FOTA.Controls.Add(this.button5);
            this.groupBox_FOTA.Location = new System.Drawing.Point(3, 364);
            this.groupBox_FOTA.Name = "groupBox_FOTA";
            this.groupBox_FOTA.Size = new System.Drawing.Size(268, 213);
            this.groupBox_FOTA.TabIndex = 12;
            this.groupBox_FOTA.TabStop = false;
            this.groupBox_FOTA.Text = "FOTA";
            this.groupBox_FOTA.Visible = false;
            // 
            // button_StartFOTAProcess
            // 
            this.button_StartFOTAProcess.Enabled = false;
            this.button_StartFOTAProcess.Location = new System.Drawing.Point(206, 107);
            this.button_StartFOTAProcess.Name = "button_StartFOTAProcess";
            this.button_StartFOTAProcess.Size = new System.Drawing.Size(57, 44);
            this.button_StartFOTAProcess.TabIndex = 21;
            this.button_StartFOTAProcess.Text = "Start FOTA";
            this.button_StartFOTAProcess.UseVisualStyleBackColor = true;
            this.button_StartFOTAProcess.Click += new System.EventHandler(this.Button34_Click_1);
            // 
            // textBox_TotalFileLength
            // 
            this.textBox_TotalFileLength.Location = new System.Drawing.Point(206, 78);
            this.textBox_TotalFileLength.Name = "textBox_TotalFileLength";
            this.textBox_TotalFileLength.ReadOnly = true;
            this.textBox_TotalFileLength.Size = new System.Drawing.Size(57, 26);
            this.textBox_TotalFileLength.TabIndex = 20;
            this.toolTip2.SetToolTip(this.textBox_TotalFileLength, "Total file length in bytes");
            this.toolTip1.SetToolTip(this.textBox_TotalFileLength, "Total file length in bytes");
            // 
            // textBox_MaximumNumberReceivedRequest
            // 
            this.textBox_MaximumNumberReceivedRequest.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_MaximumNumberReceivedRequest.Location = new System.Drawing.Point(4, 106);
            this.textBox_MaximumNumberReceivedRequest.Name = "textBox_MaximumNumberReceivedRequest";
            this.textBox_MaximumNumberReceivedRequest.Size = new System.Drawing.Size(196, 89);
            this.textBox_MaximumNumberReceivedRequest.TabIndex = 19;
            this.textBox_MaximumNumberReceivedRequest.Text = "";
            // 
            // button35
            // 
            this.button35.Location = new System.Drawing.Point(206, 300);
            this.button35.Name = "button35";
            this.button35.Size = new System.Drawing.Size(57, 23);
            this.button35.TabIndex = 18;
            this.button35.Text = "Clear";
            this.button35.UseVisualStyleBackColor = true;
            this.button35.Click += new System.EventHandler(this.Button35_Click);
            // 
            // button_StartFOTA
            // 
            this.button_StartFOTA.Enabled = false;
            this.button_StartFOTA.Location = new System.Drawing.Point(206, 273);
            this.button_StartFOTA.Name = "button_StartFOTA";
            this.button_StartFOTA.Size = new System.Drawing.Size(57, 23);
            this.button_StartFOTA.TabIndex = 16;
            this.button_StartFOTA.Text = "--->";
            this.button_StartFOTA.UseVisualStyleBackColor = true;
            this.button_StartFOTA.Click += new System.EventHandler(this.Button33_Click);
            // 
            // textBox_TotalFrames1280Bytes
            // 
            this.textBox_TotalFrames1280Bytes.Location = new System.Drawing.Point(206, 49);
            this.textBox_TotalFrames1280Bytes.Name = "textBox_TotalFrames1280Bytes";
            this.textBox_TotalFrames1280Bytes.ReadOnly = true;
            this.textBox_TotalFrames1280Bytes.Size = new System.Drawing.Size(57, 26);
            this.textBox_TotalFrames1280Bytes.TabIndex = 14;
            this.toolTip2.SetToolTip(this.textBox_TotalFrames1280Bytes, "Total Frames 1280 Bytes");
            this.toolTip1.SetToolTip(this.textBox_TotalFrames1280Bytes, "Total Frames 1280 Bytes");
            this.textBox_TotalFrames1280Bytes.TextChanged += new System.EventHandler(this.TextBox_TotalFrames256Bytes_TextChanged);
            // 
            // textBox_FOTA
            // 
            this.textBox_FOTA.Location = new System.Drawing.Point(7, 49);
            this.textBox_FOTA.Multiline = true;
            this.textBox_FOTA.Name = "textBox_FOTA";
            this.textBox_FOTA.Size = new System.Drawing.Size(193, 52);
            this.textBox_FOTA.TabIndex = 13;
            this.textBox_FOTA.TextChanged += new System.EventHandler(this.TextBox_FOTA_TextChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(7, 20);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(98, 23);
            this.button5.TabIndex = 0;
            this.button5.Text = "Choose File";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // checkBox_EchoResponse
            // 
            this.checkBox_EchoResponse.AutoSize = true;
            this.checkBox_EchoResponse.Location = new System.Drawing.Point(5, 343);
            this.checkBox_EchoResponse.Name = "checkBox_EchoResponse";
            this.checkBox_EchoResponse.Size = new System.Drawing.Size(117, 22);
            this.checkBox_EchoResponse.TabIndex = 10;
            this.checkBox_EchoResponse.Text = "Send ACK Back";
            this.checkBox_EchoResponse.UseVisualStyleBackColor = true;
            this.checkBox_EchoResponse.CheckedChanged += new System.EventHandler(this.CheckBox_EchoResponse_CheckedChanged);
            // 
            // groupBox_ConnectionTimedOut
            // 
            this.groupBox_ConnectionTimedOut.Controls.Add(this.textBox_CurrentTimeOut);
            this.groupBox_ConnectionTimedOut.Controls.Add(this.button_SetTimedOut);
            this.groupBox_ConnectionTimedOut.Controls.Add(this.textBox_ConnectionTimedOut);
            this.groupBox_ConnectionTimedOut.Location = new System.Drawing.Point(3, 288);
            this.groupBox_ConnectionTimedOut.Name = "groupBox_ConnectionTimedOut";
            this.groupBox_ConnectionTimedOut.Size = new System.Drawing.Size(273, 53);
            this.groupBox_ConnectionTimedOut.TabIndex = 9;
            this.groupBox_ConnectionTimedOut.TabStop = false;
            this.groupBox_ConnectionTimedOut.Text = "Server Connection Timed Out (seconds)";
            this.groupBox_ConnectionTimedOut.Visible = false;
            // 
            // textBox_CurrentTimeOut
            // 
            this.textBox_CurrentTimeOut.Location = new System.Drawing.Point(146, 21);
            this.textBox_CurrentTimeOut.Name = "textBox_CurrentTimeOut";
            this.textBox_CurrentTimeOut.ReadOnly = true;
            this.textBox_CurrentTimeOut.Size = new System.Drawing.Size(62, 26);
            this.textBox_CurrentTimeOut.TabIndex = 10;
            this.toolTip1.SetToolTip(this.textBox_CurrentTimeOut, "Current Timed Out");
            // 
            // button_SetTimedOut
            // 
            this.button_SetTimedOut.Location = new System.Drawing.Point(65, 21);
            this.button_SetTimedOut.Name = "button_SetTimedOut";
            this.button_SetTimedOut.Size = new System.Drawing.Size(75, 23);
            this.button_SetTimedOut.TabIndex = 9;
            this.button_SetTimedOut.Text = "Set";
            this.toolTip1.SetToolTip(this.button_SetTimedOut, "Set Timed Out");
            this.button_SetTimedOut.UseVisualStyleBackColor = true;
            this.button_SetTimedOut.Click += new System.EventHandler(this.Button_SetTimedOut_Click);
            // 
            // textBox_ConnectionTimedOut
            // 
            this.textBox_ConnectionTimedOut.Location = new System.Drawing.Point(6, 22);
            this.textBox_ConnectionTimedOut.Name = "textBox_ConnectionTimedOut";
            this.textBox_ConnectionTimedOut.Size = new System.Drawing.Size(53, 26);
            this.textBox_ConnectionTimedOut.TabIndex = 8;
            this.textBox_ConnectionTimedOut.Text = "300";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox_ServerRecord);
            this.groupBox3.Controls.Add(this.checkBox_ServerPause);
            this.groupBox3.Controls.Add(this.button_ClearServer);
            this.groupBox3.Controls.Add(this.checkBox_StopLogging);
            this.groupBox3.Controls.Add(this.TextBox_Server);
            this.groupBox3.Controls.Add(this.checkBox_RecordGeneral);
            this.groupBox3.Controls.Add(this.PauseCheck);
            this.groupBox3.Controls.Add(this.Clear_btn);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(282, 65);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(936, 611);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Server Console";
            // 
            // checkBox_StopLogging
            // 
            this.checkBox_StopLogging.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_StopLogging.AutoSize = true;
            this.checkBox_StopLogging.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_StopLogging.Location = new System.Drawing.Point(305, 629);
            this.checkBox_StopLogging.Name = "checkBox_StopLogging";
            this.checkBox_StopLogging.Size = new System.Drawing.Size(106, 26);
            this.checkBox_StopLogging.TabIndex = 8;
            this.checkBox_StopLogging.Text = "Stop Printing";
            this.checkBox_StopLogging.UseVisualStyleBackColor = true;
            // 
            // TextBox_Server
            // 
            this.TextBox_Server.BackColor = System.Drawing.Color.LightGray;
            this.TextBox_Server.EnableAutoDragDrop = true;
            this.TextBox_Server.Location = new System.Drawing.Point(7, 20);
            this.TextBox_Server.Name = "TextBox_Server";
            this.TextBox_Server.Size = new System.Drawing.Size(923, 552);
            this.TextBox_Server.TabIndex = 0;
            this.TextBox_Server.Text = "";
            this.TextBox_Server.TextChanged += new System.EventHandler(this.RichTextBox1_TextChanged);
            // 
            // checkBox_RecordGeneral
            // 
            this.checkBox_RecordGeneral.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_RecordGeneral.AutoSize = true;
            this.checkBox_RecordGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_RecordGeneral.Location = new System.Drawing.Point(417, 629);
            this.checkBox_RecordGeneral.Name = "checkBox_RecordGeneral";
            this.checkBox_RecordGeneral.Size = new System.Drawing.Size(99, 26);
            this.checkBox_RecordGeneral.TabIndex = 7;
            this.checkBox_RecordGeneral.Text = "Record Log";
            this.checkBox_RecordGeneral.UseVisualStyleBackColor = true;
            this.checkBox_RecordGeneral.CheckedChanged += new System.EventHandler(this.CheckBox_RecordGeneral_CheckedChanged);
            // 
            // PauseCheck
            // 
            this.PauseCheck.Appearance = System.Windows.Forms.Appearance.Button;
            this.PauseCheck.AutoSize = true;
            this.PauseCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PauseCheck.Location = new System.Drawing.Point(522, 629);
            this.PauseCheck.Name = "PauseCheck";
            this.PauseCheck.Size = new System.Drawing.Size(62, 26);
            this.PauseCheck.TabIndex = 5;
            this.PauseCheck.Text = "Pause";
            this.PauseCheck.UseVisualStyleBackColor = true;
            // 
            // Clear_btn
            // 
            this.Clear_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clear_btn.Location = new System.Drawing.Point(590, 629);
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.Size = new System.Drawing.Size(62, 26);
            this.Clear_btn.TabIndex = 6;
            this.Clear_btn.Text = "Clear";
            this.Clear_btn.UseVisualStyleBackColor = true;
            // 
            // tabPage_ClientTCP
            // 
            this.tabPage_ClientTCP.Controls.Add(this.button_Ping);
            this.tabPage_ClientTCP.Controls.Add(this.label10);
            this.tabPage_ClientTCP.Controls.Add(this.label9);
            this.tabPage_ClientTCP.Controls.Add(this.button_ClearRx);
            this.tabPage_ClientTCP.Controls.Add(this.richTextBox_ClientRx);
            this.tabPage_ClientTCP.Controls.Add(this.button43);
            this.tabPage_ClientTCP.Controls.Add(this.button_ClientClose);
            this.tabPage_ClientTCP.Controls.Add(this.button_ClientConnect);
            this.tabPage_ClientTCP.Controls.Add(this.button3);
            this.tabPage_ClientTCP.Controls.Add(this.richTextBox_ClientTx);
            this.tabPage_ClientTCP.Controls.Add(this.textBox_ClientPort);
            this.tabPage_ClientTCP.Controls.Add(this.textBox_ClientIP);
            this.tabPage_ClientTCP.Controls.Add(this.label8);
            this.tabPage_ClientTCP.Controls.Add(this.label7);
            this.tabPage_ClientTCP.Location = new System.Drawing.Point(4, 27);
            this.tabPage_ClientTCP.Name = "tabPage_ClientTCP";
            this.tabPage_ClientTCP.Size = new System.Drawing.Size(1547, 682);
            this.tabPage_ClientTCP.TabIndex = 9;
            this.tabPage_ClientTCP.Text = "Client TCP";
            this.tabPage_ClientTCP.UseVisualStyleBackColor = true;
            // 
            // button_Ping
            // 
            this.button_Ping.Location = new System.Drawing.Point(195, 78);
            this.button_Ping.Name = "button_Ping";
            this.button_Ping.Size = new System.Drawing.Size(75, 23);
            this.button_Ping.TabIndex = 14;
            this.button_Ping.Text = "Ping";
            this.button_Ping.UseVisualStyleBackColor = true;
            this.button_Ping.Click += new System.EventHandler(this.button72_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(599, 303);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(150, 23);
            this.label10.TabIndex = 13;
            this.label10.Text = "Rx - Data Received";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(599, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 23);
            this.label9.TabIndex = 12;
            this.label9.Text = "Tx - Data Send";
            // 
            // button_ClearRx
            // 
            this.button_ClearRx.Location = new System.Drawing.Point(1186, 333);
            this.button_ClearRx.Name = "button_ClearRx";
            this.button_ClearRx.Size = new System.Drawing.Size(75, 23);
            this.button_ClearRx.TabIndex = 11;
            this.button_ClearRx.Text = "Clear Rx";
            this.button_ClearRx.UseVisualStyleBackColor = true;
            this.button_ClearRx.Click += new System.EventHandler(this.Button_ClearRx_Click);
            // 
            // richTextBox_ClientRx
            // 
            this.richTextBox_ClientRx.Location = new System.Drawing.Point(34, 334);
            this.richTextBox_ClientRx.Name = "richTextBox_ClientRx";
            this.richTextBox_ClientRx.ReadOnly = true;
            this.richTextBox_ClientRx.Size = new System.Drawing.Size(1146, 167);
            this.richTextBox_ClientRx.TabIndex = 9;
            this.richTextBox_ClientRx.Text = "";
            // 
            // button43
            // 
            this.button43.Location = new System.Drawing.Point(1187, 145);
            this.button43.Name = "button43";
            this.button43.Size = new System.Drawing.Size(75, 24);
            this.button43.TabIndex = 8;
            this.button43.Text = "Clear Tx";
            this.button43.UseVisualStyleBackColor = true;
            this.button43.Click += new System.EventHandler(this.Button43_Click_1);
            // 
            // button_ClientClose
            // 
            this.button_ClientClose.Location = new System.Drawing.Point(115, 79);
            this.button_ClientClose.Name = "button_ClientClose";
            this.button_ClientClose.Size = new System.Drawing.Size(75, 23);
            this.button_ClientClose.TabIndex = 7;
            this.button_ClientClose.Text = "Close";
            this.button_ClientClose.UseVisualStyleBackColor = true;
            this.button_ClientClose.Click += new System.EventHandler(this.Button42_Click_1);
            // 
            // button_ClientConnect
            // 
            this.button_ClientConnect.Location = new System.Drawing.Point(34, 80);
            this.button_ClientConnect.Name = "button_ClientConnect";
            this.button_ClientConnect.Size = new System.Drawing.Size(75, 23);
            this.button_ClientConnect.TabIndex = 6;
            this.button_ClientConnect.Text = "Connect";
            this.button_ClientConnect.UseVisualStyleBackColor = true;
            this.button_ClientConnect.Click += new System.EventHandler(this.Button_ClientConnect_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1187, 116);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Send";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click_4);
            // 
            // richTextBox_ClientTx
            // 
            this.richTextBox_ClientTx.Location = new System.Drawing.Point(34, 117);
            this.richTextBox_ClientTx.Name = "richTextBox_ClientTx";
            this.richTextBox_ClientTx.Size = new System.Drawing.Size(1148, 167);
            this.richTextBox_ClientTx.TabIndex = 4;
            this.richTextBox_ClientTx.Text = "Send Data to Server";
            // 
            // textBox_ClientPort
            // 
            this.textBox_ClientPort.Location = new System.Drawing.Point(124, 47);
            this.textBox_ClientPort.Name = "textBox_ClientPort";
            this.textBox_ClientPort.Size = new System.Drawing.Size(100, 26);
            this.textBox_ClientPort.TabIndex = 3;
            this.textBox_ClientPort.Text = "7000";
            // 
            // textBox_ClientIP
            // 
            this.textBox_ClientIP.Location = new System.Drawing.Point(124, 17);
            this.textBox_ClientIP.Name = "textBox_ClientIP";
            this.textBox_ClientIP.Size = new System.Drawing.Size(100, 26);
            this.textBox_ClientIP.TabIndex = 2;
            this.textBox_ClientIP.Text = "10.0.1.10";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(30, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 23);
            this.label8.TabIndex = 1;
            this.label8.Text = "Port";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(30, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 23);
            this.label7.TabIndex = 0;
            this.label7.Text = "Host or IP";
            // 
            // tabPage_GenericFrame
            // 
            this.tabPage_GenericFrame.Controls.Add(this.button52);
            this.tabPage_GenericFrame.Controls.Add(this.groupBox31);
            this.tabPage_GenericFrame.Controls.Add(this.groupBox_clientTX);
            this.tabPage_GenericFrame.Location = new System.Drawing.Point(4, 22);
            this.tabPage_GenericFrame.Name = "tabPage_GenericFrame";
            this.tabPage_GenericFrame.Size = new System.Drawing.Size(1547, 687);
            this.tabPage_GenericFrame.TabIndex = 10;
            this.tabPage_GenericFrame.Text = "Generic Kratos frame";
            this.tabPage_GenericFrame.UseVisualStyleBackColor = true;
            this.tabPage_GenericFrame.Enter += new System.EventHandler(this.tabPage_GenericFrame_Enter);
            this.tabPage_GenericFrame.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tabPage_GenericFrame_PreviewKeyDown);
            // 
            // button52
            // 
            this.button52.Location = new System.Drawing.Point(14, 178);
            this.button52.Name = "button52";
            this.button52.Size = new System.Drawing.Size(75, 23);
            this.button52.TabIndex = 15;
            this.button52.Text = "Clear";
            this.button52.UseVisualStyleBackColor = true;
            this.button52.Click += new System.EventHandler(this.button52_Click);
            // 
            // groupBox31
            // 
            this.groupBox31.Controls.Add(this.label24);
            this.groupBox31.Controls.Add(this.textBox_RxClientDataLength);
            this.groupBox31.Controls.Add(this.label23);
            this.groupBox31.Controls.Add(this.label18);
            this.groupBox31.Controls.Add(this.label13);
            this.groupBox31.Controls.Add(this.textBox_RxClientPreamble);
            this.groupBox31.Controls.Add(this.textBox_RxClientOpcode);
            this.groupBox31.Controls.Add(this.textBox_RxClientData);
            this.groupBox31.Controls.Add(this.label15);
            this.groupBox31.Controls.Add(this.label16);
            this.groupBox31.Location = new System.Drawing.Point(434, 14);
            this.groupBox31.Name = "groupBox31";
            this.groupBox31.Size = new System.Drawing.Size(372, 157);
            this.groupBox31.TabIndex = 14;
            this.groupBox31.TabStop = false;
            this.groupBox31.Text = "Data received";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label24.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Maroon;
            this.label24.Location = new System.Drawing.Point(203, 126);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(65, 21);
            this.label24.TabIndex = 11;
            this.label24.Text = "Decimal";
            // 
            // textBox_RxClientDataLength
            // 
            this.textBox_RxClientDataLength.Location = new System.Drawing.Point(97, 125);
            this.textBox_RxClientDataLength.MaxLength = 4;
            this.textBox_RxClientDataLength.Name = "textBox_RxClientDataLength";
            this.textBox_RxClientDataLength.ReadOnly = true;
            this.textBox_RxClientDataLength.Size = new System.Drawing.Size(100, 26);
            this.textBox_RxClientDataLength.TabIndex = 10;
            this.textBox_RxClientDataLength.TabStop = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(10, 129);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(81, 18);
            this.label23.TabIndex = 9;
            this.label23.Text = "Data Length";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Maroon;
            this.label18.Location = new System.Drawing.Point(269, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(97, 21);
            this.label18.TabIndex = 8;
            this.label18.Text = "Hexadecimal";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 18);
            this.label13.TabIndex = 4;
            this.label13.Text = "Preamble";
            // 
            // textBox_RxClientPreamble
            // 
            this.textBox_RxClientPreamble.Location = new System.Drawing.Point(97, 18);
            this.textBox_RxClientPreamble.MaxLength = 4;
            this.textBox_RxClientPreamble.Name = "textBox_RxClientPreamble";
            this.textBox_RxClientPreamble.ReadOnly = true;
            this.textBox_RxClientPreamble.Size = new System.Drawing.Size(100, 26);
            this.textBox_RxClientPreamble.TabIndex = 0;
            this.textBox_RxClientPreamble.TabStop = false;
            this.textBox_RxClientPreamble.TextChanged += new System.EventHandler(this.textBox_RxClientPreamble_TextChanged);
            // 
            // textBox_RxClientOpcode
            // 
            this.textBox_RxClientOpcode.Location = new System.Drawing.Point(97, 54);
            this.textBox_RxClientOpcode.MaxLength = 4;
            this.textBox_RxClientOpcode.Name = "textBox_RxClientOpcode";
            this.textBox_RxClientOpcode.ReadOnly = true;
            this.textBox_RxClientOpcode.Size = new System.Drawing.Size(100, 26);
            this.textBox_RxClientOpcode.TabIndex = 1;
            this.textBox_RxClientOpcode.TabStop = false;
            // 
            // textBox_RxClientData
            // 
            this.textBox_RxClientData.Location = new System.Drawing.Point(97, 88);
            this.textBox_RxClientData.Name = "textBox_RxClientData";
            this.textBox_RxClientData.ReadOnly = true;
            this.textBox_RxClientData.Size = new System.Drawing.Size(225, 26);
            this.textBox_RxClientData.TabIndex = 2;
            this.textBox_RxClientData.TabStop = false;
            this.textBox_RxClientData.TextChanged += new System.EventHandler(this.textBox_RxClientData_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 18);
            this.label15.TabIndex = 5;
            this.label15.Text = "Opcode";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 91);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(36, 18);
            this.label16.TabIndex = 6;
            this.label16.Text = "Data";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // groupBox_clientTX
            // 
            this.groupBox_clientTX.Controls.Add(this.label17);
            this.groupBox_clientTX.Controls.Add(this.label4);
            this.groupBox_clientTX.Controls.Add(this.textBox_Preamble);
            this.groupBox_clientTX.Controls.Add(this.button_SendProtocol);
            this.groupBox_clientTX.Controls.Add(this.textBox_Opcode);
            this.groupBox_clientTX.Controls.Add(this.textBox_data);
            this.groupBox_clientTX.Controls.Add(this.label6);
            this.groupBox_clientTX.Controls.Add(this.label11);
            this.groupBox_clientTX.Location = new System.Drawing.Point(14, 12);
            this.groupBox_clientTX.Name = "groupBox_clientTX";
            this.groupBox_clientTX.Size = new System.Drawing.Size(372, 159);
            this.groupBox_clientTX.TabIndex = 13;
            this.groupBox_clientTX.TabStop = false;
            this.groupBox_clientTX.Text = "Send Data";
            this.groupBox_clientTX.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.groupBox_clientTX_PreviewKeyDown);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Maroon;
            this.label17.Location = new System.Drawing.Point(269, 13);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(97, 21);
            this.label17.TabIndex = 7;
            this.label17.Text = "Hexadecimal";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Preamble";
            // 
            // textBox_Preamble
            // 
            this.textBox_Preamble.Location = new System.Drawing.Point(97, 18);
            this.textBox_Preamble.MaxLength = 5;
            this.textBox_Preamble.Name = "textBox_Preamble";
            this.textBox_Preamble.Size = new System.Drawing.Size(100, 26);
            this.textBox_Preamble.TabIndex = 0;
            this.textBox_Preamble.Text = "5300";
            this.textBox_Preamble.TextChanged += new System.EventHandler(this.textBox_Preamble_TextChanged);
            this.textBox_Preamble.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Preamble_KeyDown);
            // 
            // button_SendProtocol
            // 
            this.button_SendProtocol.Location = new System.Drawing.Point(6, 125);
            this.button_SendProtocol.Name = "button_SendProtocol";
            this.button_SendProtocol.Size = new System.Drawing.Size(91, 23);
            this.button_SendProtocol.TabIndex = 3;
            this.button_SendProtocol.TabStop = false;
            this.button_SendProtocol.Text = "Send";
            this.button_SendProtocol.UseVisualStyleBackColor = true;
            this.button_SendProtocol.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // textBox_Opcode
            // 
            this.textBox_Opcode.Location = new System.Drawing.Point(97, 54);
            this.textBox_Opcode.MaxLength = 5;
            this.textBox_Opcode.Name = "textBox_Opcode";
            this.textBox_Opcode.Size = new System.Drawing.Size(100, 26);
            this.textBox_Opcode.TabIndex = 1;
            this.textBox_Opcode.Text = "70 00";
            this.textBox_Opcode.TextChanged += new System.EventHandler(this.textBox_Opcode_TextChanged);
            this.textBox_Opcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Opcode_KeyDown);
            // 
            // textBox_data
            // 
            this.textBox_data.Location = new System.Drawing.Point(97, 88);
            this.textBox_data.Name = "textBox_data";
            this.textBox_data.Size = new System.Drawing.Size(225, 26);
            this.textBox_data.TabIndex = 2;
            this.textBox_data.Text = "04 00 00 00";
            this.textBox_data.TextChanged += new System.EventHandler(this.textBox_data_TextChanged);
            this.textBox_data.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_data_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "Opcode";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 91);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 18);
            this.label11.TabIndex = 6;
            this.label11.Text = "Data";
            // 
            // tabPage_MiniAda
            // 
            this.tabPage_MiniAda.Controls.Add(this.groupBox40);
            this.tabPage_MiniAda.Controls.Add(this.groupBox32);
            this.tabPage_MiniAda.Location = new System.Drawing.Point(4, 27);
            this.tabPage_MiniAda.Name = "tabPage_MiniAda";
            this.tabPage_MiniAda.Size = new System.Drawing.Size(1547, 682);
            this.tabPage_MiniAda.TabIndex = 11;
            this.tabPage_MiniAda.Text = "MiniAda";
            this.tabPage_MiniAda.UseVisualStyleBackColor = true;
            // 
            // groupBox40
            // 
            this.groupBox40.Controls.Add(this.tabControl_MiniAda);
            this.groupBox40.Location = new System.Drawing.Point(10, 8);
            this.groupBox40.Name = "groupBox40";
            this.groupBox40.Size = new System.Drawing.Size(969, 663);
            this.groupBox40.TabIndex = 11;
            this.groupBox40.TabStop = false;
            this.groupBox40.Text = "Commands for MiniAda (press right click for help)";
            // 
            // tabControl_MiniAda
            // 
            this.tabControl_MiniAda.Controls.Add(this.tabPage1);
            this.tabControl_MiniAda.Controls.Add(this.tabPage2);
            this.tabControl_MiniAda.Controls.Add(this.tabPage6);
            this.tabControl_MiniAda.Controls.Add(this.tabPage3);
            this.tabControl_MiniAda.Controls.Add(this.tabPage7);
            this.tabControl_MiniAda.Controls.Add(this.tabPage8);
            this.tabControl_MiniAda.Controls.Add(this.tabPage9);
            this.tabControl_MiniAda.Location = new System.Drawing.Point(6, 23);
            this.tabControl_MiniAda.Name = "tabControl_MiniAda";
            this.tabControl_MiniAda.SelectedIndex = 0;
            this.tabControl_MiniAda.Size = new System.Drawing.Size(957, 635);
            this.tabControl_MiniAda.TabIndex = 21;
            this.tabControl_MiniAda.SelectedIndexChanged += new System.EventHandler(this.tabControl_MiniAda_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label31);
            this.tabPage1.Controls.Add(this.textBox_SetPSUCard);
            this.tabPage1.Controls.Add(this.button57);
            this.tabPage1.Controls.Add(this.button58);
            this.tabPage1.Controls.Add(this.textBox_SetRFCardInformation);
            this.tabPage1.Controls.Add(this.button55);
            this.tabPage1.Controls.Add(this.button56);
            this.tabPage1.Controls.Add(this.textBox_SetCoreCardInformation);
            this.tabPage1.Controls.Add(this.button54);
            this.tabPage1.Controls.Add(this.button_GetSoftwareVersion);
            this.tabPage1.Controls.Add(this.button53);
            this.tabPage1.Controls.Add(this.button45);
            this.tabPage1.Controls.Add(this.textBox_SystemIdentify);
            this.tabPage1.Controls.Add(this.button46);
            this.tabPage1.Controls.Add(this.button51);
            this.tabPage1.Controls.Add(this.button47);
            this.tabPage1.Controls.Add(this.button50);
            this.tabPage1.Controls.Add(this.textBox_LogLevel);
            this.tabPage1.Controls.Add(this.button49);
            this.tabPage1.Controls.Add(this.button48);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(949, 604);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Standard";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label31.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.Maroon;
            this.label31.Location = new System.Drawing.Point(291, 125);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(32, 21);
            this.label31.TabIndex = 32;
            this.label31.Text = "0-7";
            // 
            // textBox_SetPSUCard
            // 
            this.textBox_SetPSUCard.Location = new System.Drawing.Point(256, 565);
            this.textBox_SetPSUCard.MaxLength = 121;
            this.textBox_SetPSUCard.Name = "textBox_SetPSUCard";
            this.textBox_SetPSUCard.Size = new System.Drawing.Size(216, 26);
            this.textBox_SetPSUCard.TabIndex = 28;
            // 
            // button57
            // 
            this.button57.Location = new System.Drawing.Point(6, 568);
            this.button57.Name = "button57";
            this.button57.Size = new System.Drawing.Size(244, 23);
            this.button57.TabIndex = 27;
            this.button57.Text = "Set PSU Card Information";
            this.button57.UseVisualStyleBackColor = true;
            this.button57.Click += new System.EventHandler(this.button57_Click);
            // 
            // button58
            // 
            this.button58.Location = new System.Drawing.Point(6, 537);
            this.button58.Name = "button58";
            this.button58.Size = new System.Drawing.Size(244, 23);
            this.button58.TabIndex = 26;
            this.button58.Text = "Get PSU Card Information";
            this.button58.UseVisualStyleBackColor = true;
            this.button58.Click += new System.EventHandler(this.button58_Click);
            // 
            // textBox_SetRFCardInformation
            // 
            this.textBox_SetRFCardInformation.Location = new System.Drawing.Point(256, 470);
            this.textBox_SetRFCardInformation.MaxLength = 121;
            this.textBox_SetRFCardInformation.Name = "textBox_SetRFCardInformation";
            this.textBox_SetRFCardInformation.Size = new System.Drawing.Size(216, 26);
            this.textBox_SetRFCardInformation.TabIndex = 25;
            // 
            // button55
            // 
            this.button55.Location = new System.Drawing.Point(6, 473);
            this.button55.Name = "button55";
            this.button55.Size = new System.Drawing.Size(244, 23);
            this.button55.TabIndex = 24;
            this.button55.Text = "Set RF Card Information";
            this.button55.UseVisualStyleBackColor = true;
            this.button55.Click += new System.EventHandler(this.button55_Click);
            // 
            // button56
            // 
            this.button56.Location = new System.Drawing.Point(6, 442);
            this.button56.Name = "button56";
            this.button56.Size = new System.Drawing.Size(244, 23);
            this.button56.TabIndex = 23;
            this.button56.Text = "Get RF Card Information";
            this.button56.UseVisualStyleBackColor = true;
            this.button56.Click += new System.EventHandler(this.button56_Click);
            // 
            // textBox_SetCoreCardInformation
            // 
            this.textBox_SetCoreCardInformation.Location = new System.Drawing.Point(256, 366);
            this.textBox_SetCoreCardInformation.MaxLength = 121;
            this.textBox_SetCoreCardInformation.Name = "textBox_SetCoreCardInformation";
            this.textBox_SetCoreCardInformation.Size = new System.Drawing.Size(216, 26);
            this.textBox_SetCoreCardInformation.TabIndex = 22;
            // 
            // button54
            // 
            this.button54.Location = new System.Drawing.Point(6, 369);
            this.button54.Name = "button54";
            this.button54.Size = new System.Drawing.Size(244, 23);
            this.button54.TabIndex = 21;
            this.button54.Text = "Set Core Card Information";
            this.button54.UseVisualStyleBackColor = true;
            this.button54.Click += new System.EventHandler(this.button54_Click);
            // 
            // button_GetSoftwareVersion
            // 
            this.button_GetSoftwareVersion.Location = new System.Drawing.Point(6, 6);
            this.button_GetSoftwareVersion.Name = "button_GetSoftwareVersion";
            this.button_GetSoftwareVersion.Size = new System.Drawing.Size(244, 23);
            this.button_GetSoftwareVersion.TabIndex = 10;
            this.button_GetSoftwareVersion.Text = "Get Software version";
            this.button_GetSoftwareVersion.UseVisualStyleBackColor = true;
            this.button_GetSoftwareVersion.Click += new System.EventHandler(this.button_GetSoftwareVersion_Click);
            // 
            // button53
            // 
            this.button53.Location = new System.Drawing.Point(6, 338);
            this.button53.Name = "button53";
            this.button53.Size = new System.Drawing.Size(244, 23);
            this.button53.TabIndex = 20;
            this.button53.Text = "Get Core Card Information";
            this.button53.UseVisualStyleBackColor = true;
            this.button53.Click += new System.EventHandler(this.button53_Click);
            // 
            // button45
            // 
            this.button45.Location = new System.Drawing.Point(6, 40);
            this.button45.Name = "button45";
            this.button45.Size = new System.Drawing.Size(244, 23);
            this.button45.TabIndex = 11;
            this.button45.Text = "Get Firmware version";
            this.button45.UseVisualStyleBackColor = true;
            this.button45.Click += new System.EventHandler(this.button45_Click);
            // 
            // textBox_SystemIdentify
            // 
            this.textBox_SystemIdentify.Location = new System.Drawing.Point(258, 280);
            this.textBox_SystemIdentify.MaxLength = 121;
            this.textBox_SystemIdentify.Name = "textBox_SystemIdentify";
            this.textBox_SystemIdentify.Size = new System.Drawing.Size(216, 26);
            this.textBox_SystemIdentify.TabIndex = 19;
            // 
            // button46
            // 
            this.button46.Location = new System.Drawing.Point(6, 83);
            this.button46.Name = "button46";
            this.button46.Size = new System.Drawing.Size(244, 23);
            this.button46.TabIndex = 12;
            this.button46.Text = "Get Serial Number";
            this.button46.UseVisualStyleBackColor = true;
            this.button46.Click += new System.EventHandler(this.button46_Click);
            // 
            // button51
            // 
            this.button51.Location = new System.Drawing.Point(6, 281);
            this.button51.Name = "button51";
            this.button51.Size = new System.Drawing.Size(244, 23);
            this.button51.TabIndex = 18;
            this.button51.Text = "Set System identity Information";
            this.button51.UseVisualStyleBackColor = true;
            this.button51.Click += new System.EventHandler(this.button51_Click);
            // 
            // button47
            // 
            this.button47.Location = new System.Drawing.Point(3, 129);
            this.button47.Name = "button47";
            this.button47.Size = new System.Drawing.Size(244, 23);
            this.button47.TabIndex = 13;
            this.button47.Text = "Set Log Level";
            this.button47.UseVisualStyleBackColor = true;
            this.button47.Click += new System.EventHandler(this.button47_Click);
            // 
            // button50
            // 
            this.button50.Location = new System.Drawing.Point(6, 251);
            this.button50.Name = "button50";
            this.button50.Size = new System.Drawing.Size(244, 23);
            this.button50.TabIndex = 17;
            this.button50.Text = "Get System identity Information";
            this.button50.UseVisualStyleBackColor = true;
            this.button50.Click += new System.EventHandler(this.button50_Click);
            // 
            // textBox_LogLevel
            // 
            this.textBox_LogLevel.Location = new System.Drawing.Point(255, 123);
            this.textBox_LogLevel.MaxLength = 1;
            this.textBox_LogLevel.Name = "textBox_LogLevel";
            this.textBox_LogLevel.Size = new System.Drawing.Size(27, 26);
            this.textBox_LogLevel.TabIndex = 14;
            this.textBox_LogLevel.Text = "7";
            this.textBox_LogLevel.TextChanged += new System.EventHandler(this.textBox_LogLevel_TextChanged);
            // 
            // button49
            // 
            this.button49.Location = new System.Drawing.Point(3, 211);
            this.button49.Name = "button49";
            this.button49.Size = new System.Drawing.Size(244, 23);
            this.button49.TabIndex = 16;
            this.button49.Text = "Get system type";
            this.button49.UseVisualStyleBackColor = true;
            this.button49.Click += new System.EventHandler(this.button49_Click);
            // 
            // button48
            // 
            this.button48.Location = new System.Drawing.Point(6, 168);
            this.button48.Name = "button48";
            this.button48.Size = new System.Drawing.Size(244, 23);
            this.button48.TabIndex = 15;
            this.button48.Text = "Is System busy?";
            this.button48.UseVisualStyleBackColor = true;
            this.button48.Click += new System.EventHandler(this.button48_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox_LoadDatainFlash);
            this.tabPage2.Controls.Add(this.button73);
            this.tabPage2.Controls.Add(this.textBox_StoreDatainFlash);
            this.tabPage2.Controls.Add(this.button72);
            this.tabPage2.Controls.Add(this.label28);
            this.tabPage2.Controls.Add(this.textBox_SetTCXOTrim);
            this.tabPage2.Controls.Add(this.button69);
            this.tabPage2.Controls.Add(this.label27);
            this.tabPage2.Controls.Add(this.textBox_TCXOOnOff);
            this.tabPage2.Controls.Add(this.button68);
            this.tabPage2.Controls.Add(this.button67);
            this.tabPage2.Controls.Add(this.label26);
            this.tabPage2.Controls.Add(this.textBox_SetSystemOutputPower);
            this.tabPage2.Controls.Add(this.button66);
            this.tabPage2.Controls.Add(this.button65);
            this.tabPage2.Controls.Add(this.label25);
            this.tabPage2.Controls.Add(this.textBox_SetSyestemState);
            this.tabPage2.Controls.Add(this.button64);
            this.tabPage2.Controls.Add(this.button63);
            this.tabPage2.Controls.Add(this.label22);
            this.tabPage2.Controls.Add(this.textBox_GetTxAD936X);
            this.tabPage2.Controls.Add(this.button62);
            this.tabPage2.Controls.Add(this.label21);
            this.tabPage2.Controls.Add(this.textBox_SetTxAD936X);
            this.tabPage2.Controls.Add(this.button61);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.textBox_SetSynthesizerL2);
            this.tabPage2.Controls.Add(this.button60);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.textBox_SetSynthesizerL1);
            this.tabPage2.Controls.Add(this.button59);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(949, 604);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Master";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox_LoadDatainFlash
            // 
            this.textBox_LoadDatainFlash.Location = new System.Drawing.Point(257, 563);
            this.textBox_LoadDatainFlash.MaxLength = 30;
            this.textBox_LoadDatainFlash.Name = "textBox_LoadDatainFlash";
            this.textBox_LoadDatainFlash.Size = new System.Drawing.Size(156, 26);
            this.textBox_LoadDatainFlash.TabIndex = 60;
            this.textBox_LoadDatainFlash.Text = "00000000 00000000";
            this.textBox_LoadDatainFlash.TextChanged += new System.EventHandler(this.textBox_LoadDatainFlash_TextChanged);
            // 
            // button73
            // 
            this.button73.Location = new System.Drawing.Point(8, 566);
            this.button73.Name = "button73";
            this.button73.Size = new System.Drawing.Size(244, 23);
            this.button73.TabIndex = 59;
            this.button73.Text = "Load data from Flash by address ";
            this.button73.UseVisualStyleBackColor = true;
            this.button73.Click += new System.EventHandler(this.button73_Click);
            this.button73.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button73_MouseDown);
            // 
            // textBox_StoreDatainFlash
            // 
            this.textBox_StoreDatainFlash.Location = new System.Drawing.Point(257, 530);
            this.textBox_StoreDatainFlash.MaxLength = 30;
            this.textBox_StoreDatainFlash.Name = "textBox_StoreDatainFlash";
            this.textBox_StoreDatainFlash.Size = new System.Drawing.Size(286, 26);
            this.textBox_StoreDatainFlash.TabIndex = 57;
            this.textBox_StoreDatainFlash.Text = "00000000 00000000 00000000";
            this.textBox_StoreDatainFlash.TextChanged += new System.EventHandler(this.textBox_StoreDatainFlash_TextChanged);
            // 
            // button72
            // 
            this.button72.Location = new System.Drawing.Point(8, 533);
            this.button72.Name = "button72";
            this.button72.Size = new System.Drawing.Size(244, 23);
            this.button72.TabIndex = 56;
            this.button72.Text = "Store data in Flash  ";
            this.button72.UseVisualStyleBackColor = true;
            this.button72.Click += new System.EventHandler(this.button72_Click_1);
            this.button72.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button72_MouseDown);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label28.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Maroon;
            this.label28.Location = new System.Drawing.Point(390, 468);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(150, 21);
            this.label28.TabIndex = 55;
            this.label28.Text = "Hexadecimal 4 bytes";
            // 
            // textBox_SetTCXOTrim
            // 
            this.textBox_SetTCXOTrim.Location = new System.Drawing.Point(254, 469);
            this.textBox_SetTCXOTrim.MaxLength = 30;
            this.textBox_SetTCXOTrim.Name = "textBox_SetTCXOTrim";
            this.textBox_SetTCXOTrim.Size = new System.Drawing.Size(129, 26);
            this.textBox_SetTCXOTrim.TabIndex = 54;
            this.textBox_SetTCXOTrim.Text = "00 00 00 00";
            this.textBox_SetTCXOTrim.TextChanged += new System.EventHandler(this.textBox_SetTCXOTrim_TextChanged);
            // 
            // button69
            // 
            this.button69.Location = new System.Drawing.Point(5, 472);
            this.button69.Name = "button69";
            this.button69.Size = new System.Drawing.Size(244, 23);
            this.button69.TabIndex = 53;
            this.button69.Text = "Set TCXO Trim ";
            this.button69.UseVisualStyleBackColor = true;
            this.button69.Click += new System.EventHandler(this.button69_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label27.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Maroon;
            this.label27.Location = new System.Drawing.Point(391, 435);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(150, 21);
            this.label27.TabIndex = 52;
            this.label27.Text = "Hexadecimal 1 bytes";
            // 
            // textBox_TCXOOnOff
            // 
            this.textBox_TCXOOnOff.Location = new System.Drawing.Point(255, 436);
            this.textBox_TCXOOnOff.MaxLength = 30;
            this.textBox_TCXOOnOff.Name = "textBox_TCXOOnOff";
            this.textBox_TCXOOnOff.Size = new System.Drawing.Size(130, 26);
            this.textBox_TCXOOnOff.TabIndex = 51;
            this.textBox_TCXOOnOff.Text = "00";
            this.textBox_TCXOOnOff.TextChanged += new System.EventHandler(this.textBox_TCXOOnOff_TextChanged);
            // 
            // button68
            // 
            this.button68.Location = new System.Drawing.Point(5, 439);
            this.button68.Name = "button68";
            this.button68.Size = new System.Drawing.Size(244, 23);
            this.button68.TabIndex = 50;
            this.button68.Text = "Switch TCXO on/off ";
            this.button68.UseVisualStyleBackColor = true;
            this.button68.Click += new System.EventHandler(this.button68_Click);
            // 
            // button67
            // 
            this.button67.Location = new System.Drawing.Point(7, 381);
            this.button67.Name = "button67";
            this.button67.Size = new System.Drawing.Size(244, 23);
            this.button67.TabIndex = 49;
            this.button67.Text = "Get system output power ";
            this.button67.UseVisualStyleBackColor = true;
            this.button67.Click += new System.EventHandler(this.button67_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label26.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Maroon;
            this.label26.Location = new System.Drawing.Point(394, 348);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(150, 21);
            this.label26.TabIndex = 48;
            this.label26.Text = "Hexadecimal 5 bytes";
            // 
            // textBox_SetSystemOutputPower
            // 
            this.textBox_SetSystemOutputPower.Location = new System.Drawing.Point(258, 349);
            this.textBox_SetSystemOutputPower.MaxLength = 30;
            this.textBox_SetSystemOutputPower.Name = "textBox_SetSystemOutputPower";
            this.textBox_SetSystemOutputPower.Size = new System.Drawing.Size(130, 26);
            this.textBox_SetSystemOutputPower.TabIndex = 47;
            this.textBox_SetSystemOutputPower.Text = "00 00 00 00 00";
            this.toolTip1.SetToolTip(this.textBox_SetSystemOutputPower, "1 byte – band type: 0x00 - L1, 0x01 - L2");
            this.textBox_SetSystemOutputPower.TextChanged += new System.EventHandler(this.textBox_SetSystemOutputPower_TextChanged);
            // 
            // button66
            // 
            this.button66.Location = new System.Drawing.Point(8, 350);
            this.button66.Name = "button66";
            this.button66.Size = new System.Drawing.Size(244, 23);
            this.button66.TabIndex = 46;
            this.button66.Text = "Set system output power ";
            this.button66.UseVisualStyleBackColor = true;
            this.button66.Click += new System.EventHandler(this.button66_Click);
            this.button66.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button66_MouseDown);
            // 
            // button65
            // 
            this.button65.Location = new System.Drawing.Point(8, 295);
            this.button65.Name = "button65";
            this.button65.Size = new System.Drawing.Size(244, 23);
            this.button65.TabIndex = 45;
            this.button65.Text = "Get system state ";
            this.button65.UseVisualStyleBackColor = true;
            this.button65.Click += new System.EventHandler(this.button65_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label25.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Maroon;
            this.label25.Location = new System.Drawing.Point(393, 264);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(150, 21);
            this.label25.TabIndex = 44;
            this.label25.Text = "Hexadecimal 1 bytes";
            // 
            // textBox_SetSyestemState
            // 
            this.textBox_SetSyestemState.Location = new System.Drawing.Point(257, 265);
            this.textBox_SetSyestemState.MaxLength = 30;
            this.textBox_SetSyestemState.Name = "textBox_SetSyestemState";
            this.textBox_SetSyestemState.Size = new System.Drawing.Size(130, 26);
            this.textBox_SetSyestemState.TabIndex = 43;
            this.textBox_SetSyestemState.Text = "00";
            this.textBox_SetSyestemState.TextChanged += new System.EventHandler(this.textBox_SetSyestemState_TextChanged);
            // 
            // button64
            // 
            this.button64.Location = new System.Drawing.Point(7, 266);
            this.button64.Name = "button64";
            this.button64.Size = new System.Drawing.Size(244, 23);
            this.button64.TabIndex = 42;
            this.button64.Text = "Set system state ";
            this.button64.UseVisualStyleBackColor = true;
            this.button64.Click += new System.EventHandler(this.button64_Click);
            this.button64.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button64_MouseDown);
            // 
            // button63
            // 
            this.button63.Location = new System.Drawing.Point(3, 185);
            this.button63.Name = "button63";
            this.button63.Size = new System.Drawing.Size(244, 23);
            this.button63.TabIndex = 41;
            this.button63.Text = "Do Sync";
            this.button63.UseVisualStyleBackColor = true;
            this.button63.Click += new System.EventHandler(this.button63_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label22.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Maroon;
            this.label22.Location = new System.Drawing.Point(388, 126);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(150, 21);
            this.label22.TabIndex = 40;
            this.label22.Text = "Hexadecimal 3 bytes";
            // 
            // textBox_GetTxAD936X
            // 
            this.textBox_GetTxAD936X.Location = new System.Drawing.Point(252, 127);
            this.textBox_GetTxAD936X.MaxLength = 30;
            this.textBox_GetTxAD936X.Name = "textBox_GetTxAD936X";
            this.textBox_GetTxAD936X.Size = new System.Drawing.Size(130, 26);
            this.textBox_GetTxAD936X.TabIndex = 39;
            this.textBox_GetTxAD936X.Text = "00 1700";
            this.textBox_GetTxAD936X.TextChanged += new System.EventHandler(this.textBox_GetTxAD936X_TextChanged);
            // 
            // button62
            // 
            this.button62.Location = new System.Drawing.Point(2, 129);
            this.button62.Name = "button62";
            this.button62.Size = new System.Drawing.Size(244, 23);
            this.button62.TabIndex = 38;
            this.button62.Text = "Get Tx AD936X data ";
            this.button62.UseVisualStyleBackColor = true;
            this.button62.Click += new System.EventHandler(this.button62_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Maroon;
            this.label21.Location = new System.Drawing.Point(388, 94);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(150, 21);
            this.label21.TabIndex = 37;
            this.label21.Text = "Hexadecimal 4 bytes";
            // 
            // textBox_SetTxAD936X
            // 
            this.textBox_SetTxAD936X.Location = new System.Drawing.Point(252, 95);
            this.textBox_SetTxAD936X.MaxLength = 30;
            this.textBox_SetTxAD936X.Name = "textBox_SetTxAD936X";
            this.textBox_SetTxAD936X.Size = new System.Drawing.Size(130, 26);
            this.textBox_SetTxAD936X.TabIndex = 36;
            this.textBox_SetTxAD936X.Text = "00 0000 00";
            this.toolTip1.SetToolTip(this.textBox_SetTxAD936X, "1 byte – band type: 0x00 - L1, 0x01 - L2");
            this.textBox_SetTxAD936X.TextChanged += new System.EventHandler(this.textBox_SetTxAD936X_TextChanged);
            // 
            // button61
            // 
            this.button61.Location = new System.Drawing.Point(2, 98);
            this.button61.Name = "button61";
            this.button61.Size = new System.Drawing.Size(244, 23);
            this.button61.TabIndex = 35;
            this.button61.Text = "Set Tx AD936X data ";
            this.button61.UseVisualStyleBackColor = true;
            this.button61.Click += new System.EventHandler(this.button61_Click);
            this.button61.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button61_MouseDown);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Maroon;
            this.label20.Location = new System.Drawing.Point(388, 38);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(150, 21);
            this.label20.TabIndex = 34;
            this.label20.Text = "Hexadecimal 4 bytes";
            this.label20.Click += new System.EventHandler(this.label20_Click);
            // 
            // textBox_SetSynthesizerL2
            // 
            this.textBox_SetSynthesizerL2.Location = new System.Drawing.Point(252, 39);
            this.textBox_SetSynthesizerL2.MaxLength = 30;
            this.textBox_SetSynthesizerL2.Name = "textBox_SetSynthesizerL2";
            this.textBox_SetSynthesizerL2.Size = new System.Drawing.Size(130, 26);
            this.textBox_SetSynthesizerL2.TabIndex = 33;
            this.textBox_SetSynthesizerL2.Text = "00 00 00 00";
            this.textBox_SetSynthesizerL2.TextChanged += new System.EventHandler(this.textBox_SetSynthesizerL2_TextChanged);
            // 
            // button60
            // 
            this.button60.Location = new System.Drawing.Point(2, 42);
            this.button60.Name = "button60";
            this.button60.Size = new System.Drawing.Size(244, 23);
            this.button60.TabIndex = 32;
            this.button60.Text = "Set Synthesizer L2 register ";
            this.button60.UseVisualStyleBackColor = true;
            this.button60.Click += new System.EventHandler(this.button60_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Maroon;
            this.label19.Location = new System.Drawing.Point(389, 7);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(150, 21);
            this.label19.TabIndex = 31;
            this.label19.Text = "Hexadecimal 4 bytes";
            this.label19.Click += new System.EventHandler(this.label19_Click);
            // 
            // textBox_SetSynthesizerL1
            // 
            this.textBox_SetSynthesizerL1.Location = new System.Drawing.Point(253, 8);
            this.textBox_SetSynthesizerL1.MaxLength = 30;
            this.textBox_SetSynthesizerL1.Name = "textBox_SetSynthesizerL1";
            this.textBox_SetSynthesizerL1.Size = new System.Drawing.Size(129, 26);
            this.textBox_SetSynthesizerL1.TabIndex = 30;
            this.textBox_SetSynthesizerL1.Text = "00 00 00 00";
            this.textBox_SetSynthesizerL1.TextChanged += new System.EventHandler(this.textBox_SetSynthesizerL1_TextChanged);
            // 
            // button59
            // 
            this.button59.Location = new System.Drawing.Point(3, 11);
            this.button59.Name = "button59";
            this.button59.Size = new System.Drawing.Size(244, 23);
            this.button59.TabIndex = 29;
            this.button59.Text = "Set Synthesizer L1 register ";
            this.toolTip1.SetToolTip(this.button59, "rafrefaefaefaef");
            this.button59.UseVisualStyleBackColor = true;
            this.button59.Click += new System.EventHandler(this.button59_Click);
            this.button59.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button59_MouseClick);
            this.button59.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button59_MouseDown);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.textBox_SetDCAHex);
            this.tabPage6.Controls.Add(this.textBox_TxRFPLL);
            this.tabPage6.Controls.Add(this.textBox_RxRFPLL);
            this.tabPage6.Controls.Add(this.textBox_GetRXChannelGain);
            this.tabPage6.Controls.Add(this.button79);
            this.tabPage6.Controls.Add(this.button78);
            this.tabPage6.Controls.Add(this.button74);
            this.tabPage6.Controls.Add(this.textBox_SetDCA);
            this.tabPage6.Controls.Add(this.button75);
            this.tabPage6.Controls.Add(this.button76);
            this.tabPage6.Controls.Add(this.textBox_SetRXChannelGain);
            this.tabPage6.Controls.Add(this.button77);
            this.tabPage6.Location = new System.Drawing.Point(4, 27);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(949, 604);
            this.tabPage6.TabIndex = 3;
            this.tabPage6.Text = "RF";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // textBox_SetDCAHex
            // 
            this.textBox_SetDCAHex.Location = new System.Drawing.Point(479, 89);
            this.textBox_SetDCAHex.MaxLength = 121;
            this.textBox_SetDCAHex.Name = "textBox_SetDCAHex";
            this.textBox_SetDCAHex.ReadOnly = true;
            this.textBox_SetDCAHex.Size = new System.Drawing.Size(216, 26);
            this.textBox_SetDCAHex.TabIndex = 35;
            // 
            // textBox_TxRFPLL
            // 
            this.textBox_TxRFPLL.Location = new System.Drawing.Point(253, 208);
            this.textBox_TxRFPLL.MaxLength = 121;
            this.textBox_TxRFPLL.Name = "textBox_TxRFPLL";
            this.textBox_TxRFPLL.Size = new System.Drawing.Size(216, 26);
            this.textBox_TxRFPLL.TabIndex = 34;
            this.textBox_TxRFPLL.Text = "00 00";
            this.textBox_TxRFPLL.TextChanged += new System.EventHandler(this.textBox_TxRFPLL_TextChanged);
            // 
            // textBox_RxRFPLL
            // 
            this.textBox_RxRFPLL.Location = new System.Drawing.Point(253, 175);
            this.textBox_RxRFPLL.MaxLength = 121;
            this.textBox_RxRFPLL.Name = "textBox_RxRFPLL";
            this.textBox_RxRFPLL.Size = new System.Drawing.Size(216, 26);
            this.textBox_RxRFPLL.TabIndex = 33;
            this.textBox_RxRFPLL.Text = "00 00";
            this.textBox_RxRFPLL.TextChanged += new System.EventHandler(this.textBox_RxRFPLL_TextChanged);
            // 
            // textBox_GetRXChannelGain
            // 
            this.textBox_GetRXChannelGain.Location = new System.Drawing.Point(257, 38);
            this.textBox_GetRXChannelGain.MaxLength = 121;
            this.textBox_GetRXChannelGain.Name = "textBox_GetRXChannelGain";
            this.textBox_GetRXChannelGain.Size = new System.Drawing.Size(216, 26);
            this.textBox_GetRXChannelGain.TabIndex = 32;
            this.textBox_GetRXChannelGain.Text = "00";
            this.textBox_GetRXChannelGain.TextChanged += new System.EventHandler(this.textBox_GetRXChannelGain_TextChanged);
            // 
            // button79
            // 
            this.button79.Location = new System.Drawing.Point(3, 211);
            this.button79.Name = "button79";
            this.button79.Size = new System.Drawing.Size(244, 23);
            this.button79.TabIndex = 31;
            this.button79.Text = "AD9361 Tx RF PLL lock detect";
            this.button79.UseVisualStyleBackColor = true;
            this.button79.Click += new System.EventHandler(this.button79_Click);
            // 
            // button78
            // 
            this.button78.Location = new System.Drawing.Point(3, 178);
            this.button78.Name = "button78";
            this.button78.Size = new System.Drawing.Size(244, 23);
            this.button78.TabIndex = 30;
            this.button78.Text = "AD9361 Rx RF PLL lock detect";
            this.button78.UseVisualStyleBackColor = true;
            this.button78.Click += new System.EventHandler(this.button78_Click);
            this.button78.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button78_MouseDown);
            // 
            // button74
            // 
            this.button74.Location = new System.Drawing.Point(7, 121);
            this.button74.Name = "button74";
            this.button74.Size = new System.Drawing.Size(244, 23);
            this.button74.TabIndex = 29;
            this.button74.Text = "Get DCA";
            this.button74.UseVisualStyleBackColor = true;
            this.button74.Click += new System.EventHandler(this.button74_Click);
            // 
            // textBox_SetDCA
            // 
            this.textBox_SetDCA.Location = new System.Drawing.Point(257, 89);
            this.textBox_SetDCA.MaxLength = 121;
            this.textBox_SetDCA.Name = "textBox_SetDCA";
            this.textBox_SetDCA.Size = new System.Drawing.Size(216, 26);
            this.textBox_SetDCA.TabIndex = 28;
            this.textBox_SetDCA.Text = "1.1";
            this.textBox_SetDCA.TextChanged += new System.EventHandler(this.textBox_SetDCA_TextChanged);
            // 
            // button75
            // 
            this.button75.Location = new System.Drawing.Point(7, 92);
            this.button75.Name = "button75";
            this.button75.Size = new System.Drawing.Size(244, 23);
            this.button75.TabIndex = 27;
            this.button75.Text = "Set DCA";
            this.button75.UseVisualStyleBackColor = true;
            this.button75.Click += new System.EventHandler(this.button75_Click);
            // 
            // button76
            // 
            this.button76.Location = new System.Drawing.Point(7, 40);
            this.button76.Name = "button76";
            this.button76.Size = new System.Drawing.Size(244, 23);
            this.button76.TabIndex = 26;
            this.button76.Text = "Get RX channel gain";
            this.button76.UseVisualStyleBackColor = true;
            this.button76.Click += new System.EventHandler(this.button76_Click);
            // 
            // textBox_SetRXChannelGain
            // 
            this.textBox_SetRXChannelGain.Location = new System.Drawing.Point(257, 10);
            this.textBox_SetRXChannelGain.MaxLength = 121;
            this.textBox_SetRXChannelGain.Name = "textBox_SetRXChannelGain";
            this.textBox_SetRXChannelGain.Size = new System.Drawing.Size(216, 26);
            this.textBox_SetRXChannelGain.TabIndex = 25;
            this.textBox_SetRXChannelGain.Text = "00 00";
            this.textBox_SetRXChannelGain.TextChanged += new System.EventHandler(this.textBox_SetRXChannelGain_TextChanged);
            // 
            // button77
            // 
            this.button77.Location = new System.Drawing.Point(7, 11);
            this.button77.Name = "button77";
            this.button77.Size = new System.Drawing.Size(244, 23);
            this.button77.TabIndex = 24;
            this.button77.Text = "Set RX channel gain";
            this.button77.UseVisualStyleBackColor = true;
            this.button77.Click += new System.EventHandler(this.button77_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.textBox_GetGPIOVal);
            this.tabPage3.Controls.Add(this.button82);
            this.tabPage3.Controls.Add(this.textBox_SetGPIOVal);
            this.tabPage3.Controls.Add(this.button83);
            this.tabPage3.Controls.Add(this.textBox_GetGPIODir);
            this.tabPage3.Controls.Add(this.button80);
            this.tabPage3.Controls.Add(this.textBox_SetGPIODir);
            this.tabPage3.Controls.Add(this.button81);
            this.tabPage3.Controls.Add(this.label29);
            this.tabPage3.Controls.Add(this.textBox_WriteFPGARegister);
            this.tabPage3.Controls.Add(this.button70);
            this.tabPage3.Controls.Add(this.label30);
            this.tabPage3.Controls.Add(this.textBox_ReadFPGARegister);
            this.tabPage3.Controls.Add(this.button71);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(949, 604);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Debug";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBox_GetGPIOVal
            // 
            this.textBox_GetGPIOVal.Location = new System.Drawing.Point(252, 184);
            this.textBox_GetGPIOVal.MaxLength = 30;
            this.textBox_GetGPIOVal.Name = "textBox_GetGPIOVal";
            this.textBox_GetGPIOVal.Size = new System.Drawing.Size(130, 26);
            this.textBox_GetGPIOVal.TabIndex = 48;
            this.textBox_GetGPIOVal.Text = "01";
            this.textBox_GetGPIOVal.TextChanged += new System.EventHandler(this.textBox_GetGPIOVal_TextChanged);
            // 
            // button82
            // 
            this.button82.Location = new System.Drawing.Point(2, 187);
            this.button82.Name = "button82";
            this.button82.Size = new System.Drawing.Size(244, 23);
            this.button82.TabIndex = 47;
            this.button82.Text = "Get GPIO Value";
            this.button82.UseVisualStyleBackColor = true;
            this.button82.Click += new System.EventHandler(this.button82_Click);
            // 
            // textBox_SetGPIOVal
            // 
            this.textBox_SetGPIOVal.Location = new System.Drawing.Point(253, 153);
            this.textBox_SetGPIOVal.MaxLength = 30;
            this.textBox_SetGPIOVal.Name = "textBox_SetGPIOVal";
            this.textBox_SetGPIOVal.Size = new System.Drawing.Size(129, 26);
            this.textBox_SetGPIOVal.TabIndex = 46;
            this.textBox_SetGPIOVal.Text = "01 01";
            this.textBox_SetGPIOVal.TextChanged += new System.EventHandler(this.textBox_SetGPIOVal_TextChanged);
            // 
            // button83
            // 
            this.button83.Location = new System.Drawing.Point(3, 156);
            this.button83.Name = "button83";
            this.button83.Size = new System.Drawing.Size(244, 23);
            this.button83.TabIndex = 45;
            this.button83.Text = "Set GPIO Value";
            this.toolTip1.SetToolTip(this.button83, "rafrefaefaefaef");
            this.button83.UseVisualStyleBackColor = true;
            this.button83.Click += new System.EventHandler(this.button83_Click);
            // 
            // textBox_GetGPIODir
            // 
            this.textBox_GetGPIODir.Location = new System.Drawing.Point(252, 123);
            this.textBox_GetGPIODir.MaxLength = 30;
            this.textBox_GetGPIODir.Name = "textBox_GetGPIODir";
            this.textBox_GetGPIODir.Size = new System.Drawing.Size(130, 26);
            this.textBox_GetGPIODir.TabIndex = 44;
            this.textBox_GetGPIODir.Text = "01";
            this.textBox_GetGPIODir.TextChanged += new System.EventHandler(this.textBox_GetGPIODir_TextChanged);
            // 
            // button80
            // 
            this.button80.Location = new System.Drawing.Point(2, 126);
            this.button80.Name = "button80";
            this.button80.Size = new System.Drawing.Size(244, 23);
            this.button80.TabIndex = 43;
            this.button80.Text = "Get GPIO Direction";
            this.button80.UseVisualStyleBackColor = true;
            this.button80.Click += new System.EventHandler(this.button80_Click);
            // 
            // textBox_SetGPIODir
            // 
            this.textBox_SetGPIODir.Location = new System.Drawing.Point(253, 92);
            this.textBox_SetGPIODir.MaxLength = 30;
            this.textBox_SetGPIODir.Name = "textBox_SetGPIODir";
            this.textBox_SetGPIODir.Size = new System.Drawing.Size(129, 26);
            this.textBox_SetGPIODir.TabIndex = 42;
            this.textBox_SetGPIODir.Text = "01 00";
            this.textBox_SetGPIODir.TextChanged += new System.EventHandler(this.textBox_SetGPIODir_TextChanged);
            // 
            // button81
            // 
            this.button81.Location = new System.Drawing.Point(3, 95);
            this.button81.Name = "button81";
            this.button81.Size = new System.Drawing.Size(244, 23);
            this.button81.TabIndex = 41;
            this.button81.Text = "Set GPIO Direction";
            this.toolTip1.SetToolTip(this.button81, "rafrefaefaefaef");
            this.button81.UseVisualStyleBackColor = true;
            this.button81.Click += new System.EventHandler(this.button81_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label29.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.Maroon;
            this.label29.Location = new System.Drawing.Point(388, 38);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(150, 21);
            this.label29.TabIndex = 40;
            this.label29.Text = "Hexadecimal 4 bytes";
            // 
            // textBox_WriteFPGARegister
            // 
            this.textBox_WriteFPGARegister.Location = new System.Drawing.Point(252, 39);
            this.textBox_WriteFPGARegister.MaxLength = 30;
            this.textBox_WriteFPGARegister.Name = "textBox_WriteFPGARegister";
            this.textBox_WriteFPGARegister.Size = new System.Drawing.Size(130, 26);
            this.textBox_WriteFPGARegister.TabIndex = 39;
            this.textBox_WriteFPGARegister.Text = "00 00 00 00";
            this.textBox_WriteFPGARegister.TextChanged += new System.EventHandler(this.textBox_WriteFPGARegister_TextChanged);
            // 
            // button70
            // 
            this.button70.Location = new System.Drawing.Point(2, 42);
            this.button70.Name = "button70";
            this.button70.Size = new System.Drawing.Size(244, 23);
            this.button70.TabIndex = 38;
            this.button70.Text = "Write FPGA register ";
            this.button70.UseVisualStyleBackColor = true;
            this.button70.Click += new System.EventHandler(this.button70_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label30.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.Maroon;
            this.label30.Location = new System.Drawing.Point(389, 7);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(150, 21);
            this.label30.TabIndex = 37;
            this.label30.Text = "Hexadecimal 4 bytes";
            // 
            // textBox_ReadFPGARegister
            // 
            this.textBox_ReadFPGARegister.Location = new System.Drawing.Point(253, 8);
            this.textBox_ReadFPGARegister.MaxLength = 30;
            this.textBox_ReadFPGARegister.Name = "textBox_ReadFPGARegister";
            this.textBox_ReadFPGARegister.Size = new System.Drawing.Size(129, 26);
            this.textBox_ReadFPGARegister.TabIndex = 36;
            this.textBox_ReadFPGARegister.Text = "00 00 00 00";
            this.textBox_ReadFPGARegister.TextChanged += new System.EventHandler(this.textBox_ReadFPGARegister_TextChanged);
            // 
            // button71
            // 
            this.button71.Location = new System.Drawing.Point(3, 11);
            this.button71.Name = "button71";
            this.button71.Size = new System.Drawing.Size(244, 23);
            this.button71.TabIndex = 35;
            this.button71.Text = "Read FPGA register ";
            this.toolTip1.SetToolTip(this.button71, "rafrefaefaefaef");
            this.button71.UseVisualStyleBackColor = true;
            this.button71.Click += new System.EventHandler(this.button71_Click);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.label34);
            this.tabPage7.Controls.Add(this.textBox_SetRxChannelState);
            this.tabPage7.Controls.Add(this.button85);
            this.tabPage7.Controls.Add(this.label33);
            this.tabPage7.Controls.Add(this.textBox_RecordIQSourceSealect);
            this.tabPage7.Controls.Add(this.button84);
            this.tabPage7.Controls.Add(this.label32);
            this.tabPage7.Controls.Add(this.textBox_RecordIQData);
            this.tabPage7.Controls.Add(this.button_RecordIQData);
            this.tabPage7.Location = new System.Drawing.Point(4, 27);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(949, 604);
            this.tabPage7.TabIndex = 4;
            this.tabPage7.Text = "Recording";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label34.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.Maroon;
            this.label34.Location = new System.Drawing.Point(479, 82);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(150, 21);
            this.label34.TabIndex = 44;
            this.label34.Text = "Hexadecimal 2 bytes";
            // 
            // textBox_SetRxChannelState
            // 
            this.textBox_SetRxChannelState.Location = new System.Drawing.Point(257, 82);
            this.textBox_SetRxChannelState.MaxLength = 121;
            this.textBox_SetRxChannelState.Name = "textBox_SetRxChannelState";
            this.textBox_SetRxChannelState.Size = new System.Drawing.Size(216, 26);
            this.textBox_SetRxChannelState.TabIndex = 43;
            this.textBox_SetRxChannelState.Text = "00 00";
            this.textBox_SetRxChannelState.TextChanged += new System.EventHandler(this.textBox_SetRxChannelState_TextChanged);
            // 
            // button85
            // 
            this.button85.Location = new System.Drawing.Point(7, 83);
            this.button85.Name = "button85";
            this.button85.Size = new System.Drawing.Size(244, 23);
            this.button85.TabIndex = 42;
            this.button85.Text = "Set RX channel state RX/CAL";
            this.button85.UseVisualStyleBackColor = true;
            this.button85.Click += new System.EventHandler(this.button85_Click);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label33.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.Maroon;
            this.label33.Location = new System.Drawing.Point(479, 48);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(150, 21);
            this.label33.TabIndex = 41;
            this.label33.Text = "Hexadecimal 3 bytes";
            // 
            // textBox_RecordIQSourceSealect
            // 
            this.textBox_RecordIQSourceSealect.Location = new System.Drawing.Point(257, 48);
            this.textBox_RecordIQSourceSealect.MaxLength = 121;
            this.textBox_RecordIQSourceSealect.Name = "textBox_RecordIQSourceSealect";
            this.textBox_RecordIQSourceSealect.Size = new System.Drawing.Size(216, 26);
            this.textBox_RecordIQSourceSealect.TabIndex = 40;
            this.textBox_RecordIQSourceSealect.Text = "00 00 00";
            this.textBox_RecordIQSourceSealect.TextChanged += new System.EventHandler(this.textBox_RecordIQSourceSealect_TextChanged);
            // 
            // button84
            // 
            this.button84.Location = new System.Drawing.Point(7, 49);
            this.button84.Name = "button84";
            this.button84.Size = new System.Drawing.Size(244, 23);
            this.button84.TabIndex = 39;
            this.button84.Text = "Record IQ data source select ";
            this.button84.UseVisualStyleBackColor = true;
            this.button84.Click += new System.EventHandler(this.button84_Click);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label32.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.Maroon;
            this.label32.Location = new System.Drawing.Point(479, 15);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(150, 21);
            this.label32.TabIndex = 38;
            this.label32.Text = "Hexadecimal 5 bytes";
            // 
            // textBox_RecordIQData
            // 
            this.textBox_RecordIQData.Location = new System.Drawing.Point(257, 15);
            this.textBox_RecordIQData.MaxLength = 121;
            this.textBox_RecordIQData.Name = "textBox_RecordIQData";
            this.textBox_RecordIQData.Size = new System.Drawing.Size(216, 26);
            this.textBox_RecordIQData.TabIndex = 27;
            this.textBox_RecordIQData.Text = "00 00 00 00 00";
            this.textBox_RecordIQData.TextChanged += new System.EventHandler(this.textBox_RecordIQData_TextChanged);
            // 
            // button_RecordIQData
            // 
            this.button_RecordIQData.Location = new System.Drawing.Point(7, 16);
            this.button_RecordIQData.Name = "button_RecordIQData";
            this.button_RecordIQData.Size = new System.Drawing.Size(244, 23);
            this.button_RecordIQData.TabIndex = 26;
            this.button_RecordIQData.Text = "Record IQ data ";
            this.button_RecordIQData.UseVisualStyleBackColor = true;
            this.button_RecordIQData.Click += new System.EventHandler(this.button_RecordIQData_Click);
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(4, 27);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(949, 604);
            this.tabPage8.TabIndex = 5;
            this.tabPage8.Text = "Transmit";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // groupBox32
            // 
            this.groupBox32.Controls.Add(this.richTextBox_MiniAda);
            this.groupBox32.Controls.Add(this.checkBox_RecordMiniAda);
            this.groupBox32.Controls.Add(this.checkBox_PauseMiniAda);
            this.groupBox32.Controls.Add(this.button_ClearMiniAda);
            this.groupBox32.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox32.Location = new System.Drawing.Point(985, 3);
            this.groupBox32.Name = "groupBox32";
            this.groupBox32.Size = new System.Drawing.Size(558, 668);
            this.groupBox32.TabIndex = 9;
            this.groupBox32.TabStop = false;
            this.groupBox32.Text = "MiniAda Monitor";
            // 
            // richTextBox_MiniAda
            // 
            this.richTextBox_MiniAda.BackColor = System.Drawing.Color.LightGray;
            this.richTextBox_MiniAda.EnableAutoDragDrop = true;
            this.richTextBox_MiniAda.Location = new System.Drawing.Point(6, 17);
            this.richTextBox_MiniAda.Name = "richTextBox_MiniAda";
            this.richTextBox_MiniAda.Size = new System.Drawing.Size(553, 607);
            this.richTextBox_MiniAda.TabIndex = 0;
            this.richTextBox_MiniAda.Text = "";
            // 
            // checkBox_RecordMiniAda
            // 
            this.checkBox_RecordMiniAda.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_RecordMiniAda.AutoSize = true;
            this.checkBox_RecordMiniAda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_RecordMiniAda.Location = new System.Drawing.Point(7, 630);
            this.checkBox_RecordMiniAda.Name = "checkBox_RecordMiniAda";
            this.checkBox_RecordMiniAda.Size = new System.Drawing.Size(99, 26);
            this.checkBox_RecordMiniAda.TabIndex = 7;
            this.checkBox_RecordMiniAda.Text = "Record Log";
            this.checkBox_RecordMiniAda.UseVisualStyleBackColor = true;
            // 
            // checkBox_PauseMiniAda
            // 
            this.checkBox_PauseMiniAda.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_PauseMiniAda.AutoSize = true;
            this.checkBox_PauseMiniAda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_PauseMiniAda.Location = new System.Drawing.Point(112, 630);
            this.checkBox_PauseMiniAda.Name = "checkBox_PauseMiniAda";
            this.checkBox_PauseMiniAda.Size = new System.Drawing.Size(62, 26);
            this.checkBox_PauseMiniAda.TabIndex = 5;
            this.checkBox_PauseMiniAda.Text = "Pause";
            this.checkBox_PauseMiniAda.UseVisualStyleBackColor = true;
            // 
            // button_ClearMiniAda
            // 
            this.button_ClearMiniAda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ClearMiniAda.Location = new System.Drawing.Point(180, 630);
            this.button_ClearMiniAda.Name = "button_ClearMiniAda";
            this.button_ClearMiniAda.Size = new System.Drawing.Size(62, 26);
            this.button_ClearMiniAda.TabIndex = 6;
            this.button_ClearMiniAda.Text = "Clear";
            this.button_ClearMiniAda.UseVisualStyleBackColor = true;
            // 
            // button_OpenFolder
            // 
            this.button_OpenFolder.Location = new System.Drawing.Point(1561, 304);
            this.button_OpenFolder.Name = "button_OpenFolder";
            this.button_OpenFolder.Size = new System.Drawing.Size(191, 26);
            this.button_OpenFolder.TabIndex = 76;
            this.button_OpenFolder.Text = "Open Folder";
            this.button_OpenFolder.UseVisualStyleBackColor = true;
            this.button_OpenFolder.Click += new System.EventHandler(this.Button43_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.S1_Configuration);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1406, 776);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "S1 Configuration";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // S1_Configuration
            // 
            this.S1_Configuration.Controls.Add(this.groupBox12);
            this.S1_Configuration.Controls.Add(this.groupBox22);
            this.S1_Configuration.Controls.Add(this.groupBox28);
            this.S1_Configuration.Controls.Add(this.groupBox30);
            this.S1_Configuration.Controls.Add(this.groupBox29);
            this.S1_Configuration.Controls.Add(this.groupBox27);
            this.S1_Configuration.Controls.Add(this.groupBox26);
            this.S1_Configuration.Controls.Add(this.groupBox25);
            this.S1_Configuration.Controls.Add(this.groupBox24);
            this.S1_Configuration.Controls.Add(this.groupBox23);
            this.S1_Configuration.Controls.Add(this.groupBox21);
            this.S1_Configuration.Controls.Add(this.groupBox20);
            this.S1_Configuration.Controls.Add(this.groupBox19);
            this.S1_Configuration.Controls.Add(this.groupBox18);
            this.S1_Configuration.Controls.Add(this.groupBox17);
            this.S1_Configuration.Controls.Add(this.groupBox11);
            this.S1_Configuration.Controls.Add(this.groupBox10);
            this.S1_Configuration.Controls.Add(this.groupBox9);
            this.S1_Configuration.Controls.Add(this.groupBox8);
            this.S1_Configuration.Controls.Add(this.groupBox7);
            this.S1_Configuration.Controls.Add(this.groupBox6);
            this.S1_Configuration.Controls.Add(this.groupBox13);
            this.S1_Configuration.Controls.Add(this.groupBox14);
            this.S1_Configuration.Controls.Add(this.groupBox15);
            this.S1_Configuration.Controls.Add(this.groupBox16);
            this.S1_Configuration.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.S1_Configuration.Location = new System.Drawing.Point(3, 3);
            this.S1_Configuration.Name = "S1_Configuration";
            this.S1_Configuration.Size = new System.Drawing.Size(924, 741);
            this.S1_Configuration.TabIndex = 12;
            this.S1_Configuration.TabStop = false;
            this.S1_Configuration.Text = "S1 Configuration";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.button13);
            this.groupBox12.Location = new System.Drawing.Point(716, 24);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(164, 58);
            this.groupBox12.TabIndex = 67;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "RF pairing";
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.Location = new System.Drawing.Point(10, 20);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(152, 26);
            this.button13.TabIndex = 49;
            this.button13.Text = "RF Pairing";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.Button13_Click);
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.TextBox_Odometer);
            this.groupBox22.Controls.Add(this.button19);
            this.groupBox22.Location = new System.Drawing.Point(718, 88);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(200, 78);
            this.groupBox22.TabIndex = 68;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "Odometer";
            // 
            // TextBox_Odometer
            // 
            this.TextBox_Odometer.Location = new System.Drawing.Point(6, 23);
            this.TextBox_Odometer.Name = "TextBox_Odometer";
            this.TextBox_Odometer.Size = new System.Drawing.Size(100, 22);
            this.TextBox_Odometer.TabIndex = 64;
            // 
            // button19
            // 
            this.button19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button19.Location = new System.Drawing.Point(6, 50);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(74, 26);
            this.button19.TabIndex = 63;
            this.button19.Text = "Odometer Config";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.Button19_Click);
            // 
            // groupBox28
            // 
            this.groupBox28.Controls.Add(this.textBox_ModemSocket);
            this.groupBox28.Controls.Add(this.textBox_ModemRetries);
            this.groupBox28.Controls.Add(this.textBox_ModemTimeOut);
            this.groupBox28.Controls.Add(this.button25);
            this.groupBox28.Controls.Add(this.textBox_ModemPrimeryPort);
            this.groupBox28.Controls.Add(this.textBox_ModemPrimeryHost);
            this.groupBox28.Location = new System.Drawing.Point(188, 499);
            this.groupBox28.Name = "groupBox28";
            this.groupBox28.Size = new System.Drawing.Size(146, 195);
            this.groupBox28.TabIndex = 45;
            this.groupBox28.TabStop = false;
            this.groupBox28.Text = "Modem Config";
            // 
            // textBox_ModemSocket
            // 
            this.textBox_ModemSocket.Location = new System.Drawing.Point(8, 77);
            this.textBox_ModemSocket.Name = "textBox_ModemSocket";
            this.textBox_ModemSocket.Size = new System.Drawing.Size(132, 22);
            this.textBox_ModemSocket.TabIndex = 80;
            this.toolTip1.SetToolTip(this.textBox_ModemSocket, "Modem Socket");
            // 
            // textBox_ModemRetries
            // 
            this.textBox_ModemRetries.Location = new System.Drawing.Point(8, 50);
            this.textBox_ModemRetries.Name = "textBox_ModemRetries";
            this.textBox_ModemRetries.Size = new System.Drawing.Size(132, 22);
            this.textBox_ModemRetries.TabIndex = 79;
            this.toolTip1.SetToolTip(this.textBox_ModemRetries, "Modem retries");
            // 
            // textBox_ModemTimeOut
            // 
            this.textBox_ModemTimeOut.Location = new System.Drawing.Point(8, 23);
            this.textBox_ModemTimeOut.Name = "textBox_ModemTimeOut";
            this.textBox_ModemTimeOut.Size = new System.Drawing.Size(132, 22);
            this.textBox_ModemTimeOut.TabIndex = 78;
            this.toolTip1.SetToolTip(this.textBox_ModemTimeOut, "Modem Time Out");
            // 
            // button25
            // 
            this.button25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button25.Location = new System.Drawing.Point(8, 157);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(132, 26);
            this.button25.TabIndex = 44;
            this.button25.Text = "Config Modem";
            this.button25.UseVisualStyleBackColor = true;
            this.button25.Click += new System.EventHandler(this.Button25_Click);
            // 
            // textBox_ModemPrimeryPort
            // 
            this.textBox_ModemPrimeryPort.Location = new System.Drawing.Point(8, 129);
            this.textBox_ModemPrimeryPort.Name = "textBox_ModemPrimeryPort";
            this.textBox_ModemPrimeryPort.Size = new System.Drawing.Size(132, 22);
            this.textBox_ModemPrimeryPort.TabIndex = 37;
            this.toolTip1.SetToolTip(this.textBox_ModemPrimeryPort, "Primery Port");
            // 
            // textBox_ModemPrimeryHost
            // 
            this.textBox_ModemPrimeryHost.Location = new System.Drawing.Point(8, 101);
            this.textBox_ModemPrimeryHost.Name = "textBox_ModemPrimeryHost";
            this.textBox_ModemPrimeryHost.Size = new System.Drawing.Size(132, 22);
            this.textBox_ModemPrimeryHost.TabIndex = 36;
            this.toolTip1.SetToolTip(this.textBox_ModemPrimeryHost, "Primery Host");
            // 
            // groupBox30
            // 
            this.groupBox30.Controls.Add(this.textBox_ForginPassword);
            this.groupBox30.Controls.Add(this.button27);
            this.groupBox30.Controls.Add(this.textBox_ForginAcessPoint);
            this.groupBox30.Controls.Add(this.textBox_ForginSecondaryDNS);
            this.groupBox30.Controls.Add(this.textBox_ForginUserName);
            this.groupBox30.Controls.Add(this.textBox_ForginPrimeryDNS);
            this.groupBox30.Location = new System.Drawing.Point(344, 499);
            this.groupBox30.Name = "groupBox30";
            this.groupBox30.Size = new System.Drawing.Size(160, 195);
            this.groupBox30.TabIndex = 47;
            this.groupBox30.TabStop = false;
            this.groupBox30.Text = "Config Forgin Network";
            // 
            // textBox_ForginPassword
            // 
            this.textBox_ForginPassword.Location = new System.Drawing.Point(8, 77);
            this.textBox_ForginPassword.Name = "textBox_ForginPassword";
            this.textBox_ForginPassword.Size = new System.Drawing.Size(146, 22);
            this.textBox_ForginPassword.TabIndex = 35;
            this.toolTip1.SetToolTip(this.textBox_ForginPassword, "Password");
            // 
            // button27
            // 
            this.button27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button27.Location = new System.Drawing.Point(8, 157);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(146, 26);
            this.button27.TabIndex = 44;
            this.button27.Text = "Config Forgin Net";
            this.button27.UseVisualStyleBackColor = true;
            this.button27.Click += new System.EventHandler(this.Button27_Click);
            // 
            // textBox_ForginAcessPoint
            // 
            this.textBox_ForginAcessPoint.Location = new System.Drawing.Point(7, 23);
            this.textBox_ForginAcessPoint.Name = "textBox_ForginAcessPoint";
            this.textBox_ForginAcessPoint.Size = new System.Drawing.Size(147, 22);
            this.textBox_ForginAcessPoint.TabIndex = 33;
            this.toolTip1.SetToolTip(this.textBox_ForginAcessPoint, "Aceess point");
            // 
            // textBox_ForginSecondaryDNS
            // 
            this.textBox_ForginSecondaryDNS.Location = new System.Drawing.Point(8, 129);
            this.textBox_ForginSecondaryDNS.Name = "textBox_ForginSecondaryDNS";
            this.textBox_ForginSecondaryDNS.Size = new System.Drawing.Size(146, 22);
            this.textBox_ForginSecondaryDNS.TabIndex = 37;
            this.toolTip1.SetToolTip(this.textBox_ForginSecondaryDNS, "Secondary DNS");
            // 
            // textBox_ForginUserName
            // 
            this.textBox_ForginUserName.Location = new System.Drawing.Point(8, 51);
            this.textBox_ForginUserName.Name = "textBox_ForginUserName";
            this.textBox_ForginUserName.Size = new System.Drawing.Size(146, 22);
            this.textBox_ForginUserName.TabIndex = 34;
            this.toolTip1.SetToolTip(this.textBox_ForginUserName, "User Name");
            // 
            // textBox_ForginPrimeryDNS
            // 
            this.textBox_ForginPrimeryDNS.Location = new System.Drawing.Point(8, 101);
            this.textBox_ForginPrimeryDNS.Name = "textBox_ForginPrimeryDNS";
            this.textBox_ForginPrimeryDNS.Size = new System.Drawing.Size(146, 22);
            this.textBox_ForginPrimeryDNS.TabIndex = 36;
            this.toolTip1.SetToolTip(this.textBox_ForginPrimeryDNS, "Primery DNS");
            // 
            // groupBox29
            // 
            this.groupBox29.Controls.Add(this.textBox_HomePassword);
            this.groupBox29.Controls.Add(this.button26);
            this.groupBox29.Controls.Add(this.textBox_HomeAcessPoint);
            this.groupBox29.Controls.Add(this.textBox_HomeSecondaryDNS);
            this.groupBox29.Controls.Add(this.textBox_HomeUserName);
            this.groupBox29.Controls.Add(this.textBox_HomePrimeryDNS);
            this.groupBox29.Location = new System.Drawing.Point(345, 298);
            this.groupBox29.Name = "groupBox29";
            this.groupBox29.Size = new System.Drawing.Size(160, 195);
            this.groupBox29.TabIndex = 46;
            this.groupBox29.TabStop = false;
            this.groupBox29.Text = "Config Home Net";
            // 
            // textBox_HomePassword
            // 
            this.textBox_HomePassword.Location = new System.Drawing.Point(8, 77);
            this.textBox_HomePassword.Name = "textBox_HomePassword";
            this.textBox_HomePassword.Size = new System.Drawing.Size(146, 22);
            this.textBox_HomePassword.TabIndex = 35;
            this.textBox_HomePassword.Text = "Password";
            // 
            // button26
            // 
            this.button26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button26.Location = new System.Drawing.Point(8, 157);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(146, 26);
            this.button26.TabIndex = 44;
            this.button26.Text = "Config Home Net";
            this.button26.UseVisualStyleBackColor = true;
            this.button26.Click += new System.EventHandler(this.Button26_Click);
            // 
            // textBox_HomeAcessPoint
            // 
            this.textBox_HomeAcessPoint.Location = new System.Drawing.Point(7, 23);
            this.textBox_HomeAcessPoint.Name = "textBox_HomeAcessPoint";
            this.textBox_HomeAcessPoint.Size = new System.Drawing.Size(147, 22);
            this.textBox_HomeAcessPoint.TabIndex = 33;
            this.textBox_HomeAcessPoint.Text = "Aceess point";
            // 
            // textBox_HomeSecondaryDNS
            // 
            this.textBox_HomeSecondaryDNS.Location = new System.Drawing.Point(8, 129);
            this.textBox_HomeSecondaryDNS.Name = "textBox_HomeSecondaryDNS";
            this.textBox_HomeSecondaryDNS.Size = new System.Drawing.Size(146, 22);
            this.textBox_HomeSecondaryDNS.TabIndex = 37;
            this.textBox_HomeSecondaryDNS.Text = "Secondary DNS";
            // 
            // textBox_HomeUserName
            // 
            this.textBox_HomeUserName.Location = new System.Drawing.Point(8, 51);
            this.textBox_HomeUserName.Name = "textBox_HomeUserName";
            this.textBox_HomeUserName.Size = new System.Drawing.Size(146, 22);
            this.textBox_HomeUserName.TabIndex = 34;
            this.textBox_HomeUserName.Text = "User Name";
            // 
            // textBox_HomePrimeryDNS
            // 
            this.textBox_HomePrimeryDNS.Location = new System.Drawing.Point(8, 101);
            this.textBox_HomePrimeryDNS.Name = "textBox_HomePrimeryDNS";
            this.textBox_HomePrimeryDNS.Size = new System.Drawing.Size(146, 22);
            this.textBox_HomePrimeryDNS.TabIndex = 36;
            this.textBox_HomePrimeryDNS.Text = "Primery DNS";
            // 
            // groupBox27
            // 
            this.groupBox27.Controls.Add(this.maskedTextBox1);
            this.groupBox27.Controls.Add(this.button24);
            this.groupBox27.Location = new System.Drawing.Point(315, 107);
            this.groupBox27.Name = "groupBox27";
            this.groupBox27.Size = new System.Drawing.Size(145, 78);
            this.groupBox27.TabIndex = 72;
            this.groupBox27.TabStop = false;
            this.groupBox27.Text = "Sleep Status Duration";
            this.toolTip1.SetToolTip(this.groupBox27, "Sleep Status Duration");
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(6, 18);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 22);
            this.maskedTextBox1.TabIndex = 71;
            // 
            // button24
            // 
            this.button24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button24.Location = new System.Drawing.Point(6, 45);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(131, 26);
            this.button24.TabIndex = 70;
            this.button24.Text = "Duration sleep";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.Button24_Click);
            // 
            // groupBox26
            // 
            this.groupBox26.Controls.Add(this.TextBox_NormalStatusDuration);
            this.groupBox26.Controls.Add(this.button23);
            this.groupBox26.Location = new System.Drawing.Point(334, 24);
            this.groupBox26.Name = "groupBox26";
            this.groupBox26.Size = new System.Drawing.Size(171, 77);
            this.groupBox26.TabIndex = 71;
            this.groupBox26.TabStop = false;
            this.groupBox26.Text = "Normal Status Duration";
            // 
            // TextBox_NormalStatusDuration
            // 
            this.TextBox_NormalStatusDuration.Location = new System.Drawing.Point(6, 17);
            this.TextBox_NormalStatusDuration.Name = "TextBox_NormalStatusDuration";
            this.TextBox_NormalStatusDuration.Size = new System.Drawing.Size(100, 22);
            this.TextBox_NormalStatusDuration.TabIndex = 71;
            // 
            // button23
            // 
            this.button23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button23.Location = new System.Drawing.Point(6, 45);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(111, 26);
            this.button23.TabIndex = 70;
            this.button23.Text = "Set Duration";
            this.toolTip1.SetToolTip(this.button23, "Normal Status Duration");
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.Button23_Click);
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.maskedTextBox_SpeedLimit2);
            this.groupBox25.Controls.Add(this.maskedTextBox_SpeedLimit3);
            this.groupBox25.Controls.Add(this.maskedTextBox_SpeedLimit1);
            this.groupBox25.Controls.Add(this.button22);
            this.groupBox25.Location = new System.Drawing.Point(510, 557);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(200, 89);
            this.groupBox25.TabIndex = 70;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "Speed Limit Config";
            // 
            // maskedTextBox_SpeedLimit2
            // 
            this.maskedTextBox_SpeedLimit2.Location = new System.Drawing.Point(53, 20);
            this.maskedTextBox_SpeedLimit2.Name = "maskedTextBox_SpeedLimit2";
            this.maskedTextBox_SpeedLimit2.Size = new System.Drawing.Size(41, 22);
            this.maskedTextBox_SpeedLimit2.TabIndex = 80;
            // 
            // maskedTextBox_SpeedLimit3
            // 
            this.maskedTextBox_SpeedLimit3.Location = new System.Drawing.Point(101, 19);
            this.maskedTextBox_SpeedLimit3.Name = "maskedTextBox_SpeedLimit3";
            this.maskedTextBox_SpeedLimit3.Size = new System.Drawing.Size(41, 22);
            this.maskedTextBox_SpeedLimit3.TabIndex = 79;
            // 
            // maskedTextBox_SpeedLimit1
            // 
            this.maskedTextBox_SpeedLimit1.Location = new System.Drawing.Point(6, 20);
            this.maskedTextBox_SpeedLimit1.Name = "maskedTextBox_SpeedLimit1";
            this.maskedTextBox_SpeedLimit1.Size = new System.Drawing.Size(41, 22);
            this.maskedTextBox_SpeedLimit1.TabIndex = 78;
            // 
            // button22
            // 
            this.button22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button22.Location = new System.Drawing.Point(6, 47);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(140, 26);
            this.button22.TabIndex = 65;
            this.button22.Text = "Speed Limit Alert";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.Button22_Click);
            // 
            // groupBox24
            // 
            this.groupBox24.Controls.Add(this.comboBox_DispatchSpeed);
            this.groupBox24.Controls.Add(this.button21);
            this.groupBox24.Location = new System.Drawing.Point(228, 377);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(106, 103);
            this.groupBox24.TabIndex = 68;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = "Dispatch Speed Limit";
            // 
            // comboBox_DispatchSpeed
            // 
            this.comboBox_DispatchSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_DispatchSpeed.FormattingEnabled = true;
            this.comboBox_DispatchSpeed.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_DispatchSpeed.Location = new System.Drawing.Point(8, 44);
            this.comboBox_DispatchSpeed.Name = "comboBox_DispatchSpeed";
            this.comboBox_DispatchSpeed.Size = new System.Drawing.Size(94, 21);
            this.comboBox_DispatchSpeed.TabIndex = 63;
            this.comboBox_DispatchSpeed.Text = "Speed";
            // 
            // button21
            // 
            this.button21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button21.Location = new System.Drawing.Point(8, 71);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(94, 26);
            this.button21.TabIndex = 64;
            this.button21.Text = "Dispatch Speed";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.Button21_Click);
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.comboBox_KillEngine);
            this.groupBox23.Controls.Add(this.button20);
            this.groupBox23.Location = new System.Drawing.Point(230, 287);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(109, 91);
            this.groupBox23.TabIndex = 67;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "Kill Engine";
            // 
            // comboBox_KillEngine
            // 
            this.comboBox_KillEngine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_KillEngine.FormattingEnabled = true;
            this.comboBox_KillEngine.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_KillEngine.Location = new System.Drawing.Point(6, 20);
            this.comboBox_KillEngine.Name = "comboBox_KillEngine";
            this.comboBox_KillEngine.Size = new System.Drawing.Size(58, 21);
            this.comboBox_KillEngine.TabIndex = 63;
            this.comboBox_KillEngine.Text = "Engine";
            // 
            // button20
            // 
            this.button20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button20.Location = new System.Drawing.Point(6, 43);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(98, 26);
            this.button20.TabIndex = 64;
            this.button20.Text = "Kill Engine";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.Button20_Click);
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.maskedTextBox_TiltTowSens);
            this.groupBox21.Controls.Add(this.comboBox_TiltTowSensState);
            this.groupBox21.Controls.Add(this.button18);
            this.groupBox21.Location = new System.Drawing.Point(510, 451);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(200, 100);
            this.groupBox21.TabIndex = 65;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "Tilt Tow Sensitivity";
            // 
            // maskedTextBox_TiltTowSens
            // 
            this.maskedTextBox_TiltTowSens.Location = new System.Drawing.Point(81, 32);
            this.maskedTextBox_TiltTowSens.Name = "maskedTextBox_TiltTowSens";
            this.maskedTextBox_TiltTowSens.Size = new System.Drawing.Size(100, 22);
            this.maskedTextBox_TiltTowSens.TabIndex = 83;
            // 
            // comboBox_TiltTowSensState
            // 
            this.comboBox_TiltTowSensState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_TiltTowSensState.FormattingEnabled = true;
            this.comboBox_TiltTowSensState.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_TiltTowSensState.Location = new System.Drawing.Point(17, 32);
            this.comboBox_TiltTowSensState.Name = "comboBox_TiltTowSensState";
            this.comboBox_TiltTowSensState.Size = new System.Drawing.Size(58, 21);
            this.comboBox_TiltTowSensState.TabIndex = 82;
            this.comboBox_TiltTowSensState.Text = "State";
            // 
            // button18
            // 
            this.button18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button18.Location = new System.Drawing.Point(17, 59);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(140, 26);
            this.button18.TabIndex = 61;
            this.button18.Text = "Tilt/Tow Sensitivity";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.Button18_Click);
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.maskedTextBox_HitSensitivity);
            this.groupBox20.Controls.Add(this.comboBox_HitState);
            this.groupBox20.Controls.Add(this.button17);
            this.groupBox20.Location = new System.Drawing.Point(510, 345);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(200, 100);
            this.groupBox20.TabIndex = 64;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Hit Sensitivity";
            // 
            // maskedTextBox_HitSensitivity
            // 
            this.maskedTextBox_HitSensitivity.Location = new System.Drawing.Point(81, 32);
            this.maskedTextBox_HitSensitivity.Name = "maskedTextBox_HitSensitivity";
            this.maskedTextBox_HitSensitivity.Size = new System.Drawing.Size(100, 22);
            this.maskedTextBox_HitSensitivity.TabIndex = 82;
            // 
            // comboBox_HitState
            // 
            this.comboBox_HitState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_HitState.FormattingEnabled = true;
            this.comboBox_HitState.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_HitState.Location = new System.Drawing.Point(17, 32);
            this.comboBox_HitState.Name = "comboBox_HitState";
            this.comboBox_HitState.Size = new System.Drawing.Size(58, 21);
            this.comboBox_HitState.TabIndex = 62;
            this.comboBox_HitState.Text = "State";
            // 
            // button17
            // 
            this.button17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button17.Location = new System.Drawing.Point(17, 59);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(140, 26);
            this.button17.TabIndex = 61;
            this.button17.Text = "Hit Sensitivity";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.Button17_Click);
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.maskedTextBox_ShockDetectNum);
            this.groupBox19.Controls.Add(this.maskedTextBox_ShockWindow);
            this.groupBox19.Controls.Add(this.comboBox_ShockState);
            this.groupBox19.Controls.Add(this.button16);
            this.groupBox19.Location = new System.Drawing.Point(718, 276);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(200, 100);
            this.groupBox19.TabIndex = 63;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Config Shock";
            // 
            // maskedTextBox_ShockDetectNum
            // 
            this.maskedTextBox_ShockDetectNum.Location = new System.Drawing.Point(111, 24);
            this.maskedTextBox_ShockDetectNum.Name = "maskedTextBox_ShockDetectNum";
            this.maskedTextBox_ShockDetectNum.Size = new System.Drawing.Size(46, 22);
            this.maskedTextBox_ShockDetectNum.TabIndex = 82;
            // 
            // maskedTextBox_ShockWindow
            // 
            this.maskedTextBox_ShockWindow.Location = new System.Drawing.Point(59, 24);
            this.maskedTextBox_ShockWindow.Name = "maskedTextBox_ShockWindow";
            this.maskedTextBox_ShockWindow.Size = new System.Drawing.Size(41, 22);
            this.maskedTextBox_ShockWindow.TabIndex = 81;
            // 
            // comboBox_ShockState
            // 
            this.comboBox_ShockState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_ShockState.FormattingEnabled = true;
            this.comboBox_ShockState.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_ShockState.Location = new System.Drawing.Point(1, 24);
            this.comboBox_ShockState.Name = "comboBox_ShockState";
            this.comboBox_ShockState.Size = new System.Drawing.Size(48, 21);
            this.comboBox_ShockState.TabIndex = 61;
            this.comboBox_ShockState.Text = "State";
            // 
            // button16
            // 
            this.button16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button16.Location = new System.Drawing.Point(6, 54);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(140, 26);
            this.button16.TabIndex = 42;
            this.button16.Text = "Config Shock";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.Button16_Click);
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.maskedTextBox_TiltDetectNum);
            this.groupBox18.Controls.Add(this.maskedTextBox_TiltWindow);
            this.groupBox18.Controls.Add(this.maskedTextBox_TiltAngle);
            this.groupBox18.Controls.Add(this.comboBox1_TiltState);
            this.groupBox18.Controls.Add(this.button15);
            this.groupBox18.Location = new System.Drawing.Point(718, 170);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(200, 100);
            this.groupBox18.TabIndex = 62;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Config Tow";
            // 
            // maskedTextBox_TiltDetectNum
            // 
            this.maskedTextBox_TiltDetectNum.Location = new System.Drawing.Point(100, 29);
            this.maskedTextBox_TiltDetectNum.Name = "maskedTextBox_TiltDetectNum";
            this.maskedTextBox_TiltDetectNum.Size = new System.Drawing.Size(42, 22);
            this.maskedTextBox_TiltDetectNum.TabIndex = 83;
            // 
            // maskedTextBox_TiltWindow
            // 
            this.maskedTextBox_TiltWindow.Location = new System.Drawing.Point(53, 29);
            this.maskedTextBox_TiltWindow.Name = "maskedTextBox_TiltWindow";
            this.maskedTextBox_TiltWindow.Size = new System.Drawing.Size(41, 22);
            this.maskedTextBox_TiltWindow.TabIndex = 82;
            // 
            // maskedTextBox_TiltAngle
            // 
            this.maskedTextBox_TiltAngle.Location = new System.Drawing.Point(10, 29);
            this.maskedTextBox_TiltAngle.Name = "maskedTextBox_TiltAngle";
            this.maskedTextBox_TiltAngle.Size = new System.Drawing.Size(37, 22);
            this.maskedTextBox_TiltAngle.TabIndex = 81;
            // 
            // comboBox1_TiltState
            // 
            this.comboBox1_TiltState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1_TiltState.FormattingEnabled = true;
            this.comboBox1_TiltState.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox1_TiltState.Location = new System.Drawing.Point(152, 29);
            this.comboBox1_TiltState.Name = "comboBox1_TiltState";
            this.comboBox1_TiltState.Size = new System.Drawing.Size(42, 21);
            this.comboBox1_TiltState.TabIndex = 38;
            this.comboBox1_TiltState.Text = "State";
            // 
            // button15
            // 
            this.button15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button15.Location = new System.Drawing.Point(6, 56);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(140, 26);
            this.button15.TabIndex = 42;
            this.button15.Text = "Config Tilt";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.Button15_Click);
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.maskedTextBox_TowDetectNum);
            this.groupBox17.Controls.Add(this.maskedTextBox_TowWindow);
            this.groupBox17.Controls.Add(this.maskedTextBox_TowAngle);
            this.groupBox17.Controls.Add(this.button14);
            this.groupBox17.Location = new System.Drawing.Point(516, 17);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(157, 100);
            this.groupBox17.TabIndex = 61;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Tow Configuration";
            // 
            // maskedTextBox_TowDetectNum
            // 
            this.maskedTextBox_TowDetectNum.Location = new System.Drawing.Point(100, 24);
            this.maskedTextBox_TowDetectNum.Name = "maskedTextBox_TowDetectNum";
            this.maskedTextBox_TowDetectNum.Size = new System.Drawing.Size(42, 22);
            this.maskedTextBox_TowDetectNum.TabIndex = 80;
            // 
            // maskedTextBox_TowWindow
            // 
            this.maskedTextBox_TowWindow.Location = new System.Drawing.Point(53, 24);
            this.maskedTextBox_TowWindow.Name = "maskedTextBox_TowWindow";
            this.maskedTextBox_TowWindow.Size = new System.Drawing.Size(41, 22);
            this.maskedTextBox_TowWindow.TabIndex = 79;
            // 
            // maskedTextBox_TowAngle
            // 
            this.maskedTextBox_TowAngle.Location = new System.Drawing.Point(10, 24);
            this.maskedTextBox_TowAngle.Name = "maskedTextBox_TowAngle";
            this.maskedTextBox_TowAngle.Size = new System.Drawing.Size(37, 22);
            this.maskedTextBox_TowAngle.TabIndex = 78;
            // 
            // button14
            // 
            this.button14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.Location = new System.Drawing.Point(6, 54);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(140, 26);
            this.button14.TabIndex = 42;
            this.button14.Text = "Config Tow";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.Button14_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.comboBox_SleepPolicy);
            this.groupBox11.Controls.Add(this.button12);
            this.groupBox11.Location = new System.Drawing.Point(15, 598);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(167, 84);
            this.groupBox11.TabIndex = 57;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Sleep Policy";
            // 
            // comboBox_SleepPolicy
            // 
            this.comboBox_SleepPolicy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_SleepPolicy.FormattingEnabled = true;
            this.comboBox_SleepPolicy.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.comboBox_SleepPolicy.Location = new System.Drawing.Point(6, 27);
            this.comboBox_SleepPolicy.Name = "comboBox_SleepPolicy";
            this.comboBox_SleepPolicy.Size = new System.Drawing.Size(80, 21);
            this.comboBox_SleepPolicy.TabIndex = 47;
            this.comboBox_SleepPolicy.Text = "Sleep Policy";
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.Location = new System.Drawing.Point(6, 51);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(152, 26);
            this.button12.TabIndex = 48;
            this.button12.Text = "Set Sleep Policy";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.Button12_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.comboBox_AlarmPilicy);
            this.groupBox10.Controls.Add(this.button11);
            this.groupBox10.Location = new System.Drawing.Point(15, 492);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(166, 100);
            this.groupBox10.TabIndex = 56;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Set Alarm Configuration";
            // 
            // comboBox_AlarmPilicy
            // 
            this.comboBox_AlarmPilicy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_AlarmPilicy.FormattingEnabled = true;
            this.comboBox_AlarmPilicy.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.comboBox_AlarmPilicy.Location = new System.Drawing.Point(8, 28);
            this.comboBox_AlarmPilicy.Name = "comboBox_AlarmPilicy";
            this.comboBox_AlarmPilicy.Size = new System.Drawing.Size(80, 21);
            this.comboBox_AlarmPilicy.TabIndex = 42;
            this.comboBox_AlarmPilicy.Text = "Alarm Policy";
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Location = new System.Drawing.Point(8, 52);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(152, 26);
            this.button11.TabIndex = 43;
            this.button11.Text = "Set Alarm Policy";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.Button11_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.dateTimePicker_SetTimeDate);
            this.groupBox9.Controls.Add(this.button10);
            this.groupBox9.Location = new System.Drawing.Point(353, 193);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(204, 81);
            this.groupBox9.TabIndex = 55;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Set Time and Date";
            // 
            // dateTimePicker_SetTimeDate
            // 
            this.dateTimePicker_SetTimeDate.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dateTimePicker_SetTimeDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_SetTimeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_SetTimeDate.Location = new System.Drawing.Point(6, 20);
            this.dateTimePicker_SetTimeDate.Name = "dateTimePicker_SetTimeDate";
            this.dateTimePicker_SetTimeDate.Size = new System.Drawing.Size(179, 21);
            this.dateTimePicker_SetTimeDate.TabIndex = 41;
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Location = new System.Drawing.Point(6, 47);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(87, 26);
            this.button10.TabIndex = 40;
            this.button10.Text = "Time Date Config";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.Button10_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.comboBox_BatThreshold);
            this.groupBox8.Controls.Add(this.button9);
            this.groupBox8.Location = new System.Drawing.Point(187, 183);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(160, 91);
            this.groupBox8.TabIndex = 54;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Vehicle Battery threshold ";
            this.toolTip1.SetToolTip(this.groupBox8, "Set Vehicle Battery threshold ");
            // 
            // comboBox_BatThreshold
            // 
            this.comboBox_BatThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_BatThreshold.FormattingEnabled = true;
            this.comboBox_BatThreshold.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboBox_BatThreshold.Location = new System.Drawing.Point(6, 20);
            this.comboBox_BatThreshold.Name = "comboBox_BatThreshold";
            this.comboBox_BatThreshold.Size = new System.Drawing.Size(49, 21);
            this.comboBox_BatThreshold.TabIndex = 39;
            this.toolTip1.SetToolTip(this.comboBox_BatThreshold, "Battery");
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(6, 47);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(135, 26);
            this.button9.TabIndex = 38;
            this.button9.Text = "Vehicle Battery";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.Button9_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.maskedTextBox_OutputDuration);
            this.groupBox7.Controls.Add(this.comboBox_OutputNum);
            this.groupBox7.Controls.Add(this.comboBox_OutputControl);
            this.groupBox7.Controls.Add(this.button8);
            this.groupBox7.Controls.Add(this.comboBox_OutputPulseLevel);
            this.groupBox7.Location = new System.Drawing.Point(9, 386);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(215, 94);
            this.groupBox7.TabIndex = 12;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Set Input Config";
            // 
            // maskedTextBox_OutputDuration
            // 
            this.maskedTextBox_OutputDuration.Location = new System.Drawing.Point(164, 48);
            this.maskedTextBox_OutputDuration.Name = "maskedTextBox_OutputDuration";
            this.maskedTextBox_OutputDuration.Size = new System.Drawing.Size(39, 22);
            this.maskedTextBox_OutputDuration.TabIndex = 38;
            // 
            // comboBox_OutputNum
            // 
            this.comboBox_OutputNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_OutputNum.FormattingEnabled = true;
            this.comboBox_OutputNum.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBox_OutputNum.Location = new System.Drawing.Point(6, 20);
            this.comboBox_OutputNum.Name = "comboBox_OutputNum";
            this.comboBox_OutputNum.Size = new System.Drawing.Size(71, 21);
            this.comboBox_OutputNum.TabIndex = 33;
            this.comboBox_OutputNum.Text = "Output Num";
            // 
            // comboBox_OutputControl
            // 
            this.comboBox_OutputControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_OutputControl.FormattingEnabled = true;
            this.comboBox_OutputControl.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_OutputControl.Location = new System.Drawing.Point(83, 20);
            this.comboBox_OutputControl.Name = "comboBox_OutputControl";
            this.comboBox_OutputControl.Size = new System.Drawing.Size(71, 21);
            this.comboBox_OutputControl.TabIndex = 34;
            this.comboBox_OutputControl.Text = "Cntl";
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(5, 47);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(152, 26);
            this.button8.TabIndex = 36;
            this.button8.Text = "Set Output Config";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.Button8_Click);
            // 
            // comboBox_OutputPulseLevel
            // 
            this.comboBox_OutputPulseLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_OutputPulseLevel.FormattingEnabled = true;
            this.comboBox_OutputPulseLevel.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_OutputPulseLevel.Location = new System.Drawing.Point(160, 20);
            this.comboBox_OutputPulseLevel.Name = "comboBox_OutputPulseLevel";
            this.comboBox_OutputPulseLevel.Size = new System.Drawing.Size(43, 21);
            this.comboBox_OutputPulseLevel.TabIndex = 37;
            this.comboBox_OutputPulseLevel.Text = "Pulse\\Level";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.maskedTextBox_InputDuration);
            this.groupBox6.Controls.Add(this.comboBox_InputNum1);
            this.groupBox6.Controls.Add(this.comboBox_Interupt);
            this.groupBox6.Controls.Add(this.button7);
            this.groupBox6.Location = new System.Drawing.Point(9, 280);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(215, 100);
            this.groupBox6.TabIndex = 53;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Input Configuration";
            // 
            // maskedTextBox_InputDuration
            // 
            this.maskedTextBox_InputDuration.Location = new System.Drawing.Point(157, 31);
            this.maskedTextBox_InputDuration.Name = "maskedTextBox_InputDuration";
            this.maskedTextBox_InputDuration.Size = new System.Drawing.Size(46, 22);
            this.maskedTextBox_InputDuration.TabIndex = 33;
            // 
            // comboBox_InputNum1
            // 
            this.comboBox_InputNum1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_InputNum1.FormattingEnabled = true;
            this.comboBox_InputNum1.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_InputNum1.Location = new System.Drawing.Point(6, 31);
            this.comboBox_InputNum1.Name = "comboBox_InputNum1";
            this.comboBox_InputNum1.Size = new System.Drawing.Size(71, 21);
            this.comboBox_InputNum1.TabIndex = 29;
            this.comboBox_InputNum1.Text = "Input Num";
            // 
            // comboBox_Interupt
            // 
            this.comboBox_Interupt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Interupt.FormattingEnabled = true;
            this.comboBox_Interupt.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_Interupt.Location = new System.Drawing.Point(83, 31);
            this.comboBox_Interupt.Name = "comboBox_Interupt";
            this.comboBox_Interupt.Size = new System.Drawing.Size(71, 21);
            this.comboBox_Interupt.TabIndex = 30;
            this.comboBox_Interupt.Text = "Interrupt";
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(5, 58);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(152, 26);
            this.button7.TabIndex = 32;
            this.button7.Text = "Set Input Config";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.Button7_Click);
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.btn_ChangePassword);
            this.groupBox13.Controls.Add(this.textBox_NewPassword);
            this.groupBox13.Location = new System.Drawing.Point(9, 174);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(172, 100);
            this.groupBox13.TabIndex = 52;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Change Password";
            // 
            // btn_ChangePassword
            // 
            this.btn_ChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ChangePassword.Location = new System.Drawing.Point(8, 48);
            this.btn_ChangePassword.Name = "btn_ChangePassword";
            this.btn_ChangePassword.Size = new System.Drawing.Size(152, 26);
            this.btn_ChangePassword.TabIndex = 28;
            this.btn_ChangePassword.Text = "Change Password";
            this.btn_ChangePassword.UseVisualStyleBackColor = true;
            // 
            // textBox_NewPassword
            // 
            this.textBox_NewPassword.Location = new System.Drawing.Point(6, 19);
            this.textBox_NewPassword.Name = "textBox_NewPassword";
            this.textBox_NewPassword.Size = new System.Drawing.Size(120, 22);
            this.textBox_NewPassword.TabIndex = 27;
            this.toolTip1.SetToolTip(this.textBox_NewPassword, "New Password");
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.comboBox_SMSControl);
            this.groupBox14.Controls.Add(this.button_SMSControl);
            this.groupBox14.Location = new System.Drawing.Point(187, 105);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(122, 80);
            this.groupBox14.TabIndex = 51;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "SMS Control";
            // 
            // comboBox_SMSControl
            // 
            this.comboBox_SMSControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_SMSControl.FormattingEnabled = true;
            this.comboBox_SMSControl.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_SMSControl.Location = new System.Drawing.Point(6, 20);
            this.comboBox_SMSControl.Name = "comboBox_SMSControl";
            this.comboBox_SMSControl.Size = new System.Drawing.Size(101, 21);
            this.comboBox_SMSControl.TabIndex = 25;
            this.toolTip1.SetToolTip(this.comboBox_SMSControl, "SMS Cntl");
            // 
            // button_SMSControl
            // 
            this.button_SMSControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_SMSControl.Location = new System.Drawing.Point(6, 47);
            this.button_SMSControl.Name = "button_SMSControl";
            this.button_SMSControl.Size = new System.Drawing.Size(113, 26);
            this.button_SMSControl.TabIndex = 26;
            this.button_SMSControl.Text = "SMS Control";
            this.button_SMSControl.UseVisualStyleBackColor = true;
            this.button_SMSControl.Click += new System.EventHandler(this.Button_SMSControl_Click);
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.textBox_FreeText);
            this.groupBox15.Controls.Add(this.comboBox_InputIndex);
            this.groupBox15.Controls.Add(this.button_SetFreeText);
            this.groupBox15.Location = new System.Drawing.Point(187, 24);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(141, 75);
            this.groupBox15.TabIndex = 50;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Set Input Free Text";
            // 
            // textBox_FreeText
            // 
            this.textBox_FreeText.Location = new System.Drawing.Point(52, 16);
            this.textBox_FreeText.Name = "textBox_FreeText";
            this.textBox_FreeText.Size = new System.Drawing.Size(67, 22);
            this.textBox_FreeText.TabIndex = 25;
            // 
            // comboBox_InputIndex
            // 
            this.comboBox_InputIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_InputIndex.FormattingEnabled = true;
            this.comboBox_InputIndex.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBox_InputIndex.Location = new System.Drawing.Point(8, 17);
            this.comboBox_InputIndex.Name = "comboBox_InputIndex";
            this.comboBox_InputIndex.Size = new System.Drawing.Size(37, 21);
            this.comboBox_InputIndex.TabIndex = 20;
            this.toolTip1.SetToolTip(this.comboBox_InputIndex, "Input index");
            // 
            // button_SetFreeText
            // 
            this.button_SetFreeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_SetFreeText.Location = new System.Drawing.Point(8, 40);
            this.button_SetFreeText.Name = "button_SetFreeText";
            this.button_SetFreeText.Size = new System.Drawing.Size(111, 26);
            this.button_SetFreeText.TabIndex = 24;
            this.button_SetFreeText.Text = "Set Free Text";
            this.button_SetFreeText.UseVisualStyleBackColor = true;
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.maskedTextBox3_Subscriber3);
            this.groupBox16.Controls.Add(this.maskedTextBox2_Subscriber2);
            this.groupBox16.Controls.Add(this.maskedTextBox1_Subscriber1);
            this.groupBox16.Controls.Add(this.button4);
            this.groupBox16.Location = new System.Drawing.Point(9, 20);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(172, 149);
            this.groupBox16.TabIndex = 20;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Subscribers";
            // 
            // maskedTextBox3_Subscriber3
            // 
            this.maskedTextBox3_Subscriber3.Location = new System.Drawing.Point(8, 76);
            this.maskedTextBox3_Subscriber3.Name = "maskedTextBox3_Subscriber3";
            this.maskedTextBox3_Subscriber3.Size = new System.Drawing.Size(153, 22);
            this.maskedTextBox3_Subscriber3.TabIndex = 28;
            // 
            // maskedTextBox2_Subscriber2
            // 
            this.maskedTextBox2_Subscriber2.Location = new System.Drawing.Point(8, 49);
            this.maskedTextBox2_Subscriber2.Name = "maskedTextBox2_Subscriber2";
            this.maskedTextBox2_Subscriber2.Size = new System.Drawing.Size(153, 22);
            this.maskedTextBox2_Subscriber2.TabIndex = 27;
            // 
            // maskedTextBox1_Subscriber1
            // 
            this.maskedTextBox1_Subscriber1.Location = new System.Drawing.Point(8, 24);
            this.maskedTextBox1_Subscriber1.Name = "maskedTextBox1_Subscriber1";
            this.maskedTextBox1_Subscriber1.Size = new System.Drawing.Size(153, 22);
            this.maskedTextBox1_Subscriber1.TabIndex = 26;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(6, 107);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(154, 26);
            this.button4.TabIndex = 20;
            this.button4.Text = "Set Subscribers";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 24);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1406, 776);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "S1 Requests and Qureies";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // textBox_SMSPhoneNumber
            // 
            this.textBox_SMSPhoneNumber.Location = new System.Drawing.Point(6, 22);
            this.textBox_SMSPhoneNumber.Name = "textBox_SMSPhoneNumber";
            this.textBox_SMSPhoneNumber.Size = new System.Drawing.Size(156, 26);
            this.textBox_SMSPhoneNumber.TabIndex = 10;
            this.toolTip2.SetToolTip(this.textBox_SMSPhoneNumber, "Phone number throgh SMS");
            this.toolTip1.SetToolTip(this.textBox_SMSPhoneNumber, "Phone number throgh SMS");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer_General_100ms
            // 
            this.timer_General_100ms.Enabled = true;
            this.timer_General_100ms.Tick += new System.EventHandler(this.Timer_ConectionKeepAlive_Tick);
            // 
            // timer_General_1Second
            // 
            this.timer_General_1Second.Enabled = true;
            this.timer_General_1Second.Interval = 1000;
            this.timer_General_1Second.Tick += new System.EventHandler(this.Timer_General_Tick);
            // 
            // groupBox36
            // 
            this.groupBox36.Location = new System.Drawing.Point(0, -60);
            this.groupBox36.Name = "groupBox36";
            this.groupBox36.Size = new System.Drawing.Size(138, 57);
            this.groupBox36.TabIndex = 11;
            this.groupBox36.TabStop = false;
            this.groupBox36.Text = "Comm Interface";
            // 
            // groupBox_PhoneNumber
            // 
            this.groupBox_PhoneNumber.Controls.Add(this.textBox_SMSPhoneNumber);
            this.groupBox_PhoneNumber.Location = new System.Drawing.Point(973, 5);
            this.groupBox_PhoneNumber.Name = "groupBox_PhoneNumber";
            this.groupBox_PhoneNumber.Size = new System.Drawing.Size(172, 55);
            this.groupBox_PhoneNumber.TabIndex = 12;
            this.groupBox_PhoneNumber.TabStop = false;
            this.groupBox_PhoneNumber.Text = "Phone Number";
            this.groupBox_PhoneNumber.Visible = false;
            // 
            // Label_SerialPortRx
            // 
            this.Label_SerialPortRx.AutoSize = true;
            this.Label_SerialPortRx.Location = new System.Drawing.Point(21, 54);
            this.Label_SerialPortRx.Name = "Label_SerialPortRx";
            this.Label_SerialPortRx.Size = new System.Drawing.Size(23, 18);
            this.Label_SerialPortRx.TabIndex = 108;
            this.Label_SerialPortRx.Text = "Rx";
            // 
            // label_SerialPortConnected
            // 
            this.label_SerialPortConnected.AutoSize = true;
            this.label_SerialPortConnected.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SerialPortConnected.Location = new System.Drawing.Point(17, 29);
            this.label_SerialPortConnected.Name = "label_SerialPortConnected";
            this.label_SerialPortConnected.Size = new System.Drawing.Size(69, 18);
            this.label_SerialPortConnected.TabIndex = 109;
            this.label_SerialPortConnected.Text = "Conneted";
            // 
            // Label_SerialPortTx
            // 
            this.Label_SerialPortTx.AutoSize = true;
            this.Label_SerialPortTx.Location = new System.Drawing.Point(65, 54);
            this.Label_SerialPortTx.Name = "Label_SerialPortTx";
            this.Label_SerialPortTx.Size = new System.Drawing.Size(21, 18);
            this.Label_SerialPortTx.TabIndex = 110;
            this.Label_SerialPortTx.Text = "Tx";
            // 
            // groupBox_SerialPort
            // 
            this.groupBox_SerialPort.Controls.Add(this.label_SerialPortStatus);
            this.groupBox_SerialPort.Controls.Add(this.Label_SerialPortTx);
            this.groupBox_SerialPort.Controls.Add(this.label_SerialPortConnected);
            this.groupBox_SerialPort.Controls.Add(this.Label_SerialPortRx);
            this.groupBox_SerialPort.Location = new System.Drawing.Point(1561, 77);
            this.groupBox_SerialPort.Name = "groupBox_SerialPort";
            this.groupBox_SerialPort.Size = new System.Drawing.Size(191, 106);
            this.groupBox_SerialPort.TabIndex = 111;
            this.groupBox_SerialPort.TabStop = false;
            this.groupBox_SerialPort.Text = "Serial port";
            this.groupBox_SerialPort.Enter += new System.EventHandler(this.groupBox_SerialPort_Enter);
            // 
            // label_SerialPortStatus
            // 
            this.label_SerialPortStatus.AutoSize = true;
            this.label_SerialPortStatus.Location = new System.Drawing.Point(95, 29);
            this.label_SerialPortStatus.Name = "label_SerialPortStatus";
            this.label_SerialPortStatus.Size = new System.Drawing.Size(42, 18);
            this.label_SerialPortStatus.TabIndex = 111;
            this.label_SerialPortStatus.Text = "None";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(5, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(180, 26);
            this.textBox1.TabIndex = 112;
            this.textBox1.TabStop = false;
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged_3);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox1_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_InternalCLIoutput);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(1561, 561);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 160);
            this.groupBox1.TabIndex = 112;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Internal CLI";
            // 
            // textBox_InternalCLIoutput
            // 
            this.textBox_InternalCLIoutput.Location = new System.Drawing.Point(5, 67);
            this.textBox_InternalCLIoutput.Multiline = true;
            this.textBox_InternalCLIoutput.Name = "textBox_InternalCLIoutput";
            this.textBox_InternalCLIoutput.ReadOnly = true;
            this.textBox_InternalCLIoutput.Size = new System.Drawing.Size(180, 87);
            this.textBox_InternalCLIoutput.TabIndex = 113;
            this.textBox_InternalCLIoutput.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox_SystemStatus);
            this.groupBox4.Location = new System.Drawing.Point(1561, 336);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(191, 217);
            this.groupBox4.TabIndex = 114;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "System status";
            // 
            // textBox_SystemStatus
            // 
            this.textBox_SystemStatus.Location = new System.Drawing.Point(5, 19);
            this.textBox_SystemStatus.Multiline = true;
            this.textBox_SystemStatus.Name = "textBox_SystemStatus";
            this.textBox_SystemStatus.ReadOnly = true;
            this.textBox_SystemStatus.Size = new System.Drawing.Size(180, 192);
            this.textBox_SystemStatus.TabIndex = 113;
            this.textBox_SystemStatus.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1561, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(191, 38);
            this.pictureBox1.TabIndex = 115;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox_ClentTCPStatus
            // 
            this.groupBox_ClentTCPStatus.Controls.Add(this.label_TCPClient);
            this.groupBox_ClentTCPStatus.Controls.Add(this.label12);
            this.groupBox_ClentTCPStatus.Controls.Add(this.label_ClientTCPConnected);
            this.groupBox_ClentTCPStatus.Controls.Add(this.label14);
            this.groupBox_ClentTCPStatus.Location = new System.Drawing.Point(1561, 192);
            this.groupBox_ClentTCPStatus.Name = "groupBox_ClentTCPStatus";
            this.groupBox_ClentTCPStatus.Size = new System.Drawing.Size(191, 106);
            this.groupBox_ClentTCPStatus.TabIndex = 112;
            this.groupBox_ClentTCPStatus.TabStop = false;
            this.groupBox_ClentTCPStatus.Text = "Client TCP";
            // 
            // label_TCPClient
            // 
            this.label_TCPClient.AutoSize = true;
            this.label_TCPClient.Location = new System.Drawing.Point(92, 29);
            this.label_TCPClient.Name = "label_TCPClient";
            this.label_TCPClient.Size = new System.Drawing.Size(45, 18);
            this.label_TCPClient.TabIndex = 111;
            this.label_TCPClient.Text = " None";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(65, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 18);
            this.label12.TabIndex = 110;
            this.label12.Text = "Tx";
            // 
            // label_ClientTCPConnected
            // 
            this.label_ClientTCPConnected.AutoSize = true;
            this.label_ClientTCPConnected.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ClientTCPConnected.Location = new System.Drawing.Point(17, 29);
            this.label_ClientTCPConnected.Name = "label_ClientTCPConnected";
            this.label_ClientTCPConnected.Size = new System.Drawing.Size(69, 18);
            this.label_ClientTCPConnected.TabIndex = 109;
            this.label_ClientTCPConnected.Text = "Conneted";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(21, 54);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 18);
            this.label14.TabIndex = 108;
            this.label14.Text = "Rx";
            // 
            // checkBox_ServerPause
            // 
            this.checkBox_ServerPause.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_ServerPause.AutoSize = true;
            this.checkBox_ServerPause.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_ServerPause.Location = new System.Drawing.Point(88, 578);
            this.checkBox_ServerPause.Name = "checkBox_ServerPause";
            this.checkBox_ServerPause.Size = new System.Drawing.Size(58, 29);
            this.checkBox_ServerPause.TabIndex = 107;
            this.checkBox_ServerPause.Text = "Pause";
            this.checkBox_ServerPause.UseVisualStyleBackColor = true;
            // 
            // checkBox_ServerRecord
            // 
            this.checkBox_ServerRecord.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_ServerRecord.AutoSize = true;
            this.checkBox_ServerRecord.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_ServerRecord.Location = new System.Drawing.Point(152, 578);
            this.checkBox_ServerRecord.Name = "checkBox_ServerRecord";
            this.checkBox_ServerRecord.Size = new System.Drawing.Size(64, 29);
            this.checkBox_ServerRecord.TabIndex = 108;
            this.checkBox_ServerRecord.Text = "Record";
            this.checkBox_ServerRecord.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.button86);
            this.tabPage9.Location = new System.Drawing.Point(4, 27);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(949, 604);
            this.tabPage9.TabIndex = 6;
            this.tabPage9.Text = "Extendend";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // button86
            // 
            this.button86.Location = new System.Drawing.Point(7, 8);
            this.button86.Name = "button86";
            this.button86.Size = new System.Drawing.Size(244, 23);
            this.button86.TabIndex = 50;
            this.button86.Text = "Get UBLOX data";
            this.button86.UseVisualStyleBackColor = true;
            this.button86.Click += new System.EventHandler(this.button86_Click);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 19);
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1801, 761);
            this.Controls.Add(this.groupBox_ClentTCPStatus);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.button_OpenFolder);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_SerialPort);
            this.Controls.Add(this.tabControl_Main);
            this.Controls.Add(this.groupBox36);
            this.Controls.Add(this.groupBox_PhoneNumber);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Monitor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed_1);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox_ServerSettings.ResumeLayout(false);
            this.groupBox_ServerSettings.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl_Main.ResumeLayout(false);
            this.tabPage_SMS.ResumeLayout(false);
            this.groupBox39.ResumeLayout(false);
            this.groupBox37.ResumeLayout(false);
            this.groupBox37.PerformLayout();
            this.groupBox35.ResumeLayout(false);
            this.groupBox35.PerformLayout();
            this.groupBox34.ResumeLayout(false);
            this.groupBox34.PerformLayout();
            this.GrooupBox_Encryption.ResumeLayout(false);
            this.GrooupBox_Encryption.PerformLayout();
            this.groupBox33.ResumeLayout(false);
            this.tabPage_Configuration.ResumeLayout(false);
            this.tabControl_systems.ResumeLayout(false);
            this.tabPage10.ResumeLayout(false);
            this.tabPage10.PerformLayout();
            this.groupBox38.ResumeLayout(false);
            this.tabPage_charts.ResumeLayout(false);
            this.tabPage_charts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage_SerialPort.ResumeLayout(false);
            this.groupBox_SendSerialOrMonitorCommands.ResumeLayout(false);
            this.groupBox_SendSerialOrMonitorCommands.PerformLayout();
            this.gbPortSettings.ResumeLayout(false);
            this.gbPortSettings.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox_Timer.ResumeLayout(false);
            this.groupBox_Timer.PerformLayout();
            this.groupBox_Stopwatch.ResumeLayout(false);
            this.groupBox_Stopwatch.PerformLayout();
            this.tabPage_ServerTCP.ResumeLayout(false);
            this.tabPage_ServerTCP.PerformLayout();
            this.groupBox_FOTA.ResumeLayout(false);
            this.groupBox_FOTA.PerformLayout();
            this.groupBox_ConnectionTimedOut.ResumeLayout(false);
            this.groupBox_ConnectionTimedOut.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage_ClientTCP.ResumeLayout(false);
            this.tabPage_ClientTCP.PerformLayout();
            this.tabPage_GenericFrame.ResumeLayout(false);
            this.groupBox31.ResumeLayout(false);
            this.groupBox31.PerformLayout();
            this.groupBox_clientTX.ResumeLayout(false);
            this.groupBox_clientTX.PerformLayout();
            this.tabPage_MiniAda.ResumeLayout(false);
            this.groupBox40.ResumeLayout(false);
            this.tabControl_MiniAda.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.groupBox32.ResumeLayout(false);
            this.groupBox32.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.S1_Configuration.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox22.ResumeLayout(false);
            this.groupBox22.PerformLayout();
            this.groupBox28.ResumeLayout(false);
            this.groupBox28.PerformLayout();
            this.groupBox30.ResumeLayout(false);
            this.groupBox30.PerformLayout();
            this.groupBox29.ResumeLayout(false);
            this.groupBox29.PerformLayout();
            this.groupBox27.ResumeLayout(false);
            this.groupBox27.PerformLayout();
            this.groupBox26.ResumeLayout(false);
            this.groupBox26.PerformLayout();
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            this.groupBox24.ResumeLayout(false);
            this.groupBox23.ResumeLayout(false);
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox_PhoneNumber.ResumeLayout(false);
            this.groupBox_PhoneNumber.PerformLayout();
            this.groupBox_SerialPort.ResumeLayout(false);
            this.groupBox_SerialPort.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox_ClentTCPStatus.ResumeLayout(false);
            this.groupBox_ClentTCPStatus.PerformLayout();
            this.tabPage9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        readonly List<String> CommandsHistoy = new List<String>();
        int HistoryIndex = -1;
       // bool SelfMonitorCommandsMode = false;
        

        private void TabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //Change appearance of tabcontrol
            Brush backBrush;
            Brush foreBrush;

            backBrush = new SolidBrush(Color.Red);
            foreBrush = new SolidBrush(Color.Blue);

            e.Graphics.FillRectangle(backBrush, e.Bounds);

            //You may need to write the label here also?
            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center
            };

            Rectangle r = e.Bounds;
            r = new Rectangle(r.X, r.Y + 3, r.Width, r.Height - 3);
            e.Graphics.DrawString("my label", e.Font, foreBrush, r, sf);
        }

        private void ListBox_SMSCommands_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            bool isItemSelected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
            int itemIndex = e.Index;
            if (itemIndex >= 0 && itemIndex < listBox_SMSCommands.Items.Count)
            {
                Graphics g = e.Graphics;

                // Background Color
                SolidBrush backgroundColorBrush = new SolidBrush((isItemSelected) ? Color.Red : Color.White);
                g.FillRectangle(backgroundColorBrush, e.Bounds);

                // Set text color
                string itemText = listBox_SMSCommands.Items[itemIndex].ToString();

                SolidBrush itemTextColorBrush = (isItemSelected) ? new SolidBrush(Color.White) : new SolidBrush(Color.Black);
                g.DrawString(itemText, e.Font, itemTextColorBrush, listBox_SMSCommands.GetItemRectangle(itemIndex).Location);

                // Clean up
                backgroundColorBrush.Dispose();
                itemTextColorBrush.Dispose();
            }

            e.DrawFocusRectangle();
        }

        void ListBox_SMSCommands_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveSelectedCommand();
            }
        }

        void CheckedListBox_PhoneBook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveSelectedContact();
            }
        }

        static Boolean PhoneBookIsChecked = false;
        void CheckedListBox_PhoneBook_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PhoneBookIsChecked = !PhoneBookIsChecked;

                if (PhoneBookIsChecked == true)
                {
                    for (int x = 0; x < checkedListBox_PhoneBook.Items.Count; x++)
                    {
                        checkedListBox_PhoneBook.SetItemChecked(x, true);
                    }
                }
                else
                {
                    for (int x = 0; x < checkedListBox_PhoneBook.Items.Count; x++)
                    {
                        checkedListBox_PhoneBook.SetItemChecked(x, false);
                    }
                }

            }
        }

        void TextBox_GeneralMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                // Then Enter key was pressed

                //button29.PerformClick();
            }
        }

        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.Run(new MainForm());


        }


    








        private void Button1_Click(object sender, System.EventArgs e)
        {
            if (comboBox_ConnectionNumber.Text == "None")
            {
                return;
            }
            try
            {
                //int ConNum = int.Parse(comboBox_ConnectionNumber.Text);
                string SendString =/*tempcount.ToString() + "  " +*/ txtDataTx.Text;
                Object objData = SendString;
                byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
                SendDataToServer(comboBox_ConnectionNumber.SelectedItem.ToString(), byData);
            }
            catch (Exception ex)
            {
                ServerLogger.LogMessage(Color.Orange, Color.White, ex.ToString(), true, true);
            }
        }

        bool SerialPortSMSSendData(byte[] i_SendData)
        {

            if (serialPort_SMS.IsOpen)
            {
                // Send the binary data out the port
                serialPort_SMS.Write(i_SendData, 0, i_SendData.Length);

                if (checkBox_DebugSMS.Checked == true)
                {
                    LogSMS.LogMessage(Color.Black, Color.LightGray, "", New_Line = false, Show_Time = true);
                    LogSMS.LogMessage(Color.DarkViolet, Color.LightGray, "Send Data: ", false, false);
                    LogSMS.LogMessage(Color.DarkGreen, Color.LightGray, Encoding.ASCII.GetString(i_SendData), true, false);
                }

                return true;

            }

            return false;
        }

        bool SerialPortSendData(byte[] i_SendData)
        {
            try
            {
                if (serialPort.IsOpen)
                {
                    // Send the binary data out the port
                    serialPort.Write(i_SendData, 0, i_SendData.Length);

                    return true;

                }
            }
            catch(Exception ex)
            {
                SendExceptionToTheMonitor(ex.Message.ToString());
                
            }


            return false;
        }

        private void SendExceptionToTheMonitor(String i_Message)
        {
            SerialPortLogger.LogMessage(Color.Red, Color.LightGray, i_Message, New_Line = true, Show_Time = true);
        }
        //Color oldColor;
        Gil_Server.Server m_Server;
        private void ListenBox_CheckedChanged(object sender, EventArgs e)
        {
            // Gil: Just to remove the warnings
            New_Line = !New_Line;
            Show_Time = !Show_Time;


            if (ListenBox.Checked)
            {
                //m_Exit = false;
                //oldColor = ListenBox.BackColor;
                ListenBox.BackColor = Color.Gray;
                try
                {


                    m_Server = new Gil_Server.Server(txtPortNo.Text);
                    m_Server.DataRecievedNotifyDelegate += new EventHandler(GilServer_DataRecievedNotifyDelegate);
                    m_Server.InformationNotifyDelegate += new EventHandler(Server_InformationNotifyDelegate);

                    m_Server.Open_Server();

                    txtPortNo.Enabled = false;



                }
                catch (SocketException se)
                {
                    ServerLogger.LogMessage(Color.Black, Color.White, "Exception:  " + se.ToString(), true, true);
                }
            }
            else
            {
                ListenBox.BackColor = default;

                m_Server.Close_Server();

                txtPortNo.Enabled = true;

            }
        }

        void Server_InformationNotifyDelegate(object sender, EventArgs e)
        {
            Gil_Server.Server.stringEventArgs mye = (Gil_Server.Server.stringEventArgs)e;

            ServerLogger.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
            ServerLogger.LogMessage(Color.Brown, Color.White, "[Internal Server] ", New_Line = false, Show_Time = false);
            ServerLogger.LogMessage(Color.Black, Color.White, mye.StrData, New_Line = true, Show_Time = false);
        }

        static int LastIgn = 1;
        static int TimerStatusRingWait = 0;

        //string[] UnitNumberToConnections = new string[30];
        readonly Dictionary<string, string> ConnectionToIDdictionary = new Dictionary<string, string>();
        readonly Dictionary<string, string> IDToFOTA_Status = new Dictionary<string, string>();
        void GilServer_DataRecievedNotifyDelegate(object sender, EventArgs e)
        {

            Gil_Server.Server.DataEventArgs mye = (Gil_Server.Server.DataEventArgs)e;

            ASCIIEncoding encoder = new ASCIIEncoding();

            // string IncomingString = System.Text.Encoding.Default.GetString(mye.BytesData);
            string IncomingString = ByteArrayToString(mye.BytesData.Take(40).ToArray());
            //IncomingString = IncomingString.Replace("\0", "");

            ServerLogger.LogMessage(Color.Black, Color.White, "\n\nData Received: ", New_Line = false, Show_Time = true);
            ServerLogger.LogMessage(Color.Blue, Color.White, "Connection: " + mye.ConnectionNumber, New_Line = false, Show_Time = false);
            //     ServerLogger.LogMessage(Color.Black, Color.White, " \" ", New_Line = false, Show_Time = false);
            ServerLogger.LogMessage(Color.DarkGreen, Color.White, "    " + IncomingString, New_Line = true, Show_Time = false);

            if (checkBox_EchoResponse.Checked == true)
            {

                string ACKBack = string.Format("[{0}],ACK", IncomingString);
                byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                SendDataToServer(mye.ConnectionNumber, b2);
            }


            if (checkBox_ParseMessages.Checked == false)
            {
                return;
            }

            string[] ParseStrings = { "" };
            string[] Key = { "" };
            try
            {
                if (IncomingString.Contains(","))
                {
                    ParseStrings = IncomingString.Split(',');
                    Key = ParseStrings[1].Split('=');
                }
            }
            catch
            {
                ServerLogger.LogMessage(Color.Black, Color.White, "Data Not Valid: " + IncomingString, New_Line = true, Show_Time = true);
                return;
            }

            //string[] UnitNumberToConnections = new List<string>();

            if (ConnectionToIDdictionary.ContainsKey(mye.ConnectionNumber) == false)
            {
                ConnectionToIDdictionary.Add(mye.ConnectionNumber, ParseStrings[0]);
            }
            PrintDictineryIDKeys();
            //UnitNumberToConnections[mye.ConnectionNumber] = ParseStrings[0];

            //dataSource.Add("None");
            //comboBox_ConnectionNumber.DataSource = dataSource;

            //comboBox_ConnectionNumber.DataSource = mye.ConnectionNumber + " " + IncomingString[0];

            if (Key[0] == "POS")
            {

                //if (checkBox_ServerView.Checked == true)
                //{

                //    LogIWatcher.LogMessage(Color.Brown, Color.White, "Source: Server", New_Line = false, Show_Time = true);
                //    LogIWatcher.LogMessage(Color.Brown, Color.White, "POSITION Message Received: ", New_Line = false, Show_Time = true);

                //    string PositionString =
                //        "\n UNIT ID = " + ParseStrings[0].Replace(";", "") +
                //        "\n STATE = " + Key[1] +
                //        "\n GSM LINK QUALITY = " + ParseStrings[2] +
                //        "\n GPS STATUS = " + ParseStrings[3] +
                //        "\n GPS NUM OF SATELLITES = " + ParseStrings[4] +
                //        "\n CURRENT TIME AND DATE = " + ParseStrings[5] + " " + ParseStrings[6] +
                //        "\n LAST GPS TIME AND DATE = " + ParseStrings[7] + " " + ParseStrings[8] +
                //        "\n GPS LATITUDE = " + ParseStrings[9] +
                //        "\n GPS LONGTITUDE = " + ParseStrings[10] +
                //        "\n GPS SPEED = " + ParseStrings[11] +
                //        "\n GPS DIRECTION =" + ParseStrings[12] +
                //        "\n TRIP DISTANCE  = " + ParseStrings[13] +
                //        "\n TOTAL DISTANCE = " + ParseStrings[14] +
                //        "\n ANALOG 1  = " + ParseStrings[15] +
                //        "\n ANALOG 2  = " + ParseStrings[16] +
                //        "\n MESSAGE NUMBER  = " + ParseStrings[17];
                //    //  "\n GPRS MESSAGE  NUMBER = " + PosStrings[15];

                //    //string.Format("\n UNIT ID = {0} \n STATE = {1}\n GSM LINK QUALITY = {2}", PosStrings[0].Replace(";",""), Key[1], PosStrings[2]); 
                //    LogIWatcher.LogMessage(Color.Brown, Color.White, PositionString, New_Line = true, Show_Time = false);
                //}

              //  string ret = "";
                //if (checkBox_ShowURL.Checked)
                //{
                //    ret = "http://maps.google.com/maps?q=" + ParseStrings[9] + "," + ParseStrings[10] + "( " + " Current Time: " + DateTime.Now + "\r\n   S1TimeStamp: " + " )" + "&z=14&ll=" + "," + "&z=17";
                //    Show_WebBrowserUrl(ret);
                //}

                //if (checkBox_RecordLatLong.Checked)
                //{

                //    NumOfPositionMessage++;
                //    //354869050154426,POS=1,GSMLinkQual,5,8,12/9/2013,10:55:11,12/9/2013,10:55:11,32.155636,34.920308,0,304.2,


                //    KMl_text.Add("<Placemark>");
                //    KMl_text.Add("<name>" + "[" + NumOfPositionMessage + "]" + " " + DateTime.Now + "  </name>");
                //    KMl_text.Add("<Point>");
                //    KMl_text.Add("<coordinates>" + ParseStrings[10] + "," + ParseStrings[9] + "</coordinates> ");
                //    KMl_text.Add("</Point>");
                //    KMl_text.Add("</Placemark> ");
                //    KMl_text.Add("</Document> \n");
                //    KMl_text.Add("</kml> \n");

                //    File.Delete(log_file_S1_LatLong);
                //    using (System.IO.StreamWriter file = new System.IO.StreamWriter(log_file_S1_LatLong))
                //    {
                //        foreach (string str in KMl_text)
                //        {
                //            file.WriteLine(str);
                //        }
                //        //for (int i = 0; i < KML_Index; i++)
                //        //{

                //        //}
                //        KMl_text.RemoveAt(KMl_text.Count - 1);
                //        KMl_text.RemoveAt(KMl_text.Count - 1);
                //        // KML_Index -= 2;
                //    }


                //}

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ParseStrings[0], ParseStrings[ParseStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }


            }
            else
            if (Key[0] == "STAT")
            {

                //if (checkBox_ServerView.Checked == true)
                //{

                //    LogIWatcher.LogMessage(Color.Brown, Color.White, "Source: Server", New_Line = false, Show_Time = true);
                //    LogIWatcher.LogMessage(Color.Red, Color.White, "STATUS Message Received: ", New_Line = false, Show_Time = true);

                //    string PositionString =
                //        "\n UNIT ID = " + ParseStrings[0].Replace(";", "") +
                //        "\n SYSTEM STATE = " + Key[1] +
                //        "\n IGN STATE = " + ParseStrings[2] +
                //        "\n GP1 = " + ParseStrings[3] +
                //        "\n GP2 = " + ParseStrings[4] +
                //        "\n GP3 = " + ParseStrings[5] +
                //        "\n Main Power Source = " + ParseStrings[6] +
                //        "\n Back Up Battery problem indication = " + ParseStrings[7] +
                //        "\n OUTPUT 1  STATE = " + ParseStrings[8] +
                //        "\n OUTPUT 2  STATE = " + ParseStrings[9] +
                //        "\n OUTPUT 3  STATE = " + ParseStrings[10] +
                //        "\n OUTPUT 4  STATE = " + ParseStrings[11] +
                //        "\n DATE = " + ParseStrings[12] +
                //        "\n TIME  = " + ParseStrings[13] +
                //        "\n GPS LATITUDE = " + ParseStrings[14] +
                //        "\n GPS LONGTITUDE = " + ParseStrings[15] +
                //        "\n VEHICLE SPEED = " + ParseStrings[16] +
                //        "\n SPEED EVENT  = " + ParseStrings[17] +
                //        "\n BATTERY LOW EVENT =" + ParseStrings[18] +
                //        "\n BATTERY CUT OFF EVENT  = " + ParseStrings[19] +
                //        "\n ACCIDENT EVENT = " + ParseStrings[20] +
                //        "\n TOWING EVENT = " + ParseStrings[21] +
                //        "\n TILT EVENT = " + ParseStrings[22] +
                //        "\n ANTI JAMMING  EVENT = " + ParseStrings[23] +
                //        "\n MESSAGE NUMBER = " + ParseStrings[24];
                //    //  "\n GPRS MESSAGE  NUMBER = " + PosStrings[15];

                //    //string.Format("\n UNIT ID = {0} \n STATE = {1}\n GSM LINK QUALITY = {2}", PosStrings[0].Replace(";",""), Key[1], PosStrings[2]); 
                //    LogIWatcher.LogMessage(Color.Red, Color.White, PositionString, New_Line = true, Show_Time = false);
                //}

                string[] ign = ParseStrings[1].Split('=');
                int Newign = int.Parse(ign[1]);
                if (Newign == 1 && LastIgn == 0)
                {
                    ServerLogger.LogMessage(Color.Blue, Color.White, "New Driving Log Opened", New_Line = true, Show_Time = true);

                    //checkBox_RecordLatLong.Invoke(new EventHandler(delegate
                    //{

                    //    checkBox_RecordLatLong.Checked = false;
                    //    checkBox_RecordLatLong.Checked = true;

                    //}));


                }

                LastIgn = Newign;

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ParseStrings[0], ParseStrings[ParseStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }

                // Gil: Comare if the Unit ID is the target Unit ID For encrypted GPRS
                if (TimerStatusRingWait > 0 && SendOneTimeFlag == 1)
                {
                    if (ParseStrings[0].Replace(";", "") == textBox_UnitIDForSMS.Text)
                    {
                        //TimerStatusRingWait = 0;
                        SendOneTimeFlag = 0;
                        byte[] b2 = System.Text.Encoding.ASCII.GetBytes(txtDataTx.Text);
                        SendDataToServer(mye.ConnectionNumber, b2);

                        button_Ring.Invoke(new EventHandler(delegate
                        {
                            button_Ring.BackColor = Color.Orange;
                        }));
                    }
                }
            }
            else
            if (ParseStrings[1].Contains("ACK"))
            {
                string[] ACKStrings = IncomingString.Split(',');

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ACKStrings[0], ACKStrings[ACKStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }

                if (Key[0] == OpcodeToCompare)
                {
                    OpcodeToCompare = "";
                    ServerLogger.LogMessage(Color.Black, Color.Yellow, "Command Recieved OK!! ", true, true);
                    button_Ring.Invoke(new EventHandler(delegate
                    {
                        button_Ring.BackColor = Color.Green;
                        button_Ring.Text = "Ring Ok";
                    }));

                }
            }
            else
            if (Key[0] == "SMSSTAT?")
            {

                string[] ACKStrings = IncomingString.Split(',');

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ACKStrings[0], ACKStrings[ACKStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }
            }
            else
                if (Key[0] == "FMS1" || Key[0] == "FMS2" || Key[0] == "FMS3")
            {

                string[] ACKStrings = IncomingString.Split(',');

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ACKStrings[0], ACKStrings[ACKStrings.Length - 1].Replace(";", ",;"));
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }

            }
            else
                    if (Key[0] == "MBL1")
            {


                string[] ACKStrings = IncomingString.Split(',');

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ACKStrings[0], ACKStrings[ACKStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }

            }
            else
                        if (Key[0] == "MBL2")
            {
                string[] ACKStrings = IncomingString.Split(',');

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ACKStrings[0], ACKStrings[ACKStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }

            }
            else
                    if (Key[0] == "OBD")
            {
                string[] ACKStrings = IncomingString.Split(',');

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ACKStrings[0], ACKStrings[ACKStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }

            }
            else
                        if (Key[0] == "GRM") //Gil: Garmin message
            {
                string[] ACKStrings = IncomingString.Split(',');

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ACKStrings[0], ACKStrings[ACKStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }

            }
            else
                            if (Key[0] == "DATA1") //Gil: Garmin message
            {


                string[] ACKStrings = IncomingString.Split(',');

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ACKStrings[0], ACKStrings[ACKStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }

            }
            else
            if (Key[0] == "GETCONFIG?")
            {
                string[] ACKStrings = IncomingString.Split(',');

                if (checkBox_EchoResponse.Checked == true)
                {
                    string ACKBack = string.Format("{0},ACK,{1}", ACKStrings[0], ACKStrings[ACKStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }

            }
            else
                if (Key[0] == "CONFIG")
            {

                string[] ACKStrings = IncomingString.Split(',');

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ACKStrings[0], ACKStrings[ACKStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }

                SendToConfigPage(IncomingString, "Server");

            }
            else
                        if (Key[0] == "FOTAU")
            {


                int PacketNumber = int.Parse(ParseStrings[2]);
                //int NumOfTransmitPackets = int.Parse(FOTAStrings[3]);
                //if (NumOfTransmitPackets > 5 || NumOfTransmitPackets < 1)
                //{
                //    ServerLogger.LogMessage(Color.Red, Color.White, "Warning: Number Of Received Packets is no between 1-5", New_Line = true, Show_Time = true);
                //    return;
                //}

                //byte[] buffer = new byte[256];
                if (ConfigFileName != null)
                {
                    // m_BinaryReader = new BinaryReader(File.Open(ConfigFileName, FileMode.Open));
                    string TotalStrToSend = string.Empty;
                    //for (int i = 0; i < NumOfTransmitPackets ; i++)
                    //{
                    int FrameNumber = (PacketNumber);
                    if (FrameNumber == 999999)
                    {
                        //textBox_FOTAEnd.Invoke(new EventHandler(delegate
                        //{
                        IDToFOTA_Status[ParseStrings[0].Replace(";", "")] = "Finish";

                        PrintFotaIDStatus();
                        //textBox_FOTAEnd.BackColor = Color.Green;
                        //textBox_FOTAEnd.Text = "Finish";
                        //}));

                        string ACKBack = string.Format("{0},ACK,{1}", ParseStrings[0], ParseStrings[ParseStrings.Length - 1].Replace(";", ",;"));
                        //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                        byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                        SendDataToServer(mye.ConnectionNumber, b2);
                    }
                    else
                        if (FrameNumber < int.Parse(textBox_TotalFrames1280Bytes.Text))
                    {


                        //m_BinaryReader.BaseStream.Position = 0;
                        //int PositionInFile = 1280 * FrameNumber;
                        //m_BinaryReader.ReadBytes(PositionInFile);
                        //byte[] buffer = new byte[1280];
                        //for(int i=0;i < 1280 ; i++)
                        //{
                        //    buffer[i] = 0x30;
                        //}
                        //byte[] temp = m_BinaryReader.ReadBytes(1280);

                        //temp.CopyTo(buffer, 0);
                        ////m_BinaryReader.Read(buffer, PositionInFile, 256);
                        //// CS,@%@, @$@FOTAS,PACK NUM,256 bytes
                        //string str = Encoding.ASCII.GetString(buffer);
                        //byte b = CalcCheckSumbuffer(buffer);
                        string SendString = string.Format("{0},{1},@%@", FOTAData[FrameNumber], ParseStrings[ParseStrings.Length - 1].Replace(";", ""));

                        TotalStrToSend = SendString;


                        IDToFOTA_Status[ParseStrings[0].Replace(";", "")] = FrameNumber.ToString() + " / " + textBox_TotalFrames1280Bytes.Text;

                        PrintFotaIDStatus();
                        //textBox_MaximumNumberReceivedRequest.Invoke(new EventHandler(delegate
                        //{
                        //    textBox_MaximumNumberReceivedRequest.Text = "";

                        //    IDToFOTA_Status[ParseStrings[0]] = FrameNumber.ToString();

                        //    foreach (var pair in IDToFOTA_Status)
                        //    {

                        //        textBox_MaximumNumberReceivedRequest.AppendText(pair.Key + " | " + pair.Value + " \n");

                        //    }

                        //    //textBox_MaximumNumberReceivedRequest.Text += "," + FrameNumber.ToString();
                        //    //textBox_MaximumNumberReceivedRequest.SelectionStart = textBox_MaximumNumberReceivedRequest.TextLength;
                        //    //textBox_MaximumNumberReceivedRequest.ScrollToCaret();

                        //}));
                    }
                    //}

                    if (TotalStrToSend != string.Empty)
                    {
                        byte[] ByteArr = Encoding.ASCII.GetBytes(TotalStrToSend);
                        byte[] DataToSend = new byte[1500];
                        for (int i = 0; i < 1500; i++)
                        {
                            DataToSend[i] = 0;
                        }

                        ByteArr.CopyTo(DataToSend, 0);
                        //ServerLogger.LogMessage(Color.Black, Color.White, "Send Data Length : " + ByteArr.Length, New_Line = true, Show_Time = true);
                        SendDataToServer(mye.ConnectionNumber, DataToSend);
                    }

                    m_BinaryReader.Close();

                }
                else
                {
                    ServerLogger.LogMessage(Color.Red, Color.White, "Warning: FOTA file wasn't Chosen", New_Line = true, Show_Time = true);
                }

            }



        }

        void PrintFotaIDStatus()
        {
            textBox_MaximumNumberReceivedRequest.Invoke(new EventHandler(delegate
            {
                textBox_MaximumNumberReceivedRequest.Text = "";



                foreach (var pair in IDToFOTA_Status)
                {
                    PhoneBookContact ContactFound = MyPhoneBook.GetContactByUnitID(pair.Key);

                    if (ContactFound != null)
                    {
                        textBox_MaximumNumberReceivedRequest.AppendText(ContactFound.Name + "   " + pair.Value + " \n");
                    }
                    else
                    {
                        textBox_MaximumNumberReceivedRequest.AppendText(pair.Key + "   " + pair.Value + " \n");
                    }
                }

                //textBox_MaximumNumberReceivedRequest.Text += "," + FrameNumber.ToString();
                //textBox_MaximumNumberReceivedRequest.SelectionStart = textBox_MaximumNumberReceivedRequest.TextLength;
                //textBox_MaximumNumberReceivedRequest.ScrollToCaret();

            }));
        }

        void SendToConfigPage(string i_ConfigString, string i_Source)
        {
            bool SuccessParse = ParseConfigString(i_ConfigString);

            if (SuccessParse == true)
            {
                textBox_SourceConfig.Invoke(new EventHandler(delegate
                {
                    textBox_SourceConfig.Text = "Configuration Loaded successfully from " + i_Source + "\nDate: " + DateTime.Now.ToString();
                    textBox_SourceConfig.BackColor = Color.LightGreen;
                }));

            }
            else
            {
            }
        }

        byte CalcCheckSumbufferSize(byte[] i_buffer)
        {
            byte ret = 0;
            for (int i = 0; i < i_buffer.Length; i++)
            {
                ret += i_buffer[i];
            }
            return (byte)ret;
        }

        byte CalcCheckSumbuffer(byte[] i_buffer)
        {
            byte ret = 0;
            for (int i = 0; i < 1280; i++)
            {
                ret += i_buffer[i];
            }
            return (byte)ret;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        void SendDataToServer(string i_Connection, byte[] i_Data)
        {
            bool Issent;

            Issent = WriteDataToServer(i_Connection, i_Data);

            ASCIIEncoding encoder = new ASCIIEncoding();

            string Str = encoder.GetString(i_Data);

            if (Issent == true)
            {
                ServerLogger.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                ServerLogger.LogMessage(Color.DarkViolet, Color.White, "Send Data: ", false, false);
                ServerLogger.LogMessage(Color.DarkViolet, Color.White, " Connection: " + i_Connection, false, false);
                ServerLogger.LogMessage(Color.DarkGreen, Color.White, "   " + Str, true, false);

            }
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void TxtDataTx_TextChanged(object sender, EventArgs e)
        {
            Monitor.Properties.Settings.Default.Default_Server_Message = txtDataTx.Text;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {

                //List<string> S1frameArray = new List<string>();
                //S1frameArray.Add(S1_Protocol.S1_Messege_Builder.Get_Status());
                //SendS1Message(S1frameArray);


            }
            catch (SocketException ex)
            {
                ServerLogger.LogMessage(Color.Orange, Color.White, ex.ToString(), New_Line = true, Show_Time = true);
            }
        }


        //private void button5_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        List<string> S1frameArray = new List<string>();
        //        S1frameArray.Add(S1_Protocol.S1_Messege_Builder.Arm_Disarm_Unit(comboBox_ArmDisArm.Text));
        //        SendS1Message(S1frameArray);


        //    }
        //    catch (SocketException ex)
        //    {
        //        ServerLogger.LogMessage(Color.Orange, Color.White, ex.ToString(), New_Line = true, Show_Time = true);
        //    }
        //}




        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="i_S1frameArray"></param>
        ///// <returns>return bool if sent or not</returns>
        //bool SendS1Message(List<string> i_S1frameArray)
        //{
        //    bool ret = false;

        //    return ret;
        //}

        private bool WriteDataToServer(string i_ConnectionNumber, byte[] i_Data)
        {
            if (m_Server != null && m_Server.IsConnectedToClient && m_Server.IsServerActive)
            {
                m_Server.WriteDataToServer(i_ConnectionNumber, i_Data);
                return true;
            }

            return false;
        }



        private void ComboBox_InputIndex_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void Button23_Click(object sender, EventArgs e)
        {

        }


        private void Button24_Click(object sender, EventArgs e)
        {

        }

        private void Button_SMSControl_Click(object sender, EventArgs e)
        {

        }

        private void Button9_Click(object sender, EventArgs e)
        {

        }

        private void Button10_Click(object sender, EventArgs e)
        {

        }

        private void Button7_Click(object sender, EventArgs e)
        {

        }

        private void Button13_Click(object sender, EventArgs e)
        {

        }

        private void Button12_Click(object sender, EventArgs e)
        {

        }

        private void Button11_Click(object sender, EventArgs e)
        {

        }

        private void Button19_Click(object sender, EventArgs e)
        {

        }

        private void Button22_Click(object sender, EventArgs e)
        {

        }

        private void Button8_Click(object sender, EventArgs e)
        {

        }

        private void Button21_Click(object sender, EventArgs e)
        {

        }

        private void Button14_Click(object sender, EventArgs e)
        {

        }


        private void Button15_Click(object sender, EventArgs e)
        {

        }

        private void Button16_Click(object sender, EventArgs e)
        {

        }

        private void Button17_Click(object sender, EventArgs e)
        {

        }

        private void Button18_Click(object sender, EventArgs e)
        {

        }

        private void Button26_Click(object sender, EventArgs e)
        {

        }

        private void Button27_Click(object sender, EventArgs e)
        {

        }

        private void Button25_Click(object sender, EventArgs e)
        {

        }

        private void Button20_Click(object sender, EventArgs e)
        {

        }

        private void TxtS1_Clear_Click_1(object sender, EventArgs e)
        {
            try
            {
                SerialPortLogger_TextBox.Invoke(new EventHandler(delegate
                {

                    SerialPortLogger_TextBox.Text = "";

                }));
            }
            catch
            {
            }
        }

        private void Btn_GetPosition_Click(object sender, EventArgs e)
        {

        }

        private void Btn_ResetUnit_Click(object sender, EventArgs e)
        {

        }

        private void Button_GetTripInfo_Click(object sender, EventArgs e)
        {

        }



        private void Btn_GetSet1_Click(object sender, EventArgs e)
        {

        }

        private void Btn_GetSet2_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        void UpdateDefaultsContacts()
        {
            Monitor.Properties.Settings.Default.PhoneBook.Clear();

            List<PhoneBookContact> ContactsList = MyPhoneBook.GetContacts();
            foreach (PhoneBookContact PhoneBookContact in ContactsList)
            {
                Monitor.Properties.Settings.Default.PhoneBook.Add(PhoneBookContact.Phone + ";;;;" + PhoneBookContact.Name + ";;;;" + PhoneBookContact.Notes + ";;;;" + PhoneBookContact.Password + ";;;;" + PhoneBookContact.UnitID);
            }

            Monitor.Properties.Settings.Default.Save();
        }

        void UpdateDefaultsCommands()
        {

            Monitor.Properties.Settings.Default.SMS_Commands.Clear();

            foreach (string str in listBox_SMSCommands.Items)
            {
                Monitor.Properties.Settings.Default.SMS_Commands.Add(str);
            }

            Monitor.Properties.Settings.Default.Save();
        }

        void UpdateSMSCommands()
        {
            //string[] strArray = new string[Monitor.Properties.Settings.Default.SMS_Commands.Count];
            //Monitor.Properties.Settings.Default.PhoneBook.CopyTo(strArray, 0);

            listBox_SMSCommands.Invoke(new EventHandler(delegate
            {
                listBox_SMSCommands.Items.Clear();
                foreach (string str in Monitor.Properties.Settings.Default.SMS_Commands)
                {
                    listBox_SMSCommands.Items.Add((object)str);
                    // comboBox_SMSCommands.Items.Add(str);
                }

                SortSMSCommands();


            }));



        }

        void UpdatePhoneBook()
        {
            string[] strArray = new string[Monitor.Properties.Settings.Default.PhoneBook.Count];
            Monitor.Properties.Settings.Default.PhoneBook.CopyTo(strArray, 0);
            MyPhoneBook = new PhoneBook(strArray);

            MyPhoneBook.SortPhoneBookByNotes();

            List<PhoneBookContact> ContactsList = MyPhoneBook.GetContacts();

            checkedListBox_PhoneBook.Invoke(new EventHandler(delegate
                    {
                        checkedListBox_PhoneBook.Items.Clear();
                        foreach (PhoneBookContact PhoneBookContact in ContactsList)
                        {
                            checkedListBox_PhoneBook.Items.Add(PhoneBookContact);
                        }
                    }));

        }

        //void ClacPhoneBookTimeForPeriodOfSystem()
        //{
        //    System.Windows.Forms.Application.Exit();
        //}
        TextBox_Logger MiniAdaLogger;
        TextBox_Logger ServerLogger;
        TextBox_Logger SerialPortLogger;
        //   Logger LogIWatcher;
        TextBox_Logger LogSMS;
        PhoneBook MyPhoneBook;
    //    readonly List<Series> List_SeriesCharts = new List<Series>();
    //    readonly Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series
    //    {
    //        Name = "Raw Data",
    //        //    Color = System.Drawing.Color.Green,
    //        IsVisibleInLegend = true,
    //        IsXValueIndexed = false,
    //        ChartType = SeriesChartType.Line,
    //        MarkerStyle = MarkerStyle.Diamond
        
    //};
    //    readonly Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series
    //    {
    //        Name = "Moving Avarage 30",
    //        //    Color = System.Drawing.Color.Blue,
    //        IsVisibleInLegend = true,
    //        IsXValueIndexed = false,
    //        ChartType = SeriesChartType.Line
    //    };
    //    readonly Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series
    //    {
    //        Name = "0-100",
    //        //    Color = System.Drawing.Color.Blue,
    //        IsVisibleInLegend = true,
    //        IsXValueIndexed = false,
    //        ChartType = SeriesChartType.Line,
    //        MarkerStyle = MarkerStyle.Circle
    //    };

        Point? prevPosition = null;
        readonly ToolTip tooltip = new ToolTip();

        void Chart1_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart1.HitTest(pos.X, pos.Y, false,
                                            ChartElementType.DataPoint);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    if (result.Object is DataPoint prop)
                    {
                        var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                        // check if the cursor is really close to the point (2 pixels around the point)
                        if (Math.Abs(pos.X - pointXPixel) < 3 &&
                            Math.Abs(pos.Y - pointYPixel) < 3)
                        {
                            textBox_graph_XY.Text = "Chart=" + result.Series.Name + "\n, X=" + prop.XValue.ToString() + ", Y=" + prop.YValues[0].ToString();

                            tooltip.Show("X=" + prop.XValue + ", Y=" + prop.YValues[0], this.chart1,
                                            pos.X, pos.Y - 15, 9999999);
                        }
                    }
                }
            }
        }

        void Chart1_MouseClick(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            //if (prevPosition.HasValue && pos == prevPosition.Value)
            //    return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart1.HitTest(pos.X, pos.Y, false,
                                            ChartElementType.DataPoint);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    if (result.Object is DataPoint prop)
                    {
                        var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                        // check if the cursor is really close to the point (2 pixels around the point)
                        if (Math.Abs(pos.X - pointXPixel) < 4 &&
                            Math.Abs(pos.Y - pointYPixel) < 4)
                        {
                            chart1.Series[result.Series.Name].Points[(int)prop.XValue].Label = "X=" + prop.XValue + ", Y=" + prop.YValues[0].ToString("0.00");

                        }
                    }
                }
            }
        }

        private void Form1_Closed(object sender, System.EventArgs e)
        {
            ClientSocket.Close();

            if (this.ReceiveThread != null)
            {
                ReceiveThread.Abort();
                //   m_Exit = true;

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i_cmd"></param>
        /// <param name="i_InputArgs"></param>
        public void System1_parser_sum_CB(OneSystemCommand i_cmd, String[] i_InputArgs)
        {
            int sum = 0;
            if (i_InputArgs[0] == "?")
            {
                SerialPortLogger.LogMessage(Color.Blue, Color.LightGray, "Sum CB: " + i_cmd.Help, New_Line = true, Show_Time = true);
            }
            else
            {
                foreach (String str in i_InputArgs)
                {
                    sum += Int32.Parse(str);

                }

                SerialPortLogger.LogMessage(Color.Blue, Color.LightGray, "Sum CB: sum = " + sum, New_Line = true, Show_Time = true);
            } 
        }

        class System1_parser : CLI_Parser
        {


            public override void Parse(object sender,String i_InputString)
            {
                String[] tempStr = i_InputString.Split(' ');

                String Opcode_name = tempStr[0];


                //Gil: remove the first Opcode
                int indexToRemove = 0;
                tempStr = tempStr.Where((source, index) => index != indexToRemove).ToArray();

                //Gil Check if Opcode exists;
                foreach (OneSystemCommand cmd in ALLCommandsList)
                {
                    if (Opcode_name == cmd.Opcode)
                    {

                        //cmd.Run_Operation(tempStr);
                        String MethodName = this.GetType().Name+ "_" + Opcode_name + "_CB" ;

                        //Get the method information using the method info class
                        var method = sender.GetType().GetMethod(MethodName);
                        var parameters = new object[] { cmd, tempStr };


                        //Invoke the method
                        // (null- no parameter for the method call
                        // or you can pass the array of parameters...)
                        method.Invoke(sender, parameters);

                        //Type thisType = this.GetType();
                        //MethodInfo theMethod = thisType.GetMethod(MethodName);
                        //theMethod.Invoke(this, tempStr);
                    }
                }
            }
        }

        readonly System1_parser system1_Parser = new System1_parser();


        // List<S1_Protocol.S1_Messege_Builder.Command_Description> CommandsDescription;
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                tabControl_Main.TabPages.RemoveAt(0);
                tabControl_Main.TabPages.RemoveAt(0);
                tabControl_Main.TabPages.RemoveAt(0);
                //tabControl_Main.TabPages.RemoveAt(3);
                // tabControl_Main.TabPages.RemoveAt(3);
                system1_Parser.AddCommand("sum" , " sum all the elements \n Format: sum 1 2 3");
                //System1_parser.AddCommand("sum", "sum args", "sum all the numbers");
                //List_SeriesCharts.Add(series1);
                //List_SeriesCharts.Add(series2);
                //List_SeriesCharts.Add(series3);
                // this.TopMost = true;
                //// this.FormBorderStyle = FormBorderStyle.None;
                // this.WindowState = FormWindowState.Maximized;
                foreach(Series ser in chart1.Series)
                {
                    listBox_Charts.Items.Add(ser.Name);
                }
                textBox_SendSerialPort.PreviewKeyDown += TextBox_SendSerialPort_PreviewKeyDown;
                this.FormClosed += MainForm_FormClosed;
               // chart1.Series.Clear();
                // chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                // chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                //chart1.Series.Add(series1);
                //chart1.Series.Add(series2);
                //chart1.Series.Add(series3);
                //chart1.Series[0].BorderWidth = 2;
                //chart1.Series[1].BorderWidth = 2;

                //chart1.Series[0].IsValueShownAsLabel = true;
                //chart1.Series[1].IsValueShownAsLabel = false;
                //chart1.Series[1].SmartLabelStyle.IsMarkerOverlappingAllowed = false;
                //chart1.Series[0].SmartLabelStyle.IsMarkerOverlappingAllowed = false;
                //chart1.Series[1].SmartLabelStyle.Enabled = true;


                chart1.MouseMove += Chart1_MouseMove;
                chart1.MouseClick += Chart1_MouseClick;

               // tabControl_Main.DrawItem += TabControl1_DrawItem1;
              //  textBox_SendSerialPort.KeyDown += TextBox_SendSerialPort_KeyDown;

               //tabControl1.TabPages.RemoveAt(2);
          //      UpdatePhoneBook();
             //   UpdateSMSCommands();


                txtPortNo.Text = Monitor.Properties.Settings.Default.Start_Port;
                txtDataTx.Text = Monitor.Properties.Settings.Default.Default_Server_Message;



                //pictureBox_logo.BringToFront();

                //Gil: Generate all the loggers
                ServerLogger = new TextBox_Logger("Server", TextBox_Server, button_ClearServer, checkBox_ServerPause, checkBox_ServerRecord, null, null, null, checkBox_StopLogging);
                SerialPortLogger = new TextBox_Logger("Serial_Port", SerialPortLogger_TextBox, txtS1_Clear, checkBox_S1Pause, checkBox_S1RecordLog, textBox_SerialPortRecognizePattern, textBox_SerialPortRecognizePattern2, textBox_SerialPortRecognizePattern3, null);
                MiniAdaLogger = new TextBox_Logger("MiniAda", richTextBox_MiniAda, button_ClearMiniAda, checkBox_PauseMiniAda, checkBox_RecordMiniAda, null, null, null, checkBox_StopLogging);


               // LogSMS = new TextBox_Logger("Log_SMS", richTextBox_SMSConsole, button_ClearSMSConsole, checkBox_PauseSMSConsole, checkBox_RecordSMSConsole, null, null, null, null);

                //Gil: Active All the recorders
              //  checkBox_RecordGeneral.Checked = !checkBox_RecordGeneral.Checked;
               // checkBox_S1RecordLog.Checked = !checkBox_S1RecordLog.Checked;
                //checkBox_RecordLatLong.Checked = !checkBox_RecordLatLong.Checked;

                //        checkBox_RecordTrace.Checked = !checkBox_RecordTrace.Checked;

                //Gil: Initialize the serial ports
                serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);

                ScanComports();
                cmbStopBits.DataSource = Enum.GetValues(typeof(StopBits));
                cmbStopBits.SelectedIndex = (int)StopBits.One;

                cmbParity.DataSource = Enum.GetValues(typeof(Parity));
                cmbParity.SelectedIndex = (int)Parity.None;

                //cmbDataBits.DataSource = Enum.GetValues(typeof(Data));

                cmbBaudRate.Text = Monitor.Properties.Settings.Default.Comport_BaudRate ;
                cmbDataBits.Text = Monitor.Properties.Settings.Default.Comport_DataBits  ;
                cmbStopBits.Text = Monitor.Properties.Settings.Default.Comport_StopBit ;
                cmbParity.Text = Monitor.Properties.Settings.Default.Comport_Parity ;
                cmbPortName.Text = Monitor.Properties.Settings.Default.Comport_Port ;




                


                //cmbBaudRate.Text = Monitor.Properties.Settings.Default.Comport_BaudRate;
                //cmbDataBits.Text = Monitor.Properties.Settings.Default.Comport_DataBits;
                //cmbStopBits.Text = Monitor.Properties.Settings.Default.Comport_StopBit;
                //cmbParity.Text = Monitor.Properties.Settings.Default.Comport_Parity;
                //cmbPortName.Text = Monitor.Properties.Settings.Default.Comport_Port;


                //Gil: Set Versions Names
                string path = Directory.GetCurrentDirectory();
                string lastFolderName = Path.GetFileName(path);
                //string[] dir = Directory.GetCurrentDirectory().Split('\\');
                string version = lastFolderName;
                //if (ApplicationDeployment.IsNetworkDeployed)
                //{
                //    version = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
                //}
                //else
                //{
                //    version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                //}

                this.Text = " [ " + ", Version: " + version + ", Compiled: " + RetrieveLinkerTimestamp().ToString() + " ]";







                foreach(TextBox txtbx in List_ConfigurationTextBoxes)
                {
                    txtbx.GotFocus += Txtbx_GotFocus;
                }


                UpdateSerialPortComboBox();

                //ShowHidePages();


                TimeSpan TimeFromLastSave = DateTime.Now - Monitor.Properties.Settings.Default.LastSaveSMSTime;


                TimeSpan TimeFromLastRunTime = DateTime.Now - Monitor.Properties.Settings.Default.LastRunTime;
                //      TimeSpan TimeFromCompilation = DateTime.Now - RetrieveLinkerTimestamp();
                TimeSpan TimeForRunPhoneBookAtTime = DateTime.Now - RetrieveLinkerTimestamp();
                Monitor.Properties.Settings.Default.LastRunTime = DateTime.Now;
                Monitor.Properties.Settings.Default.Save();

                ///////////////////////////////// Leonid: Compilation time span (Remember this!!!!!!!!)
                if (TimeForRunPhoneBookAtTime.Days > 90)
                {
                    //   ClacPhoneBookTimeForPeriodOfSystem();

                }
                ///////////////////////////////
                //if (TimeFromLastSave.Days > 3)
                //{
                //    SaveCommandsAndContacts();


                //}

                SerialPortLogger.LogMessage(Color.Yellow, Color.LightGray, "Press F1 for help", New_Line = true, Show_Time = true);

                foreach (Control allContrls in this.Controls)
                {
                    FindControls(allContrls);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //  ServerLogger.LogMessage(Color.Orange, Color.White, ex.ToString(), true, true);
            }

        }

        private void FindControls(Control ctl)
        {

            if (ctl.GetType().FullName == "System.Windows.Forms.TextBox")
            {
                TextBox txt = (TextBox)ctl;
                String temp = txt.Text;
                txt.Text = " ";
                txt.Text = temp;
            }

            if (ctl.GetType().FullName == "System.Windows.Forms.CheckBox")
            {
                CheckBox chk = (CheckBox)ctl;
            }

            foreach (Control ctrl in ctl.Controls)
            {
                FindControls(ctrl);
            }

        }



        private void Txtbx_GotFocus(object sender, EventArgs e)
        {
          //  TextBox txtbx = (TextBox)sender;
            // textBox_ConfigurationHelp.Text = "";
            //textBox_ConfigurationHelp.Text = txtbx.Name + "\n" + toolTip1.GetToolTip(txtbx);

        }

        private void TextBox_SerialPortRecognizePattern3_GotFocus(object sender, EventArgs e)
        {
            SerialPortLogger.LogMessage(Color.Black, Color.Yellow, "Got focus", New_Line = true, Show_Time = true);
        }

        private void TextBox_SendSerialPort_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
               // MessageBox.Show("Tab");
                e.IsInputKey = true;
            }
            if (e.KeyData == (Keys.Tab | Keys.Shift))
            {
              //  MessageBox.Show("Shift + Tab");
                e.IsInputKey = true;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseClentConnection();
        }

        //Color Tab0Color;
        //Color Tab1Color;
        //Color Tab2Color;
        //Color Tab3Color;
        private void TabControl1_DrawItem1(object sender, DrawItemEventArgs e)
        {
            TabPage page = tabControl_Main.TabPages[e.Index];
            Color TabColor;
            if(e.Index == tabControl_Main.SelectedIndex)
            {
                TabColor = Color.Aqua;
            }
            else
            {
                TabColor = default;
            }

            //switch (e.Index)
            //{
            //    case 0:
            //        e.Graphics.FillRectangle(new SolidBrush(Tab0Color), e.Bounds);
            //        break;
            //    case 1:
            //        e.Graphics.FillRectangle(new SolidBrush(Tab1Color), e.Bounds);
            //        break;
            //    default:
            //        break;
            //}

            e.Graphics.FillRectangle(new SolidBrush(TabColor), e.Bounds);
            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(e.Graphics, page.Text, e.Font, paddedBounds, page.ForeColor);
        }

        private void TextBox_SendNumberOfTimes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TextBox_SendSerialDiff_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        void SaveCommandsAndContacts()
        {
            string subPath = Directory.GetCurrentDirectory() + "\\SMS_Backup\\";
            string m_log_file_name = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "_Contacts" + ".xml";
            string filesName = m_log_file_name;

            bool isExists = System.IO.Directory.Exists(subPath);

            if (!isExists)
            {
                System.IO.Directory.CreateDirectory(subPath);
            }

            using (Stream myStream = File.Create(subPath + m_log_file_name))
            {
                MyPhoneBook.ExportToXML(myStream);
                // Code to write the stream goes here.
                myStream.Close();
            }

            m_log_file_name = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "____________Commands" + ".xml";
            filesName += "\n" + m_log_file_name;
            using (Stream myStream = File.Create(subPath + m_log_file_name))
            {
                List<string> templist = new List<string>();
                foreach (var item in listBox_SMSCommands.Items)
                {
                    templist.Add((string)item);
                }
                XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
                TextWriter textWriter = new StreamWriter(myStream);

                serializer.Serialize(textWriter, templist);
                textWriter.Close();
                // Code to write the stream goes here.
                myStream.Close();
            }

            Monitor.Properties.Settings.Default.LastSaveSMSTime = DateTime.Now;
            Monitor.Properties.Settings.Default.Save();

           // LogSMS.LogMessage(Color.Brown, Color.White, " 2 Backup files of contacts and commands Created at \n" + subPath + "\n" + filesName, New_Line = true, Show_Time = true);


        }

        //void ShowHidePages()
        //{
        //    if (Monitor.Properties.Settings.Default.RemovePages != null)
        //    {
        //        int i = 0;
        //        foreach (string str in Monitor.Properties.Settings.Default.RemovePages)
        //        {
        //            try
        //            {
        //                // comboBox_SerialPortHistory.Items.Add((object)str);
        //                // comboBox_SMSCommands.Items.Add(str);
        //                Int32 indexToRemove = Int32.Parse(str);

        //                tabControl1.TabPages.RemoveAt(indexToRemove - i);
        //                i++;
        //            }
        //            catch
        //            {
        //                break;
        //            }

        //        }
        //    }
        //}

        // Dictionary<string, TextBox> Dictionary_ConfigurationTextBoxes;
        readonly List<TextBox> List_ConfigurationTextBoxes = new List<TextBox>();


        //static public List<string> GetAllCommands()
        //{
        //    Type type = typeof(S1_Protocol.S1_Messege_Builder);
        //    MethodInfo[] info = type.GetMethods();
        //    List<string> ret = new List<string>();

        //    Type type_Object = typeof(Object);
        //    MethodInfo[] info_Object = type_Object.GetMethods();
        //    foreach (MethodInfo inf in info)
        //    {
        //        bool Add = true;
        //        foreach (MethodInfo inf_Obj in info_Object)
        //        {
        //            if (inf_Obj.Name == inf.Name)
        //            {
        //                Add = false;
        //            }
        //        }
        //        if (Add)
        //        {
        //            ret.Add(inf.Name);
        //        }

        //    }
        //    return ret;

        //}

        //void toolStripMenuItem_CopyToSingle_Click(object sender, EventArgs e)
        //{
        //    textBox_AddSendSingleCommand.Text = richTextBox_GetConfig.SelectedText;
        //}




        private void Txtbox_Password_TextChanged(object sender, EventArgs e)
        {
            //if (txtbox_Password.Text.Length < 4)
            //{
            //    txtbox_Password.BackColor = Color.OrangeRed;
            //}
            //else
            //{
            //    txtbox_Password.BackColor = Color.White;
            //}
        }


        string ConfigFileName;
        private void Button28_Click(object sender, EventArgs e)
        {

            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                ConfigFileName = openFileDialog1.FileName;

                //TextBox_File_Name.Text = openFileDialog1.FileName;



            }


        }


        int NumOfRemainCommands = 0;
        private void BackgroundWorker_ConfigSystem_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;

            NumOfRemainCommands = 0;
            //ConfigProcessExit = false;

            // Gil Calculate the percentage
            //int percent = CalculateProgressDonePercentage();
            worker.ReportProgress(0);

            while (CalculateProgressDonePercentage() < 100)
            {
        




            }

            //Config_Sys.Invoke(new EventHandler(delegate
            //        {
            //            Config_Sys.Enabled = true;
            //        }));
            //worker.ReportProgress(CalculateProgressDonePercentage());
        }









        private int CalculateProgressDonePercentage()
        {
            float ret = ((float)NumOfRemainCommands / (float)CommandsToSend.Count) * 100;
            return (int)ret;
        }






        //Color originColor_LatLong;
        //string log_file_S1_LatLong;
      //  readonly List<string> KMl_text = new List<string>();
        //       int KML_Index = 0;
        //   int DrivingNumber = 0;
        private void CheckBox1_CheckedChanged_2(object sender, EventArgs e)
        {
            //if (checkBox_RecordLatLong.Checked)
            //{
            //    KMl_text.Clear();
            //    DrivingNumber++;
            //    originColor_LatLong = checkBox_RecordLatLong.BackColor;
            //    checkBox_RecordLatLong.BackColor = Color.Yellow;

            //    log_file_S1_LatLong = "Log_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "_LatLong_Record_DRVNUM_" + DrivingNumber + ".kml";
            //    try
            //    {

            //        while (File.Exists(log_file_S1_LatLong))
            //        {
            //            log_file_S1_LatLong = "Log_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "_LatLong_Record" + ".kml";
            //        }


            //        NumOfPositionMessage = 0;
            //        KMl_text.Add("<?xml version=\"1.0\" encoding=\"UTF-8\"?>"); 
            //        KMl_text.Add("<kml xmlns=\"http://www.google.com/earth/kml/2\">");
            //        KMl_text.Add("<Document>");




            //        SerialPortLogger.LogMessage(Color.Blue, Color.LightGray, "File " + log_file_S1_LatLong + " opened in directory \" " + Directory.GetCurrentDirectory() + "\" \n\n", true, true);
            //        //}


            //    }
            //    catch (Exception)
            //    {
            //        SerialPortLogger.LogMessage(Color.Orange, Color.LightGray, "Can't Open File", true, true);
            //    }

            //}
            //else
            //{
            //    checkBox_RecordLatLong.BackColor = default(Color);

            //    SerialPortLogger.LogMessage(Color.Blue, Color.LightGray, "File " + log_file_S1_LatLong + " closed \n\n", true, true);
            //}
        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        readonly List<List<string>> CommandsToSend = new List<List<string>>();












        private void Button29_Click_1(object sender, EventArgs e)
        {

        }

        private void TextBox_GeneralMessage_TextChanged(object sender, EventArgs e)
        {

        }
        Double ChartCntX = 0, ChartCntY = 0;
        Double ChartCntY2 = 0;
        Double ChartCntY3 = 0;
        bool OppositeCount = false, SerialRxBlinklled = false, SerialTxBlinklled = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string PrintTimeSpan(TimeSpan t)
        {
            string answer;
            if (t.TotalMinutes < 1.0)
            {
                answer = String.Format("{0}.{1:D2}s", t.Seconds, t.Milliseconds / 10);
            }
            else if (t.TotalHours < 1.0)
            {
                //answer = String.Format("{0}m:{1:D2}.{2:D2}s", t.Minutes, t.Seconds, t.Milliseconds % 100);
                answer = String.Format("{0}m:{1:D2}", t.Minutes, t.Seconds);
            }
            else // more than 1 hour
            {
                answer = String.Format("{0}h:{1:D2}m:{2:D2}", (int)t.TotalHours, t.Minutes, t.Seconds);
            }

            return answer;
        }


        static int GetDataIntervalCounter;
        bool IsTimedOutTimerEnabled = false;
        /// <summary>
        /// 
        /// </summary>
        int Timer_100ms = 0;

        void ClientTCpipProcessing()
        {
            try
            {
                if (ClientSocket == null || ClientSocket.Client == null)
                {
                    button_ClientConnect.BackColor = default;
                }
                else
                    
                    if (ClientSocket.Connected && ClientSocket.Client.Connected && ClientSocket.GetStream() != null)
                    {
                        button_ClientConnect.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        button_ClientConnect.BackColor = default;
                    }




            }
            catch
            {
                button_ClientConnect.BackColor = default;
            }

        }

        private int TimeOutKeepAlivein100ms = 3000000;
        private int RxLabelTimerBlink = 0, TxLabelTimerBlink = 0;
        private void Timer_ConectionKeepAlive_Tick(object sender, EventArgs e)
        {
            Timer_100ms++;

            ClientTCpipProcessing();

            if (stopwatch.IsRunning == true)
            {
                textBox_StopWatch.Text = PrintTimeSpan(stopwatch.Elapsed);
            }

            // Gil: In case Time Out Expiered close all the threads and connections
            if (IsTimedOutTimerEnabled == true)
            {
                GetDataIntervalCounter++;
                if (GetDataIntervalCounter >= TimeOutKeepAlivein100ms)
                {
                    //IsTimedOutTimerEnabled = false;
                    GetDataIntervalCounter = 0;
                    ServerLogger.LogMessage(Color.Orange, Color.White, "Connection Time Out ", New_Line = true, Show_Time = true);
                    ListenBox.Checked = !ListenBox.Checked;
                    ListenBox.Checked = !ListenBox.Checked;
                }
            }




            if (m_Server != null)
            {
                try
                {
                    if (m_Server.IsServerActive)
                    {
                        textBox_ServerActive.BackColor = Color.Green;
                    }
                    else
                    {
                        textBox_ServerActive.BackColor = default;
                    }


                    if (m_Server.IsConnectedToClient)
                    {
                        IsTimedOutTimerEnabled = true;
                        textBox_ServerOpen.BackColor = Color.Green;
                        //ListenBox.BackColor = Color.Green;
                    }
                    else
                    {
                        IsTimedOutTimerEnabled = false;
                        textBox_ServerOpen.BackColor = default;
                        // ListenBox.BackColor = Color.Yellow;
                    }


                    textBox_NumberOfOpenConnections.Text = m_Server.NumberOfOpenConnections.ToString();

                }
                catch (Exception ex)
                {
                    ServerLogger.LogMessage(Color.Red, Color.White, ex.ToString(), New_Line = true, Show_Time = true);
                }
            }



            if (IsPauseGraphs == false)
            {

                if (Timer_100ms % (ChartUpdateTime/100) == 0)
                {
                    GraphPrint();
                }
            }

            if (RxLabelTimerBlink > 0)
            {
                RxLabelTimerBlink--;
                if (Timer_100ms % 3 == 0)
                {
                    SerialRxBlinklled = !SerialRxBlinklled;
                    if (SerialRxBlinklled == true)
                    {
                        Label_SerialPortRx.BackColor = Color.Green;
                    }
                    else
                    {
                        Label_SerialPortRx.BackColor = default;
                    }
                }
            }
            else
            if (RxLabelTimerBlink == 0)
            {
                Label_SerialPortRx.BackColor = default;
            }

            if (TxLabelTimerBlink > 0)
            {
                TxLabelTimerBlink--;
                if (Timer_100ms % 5 == 0)
                {
                    SerialTxBlinklled = !SerialTxBlinklled;
                    if (SerialTxBlinklled == true)
                    {
                        Label_SerialPortTx.BackColor = Color.Green;
                    }
                    else
                    {
                        Label_SerialPortTx.BackColor = default;
                    }
                }
            }
            else
            if (TxLabelTimerBlink == 0)
            {
                Label_SerialPortTx.BackColor = default;
            }







            }

        readonly List<double> ChartMem = new List<double>();
        readonly List<double> ChartMem2 = new List<double>();
        readonly Random rand = new Random();
        int GreenCnt = 0, RedCnt = 0;
        private const int MOVING_AVARAGE_SIZE = 30;
        void GraphPrint()
        {

            try
            {

                

                if (OppositeCount == true)
                {
                    ChartCntY3++;
                    ChartCntY3 *= 1.1;
                    if (ChartCntY3 >= 100)
                    {
                        OppositeCount = false;
                    }
                }
                else
                {
                    ChartCntY3--;
                    ChartCntY3 *= 0.9;
                    if (ChartCntY3 <= 0)
                    {
                        OppositeCount = true;
                    }
                }

                ChartCntY2 = 0;
                int cnt = 0;
                for (int i = chart1.Series[0].Points.Count - 1; i >= (chart1.Series[0].Points.Count - MOVING_AVARAGE_SIZE) && i >= 0; i--)
                {
                    cnt++;
                    ChartCntY2 += (int)chart1.Series[0].Points[i].YValues[0];
                }
                ChartCntY2 /= cnt;

                if (IsPauseGraphs == false)
                {
                    chart1.Series[0].Points.AddXY(ChartCntX, ChartCntY);
                    chart1.Series[0].Name = $"Data 1 [{ChartCntY}]";

                    chart1.Series[1].Points.AddXY(ChartCntX, ChartCntY2);
                    chart1.Series[1].Name = $"Data 2 [{ChartCntY2}]";

                    chart1.Series[2].Points.AddXY(ChartCntX, ChartCntY3);
                    chart1.Series[2].Name = $"Data 3 [{ChartCntY3}]";
                }
                else
                {
                    ChartMem.Add(ChartCntY);
                    ChartMem2.Add(ChartCntY2);
                }

                ChartCntX++;
                double temp = rand.Next(-1, 2);
                temp *= rand.NextDouble();
                ChartCntY += temp;

                if (ChartCntY > ChartCntY2)
                {
                    chart1.BackColor = Color.LightGreen;
                    GreenCnt++;
                }
                else
                {
                    chart1.BackColor = Color.Red;
                    RedCnt++;
                }
                if (Timer_100ms % 50 == 0)
                {
                    textBox_graph_XY.Text = "Green = " + GreenCnt + "  Red = " + RedCnt;
                }
                //  ChartCntY2 = ChartCntY2 + rnd.Next(-1, 2);

                if (ChartCntX % 1000 == 0)
                {
                    chart1.ChartAreas[0].AxisX.Minimum = ChartCntX;
                }


                chart1.Refresh();
                chart1.Invalidate();
            }
            catch(Exception ex)
            {
                textBox_graph_XY.Text = ex.Message;
                textBox_graph_XY.BackColor = Color.Red;
            }
            
        }

        //static float NextFloat(Random random)
        //{
        //    double mantissa = (random.NextDouble() * 2.0) - 1.0;
        //    // choose -149 instead of -126 to also generate subnormal floats (*)
        //    double exponent = Math.Pow(2.0, random.Next(-126, 128));
        //    return (float)(mantissa * exponent);
        //}

        private void TakeCroppedScreenShot()
        {
            string FileLocation = @".\MyPanelImage.bmp";
            Bitmap bmp = new Bitmap(chart1.Width, chart1.Height);
            chart1.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            bmp.Save(FileLocation);

            var filePath = FileLocation;
            ProcessStartInfo Info = new ProcessStartInfo()
            {
                FileName = "mspaint.exe",
                WindowStyle = ProcessWindowStyle.Maximized,
                Arguments = filePath
            };
            Process.Start(Info);
        }


        private void TabPage6_Click(object sender, EventArgs e)
        {

        }

        private void Button_Set2_Click(object sender, EventArgs e)
        {

        }

        private void Button_GenerateConfigFile_Click(object sender, EventArgs e)
        {

        }

        private void Button_Set1_Click(object sender, EventArgs e)
        {



        }


        void TCPClientConnection()
        {
            if (ClientSocket == null || ClientSocket.Client == null)
            {
                button_ClientConnect.BackColor = default;
            }
            label_ClientTCPConnected.BackColor = button_ClientConnect.BackColor;
            if (label_ClientTCPConnected.BackColor == Color.LightGreen)
            {
                label_TCPClient.Text = textBox_ClientIP.Text + "  \n" + textBox_ClientPort.Text;
            }
            else
            {
                label_TCPClient.Text = "None";
            }
        }
        //bool timer_General_TranssmitionPeriodicallyEnable = false;
        //uint NumbeOfTransmmitions = 0;
         int  TimerClearModemStatus = 0;
        //uint IntervalTimeBetweenTransmitions = 1;
        private void Timer_General_Tick(object sender, EventArgs e)
        {

            TCPClientConnection();
            //Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            //Tab0Color = randomColor;

            //randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            //Tab1Color = randomColor;

            //randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            //Tab2Color = randomColor;

            //randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            //Tab3Color = randomColor;
            tabControl_Main.Invalidate();

            if (IsTimerRunning == true)
            {
                int.TryParse(textBox_TimerTime.Text, out int Result);
                if (Result != 0)
                {
                    Result--;
                    if (Result == 0)
                    {
                        SerialPortLogger.LogMessage(Color.White, Color.DarkOrange, "Timer End", true, true);
                        checkBox_S1Pause.Checked = true;

                        ResetTimer();
                    }
                    else
                    {

                    }
                    textBox_TimerTime.Text = Result.ToString();
                }
            }


            //         label_TimeDate.Text = DateTime.Now.ToString();
            //label_TimeDate2.Text = DateTime.Now.ToString();
            //label_TimeDate3.Text = DateTime.Now.ToString();

            if (TimerStatusRingWait > 0)
            {
                TimerStatusRingWait--;
                button_Ring.Text = "Ring Processing (" + TimerStatusRingWait + ")" + "(" + SendOneTimeFlag + ")";

            }
            else
            {
                button_Ring.BackColor = default;
                button_Ring.Text = "Ring";
            }

          //  TimerCounter100ms++;

            TimerClearModemStatus++;

            //TimerExportContactsCommandsToFile++;

            if (TimerClearModemStatus % 60 == 0)
            {
                richTextBox_ModemStatus.Invoke(new EventHandler(delegate
                {
                    richTextBox_ModemStatus.BackColor = default;
                    richTextBox_ModemStatus.Text = "";
                }));
            }


            if (m_Server != null)
            {
                textBox_CurrentTimeOut.Text = ((TimeOutKeepAlivein100ms / 10) - (GetDataIntervalCounter / 10)).ToString();

            }




            if (CloseSerialPortTimer == true)
            {
                CloseSerialPortConter++;
                if (CloseSerialPortConter > 1)
                {
                    SerialPort_DataReceived(null, null);
                    CloseSerialPortConter = 0;
                }
            }
            try
            {
                if (m_Server != null)
                {

                    if (m_Server.NumberOfOpenConnections == 0)
                    {
                        var dataSource = new List<string>
                        {
                            "None"
                        };
                        comboBox_ConnectionNumber.DataSource = dataSource;
                        LastConNum = m_Server.NumberOfOpenConnections;

                        ConnectionToIDdictionary.Clear();
                        //for (int i = 0; i < UnitNumberToConnections.Length; i++)
                        //{
                        //    UnitNumberToConnections[i] = "";
                        //}
                    }
                    else
                        if (LastConNum != m_Server.NumberOfOpenConnections)
                    {
                        List<string> ret = m_Server.GetAllOpenConnections();

                        List<string> listkeys = new List<string>(ConnectionToIDdictionary.Keys);
                        foreach (string str in listkeys)
                        {
                            bool found = false;

                            foreach (string str2 in ret)
                            {
                                if (str == str2)
                                {
                                    found = true;

                                }
                            }

                            if (found == false)
                            {
                                ConnectionToIDdictionary.Remove(str);
                            }
                        }

                        comboBox_ConnectionNumber.DataSource = ret;

                        LastConNum = m_Server.NumberOfOpenConnections;


                    }
                    PrintDictineryIDKeys();
                }



            }
            catch (Exception ex)
            {
                ServerLogger.LogMessage(Color.Red, Color.White, ex.ToString(), New_Line = true, Show_Time = true);
            }
            //if (ComPortClosing == true)
            //{
            //    Thread.Sleep(4000);
            //    serialPort_DataReceived(null, null);
            //}


        }

        void PrintDictineryIDKeys()
        {
            textBox_IDKey.Invoke(new EventHandler(delegate
            {
                textBox_IDKey.Text = "Connection       |      Unit ID \n";
                textBox_IDKey.AppendText("------------------------------------- \n");
            }));

            foreach (var pair in ConnectionToIDdictionary)
            {
                textBox_IDKey.Invoke(new EventHandler(delegate
                {
                    textBox_IDKey.AppendText(pair.Key + " | " + pair.Value.Replace(';', ' ') + " \n");
                }));
            }

        }

        static int LastConNum = 0;
        static int CloseSerialPortConter = 0;


        bool CloseSerialPortTimer = false;

        bool ComPortClosing = false;
        //List<byte> temp_serialBuff = new List<byte>();
        void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            // If the com port has been closed, do nothing
            if (!serialPort.IsOpen) return;


            if (ComPortClosing == true)
            {
                //Thread.Sleep(400);
                serialPort.Close();
                ComPortClosing = false;

                //checkBox_ComportOpen.Checked = false;

                cmbBaudRate.Invoke(new EventHandler(delegate
                 {
                     //button_OpenPort.Checked = false;
                     button_OpenPort.Enabled = true;
                     gbPortSettings.Enabled = true;

                     button_OpenPort.BackColor = default;
                     label_SerialPortConnected.BackColor = default;
                     label_SerialPortStatus.Text = "";

                     cmbBaudRate.Enabled = true;
                     cmbDataBits.Enabled = true;
                     cmbParity.Enabled = true;
                     cmbPortName.Enabled = true;
                     cmbStopBits.Enabled = true;
                 }));

                CloseSerialPortTimer = false;

                SerialPortLogger.LogMessage(Color.Orange, Color.LightGray, "Serial port Closed", New_Line = true, Show_Time = true);
                return;
            }

            // This method will be called when there is data waiting in the port's buffer
            Thread.Sleep(300);

            if (!serialPort.IsOpen) return;

            RxLabelTimerBlink = 5;

            // Obtain the number of bytes waiting in the port's buffer
            int bytes = serialPort.BytesToRead;

            // Create a byte array buffer to hold the incoming data
            byte[] buffer = new byte[bytes];

            // Read the data from the port and store it in our buffer
            serialPort.Read(buffer, 0, bytes);

            SerialPortLogger.LogMessage(Color.Blue, Color.Azure, "", New_Line = false, Show_Time = true);
            SerialPortLogger.LogMessage(Color.Blue, Color.Azure, "Rx:>", false, false);

            if (checkBox_RxHex.Checked == true)
            {
                
                string IncomingHexMessage = ConvertByteArraytToString(buffer);

                SerialPortLogger.LogMessage(Color.Blue, Color.LightGray, IncomingHexMessage, New_Line = true, Show_Time = false);
            }
            else
            {

                string IncomingString = System.Text.Encoding.Default.GetString(buffer);



                
                string[] lines = Regex.Split(IncomingString, "\r\n");

                foreach (string line in lines)
                {
                    SerialPortLogger.LogMessage(Color.Blue, Color.LightGray, line, New_Line = true, Show_Time = false);
                }


                ParseSerialPortString(IncomingString);
            }



        }

        private byte[] StringToByteArray(string hex)
        {
            try
            {
                return Enumerable.Range(0, hex.Length)
                                 .Where(x => x % 2 == 0)
                                 .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                                 .ToArray();

            }
            catch(Exception ex)
            {
                SerialPortLogger.LogMessage(Color.Red, Color.LightGray, ex.Message, New_Line = true, Show_Time = false);
                return null;
            }
        }

        String ConvertByteArraytToString(byte[] i_Buffer)
        {
            string IncomingHexMessage = "";
            foreach (byte by in i_Buffer)
            {
                IncomingHexMessage += "[0x" + by.ToString("X2") + "] ";

            }

            return IncomingHexMessage;
        }



        enum SourceMessage
        {
            SMS,
            SerialPort,
            Server
        };

        void ParseStatuPos(string IncomingString)
        {
            string[] ParseStrings = { "" };
            string[] Key = { "" };
            try
            {
                if (IncomingString.Contains(","))
                {
                    ParseStrings = IncomingString.Split(',');
                    Key = ParseStrings[1].Split('=');
                }
            }
            catch
            {
                //ServerLogger.LogMessage(Color.Black, Color.White, "Data Not Valid: " + IncomingString, New_Line = true, Show_Time = true);
                return;
            }

            Boolean IwatcherPrint = false;


            if (Key[0] == "POS")
            {

                if (IwatcherPrint == true)
                {

                    _ =
                        "\n UNIT ID = " + ParseStrings[0].Replace(";", "") +
                        "\n STATE = " + Key[1] +
                        "\n GSM LINK QUALITY = " + ParseStrings[2] +
                        "\n GPS STATUS = " + ParseStrings[3] +
                        "\n GPS NUM OF SATELLITES = " + ParseStrings[4] +
                        "\n CURRENT TIME AND DATE = " + ParseStrings[5] + " " + ParseStrings[6] +
                        "\n LAST GPS TIME AND DATE = " + ParseStrings[7] + " " + ParseStrings[8] +
                        "\n GPS LATITUDE = " + ParseStrings[9] +
                        "\n GPS LONGTITUDE = " + ParseStrings[10] +
                        "\n GPS SPEED = " + ParseStrings[11] +
                        "\n GPS DIRECTION =" + ParseStrings[12] +
                        "\n TRIP DISTANCE  = " + ParseStrings[13] +
                        "\n TOTAL DISTANCE = " + ParseStrings[14];
                    //  "\n GPRS MESSAGE  NUMBER = " + PosStrings[15];

                    //string.Format("\n UNIT ID = {0} \n STATE = {1}\n GSM LINK QUALITY = {2}", PosStrings[0].Replace(";",""), Key[1], PosStrings[2]); 
                    //LogIWatcher.LogMessage(Color.Brown, Color.White, PositionString, New_Line = true, Show_Time = false);
                }

                //string ret = "";
                //if (checkBox_ShowURL.Checked)
                //{
                //    string ret = "http://maps.google.com/maps?q=" + ParseStrings[9] + "," + ParseStrings[10] + "( " + " Current Time: " + DateTime.Now + "\r\n   S1TimeStamp: " + " )" + "&z=14&ll=" + "," + "&z=17";
                //    Show_WebBrowserUrl(ret);
                //}

                //if (checkBox_RecordLatLong.Checked)
                //{

                //    NumOfPositionMessage++;
                //    //354869050154426,POS=1,GSMLinkQual,5,8,12/9/2013,10:55:11,12/9/2013,10:55:11,32.155636,34.920308,0,304.2,


                //    KMl_text.Add("<Placemark>");
                //    KMl_text.Add("<name>" + "[" + NumOfPositionMessage + "]" + " " + DateTime.Now + "  </name>");
                //    KMl_text.Add("<Point>");
                //    KMl_text.Add("<coordinates>" + ParseStrings[10] + "," + ParseStrings[9] + "</coordinates> ");
                //    KMl_text.Add("</Point>");
                //    KMl_text.Add("</Placemark> ");
                //    KMl_text.Add("</Document> \n");
                //    KMl_text.Add("</kml> \n");

                //    File.Delete(log_file_S1_LatLong);
                //    using (System.IO.StreamWriter file = new System.IO.StreamWriter(log_file_S1_LatLong))
                //    {
                //        foreach (string str in KMl_text)
                //        {
                //            file.WriteLine(str);
                //        }
                //        //for (int i = 0; i < KML_Index; i++)
                //        //{

                //        //}
                //        KMl_text.RemoveAt(KMl_text.Count - 1);
                //        KMl_text.RemoveAt(KMl_text.Count - 1);
                //        // KML_Index -= 2;
                //    }


                //}

                //if (checkBox_EchoResponse.Checked == true)
                //{

                //    string ACKBack = string.Format("{0},ACK,{1}", ParseStrings[0], ParseStrings[ParseStrings.Length - 1].Replace(";", ",;"));
                //    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                //    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                //    SendDataToServer(mye.ConnectionNumber, b2);
                //}


            }
            else
                if (Key[0] == "STAT")
            {
                if (IwatcherPrint == true)
                {
                    //LogIWatcher.LogMessage(Color.Brown, Color.White, "Source: " + i_SourceMessage.ToString(), New_Line = false, Show_Time = true);
                    //if (i_Contact != null)
                    //{
                    //    LogIWatcher.LogMessage(Color.DarkBlue, Color.White, "\nName: " + i_Contact.Name, New_Line = false, Show_Time = false);
                    //}
                    //else
                    //{
                    //    LogIWatcher.LogMessage(Color.DarkBlue, Color.White, "\nName: ", New_Line = false, Show_Time = false);
                    //}
                    //LogIWatcher.LogMessage(Color.DarkOrange, Color.White, "\nSTATUS Message Received: ", New_Line = false, Show_Time = false);

                    _ =
                        "\n UNIT ID = " + ParseStrings[0].Replace(";", "") +
                        "\n SYSTEM STATE = " + Key[1] +
                        "\n IGN STATE = " + ParseStrings[2] +
                        "\n GP1 = " + ParseStrings[3] +
                        "\n GP2 = " + ParseStrings[4] +
                        "\n GP3 = " + ParseStrings[5] +
                        "\n Main Power Source = " + ParseStrings[6] +
                        "\n Back Up Battery problem indication = " + ParseStrings[7] +
                        "\n OUTPUT 1  STATE = " + ParseStrings[8] +
                        "\n OUTPUT 2  STATE = " + ParseStrings[9] +
                        "\n OUTPUT 3  STATE = " + ParseStrings[10] +
                        "\n OUTPUT 4  STATE = " + ParseStrings[11] +
                        "\n DATE = " + ParseStrings[12] +
                        "\n TIME  = " + ParseStrings[13] +
                        "\n GPS LATITUDE = " + ParseStrings[14] +
                        "\n GPS LONGTITUDE = " + ParseStrings[15] +
                        "\n VEHICLE SPEED = " + ParseStrings[16] +
                        "\n SPEED EVENT  = " + ParseStrings[17] +
                        "\n BATTERY LOW EVENT =" + ParseStrings[18] +
                        "\n BATTERY CUT OFF EVENT  = " + ParseStrings[19] +
                        "\n ACCIDENT EVENT = " + ParseStrings[20] +
                        "\n TOWING EVENT = " + ParseStrings[21] +
                        "\n TILT EVENT = " + ParseStrings[22];

                    //LogIWatcher.LogMessage(Color.Blue, Color.White, PositionString, New_Line = true, Show_Time = false);
                }
            }
            else
                    if (Key[0] == "GETCONFIG?")
            {
                if (IwatcherPrint == true)
                {


                    _ =
                        "\n UNIT ID = " + ParseStrings[0].Replace(";", "") +
                        "\n SUBSCRIBER 1 = " + ParseStrings[2] +
                        "\n SUBSCRIBER 2 = " + ParseStrings[3] +
                        "\n SUBSCRIBER 3 = " + ParseStrings[4] +
                        "\n SPEED LIMIT = " + ParseStrings[5] +
                        "\n vehicle battery threshold = " + ParseStrings[6] +
                        "\n pos message duration time interval = " + ParseStrings[7] +
                        "\n pos message according distance interval = " + ParseStrings[8] +
                        "\n status message duration time interval on sleep = " + ParseStrings[9] +
                        "\n Logger Counter = " + ParseStrings[10] +
                        "\n Tilt angle= " + ParseStrings[11] +
                        "\n Tilt sensitivity = " + ParseStrings[12] +
                        "\n Tilt Constant = " + ParseStrings[13] +
                        "\n TOW angle  = " + ParseStrings[14] +
                        "\n TOW sensitivity = " + ParseStrings[15] +
                        "\n TOW Constant = " + ParseStrings[16] +
                        "\n Anti Jamming detection = " + ParseStrings[17] +
                        "\n Anti Jamming configuration = " + ParseStrings[18] +
                        "\n GPRS reconnection = " + ParseStrings[19] +
                        "\n Satellite type = " + ParseStrings[20];

                    //LogIWatcher.LogMessage(Color.Blue, Color.White, PositionString, New_Line = true, Show_Time = false);
                }
            }
            else
                        if (Key[0] == "GETCONFIG2?")
            {
                if (IwatcherPrint == true)
                {

                    _ =
                        "\n UNIT ID = " + ParseStrings[0].Replace(";", "") +
                        "\n password = " + ParseStrings[2] +
                        "\n primary host address + port = " + ParseStrings[3] +
                        "\n primary access point name = " + ParseStrings[4] +
                        "\n fota host address + port = " + ParseStrings[5] +
                        "\n fota access point name = " + ParseStrings[6] +
                        "\n software version = " + ParseStrings[7] +
                        "\n GPS num of used satellites = " + ParseStrings[8] +
                        "\n GPS last timestamp  = " + ParseStrings[9];

                    //LogIWatcher.LogMessage(Color.Brown, Color.White, PositionString, New_Line = true, Show_Time = false);
                }
            }
        }
        private static readonly Mutex mutexACKSMSReceived = new Mutex();

        void ParseSerialPortSMSString(string IncomingString)
        {
            Boolean ret;
            try
            {
                IncomingString = IncomingString.Replace(System.Environment.NewLine, "");
                ret = ParseSMSCommand(IncomingString);
            }
            catch (Exception ex)
            {
                LogSMS.LogMessage(Color.Red, Color.LightGray, ex.ToString(), New_Line = true, Show_Time = true);
                //    return;
            }
        }

        void ParseSerialPortString(string IncomingString)
        {
            // Boolean ret;
            try
            {
                ParseUnitVersion(IncomingString.Replace(System.Environment.NewLine, " "));
                IncomingString = IncomingString.Replace(System.Environment.NewLine, "");
                ParseConfigCommand(IncomingString);
                //ret = ParseSMSCommand(IncomingString);

                ParseStatuPos(IncomingString);

                // ParseUnitVersion(IncomingString);





            }
            catch (Exception ex)
            {
                SerialPortLogger.LogMessage(Color.Red, Color.LightGray, ex.ToString(), New_Line = true, Show_Time = true);
                //    return;
            }
        }

        Boolean ParseSMSCommand(string IncomingString)
        {
            Boolean ret = false;
            Boolean IsCommandFound = true;
            while (IsCommandFound == true)
            {

                int StartCommand = IncomingString.IndexOf("{COMMAND_SMS_START}");
                int EndCommand = IncomingString.IndexOf("{COMMAND_SMS_END}");
                if (StartCommand >= 0 && EndCommand >= 0 && (EndCommand > StartCommand))
                {
                    ret = true;
                    StartCommand += "{COMMAND_SMS_START}".Length;
                    string CommandString = IncomingString.Substring(StartCommand, EndCommand - StartCommand);

                    //       LogSMS.LogMessage(Color.Cyan, Color.White, CommandString, New_Line = true, Show_Time = true);

                    EndCommand += "{COMMAND_SMS_END}".Length;
                    IncomingString = IncomingString.Substring(EndCommand);
                    IsCommandFound = true;

                    ModemStatus mdmStat = new ModemStatus(ref CommandString);

                    if (mdmStat.Valid == true)
                    {
                        richTextBox_ModemStatus.Invoke(new EventHandler(delegate
                        {
                            TimerClearModemStatus = 0;
                            if ((mdmStat.ModemRegistrationStatus == "1" || mdmStat.ModemRegistrationStatus == "5") && mdmStat.SIMStatus == "1")
                            {
                                richTextBox_ModemStatus.BackColor = Color.LightGreen;
                            }
                            else
                            {
                                richTextBox_ModemStatus.BackColor = Color.Red;
                            }

                            richTextBox_ModemStatus.Text =
                                  " Modem Registered: " + mdmStat.ModemRegistrationStatus +
                                "\n Sim: " + mdmStat.SIMStatus +
                                "\n Modem RSSI: " + mdmStat.RSSI +
                                "\n Operator Name: " + mdmStat.Operator +
                                "\n Modem IMEI: " + mdmStat.ModemIMEI +
                                "\n Sim IMSI: " + mdmStat.SimIMSI +
                                "\n Modem Update Counter: " + mdmStat.ModemEUpdateCounter;
                        }));

                    }

                    if (CommandString.Contains("SMS was Send To the Modem"))
                    {
                        mutexACKSMSReceived.WaitOne();
                        //   ACKSMSReceived = true;
                        mutexACKSMSReceived.ReleaseMutex();

                        LogSMS.LogMessage(Color.DarkBlue, Color.White, "SMS Send ACK received", New_Line = true, Show_Time = true);

                        if (checkBox_SMSencrypted.Checked == true)
                        {
                            string[] temp = CommandString.Split('[', ']');
                            LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                            LogSMS.LogMessage(Color.Green, Color.White, "Encrypted SMS (Copy to server Tab):\n" + temp[5], New_Line = true, Show_Time = false);

                            txtDataTx.Invoke(new EventHandler(delegate
                            {
                                txtDataTx.Text = temp[5];
                            }));

                        }
                    }
                    else
                    if (CommandString.Contains("Modem ring to Contact."))
                    {
                        string[] temp = CommandString.Split('[', ']');
                        LogSMS.LogMessage(Color.DarkBlue, Color.White, "Ring to contact, Phone Number: " + temp[3] + " Hangout: " + temp[5], New_Line = true, Show_Time = true);

                    }

                    if (CommandString.Contains("SMS_received Decrypted"))
                    {
                        string[] strsplit = CommandString.Split('[', ']');


                        ParseSMSText(strsplit[1], strsplit[3], Color.Brown);
                    }
                    else
                        if (CommandString.Contains("SMS_received"))
                    {
                        string[] strsplit = CommandString.Split('[', ']');


                        ParseSMSText(strsplit[1], strsplit[3], Color.Blue);
                    }
                }
                else
                {
                    IsCommandFound = false;
                }
            }

            return ret;
        }

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        void ParseSMSText(string i_Subscriber, string i_SMSText, Color i_ColorDisplay)
        {
            i_Subscriber = i_Subscriber.Replace("\"", "");
            PhoneBookContact ContactFound = MyPhoneBook.IsNumberExist(i_Subscriber);

            string ReceivedUnitID = String.Empty;
            try
            {
                if (i_SMSText.Contains(","))
                {
                    //ParseStrings = i_SMSText.Split(',');
                   // ReceivedUnitID = ParseStrings[0].Replace(";", "");
                }
            }
            catch (Exception ex)
            {
                LogSMS.LogMessage(Color.Black, Color.White, ex.ToString(), New_Line = true, Show_Time = true);
                //return;
            }



            if (ContactFound != null)
            {
                LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                LogSMS.LogMessage(i_ColorDisplay, Color.White, "\n SMS Received: ", New_Line = false, Show_Time = false);
                LogSMS.LogMessage(Color.DarkBlue, Color.Yellow, "\n Contact:  " + ContactFound.ToString(), New_Line = false, Show_Time = false);
                LogSMS.LogMessage(i_ColorDisplay, Color.White, "\n Text:  " + i_SMSText, New_Line = true, Show_Time = false);

                if (ReceivedUnitID != String.Empty)
                {
                    if (IsDigitsOnly(ReceivedUnitID))
                    {
                        if (ContactFound.UnitID != ReceivedUnitID)
                        {
                            ContactFound.UnitID = ReceivedUnitID;

                            UpdateDefaultsContacts();

                            UpdatePhoneBook();
                        }
                    }
                }
            }
            else
            {
                LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                LogSMS.LogMessage(i_ColorDisplay, Color.White, "SMS Received: " + "\n Number:  " + i_Subscriber + "\n Text:  " + i_SMSText, New_Line = true, Show_Time = false);



                PhoneBookContact NewContact = new PhoneBookContact
                {
                    Name = "",            //values preserved after close
                    Phone = i_Subscriber,
                    Notes = ""
                };

                if (ReceivedUnitID != String.Empty)
                {
                    if (IsDigitsOnly(ReceivedUnitID))
                    {
                        NewContact.UnitID = ReceivedUnitID;
                    }
                }
                //Do something here with these values

                MyPhoneBook.AddContactToPhoneBook(NewContact);

                UpdateDefaultsContacts();

                UpdatePhoneBook();

            }



            ParseStatuPos(i_SMSText);



        }
        string UnitVersion;
        void ParseUnitVersion(string IncomingString)
        {
            if (IncomingString.Contains("******START******") == true)
            {
                int StartConfig = IncomingString.IndexOf("******START******");
                StartConfig += "******START******".Length;
                UnitVersion = IncomingString.Substring(StartConfig);
                int EndConfig = UnitVersion.IndexOf("*********************");
                UnitVersion = UnitVersion.Substring(0, EndConfig);



            }

        }

        void ParseConfigCommand(string IncomingString)
        {
            int StartConfig = IncomingString.IndexOf("{CONFIG_START}");
            int EndConfig = IncomingString.IndexOf("{CONFIG_END}");
            if (StartConfig >= 0 && EndConfig > 0 && (EndConfig > StartConfig))
            {
                StartConfig += "{CONFIG_START}".Length;
                string ConfigString = IncomingString.Substring(StartConfig, EndConfig - StartConfig);

                if (ConfigString.Contains("CONFIGOK"))
                {
                    //TextBox_GenerateConfigFile_Text("Config OK", Color.LightGreen);
                }
                else
                {
                    SendToConfigPage(ConfigString, "Serial Port");
                }
            }
        }


        private void Button_StopPeriodaclly_Click(object sender, EventArgs e)
        {


        }

        private DateTime RetrieveLinkerTimestamp()
        {
            string filePath = System.Reflection.Assembly.GetCallingAssembly().Location;
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;
            byte[] b = new byte[2048];
            System.IO.Stream s = null;

            try
            {
                s = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                s.Read(b, 0, 2048);
            }
            finally
            {
                if (s != null)
                {
                    s.Close();
                }
            }

            int i = System.BitConverter.ToInt32(b, c_PeHeaderOffset);
            int secondsSince1970 = System.BitConverter.ToInt32(b, i + c_LinkerTimestampOffset);
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0);
            dt = dt.AddSeconds(secondsSince1970);
            dt = dt.AddHours(TimeZone.CurrentTimeZone.GetUtcOffset(dt).Hours);
            return dt;
        }


        private void Button_SetTimedOut_Click(object sender, EventArgs e)
        {

            try
            {
                int Timeoutvalue = int.Parse(textBox_ConnectionTimedOut.Text);

                //if(m_Server != null)
                //{
                //     m_Server.SetTimeoutinSeconds = Timeoutvalue * 10;
                //}
                TimeOutKeepAlivein100ms = Timeoutvalue * 10;
                GetDataIntervalCounter = 0;


            }
            catch
            {
                textBox_ConnectionTimedOut.Text = "300";
            }
        }

        //  static int LastNumOfConnections = 0;
        private void TextBox_NumberOfOpenConnections_TextChanged(object sender, EventArgs e)
        {

            if (m_Server != null)
            {

                if (m_Server.NumberOfOpenConnections > 1)
                {
                    // IsTimedOutTimerEnabled = true;
                    textBox_NumberOfOpenConnections.BackColor = Color.Orange;
                    //ListenBox.BackColor = Color.Green;

                    ServerLogger.LogMessage(Color.Orange, Color.White, "Num Of Connections is bigger than one, " + m_Server.NumberOfOpenConnections, true, true);

                }
                else
                    if (m_Server.NumberOfOpenConnections == 1)
                {
                    //IsTimedOutTimerEnabled = true;
                    //ListenBox.BackColor = Color.Green;
                    textBox_NumberOfOpenConnections.BackColor = Color.Green;
                }
                else
                {
                    // IsTimedOutTimerEnabled = false;
                    textBox_NumberOfOpenConnections.BackColor = default;
                }

                GetDataIntervalCounter = 0;


                //if (LastNumOfConnections > m_Server.NumberOfOpenConnections)
                //{
                //    //ListenBox.BackColor = Color.Yellow;
                //}

                // LastNumOfConnections = m_Server.NumberOfOpenConnections;
            }

        }

        private void Button_AddDendSingleCommand_Click(object sender, EventArgs e)
        {
            try
            {
                //textBox_AddSendSingleCommand.Text = CommandsDescription[comboBox_AddSendSingleCommand.SelectedIndex].Format;
            }
            catch
            {
            }
        }

        private void ComboBox_AddSendSingleCommand_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button_ValidateCommand_Click(object sender, EventArgs e)
        {


        }


        private void Button6_Click(object sender, EventArgs e)
        {
            //button_ValidateCommand.Enabled = true;
        }

        private void Button6_Click_1(object sender, EventArgs e)
        {
            //Config_Sys.Enabled = true;
            //ConfigProcessExit = true;
        }

       
        private void CheckBox_EchoResponse_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        BinaryReader m_BinaryReader;
        readonly Dictionary<int, string> FOTAData = new Dictionary<int, string>();
        private void Button5_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                ConfigFileName = openFileDialog1.FileName;

                textBox_FOTA.Text = openFileDialog1.FileName;

                try
                {
                    m_BinaryReader = new BinaryReader(File.Open(ConfigFileName, FileMode.Open));

                    int length = (int)m_BinaryReader.BaseStream.Length;
                    textBox_TotalFileLength.Text = length.ToString();
                    textBox_TotalFrames1280Bytes.Text = (Math.Ceiling((decimal)length / 1280)).ToString();

                    textBox_MaximumNumberReceivedRequest.Invoke(new EventHandler(delegate
                    {

                        textBox_MaximumNumberReceivedRequest.Text = "";

                    }));


                    //txtDataTx.Text = ";<1234>STARTFOTA=," + (Math.Ceiling((decimal)length / 1280)).ToString() + "," + length.ToString() + ",;";
                    string StartFota = string.Format(";<{0}>STARTFOTA=,{1},{2},;", "", textBox_TotalFrames1280Bytes.Text, textBox_TotalFileLength.Text);
                    txtDataTx.Text = StartFota;
                    richTextBox_TextSendSMS.Text = StartFota;
                    //AddCommandToCommands(StartFota);

                    FOTAData.Clear();
                    for (int i = 0; i < int.Parse(textBox_TotalFrames1280Bytes.Text); i++)
                    {


                        // int PositionInFile = 1280 * i;
                        //  m_BinaryReader.ReadBytes(PositionInFile);
                        byte[] buffer = new byte[1280];

                        for (int k = 0; k < 1280; k++)
                        {
                            buffer[k] = 0x30;
                        }
                        byte[] temp = m_BinaryReader.ReadBytes(1280);

                        temp.CopyTo(buffer, 0);

                        string str = Encoding.ASCII.GetString(buffer);
                        byte b = CalcCheckSumbuffer(buffer);
                        string SendString = string.Format("@$@FOTAS,{0},{1},{2}", i, Encoding.ASCII.GetString(buffer), CalcCheckSumbuffer(buffer).ToString("x2"));

                        FOTAData[i] = SendString;


                    }

                    m_BinaryReader.Close();




                    button_StartFOTAProcess.Enabled = true;



                }
                catch (Exception ex)
                {
                    ServerLogger.LogMessage(Color.Blue, Color.White, ex.ToString(), New_Line = true, Show_Time = false);
                }

                if (m_BinaryReader != null && ConfigFileName != null)
                {
                    button_StartFOTA.Enabled = true;
                }
                //AllFileLines = File.ReadAllText(ConfigFileName);



            }
        }

        private void TextBox_FOTA_TextChanged(object sender, EventArgs e)
        {
            if (textBox_FOTA.Text.Length > 0)
            {
                textBox_FOTA.BackColor = Color.White;
            }
        }

        private void TextBox_MaximumNumberReceivedRequest_TextChanged(object sender, EventArgs e)
        {
            if (textBox_MaximumNumberReceivedRequest.Text.Length > 0)
            {
                textBox_MaximumNumberReceivedRequest.BackColor = Color.White;
            }
        }

        private void TextBox_TotalFrames256Bytes_TextChanged(object sender, EventArgs e)
        {
            //if (textBox_TotalFrames256Bytes.Text.Length > 0)
            //{
            //    textBox_TotalFrames256Bytes.BackColor = Color.White;
            //}
        }

        private void Button33_Click(object sender, EventArgs e)
        {
            //if (textBox_TotalFrames1280Bytes.Text.Length > 0 && textBox_TotalFileLength.Text.Length > 0)
            //{
            //    //txtDataTx.Text = ";<" + Monitor.Properties.Settings.Default.SystemPassword + ">STARTFOTA=," + textBox_TotalFrames1280Bytes.Text + "," + textBox_TotalFileLength.Text + ",;";
            //    txtDataTx.Text = string.Format(";<{0}>STARTFOTA=,{1},{2},;", Monitor.Properties.Settings.Default.SystemPassword, textBox_TotalFrames1280Bytes.Text, textBox_TotalFileLength.Text);           
            //}


            ServerLogger.LogMessage(Color.Blue, Color.White, "****************** System ID's Status ****************** ", New_Line = true, Show_Time = true);
            foreach (var pair in IDToFOTA_Status)
            {
                ServerLogger.LogMessage(Color.Blue, Color.White, pair.Key + "   " + pair.Value + " \n", New_Line = false, Show_Time = false);

            }
        }

        private void Button35_Click(object sender, EventArgs e)
        {
            //textBox_MaximumNumberReceivedRequest.Text = "";
            IDToFOTA_Status.Clear();
            PrintFotaIDStatus();
            //textBox_FOTAEnd.BackColor = default(Color);
            //textBox_FOTAEnd.Text = "";
        }

        private void Button34_Click(object sender, EventArgs e)
        {
            int NumOfSendingPackets = 0, NumOfMissingPackets = 0;
            string[] StringSplt = textBox_MaximumNumberReceivedRequest.Text.Split(',');
            try
            {
                int NumOfPacketes = int.Parse(textBox_TotalFrames1280Bytes.Text);

                ServerLogger.LogMessage(Color.Blue, Color.White, "****************** Packets Reusults Which Didn't Found ****************** ", New_Line = true, Show_Time = true);
                for (int i = 0; i < NumOfPacketes; i++)
                {
                    bool found = false;
                    foreach (string str in StringSplt)
                    {
                        try
                        {
                            int PacketNum = int.Parse(str);
                            if (i == 0)
                            {
                                NumOfSendingPackets++;
                            }
                            if (i == PacketNum)
                            {
                                found = true;
                            }
                        }
                        catch
                        {
                        }
                    }
                    if (found == true)
                    {
                        //   ServerLogger.LogMessage(Color.Blue, Color.White,  i + " X ", New_Line = true, Show_Time = false);
                    }
                    else
                    {
                        NumOfMissingPackets++;
                        ServerLogger.LogMessage(Color.Blue, Color.White, i + ",  ", New_Line = false, Show_Time = false);
                    }
                }
                ServerLogger.LogMessage(Color.Blue, Color.White, "\n\nTotal Packets: " + NumOfPacketes + ", ToTal Sending Packets: " + NumOfSendingPackets + ", ToTal Missing Packets: " + NumOfMissingPackets, New_Line = true, Show_Time = false);
                ServerLogger.LogMessage(Color.Blue, Color.White, "****************** Packets Reusults End ****************** ", New_Line = true, Show_Time = true);
            }
            catch (Exception ex)
            {
                ServerLogger.LogMessage(Color.Orange, Color.White, ex.ToString(), true, true);
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void UpdateSerialPortHistory(string i_SendString)
        {
            Boolean Found = false;

            foreach (string str in Monitor.Properties.Settings.Default.SerialPort_History)
            {
                //comboBox_SerialPortHistory.Items.Add((object)str);
                // comboBox_SMSCommands.Items.Add(str);
                if (str == i_SendString)
                {
                    Found = true;
                }
            }

            if (Found == false)
            {
                Monitor.Properties.Settings.Default.SerialPort_History.Add(i_SendString);
                Monitor.Properties.Settings.Default.Save();
            }

            if (CommandsHistoy.Count > 0)
            {
                String LastCommand = CommandsHistoy[CommandsHistoy.Count - 1];

                if(LastCommand != i_SendString)
                {
                    CommandsHistoy.Add(i_SendString);
                }
            }

            


            //if (Monitor.Properties.Settings.Default.SerialPort_History != null)
            //{
            //    CommandsHistoy.Clear();
            //    foreach (string str in Monitor.Properties.Settings.Default.SerialPort_History)
            //    {
            //        CommandsHistoy.Add(str);
            //        // comboBox_SMSCommands.Items.Add(str);
            //    }
            //}
        }

        void UpdateSerialPortComboBox()
        {
            if (Monitor.Properties.Settings.Default.SerialPort_History != null)
            {
                CommandsHistoy.Clear();
                foreach (string str in Monitor.Properties.Settings.Default.SerialPort_History)
                {
                    CommandsHistoy.Add(str);
                    // comboBox_SMSCommands.Items.Add(str);
                }
            }
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            bool IsSent = false;
            if (checkBox_SendHexdata.Checked == true)
            {
                String tempStr = textBox_SendSerialPort.Text.Replace(" ", ""); 

                byte[] buffer = StringToByteArray(tempStr);

                if (buffer != null)
                {
                    IsSent = SerialPortSendData(buffer);
                }
                else
                {
                    SerialPortLogger.LogMessage(Color.Red, Color.LightGray, "Not Hex data format for example: aabbcc is 0xAA 0xBB 0xCC", New_Line = true, Show_Time = false);
                }

                if (IsSent == true)
                {
                    UpdateSerialPortHistory(textBox_SendSerialPort.Text);

                //    UpdateSerialPortComboBox();

                    if (checkBox_DeleteCommand.Checked == true)
                    {
                        textBox_SendSerialPort.Text = "";
                    }

                    TxLabelTimerBlink = 5;

                    SerialPortLogger.LogMessage(Color.Purple, Color.Azure, "", New_Line = false, Show_Time = true);
                    SerialPortLogger.LogMessage(Color.Purple, Color.Azure, "Tx:>", false, false);
                    SerialPortLogger.LogMessage(Color.Purple, Color.LightGray, ConvertByteArraytToString(buffer), true, false);

                    

                }


            }
            else
            {


                String tempStr = textBox_SendSerialPort.Text.Replace("\\n", "\n");
                tempStr = tempStr.Replace("\\r", "\r");
                byte[] buffer = Encoding.ASCII.GetBytes(tempStr);

                 IsSent = SerialPortSendData(buffer);

                if (IsSent == true)
                {
                    UpdateSerialPortHistory(textBox_SendSerialPort.Text);

                //    UpdateSerialPortComboBox();

                    if (checkBox_DeleteCommand.Checked == true)
                    {
                        textBox_SendSerialPort.Text = "";
                    }

                    TxLabelTimerBlink = 10;

                    SerialPortLogger.LogMessage(Color.Purple, Color.Azure, "", New_Line = false, Show_Time = true);
                    SerialPortLogger.LogMessage(Color.Purple, Color.Azure, "Tx:>", false, false);
                    SerialPortLogger.LogMessage(Color.Purple, Color.LightGray, Encoding.ASCII.GetString(buffer), true, false);

                }


            }





        }

        private void Button29_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox_GenerateConfigFile_Clear();
                bool IsAllGreen = CheckAllTextboxConfig();

                if (IsAllGreen == false)
                {
                    //textBox_GenerateConfigFile.Text = " Some Of filds are Red!!!";
                    //textBox_GenerateConfigFile.BackColor = Color.Red;
                    return;
                }
                else
                {
                    //textBox_GenerateConfigFile.BackColor = Color.LightGreen;
                }

                //  string UnitID = textBox_ConfigUnitID.Text;
                string UnitID = "00000000000"; 
                string Config_file_name = "Config_Date-" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "_UnitID-" + UnitID + ".txt";

                SaveFileDialog saveFileDialog1 = new SaveFileDialog
                {
                    Filter = "Text Files | *.txt",
                    FilterIndex = 1,
                    RestoreDirectory = true
                };

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    File.Delete(saveFileDialog1.FileName);
                    using (StreamWriter sw = File.AppendText(saveFileDialog1.FileName))
                    {
                        //List<S1_Protocol.S1_Messege_Builder.Command_Description> ret = S1_Protocol.S1_Messege_Builder.NonCommand_GetALLconfigCommandsDescription();

                        sw.WriteLine("// " + "Date: " + DateTime.Now.ToString() + "  Unit ID: " + UnitID);
                        sw.WriteLine();
                        sw.WriteLine();

                        string SendStr = GenerateConfigCommand();

                        SendStr = SendStr.Replace(";", ",");

                        byte[] buf = Encoding.ASCII.GetBytes(SendStr);
                        int Size = buf.Length;
                        Byte CheckSum = CalcCheckSumbufferSize(buf);


                        SendStr = ";{CONFIG_START}," + SendStr + "," + Size + "," + CheckSum + ",{CONFIG_END};";

                        sw.Write(SendStr);

                    }
                }

                // This text is always added, making the file longer over time 
                // if it is not deleted. 


                //textBox_GenerateConfigFile.BackColor = Color.Green;
                //textBox_GenerateConfigFile.Text = "File has been saved: \n" + saveFileDialog1.FileName ;
                //textBox_GenerateConfigFile.BackColor = Color.LightGreen;
            }
            catch (Exception ex)
            {

                ex.ToString(); //Gil: just remove warning.
                //textBox_GenerateConfigFile.Text = ex.ToString();
            }
        }

        private void Button31_Click(object sender, EventArgs e)
        {
            TextBox_SourceConfig_Clear();

            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                ConfigFileName = openFileDialog1.FileName;

                textBox_SourceConfig.Text = "File have been chosen: \n" + openFileDialog1.FileName;

                string[] lines = System.IO.File.ReadAllLines(ConfigFileName);

                foreach (string line in lines)
                {
                    if (line.Contains("//") || line == "")
                    {

                    }
                    else
                    {
                        string str;
                        //";{CONFIG_START}," + SendStr + ",{CONFIG_END};";
                        str = line.Replace(";{CONFIG_START},,", "");
                        str = str.Replace(",{CONFIG_END};", "");
                        SendToConfigPage(str, "File");
                    }
                }


            }



            //ParseConfigString(";23421342134,CONFIG=,12321321,434343434,656565656,55554,43434,66665,6565645456,6,6,6,6,6,6,6,6,5,5,5,5,5,5,5,5,5,4,4,4,4,4,4,4,4,4,3,3,3,3,6,6,6,41,3;");

        }

        bool ParseConfigString(string i_Config)
        {
            try
            {

                string[] StringSplit = i_Config.Replace(";", "").Split(',');

                if (StringSplit[0].Length > 17 || StringSplit[0].Length < 12)
                {
                    return false;
                }



                // Store keys in a List
                //List<string> list = new List<string>(Dictionary_ConfigurationTextBoxes.Keys);
                //// Loop through list
                //int i = 2;
                //foreach (string k in list)
                //{
                //    TextBox temp = Dictionary_ConfigurationTextBoxes[k];

                //    temp.Invoke(new EventHandler(delegate
                //    {
                //        if (i < StringSplit.Length)
                //        {
                //            temp.Text = StringSplit[i];
                //        }
                //    }));
                //    i++;
                //}
                //textBox_Config1.Text = StringSplit[2];
                //textBox_Config2.Text = StringSplit[3];
                //textBox_Config3.Text = StringSplit[4];
                //textBox_Config4.Text = StringSplit[5];
                //textBox_Config5.Text = StringSplit[6];
                //textBox_Config6.Text = StringSplit[7];
                //textBox_Config7.Text = StringSplit[8];
                //textBox_Config8.Text = StringSplit[9];
                //textBox_Config9.Text = StringSplit[10];
                //textBox_Config10.Text = StringSplit[11];
                //textBox_Config11.Text = StringSplit[12];
                //textBox_Config12.Text = StringSplit[13];
                //textBox_Config13.Text = StringSplit[14];
                //textBox_Config14.Text = StringSplit[15];
                //textBox_Config15.Text = StringSplit[16];
                //textBox_Config16.Text = StringSplit[17];
                //textBox_Config17.Text = StringSplit[18];
                //textBox_Config18.Text = StringSplit[19];
                //textBox_Config19.Text = StringSplit[20];
                //textBox_Config20.Text = StringSplit[21];
                //textBox_Config21.Text = StringSplit[22];
                //textBox_Config22.Text = StringSplit[23];
                //textBox_Config23.Text = StringSplit[24];
                //textBox_Config24.Text = StringSplit[25];
                //textBox_Config25.Text = StringSplit[26];
                //textBox_Config26.Text = StringSplit[27];
                //textBox_Config27.Text = StringSplit[28];

                return true;
            }
            catch (Exception ex)
            {
                textBox_SourceConfig.Invoke(new EventHandler(delegate
                {
                    textBox_SourceConfig.Text = ex.ToString();
                    textBox_SourceConfig.BackColor = Color.Red;
                }));


                return false;
            }
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {

        }

        private void Button6_Click_2(object sender, EventArgs e)
        {
            //   textBox_SendSerialPort.Text = "<1234>READ?,;";
            TextBox_SourceConfig_Clear();

            string Sendstr = string.Format(";READ?,;");
            byte[] buffer = Encoding.ASCII.GetBytes(Sendstr);
            bool IsSent = SerialPortSendData(buffer);

            if (IsSent == true)
            {
                textBox_SourceConfig.Text = "Command sent";

            }

        }

        private void TextBox_GenerateConfigFile_TextChanged(object sender, EventArgs e)
        {

        }

        //bool IsDigitsOnly(string str)
        //{
        //    foreach (char c in str)
        //    {
        //        if (c < '0' || c > '9')
        //            return false;
        //    }

        //    return true;
        //}

        enum ConfigDataType
        {
            PosPeriod5Sec,
            AutoARM,
            Angel,
            PeriodStatus,
            SpeedLimit,
            Number,
            Float,
            BatLevel,
            JammingSens,
            EveryThing,
            AlarmViaSMS,
            Unit_ID,
            Subscriber,
            Password,
            Boolean,
            IpAddress,
            Port,
            GPRSDisconnectNum,
            GPSType,
            DISARMCODE,
            CutSpeed
        };
        bool CheckSubscriberValid(string i_String, ConfigDataType i_DataType)
        {
            bool ret;
            try
            {


                switch (i_DataType)
                {
                    case ConfigDataType.CutSpeed:
                        if (i_String.Length <= 3 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Num = int.Parse(i_String);

                            if (Num >= 0 && Num <= 20 || Num == 255)
                            {
                                ret = true;
                            }
                            else
                            {
                                ret = false;
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;
                    case ConfigDataType.DISARMCODE:
                        if (i_String.Length == 4 && (Regex.IsMatch(i_String, @"^[1-5]+$") || Regex.IsMatch(i_String, @"^[0]+$") || i_String == "9999"))
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;
                    case ConfigDataType.GPSType:
                        if (i_String.Length == 1 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Num = int.Parse(i_String);

                            if (Num >= 0 && Num <= 2)
                            {
                                ret = true;
                            }
                            else
                            {
                                ret = false;
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.PosPeriod5Sec:
                        if (i_String.Length < 5 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Num = int.Parse(i_String);

                            if (Num > 0)
                            {
                                ret = true;
                            }
                            else
                            {
                                ret = false;
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.AutoARM:
                        if (i_String.Length < 5 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Num = int.Parse(i_String);

                            if (Num >= 2 && Num <= 300)
                            {
                                ret = true;
                            }
                            else
                            {
                                ret = false;
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.EveryThing:
                        ret = true;
                        break;

                    case ConfigDataType.PeriodStatus:

                        if (i_String.Length < 5 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Num = int.Parse(i_String);

                            if (Num >= 0 && Num <= 96)
                            {
                                ret = true;
                            }
                            else
                            {
                                ret = false;
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.Angel:

                        if (i_String.Length < 5 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Num = int.Parse(i_String);

                            if (Num >= 0 && Num <= 360)
                            {
                                ret = true;
                            }
                            else
                            {
                                ret = false;
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.SpeedLimit:

                            ret = false;

                        break;

                    case ConfigDataType.BatLevel:

                        if (i_String.Length < 3 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Num = int.Parse(i_String);

                            if (Num >= 0 && Num <= 9)
                            {
                                ret = true;
                            }
                            else
                            {
                                ret = false;
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.JammingSens:

                        if (i_String.Length < 3 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Jamming = int.Parse(i_String);

                            if (Jamming >= 20 && Jamming <= 70)
                            {
                                ret = true;
                            }
                            else
                            {
                                ret = false;
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.Float:
                        float f;

                        if (float.TryParse(i_String, out f))
                        {

                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }



                        break;

                    case ConfigDataType.Number:
                        if (Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;
                    case ConfigDataType.GPRSDisconnectNum:
                        if (i_String.Length < 6 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;
                    case ConfigDataType.Port:
                        if (i_String.Length < 6 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.AlarmViaSMS:
                        if (i_String.Length < 8 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            ret = true;
                            UpdateAlarmCheckBoxes();
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.IpAddress:
                        //                IPAddress address;
                        //if (IPAddress.TryParse(i_String, out address))
                        if (i_String.Length > 4)
                        {
                            //Valid IP, with address containing the IP
                            ret = true;
                        }
                        else
                        {
                            //Invalid IP
                            ret = false;
                        }
                        break;
                    case ConfigDataType.Subscriber:
                        if (i_String == "0")
                        {
                            ret = true;
                        }
                        else
                        if (i_String.Length < 6)
                        {
                            ret = false;
                        }
                        else
                            if (i_String.Length < 20 && (i_String.StartsWith("+") || i_String.StartsWith("00")) && Regex.IsMatch(i_String.Substring(1), @"^[0-9]+$"))
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.Password:

                        if (i_String.Length < 15)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.Boolean:
                        if (i_String == "0" || i_String == "1")
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.Unit_ID:
                        if (i_String.Length > 14 && i_String.Length < 17 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    default:
                        ret = false;
                        break;
                }
            }
            catch 
            {
                //TextBox_GenerateConfigFile_Text(ex.ToString(), Color.Red);
                ret = false;
            }

            return ret;
        }

        bool CheckAllTextboxConfig()
        {

            //List<string> list = new List<string>(Dictionary_ConfigurationTextBoxes.Keys);
            //// Loop through list
            ////bool IsAllGreen = true;
            //foreach (string k in list)
            //{
            //    TextBox temp = Dictionary_ConfigurationTextBoxes[k];
            //    if (temp.BackColor == Color.Red && temp.Visible == true)
            //    {
            //        return false;
            //    }
            //}

            return true;
        }

        private void TextBox_Config1_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Subscriber);
        }

        private void TextBox_Config2_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Subscriber);
        }

        private void TextBox_Config3_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Subscriber);
        }

        void CheckConfigTextboxValidData(TextBox i_TextBox, ConfigDataType i_ConfigDataType)
        {

            i_TextBox.Invoke(new EventHandler(delegate
            {
                if (i_TextBox.Text == "" || i_TextBox.Text == "@%@")
                {
                    i_TextBox.Text = "";
                    i_TextBox.BackColor = default;
                }
                else
                    if (CheckSubscriberValid(i_TextBox.Text, i_ConfigDataType) == true)
                {
                    i_TextBox.BackColor = Color.LightGreen;
                }
                else
                {
                    //  i_TextBox.Visible = true;
                    i_TextBox.BackColor = Color.Red;
                }
            }));
        }

        private void TextBox_Config4_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Password);
        }

        private void TextBox_Config5_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.BatLevel);
        }

        void TextBox_SourceConfig_Clear()
        {
            textBox_SourceConfig.BackColor = default;
            textBox_SourceConfig.Text = "";
        }

        private void Button3_Click_2(object sender, EventArgs e)
        {
            //   textBox_SendSerialPort.Text = "<1234>READ?,;"

            TextBox_SourceConfig_Clear();

            using (var form = new System_Password())
            {
                form.Load += new EventHandler(Password_form_Load);
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.Password;            //values preserved after close
                                                           //Do something here with these values

                    //      Monitor.Properties.Settings.Default.SystemPassword = val;

                    Monitor.Properties.Settings.Default.Save();

                    string Sendstr = string.Format("<{0}>READ?,;", val);


                    if (form.ConnectionNumbers.Text == "None")
                    {
                        return;
                    }
                    try
                    {
                        string SendString = Sendstr;
                        Object objData = SendString;
                        byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
                        SendDataToServer(form.ConnectionNumbers.SelectedItem.ToString(), byData);

                        textBox_SourceConfig.Text = "Message has been sent";
                        textBox_SourceConfig.BackColor = Color.LightGreen;
                    }
                    catch (Exception ex)
                    {
                        textBox_SourceConfig.Text = ex.ToString();
                        textBox_SourceConfig.BackColor = Color.Red;
                    }



                }
            }


        }

        void Password_form_Load(object sender, EventArgs e)
        {
            System_Password form = (System_Password)sender;
            form.ConnectionNumbers.DataSource = comboBox_ConnectionNumber.DataSource;
            form.PasswordText.Text = "";
        }

        string GenerateConfigCommand()
        {

            //sw.Write(";" + UnitID + ",CONFIG=,");
            //List<string> list = new List<string>(Dictionary_ConfigurationTextBoxes.Keys);
            //// Loop through list

            //foreach (string k in list)
            //{
            //    TextBox temp = Dictionary_ConfigurationTextBoxes[k];
            //    string Field = temp.Text;
            //    if (Field == "")
            //    {
            //        Field = "@%@";
            //    }
            //    SendStr += Field + ",";
            //}

            string SendStr = ";";

            return SendStr;
        }


        //void CleartextBox_GenerateConfigFile()
        //{
        //    textBox_GenerateConfigFile.Text = "";
        //    textBox_GenerateConfigFile.BackColor = default(Color);
        //}

        private void Button28_Click_1(object sender, EventArgs e)
        {
            try
            {
                TextBox_GenerateConfigFile_Clear();

                bool IsAllGreen = CheckAllTextboxConfig();

                if (IsAllGreen == false)
                {
                    //textBox_GenerateConfigFile.Text = " Some Of filds are Red!!!";
                    //textBox_GenerateConfigFile.BackColor = Color.Red;
                    return;
                }
                else
                {
                    //textBox_GenerateConfigFile.BackColor = Color.LightGreen;
                }



                using (var form = new System_Password())
                {
                    form.Load += new EventHandler(Password_form_Load);
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string val = form.Password;            //values preserved after close
                        //Do something here with these values

                        string SendStr = GenerateConfigCommand();

                        SendStr = SendStr.Replace(";", ",");

                        SendStr = ";{CONFIG_START}," + SendStr + ",{CONFIG_END};";


                        if (form.ConnectionNumbers.Text == "None")
                        {
                            return;
                        }
                        try
                        {
                            string SendString = SendStr;
                            Object objData = SendString;
                            byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
                            SendDataToServer(form.ConnectionNumbers.SelectedItem.ToString(), byData);

                            //textBox_GenerateConfigFile.Text = "Message has been sent";
                            //textBox_GenerateConfigFile.BackColor = Color.LightGreen;
                        }
                        catch (Exception ex)
                        {
                            ex.ToString(); //Gil: just remove warning.
                            //textBox_GenerateConfigFile.Text = ex.ToString();
                            //textBox_GenerateConfigFile.BackColor = Color.Red;
                        }



                    }
                }

                //string Config_file_name = "Config_Date-" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "_UnitID-" + UnitID + ".txt";


                // This text is always added, making the file longer over time 
                // if it is not deleted. 

                //List<S1_Protocol.S1_Messege_Builder.Command_Description> ret = S1_Protocol.S1_Messege_Builder.NonCommand_GetALLconfigCommandsDescription();




                //textBox_GenerateConfigFile.BackColor = Color.Green;

            }
            catch (Exception ex)
            {
                ex.ToString(); //Gil: just remove warning.
                //textBox_GenerateConfigFile.Text = ex.ToString();
            }
        }

        private void Button2_Click_2(object sender, EventArgs e)
        {
            try
            {
                TextBox_GenerateConfigFile_Clear();
                bool IsAllGreen = CheckAllTextboxConfig();

                if (IsAllGreen == false)
                {
                    //textBox_GenerateConfigFile.Text = " Some Of filds are Red!!!";
                    //textBox_GenerateConfigFile.BackColor = Color.Red;
                    return;
                }
                else
                {

                }


                //string Config_file_name = "Config_Date-" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "_UnitID-" + UnitID + ".txt";


                // This text is always added, making the file longer over time 
                // if it is not deleted. 

                //List<S1_Protocol.S1_Messege_Builder.Command_Description> ret = S1_Protocol.S1_Messege_Builder.NonCommand_GetALLconfigCommandsDescription();

                string SendStr = GenerateConfigCommand();

                SendStr = SendStr.Replace(";", ",");

                byte[] buf = Encoding.ASCII.GetBytes(SendStr);
                int Size = buf.Length;
                Byte CheckSum = CalcCheckSumbufferSize(buf);


                SendStr = ";{CONFIG_START}," + SendStr + "," + Size + "," + CheckSum + ",{CONFIG_END};";
                byte[] buffer = Encoding.ASCII.GetBytes(SendStr);
                bool IsSent = SerialPortSendData(buffer);

                if (IsSent == true)
                {
                    //textBox_GenerateConfigFile.BackColor = Color.Yellow;
                    //textBox_GenerateConfigFile.Text = "Config has been sent";

                }

                //textBox_GenerateConfigFile.BackColor = Color.Green;
                //textBox_GenerateConfigFile.Text = "File " +  + " saved in directory \n" + Directory.GetCurrentDirectory();
            }
            catch (Exception ex)
            {
                ex.ToString(); //Gil: just remove warning.
                //textBox_GenerateConfigFile.Text = ex.ToString();
            }
        }

        private void Button30_Click(object sender, EventArgs e)
        {
            using (var form = new System_Password())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.Password;            //values preserved after close
                    //Do something here with these values

                    //for example
                    this.textBox_SourceConfig.Text = val;
                }
            }
        }

        //textBox_UnitVersion



        void TextBox_GenerateConfigFile_Clear()
        {
            //textBox_GenerateConfigFile.Invoke(new EventHandler(delegate
            //    {
            //        textBox_GenerateConfigFile.Text = "";
            //        textBox_GenerateConfigFile.BackColor = default(Color);
            //    }));
        }




        private void TextBox_ConfigUnitID_TextChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //List<string> list = new List<string>(Dictionary_ConfigurationTextBoxes.Keys);
            //// Loop through list

            //foreach (string k in list)
            //{
            //    TextBox temp = Dictionary_ConfigurationTextBoxes[k];
            //    temp.Visible = true;
            //}

        }

        private void Label26_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox_LoadedConfig_Enter(object sender, EventArgs e)
        {

        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void TextBox_Config13_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.AlarmViaSMS);

        }

        void UpdateAlarmCheckBoxes()
        {
            
        }

        private void CheckBox_config_Bit0_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        void UpdateTextBox13()
        {

            

        }

        private void CheckBox_config_Bit4_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void CheckBox_config_Bit5_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void CheckBox_config_Bit6_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void CheckBox_config_Bit7_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void CheckBox_config_Bit8_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void CheckBox_config_Bit9_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void CheckBox_config_Bit10_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void Button32_Click(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void TextBox_Config10_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.IpAddress);
        }

        private void TextBox_Config11_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.IpAddress);
        }

        private void TextBox_Config12_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Port);
        }

        private void TextBox_Config24_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Boolean);
        }

        private void TextBox_Config23_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Boolean);
        }

        private void TextBox_Config27_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.GPRSDisconnectNum);
        }

        private void TextBox_Config9_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.EveryThing);
        }

        private void TextBox_Config29_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Boolean);
        }

        private void TextBox_Config26_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.JammingSens);
        }

        private void TextBox_Config6_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Port);
        }

        private void TextBox_Config7_TextChanged(object sender, EventArgs e)
        {

            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.SpeedLimit);


        }

        private void TextBox_Config8_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.PeriodStatus);
        }

        private void TextBox_Config14_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Angel);
        }

        private void TextBox_Config15_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Number);
        }

        private void TextBox_Config16_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Number);
        }

        private void TextBox_Config17_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Angel);
        }

        private void TextBox_Config18_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Number);
        }

        private void TextBox_Config19_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Number);
        }

        private void TextBox_Config20_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Angel);
        }

        private void TextBox_Config21_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Number);
        }

        private void TextBox_Config22_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.PosPeriod5Sec);
        }

        private void TextBox_Config28_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Number);
        }

        private void TextBox_Config30_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Number);
        }

        private void TextBox_Config25_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Float);
        }

        private void CheckBox_RecordGeneral_CheckedChanged(object sender, EventArgs e)
        {

        }



        private void TextBox_IDKey_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtPortNo_TextChanged(object sender, EventArgs e)
        {
            Monitor.Properties.Settings.Default.Start_Port = txtPortNo.Text.ToString();

            Monitor.Properties.Settings.Default.Save();
        }

        private void Button33_Click_1(object sender, EventArgs e)
        {
            using (var form = new AddContact())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {

                    PhoneBookContact NewContact = new PhoneBookContact
                    {
                        Name = form.ContactName,            //values preserved after close
                        Phone = form.ContactPhone,
                        Notes = form.ContactNotes,
                        Password = form.ContactPassword,
                        UnitID = form.ContactIMEI
                    };
                    //Do something here with these values

                    MyPhoneBook.AddContactToPhoneBook(NewContact);

                    UpdateDefaultsContacts();

                    UpdatePhoneBook();


                }
            }
        }

        bool CheckValidSMS(string i_SMS)
        {
            try
            {
                //;<S1BM>CDC=,1111,;
                if (i_SMS.Contains("CDC"))
                {
                    int CommaIndex = i_SMS.IndexOf(',');
                    string str = i_SMS.Substring(CommaIndex + 1, 4);
                    if (!(str.Length == 4 && (Regex.IsMatch(str, @"^[1-5]+$") || Regex.IsMatch(str, @"^[0]+$"))))
                    {
                        return false;
                    }


                }
                return true;

            }
            catch (Exception ex)
            {
                LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                LogSMS.LogMessage(Color.Red, Color.White, ex.ToString(), New_Line = true, Show_Time = false);

                return false;
            }
        }

        string ReturnCommandWithPassword(string i_Command, PhoneBookContact i_Contact)
        {
            string temp ;
            string command = i_Command;
            int endindex = command.IndexOf('>');
            if (endindex >= 0 && checkBox_SendSMSAsIs.Checked == false)
            {
                temp = ";<" + i_Contact.Password + ">" + command.Substring(endindex + 1);
            }
            else
            {
                temp = command;
            }

            return temp;
        }

        private void Button39_Click(object sender, EventArgs e)
        {
            groupBox34.Enabled = false;
            foreach (var item in checkedListBox_PhoneBook.CheckedItems)
            {
                if (item != null)
                {
                    string SMSText = ReturnCommandWithPassword(richTextBox_TextSendSMS.Text, (PhoneBookContact)item);
                    SendSMSToContact((PhoneBookContact)item, SMSText);
                }
            }
            //     AddCommandToCommands(richTextBox_TextSendSMS.Text);
            groupBox34.Enabled = true;
        }

        void RemoveSelectedContact()
        {
            try
            {
                int i = checkedListBox_PhoneBook.SelectedIndex;
                MyPhoneBook.RemoveContactFromPhoneBook((PhoneBookContact)checkedListBox_PhoneBook.SelectedItem);

                UpdateDefaultsContacts();

                UpdatePhoneBook();

                if (i < checkedListBox_PhoneBook.Items.Count)
                {
                    checkedListBox_PhoneBook.SelectedIndex = i;
                }
                else
                {
                    checkedListBox_PhoneBook.SelectedIndex = checkedListBox_PhoneBook.Items.Count - 1;
                }
            }
            catch (Exception ex)
            {
                //LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                LogSMS.LogMessage(Color.Red, Color.White, ex.Message, New_Line = true, Show_Time = true);

            }
        }

        private void Button_RemoveContact_Click(object sender, EventArgs e)
        {
            RemoveSelectedContact();
        }

        private void Button_ExportToXML_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                FileName = "MyContacts",
                Filter = "XML files (*.xml)|*.xml",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    MyPhoneBook.ExportToXML(myStream);
                    // Code to write the stream goes here.
                    myStream.Close();
                }
            }







        }

        private void Button_ImportToXML_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
                if (result == DialogResult.OK) // Test result.
                {
                    MyPhoneBook.ImportToXML(openFileDialog1.FileName);

                    UpdateDefaultsContacts();

                    UpdatePhoneBook();

                }
            }
            catch (Exception ex)
            {
                //LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                LogSMS.LogMessage(Color.Red, Color.White, ex.Message, New_Line = true, Show_Time = true);

            }

        }

        void AddCommandToCommands(string i_SMSText)
        {
            Boolean IsExist = false;
            foreach (string str in Monitor.Properties.Settings.Default.SMS_Commands)
            {
                if (i_SMSText == str)
                {
                    IsExist = true;
                }
            }

            if (IsExist == false)
            {
                if (Monitor.Properties.Settings.Default.SMS_Commands.Count >= 100)
                {
                    Monitor.Properties.Settings.Default.SMS_Commands.RemoveAt(Monitor.Properties.Settings.Default.SMS_Commands.Count - 40);
                }

                Monitor.Properties.Settings.Default.SMS_Commands.Add(i_SMSText);
                Monitor.Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// 
        /// </summary>
      //  bool ACKSMSReceived = false;
        void SendSMSToContact(PhoneBookContact i_Contact, string i_SMSText)
        {
            // AddCommandToCommands(i_SMSText);
            int PosStr = 0;
            if (i_Contact == null)
            {
                return;
            }

            //i_SMSText = i_SMSText.Replace("\n", string.Empty);
            //i_SMSText = i_SMSText.Replace("\r", string.Empty);
            while (PosStr < i_SMSText.Length)
            {

                string SMSToSend ;
                int CharsLeft = i_SMSText.Length - PosStr;
                //.SubString( 0, dec.Length > 240 ? 240 : dec.Length )

                if (CharsLeft > 160)
                {
                    SMSToSend = i_SMSText.Substring(PosStr, 160);

                }
                else
                {
                    SMSToSend = i_SMSText.Substring(PosStr, CharsLeft);
                }
                PosStr += 160;

                string StrToSend = "{SMS_SEND}," + i_Contact.Phone + "," + SMSToSend + "\r{SMS_END}";

                StrToSend = ReturnSMSEncryiepted(StrToSend);

                byte[] buffer = Encoding.ASCII.GetBytes(StrToSend);

                bool IsSent = SerialPortSMSSendData(buffer);

                if (IsSent == true)
                {

                    LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                    LogSMS.LogMessage(Color.Green, Color.White, "  SMS was Sent:\n Contact: " + i_Contact.ToString() + "\n Text:  " + SMSToSend, New_Line = true, Show_Time = false);

                    Thread.Sleep(1500);

                }
            }
        }

        //bool ACKSMSReceived = false;
        void RingToContact(PhoneBookContact i_Contact)
        {
            // AddCommandToCommands(i_SMSText);
            //  int PosStr = 0;
            if (i_Contact == null)
            {
                return;
            }



            string StrToSend = "{RING," + i_Contact.Phone + ",}";

            byte[] buffer = Encoding.ASCII.GetBytes(StrToSend);

            bool IsSent = SerialPortSMSSendData(buffer);

            if (IsSent == true)
            {
                //  mutexACKSMSReceived.WaitOne();
                //ACKSMSReceived = false;
                //   ACKSMSReceived = true;
                //Thread.Sleep(1000);
                //   mutexACKSMSReceived.ReleaseMutex();

                //int cnt = 0;
                //while (ACKSMSReceived == false && cnt < 100)
                //{
                //    Thread.Sleep(50);
                //    cnt++;
                //}
                //if (ACKSMSReceived)
                //{
                LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                LogSMS.LogMessage(Color.Green, Color.White, "  Ring to Contact:\n Contact: " + i_Contact.ToString(), New_Line = true, Show_Time = false);

                Thread.Sleep(1500);
                //}
                //else
                //{
                //    LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                //    LogSMS.LogMessage(Color.Red, Color.White, "  SMS wasn't Sent to " + i_Contact.ToString() + "  Text:  " + SMSToSend, New_Line = true, Show_Time = false);
                //}

                //return true;
            }

        }

        string ReturnSMSEncryiepted(string i_SMSText)
        {
            if (checkBox_SMSencrypted.Checked == true)
            {
                return "{ENCRYPED," + textBox_UnitIDForSMS.Text + "," + textBox_CodeArrayForSMS.Text + "," + i_SMSText;
            }
            else
            {
                return i_SMSText;
            }
        }

        private void Button_SendSelectedSMS_Click(object sender, EventArgs e)
        {

            if (checkedListBox_PhoneBook.SelectedItem != null)
            {
                groupBox34.Enabled = false;

                string SMSText = ReturnCommandWithPassword(richTextBox_TextSendSMS.Text, (PhoneBookContact)checkedListBox_PhoneBook.SelectedItem);

                if (CheckValidSMS(SMSText))
                {


                    SendSMSToContact((PhoneBookContact)checkedListBox_PhoneBook.SelectedItem, SMSText);
                }
                else
                {
                    LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                    LogSMS.LogMessage(Color.Red, Color.White, "SMS Not Valid", New_Line = true, Show_Time = false);
                }

                // AddCommandToCommands(richTextBox_TextSendSMS.Text);
                groupBox34.Enabled = true;
            }
        }

        private void Button33_Click_2(object sender, EventArgs e)
        {
            using (var form = new AddContact())
            {
                PhoneBookContact Contact = (PhoneBookContact)checkedListBox_PhoneBook.SelectedItem;
                form.Load += new EventHandler(Form_Load);

                if (Contact != null)
                {
                    form.ContactName = Contact.Name;
                    form.ContactName = Contact.Phone;
                    form.ContactNotes = Contact.Notes;
                    form.ContactPassword = Contact.Password;
                    form.ContactIMEI = Contact.UnitID;

                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        Contact.Name = form.ContactName;            //values preserved after close
                        Contact.Phone = form.ContactPhone;
                        Contact.Notes = form.ContactNotes;
                        Contact.Password = form.ContactPassword;
                        Contact.UnitID = form.ContactIMEI;
                        //Do something here with these values

                        //MyPhoneBook.AddContactToPhoneBook(NewContact);

                        UpdateDefaultsContacts();

                        UpdatePhoneBook();


                    }
                }
            }
        }

        void Form_Load(object sender, EventArgs e)
        {
            PhoneBookContact Contact = (PhoneBookContact)checkedListBox_PhoneBook.SelectedItem;
            if (Contact != null)
            {
                AddContact form = (AddContact)sender;
                form.TextBoxName = Contact.Name;
                form.TextBoxPhone = Contact.Phone;
                form.TextBoxNotes = Contact.Notes;
                form.TextBoxPassword = Contact.Password;
                form.TextBoxIMEI = Contact.UnitID;
            }
        }

        private void Button36_Click(object sender, EventArgs e)
        {
            richTextBox_ModemStatus.BackColor = default;
            richTextBox_ModemStatus.Text = "";
        }

        private void RichTextBox_TextSendSMS_TextChanged(object sender, EventArgs e)
        {
            label_SMSSendCharacters.Text = richTextBox_TextSendSMS.Text.Length.ToString() + "/160 = " + (richTextBox_TextSendSMS.Text.Length / 160 + 1);
            //if (richTextBox_TextSendSMS.Text.Length < 160)
            //{
            //    richTextBox_TextSendSMS.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    richTextBox_TextSendSMS.BackColor = Color.Red;
            //}
        }

        private void Button_SMSOpenPort_Click(object sender, EventArgs e)
        {

        }

        private void TextBox_Config31_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.AutoARM);
        }

        private void PictureBox_logo_Click(object sender, EventArgs e)
        {

        }

        private void Button_SetConfigSMS_Click(object sender, EventArgs e)
        {

        }

        private void Button_EndFOTAReset_Click(object sender, EventArgs e)
        {
            if (textBox_TotalFrames1280Bytes.Text.Length > 0 && textBox_TotalFileLength.Text.Length > 0)
            {
                //txtDataTx.Text = ";<1234>ENDFOTA=," + textBox_TotalFrames1280Bytes.Text + "," + textBox_TotalFileLength.Text + ",;";
                txtDataTx.Text = string.Format(";<{0}>ENDFOT=,{1},{2},;", "", textBox_TotalFrames1280Bytes.Text, textBox_TotalFileLength.Text);
            }
        }

        private void TextBox_Config32_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.GPSType);
        }

        private void CheckBox_S1RecordLog_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Button_AddToSendSMS_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox_SMSCommands.SelectedItem != null)
                {
                    richTextBox_TextSendSMS.Text = listBox_SMSCommands.SelectedItem.ToString();
                }

            }
            catch (Exception ex)
            {
                LogSMS.LogMessage(Color.Black, Color.White, ex.ToString(), New_Line = false, Show_Time = true);
            }
        }

        private void TextBox_Config33_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.DISARMCODE);
        }

        private void ComboBox_SMSCommands_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




        private void ListBox_SMSCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listBox_SMSCommands.SelectedItem != null)
                {

                    richTextBox_TextSendSMS.Text = listBox_SMSCommands.SelectedItem.ToString();
                }

            }
            catch (Exception ex)
            {
                LogSMS.LogMessage(Color.Black, Color.White, ex.ToString(), New_Line = false, Show_Time = true);
            }
        }

        private void Button41_Click(object sender, EventArgs e)
        {
            using (var form = new SMSCommand())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    AddCommandToCommands(form.Command);



                }
            }
        }

        private void Button37_Click(object sender, EventArgs e)
        {
            using (var form = new SMSCommand())
            {
                string Command = (string)listBox_SMSCommands.SelectedItem;
                form.Load += new EventHandler(SMSCommandForm_Load);

                if (Command != null)
                {
                    form.Command = Command;

                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        Command = form.Command;            //values preserved after close

                        Monitor.Properties.Settings.Default.SMS_Commands.Remove((string)listBox_SMSCommands.SelectedItem);
                        AddCommandToCommands(Command);

                        SortSMSCommands();


                    }
                }
            }
        }

        void SortSMSCommands()
        {
            ArrayList q = new ArrayList();
            foreach (object o in listBox_SMSCommands.Items)
            {
                q.Add(o);
            }
            q.Sort();
            listBox_SMSCommands.Items.Clear();
            foreach (object o in q)
            {

                listBox_SMSCommands.Items.Add(o);
            }
        }

        void SMSCommandForm_Load(object sender, EventArgs e)
        {
            string Command = (string)listBox_SMSCommands.SelectedItem;
            if (Command != null)
            {
                SMSCommand form = (SMSCommand)sender;
                form.TextBoxCommand = Command;

            }
        }

        void RemoveSelectedCommand()
        {
            try
            {
                int i = listBox_SMSCommands.SelectedIndex;
                //MyPhoneBook.RemoveContactFromPhoneBook((PhoneBookContact)checkedListBox_PhoneBook.SelectedItem);

                listBox_SMSCommands.Items.Remove(listBox_SMSCommands.SelectedItem);

                UpdateDefaultsCommands();

                UpdateSMSCommands();

                if (i < listBox_SMSCommands.Items.Count)
                {
                    listBox_SMSCommands.SelectedIndex = i;
                }
                else
                {
                    listBox_SMSCommands.SelectedIndex = listBox_SMSCommands.Items.Count - 1;
                }
            }
            catch (Exception ex)
            {
                //LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                LogSMS.LogMessage(Color.Red, Color.White, ex.Message, New_Line = true, Show_Time = true);

            }



        }

        private void Button40_Click(object sender, EventArgs e)
        {
            RemoveSelectedCommand();

        }

        private void Button39_Click_1(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                FileName = "MySMSCommands",
                Filter = "XML files (*.xml)|*.xml",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    List<string> templist = new List<string>();
                    foreach (var item in listBox_SMSCommands.Items)
                    {
                        templist.Add((string)item);
                    }
                    XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
                    TextWriter textWriter = new StreamWriter(myStream);

                    serializer.Serialize(textWriter, templist);
                    textWriter.Close();
                    // Code to write the stream goes here.
                    myStream.Close();
                }
            }
        }

        private void Button38_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1 = new OpenFileDialog();
                DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
                if (result == DialogResult.OK) // Test result.
                {

                    XmlSerializer deserializer = new XmlSerializer(typeof(List<string>));
                    TextReader textReader = new StreamReader(openFileDialog1.FileName);
                    List<string> ImportedCommands;
                    ImportedCommands = (List<string>)deserializer.Deserialize(textReader);
                    textReader.Close();

                    Monitor.Properties.Settings.Default.SMS_Commands.Clear();
                    listBox_SMSCommands.Items.Clear();
                    foreach (string str in ImportedCommands)
                    {
                        AddCommandToCommands(str);
                    }
                    UpdateSMSCommands();



                }
            }
            catch (Exception ex)
            {
                //LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                LogSMS.LogMessage(Color.Red, Color.White, ex.Message, New_Line = true, Show_Time = true);

            }
        }





        private void CheckedListBox_PhoneBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBox_PhoneBook.SelectedItem != null)
            {
                PhoneBookContact contact = (PhoneBookContact)checkedListBox_PhoneBook.SelectedItem;

                richTextBox_ContactDetails.Text = string.Format("Name: \n{0}\n\nPhone: \n{1}\n\nPassword: \n{3}\n\nUnit ID: \n{4}\n\nNotes: \n{2}\n ", contact.Name, contact.Phone, contact.Notes, contact.Password, contact.UnitID);

                textBox_UnitIDForSMS.Text = contact.UnitID;

            }

        }

        private void TextBox_Config34_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.GPSType);
        }

        private void Button34_Click_1(object sender, EventArgs e)
        {
            string StartFota = string.Format(";<{0}>STARTFOTA=,{1},{2},;", "", textBox_TotalFrames1280Bytes.Text, textBox_TotalFileLength.Text);
            txtDataTx.Text = StartFota;
            richTextBox_TextSendSMS.Text = StartFota;
        }

        private void Label_Config12_Click(object sender, EventArgs e)
        {

        }

        private void Label_Config32_Click(object sender, EventArgs e)
        {

        }

        private void Label_Config31_Click(object sender, EventArgs e)
        {

        }

        private void Label_Config11_Click(object sender, EventArgs e)
        {

        }

        private void Label_Config3_Click(object sender, EventArgs e)
        {

        }

        private void Label_Config28_Click(object sender, EventArgs e)
        {

        }

        private void Label_Config29_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

        private void CheckBox_OpenPortSMS_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_OpenPortSMS.Checked)
            {
                try
                {
                    checkBox_OpenPortSMS.BackColor = Color.Yellow;


                    serialPort_SMS.BaudRate = 38400;
                    serialPort_SMS.DataBits = 8;
                    serialPort_SMS.StopBits = StopBits.One;
                    serialPort_SMS.Parity = Parity.None;
                    serialPort_SMS.PortName = comboBox_ComportSMS.Text;






                    serialPort_SMS.Open();



                    LogSMS.LogMessage(Color.Green, Color.LightGray,
                     " Serial port Opened with  " + " ,PortName = " + serialPort_SMS.PortName
                     + " ,BaudRate = " + serialPort_SMS.BaudRate +
                     " ,DataBits = " + serialPort_SMS.DataBits +
                     " ,StopBits = " + serialPort_SMS.StopBits +
                     " ,Parity = " + serialPort_SMS.Parity,
                     New_Line = true, Show_Time = true);

                    checkBox_OpenPortSMS.BackColor = Color.Green;

                    serialPort_SMS.DataReceived += new SerialDataReceivedEventHandler(SerialPort_SMS_DataReceived);

                    comboBox_ComportSMS.Enabled = false;
                }
                catch (Exception ex)
                {
                    checkBox_OpenPortSMS.Checked = false;
                    checkBox_OpenPortSMS.BackColor = default;



                    LogSMS.LogMessage(Color.Red, Color.LightGray, ex.Message.ToString(), New_Line = true, Show_Time = true);
                    return;
                }




            }
            else
            {

                checkBox_OpenPortSMS.BackColor = default;
                //checkBox_ComportOpen.Enabled = false;


                serialPort_SMS.Close();

                comboBox_ComportSMS.Enabled = true;
                //groupBox_ServerSettings.Enabled = true;
            }
        }

        void SerialPort_SMS_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // If the com port has been closed, do nothing
            if (!serialPort_SMS.IsOpen) return;

            // This method will be called when there is data waiting in the port's buffer
            Thread.Sleep(300);

            if (!serialPort_SMS.IsOpen) return;

            // Obtain the number of bytes waiting in the port's buffer
            int bytes = serialPort_SMS.BytesToRead;

            // Create a byte array buffer to hold the incoming data
            byte[] buffer = new byte[bytes];

            // Read the data from the port and store it in our buffer
            serialPort_SMS.Read(buffer, 0, bytes);


            string IncomingString = System.Text.Encoding.Default.GetString(buffer);

            if (checkBox_DebugSMS.Checked == true)
            {

                LogSMS.LogMessage(Color.Black, Color.LightGray, "", New_Line = false, Show_Time = true);
                LogSMS.LogMessage(Color.Black, Color.LightGray, IncomingString, New_Line = true, Show_Time = false);
            }


            ParseSerialPortSMSString(IncomingString);
        }

        private void TextBox_Config35_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.EveryThing);
        }

        private void TextBox_Config36_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.EveryThing);
        }

        private void Button_SerialPortAdd_Click(object sender, EventArgs e)
        {
            //if (comboBox_SerialPortHistory.SelectedItem != null)
            //{
            //    textBox_SendSerialPort.Text = comboBox_SerialPortHistory.SelectedItem.ToString();
            //}
        }

        private void TextBox_Config37_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Boolean);
        }

        private void TextBox_Config38_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Boolean);

        }

        private void CheckBox_SendSMSAsIs_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox_SMSencrypted_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_SMSencrypted.Checked == true)
            {
                GrooupBox_Encryption.Enabled = true;
            }
            else
            {
                GrooupBox_Encryption.Enabled = false;
            }
        }

        private void TextBox_SpeedLimit1_TextChanged(object sender, EventArgs e)
        {

            SetSpeedThreeSpeedLimit();
        }

        void SetSpeedThreeSpeedLimit()
        {

            //Int32.TryParse(textBox_SpeedLimit1.Text, out int Speed1);
            //Int32.TryParse(textBox_SpeedLimit2.Text, out int Speed2);
            //Int32.TryParse(textBox_SpeedLimit3.Text, out int Speed3);


            //int temp;




        }

        private void TextBox_SpeedLimit2_TextChanged(object sender, EventArgs e)
        {
            SetSpeedThreeSpeedLimit();
        }

        private void TextBox_SpeedLimit3_TextChanged(object sender, EventArgs e)
        {
            SetSpeedThreeSpeedLimit();
        }

        private void Label_Config37_Click(object sender, EventArgs e)
        {

        }

        private void Label_Config27_Click(object sender, EventArgs e)
        {

        }

        private void Label_Config7_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox_Configuration_Enter(object sender, EventArgs e)
        {

        }

        private void Label_Config1_Click(object sender, EventArgs e)
        {

        }

        private void Label_Config2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox_Config39_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.GPSType);
        }

        private void Button34_Click_2(object sender, EventArgs e)
        {
            SaveCommandsAndContacts();
        }

        private void CheckBox_S1Pause_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox33_Enter(object sender, EventArgs e)
        {

        }

        private void RichTextBox_ContactDetails_TextChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox39_Enter(object sender, EventArgs e)
        {

        }

        private void TextBox_Config40_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.CutSpeed);
        }

        private void TextBox1_TextChanged_1(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Boolean);
        }

        string OpcodeToCompare = "";
        int SendOneTimeFlag = 0;
        private void Button_Ring_Click(object sender, EventArgs e)
        {
            if (checkedListBox_PhoneBook.SelectedItem != null
                //           && checkBox_SMSencrypted.Checked == true 
                && listBox_SMSCommands.SelectedItem != null
                && listBox_SMSCommands.SelectedItem != null
                && textBox_UnitIDForSMS.Text.Length >= 10
                //        && textBox_CodeArrayForSMS.Text.Length == 4
                && serialPort_SMS.IsOpen
                && ((checkBox_SMSencrypted.Checked == false) || (textBox_CodeArrayForSMS.Text.Length == 4))
                )
            {


                groupBox34.Enabled = false;

                button_Ring.BackColor = Color.Yellow;
                button_Ring.Text = "Ring Processing";

                SendOneTimeFlag = 1;
                TimerStatusRingWait = 300;
                RingToContact((PhoneBookContact)checkedListBox_PhoneBook.SelectedItem);

                Thread.Sleep(1000);



                if (checkBox_SMSencrypted.Checked == true)
                {


                    string[] temp = richTextBox_TextSendSMS.Text.Split('>', '=');

                    OpcodeToCompare = temp[1];

                    string SMSText = ReturnCommandWithPassword(richTextBox_TextSendSMS.Text, (PhoneBookContact)checkedListBox_PhoneBook.SelectedItem);

                    //SMSText = ReturnSMSEncryiepted(SMSText);

                    if (CheckValidSMS(SMSText))
                    {
                        PhoneBookContact Temp = new PhoneBookContact
                        {
                            Phone = "+00000000000"
                        };

                        SendSMSToContact(Temp, SMSText);
                    }
                    else
                    {
                        LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                        LogSMS.LogMessage(Color.Red, Color.White, "SMS Not Valid", New_Line = true, Show_Time = false);
                    }

                    // AddCommandToCommands(richTextBox_TextSendSMS.Text);

                }
                else
                {
                    string SMSText = ReturnCommandWithPassword(richTextBox_TextSendSMS.Text, (PhoneBookContact)checkedListBox_PhoneBook.SelectedItem);
                    txtDataTx.Text = SMSText;
                }

                groupBox34.Enabled = true;

            }
            else
            {
                LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                string RingExplain = @"In Order to Ring you have to:
1. Select the contact 
2. Select the command
3. Check that the password is the right password
4. Check the Encripted checkbox
5. Check the unit ID (IMEI),it should be the same IMEI target ID (when the status received it compare the IMEI recieved vs the UnitID TextBox)
6. Check the Unit code it the right code
7. Comport must be open ";
                LogSMS.LogMessage(Color.Red, Color.White, RingExplain, New_Line = true, Show_Time = false);

                button_Ring.BackColor = default;
                button_Ring.Text = "Ring";
                SendOneTimeFlag = 0;
                TimerStatusRingWait = 0;

            }
        }

        void ScanComports()
        {
            cmbPortName.Items.Clear();
            comboBox_ComportSMS.Items.Clear();

            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                cmbPortName.Items.Add(port);
                comboBox_ComportSMS.Items.Add(port);
            }
            if (ports.Length > 0)
            {
                cmbPortName.SelectedIndex = 0;
                comboBox_ComportSMS.SelectedIndex = 0;
            }
        }

        private void Button_ReScanComPort_Click(object sender, EventArgs e)
        {
            ScanComports();
        }

        private void TextBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        readonly Stopwatch stopwatch = new Stopwatch();

        private void TextBox_StopWatch_TextChanged(object sender, EventArgs e)
        {

        }

        int TimerLogNumber = 0;
        private void Button_StopwatchReset_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();
            TimerLogNumber = 0;
            textBox_StopWatch.Text = PrintTimeSpan(stopwatch.Elapsed);
            button_Stopwatch_Start_Stop.BackColor = default;
        }

        private void Button_Stopwatch_Start_Stop_Click(object sender, EventArgs e)
        {
            if (stopwatch.IsRunning == false)
            {
                button_Stopwatch_Start_Stop.BackColor = Color.LightGreen;
                stopwatch.Start();
            }
            else
            {
                button_Stopwatch_Start_Stop.BackColor = default;
                stopwatch.Stop();
            }

        }

        private void Button_TimerLog_Click(object sender, EventArgs e)
        {
            TimerLogNumber++;
            SerialPortLogger.LogMessage(Color.DarkBlue, Color.White, "Stopwatch Log: " + TimerLogNumber + ">  " + PrintTimeSpan(stopwatch.Elapsed), true, true);
        }

        private void CheckBox_ParseMessages_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TextBox_Config42_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Number);
        }

        Boolean IsTimerRunning = false;
        int TimerMemory = 0;
        private void Button_StartStopTimer_Click(object sender, EventArgs e)
        {
            IsTimerRunning = !IsTimerRunning;
            if (IsTimerRunning == true && (textBox_SetTimerTime.Text != "0" || textBox_TimerTime.Text != "0"))
            {


                int.TryParse(textBox_SetTimerTime.Text, out int Result);
                if (Result != 0)
                {
                    button_StartStopTimer.BackColor = Color.LightGreen;
                    TimerMemory = Result;
                    button_ResetTimer.Text = "Reset (" + TimerMemory + ")";
                    textBox_TimerTime.Text = textBox_SetTimerTime.Text;
                    textBox_SetTimerTime.Text = "0";
                }
                else
                {

                }
            }
            else
            {
                button_StartStopTimer.BackColor = default;

            }
        }

        private void CmbPortName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button42_Click(object sender, EventArgs e)
        {
            tabControl_Main.TabPages[5].BackColor = Color.Red;
        }

        private void Button43_Click(object sender, EventArgs e)
        {
            Process.Start(@".");
        }

        private void TextBox_SendSerialPort_TextChanged(object sender, EventArgs e)
        {
            //textBox_SendSerialPort.SelectionStart = textBox_SendSerialPort.Text.Length;
            //textBox_SendSerialPort.SelectionLength = 0;
        }

        private void TextBox_SourceConfig_TextChanged(object sender, EventArgs e)
        {

        }

        private void CmbBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox_SendTimer_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TextBox_SendSerialDiff_TextChanged(object sender, EventArgs e)
        {

        }

       // private Random rnd = new Random();

        private void Button_ScreenShot_Click(object sender, EventArgs e)
        {
            TakeCroppedScreenShot();


        }


        private void ListBox_SMSCommands_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
            for (int i = 0; i < listBox_SMSCommands.Items.Count; i++)
            {
                if (listBox_SMSCommands.GetSelected(i) == true)
                {
                    LogSMS.LogMessage(Color.Black, Color.White, "[" + listBox_SMSCommands.Items[i].ToString() + "]", New_Line = true, Show_Time = false);
                }
            }
            LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = true, Show_Time = false);
        }

        private void Button_ResetGraphs_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            ChartCntX = 0;
            foreach (var ser in chart1.Series)
            {
                ser.Points.Clear();
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //public System.Data.DataTable ExportToExcel(Series ser)
        //{
        //    System.Data.DataTable table = new System.Data.DataTable();
        //    table.Columns.Add("Chart name", typeof(string));
        //    table.Columns.Add("X", typeof(double));
        //    table.Columns.Add("Y", typeof(double));

        //    //foreach (var ser in chart1.Series)
        //    //{
        //    DataPoint[] TotalPoints = new DataPoint[ser.Points.Count];
        //    ser.Points.CopyTo(TotalPoints,0);
        //        foreach(var Point in TotalPoints)
        //        {
        //            table.Rows.Add(ser.Name , Point.XValue,Point.YValues[0]);
        //        }
        //    //}

        //    //table.Columns.Add("Chart", typeof(int));
        //    //table.Columns.Add("X", typeof(string));
        //    //table.Columns.Add("Y", typeof(string));

        //    //table.Columns.Add("Subject1", typeof(int));
        //    //table.Columns.Add("Subject2", typeof(int));
        //    //table.Columns.Add("Subject3", typeof(int));
        //    //table.Columns.Add("Subject4", typeof(int));
        //    //table.Columns.Add("Subject5", typeof(int));
        //    //table.Columns.Add("Subject6", typeof(int));
        //    //table.Rows.Add(1, "Amar", "M", 78, 59, 72, 95, 83, 77);
        //    //table.Rows.Add(2, "Mohit", "M", 76, 65, 85, 87, 72, 90);
        //    //table.Rows.Add(3, "Garima", "F", 77, 73, 83, 64, 86, 63);
        //    //table.Rows.Add(4, "jyoti", "F", 55, 77, 85, 69, 70, 86);
        //    //table.Rows.Add(5, "Avinash", "M", 87, 73, 69, 75, 67, 81);
        //    //table.Rows.Add(6, "Devesh", "M", 92, 87, 78, 73, 75, 72);
        //    return table;
        //}


        private void Button_Export_excel_Click(object sender, EventArgs e)
        {
            // writetext.WriteLine("writing in text file");


            this.Invoke((MethodInvoker)delegate ()
            {
                textBox_graph_XY.Text = "";
            });

            Series[] Serias_Graphs = new Series[chart1.Series.Count];
            chart1.Series.CopyTo(Serias_Graphs, 0);
            foreach (var ser in Serias_Graphs)
            {
                String fileName = ser.Name;
                String Location = AppDomain.CurrentDomain.BaseDirectory + fileName + DateTime.Now.ToString("MM_DD_HH_mm_ss") + ".csv";
                using (StreamWriter writetext = new StreamWriter(@Location))
                {

                    foreach (DataPoint point_ in ser.Points)
                    {
                        writetext.WriteLine(point_.XValue + "," + point_.YValues[0]);
                    }

                    this.Invoke((MethodInvoker)delegate ()
                    {
                        textBox_graph_XY.Text += "Excel Generated at " + Location;
                    });
                }
            }


        }

        private void Button3_Click_3(object sender, EventArgs e)
        {
           // Color randomColor ;
            //Tab0Color = randomColor;
        }

        bool IsPauseGraphs = false;
        private void Button_GraphPause_Click(object sender, EventArgs e)
        {

            if(IsPauseGraphs == false)
            {
                IsPauseGraphs = true;
                button_GraphPause.BackColor = Color.Yellow;
            }
            else
            {

                IsPauseGraphs = false;
                button_GraphPause.BackColor = default;
            }
        }

        private void Button1_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Help.ShowHelp(this, "helpfile.chm", HelpNavigator.TopicId, "1234");
        }

        private void Button_OpenFolder2_Click(object sender, EventArgs e)
        {
            Process.Start(@".");
        }

        void CloseClentConnection()
        {
            if (ClientSocket != null)
            {
                //ClientSocket.GetStream().Close();
                ClientSocket.Close();
            }

            if (ReceiveThread != null)
            {
                ReceiveThread.Abort();
                //   m_Exit = true;

            }

            button_Ping.BackColor = default;
            button_ClientConnect.BackColor = default;

            richTextBox_ClientRx.AppendText("Connection closed \n");
        }
        private void Button42_Click_1(object sender, EventArgs e)
        {
            CloseClentConnection();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ba"></param>
        /// <returns></returns>
        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2} ", b);
            return hex.ToString();
        }

        void ReceiveData()
        {
            TcpClient PClientSocket = ClientSocket;
            try
            {
                while (true)
                {
                    if (m_Exit == true)
                    {
                        return;
                    }

                    if (PClientSocket != null)
                    {
                        try
                        {
                            byte[] buffer = new byte[4096];
                            Stream stm = PClientSocket.GetStream();



                            stm.Read(buffer, 0, buffer.Length);
                            KratosProtocolFrame Result = new KratosProtocolFrame();
                            Result = Kratos_Protocol.DecodeKratusProtocol(buffer);

                            textBox_RxClientPreamble.BeginInvoke(new EventHandler(delegate
                            {
                                if (Result != null)
                                {
                                    textBox_RxClientPreamble.BackColor = Color.LightGreen;
                                    textBox_RxClientPreamble.Text = Result.Preamble;

                                    textBox_RxClientOpcode.BackColor = Color.LightGreen;
                                    textBox_RxClientOpcode.Text = Result.Opcode;

                                    textBox_RxClientData.BackColor = Color.LightGreen;
                                    textBox_RxClientData.Text = Result.Data;

                                    textBox_RxClientDataLength.BackColor = Color.LightGreen;
                                    textBox_RxClientDataLength.Text = Result.DataLength + " Bytes";
                                }


                            }));



                            string MiniAdaResult = MiniAda_Parser.ParseKratosFrame(Result);

                           // MiniAdaLogger.LogMessage(Color.Black, Color.Empty, MiniAdaResult, New_Line = true, Show_Time = true);

                            MiniAdaLogger.LogMessage(Color.Blue, Color.Azure, "", New_Line = false, Show_Time = true);
                            MiniAdaLogger.LogMessage(Color.Blue, Color.Azure, "Rx:>", false, false);
                            MiniAdaLogger.LogMessage(Color.Blue, Color.Azure, MiniAdaResult, true, false);







                            //SSP_Protocol.SSP_DataPayload data = SSP_Protocol.SSP_Protocol.SSPPacket_Decoder(buffer);
                            richTextBox_ClientRx.Invoke(new EventHandler(delegate
                            {
                                byte[] Onlythe40FirstBytes = buffer.Skip(0).Take(200).ToArray();
                                richTextBox_ClientRxPrintText("[" + DateTime.Now.TimeOfDay.ToString().Substring(0, 11) + "] " + ByteArrayToString(Onlythe40FirstBytes) + "\n \n");
                                //richTextBox_ClientRx.AppendText("[" + dt.TimeOfDay.ToString().Substring(0, 11) + "] " + Encoding.ASCII.GetString(buffer) + " \n");



                            }));
                            PClientSocket = ClientSocket;

                        }
                        catch (Exception ex)
                        {


                                //textBox_SystemStatus.Invoke(new EventHandler(delegate
                                //        {
                                //            richTextBox_ClientRx.Text = ex.Message;
                                //            textBox_SystemStatus.Text = ex.Message;

                                //        //       ClearRxTextBox();

                                //    }));
                            

                                    

                        }
                        finally
                        { }
                    }
                    else
                    {
                        PClientSocket.Close();
                    }

                }
            }
            catch (System.Net.Sockets.SocketException se)
            {
                se.ToString(); //Gil: just remove warning.
                //MessageBox.Show(se.Message);
            }
        }

        bool m_Exit = false;
        TcpClient ClientSocket;
        Thread ReceiveThread;
        private void Button_ClientConnect_Click(object sender, EventArgs e)
        {
            try
            {
                //create a new client socket ...
                m_Exit = false;
                //m_socWorker = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                String szIPSelected = textBox_ClientIP.Text;
                String szPort = textBox_ClientPort.Text;
                int alPort = System.Convert.ToInt16(szPort, 10);

                ClientSocket = new TcpClient();
                var result = ClientSocket.BeginConnect(textBox_ClientIP.Text, alPort, null, null);

                var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));
                if (!success)
                {
                    richTextBox_ClientRxPrintText(String.Format("Failed to connect to [{0}] [{1}]\n", szIPSelected, szPort));
                    return;
                }
                // we have connected
                ClientSocket.EndConnect(result);
                

                //System.Net.IPAddress	remoteIPAddress	 = System.Net.IPAddress.Parse(szIPSelected);
                //System.Net.IPEndPoint	remoteEndPoint = new System.Net.IPEndPoint(remoteIPAddress, alPort);
                //m_socWorker.Connect(remoteEndPoint);

                if (ClientSocket.Connected)
                {
                    this.ReceiveThread = new Thread(new ThreadStart(ReceiveData));
                    this.ReceiveThread.Start();
                }
            }
            catch (System.Net.Sockets.SocketException se)
            {
                richTextBox_ClientRx.AppendText(se.Message + "\n");
            }
        }

        int ClentSendData = 0;
        private void Button3_Click_4(object sender, EventArgs e)
        {
            try
            {
                String str = richTextBox_ClientTx.Text;
                Stream stm = ClientSocket.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(str);

                //byte[] sspData = SSP_Protocol.SSP_Protocol.SSPPacket_Encoder(SSP_Protocol.eMessegeType.TRACE, ba);

                // Console.WriteLine("Sending...");

                stm.Write(ba, 0, ba.Length);

                ClentSendData++;
                richTextBox_ClientTx.Text = "Send Data to Server " + ClentSendData;

                // byte[] bb = new byte[100];

            }
            catch
            {
                //MessageBox.Show (se.Message );
            }
        }

        private void Button43_Click_1(object sender, EventArgs e)
        {
            richTextBox_ClientTx.Text = "";
        }

        private void Button28_Click_2(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Minimum = ChartCntX;
        }

        private void TextBox_graph_XY_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox_SendSerialPort_KeyDown_1(object sender, KeyEventArgs e)
        {

        }

        void SerialTerminalPrintHelp()
        {
            SerialPortLogger.LogMessage(Color.Black, Color.Chartreuse, "F1 function - Help", New_Line = true, Show_Time = true);
        }

        private void TextBox_SendSerialPort_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F1:
                        SerialTerminalPrintHelp();
                        
                        break;

                    case Keys.F2:
                        SerialPortLogger.LogMessage(Color.Black, Color.Chartreuse, "F2 function reads all commands to history", New_Line = true, Show_Time = true);
                        break;

                    //case Keys.ControlKey:
                    //    SelfMonitorCommandsMode = !SelfMonitorCommandsMode;
                    //    if (SelfMonitorCommandsMode == true)
                    //    {
                    //        textBox_SendSerialPort.BackColor = SystemColors.Info;
                    //        groupBox_SendSerialOrMonitorCommands.BackColor = SystemColors.Info;
                    //        SerialPortLogger.LogMessage(Color.Black, Color.Chartreuse, "Change to Monitor commands mode", New_Line = true, Show_Time = true);
                    //    }
                    //    else
                    //    {
                    //        groupBox_SendSerialOrMonitorCommands.BackColor = default(Color);
                    //        textBox_SendSerialPort.BackColor = SystemColors.ActiveCaption;
                    //        SerialPortLogger.LogMessage(Color.Black, Color.Chartreuse, "Change to Send to serial port mode", New_Line = true, Show_Time = true);


                    //    }
                    //    break;


                    case Keys.Enter:
                        //if (SelfMonitorCommandsMode == true)
                        //{

                        //}
                        //else
                        //{
                            button_SendSerialPort.PerformClick();
                        //}

                        break;

                    case Keys.Up:
                        //SerialPortLogger.LogMessage(Color.Purple, Color.LightGray, " History Index: " + HistoryIndex.ToString(), New_Line = true, Show_Time = false);
                        if (HistoryIndex > CommandsHistoy.Count - 1 || HistoryIndex < 0)
                        {
                            HistoryIndex = CommandsHistoy.Count;
                        }

                        //if(textBox_SendSerialPort.Text == string.Empty)
                        //{
                        //    HistoryIndex = CommandsHistoy.Count;
                        //}


                        if (HistoryIndex > 0)
                        {
                            HistoryIndex--;
                        }
                        textBox_SendSerialPort.Text = CommandsHistoy[HistoryIndex];
                        break;

                    case Keys.Down:

                        textBox_SendSerialPort.Text = CommandsHistoy[HistoryIndex];
                        if (HistoryIndex < CommandsHistoy.Count - 1)
                        {
                            HistoryIndex++;
                        }
                        break;

                    case Keys.Tab:
                        List<String> Strlist = new List<String>();
                        foreach (String str in CommandsHistoy)
                        {
                            if (str.StartsWith(textBox_SendSerialPort.Text))
                            {
                                Strlist.Add(str);
                            }
                        }

                        if (Strlist.Count > 1)
                        {
                            SerialPortLogger.LogMessage(Color.Black, Color.Yellow, "Total sub commands: " + Strlist.Count.ToString() + " ", New_Line = true, Show_Time = true);
                            foreach (String str in Strlist)
                            {
                                SerialPortLogger.LogMessage(Color.Black, Color.Chartreuse, str, New_Line = true, Show_Time = false);
                                if (HistoryIndex == Strlist.IndexOf(str))
                                {
                                    SerialPortLogger.LogMessage(Color.Black, Color.Chartreuse, "<------", New_Line = false, Show_Time = false);
                                }
                            }
                        }
                        else
                            if (Strlist.Count == 1)
                        {
                            textBox_SendSerialPort.Text = Strlist[0];
                        }
                        break;

                    default:
                        HistoryIndex = CommandsHistoy.Count - 1;
                        break;
                }

                //  CommandsHistoy.SelectedIndex = HistoryIndex;
            }
            catch (Exception ex)
            {
                SerialPortLogger.LogMessage(Color.Blue, Color.White, ex.ToString(), New_Line = true, Show_Time = false);
            }
        }

         
        private void Button_OpenPort_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen == false)
            {
                try
                {
                    button_OpenPort.BackColor = Color.Yellow;
                    label_SerialPortConnected.BackColor = Color.Yellow;

                    ComPortClosing = false;

                    CloseSerialPortTimer = false;



                    // Set the port's settings

                    serialPort.BaudRate = int.Parse(cmbBaudRate.Text);

                    if (cmbBaudRate.Items.Contains(cmbBaudRate.Text) == false)
                    {
                        cmbBaudRate.Items.Add(cmbBaudRate.Text);
                    }

                    serialPort.DataBits = int.Parse(cmbDataBits.Text);
                    serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbStopBits.Text);
                    serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), cmbParity.Text);
                    serialPort.PortName = cmbPortName.Text;




                    serialPort.WriteTimeout = 500;
                    serialPort.Open();

                    //ListenBox.Checked = false;
                    //groupBox_ServerSettings.Enabled = false;
                    IsTimedOutTimerEnabled = false;

                    SerialPortLogger.LogMessage(Color.Green, Color.LightGray,
                     " Serial port Opened with  " + " ,PortName = " + serialPort.PortName
                     + " ,BaudRate = " + serialPort.BaudRate +
                     " ,DataBits = " + serialPort.DataBits +
                     " ,StopBits = " + serialPort.StopBits +
                     " ,Parity = " + serialPort.Parity,
                     New_Line = true, Show_Time = true);

                    button_OpenPort.Text = "Close";
                    button_OpenPort.BackColor = Color.LightGreen;
                    label_SerialPortConnected.BackColor = Color.LightGreen;
                    label_SerialPortStatus.Text = cmbPortName.Text+ "   \n" + cmbBaudRate.Text; 


                    cmbBaudRate.Enabled = false;
                    cmbDataBits.Enabled = false;
                    cmbParity.Enabled = false;
                    cmbPortName.Enabled = false;
                    cmbStopBits.Enabled = false;

                    Monitor.Properties.Settings.Default.Comport_BaudRate = cmbBaudRate.Text;
                    Monitor.Properties.Settings.Default.Comport_DataBits = cmbDataBits.Text;
                    Monitor.Properties.Settings.Default.Comport_StopBit = cmbStopBits.Text;
                    Monitor.Properties.Settings.Default.Comport_Parity = cmbParity.Text;
                    Monitor.Properties.Settings.Default.Comport_Port = cmbPortName.Text;

                    Monitor.Properties.Settings.Default.Save();


                }
                catch (Exception ex)
                {
                    //checkBox_ComportOpen.Checked = false;

                    //SerialException = true;

                    SerialPortLogger.LogMessage(Color.Red, Color.LightGray, ex.Message.ToString(), New_Line = true, Show_Time = true);
                    return;
                }




            }
            else
            {

                ComPortClosing = true;
                button_OpenPort.BackColor = default;
                label_SerialPortConnected.BackColor = default;
                label_SerialPortStatus.Text = "";
                gbPortSettings.Enabled = false;
                //checkBox_ComportOpen.Enabled = false;
                button_OpenPort.Text = "Open";

                CloseSerialPortTimer = true;
                CloseSerialPortConter = 0;




                //groupBox_ServerSettings.Enabled = true;
            }
        }

        private void TabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F1:
                        SerialTerminalPrintHelp();

                        break;

                    case Keys.F2:
                        SerialPortLogger.LogMessage(Color.Black, Color.Chartreuse, "F2 function reads all commands to history", New_Line = true, Show_Time = true);
                        break;

                    case Keys.Enter:
                        if (tabControl_Main.SelectedIndex == 3 && button_ClientConnect.BackColor == Color.LightGreen)
                        {
                            button_Send_Click(this, new EventArgs());
                        }
                        break;
                }


            }
            catch(Exception ex)
            {
                SerialPortLogger.LogMessage(Color.Black, Color.Red, ex.Message , New_Line = true, Show_Time = true);
            }

        }



        int ChartUpdateTime = 100;
        private void ComboBox_ChartUpdateTime_SelectedIndexChanged(object sender, EventArgs e)
        {

            int.TryParse(comboBox_ChartUpdateTime.Text, out int UpdateTime);
            ChartUpdateTime = UpdateTime;


        }

        private void CheckBox_SendHexdata_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SerialPortLogger_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged_3(object sender, EventArgs e)
        {
                Color TextColor = Color.FromName(textBox1.Text);
                if(TextColor.ToArgb() == 0)
                {
                    textBox1.BackColor = default;
                }
                else
                {
                    textBox1.BackColor = TextColor;
                }

                

                
        }

        private void TextBox_SendSerialPort_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                system1_Parser.Parse(this,textBox1.Text);
            }
        }

        private void Button_ClearRx_Click(object sender, EventArgs e)
        {
            richTextBox_ClientRx.Text = "";
        }

        private void GroupBox5_Enter(object sender, EventArgs e)
        {

        }

        void ClearRxTextBox()
        {
            textBox_RxClientPreamble.BackColor = default;
            textBox_RxClientPreamble.Text = "";

            textBox_RxClientOpcode.BackColor = default;
            textBox_RxClientOpcode.Text = "";

            textBox_RxClientData.BackColor = default;
            textBox_RxClientData.Text = "";

        }

        void ClearallTextBoxsTCPClient()
        {
            textBox_RxClientPreamble.BackColor = default;
            textBox_RxClientPreamble.Text = "";

            textBox_RxClientOpcode.BackColor = default;
            textBox_RxClientOpcode.Text = "";

            textBox_RxClientData.BackColor = default;
            textBox_RxClientData.Text = "";

            textBox_Preamble.BackColor = default;
            textBox_Preamble.Text = "";

            textBox_Opcode.BackColor = default;
            textBox_Opcode.Text = "";

            textBox_data.BackColor = default;
            textBox_data.Text = "";

        }

        private void button_Send_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClientSocket == null)
                {
                    return;
                }
                    ClearRxTextBox();
                textBox_Preamble_TextChanged(null, null);
                textBox_Opcode_TextChanged(null, null);
                textBox_data_TextChanged(null, null);

                if (!(textBox_Preamble.BackColor == Color.LightGreen && textBox_Opcode.BackColor == Color.LightGreen && textBox_data.BackColor == Color.LightGreen))
                {
                    button_SendProtocol.BackColor = Color.Red;
                    return;
                }
                else
                {
                    button_SendProtocol.BackColor = Color.LightGreen;
                }

                List<byte> ListBytes = new List<byte>();
                // Kratos_Protocol KratusP = new Kratos_Protocol();
                
                    Stream stm = ClientSocket.GetStream();

                byte[] Result = Kratos_Protocol.EncodeKratusProtocol(Regex.Replace(textBox_Preamble.Text, @"\s+", ""), Regex.Replace(textBox_Opcode.Text, @"\s+", ""), Regex.Replace(textBox_data.Text, @"\s+", ""));

                    stm.Write(Result, 0, Result.Length);
                


            }
            catch
            {
                //MessageBox.Show (se.Message );
            }
        }

        private void textBox_Preamble_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(textBox_Preamble.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && textBox_Preamble.Text.Length <= 5)
            {
                textBox_Preamble.BackColor = Color.LightGreen;
            }
            else
            {
                textBox_Preamble.BackColor = Color.Red;
            }
        }

        private void textBox_Opcode_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(textBox_Opcode.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && textBox_Opcode.Text.Length <= 5)
            {
                textBox_Opcode.BackColor = Color.LightGreen;
            }
            else
            {
                textBox_Opcode.BackColor = Color.Red;
            }
        }

        private void textBox_data_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(textBox_data.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null )
            {
                textBox_data.BackColor = Color.LightGreen;
            }
            else
            {
                textBox_data.BackColor = Color.Red;
            }
        }

        private void txtS1_Clear_Click(object sender, EventArgs e)
        {

        }

        private void textBox_RxClientData_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox_SerialPort_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage_GenericFrame_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage_GenericFrame_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_Send_Click(this, new EventArgs());
            }
        }

        private void groupBox_clientTX_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_Send_Click(this, new EventArgs());
            }
        }

        private void textBox_Preamble_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_Send_Click(this, new EventArgs());
            }
        }

        private void textBox_Opcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_Send_Click(this, new EventArgs());
            }
        }

        private void textBox_data_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_Send_Click(this, new EventArgs());
            }
        }

        void SendDataToSystem()
        {
            button_Send_Click(null, null);

            if (button_SendProtocol.BackColor == Color.LightGreen)
            {
                MiniAdaLogger.LogMessage(Color.Purple, Color.LightYellow, "", New_Line = false, Show_Time = true);
                MiniAdaLogger.LogMessage(Color.Purple, Color.LightYellow, "Tx:>", false, false);
                String str = String.Format("Preamble [{0}],Opcode [{1}],Data [{2}] ", textBox_Preamble.Text, textBox_Opcode.Text, textBox_data.Text);
                MiniAdaLogger.LogMessage(Color.Purple, Color.LightYellow, str, true, false);
            }

            
        }

        private void button_GetSoftwareVersion_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "01 00";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void button45_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "02 00";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "04 00";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void button47_Click(object sender, EventArgs e)
        {
            if (textBox_LogLevel.BackColor == Color.LightGreen)
            {
                textBox_Preamble.Text = MINIADA_HEADER;
                textBox_Opcode.Text = "06 00";
                textBox_data.Text = "0" + textBox_LogLevel.Text;

                SendDataToSystem();
            }
            else
            {
                MiniAdaLogger.LogMessage(Color.Orange, Color.White, "Log level didn't set in the textbox near the button", New_Line = true, Show_Time = true);
            }
        }

        private void textBox_LogLevel_TextChanged(object sender, EventArgs e)
        {

            int LogLevel = 0;
            Int32.TryParse(textBox_LogLevel.Text, out LogLevel);


            if (LogLevel >=0 && LogLevel <=7 && LogLevel >= 0)
            {
                textBox_LogLevel.BackColor = Color.LightGreen;
            }
            else
            {
                textBox_LogLevel.BackColor = Color.Red;
            }
        }

        private void button48_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "07 00";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void button49_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "08 00";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void button50_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "10 00";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void button51_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "11 00";

            byte[] ba = Encoding.Default.GetBytes(textBox_SystemIdentify.Text);
            string hexString = BitConverter.ToString(ba).Replace("-", string.Empty);

            textBox_data.Text = hexString;

            SendDataToSystem();
        }

        private void button52_Click(object sender, EventArgs e)
        {
            ClearallTextBoxsTCPClient();

        }

        private void button53_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "12 00";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void MainForm_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            m_Exit = true;
            System.GC.Collect();
        }

        private void button54_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "13 00";

            byte[] ba = Encoding.Default.GetBytes(textBox_SetCoreCardInformation.Text);
            string hexString = BitConverter.ToString(ba).Replace("-", string.Empty);

            textBox_data.Text = hexString;

            SendDataToSystem();
        }

        private void button56_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "14 00";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void button55_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "15 00";

            byte[] ba = Encoding.Default.GetBytes(textBox_SetRFCardInformation.Text);
            string hexString = BitConverter.ToString(ba).Replace("-", string.Empty);

            textBox_data.Text = hexString;

            SendDataToSystem();
        }

        private void button58_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "16 00";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void button57_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "17 00";

            byte[] ba = Encoding.Default.GetBytes(textBox_SetPSUCard.Text);
            string hexString = BitConverter.ToString(ba).Replace("-", string.Empty);

            textBox_data.Text = hexString;

            SendDataToSystem();
        }

        private void button59_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "1E 00";
            textBox_data.Text = textBox_SetSynthesizerL1.Text;

            SendDataToSystem();
        }

        private void textBox_SetSynthesizerL1_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(textBox_SetSynthesizerL1.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && buffer.Length <=4)
            {
                textBox_SetSynthesizerL1.BackColor = Color.LightGreen;
            }
            else
            {
                textBox_SetSynthesizerL1.BackColor = Color.Red;
            }
        }

        private void button60_Click(object sender, EventArgs e)
        {
            textBox_SetSynthesizerL2_TextChanged(null, null);
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "1F 00";
            textBox_data.Text = textBox_SetSynthesizerL2.Text;

            SendDataToSystem();
        }

        private void textBox_SetSynthesizerL2_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(textBox_SetSynthesizerL2.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && buffer.Length <= 4)
            {
                textBox_SetSynthesizerL2.BackColor = Color.LightGreen;
            }
            else
            {
                textBox_SetSynthesizerL2.BackColor = Color.Red;
            }
        }

        private void textBox_SetTxAD936X_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(textBox_SetTxAD936X.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && buffer.Length <= 4)
            {
                textBox_SetTxAD936X.BackColor = Color.LightGreen;
            }
            else
            {
                textBox_SetTxAD936X.BackColor = Color.Red;
            }
        }

        private void button61_Click(object sender, EventArgs e)
        {
            textBox_SetTxAD936X_TextChanged(null, null);
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "20 00";
            textBox_data.Text = textBox_SetTxAD936X.Text;

            SendDataToSystem();
        }

        private void button62_Click(object sender, EventArgs e)
        {
            textBox_GetTxAD936X_TextChanged(null, null);
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "21 00";
            textBox_data.Text = textBox_GetTxAD936X.Text;

            SendDataToSystem();
        }



        private void textBox_GetTxAD936X_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(textBox_GetTxAD936X.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && buffer.Length <= 3)
            {
                textBox_GetTxAD936X.BackColor = Color.LightGreen;
            }
            else
            {
                textBox_GetTxAD936X.BackColor = Color.Red;
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox_RxClientPreamble_TextChanged(object sender, EventArgs e)
        {

        }

        private void button59_MouseClick(object sender, MouseEventArgs e)
        {


        }

        private void button59_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void button61_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"Help:
Set Tx AD936X data :
4 bytes 
byte – band type: 0x00 - L1, 0x01 - L2 
2 bytes – address 
1 bytes - data");
                MiniAdaLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                MiniAdaLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }

        private void button63_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "26 00";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void textBox_SetSyestemState_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(textBox_SetSyestemState.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && buffer.Length == 1)
            {
                textBox_SetSyestemState.BackColor = Color.LightGreen;
            }
            else
            {
                textBox_SetSyestemState.BackColor = Color.Red;
            }
        }

        private void button64_Click(object sender, EventArgs e)
        {
            textBox_SetSyestemState_TextChanged(null, null);
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "28 00";
            textBox_data.Text = textBox_GetTxAD936X.Text;

            SendDataToSystem();
        }

        private void button65_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "29 00";
            textBox_data.Text = textBox_GetTxAD936X.Text;

            SendDataToSystem();
        }

        private void button64_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"Description:   Set the system state: 
 Command: 0x28
 TX data: 1 byte – System state: 0x1 – CAL; 0x2 - Normal
 TX frame: 	0x004D 0x0028 0x00000001 + TX Data + checksum
 RX data: 	N.A
 RX frame: 0x004D 0x0028 0x00000000 0x75
");
                MiniAdaLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                MiniAdaLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_SetSystemOutputPower_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(textBox_SetSystemOutputPower.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && buffer.Length <= 5)
            {
                textBox_SetSystemOutputPower.BackColor = Color.LightGreen;
            }
            else
            {
                textBox_SetSystemOutputPower.BackColor = Color.Red;
            }
        }

        private void button66_Click(object sender, EventArgs e)
        {
            textBox_SetSystemOutputPower_TextChanged(null,null); //Gil: a trick for send event of text changed
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "2A 00";
            textBox_data.Text = textBox_SetSystemOutputPower.Text;

            SendDataToSystem();
        }

        private void button67_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "2B 00";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void button66_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"Description:   Set system output power in dBm by Band type
Command: 	0x2A
TX data: 	5 bytes
		1 byte – Band type: 0x0 – Both, 0x1 – L1; 0x2 – L2
		4 byte – System output power in dBm -117.0 ÷ -49.0, Float type
TX frame: 	0x004D 0x002A 0x00000005 + TX Data + checksum
RX data: 	N.A
RX frame: 	0x004D 0x002A 0x00000000 0x77
");
                MiniAdaLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                MiniAdaLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }

        private void textBox_TCXOOnOff_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(textBox_TCXOOnOff.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && buffer.Length == 1)
            {
                textBox_TCXOOnOff.BackColor = Color.LightGreen;
            }
            else
            {
                textBox_TCXOOnOff.BackColor = Color.Red;
            }
        }

        private void button68_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "2E 00";
            textBox_data.Text = textBox_TCXOOnOff.Text;

            SendDataToSystem();
        }

        private void textBox_SetTCXOTrim_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(textBox_SetTCXOTrim.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && buffer.Length <= 4)
            {
                textBox_SetTCXOTrim.BackColor = Color.LightGreen;
            }
            else
            {
                textBox_SetTCXOTrim.BackColor = Color.Red;
            }
        }

        private void button69_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "2F 00";
            textBox_data.Text = textBox_SetTCXOTrim.Text;

            SendDataToSystem();
        }

        private void tabControl_MiniAda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void button71_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "70 00";
            textBox_data.Text = textBox_ReadFPGARegister.Text;

            SendDataToSystem();
        }

        private void textBox_ReadFPGARegister_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(textBox_ReadFPGARegister.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && buffer.Length <= 4)
            {
                textBox_ReadFPGARegister.BackColor = Color.LightGreen;
            }
            else
            {
                textBox_ReadFPGARegister.BackColor = Color.Red;
            }
        }

        private void textBox_WriteFPGARegister_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(textBox_WriteFPGARegister.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && buffer.Length <= 8)
            {
                textBox_WriteFPGARegister.BackColor = Color.LightGreen;
            }
            else
            {
                textBox_WriteFPGARegister.BackColor = Color.Red;
            }
        }

        private void button70_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "71 00";
            textBox_data.Text = textBox_WriteFPGARegister.Text;

            SendDataToSystem();
        }

        void richTextBox_ClientRxPrintText(String i_string)
        {
            richTextBox_ClientRx.AppendText(i_string);
            richTextBox_ClientRx.ScrollToCaret();
        }
        private void button72_Click(object sender, EventArgs e)
        {
            try
            {

                String szIPSelected = textBox_ClientIP.Text;


                Ping myPing = new Ping();
                PingReply reply = myPing.Send(szIPSelected);
                if (reply != null)
                {

                    // richTextBox_ClientRx.AppendText(String.Format("Failed to connect to [{0}] [{1}]\n", szIPSelected, szPort));
                    richTextBox_ClientRxPrintText("\n Status :  " + reply.Status + " \n Time : " + reply.RoundtripTime.ToString() + " \n Address : " + reply.Address);

                    if (reply.Status == IPStatus.Success)
                    {
                        button_Ping.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        button_Ping.BackColor = Color.Orange;
                    }
                    //Console.WriteLine(reply.ToString());
                }
            }
            catch
            {
                richTextBox_ClientRx.AppendText("ERROR: You have Some TIMEOUT issue");
            }
        }

        private void textBox_StoreDatainFlash_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(textBox_StoreDatainFlash.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                textBox_StoreDatainFlash.BackColor = Color.LightGreen;
            }
            else
            {
                textBox_StoreDatainFlash.BackColor = Color.Red;
            }
        }

        private void button72_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"4.2.2.12	Store data in Flash 
Description:   Store data in flash device 
Command: 	0x0030
TX data: 	8 bytes + N byte:
		4 bytes – address
		4 bytes – size of data to be stored
		N bytes – data to be stored
TX frame: 	0x0044 0x0030 + size + TX Data + CRC
RX data: 	N.A
RX frame: 	0x0044 0x0030 0x00000000 + CRC

");
                MiniAdaLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                MiniAdaLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }

        private void button72_Click_1(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "30 00";
            textBox_data.Text = textBox_StoreDatainFlash.Text;

            SendDataToSystem();
        }

        private void textBox_LoadDatainFlash_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(textBox_LoadDatainFlash.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && buffer.Length <= 8)
            {
                textBox_LoadDatainFlash.BackColor = Color.LightGreen;
            }
            else
            {
                textBox_LoadDatainFlash.BackColor = Color.Red;
            }
        }

        private void button73_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "31 00";
            textBox_data.Text = textBox_LoadDatainFlash.Text;

            SendDataToSystem();
        }

        private void button73_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"4.2.2.13	Load data from Flash by address 
Description:   Load data from flash by address
Command: 	0x0031
TX data: 	8 bytes:
4 byte – address
4 bytes – bytes to read. 
TX frame: 	0x0044 0x0031 0x00000008 + TX Data + CRC
RX data: 	N bytes – read data content 
RX frame: 	0x0044 0x0031 + size + RX Data + CRC

");
                MiniAdaLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                MiniAdaLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }

        private void button77_Click(object sender, EventArgs e)
        {
            textBox_SetRXChannelGain_TextChanged(null, null); //Gil: a trick for send event of text changed
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "56 00";
            textBox_data.Text = textBox_SetRXChannelGain.Text;

            SendDataToSystem();
        }

        private void textBox_SetRXChannelGain_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(textBox_SetRXChannelGain.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && buffer.Length <= 2)
            {
                textBox_SetRXChannelGain.BackColor = Color.LightGreen;
            }
            else
            {
                textBox_SetRXChannelGain.BackColor = Color.Red;
            }
        }

        private void button76_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "57 00";
            textBox_data.Text = textBox_GetRXChannelGain.Text;

            SendDataToSystem();
        }

        private void textBox_GetRXChannelGain_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(textBox_GetRXChannelGain.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && buffer.Length <= 1)
            {
                textBox_GetRXChannelGain.BackColor = Color.LightGreen;
            }
            else
            {
                textBox_GetRXChannelGain.BackColor = Color.Red;
            }
        }


        private void textBox_SetDCA_TextChanged(object sender, EventArgs e)
        {

            float DCA = 0; 
            bool Succees =float.TryParse(textBox_SetDCA.Text, out DCA);
            if (Succees == true)
            {
                byte[] buffer = BitConverter.GetBytes(DCA);

                if (buffer != null)
                {
                    textBox_SetDCAHex.Text = ByteArrayToString(buffer);
                    textBox_SetDCAHex.BackColor = Color.LightGreen;
                    textBox_SetDCA.BackColor = Color.LightGreen;
                }
                else
                {
                    textBox_SetDCA.BackColor = Color.Red;
                }
            }
            else
            {
                textBox_SetDCA.BackColor = Color.Red;
            }
        }

        private void button75_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "58 00";
            textBox_data.Text = textBox_SetDCAHex.Text;

            SendDataToSystem();
        }

        private void button74_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "59 00";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void textBox_RxRFPLL_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(textBox_RxRFPLL.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && buffer.Length <= 2)
            {
                textBox_RxRFPLL.BackColor = Color.LightGreen;
            }
            else
            {
                textBox_RxRFPLL.BackColor = Color.Red;
            }
        }

        private void button78_Click(object sender, EventArgs e)
        {
            textBox_RxRFPLL_TextChanged(null, null);

            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "5C 00";
            textBox_data.Text = textBox_RxRFPLL.Text;

            SendDataToSystem();
        }

        private void textBox_TxRFPLL_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(textBox_TxRFPLL.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && buffer.Length <= 2)
            {
                textBox_TxRFPLL.BackColor = Color.LightGreen;
            }
            else
            {
                textBox_TxRFPLL.BackColor = Color.Red;
            }
        }

        private void button79_Click(object sender, EventArgs e)
        {
            textBox_TxRFPLL_TextChanged(null, null);

            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "5D 00";
            textBox_data.Text = textBox_TxRFPLL.Text;

            SendDataToSystem();
        }

        private void button78_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"Help:
4.2.3.7	AD9361 Rx RF PLL lock detect 

Description:   Get RF PLL lock detect
Command: 	0x5C
TX data: 	2 byte
1 byte – Xcvr ID: 0x0 ÷ 0x3
1 byte – RF Synth.: 0x1 = Tx; 0x0 = Rx	
TX frame: 	0x004D 0x005C 0x00000002 + TX Data + checksum
RX data: 	1 byte 
Lock detect: 0x1=Locked; 0x0 = Not locked
RX frame: 	0x004D 0x005C 0x00000001 + RX Data + checksum

");
                MiniAdaLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                MiniAdaLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }

        private void textBox_SetGPIODir_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(textBox_SetGPIODir.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && buffer.Length <= 2)
            {
                textBox_SetGPIODir.BackColor = Color.LightGreen;
            }
            else
            {
                textBox_SetGPIODir.BackColor = Color.Red;
            }
        }

        private void textBox_GetGPIODir_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(textBox_GetGPIODir.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && buffer.Length <= 1)
            {
                textBox_GetGPIODir.BackColor = Color.LightGreen;
            }
            else
            {
                textBox_GetGPIODir.BackColor = Color.Red;
            }
        }

        private void textBox_SetGPIOVal_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(textBox_SetGPIOVal.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && buffer.Length <= 2)
            {
                textBox_SetGPIOVal.BackColor = Color.LightGreen;
            }
            else
            {
                textBox_SetGPIOVal.BackColor = Color.Red;
            }
        }

        private void textBox_GetGPIOVal_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(textBox_GetGPIOVal.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && buffer.Length <= 1)
            {
                textBox_GetGPIOVal.BackColor = Color.LightGreen;
            }
            else
            {
                textBox_GetGPIOVal.BackColor = Color.Red;
            }
        }

        private void button81_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "74 00";
            textBox_data.Text = textBox_SetGPIODir.Text;

            SendDataToSystem();
        }

        private void button80_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "75 00";
            textBox_data.Text = textBox_GetGPIODir.Text;

            SendDataToSystem();
        }

        private void button83_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "76 00";
            textBox_data.Text = textBox_SetGPIOVal.Text;

            SendDataToSystem();
        }

        private void button82_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "77 00";
            textBox_data.Text = textBox_GetGPIOVal.Text;

            SendDataToSystem();
        }

        private void textBox_RecordIQData_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(textBox_RecordIQData.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && buffer.Length <= 5)
            {
                textBox_RecordIQData.BackColor = Color.LightGreen;
            }
            else
            {
                textBox_RecordIQData.BackColor = Color.Red;
            }
        }

        private void button_RecordIQData_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "80 00";
            textBox_data.Text = textBox_RecordIQData.Text;

            SendDataToSystem();
        }

        private void textBox_RecordIQSourceSealect_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(textBox_RecordIQSourceSealect.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && buffer.Length <= 3)
            {
                textBox_RecordIQSourceSealect.BackColor = Color.LightGreen;
            }
            else
            {
                textBox_RecordIQSourceSealect.BackColor = Color.Red;
            }
        }

        private void textBox_SetRxChannelState_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(textBox_SetRxChannelState.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && buffer.Length <= 2)
            {
                textBox_SetRxChannelState.BackColor = Color.LightGreen;
            }
            else
            {
                textBox_SetRxChannelState.BackColor = Color.Red;
            }
        }

        private void button84_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "81 00";
            textBox_data.Text = textBox_RecordIQSourceSealect.Text;

            SendDataToSystem();
        }

        private void button85_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "81 00";
            textBox_data.Text = textBox_SetRxChannelState.Text;

            SendDataToSystem();
            
        }

        private void button86_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = MINIADA_HEADER;
            textBox_Opcode.Text = "D0 00";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void ComboBox_SerialPortHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox_SerialPortHistory.SelectedItem != null )
            //{
            //    if (textBox_SendSerialPort.Text != comboBox_SerialPortHistory.SelectedItem.ToString())
            //    {
            //        textBox_SendSerialPort.Text = comboBox_SerialPortHistory.SelectedItem.ToString();
            //    }
            //}
        }

        private void ListBox_Charts_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox_Charts.Items.Count; i++)
            {
                
                if (listBox_Charts.GetSelected(i) == true)
                {
                    chart1.Series[i].Enabled = true;
                }
                else
                {
                    chart1.Series[i].Enabled = false;
                }
            }
        }

        void ResetTimer()
        {
            textBox_TimerTime.Text = TimerMemory.ToString();
            textBox_SetTimerTime.Text = "0";
            IsTimerRunning = false;
            button_StartStopTimer.BackColor = default;
        }

        private void Button_ResetTimer_Click(object sender, EventArgs e)
        {
            ResetTimer();
        }

        //private void comboBox_SendThrough_SelectedIndexChanged_1(object sender, EventArgs e)
        //{
        //    switch (comboBox_SendThrough.SelectedIndex)
        //    {
        //        case (int)eComSource.GPRS:
        //            groupBox_ServerSettings.Visible = true;
        //            gbPortSettings.Visible = false;
        //            groupBox_PhoneNumber.Visible = false;
        //            break;
        //        case (int)eComSource.SerialPort:
        //            groupBox_ServerSettings.Visible = false;
        //            gbPortSettings.Visible = true;
        //            groupBox_PhoneNumber.Visible = false;
        //            break;
        //        case (int)eComSource.SMS:
        //            groupBox_ServerSettings.Visible = false;
        //            gbPortSettings.Visible = true;
        //            groupBox_PhoneNumber.Visible = true;
        //            break;
        //    }
        //}

        //private bool m_EchoResponse = false;
        //private void checkBox1_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox1.Checked == true)
        //    {
        //        m_EchoResponse = true;
        //    }
        //    else
        //    {
        //        m_EchoResponse = false;
        //    }
        //}


        /*Modem Registration Status = [1], RSSI = [31], Modem GPRS = [0],
         * Temperature Level = [0],Board Temperature = [31] , Sim Status = [1] ,
         * OperatorName = ["Cellcom"], Modem Voltage = [3.924000], Modem SIMIdentificationNumber = [899720201108447424] ,
         * ModemIMEI = [354869050098417], SimIMSI = [425020110844742], ModemVersion = [Cinterion,BGS2-W,REVISION 02.000,A-REVISION 01.000.08,OK,], 
         * ModemConnectionStatus = [], ModemServiceStatus = [], ModemServiceStatus2 = [], ModemErrorServiceStatus = [], ModemEUpdateCounter = [4],*/

        class ModemStatus
        {
            public bool Valid = false;
            public string ModemRegistrationStatus = "";
            public string RSSI = "";
            public string SIMStatus = "";
            public string Operator = "";
            public string ModemVoltage = "";
            public string SIMIdentificationNumber = "";
            public string ModemIMEI = "";
            public string SimIMSI = "";
            public string ModemVersion = "";
            public string ModemEUpdateCounter = "";

            public ModemStatus(ref string i_ModemStatus)
            {
                if (i_ModemStatus.Contains("Modem Registration Status") &&
                    i_ModemStatus.Contains("RSSI") &&
                    i_ModemStatus.Contains("SIMIdentificationNumber") &&
                    i_ModemStatus.Contains("SMS_ONLY") &&
                    i_ModemStatus.Contains("SIMIdentificationNumber"))
                {
                    i_ModemStatus = i_ModemStatus.Substring(i_ModemStatus.LastIndexOf("SMS_ONLY"));
                    string[] values = i_ModemStatus.Split('[', ']');
                    if (values.Length >= 33)
                    {
                        this.ModemRegistrationStatus = values[1];
                        this.RSSI = values[3];
                        this.SIMStatus = values[11];
                        this.Operator = values[13];
                        this.ModemVoltage = values[15];
                        this.SIMIdentificationNumber = values[17];
                        this.ModemIMEI = values[19];
                        this.SimIMSI = values[21];
                        this.ModemVersion = values[23];
                        this.ModemEUpdateCounter = values[33];

                        Valid = true;
                    }
                    else
                    {
                        Valid = false;
                    }

                }
                else
                {
                    Valid = false;
                }
            }
        }



    }
}