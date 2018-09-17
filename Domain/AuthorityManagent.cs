using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AuthorityManagent
    {
        public string UserName { get; protected set; }
        public string Password { get; protected set; }
        public enum Authority { 管理員, 操作者, 訪客 };
        public Authority Auth { get; protected set; }
        public bool CheckAuthority { get; set; }
        public AuthorityManagent(string username, string password, Authority authority)
        {
            this.UserName = username;
            this.Password = password;
            this.Auth = authority;
        }
    }
}
