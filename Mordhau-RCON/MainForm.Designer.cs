
namespace Mordhau_RCON
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tbInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.serversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemShowPw = new System.Windows.Forms.ToolStripMenuItem();
            this.colorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCommandHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autocompleteListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.keepAliveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideAliveCMDOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateAvailableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblIP = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblPw = new System.Windows.Forms.Label();
            this.tbPw = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbPort = new System.Windows.Forms.NumericUpDown();
            this.tbConsole = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numUpDownAlive = new System.Windows.Forms.NumericUpDown();
            this.customMenuItem = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxAutoscroll = new System.Windows.Forms.CheckBox();
            this.StatusDot = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.checkUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownAlive)).BeginInit();
            this.customMenuItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbInput
            // 
            resources.ApplyResources(this.tbInput, "tbInput");
            this.tbInput.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.tbInput.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbInput.BackColor = System.Drawing.SystemColors.Window;
            this.tbInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbInput.Name = "tbInput";
            this.tbInput.TextChanged += new System.EventHandler(this.tbInput_TextChanged);
            this.tbInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInput_KeyDown);
            this.tbInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbInput_KeyUp);
            this.tbInput.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tbInput_PreviewKeyDown);
            this.tbInput.Validating += new System.ComponentModel.CancelEventHandler(this.tbInput_Validating);
            // 
            // btnSend
            // 
            resources.ApplyResources(this.btnSend, "btnSend");
            this.btnSend.BackColor = System.Drawing.SystemColors.Control;
            this.btnSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSend.Name = "btnSend";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Silver;
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serversToolStripMenuItem,
            this.toolStripMenuItemSettings,
            this.updateAvailableToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // serversToolStripMenuItem
            // 
            this.serversToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.serversToolStripMenuItem.Name = "serversToolStripMenuItem";
            resources.ApplyResources(this.serversToolStripMenuItem, "serversToolStripMenuItem");
            this.serversToolStripMenuItem.Click += new System.EventHandler(this.serversToolStripMenuItem_Click);
            this.serversToolStripMenuItem.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.serversToolStripMenuItem.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            // 
            // toolStripMenuItemSettings
            // 
            this.toolStripMenuItemSettings.BackColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItemSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemShowPw,
            this.colorsToolStripMenuItem,
            this.deleteCommandHistoryToolStripMenuItem,
            this.autocompleteListToolStripMenuItem,
            this.toolStripSeparator1,
            this.keepAliveToolStripMenuItem,
            this.hideAliveCMDOutputToolStripMenuItem});
            resources.ApplyResources(this.toolStripMenuItemSettings, "toolStripMenuItemSettings");
            this.toolStripMenuItemSettings.Name = "toolStripMenuItemSettings";
            this.toolStripMenuItemSettings.Click += new System.EventHandler(this.Settings_Click);
            this.toolStripMenuItemSettings.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.toolStripMenuItemSettings.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            this.toolStripMenuItemSettings.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MenuMouseMove);
            // 
            // toolStripMenuItemShowPw
            // 
            this.toolStripMenuItemShowPw.CheckOnClick = true;
            this.toolStripMenuItemShowPw.Name = "toolStripMenuItemShowPw";
            resources.ApplyResources(this.toolStripMenuItemShowPw, "toolStripMenuItemShowPw");
            this.toolStripMenuItemShowPw.CheckStateChanged += new System.EventHandler(this.toolStripMenuItemShowPw_CheckStateChanged);
            this.toolStripMenuItemShowPw.MouseEnter += new System.EventHandler(this.SubMenu_MouseEnter);
            this.toolStripMenuItemShowPw.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            this.toolStripMenuItemShowPw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MenuMouseMove);
            // 
            // colorsToolStripMenuItem
            // 
            this.colorsToolStripMenuItem.Name = "colorsToolStripMenuItem";
            resources.ApplyResources(this.colorsToolStripMenuItem, "colorsToolStripMenuItem");
            this.colorsToolStripMenuItem.Click += new System.EventHandler(this.colorsToolStripMenuItem_Click);
            this.colorsToolStripMenuItem.MouseEnter += new System.EventHandler(this.SubMenu_MouseEnter);
            this.colorsToolStripMenuItem.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            this.colorsToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MenuMouseMove);
            // 
            // deleteCommandHistoryToolStripMenuItem
            // 
            this.deleteCommandHistoryToolStripMenuItem.Name = "deleteCommandHistoryToolStripMenuItem";
            resources.ApplyResources(this.deleteCommandHistoryToolStripMenuItem, "deleteCommandHistoryToolStripMenuItem");
            this.deleteCommandHistoryToolStripMenuItem.Click += new System.EventHandler(this.deleteCommandHistoryToolStripMenuItem_Click);
            this.deleteCommandHistoryToolStripMenuItem.MouseEnter += new System.EventHandler(this.SubMenu_MouseEnter);
            this.deleteCommandHistoryToolStripMenuItem.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            this.deleteCommandHistoryToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MenuMouseMove);
            // 
            // autocompleteListToolStripMenuItem
            // 
            this.autocompleteListToolStripMenuItem.Name = "autocompleteListToolStripMenuItem";
            resources.ApplyResources(this.autocompleteListToolStripMenuItem, "autocompleteListToolStripMenuItem");
            this.autocompleteListToolStripMenuItem.Click += new System.EventHandler(this.autocompleteListToolStripMenuItem_Click);
            this.autocompleteListToolStripMenuItem.MouseEnter += new System.EventHandler(this.SubMenu_MouseEnter);
            this.autocompleteListToolStripMenuItem.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            this.autocompleteListToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MenuMouseMove);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // keepAliveToolStripMenuItem
            // 
            this.keepAliveToolStripMenuItem.CheckOnClick = true;
            this.keepAliveToolStripMenuItem.Name = "keepAliveToolStripMenuItem";
            resources.ApplyResources(this.keepAliveToolStripMenuItem, "keepAliveToolStripMenuItem");
            this.keepAliveToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.keepAliveToolStripMenuItem_CheckStateChanged);
            this.keepAliveToolStripMenuItem.MouseEnter += new System.EventHandler(this.SubMenu_MouseEnter);
            this.keepAliveToolStripMenuItem.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            this.keepAliveToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MenuMouseMove);
            // 
            // hideAliveCMDOutputToolStripMenuItem
            // 
            this.hideAliveCMDOutputToolStripMenuItem.CheckOnClick = true;
            this.hideAliveCMDOutputToolStripMenuItem.Name = "hideAliveCMDOutputToolStripMenuItem";
            resources.ApplyResources(this.hideAliveCMDOutputToolStripMenuItem, "hideAliveCMDOutputToolStripMenuItem");
            this.hideAliveCMDOutputToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.hideAliveCMDOutputToolStripMenuItem_CheckStateChanged);
            this.hideAliveCMDOutputToolStripMenuItem.MouseEnter += new System.EventHandler(this.SubMenu_MouseEnter);
            this.hideAliveCMDOutputToolStripMenuItem.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            this.hideAliveCMDOutputToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MenuMouseMove);
            // 
            // updateAvailableToolStripMenuItem
            // 
            this.updateAvailableToolStripMenuItem.Name = "updateAvailableToolStripMenuItem";
            resources.ApplyResources(this.updateAvailableToolStripMenuItem, "updateAvailableToolStripMenuItem");
            this.updateAvailableToolStripMenuItem.Click += new System.EventHandler(this.updateAvailableToolStripMenuItem_Click);
            this.updateAvailableToolStripMenuItem.DoubleClick += new System.EventHandler(this.updateAvailableToolStripMenuItem_DoubleClick);
            this.updateAvailableToolStripMenuItem.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.updateAvailableToolStripMenuItem.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            this.updateAvailableToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MenuMouseMove);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            resources.ApplyResources(this.infoToolStripMenuItem, "infoToolStripMenuItem");
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            this.infoToolStripMenuItem.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.infoToolStripMenuItem.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            this.infoToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MenuMouseMove);
            // 
            // tbIP
            // 
            resources.ApplyResources(this.tbIP, "tbIP");
            this.tbIP.BackColor = System.Drawing.SystemColors.Window;
            this.tbIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbIP.Name = "tbIP";
            this.tbIP.TextChanged += new System.EventHandler(this.DataChanged);
            // 
            // btnConnect
            // 
            resources.ApplyResources(this.btnConnect, "btnConnect");
            this.btnConnect.BackColor = System.Drawing.SystemColors.Control;
            this.btnConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblIP
            // 
            resources.ApplyResources(this.lblIP, "lblIP");
            this.lblIP.BackColor = System.Drawing.Color.Transparent;
            this.lblIP.Name = "lblIP";
            // 
            // lblPort
            // 
            resources.ApplyResources(this.lblPort, "lblPort");
            this.lblPort.BackColor = System.Drawing.Color.Transparent;
            this.lblPort.Name = "lblPort";
            // 
            // lblPw
            // 
            resources.ApplyResources(this.lblPw, "lblPw");
            this.lblPw.BackColor = System.Drawing.Color.Transparent;
            this.lblPw.Name = "lblPw";
            // 
            // tbPw
            // 
            resources.ApplyResources(this.tbPw, "tbPw");
            this.tbPw.BackColor = System.Drawing.SystemColors.Window;
            this.tbPw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPw.Name = "tbPw";
            this.tbPw.UseSystemPasswordChar = true;
            this.tbPw.TextChanged += new System.EventHandler(this.DataChanged);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.Controls.Add(this.tbIP, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbPort, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbPw, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblIP, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPw, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPort, 1, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tbPort
            // 
            resources.ApplyResources(this.tbPort, "tbPort");
            this.tbPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.tbPort.Name = "tbPort";
            this.tbPort.Value = new decimal(new int[] {
            7778,
            0,
            0,
            0});
            this.tbPort.ValueChanged += new System.EventHandler(this.DataChanged);
            // 
            // tbConsole
            // 
            resources.ApplyResources(this.tbConsole, "tbConsole");
            this.tbConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbConsole.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.ReadOnly = true;
            this.tbConsole.TabStop = false;
            this.tbConsole.TextChanged += new System.EventHandler(this.tbConsole_TextChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.numUpDownAlive_Click);
            this.label1.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MenuMouseMove);
            // 
            // numUpDownAlive
            // 
            resources.ApplyResources(this.numUpDownAlive, "numUpDownAlive");
            this.numUpDownAlive.Maximum = new decimal(new int[] {
            10800,
            0,
            0,
            0});
            this.numUpDownAlive.Name = "numUpDownAlive";
            this.numUpDownAlive.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUpDownAlive.ValueChanged += new System.EventHandler(this.numUpDownAlive_ValueChanged);
            this.numUpDownAlive.Click += new System.EventHandler(this.numUpDownAlive_Click);
            this.numUpDownAlive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numUpDownAlive_KeyDown);
            // 
            // customMenuItem
            // 
            resources.ApplyResources(this.customMenuItem, "customMenuItem");
            this.customMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customMenuItem.Controls.Add(this.label1, 1, 0);
            this.customMenuItem.Controls.Add(this.numUpDownAlive, 0, 0);
            this.customMenuItem.Name = "customMenuItem";
            this.customMenuItem.TabStop = true;
            this.customMenuItem.Click += new System.EventHandler(this.customMenuItem_Click);
            this.customMenuItem.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.customMenuItem.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            this.customMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MenuMouseMove);
            // 
            // checkBoxAutoscroll
            // 
            resources.ApplyResources(this.checkBoxAutoscroll, "checkBoxAutoscroll");
            this.checkBoxAutoscroll.Checked = true;
            this.checkBoxAutoscroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoscroll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxAutoscroll.Name = "checkBoxAutoscroll";
            this.checkBoxAutoscroll.UseVisualStyleBackColor = true;
            this.checkBoxAutoscroll.CheckedChanged += new System.EventHandler(this.checkBoxAutoscroll_CheckedChanged);
            // 
            // StatusDot
            // 
            resources.ApplyResources(this.StatusDot, "StatusDot");
            this.StatusDot.BackColor = System.Drawing.Color.Transparent;
            this.StatusDot.ForeColor = System.Drawing.Color.Red;
            this.StatusDot.Name = "StatusDot";
            this.StatusDot.UseMnemonic = false;
            // 
            // StatusLabel
            // 
            resources.ApplyResources(this.StatusLabel, "StatusLabel");
            this.StatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.UseMnemonic = false;
            // 
            // checkUpdateTimer
            // 
            this.checkUpdateTimer.Enabled = true;
            this.checkUpdateTimer.Interval = 300000;
            this.checkUpdateTimer.Tick += new System.EventHandler(this.checkUpdateTimer_Tick);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.StatusDot);
            this.Controls.Add(this.checkBoxAutoscroll);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.tbInput);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.customMenuItem);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tbConsole);
            this.Controls.Add(this.StatusLabel);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Opacity = 0.95D;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownAlive)).EndInit();
            this.customMenuItem.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSettings;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblPw;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem serversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowPw;
        private System.Windows.Forms.ToolStripMenuItem keepAliveToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel customMenuItem;
        private System.Windows.Forms.NumericUpDown numUpDownAlive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.TextBox tbIP;
        public System.Windows.Forms.TextBox tbPw;
        public System.Windows.Forms.NumericUpDown tbPort;
        private System.Windows.Forms.ToolStripMenuItem colorsToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxAutoscroll;
        public System.Windows.Forms.RichTextBox tbConsole;
        private System.Windows.Forms.ToolStripMenuItem deleteCommandHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autocompleteListToolStripMenuItem;
        public System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Label StatusDot;
        public System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.ToolStripMenuItem updateAvailableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideAliveCMDOutputToolStripMenuItem;
        public System.Windows.Forms.Timer checkUpdateTimer;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        public System.Windows.Forms.Button btnConnect;
    }
}

