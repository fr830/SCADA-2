using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Collections;

namespace ConnectLib
{
    public class ModbusClient
    {
        private string IP
        {
            get;
            set;
        }     //將服務器IP設為可讀可寫
        public string Errorcode
        {
            get;
            set;
        }  //宣告通訊錯誤碼
        public int Len;
        public int R
        {
            get;
            set;
        }  //宣告接收總btye數
        private Socket ModbusSocket { get; set; }  //建立發訊端通訊對象
        private byte[] ReceiverBuffer = new byte[2048];  //宣告接收緩衝區為2KB
        public ModbusClient(string ip)   //建立客戶端對象
        {
            try
            {
                this.IP = ip;
                ModbusSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);  //建立套接字對象
                IPEndPoint server = new IPEndPoint(IPAddress.Parse(ip), 502);  //建立遠端連線夥伴對象,port 502代表modbusTCP/IP專用通訊阜
                ModbusSocket.SendBufferSize = 2048;  //建立記出緩衝區
                ModbusSocket.ReceiveBufferSize = 2048;  // 建立接收緩衝區
                ModbusSocket.Connect(server); //與遠端夥伴連線
            }
            catch (SocketException)
            {
                throw;
            }
            }
        public bool[] ReadCoil(byte slaveAddress, ushort startAddress, ushort numberofpoints)  //建立讀取線圈狀態方法(需傳入服務器ID,欲讀線圈起始地址,欲讀線圈總數)
        {
            byte[] data = null;  //宣告存放數據數組,在try迴圈外宣告,讓ReadCoil方法中的所有人都能讀取
            try
            {
                byte[] frame = new byte[12];  //建立命令數組
                frame[0] = (byte)(1 >> 8);  //傳輸識別碼的高字節
                frame[1] = (byte)1; //傳輸識別碼的低字節
                frame[2] = 0; //協定識別碼的高字節(協定識別碼通常都為0)
                frame[3] = 0; //協定識別碼的低字節
                frame[4] = 0; //封包內共有數據數的高字節
                frame[5] = 6; //封包內共有數據數的低字節
                frame[6] = slaveAddress; //unit ID
                frame[7] = 1;  //功能碼
                frame[8] = (byte)(startAddress >> 8); //要求開始讀取的線圈位子的高字節
                frame[9] = (byte)startAddress;//要求開始讀取的線圈位子的低字節
                frame[10] = (byte)(numberofpoints >> 8); //要求總共讀取線圈數的高字節
                frame[11] = (byte)numberofpoints;//要求總共讀取線圈數的低字節
                ModbusSocket.Send(frame, frame.Length, SocketFlags.None); //將命令寄出
                Thread.Sleep(100);  //線程暫停100ms等待服務器回應
                NetworkStream ns = new NetworkStream(ModbusSocket);
                if (ns != null)
                {
                    if (ns.CanRead)
                    {
                        int r = ModbusSocket.Receive(ReceiverBuffer, ReceiverBuffer.Length, SocketFlags.None); //接收服務器傳回的指令,r表示總共接到多少個字元
                        this.R = r;
                    }
                }
                else
                {
                    Errorcode = "Server was not respond";
                }
                int SizeByte = ReceiverBuffer[8]; //服務器回應中的第9位代表共有多少個數據字節組
                data = new byte[SizeByte]; //建立數據存放區
                Array.Copy(ReceiverBuffer, 9, data, 0, data.Length); //將服務器回應中為線圈狀態的數據讀入
            }
            catch (Exception ex)
            {
                Errorcode = ex.ToString();
            }
            List<bool> result = new List<bool>();  //建立一個專門儲存布林數的泛型集合,使用泛型集合是因為泛型集合存取數據相對容易
            BitArray bits = new BitArray(data); //將字節數組轉換為位元陣列

            bool[] temp = null;
            for (int i = 0; i < bits.Count; i++) //將轉成位元的線圈狀態依次存入集合中
            {
                result.Add(bits[i]);
            }
            temp = result.ToArray(); //將讀取到的數據從byte轉成bit用以判斷哪些線圈輸出了
            return temp;
        }
    /*    public int[] ReadHoldRegister(byte slaveAddress, ushort startAddress, ushort numberofpoints) //建立讀取暫存器值的方法(需傳入 服務器ID,欲讀線圈起始地址,欲讀線圈總數),在此建立int16是因為PLC大部分的字、整數都是16bits
        {
            byte[] data = null;  //宣告存放數據數組,在try迴圈外宣告,讓ReadCoil方法中的所有人都能讀取
            try
            {
                byte[] frame = new byte[12];  //建立命令數組
                frame[0] = (byte)(1 >> 8);  //傳輸識別碼的高字節
                frame[1] = (byte)1; //傳輸識別碼的低字節
                frame[2] = 0; //協定識別碼的高字節(協定識別碼通常都為0)
                frame[3] = 0; //協定識別碼的低字節
                frame[4] = 0; //封包內共有數據數的高字節
                frame[5] = 6; //封包內共有數據數的低字節
                frame[6] = slaveAddress; //unit ID
                frame[7] = 3;  //功能碼
                frame[8] = (byte)(startAddress >> 8); //要求開始讀取的線圈位子的高字節
                frame[9] = (byte)startAddress;//要求開始讀取的線圈位子的低字節
                frame[10] = (byte)(numberofpoints >> 8); //要求總共讀取線圈數的高字節
                frame[11] = (byte)numberofpoints;//要求總共讀取線圈數的低字節
                ModbusSocket.Send(frame, frame.Length, SocketFlags.None); //將命令寄出
                Thread.Sleep(100);  //線程暫停100ms等待服務器回應
                NetworkStream ns = new NetworkStream(ModbusSocket);
                int r = ModbusSocket.Receive(ReceiverBuffer, ReceiverBuffer.Length, SocketFlags.None); //接收服務器傳回的指令,r表示總共接到多少個字元
                this.R = r;
            }
            catch (Exception )
            {
                throw;
            }
            int SizeByte = ReceiverBuffer[8]; //服務器回應中的第9位代表共有多少個數據字節組
            data = new byte[SizeByte]; //建立數據存放區
            Array.Copy(ReceiverBuffer, 9, data, 0, data.Length); //將服務器回應中為線圈狀態的數據讀入
            int[] RegisterValue = GetInt(data);
            return RegisterValue;
        }*/
        public short[] ReadHoldRegister(byte slaveAddress, ushort startAddress, ushort numberofpoints) //建立讀取暫存器值的方法(需傳入 服務器ID,欲讀線圈起始地址,欲讀線圈總數),在此建立int16是因為PLC大部分的字、整數都是16bits
        {
            byte[] data = null;  //宣告存放數據數組,在try迴圈外宣告,讓ReadCoil方法中的所有人都能讀取
            try
            {
                byte[] frame = new byte[12];  //建立命令數組
                frame[0] = (byte)(1 >> 8);  //傳輸識別碼的高字節
                frame[1] = (byte)1; //傳輸識別碼的低字節
                frame[2] = 0; //協定識別碼的高字節(協定識別碼通常都為0)
                frame[3] = 0; //協定識別碼的低字節
                frame[4] = 0; //封包內共有數據數的高字節
                frame[5] = 6; //封包內共有數據數的低字節
                frame[6] = slaveAddress; //unit ID
                frame[7] = 3;  //功能碼
                frame[8] = (byte)(startAddress >> 8); //要求開始讀取的線圈位子的高字節
                frame[9] = (byte)startAddress;//要求開始讀取的線圈位子的低字節
                frame[10] = (byte)(numberofpoints >> 8); //要求總共讀取線圈數的高字節
                frame[11] = (byte)numberofpoints;//要求總共讀取線圈數的低字節
                ModbusSocket.Send(frame, frame.Length, SocketFlags.None); //將命令寄出
                Thread.Sleep(100);  //線程暫停100ms等待服務器回應
                NetworkStream ns = new NetworkStream(ModbusSocket);
                int r = ModbusSocket.Receive(ReceiverBuffer, ReceiverBuffer.Length, SocketFlags.None); //接收服務器傳回的指令,r表示總共接到多少個字元
                this.R = r;
            }
            catch (Exception)
            {
                throw;
            }
            int SizeByte = ReceiverBuffer[8]; //服務器回應中的第9位代表共有多少個數據字節組
            data = new byte[SizeByte]; //建立數據存放區
            Array.Copy(ReceiverBuffer, 9, data, 0, data.Length); //將服務器回應中為線圈狀態的數據讀入
            short[] RegisterValue = GetInt16(data);
            return RegisterValue;
        }
        public bool[] ReadDigitalInput(byte slaveAddress, ushort startAddress, ushort numberofpoints)
        {
            byte[] data = null;  //宣告存放數據數組,在try迴圈外宣告,讓ReadCoil方法中的所有人都能讀取
            try
            {
                byte[] frame = new byte[12];  //建立命令數組
                frame[0] = (byte)(1 >> 8);  //傳輸識別碼的高字節
                frame[1] = (byte)1; //傳輸識別碼的低字節
                frame[2] = 0; //協定識別碼的高字節(協定識別碼通常都為0)
                frame[3] = 0; //協定識別碼的低字節
                frame[4] = 0; //封包內共有數據數的高字節
                frame[5] = 6; //封包內共有數據數的低字節
                frame[6] = slaveAddress; //unit ID
                frame[7] = 2;  //功能碼
                frame[8] = (byte)(startAddress >> 8); //要求開始讀取的線圈位子的高字節
                frame[9] = (byte)startAddress;//要求開始讀取的線圈位子的低字節
                frame[10] = (byte)(numberofpoints >> 8); //要求總共讀取線圈數的高字節
                frame[11] = (byte)numberofpoints;//要求總共讀取線圈數的低字節
                ModbusSocket.Send(frame, frame.Length, SocketFlags.None); //將命令寄出
                Thread.Sleep(100);  //線程暫停100ms等待服務器回應
                NetworkStream ns = new NetworkStream(ModbusSocket);
                if (ns != null)
                {
                    if (ns.CanRead)
                    {
                        int r = ModbusSocket.Receive(ReceiverBuffer, ReceiverBuffer.Length, SocketFlags.None); //接收服務器傳回的指令,r表示總共接到多少個字元
                        this.R = r;
                    }
                }
                else
                {
                    Errorcode = "Server was not respond";
                }
                int SizeByte = ReceiverBuffer[8]; //服務器回應中的第9位代表共有多少個數據字節組
                Len = ReceiverBuffer[8];
                data = new byte[SizeByte]; //建立數據存放區
                Array.Copy(ReceiverBuffer, 9, data, 0, data.Length); //將服務器回應中為線圈狀態的數據讀入
            }
            catch (Exception ex)
            {
                Errorcode = ex.ToString();
            }
            List<bool> result = new List<bool>();  //建立一個專門儲存布林數的泛型集合,使用泛型集合是因為泛型集合存取數據相對容易
            BitArray bits = new BitArray(data); //將字節數組轉換為位元陣列
            bool[] temp = null;
            for (int i = 0; i < bits.Count; i++) //將轉成位元的線圈狀態依次存入集合中
            {
                result.Add(bits[i]);
            }
            temp = result.ToArray(); //將讀取到的數據從byte轉成bit用以判斷哪些線圈輸出了
            return temp;
        }
        public short[] GetInt16(byte[] data)
        {
            try
            {
                List<short> DataInt16 = new List<short>();
                short NumberOByte = 0;
                byte[] Bytes = new byte[1];
                for (short item = 0; item < data.Length / 2;)
                {
                    Bytes[0] = data[NumberOByte];
                    BitArray bits = new BitArray(Bytes);
                    short IntValue = 0;
                    if (bits[7])
                    {
                        IntValue = Convert.ToInt16((data[NumberOByte++] * 256 + data[NumberOByte++]) - 65536);
                    }
                    else
                    {
                        IntValue = Convert.ToInt16(data[NumberOByte++] * 256 + data[NumberOByte++]);
                    }
                    item++;
                    DataInt16.Add(IntValue);
                }
                short[] RealData = DataInt16.ToArray();
                return RealData;
            }
            catch (OverflowException)
            {
                throw;
            }
        }
        public int[] GetInt(byte[] data)
        {
            List<int> DataInt32 = new List<int>();
            short NumberOByte = 0;
            byte[] Bytes = new byte[1];
            for (short item = 0; item < data.Length / 2;)
            {
                Bytes[0] = data[NumberOByte];
                BitArray bits = new BitArray(Bytes);
                int IntValue = 0;
                if (bits[7])
                {
                    IntValue = (Convert.ToInt32(data[NumberOByte++] * 256 + data[NumberOByte++]) - 65536);
                }
                else
                {
                    IntValue = Convert.ToInt32(data[NumberOByte++] * 256 + data[NumberOByte++]);
                }
                item++;
                DataInt32.Add(IntValue);
            }
            int[] RealData = DataInt32.ToArray();
            return RealData;
        }  //將字節組數組轉成帶正負整數數組的方法
        public void Disconnect() //斷開與服務器的通訊方法
        {
            try
            {
                ModbusSocket.Disconnect(false);
            }
            catch (SocketException)
            {

            }
            finally
            {
                ModbusSocket.Shutdown(SocketShutdown.Both);
                ModbusSocket.Dispose();
            }
        }
        public void CheckVaildote(byte[] messageReceived) //回傳錯誤代碼
        {
            try
            {
                switch (messageReceived[1])
                {
                    case 129:
                    case 130:
                    case 131:
                    case 132:
                    case 133:
                    case 134:
                    case 143:
                    case 144:
                        switch (messageReceived[2])
                        {
                            case 1:
                                throw new Exception("01/0x01:Illegal Function");
                            case 2:
                                throw new Exception("02/0x02:Illegal Data Address");
                            case 3:
                                throw new Exception("03/0x03:Illegal Data Value");
                            case 4:
                                throw new Exception("04/0x04:Failure in Associated Device");
                            case 5:
                                throw new Exception("05/0x05:Ackonwledge");
                            case 6:
                                throw new Exception("06/0x06: Slave Deevice Busy");
                            case 7:
                                throw new Exception("07/0x07:NAK ");
                            case 8:
                                throw new Exception("08/0x08: Memory Parity Error");
                            case 10:
                                throw new Exception("10/0x0A:Gateway Path Unavailable");
                            case 11:
                                throw new Exception("11/0x0B:Gateway Target Decive Failed to respond");
                            default:
                                break;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                this.Errorcode = ex.ToString();
            }
        }
        public ushort[] GetWord(byte[] data)
        {
            List<ushort> DataWord = new List<ushort>();
            short NumberOByte = 0;
            byte[] Bytes = new byte[1];
            for (short item = 0; item < data.Length / 2;)
            {
                ushort IntValue = Convert.ToUInt16(data[NumberOByte++] * 256 + data[NumberOByte++]);
                item++;
                DataWord.Add(IntValue);
            }
            ushort[] RealData = DataWord.ToArray();
            return RealData;
        }    //將字節組數組轉成不帶正負整數數組的方法
        public void WriteSingleCoil(byte slaveAddress, ushort Address, bool Common)
        {
            try
            {
                byte[] frame = new byte[12];  //建立命令數組
                frame[0] = (byte)(1 >> 8);  //傳輸識別碼的高字節
                frame[1] = (byte)1; //傳輸識別碼的低字節
                frame[2] = 0; //協定識別碼的高字節(協定識別碼通常都為0)
                frame[3] = 0; //協定識別碼的低字節
                frame[4] = 0; //封包內共有數據數的高字節
                frame[5] = 6; //封包內共有數據數的低字節
                frame[6] = slaveAddress; //unit ID
                frame[7] = 5;  //功能碼
                frame[8] = (byte)(Address >> 8); //要求開始讀取的線圈位子的高字節
                frame[9] = (byte)Address;//要求開始讀取的線圈位子的低字節
                if (Common)
                    frame[10] = 0xFF; //要求總共讀取線圈數的高字節
                else
                    frame[10] = 0x00; //要求總共讀取線圈數的高字節
                frame[11] = 0;
                ModbusSocket.Send(frame, frame.Length, SocketFlags.None); //將命令寄出
                Thread.Sleep(100);
                NetworkStream ns = new NetworkStream(ModbusSocket);
                if (ns != null)
                {
                    if (ns.CanRead)
                    {
                        int r = ModbusSocket.Receive(ReceiverBuffer, ReceiverBuffer.Length, SocketFlags.None); //接收服務器傳回的指令,r表示總共接到多少個字元
                    }
                }
            }
            catch (Exception ex)
            {
                Errorcode = ex.ToString();
            }
        }
        public bool Connected()
        {
            if (ModbusSocket.Connected)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
