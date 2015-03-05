namespace ChampSelector
{
    partial class ChampSelect
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChampSelect));
            this.gameDelayTextLabel = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.clientCheckFreqTextLabel = new System.Windows.Forms.Label();
            this.sendChatDelayTextLabel = new System.Windows.Forms.Label();
            this.selectChampDelayTextLabel = new System.Windows.Forms.Label();
            this.lockInDelayTextLabel = new System.Windows.Forms.Label();
            this.limitedRandomPickCheckBox = new System.Windows.Forms.CheckBox();
            this.initialDelayTrackBar = new System.Windows.Forms.TrackBar();
            this.clientCheckFreqTrackBar = new System.Windows.Forms.TrackBar();
            this.sendChatMessageCheckBox = new System.Windows.Forms.CheckBox();
            this.sendChatMessageTextBox = new System.Windows.Forms.TextBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomLockInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendChatDelayTrackBar = new System.Windows.Forms.TrackBar();
            this.startStopButton = new System.Windows.Forms.Button();
            this.pickChampionCheckBox = new System.Windows.Forms.CheckBox();
            this.championsComboBox = new System.Windows.Forms.ComboBox();
            this.selectChampionDelayTrackBar = new System.Windows.Forms.TrackBar();
            this.lockInCheckBox = new System.Windows.Forms.CheckBox();
            this.lockInDelayTrackBar = new System.Windows.Forms.TrackBar();
            this.randompickCheckBox = new System.Windows.Forms.CheckBox();
            this.limitChampionsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.acceptGameCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.initialDelayTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientCheckFreqTrackBar)).BeginInit();
            this.notifyIconMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sendChatDelayTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectChampionDelayTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lockInDelayTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // gameDelayTextLabel
            // 
            this.gameDelayTextLabel.AutoSize = true;
            this.gameDelayTextLabel.Location = new System.Drawing.Point(4, 61);
            this.gameDelayTextLabel.Name = "gameDelayTextLabel";
            this.gameDelayTextLabel.Size = new System.Drawing.Size(64, 13);
            this.gameDelayTextLabel.TabIndex = 0;
            this.gameDelayTextLabel.Text = "Initial Delay:";
            this.toolTip.SetToolTip(this.gameDelayTextLabel, "The amount of delay, in milliseconds, ChampSelector waits after you enter a game " +
        "to start performing actions");
            // 
            // toolTip
            // 
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // clientCheckFreqTextLabel
            // 
            this.clientCheckFreqTextLabel.AutoSize = true;
            this.clientCheckFreqTextLabel.Location = new System.Drawing.Point(3, 9);
            this.clientCheckFreqTextLabel.Name = "clientCheckFreqTextLabel";
            this.clientCheckFreqTextLabel.Size = new System.Drawing.Size(94, 13);
            this.clientCheckFreqTextLabel.TabIndex = 2;
            this.clientCheckFreqTextLabel.Text = "Client Check Freq:";
            this.toolTip.SetToolTip(this.clientCheckFreqTextLabel, "The amount of time, in milliseconds, ChampSelector waits between checks to see if" +
        " you\'re in a game");
            // 
            // sendChatDelayTextLabel
            // 
            this.sendChatDelayTextLabel.AutoSize = true;
            this.sendChatDelayTextLabel.Location = new System.Drawing.Point(3, 104);
            this.sendChatDelayTextLabel.Name = "sendChatDelayTextLabel";
            this.sendChatDelayTextLabel.Size = new System.Drawing.Size(90, 13);
            this.sendChatDelayTextLabel.TabIndex = 6;
            this.sendChatDelayTextLabel.Text = "Send Chat Delay:";
            this.toolTip.SetToolTip(this.sendChatDelayTextLabel, "The amount of time, in milliseconds, before a message is sent to chat.");
            // 
            // selectChampDelayTextLabel
            // 
            this.selectChampDelayTextLabel.AutoSize = true;
            this.selectChampDelayTextLabel.Location = new System.Drawing.Point(3, 255);
            this.selectChampDelayTextLabel.Name = "selectChampDelayTextLabel";
            this.selectChampDelayTextLabel.Size = new System.Drawing.Size(120, 13);
            this.selectChampDelayTextLabel.TabIndex = 12;
            this.selectChampDelayTextLabel.Text = "Select Champion Delay:";
            this.toolTip.SetToolTip(this.selectChampDelayTextLabel, "The amount of time, in milliseconds, before a champion is selected.");
            // 
            // lockInDelayTextLabel
            // 
            this.lockInDelayTextLabel.AutoSize = true;
            this.lockInDelayTextLabel.Location = new System.Drawing.Point(3, 301);
            this.lockInDelayTextLabel.Name = "lockInDelayTextLabel";
            this.lockInDelayTextLabel.Size = new System.Drawing.Size(76, 13);
            this.lockInDelayTextLabel.TabIndex = 15;
            this.lockInDelayTextLabel.Text = "Lock In Delay:";
            this.toolTip.SetToolTip(this.lockInDelayTextLabel, "The amount of time, in milliseconds, before the you are locked in.");
            // 
            // limitedRandomPickCheckBox
            // 
            this.limitedRandomPickCheckBox.AutoSize = true;
            this.limitedRandomPickCheckBox.Location = new System.Drawing.Point(6, 178);
            this.limitedRandomPickCheckBox.Name = "limitedRandomPickCheckBox";
            this.limitedRandomPickCheckBox.Size = new System.Drawing.Size(129, 17);
            this.limitedRandomPickCheckBox.TabIndex = 18;
            this.limitedRandomPickCheckBox.Text = "Limited Random Pick:";
            this.toolTip.SetToolTip(this.limitedRandomPickCheckBox, "Allows random selection from only the champions checked in  the check listbox to " +
        "the right.");
            this.limitedRandomPickCheckBox.UseVisualStyleBackColor = true;
            this.limitedRandomPickCheckBox.CheckedChanged += new System.EventHandler(this.limitedRandomPickCheckBox_CheckedChanged);
            // 
            // initialDelayTrackBar
            // 
            this.initialDelayTrackBar.LargeChange = 100;
            this.initialDelayTrackBar.Location = new System.Drawing.Point(63, 59);
            this.initialDelayTrackBar.Maximum = 5000;
            this.initialDelayTrackBar.Minimum = 1750;
            this.initialDelayTrackBar.Name = "initialDelayTrackBar";
            this.initialDelayTrackBar.Size = new System.Drawing.Size(226, 45);
            this.initialDelayTrackBar.TabIndex = 1;
            this.initialDelayTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.initialDelayTrackBar.Value = 1750;
            this.initialDelayTrackBar.Scroll += new System.EventHandler(this.initialDelayTrackBar_Scroll);
            // 
            // clientCheckFreqTrackBar
            // 
            this.clientCheckFreqTrackBar.Location = new System.Drawing.Point(94, 9);
            this.clientCheckFreqTrackBar.Maximum = 1000;
            this.clientCheckFreqTrackBar.Minimum = 1;
            this.clientCheckFreqTrackBar.Name = "clientCheckFreqTrackBar";
            this.clientCheckFreqTrackBar.Size = new System.Drawing.Size(195, 45);
            this.clientCheckFreqTrackBar.TabIndex = 3;
            this.clientCheckFreqTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.clientCheckFreqTrackBar.Value = 1;
            this.clientCheckFreqTrackBar.Scroll += new System.EventHandler(this.clientCheckFreqTrackBar_Scroll);
            // 
            // sendChatMessageCheckBox
            // 
            this.sendChatMessageCheckBox.AutoSize = true;
            this.sendChatMessageCheckBox.Location = new System.Drawing.Point(6, 84);
            this.sendChatMessageCheckBox.Name = "sendChatMessageCheckBox";
            this.sendChatMessageCheckBox.Size = new System.Drawing.Size(125, 17);
            this.sendChatMessageCheckBox.TabIndex = 4;
            this.sendChatMessageCheckBox.Text = "Send Chat Message:";
            this.sendChatMessageCheckBox.UseVisualStyleBackColor = true;
            this.sendChatMessageCheckBox.CheckedChanged += new System.EventHandler(this.sendChatMessageCheckBox_CheckedChanged);
            // 
            // sendChatMessageTextBox
            // 
            this.sendChatMessageTextBox.Location = new System.Drawing.Point(132, 84);
            this.sendChatMessageTextBox.Name = "sendChatMessageTextBox";
            this.sendChatMessageTextBox.Size = new System.Drawing.Size(148, 20);
            this.sendChatMessageTextBox.TabIndex = 5;
            this.sendChatMessageTextBox.TextChanged += new System.EventHandler(this.sendChatMessageTextBox_TextChanged);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyIconMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // notifyIconMenuStrip
            // 
            this.notifyIconMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.randomLockInToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.notifyIconMenuStrip.Name = "notifyIconMenuStrip";
            this.notifyIconMenuStrip.Size = new System.Drawing.Size(161, 92);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // randomLockInToolStripMenuItem
            // 
            this.randomLockInToolStripMenuItem.Name = "randomLockInToolStripMenuItem";
            this.randomLockInToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.randomLockInToolStripMenuItem.Text = "Random Lock In";
            this.randomLockInToolStripMenuItem.Click += new System.EventHandler(this.randomLockInToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // sendChatDelayTrackBar
            // 
            this.sendChatDelayTrackBar.Location = new System.Drawing.Point(94, 104);
            this.sendChatDelayTrackBar.Maximum = 2000;
            this.sendChatDelayTrackBar.Minimum = 300;
            this.sendChatDelayTrackBar.Name = "sendChatDelayTrackBar";
            this.sendChatDelayTrackBar.Size = new System.Drawing.Size(195, 45);
            this.sendChatDelayTrackBar.TabIndex = 7;
            this.sendChatDelayTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sendChatDelayTrackBar.Value = 300;
            this.sendChatDelayTrackBar.Scroll += new System.EventHandler(this.sendChatDelayTrackBar_Scroll);
            // 
            // startStopButton
            // 
            this.startStopButton.Location = new System.Drawing.Point(12, 325);
            this.startStopButton.Name = "startStopButton";
            this.startStopButton.Size = new System.Drawing.Size(262, 23);
            this.startStopButton.TabIndex = 9;
            this.startStopButton.Text = "Start (Ctrl + S)";
            this.startStopButton.UseVisualStyleBackColor = true;
            this.startStopButton.Click += new System.EventHandler(this.startStopButton_Click);
            // 
            // pickChampionCheckBox
            // 
            this.pickChampionCheckBox.AutoSize = true;
            this.pickChampionCheckBox.Location = new System.Drawing.Point(6, 132);
            this.pickChampionCheckBox.Name = "pickChampionCheckBox";
            this.pickChampionCheckBox.Size = new System.Drawing.Size(109, 17);
            this.pickChampionCheckBox.TabIndex = 10;
            this.pickChampionCheckBox.Text = "Select Champion:";
            this.pickChampionCheckBox.UseVisualStyleBackColor = true;
            this.pickChampionCheckBox.CheckedChanged += new System.EventHandler(this.pickChampionCheckBox_CheckedChanged);
            // 
            // championsComboBox
            // 
            this.championsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.championsComboBox.FormattingEnabled = true;
            this.championsComboBox.Location = new System.Drawing.Point(121, 130);
            this.championsComboBox.Name = "championsComboBox";
            this.championsComboBox.Size = new System.Drawing.Size(121, 21);
            this.championsComboBox.TabIndex = 11;
            this.championsComboBox.SelectedIndexChanged += new System.EventHandler(this.championsComboBox_SelectedIndexChanged);
            // 
            // selectChampionDelayTrackBar
            // 
            this.selectChampionDelayTrackBar.Location = new System.Drawing.Point(121, 255);
            this.selectChampionDelayTrackBar.Maximum = 2000;
            this.selectChampionDelayTrackBar.Name = "selectChampionDelayTrackBar";
            this.selectChampionDelayTrackBar.Size = new System.Drawing.Size(168, 45);
            this.selectChampionDelayTrackBar.TabIndex = 13;
            this.selectChampionDelayTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.selectChampionDelayTrackBar.Scroll += new System.EventHandler(this.selectChampionDelayTrackBar_Scroll);
            // 
            // lockInCheckBox
            // 
            this.lockInCheckBox.AutoSize = true;
            this.lockInCheckBox.Location = new System.Drawing.Point(6, 281);
            this.lockInCheckBox.Name = "lockInCheckBox";
            this.lockInCheckBox.Size = new System.Drawing.Size(62, 17);
            this.lockInCheckBox.TabIndex = 14;
            this.lockInCheckBox.Text = "Lock In";
            this.lockInCheckBox.UseVisualStyleBackColor = true;
            this.lockInCheckBox.CheckedChanged += new System.EventHandler(this.lockInCheckBox_CheckedChanged);
            // 
            // lockInDelayTrackBar
            // 
            this.lockInDelayTrackBar.Location = new System.Drawing.Point(75, 301);
            this.lockInDelayTrackBar.Maximum = 2000;
            this.lockInDelayTrackBar.Minimum = 400;
            this.lockInDelayTrackBar.Name = "lockInDelayTrackBar";
            this.lockInDelayTrackBar.Size = new System.Drawing.Size(205, 45);
            this.lockInDelayTrackBar.TabIndex = 16;
            this.lockInDelayTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.lockInDelayTrackBar.Value = 400;
            this.lockInDelayTrackBar.Scroll += new System.EventHandler(this.lockInDelayTrackBar_Scroll);
            // 
            // randompickCheckBox
            // 
            this.randompickCheckBox.AutoSize = true;
            this.randompickCheckBox.Location = new System.Drawing.Point(6, 155);
            this.randompickCheckBox.Name = "randompickCheckBox";
            this.randompickCheckBox.Size = new System.Drawing.Size(134, 17);
            this.randompickCheckBox.TabIndex = 17;
            this.randompickCheckBox.Text = "Random Pick (Ctrl + R)";
            this.randompickCheckBox.UseVisualStyleBackColor = true;
            this.randompickCheckBox.CheckedChanged += new System.EventHandler(this.randompickCheckBox_CheckedChanged);
            // 
            // limitChampionsCheckedListBox
            // 
            this.limitChampionsCheckedListBox.FormattingEnabled = true;
            this.limitChampionsCheckedListBox.Location = new System.Drawing.Point(141, 172);
            this.limitChampionsCheckedListBox.Name = "limitChampionsCheckedListBox";
            this.limitChampionsCheckedListBox.Size = new System.Drawing.Size(133, 64);
            this.limitChampionsCheckedListBox.TabIndex = 19;
            this.limitChampionsCheckedListBox.SelectedIndexChanged += new System.EventHandler(this.limitChampionsCheckedListBox_SelectedIndexChanged);
            // 
            // acceptGameCheckBox
            // 
            this.acceptGameCheckBox.AutoSize = true;
            this.acceptGameCheckBox.Location = new System.Drawing.Point(6, 36);
            this.acceptGameCheckBox.Name = "acceptGameCheckBox";
            this.acceptGameCheckBox.Size = new System.Drawing.Size(91, 17);
            this.acceptGameCheckBox.TabIndex = 20;
            this.acceptGameCheckBox.Text = "Accept Game";
            this.acceptGameCheckBox.UseVisualStyleBackColor = true;
            this.acceptGameCheckBox.CheckedChanged += new System.EventHandler(this.acceptGameCheckBox_CheckedChanged);
            // 
            // ChampSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 358);
            this.Controls.Add(this.acceptGameCheckBox);
            this.Controls.Add(this.limitChampionsCheckedListBox);
            this.Controls.Add(this.limitedRandomPickCheckBox);
            this.Controls.Add(this.randompickCheckBox);
            this.Controls.Add(this.startStopButton);
            this.Controls.Add(this.lockInDelayTextLabel);
            this.Controls.Add(this.lockInCheckBox);
            this.Controls.Add(this.selectChampDelayTextLabel);
            this.Controls.Add(this.selectChampionDelayTrackBar);
            this.Controls.Add(this.championsComboBox);
            this.Controls.Add(this.pickChampionCheckBox);
            this.Controls.Add(this.sendChatDelayTextLabel);
            this.Controls.Add(this.sendChatDelayTrackBar);
            this.Controls.Add(this.sendChatMessageTextBox);
            this.Controls.Add(this.sendChatMessageCheckBox);
            this.Controls.Add(this.clientCheckFreqTextLabel);
            this.Controls.Add(this.initialDelayTrackBar);
            this.Controls.Add(this.gameDelayTextLabel);
            this.Controls.Add(this.clientCheckFreqTrackBar);
            this.Controls.Add(this.lockInDelayTrackBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(302, 396);
            this.MinimumSize = new System.Drawing.Size(302, 396);
            this.Name = "ChampSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChampSelector ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChampSelect_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChampSelect_FormClosed);
            this.Load += new System.EventHandler(this.ChampSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.initialDelayTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientCheckFreqTrackBar)).EndInit();
            this.notifyIconMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sendChatDelayTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectChampionDelayTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lockInDelayTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label gameDelayTextLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TrackBar initialDelayTrackBar;
        private System.Windows.Forms.Label clientCheckFreqTextLabel;
        private System.Windows.Forms.TrackBar clientCheckFreqTrackBar;
        private System.Windows.Forms.TextBox sendChatMessageTextBox;
        private System.Windows.Forms.CheckBox sendChatMessageCheckBox;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyIconMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomLockInToolStripMenuItem;
        private System.Windows.Forms.Label sendChatDelayTextLabel;
        private System.Windows.Forms.TrackBar sendChatDelayTrackBar;
        private System.Windows.Forms.Button startStopButton;
        private System.Windows.Forms.CheckBox pickChampionCheckBox;
        private System.Windows.Forms.ComboBox championsComboBox;
        private System.Windows.Forms.Label selectChampDelayTextLabel;
        private System.Windows.Forms.TrackBar selectChampionDelayTrackBar;
        private System.Windows.Forms.CheckBox lockInCheckBox;
        private System.Windows.Forms.Label lockInDelayTextLabel;
        private System.Windows.Forms.TrackBar lockInDelayTrackBar;
        private System.Windows.Forms.CheckBox randompickCheckBox;
        private System.Windows.Forms.CheckBox limitedRandomPickCheckBox;
        private System.Windows.Forms.CheckedListBox limitChampionsCheckedListBox;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.CheckBox acceptGameCheckBox;




    }
}

