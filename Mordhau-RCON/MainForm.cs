using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Mordhau_RCON
{
    public partial class MainForm : Form
    {
        public List<ServerEntry> servers;
        public List<VersionEntry> missedVersions;
        public ServerEntry lastServer;

        bool fullyLoaded = false;
        
        System.Timers.Timer timerAlive = new System.Timers.Timer(Properties.Settings.Default.AliveFreqSec * 1000);



        public Color colorConnecting = Color.DarkOrange;
        public Color colorConSuc = Color.GreenYellow;
        public Color colorErrors = Color.Red;
        public Color colorCommands = Color.White;
        public Color colorOutput = Color.Yellow;

        public Color colorConsole = Color.FromArgb(64, 64, 64);

        public double opacity = 0.95;

        public MainForm()
        {
            InitializeComponent();
            timerAlive.Elapsed += new System.Timers.ElapsedEventHandler(timerElapsed);
            //timerAlive.Enabled = true;

            //timerAlive.Stop();
            // Upgrade settings from last version
            if (Properties.Settings.Default.UpgradeRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeRequired = false;
                Properties.Settings.Default.Save();
            }


            keepAliveItem = customMenuItem;
            keepAliveItem.MouseEnter += Menu_MouseEnter;
            keepAliveItem.MouseLeave += Menu_MouseLeave;
            keepAliveItem.MouseMove += MenuMouseMove;

            colorConnecting = JsonConvert.DeserializeObject<Color>(Properties.Settings.Default.ColorConnecting);
            colorConSuc = JsonConvert.DeserializeObject<Color>(Properties.Settings.Default.ColorConSuc);
            colorErrors = JsonConvert.DeserializeObject<Color>(Properties.Settings.Default.ColorErrors);
            colorCommands = JsonConvert.DeserializeObject<Color>(Properties.Settings.Default.ColorCommands);
            colorOutput = JsonConvert.DeserializeObject<Color>(Properties.Settings.Default.ColorOutput);

            colorConsole = JsonConvert.DeserializeObject<Color>(Properties.Settings.Default.ColorConsole);

            opacity = Double.Parse(Properties.Settings.Default.Opacity.ToString());

            tbConsole.BackColor = colorConsole;

            
        }

        private void timerElapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("DO ALIVE");
            if (Sr != null && Sr.Connected)
            {
                Sr.ServerCommand("alive");
            }
        }

        public SourceRcon Sr = new SourceRcon();
        RichTextBox console;
        TableLayoutPanel keepAliveItem;

        public enum RunningOS
        {
            Windows,
            Unix,
            Invalid
        }

        public RunningOS OS = RunningOS.Invalid;
        //RTFScrolledBottom newConsole = new RTFScrolledBottom();
        private void Form1_Load(object sender, EventArgs e)
        {

            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);

            AutoCompleteStringCollection sc = new AutoCompleteStringCollection();
            string[] cmds = JsonConvert.DeserializeObject<string[]>(Properties.Settings.Default.AutocompleteList);
            sc.AddRange(cmds);
            tbInput.AutoCompleteCustomSource = sc;

            lastCommands = JsonConvert.DeserializeObject<List<string>>(Properties.Settings.Default.LastCommands);
            if (lastCommands == null)
            {
                lastCommands = new List<string>();
            }

            //Console.WriteLine(opacity);
            this.Opacity = opacity;
            console = tbConsole;


            OperatingSystem os = Environment.OSVersion;
            PlatformID pid = os.Platform;
            switch (pid)
            {
                case PlatformID.Win32NT:
                case PlatformID.Win32S:
                case PlatformID.Win32Windows:
                case PlatformID.WinCE:
                    OS = RunningOS.Windows;
                    break;
                case PlatformID.Unix:
                    OS = RunningOS.Unix;
                    break;
                default:
                    OS = RunningOS.Invalid;
                    break;
            }


            this.ActiveControl = tbInput;

            toolStripMenuItemSettings.MouseEnter += new EventHandler(Menu_MouseEnter);
            toolStripMenuItemSettings.MouseLeave += new EventHandler(Menu_MouseLeave);



            ToolStripControlHost tsHost = new ToolStripControlHost(keepAliveItem);

            toolStripMenuItemSettings.DropDownItems.Insert(toolStripMenuItemSettings.DropDownItems.Count - 1, tsHost);
            //toolStripMenuItemSettings.DropDownItems.Insert(toolStripMenuItemSettings.DropDownItems.Count - 1, new ToolStripSeparator());



            toolStripMenuItemSettings.DropDown.AutoSize = true;
            int fullheight = 0;
            foreach (var item in toolStripMenuItemSettings.DropDownItems)
            {
                ToolStripDropDownItem x = item as ToolStripDropDownItem;
                if (x != null)
                {
                    fullheight += x.Height;
                }
            }
            fullheight += keepAliveItem.Height;

            toolStripMenuItemSettings.DropDown.MinimumSize = new Size(toolStripMenuItemSettings.DropDown.Width, toolStripMenuItemSettings.Height + fullheight);
            toolStripMenuItemSettings.DropDown.Size = new Size(toolStripMenuItemSettings.DropDown.Width, toolStripMenuItemSettings.Height + fullheight);
            //toolStripMenuItemSettings.DropDown.Closing += DropDown_Closing;



            keepAliveToolStripMenuItem.Checked = Properties.Settings.Default.KeepAlive;
            hideAliveCMDOutputToolStripMenuItem.Checked = Properties.Settings.Default.SuppressAlive;
            
            numUpDownAlive.Value = Properties.Settings.Default.AliveFreqSec;
            timerAlive.Interval = Properties.Settings.Default.AliveFreqSec * 1000;
            numUpDownAlive.LostFocus += NumUpDownAlive_LostFocus;

            lastServer = JsonConvert.DeserializeObject<ServerEntry>(Properties.Settings.Default.LastServer);
            // Decrypt for use in app - only crypt when saving in props
            lastServer.Password = lastServer.Password;



            servers = new List<ServerEntry>();

            servers = JsonConvert.DeserializeObject<List<ServerEntry>>(Properties.Settings.Default.Servers);

            if (lastServer.ServerName == "LastServerEntry")
            {
                StatusLabel.Text = "Server: Unsaved Server";
            }
            else
            {
                StatusLabel.Text = "Server: " + lastServer.ServerName;

            }

            //Console.WriteLine(JsonConvert.DeserializeObject(Properties.Settings.Default.LastServer));
            if (lastServer != null && lastServer.ServerName == "LastServerEntry" && lastServer.IP == "INVALID")
            {
                IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
                foreach (IPAddress addr in localIPs)
                {
                    if (addr.AddressFamily == AddressFamily.InterNetwork)
                    {
                        if (addr.ToString().StartsWith("192."))
                        {
                            lastServer.IP = addr.ToString();
                            break;
                        }
                    }
                }

            }

            //StatusLabel.Text = lastServer.ServerName;
            tbIP.Text = lastServer.IP;
            tbPort.Value = lastServer.Port;
            //tbPw.Text = XCRYPT.DecryptString(lastServer.Password);
            tbPw.Text = lastServer.Password;

            this.ActiveControl = btnConnect;
            btnConnect.Focus();

            

            this.Show();
            missedVersions = getMissedVersions();
            if (missedVersions != null && missedVersions.Count > 0)
            {
                using (var updateForm = new Update(this))
                {
                    updateForm.ShowDialog();
                    updateAvailableToolStripMenuItem.Visible = true;
                    checkUpdateTimer.Start();
                }
            }
            fullyLoaded = true;
        }

        private void OnProcessExit(object sender, EventArgs e)
        {
            if (lastCommands != null)
            {
                Properties.Settings.Default.LastCommands = JsonConvert.SerializeObject(lastCommands);
                Properties.Settings.Default.Save();
            }
        }


        private void NumUpDownAlive_LostFocus(object sender, EventArgs e)
        {
            Properties.Settings.Default.AliveFreqSec = Convert.ToInt32(numUpDownAlive.Value);
        }



        bool informedAboutEmptyCmdAlready = false;
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbInput.Text))
            {
                if (!informedAboutEmptyCmdAlready)
                {
                    tbConsole.AppendText("Cannot send empty command!" + Environment.NewLine, colorConnecting);
                    informedAboutEmptyCmdAlready = true;
                }
                return;
            }
            if (Sr.Connected)
            {
                Sr.ServerCommand(tbInput.Text);
                tbInput.Text = string.Empty;
                this.ActiveControl = tbInput;

                informedAboutEmptyCmdAlready = false;

                lastCommand = -1;
            }
        }


        string ip = string.Empty;
        int port = 0;
        string password = string.Empty;


        private async Task ConnectAsync(string ip, int port, string password)
        {
            
            await Task.Run(() =>
            {

                console.BeginInvoke((MethodInvoker)delegate ()
                {
                    tbConsole.AppendText("Connecting..." + Environment.NewLine, colorConnecting);

                    StatusDot.ForeColor = Color.Orange;
                    //StatusDot.Invalidate();

                    if (lastServer.IP == tbIP.Text && lastServer.Port == Convert.ToInt32(tbPort.Value) && lastServer.Password == tbPw.Text) // it's last server
                    {
                        if (lastServer.ServerName != "LastServerEntry")
                        {
                            StatusLabel.Text = $"Connecting to {lastServer.ServerName} | {tbIP.Text}:{Convert.ToInt32(tbPort.Value)}";
                        }
                        else
                        {
                            //Console.WriteLine("ELSE");
                        }
                    }
                    else // not last server
                    {
                        StatusLabel.Text = $"Connecting to {tbIP.Text}:{Convert.ToInt32(tbPort.Value)}";
                    }
                });


                if (Sr.Connect(new IPEndPoint(IPAddress.Parse(ip), port), password))
                {
                    //tbConsole.Text += "Connecting..." + Environment.NewLine;


                    //TT.Start();

                    while (!Sr.Connected)
                    {

                        Thread.Sleep(10);
                    }


                    if (Sr.Connected)
                    {

                        //tbConsole.AppendText("Connected!" + Environment.NewLine, Color.LimeGreen);
                        //tbConsole.Text += "Connected!" + Environment.NewLine;                    

                    }
                }
                else
                {
                    console.BeginInvoke((MethodInvoker)delegate ()
                    {
                        btnConnect.Text = "Connect";
                        btnConnect.Enabled = true;
                    });
                }
            });
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
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


            Match match = Regex.Match(tbIP.Text, @"((^\s*((([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5]))\s*$)|(^\s*((([0-9A-Fa-f]{1,4}:){7}([0-9A-Fa-f]{1,4}|:))|(([0-9A-Fa-f]{1,4}:){6}(:[0-9A-Fa-f]{1,4}|((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3})|:))|(([0-9A-Fa-f]{1,4}:){5}(((:[0-9A-Fa-f]{1,4}){1,2})|:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3})|:))|(([0-9A-Fa-f]{1,4}:){4}(((:[0-9A-Fa-f]{1,4}){1,3})|((:[0-9A-Fa-f]{1,4})?:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){3}(((:[0-9A-Fa-f]{1,4}){1,4})|((:[0-9A-Fa-f]{1,4}){0,2}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){2}(((:[0-9A-Fa-f]{1,4}){1,5})|((:[0-9A-Fa-f]{1,4}){0,3}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){1}(((:[0-9A-Fa-f]{1,4}){1,6})|((:[0-9A-Fa-f]{1,4}){0,4}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(:(((:[0-9A-Fa-f]{1,4}){1,7})|((:[0-9A-Fa-f]{1,4}){0,5}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:)))(%.+)?\s*$))");
            if (tbIP.Text.StartsWith("0.") || !match.Success)
            {
                MessageBox.Show("Invalid IP");
                return;
            }

            if (btnConnect.Text == "Connect")
            {
                tbIP.Enabled = false;
                tbPort.Enabled = false;
                tbPw.Enabled = false;
                //btnConnect.Enabled = false;
                btnConnect.Text = "Connecting";
                btnConnect.Enabled = false;
                btnConnect.Invalidate();
                btnConnect.Refresh();



                Thread.Sleep(100);

                ip = tbIP.Text;
                port = Convert.ToInt32(tbPort.Value);
                password = tbPw.Text;

                Sr = new SourceRcon();
                Sr.Errors += new StringOutput(ErrorOutput);
                Sr.ServerOutput += new StringOutput(ConsoleOutput);
                Sr.CommandOutput += new StringOutput(CommandOutput);
                Sr.SuccessOutput += new StringOutput(SuccessOutput);
                Sr.Disconnect += new StringOutput(Disconnected);
                Sr.ConnectionSuccess += Sr_ConnectionSuccess;

                var connectTask = ConnectAsync(ip, port, password);




            }
            else if (btnConnect.Text == "Disconnect")
            {
                Sr.S.Close(); // weird way, had to edit lib, add an event called on exception when accessing disposed socket
                tbInput.Text = string.Empty;


                StatusDot.ForeColor = Color.Red;
                timerAlive.Stop();

                if (lastServer.IP == tbIP.Text && lastServer.Port == Convert.ToInt32(tbPort.Value) && lastServer.Password == tbPw.Text) // it's last server
                {
                    if (lastServer.ServerName != "LastServerEntry")
                    {
                        StatusLabel.Text = "Server: " + lastServer.ServerName;
                    }
                    else
                    {
                        //Console.WriteLine("ELSE");
                    }

                }
                else // not last server
                {
                    StatusLabel.Text = "Server: Unsaved Server";
                }
            }
        }

        private void Sr_ConnectionSuccess(bool info)
        {
            if (info)
            {
                console.BeginInvoke((MethodInvoker)delegate ()
                {
                    tbIP.Enabled = false;
                    tbPort.Enabled = false;
                    tbPw.Enabled = false;
                    //btnConnect.Enabled = false;
                    btnConnect.Text = "Disconnect";
                    btnConnect.Enabled = true;

                    tbInput.Enabled = true;
                    btnSend.Enabled = true;

                    //tbIP.BackColor = Color.Orange;
                    //tbPort.BackColor = Color.Orange;
                    //tbPw.BackColor = Color.Orange;
                    //btnConnect.BackColor = Color.Orange;

                    //tbInput.BackColor = Color.DarkGray;
                    //btnSend.BackColor = Color.Gray;

                    tbConsole.AppendText(SourceRcon.ConnectionSuccessString + Environment.NewLine, colorConSuc);


                    tbInput.Focus();
                    this.ActiveControl = tbInput;

                    StatusDot.ForeColor = Color.Green;

                    //StatusDot.Invalidate();

                    if (lastServer.IP == tbIP.Text && lastServer.Port == Convert.ToInt32(tbPort.Value) && lastServer.Password == tbPw.Text) // it's last server
                    {
                        if (lastServer.ServerName != "LastServerEntry")
                        {
                            StatusLabel.Text = "Connected to " + lastServer.ServerName;
                            ServerEntry tmpServerEntry = new ServerEntry(lastServer.ServerName, tbIP.Text, Convert.ToInt32(tbPort.Value), tbPw.Text);
                            Properties.Settings.Default.LastServer = JsonConvert.SerializeObject(tmpServerEntry);
                        }
                        else
                        {
                            //Console.WriteLine("ELSE");
                        }
                    }
                    else // not last server
                    {
                        // Connected successfully to a server. Save it as lastserver "without name"
                        StatusLabel.Text = $"Connected to {tbIP.Text}:{Convert.ToInt32(tbPort.Value)}";
                        ServerEntry tmpServerEntry = new ServerEntry("LastServerEntry", tbIP.Text, Convert.ToInt32(tbPort.Value), tbPw.Text);
                        Properties.Settings.Default.LastServer = JsonConvert.SerializeObject(tmpServerEntry);
                    }

                    Properties.Settings.Default.Save();
                });

                Sr.ServerCommand("alive"); // initial alive
                if (Sr != null && Sr.Connected && Properties.Settings.Default.KeepAlive)
                {
                    timerAlive.Start();
                }
            }
            else
            {
                console.BeginInvoke((MethodInvoker)delegate ()
                {
                    btnConnect.Enabled = true;
                });
            }
        }

        private void Disconnected(string output)
        {
            console.BeginInvoke((MethodInvoker)delegate ()
            {
                tbIP.Enabled = true;
                tbPort.Enabled = true;
                tbPw.Enabled = true;
                btnConnect.Enabled = true;
                btnConnect.Text = "Connect";

                tbInput.Enabled = false;
                btnSend.Enabled = false;

                StatusDot.ForeColor = Color.Red;
                tbConsole.AppendText(output + Environment.NewLine, colorConnecting);
                timerAlive.Stop();
                //newConsole.Text += Environment.NewLine + "Command: " + output + Environment.NewLine + Environment.NewLine;
            });
        }

        private void SuccessOutput(string output)
        {
            //if (output == SourceRcon.ConnectionSuccessString)
            //{
            //    console.BeginInvoke((MethodInvoker)delegate ()
            //    {
            //        tbConsole.AppendText(output + Environment.NewLine, colorConSuc);
            //    });
            //    caretHidden = false;
            //}
            //else
            //{
            //    btnConnect.Enabled = true;
            //}
        }

        List<string> lastCommands = new List<string>();
        private void CommandOutput(string output)
        {
            if (Properties.Settings.Default.SuppressAlive && output == "alive")
            {
                return;
            }

            if (lastCommands == null)
            {
                lastCommands = new List<string>();
            }

            if (lastCommands.Contains(output))
            {
                lastCommands.Remove(output);
            }
            if (lastCommands.Count < 50)
            {
                lastCommands.Add(output);
            }
            else
            {
                lastCommands.RemoveAt(0);
                lastCommands.Add(output);
            }


            console.BeginInvoke((MethodInvoker)delegate ()
            {
                tbConsole.AppendText(Environment.NewLine + "Command: " + output + Environment.NewLine + Environment.NewLine, colorCommands);
                //tbConsole.Text += Environment.NewLine + "Command: " + output + Environment.NewLine + Environment.NewLine;
            });
        }
        private void ConsoleOutput(string output)
        {
            if (Properties.Settings.Default.SuppressAlive && output.StartsWith("Keeping client alive for another "))
            {
                return;
            }

            console.BeginInvoke((MethodInvoker)delegate ()
            {
                string tmpOutput = output.Replace("\n", Environment.NewLine);
                string feed = "Console: ";

                if (tmpOutput.StartsWith("Chat: ") ||
                    tmpOutput.StartsWith("Login: ") ||
                    tmpOutput.StartsWith("MatchState: ") ||
                    tmpOutput.StartsWith("Killfeed: ") ||
                    tmpOutput.StartsWith("Scorefeed: ") ||
                    tmpOutput.StartsWith("Custom: ") ||
                    tmpOutput.StartsWith("Punishment: ")
                    )
                {
                    feed = string.Empty;
                }

                if (tmpOutput.Length >= 2 && tmpOutput.Substring(tmpOutput.Length - 2) == Environment.NewLine)
                {
                    tmpOutput = tmpOutput.Substring(0, tmpOutput.Length - 2);
                }
                if (tmpOutput.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).Length > 1)
                {
                    if (string.IsNullOrEmpty(feed))
                    {
                        tbConsole.AppendText(tmpOutput + Environment.NewLine, colorOutput);
                    }
                    else
                    {
                        tbConsole.AppendText(feed + Environment.NewLine + tmpOutput + Environment.NewLine, colorOutput);
                    }
                    //tbConsole.Text += "Console: " + Environment.NewLine + tmpOutput + Environment.NewLine;
                }
                else
                {
                    tbConsole.AppendText(feed + tmpOutput + Environment.NewLine, colorOutput);
                    //tbConsole.Text += "Console: " + tmpOutput + Environment.NewLine;
                }
            });
        }
        
        private void ErrorOutput(string output)
        {
            console.BeginInvoke((MethodInvoker)delegate ()
            {
                if (output == SourceRcon.ConnectionClosed || output == SourceRcon.ConnectionFailedString || output == SourceRcon.WrongPassword || output == SourceRcon.ConnectionTimeout || output == SourceRcon.UnknownConnectionIssue)
                {
                    Sr.S.Close();
                    timerAlive.Stop();

                    StatusDot.ForeColor = Color.Red;
                    if (lastServer.IP == tbIP.Text && lastServer.Port == Convert.ToInt32(tbPort.Value) && lastServer.Password == tbPw.Text) // it's last server
                    {
                        if (lastServer.ServerName != "LastServerEntry")
                        {
                            StatusLabel.Text = "Server: " + lastServer.ServerName;
                        }
                        else
                        {
                            //Console.WriteLine("ELSE");
                        }

                    }
                    else // not last server
                    {
                        StatusLabel.Text = "Server: Unsaved Server";
                    }



                    tbIP.Enabled = true;
                    tbPort.Enabled = true;
                    tbPw.Enabled = true;
                    btnConnect.Enabled = true;
                    btnConnect.Text = "Connect";

                    tbInput.Enabled = false;
                    btnSend.Enabled = false;

                    tbInput.Text = string.Empty;

                    btnConnect.Focus();
                    this.ActiveControl = btnConnect;
                }

                // Own newline style
                string tmpOutput = output.Replace("\n", Environment.NewLine);
                if (tmpOutput.Length >= 2 && tmpOutput.Substring(tmpOutput.Length - 2) == Environment.NewLine)
                {
                    tmpOutput = tmpOutput.Substring(0, tmpOutput.Length - 2);
                }

                if (tmpOutput.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).Length > 1)
                {
                    tbConsole.AppendText("Error: " + Environment.NewLine + tmpOutput + Environment.NewLine, Color.Red);
                    //tbConsole.Text += "Error: " + Environment.NewLine + tmpOutput + Environment.NewLine;
                }
                else
                {
                    tbConsole.AppendText("Error: " + tmpOutput + Environment.NewLine, colorErrors);
                    //newConsole.Text += "Error: " + tmpOutput + Environment.NewLine;
                }
            });
        }

        private void tbConsole_TextChanged(object sender, EventArgs e)
        {
            RichTextBox tb = (RichTextBox)sender;

            tb.SelectionStart = tb.Text.Length;

            if (checkBoxAutoscroll.Checked)
            {
                tb.ScrollToCaret();
            }
            if (tbConsole.Focused)
            {
                this.ActiveControl = tbInput;
            }
        }


        private void tbInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //e.SuppressKeyPress = true;
                if (tbInput.AutoCompleteCustomSource.Contains(tbInput.Text))
                {
                    tbInput.SelectionStart = tbInput.Text.Length;
                    return;
                }

 

                //e.SuppressKeyPress = true;
                //if (tbInput.AutoCompleteCustomSource.Contains(tbInput.Text) && tbInput.Text.EndsWith(" "))
                //{

                //    tbInput.SelectionStart = tbInput.Text.Length;
                //    return;
                //}
                //btnSend_Click(sender, null);
            }
        }


        
        private void tbInput_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //e.SuppressKeyPress = true;
                //if (tbInput.AutoCompleteCustomSource.Contains(tbInput.Text))
                //{
                //    suppressedSuggestion = true;
                //    tbInput.SelectionStart = tbInput.Text.Length;
                //    return;
                //}

                //if (tbInput.AutoCompleteCustomSource.Contains(tbInput.Text) && tbInput.SelectionLength > 0 && tbInput.SelectedText.EndsWith(" "))
                if (tbInput.AutoCompleteCustomSource.Contains(tbInput.Text) && tbInput.SelectionLength > 0)
                {
                    tbInput.SelectionStart = tbInput.Text.Length;
                    return;
                }
                
                btnSend_Click(sender, null);

                //e.SuppressKeyPress = true;
                //if (tbInput.AutoCompleteCustomSource.Contains(tbInput.Text) && tbInput.Text.EndsWith(" "))
                //{

                //    tbInput.SelectionStart = tbInput.Text.Length;
                //    return;
                //}
                //btnSend_Click(sender, null);
            }
        }


        int lastCommand = -1;
        private void tbInput_KeyDown(object sender, KeyEventArgs e)
        {

            if ((e.KeyCode == Keys.Up || e.KeyCode == Keys.Down))
            {
                if (lastCommands == null)
                {
                    lastCommands = new List<string>();
                }

                if (lastCommands.Count > 0)
                {
                    if (lastCommand == -1)
                    {
                        if (e.KeyCode == Keys.Up)
                        {
                            lastCommand = lastCommands.Count - 1;
                        }
                        if (e.KeyCode == Keys.Down)
                        {
                            lastCommand = 0;
                        }
                    }
                    if (lastCommand < 0)
                    {
                        lastCommand = lastCommands.Count - 1;
                    }
                    if (lastCommand > lastCommands.Count - 1)
                    {
                        lastCommand = 0;
                    }
                }
            }
            if (e.KeyCode == Keys.Down && lastCommands.Count > 0)
            {
                //if (lastCommand == 0)
                //{
                //    lastCommand = lastCommands.Count - 1;
                //}

                e.SuppressKeyPress = true;

                //Console.WriteLine(lastCommand);
                tbInput.Text = lastCommands[lastCommand];
                tbInput.SelectionStart = tbInput.Text.Length;
                lastCommand++;

            }

            if (e.KeyCode == Keys.Up && lastCommands.Count > 0)
            {


                e.SuppressKeyPress = true;

                //Console.WriteLine(lastCommand);
                tbInput.Text = lastCommands[lastCommand];
                tbInput.SelectionStart = tbInput.Text.Length;
                lastCommand--;

            }


            //if (e.KeyCode == Keys.Down)
            //{
            //    e.SuppressKeyPress = true;

            //    Console.WriteLine(lastCommand);
            //    tbInput.Text = lastCommands[lastCommand - 1];
            //    tbInput.SelectionStart = tbInput.Text.Length;

            //    lastCommand++;
            //}

            //if (lastCommand >= lastCommands.Count - 1)
            //{
            //    lastCommand = 0;
            //}
            //if (lastCommand <= 0)
            //{
            //    lastCommand = lastCommands.Count - 1;
            //}

            if (e.Control && e.KeyCode == Keys.A)
            {
                e.SuppressKeyPress = true;
                tbInput.SelectAll();
            }

            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (tbInput.AutoCompleteCustomSource.Contains(tbInput.Text))
            //    {
            //        suppressedSuggestion = true;
            //        tbInput.SelectionStart = tbInput.Text.Length;
            //        return;
            //    }
            //}

        }

        private void Settings_Click(object sender, EventArgs e)
        {

        }

        private void Menu_MouseEnter(object sender, EventArgs e)
        {
            //this.Focus();
            this.Cursor = Cursors.Hand;
        }
        private void SubMenu_MouseEnter(object sender, EventArgs e)
        {
            //this.Focus();
            this.Cursor = Cursors.Hand;
        }

        private void Menu_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void MenuMouseMove(object sender, MouseEventArgs e) // only for subitems
        {
            this.Cursor = Cursors.Hand;
        }

        private void serversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            servers = JsonConvert.DeserializeObject<List<ServerEntry>>(Properties.Settings.Default.Servers);

            using (var serversForm = new Servers(this))
            {
                serversForm.StartPosition = FormStartPosition.CenterParent;
                var result = serversForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (Sr.Connected)
                    {
                        Sr.S.Close();
                    }
                    tbIP.Text = serversForm.selectedServer.IP;
                    tbPort.Value = serversForm.selectedServer.Port;
                    tbPw.Text = serversForm.selectedServer.Password;

                    lastServer = new ServerEntry(serversForm.selectedServer.ServerName, serversForm.selectedServer.IP, serversForm.selectedServer.Port, serversForm.selectedServer.Password);

                    Properties.Settings.Default.LastServer = JsonConvert.SerializeObject(lastServer);
                    Properties.Settings.Default.Save();


                    if (lastServer.ServerName == "LastServerEntry")
                    {
                        StatusLabel.Text = "Server: Unsaved Server";
                    }
                    else
                    {
                        StatusLabel.Text = "Server: " + lastServer.ServerName;

                    }

                    btnConnect.Focus();
                    this.ActiveControl = btnConnect;
                }
                if (result == DialogResult.Cancel)
                {

                }
            }
        }

        private void toolStripMenuItemShowPw_CheckStateChanged(object sender, EventArgs e)
        {
            if (fullyLoaded)
            {
                toolStripMenuItemSettings.ShowDropDown();
            }
            if (toolStripMenuItemShowPw.Checked)
            {
                tbPw.PasswordChar = '\0';
                tbPw.UseSystemPasswordChar = false;
            }
            else
            {
                tbPw.PasswordChar = '*';
                tbPw.UseSystemPasswordChar = true;
            }
        }


        private void keepAliveToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (fullyLoaded)
            {
                toolStripMenuItemSettings.ShowDropDown();
            }

            Properties.Settings.Default.KeepAlive = keepAliveToolStripMenuItem.Checked;

            if (Properties.Settings.Default.KeepAlive)
            {
                if (Sr != null && Sr.Connected)
                {
                    timerAlive.Start();
                }
            }
            else
            {
                timerAlive.Stop();
            }
            //Properties.Settings.Default.Save();
        }

        private void numUpDownAlive_Click(object sender, EventArgs e)
        {
            //this.ActiveControl = numUpDownAlive;
            numUpDownAlive.Focus();
            numUpDownAlive.Select(0, numUpDownAlive.Text.Length);
        }

        private static TextBox GetPrivateField(NumericUpDown ctrl)
        {
            // find internal TextBox
            System.Reflection.FieldInfo textFieldInfo = typeof(NumericUpDown).GetField("upDownEdit", System.Reflection.BindingFlags.FlattenHierarchy | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            // take some caution... they could change field name
            // in the future!
            if (textFieldInfo == null)
            {
                return null;
            }
            else
            {
                return textFieldInfo.GetValue(ctrl) as TextBox;
            }
        }

        private void customMenuItem_Click(object sender, EventArgs e)
        {
            //this.ActiveControl = numUpDownAlive;
            numUpDownAlive.Focus();
            numUpDownAlive.Select(0, numUpDownAlive.Text.Length);
        }

        public void DataChanged(object sender, EventArgs e)
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

            if (lastServer.IP == tbIP.Text && lastServer.Port == Convert.ToInt32(tbPort.Value) && lastServer.Password == tbPw.Text) // it's last server
            {
                
                if (lastServer.ServerName != "LastServerEntry")
                {
                    if (StatusLabel.Text.StartsWith("Server: "))
                    {
                        StatusLabel.Text = "Server: " + lastServer.ServerName;
                    }
                    else if (StatusLabel.Text.StartsWith("Connecting to "))
                    {
                        StatusLabel.Text = "Connecting to " + lastServer.ServerName;
                    }
                    else if (StatusLabel.Text.StartsWith("Connected to "))
                    {
                        StatusLabel.Text = "Connected to " + lastServer.ServerName;
                    }
                }
                else
                {
                    //Console.WriteLine("ELSE");
                }

            }
            else // not last server
            {
                if (StatusLabel.Text.StartsWith("Server: "))
                {
                    StatusLabel.Text = "Server: Unsaved Server";
                }
                else if (StatusLabel.Text.StartsWith("Connecting to "))
                {
                    StatusLabel.Text = "Connecting to " + tbIP.Text + ":" + tbPort.Value.ToString();
                }
                else if (StatusLabel.Text.StartsWith("Connected to "))
                {
                    StatusLabel.Text = "Connected to " + tbIP.Text + ":" + tbPort.Value.ToString();
                }

            }
        }

        private void toolStripMenuItemAutoscroll_CheckStateChanged(object sender, EventArgs e)
        {
            

        }

        private void debugTimer_Tick(object sender, EventArgs e)
        {
            //Console.WriteLine(console.GetPositionFromCharIndex(console.TextLength).Y);

            //Console.WriteLine(console.GetPositionFromCharIndex(0).Y);
            //Console.WriteLine(console.AutoScrollOffset);
        }

        private void colorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FrmColors colorsForm = new FrmColors(this))
            {
                
                var result = colorsForm.ShowDialog();
                //Console.WriteLine(result);
                if (result == DialogResult.OK)
                {

                }
                else if (result == DialogResult.Cancel)
                {
                    colorConsole = JsonConvert.DeserializeObject<Color>(Properties.Settings.Default.ColorConsole);

                    tbConsole.BackColor = colorConsole;

                    opacity = (double)(Properties.Settings.Default.Opacity);
                    this.Opacity = opacity;
                }
            }
        }

        private void checkBoxAutoscroll_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                console.ScrollToCaret();
            }
        }

        protected override bool ProcessTabKey(bool forward)
        {
            Control ctl = this.ActiveControl;
            if (ctl != null && ctl == tbInput && !string.IsNullOrEmpty(tbInput.Text))
            {
                TextBox tb = (TextBox)ctl;
                tb.Focus();
                tb.SelectionStart = tb.Text.Length;
                return true;
            }
            return base.ProcessTabKey(forward); // process TAB key as normal
        }

        private void tbInput_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void tbInput_TextChanged(object sender, EventArgs e)
        {
            //Console.WriteLine(tbInput.SelectionLength);
            //if (tbInput.AutoCompleteCustomSource.Contains(tbInput.Text))
            //{
            //    suppressedSuggestion = true;
            //}
        }

        private void deleteCommandHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lastCommands = null;
            Properties.Settings.Default.LastCommands = Properties.Settings.Default.Properties["LastCommands"].DefaultValue as string;
            Properties.Settings.Default.Save();
            MessageBox.Show("Command-History deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void autocompleteListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(var frmAutoComplete = new AutocompleteList(this))
            {
                var result = frmAutoComplete.ShowDialog();
            }
        }

        private void updateAvailableToolStripMenuItem_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("bla");
        }

        public static List<VersionEntry> getMissedVersions()
        {
            long timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
            String WaGiRequest(string url)
            {
                try
                {
                    //Console.WriteLine(url);
                    url += (String.IsNullOrEmpty(new Uri(url).Query) ? "?" : "&");
                    HttpWebRequest.DefaultCachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.Default);
                    HttpWebRequest webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
                    webRequest.Method = "GET";
                    webRequest.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
                    webRequest.UserAgent = "WaGi's Mordhau RCON Tool " + timestamp.ToString();
                    webRequest.ServicePoint.Expect100Continue = false;
                    HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                    //Console.WriteLine(response.StatusCode == HttpStatusCode.OK);

                    using (StreamReader responseReader = new StreamReader(response.GetResponseStream()))
                    {
                        return responseReader.ReadToEnd();
                    }
                }
                catch
                {
                    return String.Empty;
                }
            }

            Version curV = new Version(Application.ProductVersion);
            List<VersionEntry> deserializedVersions = new List<VersionEntry>();
            List<VersionEntry> missedVersions = new List<VersionEntry>();
            try
            {
                deserializedVersions = JsonConvert.DeserializeObject<List<VersionEntry>>(WaGiRequest("https://wagi-coding.github.io/mordhau-rcon-tool/versions.json?ts=" + timestamp.ToString())); // weird way of prevent reading cached static site. Won't use github API as it's pretty hard rate limited
                if (deserializedVersions == null || deserializedVersions.Count < 1)
                {
                    return null; //Kinda error to handle with null later somewhere, otherwise use missedVersions count
                }
                deserializedVersions.Reverse();

                foreach (var version in deserializedVersions)
                {
                    if (curV.CompareTo(new Version(deserializedVersions.First().Version)) >= 0)
                    {
                        //return;
                    }
                    if (curV.CompareTo(new Version(version.Version)) < 0)
                    {
                        missedVersions.Add(version);
                    }
                }
                return missedVersions; // if it's empty, there are no missed versions. Equal or higher(testing branch)
            }
            catch (Exception)
            {
                return null; // some request error?
            }
        }

        private void updateAvailableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            missedVersions = getMissedVersions();
            if (missedVersions != null && missedVersions.Count > 0)
            {
                using (var updateForm = new Update(this))
                {
                    this.Show();
                    updateForm.ShowDialog();
                    updateAvailableToolStripMenuItem.Visible = true;
                }
            }
        }

        private void hideAliveCMDOutputToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (fullyLoaded)
            {
                toolStripMenuItemSettings.ShowDropDown();
            }
            Properties.Settings.Default.SuppressAlive = hideAliveCMDOutputToolStripMenuItem.Checked;
        }

        private void numUpDownAlive_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AliveFreqSec = Convert.ToInt32(numUpDownAlive.Value);
            timerAlive.Interval = Properties.Settings.Default.AliveFreqSec * 1000;
        }

        private void numUpDownAlive_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                this.Focus();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Console.WriteLine(timerAlive.Enabled);
            //if (Sr.Connected)
            //{
            //    Sr.ServerCommand("alive");
            //}
        }

        private void checkUpdateTimer_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("CHECKING FOR UPDATE...");

            missedVersions = getMissedVersions();

            if (missedVersions != null && missedVersions.Count > 0)
            {
                updateAvailableToolStripMenuItem.Visible = true;
                Console.WriteLine("A new version is available!");
            }
            else
            {
                Console.WriteLine("You're using the newest version!");
            }

        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (InfoForm infoForm = new InfoForm())
            {
                infoForm.ShowDialog();
            }
        }
    }





    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            // limitation cutting

            int lineLimit = 5000;

            int textLines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None).Length;

            if (box.Lines.Length + textLines + 5 > lineLimit)
            {
                try
                {
                    box.Select(0, box.GetFirstCharIndexFromLine(textLines + 20));
                    box.SelectedText = string.Empty;

                }
                catch (Exception)
                {
                    box.Text = string.Empty; // if something weird happens like some huge response?! let's jsut delete whole console
                }


            }


            // Actual append
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }

    public class OldRendererTrash : ToolStripProfessionalRenderer
    {
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            if (e.Item.GetType() == typeof(ToolStripDropDownButton))
            {
                Rectangle r = e.ArrowRectangle;
                List<Point> points = new List<Point>();
                points.Add(new Point(r.Left - 2, r.Height / 2 - 3));
                points.Add(new Point(r.Right + 2, r.Height / 2 - 3));
                points.Add(new Point(r.Left + (r.Width / 2),
                                     r.Height / 2 + 3));
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillPolygon(Brushes.Black, points.ToArray());
            }
            else
            {
                base.OnRenderArrow(e);
            }
        }
    }
}
