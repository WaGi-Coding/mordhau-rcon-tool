
namespace Mordhau_RCON
{
    partial class FrmColors
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmColors));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelConSuc = new System.Windows.Forms.Panel();
            this.bgConSuc = new System.Windows.Forms.Panel();
            this.labelConSuc = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.bgConnecting = new System.Windows.Forms.Panel();
            this.labelConnecting = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelConnecting = new System.Windows.Forms.Panel();
            this.bgErrors = new System.Windows.Forms.Panel();
            this.labelErrors = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panelErrors = new System.Windows.Forms.Panel();
            this.bgConsole = new System.Windows.Forms.Panel();
            this.labelOutputConsole = new System.Windows.Forms.Label();
            this.labelCommandsConsole = new System.Windows.Forms.Label();
            this.labelErrorsConsole = new System.Windows.Forms.Label();
            this.labelConnectingConsole = new System.Windows.Forms.Label();
            this.labelConSucConsole = new System.Windows.Forms.Label();
            this.bgCommands = new System.Windows.Forms.Panel();
            this.labelCommands = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panelConsole = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.panelCommands = new System.Windows.Forms.Panel();
            this.bgOutput = new System.Windows.Forms.Panel();
            this.labelOutput = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.panelOutput = new System.Windows.Forms.Panel();
            this.labelPercentOpacity = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.trackBarOpacity = new System.Windows.Forms.TrackBar();
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.bgConSuc.SuspendLayout();
            this.bgConnecting.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.bgErrors.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.bgConsole.SuspendLayout();
            this.bgCommands.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.bgOutput.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelConSuc);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 205);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(131, 62);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection-Success";
            // 
            // panelConSuc
            // 
            this.panelConSuc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelConSuc.AutoSize = true;
            this.panelConSuc.BackColor = System.Drawing.Color.GreenYellow;
            this.panelConSuc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelConSuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelConSuc.Location = new System.Drawing.Point(6, 19);
            this.panelConSuc.Name = "panelConSuc";
            this.panelConSuc.Size = new System.Drawing.Size(119, 38);
            this.panelConSuc.TabIndex = 2;
            this.panelConSuc.TabStop = true;
            this.panelConSuc.Click += new System.EventHandler(this.panelConSuc_Click);
            // 
            // bgConSuc
            // 
            this.bgConSuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bgConSuc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bgConSuc.Controls.Add(this.labelConSuc);
            this.bgConSuc.Location = new System.Drawing.Point(149, 211);
            this.bgConSuc.Name = "bgConSuc";
            this.bgConSuc.Size = new System.Drawing.Size(225, 56);
            this.bgConSuc.TabIndex = 2;
            // 
            // labelConSuc
            // 
            this.labelConSuc.AutoSize = true;
            this.labelConSuc.BackColor = System.Drawing.Color.Transparent;
            this.labelConSuc.Font = new System.Drawing.Font("Arial", 9.75F);
            this.labelConSuc.ForeColor = System.Drawing.Color.GreenYellow;
            this.labelConSuc.Location = new System.Drawing.Point(3, 20);
            this.labelConSuc.Name = "labelConSuc";
            this.labelConSuc.Size = new System.Drawing.Size(145, 16);
            this.labelConSuc.TabIndex = 2;
            this.labelConSuc.Text = "Connection Succeeded!";
            // 
            // bgConnecting
            // 
            this.bgConnecting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bgConnecting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bgConnecting.Controls.Add(this.labelConnecting);
            this.bgConnecting.Location = new System.Drawing.Point(149, 139);
            this.bgConnecting.Name = "bgConnecting";
            this.bgConnecting.Size = new System.Drawing.Size(225, 56);
            this.bgConnecting.TabIndex = 4;
            // 
            // labelConnecting
            // 
            this.labelConnecting.AutoSize = true;
            this.labelConnecting.BackColor = System.Drawing.Color.Transparent;
            this.labelConnecting.Font = new System.Drawing.Font("Arial", 9.75F);
            this.labelConnecting.ForeColor = System.Drawing.Color.DarkOrange;
            this.labelConnecting.Location = new System.Drawing.Point(3, 20);
            this.labelConnecting.Name = "labelConnecting";
            this.labelConnecting.Size = new System.Drawing.Size(85, 16);
            this.labelConnecting.TabIndex = 3;
            this.labelConnecting.Text = "Connecting...";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panelConnecting);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(12, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(131, 62);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connect/Disconnect";
            // 
            // panelConnecting
            // 
            this.panelConnecting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelConnecting.AutoSize = true;
            this.panelConnecting.BackColor = System.Drawing.Color.DarkOrange;
            this.panelConnecting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelConnecting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelConnecting.Location = new System.Drawing.Point(6, 19);
            this.panelConnecting.Name = "panelConnecting";
            this.panelConnecting.Size = new System.Drawing.Size(119, 38);
            this.panelConnecting.TabIndex = 1;
            this.panelConnecting.TabStop = true;
            this.panelConnecting.Click += new System.EventHandler(this.panelConnecting_Click);
            // 
            // bgErrors
            // 
            this.bgErrors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bgErrors.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bgErrors.Controls.Add(this.labelErrors);
            this.bgErrors.Location = new System.Drawing.Point(149, 283);
            this.bgErrors.Name = "bgErrors";
            this.bgErrors.Size = new System.Drawing.Size(225, 56);
            this.bgErrors.TabIndex = 6;
            // 
            // labelErrors
            // 
            this.labelErrors.AutoSize = true;
            this.labelErrors.BackColor = System.Drawing.Color.Transparent;
            this.labelErrors.Font = new System.Drawing.Font("Arial", 9.75F);
            this.labelErrors.ForeColor = System.Drawing.Color.Red;
            this.labelErrors.Location = new System.Drawing.Point(3, 20);
            this.labelErrors.Name = "labelErrors";
            this.labelErrors.Size = new System.Drawing.Size(205, 16);
            this.labelErrors.TabIndex = 4;
            this.labelErrors.Text = "Error: Wrong Password! Kicking...";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panelErrors);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(12, 277);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(131, 62);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Errors";
            // 
            // panelErrors
            // 
            this.panelErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelErrors.AutoSize = true;
            this.panelErrors.BackColor = System.Drawing.Color.Red;
            this.panelErrors.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelErrors.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelErrors.Location = new System.Drawing.Point(6, 19);
            this.panelErrors.Name = "panelErrors";
            this.panelErrors.Size = new System.Drawing.Size(119, 38);
            this.panelErrors.TabIndex = 3;
            this.panelErrors.TabStop = true;
            this.panelErrors.Click += new System.EventHandler(this.panelErrors_Click);
            // 
            // bgConsole
            // 
            this.bgConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bgConsole.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bgConsole.Controls.Add(this.labelOutputConsole);
            this.bgConsole.Controls.Add(this.labelCommandsConsole);
            this.bgConsole.Controls.Add(this.labelErrorsConsole);
            this.bgConsole.Controls.Add(this.labelConnectingConsole);
            this.bgConsole.Controls.Add(this.labelConSucConsole);
            this.bgConsole.Location = new System.Drawing.Point(517, 18);
            this.bgConsole.Name = "bgConsole";
            this.bgConsole.Size = new System.Drawing.Size(225, 91);
            this.bgConsole.TabIndex = 10;
            // 
            // labelOutputConsole
            // 
            this.labelOutputConsole.AutoSize = true;
            this.labelOutputConsole.BackColor = System.Drawing.Color.Transparent;
            this.labelOutputConsole.Font = new System.Drawing.Font("Arial", 9.75F);
            this.labelOutputConsole.ForeColor = System.Drawing.Color.Yellow;
            this.labelOutputConsole.Location = new System.Drawing.Point(3, 68);
            this.labelOutputConsole.Name = "labelOutputConsole";
            this.labelOutputConsole.Size = new System.Drawing.Size(188, 16);
            this.labelOutputConsole.TabIndex = 5;
            this.labelOutputConsole.Text = "Console: There are now 2 bots.";
            // 
            // labelCommandsConsole
            // 
            this.labelCommandsConsole.AutoSize = true;
            this.labelCommandsConsole.BackColor = System.Drawing.Color.Transparent;
            this.labelCommandsConsole.Font = new System.Drawing.Font("Arial", 9.75F);
            this.labelCommandsConsole.ForeColor = System.Drawing.Color.White;
            this.labelCommandsConsole.Location = new System.Drawing.Point(3, 52);
            this.labelCommandsConsole.Name = "labelCommandsConsole";
            this.labelCommandsConsole.Size = new System.Drawing.Size(132, 16);
            this.labelCommandsConsole.TabIndex = 4;
            this.labelCommandsConsole.Text = "Command: addbots 2";
            // 
            // labelErrorsConsole
            // 
            this.labelErrorsConsole.AutoSize = true;
            this.labelErrorsConsole.BackColor = System.Drawing.Color.Transparent;
            this.labelErrorsConsole.Font = new System.Drawing.Font("Arial", 9.75F);
            this.labelErrorsConsole.ForeColor = System.Drawing.Color.Red;
            this.labelErrorsConsole.Location = new System.Drawing.Point(3, 36);
            this.labelErrorsConsole.Name = "labelErrorsConsole";
            this.labelErrorsConsole.Size = new System.Drawing.Size(205, 16);
            this.labelErrorsConsole.TabIndex = 3;
            this.labelErrorsConsole.Text = "Error: Wrong Password! Kicking...";
            // 
            // labelConnectingConsole
            // 
            this.labelConnectingConsole.AutoSize = true;
            this.labelConnectingConsole.BackColor = System.Drawing.Color.Transparent;
            this.labelConnectingConsole.Font = new System.Drawing.Font("Arial", 9.75F);
            this.labelConnectingConsole.ForeColor = System.Drawing.Color.DarkOrange;
            this.labelConnectingConsole.Location = new System.Drawing.Point(3, 4);
            this.labelConnectingConsole.Name = "labelConnectingConsole";
            this.labelConnectingConsole.Size = new System.Drawing.Size(85, 16);
            this.labelConnectingConsole.TabIndex = 2;
            this.labelConnectingConsole.Text = "Connecting...";
            // 
            // labelConSucConsole
            // 
            this.labelConSucConsole.AutoSize = true;
            this.labelConSucConsole.BackColor = System.Drawing.Color.Transparent;
            this.labelConSucConsole.Font = new System.Drawing.Font("Arial", 9.75F);
            this.labelConSucConsole.ForeColor = System.Drawing.Color.GreenYellow;
            this.labelConSucConsole.Location = new System.Drawing.Point(3, 20);
            this.labelConSucConsole.Name = "labelConSucConsole";
            this.labelConSucConsole.Size = new System.Drawing.Size(145, 16);
            this.labelConSucConsole.TabIndex = 1;
            this.labelConSucConsole.Text = "Connection Succeeded!";
            // 
            // bgCommands
            // 
            this.bgCommands.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bgCommands.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bgCommands.Controls.Add(this.labelCommands);
            this.bgCommands.Location = new System.Drawing.Point(517, 139);
            this.bgCommands.Name = "bgCommands";
            this.bgCommands.Size = new System.Drawing.Size(225, 56);
            this.bgCommands.TabIndex = 8;
            // 
            // labelCommands
            // 
            this.labelCommands.AutoSize = true;
            this.labelCommands.BackColor = System.Drawing.Color.Transparent;
            this.labelCommands.Font = new System.Drawing.Font("Arial", 9.75F);
            this.labelCommands.ForeColor = System.Drawing.Color.White;
            this.labelCommands.Location = new System.Drawing.Point(3, 20);
            this.labelCommands.Name = "labelCommands";
            this.labelCommands.Size = new System.Drawing.Size(132, 16);
            this.labelCommands.TabIndex = 5;
            this.labelCommands.Text = "Command: addbots 2";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.panelConsole);
            this.groupBox4.ForeColor = System.Drawing.Color.Black;
            this.groupBox4.Location = new System.Drawing.Point(380, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(131, 97);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Console-Background";
            // 
            // panelConsole
            // 
            this.panelConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelConsole.AutoSize = true;
            this.panelConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelConsole.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelConsole.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelConsole.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.panelConsole.Location = new System.Drawing.Point(6, 19);
            this.panelConsole.Name = "panelConsole";
            this.panelConsole.Size = new System.Drawing.Size(119, 73);
            this.panelConsole.TabIndex = 6;
            this.panelConsole.TabStop = true;
            this.panelConsole.Click += new System.EventHandler(this.panelConsole_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.panelCommands);
            this.groupBox5.ForeColor = System.Drawing.Color.Black;
            this.groupBox5.Location = new System.Drawing.Point(380, 133);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(131, 62);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Commands";
            // 
            // panelCommands
            // 
            this.panelCommands.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCommands.AutoSize = true;
            this.panelCommands.BackColor = System.Drawing.Color.White;
            this.panelCommands.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelCommands.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelCommands.Location = new System.Drawing.Point(6, 19);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Size = new System.Drawing.Size(119, 38);
            this.panelCommands.TabIndex = 4;
            this.panelCommands.TabStop = true;
            this.panelCommands.Click += new System.EventHandler(this.panelCommands_Click);
            // 
            // bgOutput
            // 
            this.bgOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bgOutput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bgOutput.Controls.Add(this.labelOutput);
            this.bgOutput.Location = new System.Drawing.Point(517, 211);
            this.bgOutput.Name = "bgOutput";
            this.bgOutput.Size = new System.Drawing.Size(225, 56);
            this.bgOutput.TabIndex = 10;
            // 
            // labelOutput
            // 
            this.labelOutput.AutoSize = true;
            this.labelOutput.BackColor = System.Drawing.Color.Transparent;
            this.labelOutput.Font = new System.Drawing.Font("Arial", 9.75F);
            this.labelOutput.ForeColor = System.Drawing.Color.Yellow;
            this.labelOutput.Location = new System.Drawing.Point(3, 20);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(188, 16);
            this.labelOutput.TabIndex = 6;
            this.labelOutput.Text = "Console: There are now 2 bots.";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.panelOutput);
            this.groupBox6.ForeColor = System.Drawing.Color.Black;
            this.groupBox6.Location = new System.Drawing.Point(380, 205);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(131, 62);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Console-Output";
            // 
            // panelOutput
            // 
            this.panelOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelOutput.AutoSize = true;
            this.panelOutput.BackColor = System.Drawing.Color.Yellow;
            this.panelOutput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelOutput.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelOutput.Location = new System.Drawing.Point(6, 19);
            this.panelOutput.Name = "panelOutput";
            this.panelOutput.Size = new System.Drawing.Size(119, 38);
            this.panelOutput.TabIndex = 5;
            this.panelOutput.TabStop = true;
            this.panelOutput.Click += new System.EventHandler(this.panelOutput_Click);
            // 
            // labelPercentOpacity
            // 
            this.labelPercentOpacity.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPercentOpacity.ForeColor = System.Drawing.Color.Black;
            this.labelPercentOpacity.Location = new System.Drawing.Point(6, 17);
            this.labelPercentOpacity.Name = "labelPercentOpacity";
            this.labelPercentOpacity.Size = new System.Drawing.Size(350, 39);
            this.labelPercentOpacity.TabIndex = 0;
            this.labelPercentOpacity.Text = "95%";
            this.labelPercentOpacity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.trackBarOpacity);
            this.groupBox7.Controls.Add(this.labelPercentOpacity);
            this.groupBox7.ForeColor = System.Drawing.Color.Black;
            this.groupBox7.Location = new System.Drawing.Point(12, 12);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(362, 97);
            this.groupBox7.TabIndex = 10;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Window-Opacity";
            // 
            // trackBarOpacity
            // 
            this.trackBarOpacity.AutoSize = false;
            this.trackBarOpacity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBarOpacity.Location = new System.Drawing.Point(6, 55);
            this.trackBarOpacity.Maximum = 100;
            this.trackBarOpacity.Minimum = 20;
            this.trackBarOpacity.Name = "trackBarOpacity";
            this.trackBarOpacity.Size = new System.Drawing.Size(350, 36);
            this.trackBarOpacity.TabIndex = 7;
            this.trackBarOpacity.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBarOpacity.Value = 95;
            this.trackBarOpacity.ValueChanged += new System.EventHandler(this.trackBarOpacity_ValueChanged);
            // 
            // btnDefault
            // 
            this.btnDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDefault.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDefault.Location = new System.Drawing.Point(426, 321);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(75, 23);
            this.btnDefault.TabIndex = 8;
            this.btnDefault.Text = "Default";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Location = new System.Drawing.Point(507, 321);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(377, 283);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Text-Colors will only apply to new lines in the console";
            this.label1.UseMnemonic = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(669, 321);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(588, 321);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmColors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(754, 351);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.bgOutput);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.bgConsole);
            this.Controls.Add(this.bgErrors);
            this.Controls.Add(this.bgCommands);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.bgConnecting);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.bgConSuc);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(770, 390);
            this.MinimumSize = new System.Drawing.Size(770, 390);
            this.Name = "FrmColors";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings - Colors";
            this.Load += new System.EventHandler(this.FrmColors_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.bgConSuc.ResumeLayout(false);
            this.bgConSuc.PerformLayout();
            this.bgConnecting.ResumeLayout(false);
            this.bgConnecting.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.bgErrors.ResumeLayout(false);
            this.bgErrors.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.bgConsole.ResumeLayout(false);
            this.bgConsole.PerformLayout();
            this.bgCommands.ResumeLayout(false);
            this.bgCommands.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.bgOutput.ResumeLayout(false);
            this.bgOutput.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label labelPercentOpacity;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Panel panelConnecting;
        private System.Windows.Forms.Panel panelConSuc;
        private System.Windows.Forms.Panel bgConSuc;
        private System.Windows.Forms.Panel bgConnecting;
        private System.Windows.Forms.Panel bgErrors;
        private System.Windows.Forms.Panel panelErrors;
        private System.Windows.Forms.Panel bgConsole;
        private System.Windows.Forms.Panel bgCommands;
        private System.Windows.Forms.Panel panelConsole;
        private System.Windows.Forms.Panel panelCommands;
        private System.Windows.Forms.Panel bgOutput;
        private System.Windows.Forms.Panel panelOutput;
        private System.Windows.Forms.Label labelOutputConsole;
        private System.Windows.Forms.Label labelCommandsConsole;
        private System.Windows.Forms.Label labelErrorsConsole;
        private System.Windows.Forms.Label labelConnectingConsole;
        private System.Windows.Forms.Label labelConSucConsole;
        private System.Windows.Forms.Label labelConSuc;
        private System.Windows.Forms.Label labelConnecting;
        private System.Windows.Forms.Label labelErrors;
        private System.Windows.Forms.Label labelCommands;
        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.TrackBar trackBarOpacity;
    }
}