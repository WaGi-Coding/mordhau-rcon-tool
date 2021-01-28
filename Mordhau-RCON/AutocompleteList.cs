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
    public partial class AutocompleteList : Form
    {
        MainForm mainForm;
        public AutocompleteList(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            richTextBox1.BackColor = mainForm.colorConsole;
            richTextBox1.ForeColor = mainForm.colorCommands;
            this.Opacity = mainForm.Opacity;
        }

        private void AutocompleteList_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Join("\n", mainForm.tbInput.AutoCompleteCustomSource.Cast<string>());
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AutoCompleteStringCollection sc = new AutoCompleteStringCollection();
            sc.AddRange(richTextBox1.Text.Split(new string[] { "\n" }, StringSplitOptions.None));
            mainForm.tbInput.AutoCompleteCustomSource = sc;

            Properties.Settings.Default.AutocompleteList = JsonConvert.SerializeObject(mainForm.tbInput.AutoCompleteCustomSource.Cast<string>());
            Properties.Settings.Default.Save();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            AutoCompleteStringCollection sc = new AutoCompleteStringCollection();
            string[] cmds = JsonConvert.DeserializeObject<string[]>(Properties.Settings.Default.AutocompleteList);
            sc.AddRange(cmds);
            mainForm.tbInput.AutoCompleteCustomSource = sc;

            richTextBox1.Text = string.Join("\n", cmds);
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you really want to load Application Defaults?", "Autocomplete-Settings | Load Defaults", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            else if (result == DialogResult.Yes)
            {
                
                AutoCompleteStringCollection sc = new AutoCompleteStringCollection();
                string[] cmds = JsonConvert.DeserializeObject<string[]>(Properties.Settings.Default.Properties["AutocompleteList"].DefaultValue as string);
                sc.AddRange(cmds);
                mainForm.tbInput.AutoCompleteCustomSource = sc;

                richTextBox1.Text = string.Join("\n", cmds);
            }
        }
    }
}
