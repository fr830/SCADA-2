using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AuthorityEvent : EventArgs
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Authority { get; set; }
    }
}
