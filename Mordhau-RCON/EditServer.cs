using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mordhau_RCON
{
    public partial class EditServer : Form
    {
        ServerEntry se;
        public int index;
        MainForm mainForm;
        public ServerEntry newServerEntryData { get; set; }

        public EditServer(ServerEntry se, int index, MainForm mainForm)
        {
            InitializeComponent();
            this.se = se;
            this.index = index;
            this.mainForm = mainForm;
        }


        private void EditServer_Load(object sender, EventArgs e)
        {
            if (se != null)
            {
                if (!string.IsNullOrEmpty(se.ServerName))
                {
                    this.Text = "Edit Server - " + se.ServerName;
                    tbServername.Text = se.ServerName;
                }

                tbIP.Text = se.IP;
                tbPort.Value = se.Port;
                tbPassword.Text = se.Password;

                tbServername.Focus();
                this.ActiveControl = tbServername;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Name filled check
            if (string.IsNullOrEmpty(tbServername.Text))
            {
                MessageBox.Show("Please enter a Servername!");
                return;
            }

            // Name exists check
            if (mainForm.servers.Count > 0)
            {
                if (mainForm.servers.Any(item => item.ServerName == tbServername.Text && item.ServerName != se.ServerName))
                {
                    MessageBox.Show("Another Server with this name does already exists!");
                    return;
                }
            }

            // IP "convert"
            if (tbIP.Text.ToLower() == "localhost" || tbIP.Text.ToLower() == "127.0.0.1")
            {
                IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
                foreach (IPAddress addr in localIPs)
                {
                    if (addr.AddressFamily == AddressFamily.InterNetwork)
                    {
                        if (addr.ToString().StartsWith("192."))
                        {
                            tbIP.Text = addr.ToString();
                            break;
                        }
                    }
                }
            }


            // IP check
            if (string.IsNullOrEmpty(tbIP.Text))
            {
                MessageBox.Show("Please enter an IP-Adress!");
                return;
            }

            Match match = Regex.Match(tbIP.Text, @"((^\s*((([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5]))\s*$)|(^\s*((([0-9A-Fa-f]{1,4}:){7}([0-9A-Fa-f]{1,4}|:))|(([0-9A-Fa-f]{1,4}:){6}(:[0-9A-Fa-f]{1,4}|((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3})|:))|(([0-9A-Fa-f]{1,4}:){5}(((:[0-9A-Fa-f]{1,4}){1,2})|:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3})|:))|(([0-9A-Fa-f]{1,4}:){4}(((:[0-9A-Fa-f]{1,4}){1,3})|((:[0-9A-Fa-f]{1,4})?:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){3}(((:[0-9A-Fa-f]{1,4}){1,4})|((:[0-9A-Fa-f]{1,4}){0,2}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){2}(((:[0-9A-Fa-f]{1,4}){1,5})|((:[0-9A-Fa-f]{1,4}){0,3}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){1}(((:[0-9A-Fa-f]{1,4}){1,6})|((:[0-9A-Fa-f]{1,4}){0,4}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(:(((:[0-9A-Fa-f]{1,4}){1,7})|((:[0-9A-Fa-f]{1,4}){0,5}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:)))(%.+)?\s*$))");
            if (tbIP.Text.StartsWith("0.") || !match.Success)
            {
                MessageBox.Show("Invalid IP");
                return;
            }

            // Password Empty check and confirmation
            if (string.IsNullOrEmpty(tbPassword.Text))
            {
                var result = MessageBox.Show("Save this Server without Password?", "Info - Empty Password", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    tbPassword.Focus();
                    this.ActiveControl = tbPassword;
                    return;
                }
            }

            newServerEntryData = new ServerEntry(tbServername.Text, tbIP.Text, (int)tbPort.Value, tbPassword.Text);

            if (newServerEntryData.ServerName == mainForm.lastServer.ServerName && newServerEntryData.IP == mainForm.lastServer.IP && newServerEntryData.Port == mainForm.lastServer.Port && newServerEntryData.Password == mainForm.lastServer.Password)
            {
                this.DialogResult = DialogResult.Abort;
                this.Close();
                return;
            }

            // Update Lastserver & Label if needed
            if ((se.ServerName == mainForm.lastServer.ServerName))
            {
                mainForm.tbIP.Text = newServerEntryData.IP;
                mainForm.tbPort.Value = newServerEntryData.Port;
                mainForm.tbPw.Text = newServerEntryData.Password;
                mainForm.lastServer = newServerEntryData;
                if (mainForm.btnConnect.Text == "Disconnect" || mainForm.btnConnect.Text == "Connecting")
                {
                    mainForm.Sr.S.Close();
                }
                
            }
            mainForm.StatusLabel.Text = "Server: " + newServerEntryData.ServerName;
            this.DialogResult = DialogResult.OK;


            //if (se.ServerName == mainForm.lastServer.ServerName)
            //{
            //    if (mainForm.StatusLabel.Text.StartsWith("Server: "))
            //    {
            //        mainForm.StatusLabel.Text = "Server: " + newServerEntryData.ServerName;
            //    }
            //    else if (mainForm.StatusLabel.Text.StartsWith("Connecting to "))
            //    {
            //        mainForm.StatusLabel.Text = "Connecting to " + newServerEntryData.ServerName;
            //    }
            //    else if (mainForm.StatusLabel.Text.StartsWith("Connected to "))
            //    {
            //        mainForm.StatusLabel.Text = "Connected to " + newServerEntryData.ServerName;
            //    }
            //}


            //if (tbIP.Text == mainForm.lastServer.IP && tbPort.Value == mainForm.lastServer.Port && tbPassword.Text == mainForm.lastServer.Password && mainForm.lastServer.ServerName == "LastServerEntry")
            //{
            //    // change last server to just saved one
            //    mainForm.lastServer = new ServerEntry(tbServername.Text, tbIP.Text, Convert.ToInt32(tbPort.Value), tbPassword.Text);
            //    // Handle update label
            //    mainForm.DataChanged(null, null);
            //    // save new as last server
            //    Properties.Settings.Default.LastServer = JsonConvert.SerializeObject(mainForm.lastServer);
            //    Properties.Settings.Default.Save();
            //}
            //else
            //{

            //}

            //////////////////////////////////////


            this.Close();
        }

        private void btnShowHidePassword_Click(object sender, EventArgs e)
        {
            if (tbPassword.UseSystemPasswordChar)
            {
                btnShowHidePassword.Text = "Hide Pass";
                tbPassword.UseSystemPasswordChar = false;
                tbPassword.PasswordChar = '\0';
            }
            else
            {
                btnShowHidePassword.Text = "Show Pass";
                tbPassword.UseSystemPasswordChar = true;
                tbPassword.PasswordChar = '*';
            }
        }

        private void tbIP_TextChanged(object sender, EventArgs e)
        {
            // IP "convert"
            if (tbIP.Text.ToLower() == "localhost" || tbIP.Text.ToLower() == "127.0.0.1")
            {
                IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
                foreach (IPAddress addr in localIPs)
                {
                    if (addr.AddressFamily == AddressFamily.InterNetwork)
                    {
                        if (addr.ToString().StartsWith("192."))
                        {
                            tbIP.Text = addr.ToString();
                            tbIP.SelectionStart = tbIP.Text.Length;
                            break;
                        }
                    }
                }
            }
        }
    }
}
