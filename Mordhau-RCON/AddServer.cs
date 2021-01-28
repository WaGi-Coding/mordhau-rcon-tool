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
    public partial class AddServer : Form
    {
        MainForm mainForm;

        ServerEntry se;
        List<ServerEntry> ServerList = new List<ServerEntry>();
        
        public ServerEntry newServerEntryData { get; set; }

        public AddServer(MainForm mainForm, ServerEntry se, List<ServerEntry> servers)
        {
            InitializeComponent();

            this.mainForm = mainForm;

            this.se = se;
            this.ServerList = servers;
        }

        private void AddServer_Load(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(tbServername.Text))
            {
                // ===================
                //var newServerEntries = 

                var tmpList = ServerList.Where(x => x.ServerName.Contains("New Server ")).Select(x => x.ServerName.Split(new string[] { "New Server " }, StringSplitOptions.None)).ToArray();
                //Console.WriteLine("COUNT: " + tmpList[0][1]);
                List<int> tmpIntList = new List<int>();
                //Console.WriteLine("========= tmpCount: " + tmpIntList.Count());
                foreach (var item in tmpList)
                {
                    if (Int32.TryParse(item[1], out int result) && item[1].Count() == 1)
                    {
                        if (true)
                        {
                            if (result > 0)
                            {
                                tmpIntList.Add(result);
                                //Console.WriteLine(result);
                            }
                        }
                    }
                }
                //Array.Sort(tmpIntArray);
                //Console.WriteLine("=========" + tmpIntList.Count());
                //foreach (int item in tmpIntList)
                //{
                //    Console.WriteLine(item.ToString());
                //}

                int NewServerCounter = getSmallestAvailable(tmpIntList.ToArray(), 1);

                // ===================

                if (NewServerCounter <= 0)
                {
                    tbServername.Text = string.Empty;
                }
                else
                {
                    tbServername.Text = "New Server " + (NewServerCounter).ToString();
                }

                tbServername.SelectAll();
            }
            else
            {
                tbServername.SelectionStart = tbServername.Text.Length;
            }

            //if (se != null)
            //{
            //    if (!string.IsNullOrEmpty(se.ServerName))
            //    {
            //        this.Text = "Edit Server - " + se.ServerName;
            //        tbServername.Text = se.ServerName;
            //    }
            //}
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ServerList == null)
            {
                ServerList = new List<ServerEntry>();
            }

            // Name filled check
            if (string.IsNullOrEmpty(tbServername.Text))
            {
                MessageBox.Show("Please enter a Servername!");
                return;
            }

            // Name exists check
            if (ServerList.Count > 0)
            {
                if (ServerList.Any(item => item.ServerName == tbServername.Text))
                {
                    MessageBox.Show("Server with this name does already exists!");
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
            this.DialogResult = DialogResult.OK;


            // Update Lastserver & Label if needed

            // check if same as in form to update statuslabel when server is same as in mainform inputs & set the last server to the new one after successful add
            if (tbIP.Text == mainForm.tbIP.Text && tbPort.Value == mainForm.tbPort.Value && tbPassword.Text == mainForm.tbPw.Text && mainForm.lastServer.ServerName == "LastServerEntry")
            {
                // change last server to just saved one
                mainForm.lastServer = new ServerEntry(tbServername.Text, tbIP.Text, Convert.ToInt32(tbPort.Value), tbPassword.Text);
                // Handle update label
                mainForm.DataChanged(null, null);
                // save new as last server
                Properties.Settings.Default.LastServer = JsonConvert.SerializeObject(mainForm.lastServer);
                Properties.Settings.Default.Save();
            }
            else
            {

            }

            //////////////////////////////////////


            this.Close();

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            tbIP.Text = mainForm.tbIP.Text;
            tbPort.Value = mainForm.tbPort.Value;
            tbPassword.Text = mainForm.tbPw.Text;

            tbServername.Focus();
            this.ActiveControl = tbServername;
            if (string.IsNullOrEmpty(tbServername.Text))
            {
                // ===================
                //var newServerEntries = 

                var tmpList = ServerList.Where(x => x.ServerName.Contains("New Server ")).Select(x => x.ServerName.Split(new string[] { "New Server " }, StringSplitOptions.None)).ToArray();
                //Console.WriteLine("COUNT: " + tmpList[0][1]);
                List<int> tmpIntList = new List<int>();
                //Console.WriteLine("========= tmpCount: " + tmpIntList.Count());
                foreach (var item in tmpList)
                {
                    if (Int32.TryParse(item[1], out int result) && item[1].Count() == 1)
                    {
                        if (true)
                        {
                            if (result > 0)
                            {
                                tmpIntList.Add(result);
                                //Console.WriteLine(result);
                            }
                        }
                    }
                }
                //Array.Sort(tmpIntArray);
                //Console.WriteLine("=========" + tmpIntList.Count());
                //foreach (int item in tmpIntList)
                //{
                //    Console.WriteLine(item.ToString());
                //}

                int NewServerCounter = getSmallestAvailable(tmpIntList.ToArray(), 1);

                // ===================

                if (NewServerCounter <= 0)
                {
                    tbServername.Text = string.Empty;
                }
                else
                {
                    tbServername.Text = "New Server " + (NewServerCounter).ToString();
                }

                tbServername.SelectAll();
            }
            else
            {
                tbServername.SelectionStart = tbServername.Text.Length;
            }
        }

        private static int getSmallestAvailable(int[] ToStartWith, int ToTryWith)
        {
            if (ToTryWith > 10000)
            {
                return 0;
            }
            if (!ToStartWith.Contains(ToTryWith)) // we're good
            {
                return ToTryWith;
            }
            else
            {
                return getSmallestAvailable(ToStartWith, ToTryWith + 1);

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
    }
}
