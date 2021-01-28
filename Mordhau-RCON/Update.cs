using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mordhau_RCON
{
    public partial class Update : Form
    {

        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        MainForm mainform;
        public Update(MainForm mainform)
        {
            InitializeComponent();
            this.mainform = mainform;
            richTextBox1.BackColor = mainform.colorConsole;
            richTextBox1.ForeColor = mainform.colorCommands;
            richTextBox1.TabStop = false;

            mainform.checkUpdateTimer.Stop();
        }

        private void Update_Load(object sender, EventArgs e)
        {
            if (mainform.missedVersions.Count > 0)
            {
                lblCurrent.Text = "Current Version: " + Application.ProductVersion;
                lblNew.Text = "New Version: " + mainform.missedVersions.First().Version;

                foreach (var version in mainform.missedVersions)
                {
                    richTextBox1.Text += version.Version + ":\n\n"
                                                + (version.Header != null && !string.IsNullOrEmpty(version.Header) ? version.Header + "\n\n\t" : "\t")
                                                + (version.Fixes != null ? "Fixes:\n\n\t" + String.Join("\n\t", version.Fixes) : "")
                                                + (version.Additions != null ? "\n\n\n\n\tAdditions:\n\n\t" + String.Join("\n\t", version.Additions) + "\n\n" : "\n\n")
                                                + (version.Footer != null && !string.IsNullOrEmpty(version.Footer) ? version.Footer : string.Empty);

                    if (version != mainform.missedVersions.Last() && mainform.missedVersions.Count > 1)
                    {
                        richTextBox1.Text += "\n\n\n\n\n\n";
                    }
                }
                if (mainform.OS == MainForm.RunningOS.Windows)
                {
                    HideCaret(richTextBox1.Handle);
                }
            }
            else
            {
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (mainform.OS == MainForm.RunningOS.Windows)
            {
                HideCaret(richTextBox1.Handle);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            DialogResult openBrowserResult = MessageBox.Show("Click OK to open the Link in the Browser & closing the Programm!", "Open Browser?", MessageBoxButtons.OKCancel);

            if (openBrowserResult == DialogResult.OK)
            {
                System.Diagnostics.Process.Start("https://github.com/WaGi-Coding/mordhau-rcon-tool/releases/latest");
                Application.Exit();
            }
            else
            {
                return;
            }
        }
    }
}
