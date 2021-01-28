using Newtonsoft.Json;
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
    public partial class FrmColors : Form
    {
        public MainForm mainForm;
        public FrmColors(MainForm mainForm)
        {
            InitializeComponent();

            this.mainForm = mainForm;

            this.Opacity = mainForm.opacity;
            this.BackColor = mainForm.BackColor;
            trackBarOpacity.BackColor = mainForm.BackColor;
            trackBarOpacity.Value = (int)(mainForm.opacity * 100);


            panelConnecting.BackColor = mainForm.colorConnecting;
            panelConSuc.BackColor = mainForm.colorConSuc;
            panelErrors.BackColor = mainForm.colorErrors;
            panelCommands.BackColor = mainForm.colorCommands;
            panelOutput.BackColor = mainForm.colorOutput;
            panelConsole.BackColor = mainForm.colorConsole;
            panelConsole.BackColor = mainForm.tbConsole.BackColor;

            this.Opacity = mainForm.Opacity;
            trackBarOpacity.Value = (int)(mainForm.Opacity * 100.0);

            labelConnecting.ForeColor = panelConnecting.BackColor;
            labelConSuc.ForeColor = panelConSuc.BackColor;
            labelErrors.ForeColor = panelErrors.BackColor;
            labelCommands.ForeColor = panelCommands.BackColor;
            labelOutput.ForeColor = panelOutput.BackColor;

            labelConnectingConsole.ForeColor = panelConnecting.BackColor;
            labelConSucConsole.ForeColor = panelConSuc.BackColor;
            labelErrorsConsole.ForeColor = panelErrors.BackColor;
            labelCommandsConsole.ForeColor = panelCommands.BackColor;
            labelOutputConsole.ForeColor = panelOutput.BackColor;

            bgConnecting.BackColor = panelConsole.BackColor;
            bgConSuc.BackColor = panelConsole.BackColor;
            bgErrors.BackColor = panelConsole.BackColor;
            bgCommands.BackColor = panelConsole.BackColor;
            bgOutput.BackColor = panelConsole.BackColor;
            bgConsole.BackColor = panelConsole.BackColor;
        }

        private void FrmColors_Load(object sender, EventArgs e)
        {
            Console.WriteLine("================Bg Control Window===============");
            Console.WriteLine(this.BackColor.ToArgb());
            Console.WriteLine(Color.FromArgb(this.BackColor.ToArgb()));
            Console.WriteLine(JsonConvert.SerializeObject(Color.FromArgb(this.BackColor.ToArgb())));

            Console.WriteLine("================Connecting===============");
            Console.WriteLine(panelConnecting.BackColor.ToArgb());
            Console.WriteLine(Color.FromArgb(panelConnecting.BackColor.ToArgb()));
            Console.WriteLine(JsonConvert.SerializeObject(Color.FromArgb(panelConnecting.BackColor.ToArgb())));

            Console.WriteLine("===============ConSuc================");
            Console.WriteLine(panelConSuc.BackColor.ToArgb());
            Console.WriteLine(Color.FromArgb(panelConSuc.BackColor.ToArgb()));
            Console.WriteLine(JsonConvert.SerializeObject(Color.FromArgb(panelConSuc.BackColor.ToArgb())));

            Console.WriteLine("===============Errors================");
            Console.WriteLine(panelErrors.BackColor.ToArgb());
            Console.WriteLine(Color.FromArgb(panelErrors.BackColor.ToArgb()));
            Console.WriteLine(JsonConvert.SerializeObject(Color.FromArgb(panelErrors.BackColor.ToArgb())));

            Console.WriteLine("=============Commands==================");
            Console.WriteLine(panelCommands.BackColor.ToArgb());
            Console.WriteLine(Color.FromArgb(panelCommands.BackColor.ToArgb()));
            Console.WriteLine(JsonConvert.SerializeObject(Color.FromArgb(panelCommands.BackColor.ToArgb())));

            Console.WriteLine("==============Output=================");
            Console.WriteLine(panelOutput.BackColor.ToArgb());
            Console.WriteLine(Color.FromArgb(panelOutput.BackColor.ToArgb()));
            Console.WriteLine(JsonConvert.SerializeObject(Color.FromArgb(panelOutput.BackColor.ToArgb())));

            Console.WriteLine("================Console===============");
            Console.WriteLine(panelConsole.BackColor.ToArgb());
            Console.WriteLine(Color.FromArgb(panelConsole.BackColor.ToArgb()));
            Console.WriteLine(JsonConvert.SerializeObject(Color.FromArgb(panelConsole.BackColor.ToArgb())));

            Console.WriteLine(JsonConvert.SerializeObject(mainForm.lastServer));
        }

        private void trackBarOpacity_ValueChanged(object sender, EventArgs e)
        {
            labelPercentOpacity.Text = trackBarOpacity.Value.ToString() + "%";
            //Console.WriteLine(trackBarOpacity.Value / 100.00);
            this.Opacity = trackBarOpacity.Value / 100.00;
            mainForm.Opacity = trackBarOpacity.Value / 100.00;
            mainForm.opacity = mainForm.Opacity;
        }

        private void panelConnecting_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorPicker = new ColorDialog())
            {
                var result = colorPicker.ShowDialog();
                if (result == DialogResult.OK)
                {
                    (sender as Panel).BackColor = colorPicker.Color;
                    labelConnecting.ForeColor = colorPicker.Color;
                    labelConnectingConsole.ForeColor = colorPicker.Color;

                    mainForm.colorConnecting = panelConnecting.BackColor;
                    
                }
            }
        }

        private void panelConSuc_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorPicker = new ColorDialog())
            {
                var result = colorPicker.ShowDialog();
                if (result == DialogResult.OK)
                {
                    (sender as Panel).BackColor = colorPicker.Color;
                    labelConSuc.ForeColor = colorPicker.Color;
                    labelConSucConsole.ForeColor = colorPicker.Color;
                    mainForm.colorConSuc = panelConSuc.BackColor;
                    
                }
            }
        }

        private void panelErrors_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorPicker = new ColorDialog())
            {
                var result = colorPicker.ShowDialog();
                if (result == DialogResult.OK)
                {
                    (sender as Panel).BackColor = colorPicker.Color;
                    labelErrors.ForeColor = colorPicker.Color;
                    labelErrorsConsole.ForeColor = colorPicker.Color;
                    mainForm.colorErrors = panelErrors.BackColor;
                    
                }
            }
        }

        private void panelCommands_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorPicker = new ColorDialog())
            {
                var result = colorPicker.ShowDialog();
                if (result == DialogResult.OK)
                {
                    (sender as Panel).BackColor = colorPicker.Color;
                    labelCommands.ForeColor = colorPicker.Color;
                    labelCommandsConsole.ForeColor = colorPicker.Color;
                    mainForm.colorCommands = panelCommands.BackColor;
                    
                }
            }
        }

        private void panelOutput_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorPicker = new ColorDialog())
            {
                var result = colorPicker.ShowDialog();
                if (result == DialogResult.OK)
                {
                    (sender as Panel).BackColor = colorPicker.Color;
                    labelOutput.ForeColor = colorPicker.Color;
                    labelOutputConsole.ForeColor = colorPicker.Color;
                    mainForm.colorOutput = panelOutput.BackColor;
                    
                }
            }
        }

        private void panelConsole_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorPicker = new ColorDialog())
            {
                var result = colorPicker.ShowDialog();
                if (result == DialogResult.OK)
                {
                    (sender as Panel).BackColor = colorPicker.Color;
                    
                    bgConnecting.BackColor = colorPicker.Color;
                    bgConSuc.BackColor = colorPicker.Color;
                    bgErrors.BackColor = colorPicker.Color;
                    bgCommands.BackColor = colorPicker.Color;
                    bgOutput.BackColor = colorPicker.Color;
                    bgConsole.BackColor = colorPicker.Color;

                    mainForm.tbConsole.BackColor = colorPicker.Color;
                    mainForm.colorConsole = colorPicker.Color;
                }
            }
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you really want to load Application Defaults?", "Color-Settings | Load Defaults", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            else if (result == DialogResult.Yes)
            {
                panelConnecting.BackColor = JsonConvert.DeserializeObject<Color>(Properties.Settings.Default.Properties["ColorConnecting"].DefaultValue.ToString());
                labelConnecting.ForeColor = panelConnecting.BackColor;

                panelConSuc.BackColor = JsonConvert.DeserializeObject<Color>(Properties.Settings.Default.Properties["ColorConSuc"].DefaultValue.ToString());
                labelConSuc.ForeColor = panelConSuc.BackColor;

                panelErrors.BackColor = JsonConvert.DeserializeObject<Color>(Properties.Settings.Default.Properties["ColorErrors"].DefaultValue.ToString());
                labelErrors.ForeColor = panelErrors.BackColor;

                panelCommands.BackColor = JsonConvert.DeserializeObject<Color>(Properties.Settings.Default.Properties["ColorCommands"].DefaultValue.ToString());
                labelCommands.ForeColor = panelCommands.BackColor;

                panelOutput.BackColor = JsonConvert.DeserializeObject<Color>(Properties.Settings.Default.Properties["ColorOutput"].DefaultValue.ToString());
                labelOutput.ForeColor = panelOutput.BackColor;

                panelConsole.BackColor = JsonConvert.DeserializeObject<Color>(Properties.Settings.Default.Properties["ColorConsole"].DefaultValue.ToString());

                mainForm.colorConnecting = panelConnecting.BackColor;
                mainForm.colorConSuc = panelConSuc.BackColor;
                mainForm.colorErrors = panelErrors.BackColor;
                mainForm.colorCommands = panelCommands.BackColor;
                mainForm.colorOutput = panelOutput.BackColor;
                mainForm.colorConsole = panelConsole.BackColor;
                mainForm.tbConsole.BackColor = panelConsole.BackColor;

                labelConnectingConsole.ForeColor = panelConnecting.BackColor;
                labelConSucConsole.ForeColor = panelConSuc.BackColor;
                labelErrorsConsole.ForeColor = panelErrors.BackColor;
                labelCommandsConsole.ForeColor = panelCommands.BackColor;
                labelOutputConsole.ForeColor = panelOutput.BackColor;

                bgConnecting.BackColor = panelConsole.BackColor;
                bgConSuc.BackColor = panelConsole.BackColor;
                bgErrors.BackColor = panelConsole.BackColor;
                bgCommands.BackColor = panelConsole.BackColor;
                bgOutput.BackColor = panelConsole.BackColor;
                bgConsole.BackColor = panelConsole.BackColor;

                double opacity = Double.Parse(Properties.Settings.Default.Properties["Opacity"].DefaultValue.ToString()) * 100;
                trackBarOpacity.Value = (int)(opacity / 100.0);

                this.Opacity = trackBarOpacity.Value / 100.00;
                mainForm.Opacity = trackBarOpacity.Value / 100.00;
                mainForm.opacity = mainForm.Opacity;

                //this.Opacity = (double)(Properties.Settings.Default.Opacity);
                //mainForm.Opacity = this.Opacity;
                //mainForm.opacity = this.Opacity;
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            panelConnecting.BackColor = JsonConvert.DeserializeObject<Color>(Properties.Settings.Default.ColorConnecting);
            labelConnecting.ForeColor = panelConnecting.BackColor;

            panelConSuc.BackColor = JsonConvert.DeserializeObject<Color>(Properties.Settings.Default.ColorConSuc);
            labelConSuc.ForeColor = panelConSuc.BackColor;

            panelErrors.BackColor = JsonConvert.DeserializeObject<Color>(Properties.Settings.Default.ColorErrors);
            labelErrors.ForeColor = panelErrors.BackColor;

            panelCommands.BackColor = JsonConvert.DeserializeObject<Color>(Properties.Settings.Default.ColorCommands);
            labelCommands.ForeColor = panelCommands.BackColor;

            panelOutput.BackColor = JsonConvert.DeserializeObject<Color>(Properties.Settings.Default.ColorOutput);
            labelOutput.ForeColor = panelOutput.BackColor;

            panelConsole.BackColor = JsonConvert.DeserializeObject<Color>(Properties.Settings.Default.ColorConsole);

            mainForm.colorConnecting = panelConnecting.BackColor;
            mainForm.colorConSuc = panelConSuc.BackColor;
            mainForm.colorErrors = panelErrors.BackColor;
            mainForm.colorCommands = panelCommands.BackColor;
            mainForm.colorOutput = panelOutput.BackColor;
            mainForm.colorConsole = panelConsole.BackColor;
            mainForm.tbConsole.BackColor = panelConsole.BackColor;

            labelConnectingConsole.ForeColor = panelConnecting.BackColor;
            labelConSucConsole.ForeColor = panelConSuc.BackColor;
            labelErrorsConsole.ForeColor = panelErrors.BackColor;
            labelCommandsConsole.ForeColor = panelCommands.BackColor;
            labelOutputConsole.ForeColor = panelOutput.BackColor;

            bgConnecting.BackColor = panelConsole.BackColor;
            bgConSuc.BackColor = panelConsole.BackColor;
            bgErrors.BackColor = panelConsole.BackColor;
            bgCommands.BackColor = panelConsole.BackColor;
            bgOutput.BackColor = panelConsole.BackColor;
            bgConsole.BackColor = panelConsole.BackColor;

            double opacity = Double.Parse(Properties.Settings.Default.Opacity.ToString()) * 100;
            trackBarOpacity.Value = (int)opacity;
            this.Opacity = (double)(Properties.Settings.Default.Opacity);
            mainForm.Opacity = this.Opacity;
            mainForm.opacity = this.Opacity;
            Console.WriteLine("opac = " + this.Opacity);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ColorConnecting = JsonConvert.SerializeObject(Color.FromArgb(panelConnecting.BackColor.ToArgb()));
            Properties.Settings.Default.ColorConSuc = JsonConvert.SerializeObject(Color.FromArgb(panelConSuc.BackColor.ToArgb()));
            Properties.Settings.Default.ColorErrors = JsonConvert.SerializeObject(Color.FromArgb(panelErrors.BackColor.ToArgb()));
            Properties.Settings.Default.ColorCommands = JsonConvert.SerializeObject(Color.FromArgb(panelCommands.BackColor.ToArgb()));
            Properties.Settings.Default.ColorOutput = JsonConvert.SerializeObject(Color.FromArgb(panelOutput.BackColor.ToArgb()));
            Properties.Settings.Default.ColorConsole = JsonConvert.SerializeObject(Color.FromArgb(panelConsole.BackColor.ToArgb()));

            Properties.Settings.Default.Opacity = this.Opacity;

            Properties.Settings.Default.Save();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
