using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mordhau_RCON
{
    public class VersionEntry
    {
        public string Version { get; set; }
        public string Header { get; set; }
        public string[] Fixes { get; set; }
        public string[] Additions { get; set; }
        public string Footer { get; set; }

        public VersionEntry(string version, string header, string[] fixes, string[] additions, string footer)
        {
            Version = version;
            Header = header;
            Fixes = fixes;
            Additions = additions;
            Footer = footer;
        }
    }
}
