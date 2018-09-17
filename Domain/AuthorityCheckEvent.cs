using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AuthorityCheckEvent : EventArgs
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string AuthorityManagent { get; set; }
    }
}
