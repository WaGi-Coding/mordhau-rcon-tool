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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mordhau_RCON
{
    public partial class Servers : Form
    {
        public List<ServerEntry> servers;
        public MainForm mainForm;
        public ServerEntry selectedServer { get; set; }
        public bool isEditing { get; set; }

        public Servers(MainForm mainForm)
        {
            InitializeComponent();
            this.isEditing = false;
            this.mainForm = mainForm;
            this.servers = this.mainForm.servers;

            this.Opacity = mainForm.opacity;
            listBox1.BackColor = mainForm.colorConsole;
            listBox1.ForeColor = mainForm.colorCommands;

        }

        private void Servers_Load(object sender, EventArgs e)
        {

            if (servers == null || servers.Count == 0)
            {
                return;
            }
            listBox1.Items.Clear();

            foreach (ServerEntry server in servers)
            {
                listBox1.Items.Add(server.ServerName);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {


            if (listBox1.SelectedItem != null)
            {
                selectedServer = servers[listBox1.SelectedIndex];
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void toolStripMenuItemMoveUp_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                MoveUp(listBox1.SelectedIndex);

                //Just keep it focused for keyboard controls
                btnUp.Focus();
                this.ActiveControl = btnUp;

            }
        }

        private void toolStripMenuItemMoveDown_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                MoveDown(listBox1.SelectedIndex);

                //Just keep it focused for keyboard controls
                btnDown.Focus();
                this.ActiveControl = btnDown;
            }
        }
        private void Delete(int theIndex)
        {
            listBox1.Items.RemoveAt(theIndex);
            servers.RemoveAt(theIndex);

            if (servers != null && servers.Count > 0)
            {
                Properties.Settings.Default.Servers = JsonConvert.SerializeObject(servers);
                Properties.Settings.Default.Save();
            }
        }
        private void MoveUp(int theIndex)
        {
            ServerEntry tmpServerEntry = servers[theIndex];

            listBox1.Items.RemoveAt(theIndex);
            servers.RemoveAt(theIndex);

            if (theIndex - 1 < 0)
            {
                listBox1.Items.Insert(listBox1.Items.Count, tmpServerEntry.ServerName);
                servers.Insert(servers.Count, tmpServerEntry);
                listBox1.SelectedIndex = servers.Count - 1;
            }
            else
            {
                listBox1.Items.Insert(theIndex - 1, tmpServerEntry.ServerName);
                servers.Insert(theIndex - 1, tmpServerEntry);
                listBox1.SelectedIndex = theIndex - 1;
            }
            if (servers != null)
            {
                Properties.Settings.Default.Servers = JsonConvert.SerializeObject(servers);
                Properties.Settings.Default.Save();
            }
        }

        private void MoveDown(int theIndex)
        {
            ServerEntry tmpServerEntry = servers[theIndex];

            listBox1.Items.RemoveAt(theIndex);
            servers.RemoveAt(theIndex);

            if (theIndex + 1 > listBox1.Items.Count && theIndex + 1 > servers.Count)
            {
                listBox1.Items.Insert(0, tmpServerEntry.ServerName);
                servers.Insert(0, tmpServerEntry);
                listBox1.SelectedIndex = 0;
            }
            else
            {
                listBox1.Items.Insert(theIndex + 1, tmpServerEntry.ServerName);
                servers.Insert(theIndex + 1, tmpServerEntry);
                listBox1.SelectedIndex = theIndex + 1;
            }
            if (servers != null)
            {
                Properties.Settings.Default.Servers = JsonConvert.SerializeObject(servers);
                Properties.Settings.Default.Save();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                selectedServer = servers[listBox1.SelectedIndex];
                this.Text = "Servers - " + selectedServer.ServerName;

                btnUp.Enabled = true;
                btnDown.Enabled = true;
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
                btnLoad.Enabled = true;
            }
            else
            {
                selectedServer = null;
                this.Text = "Servers";
                btnUp.Enabled = false;
                btnDown.Enabled = false;
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                btnLoad.Enabled = false;
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                selectedServer = servers[listBox1.SelectedIndex];
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            listBox1.SelectedIndex = listBox1.IndexFromPoint(e.X, e.Y);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                var result = MessageBox.Show($"You're about to delete following server:\n{servers[listBox1.SelectedIndex].ServerName}\n\nAre you sure?", "Delete Server", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (mainForm.lastServer.ServerName == listBox1.SelectedItem.ToString())
                    {
                        mainForm.StatusLabel.Text = "Server: Unsaved Server";
                        mainForm.lastServer = JsonConvert.DeserializeObject<ServerEntry>(Properties.Settings.Default.Properties["LastServer"].DefaultValue as string);
                        Properties.Settings.Default.LastServer = JsonConvert.SerializeObject(mainForm.lastServer);
                        Properties.Settings.Default.Save();
                    }

                    Delete(listBox1.SelectedIndex);
                }
            }
        }

        private void Servers_Click(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = -1;
        }

        private void MyMouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void MyMouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (AddServer frmAddServer = new AddServer(mainForm, selectedServer, servers))
            {
                btnAdd.Visible = false;
                btnLoad.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnUp.Visible = false;
                btnDown.Visible = false;
                //panel1.Visible = false; //idk why but this panel crashes the app on linux with mono ._.
                var result = frmAddServer.ShowDialog();
                if (result == DialogResult.OK)
                {

                    if (frmAddServer.newServerEntryData != null)
                    {
                        if (servers == null || servers.Count == 0)
                        {
                            servers = new List<ServerEntry>();
                        }
                        servers.Insert((listBox1.SelectedIndex == -1 ) ? listBox1.Items.Count : listBox1.SelectedIndex, frmAddServer.newServerEntryData);
                        listBox1.Items.Insert((listBox1.SelectedIndex == -1) ? listBox1.Items.Count : listBox1.SelectedIndex, frmAddServer.newServerEntryData.ServerName);
                        listBox1.SelectedItem = frmAddServer.newServerEntryData.ServerName;

                        Properties.Settings.Default.Servers = JsonConvert.SerializeObject(servers);
                        Properties.Settings.Default.Save();
                        // =================================

                    }
                }
                btnAdd.Visible = true;
                btnLoad.Visible = true;
                btnEdit.Visible = true;
                btnDelete.Visible = true;
                btnUp.Visible = true;
                btnDown.Visible = true;
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null && listBox1.SelectedIndex != -1)
            {
                selectedServer = servers[listBox1.SelectedIndex];

                using (var editServerForm = new EditServer(selectedServer, listBox1.SelectedIndex, mainForm))
                {
                    btnAdd.Visible = false;
                    btnLoad.Visible = false;
                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                    btnUp.Visible = false;
                    btnDown.Visible = false;
                    //panel1.Visible = false; //idk why but this panel crashes the app on linux with mono ._.
                    var result = editServerForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {

                        if (editServerForm.newServerEntryData != null)
                        {
                            if (servers == null || servers.Count == 0)
                            {
                                servers = new List<ServerEntry>();
                            }
                            servers[editServerForm.index] = editServerForm.newServerEntryData;
                            listBox1.Items[editServerForm.index] = editServerForm.newServerEntryData.ServerName;
                            listBox1.SelectedItem = editServerForm.newServerEntryData.ServerName;

                            Properties.Settings.Default.Servers = JsonConvert.SerializeObject(servers);
                            Properties.Settings.Default.Save();
                            // =================================

                        }
                    }
                    btnAdd.Visible = true;
                    btnLoad.Visible = true;
                    btnEdit.Visible = true;
                    btnDelete.Visible = true;
                    btnUp.Visible = true;
                    btnDown.Visible = true;
                }
            }
        }

        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            listBox1_MouseDoubleClick(sender, null);
        }

        private void Servers_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (listBox1.SelectedIndex != -1)
                {
                    listBox1.SelectedIndex = -1;
                }
                else
                {
                    this.Close();
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                btnLoad_Click(null, null);
            }
            if (e.KeyCode == Keys.Delete)
            {
                deleteToolStripMenuItem_Click(null, null);
            }
        }

        private void MoveCursor(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                toolStripMenuItemMoveUp_Click(null, null);
                listBox1.Focus();
            }
            if (e.Control && e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;
                toolStripMenuItemMoveDown_Click(null, null);
                listBox1.Focus();
            }
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void listBox1_DragOver(object sender, DragEventArgs e)
        {

        }

        private void addServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAdd_Click(sender, e);
        }
    }
}