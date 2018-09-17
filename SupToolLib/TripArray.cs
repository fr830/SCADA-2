using System;
using System.Collections.Generic;
using ConnectLib;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupToolLib
{
    public class TripArray
    {
        public string Name { get; private set; }
        public DateTime Time { get; private set; }
        public status Stat { get; private set; }
        public enum status
        {
            發生 = 1,
            複歸 = 0
        }
        public TripArray(string name, DateTime time, status status)
        {
            this.Name = name;
            this.Time = time;
            this.Stat = status;
        }
        public static void GetTrip(short DINewTripHigh,short D1NewTripLow,short AINewTripHigh,short AINewTripLow,short NewAlarmHigh,short NewAlarmLow,int OldInput,int OldAITrip, string[] TripType, string[] AITripType, DateTime InputTime, SQLBroke broke)
        {
            bool[] NewBits = new bool[32];
            bool[] OldBits = new bool[32];
            int DITrip = shortToInt(DINewTripHigh, D1NewTripLow);
            int AITrip = shortToInt(AINewTripHigh, AINewTripLow);
            int Alarm = shortToInt(NewAlarmHigh, NewAlarmLow);
        //    int Search = shortToInt(SearchHigh, SearchLow);
            List <TripArray> list = new List<TripArray>();
            if (DITrip != OldInput)
            {
                for (int i = 0; i < 32; i++)
                {
                    NewBits[i] = (((DITrip >> i) & 1) == 1);
                    OldBits[i] = (((OldInput >> i) & 1) == 1);
                    if (NewBits[i] != OldBits[i])
                    {
                        if (OldBits[i])
                        {
                            if (broke.Search("Name", "UnitTrip").Contains(TripType[i]))
                            {
                                broke.Update("UnitTrip", TripType[i], InputTime, "複歸", DITrip, AITrip, Alarm);
                            }
                            else
                            {
                                broke.Insert("UnitTrip", TripType[i], InputTime, "複歸", DITrip, AITrip, Alarm);
                            }
                        }
                        else
                        {
                            broke.Insert("UnitTrip", TripType[i], InputTime, "發生", DITrip, AITrip, Alarm);
                        }
                    }
                }
            }
            if (AITrip != OldAITrip)
            {
                for (int i = 0; i < 32; i++)
                {
                    NewBits[i] = (((AITrip >> i) & 1) == 1);
                    OldBits[i] = (((OldAITrip >> i) & 1) == 1);
                    if (NewBits[i] != OldBits[i])
                    {
                        if (OldBits[i])
                        {
                            if (broke.Search("Name", "UnitTrip").Contains(AITripType[i]))
                            {
                                broke.Update("UnitTrip", AITripType[i], InputTime, "複歸", DITrip, AITrip, Alarm);
                            }
                            else
                            {
                                broke.Insert("UnitTrip", AITripType[i], InputTime, "複歸", DITrip, AITrip, Alarm);
                            }
                        }
                        else
                        {
                            broke.Insert("UnitTrip", AITripType[i], InputTime, "發生", DITrip, AITrip, Alarm);
                        }
                    }
                }
            }
        }
        public static int shortToInt(short High, short Low)
        {
            byte[] Bytes = new byte[4] { 0, 0, 0, 0 };
            Bytes[0] = (byte)(Low & 0xff);
            Bytes[1] = (byte)((Low >> 8) & 0xff);
            Bytes[2] = (byte)(High & 0xff);
            Bytes[3] = (byte)((High >> 8) & 0xff);
            int GetInt = BitConverter.ToInt32(Bytes, 0);
            return GetInt;
        }
    }
}
