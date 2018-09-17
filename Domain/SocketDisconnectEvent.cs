using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain
{
    public class SocketDisconnectEvent : EventArgs
    {
       public string status;
        public string TextColor;
        public bool OpenButton;
    }
}
