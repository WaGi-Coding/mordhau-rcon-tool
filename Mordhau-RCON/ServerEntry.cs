using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mordhau_RCON
{
    public class ServerEntry
    {
        public string ServerName { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
        public string Password { get; set; }

        public ServerEntry(string ServerName, string IP, int Port, string Password)
        {
            this.ServerName = ServerName;
            this.IP = IP;
            this.Port = Port;
            this.Password = Password;

        }
    }
}
