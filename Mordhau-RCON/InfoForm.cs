using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mordhau_RCON
{
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();
            lblVersion.Text = "Version: " + Application.ProductVersion;
        }

        private void CopyMail(object sender, EventArgs e)
        {
            Clipboard.SetText("wagi.coding@gmail.com");
        }

        private void mailClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:wagi.coding@gmail.com");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("Taki7o7#0707");
        }

        private void linkLabelGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/WaGi-Coding/mordhau-rcon-tool");
        }
    }
}
