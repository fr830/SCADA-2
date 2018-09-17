using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain
{
    public class ConnectStatusEvent : EventArgs
    {
        public string UnitConnectStatus;
        public string ConnectStatus;
        public string UserName;
        public string authority;
        public string UnitConnectStatusColor;
        public string StationConnectStatusColor;
    }
}
