using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mordhau_RCON
{
    public partial class FrmTimestampSettings : Form
    {
        MainForm mainForm;
        public FrmTimestampSettings(MainForm mainForm)
        {
            InitializeComponent();
            
            this.mainForm = mainForm;

            this.checkBox1.Checked = mainForm.enableTimestamps;
            this.textBox1.Text = mainForm.timestampFormat;

            formatTestLabel.Text = "Test: " + DateTime.Now.ToString(mainForm.timestampFormat);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.c-sharpcorner.com/blogs/date-and-time-format-in-c-sharp-programming1");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //invisible test. no idea if thats even needed for ToString()
            try
            {
                Console.WriteLine(DateTime.Now.ToString(textBox1.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Format!");
                return;
            }

            mainForm.enableTimestamps = checkBox1.Checked;
            mainForm.timestampFormat = textBox1.Text;
            Properties.Settings.Default.TimestampsEnabled = checkBox1.Checked;
            Properties.Settings.Default.TimestampFormat = textBox1.Text;

            Properties.Settings.Default.Save();

            MessageBox.Show("Saved!");
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            textBox1.Text = "[" + CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern + " " + CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern + "]";
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                formatTestLabel.Text = "Test: " + DateTime.Now.ToString(textBox1.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Invalid Format!");
            }
        }
    }
}
