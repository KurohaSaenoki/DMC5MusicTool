namespace WindowsFormsApp1
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.OpenButton = new System.Windows.Forms.ToolStripButton();
            this.SaveButton = new System.Windows.Forms.ToolStripButton();
            this.SaveAsButton = new System.Windows.Forms.ToolStripButton();
            this.HowtoUseButton = new System.Windows.Forms.ToolStripButton();
            this.WEMLabel = new System.Windows.Forms.Label();
            this.StartLabel = new System.Windows.Forms.Label();
            this.LoopStartLabel = new System.Windows.Forms.Label();
            this.LoopEndLabel = new System.Windows.Forms.Label();
            this.LengthLabel = new System.Windows.Forms.Label();
            this.SectionCheckbox = new System.Windows.Forms.CheckBox();
            this.StartNumeric = new System.Windows.Forms.NumericUpDown();
            this.LoopStartNumeric = new System.Windows.Forms.NumericUpDown();
            this.LoopEndNumeric = new System.Windows.Forms.NumericUpDown();
            this.LengthNumeric = new System.Windows.Forms.NumericUpDown();
            this.FilesOpenedLabel = new System.Windows.Forms.Label();
            this.FilesSavedLabel = new System.Windows.Forms.Label();
            this.WEMComboBox = new System.Windows.Forms.ComboBox();
            this.WEMIDLabel = new System.Windows.Forms.Label();
            this.HowToUseTextbox = new System.Windows.Forms.RichTextBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StartNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoopStartNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoopEndNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LengthNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenButton,
            this.SaveButton,
            this.SaveAsButton,
            this.HowtoUseButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(315, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // OpenButton
            // 
            this.OpenButton.AutoToolTip = false;
            this.OpenButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.OpenButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenButton.Image")));
            this.OpenButton.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(40, 22);
            this.OpenButton.Text = "Open";
            this.OpenButton.ToolTipText = "Open";
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.AutoToolTip = false;
            this.SaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SaveButton.Enabled = false;
            this.SaveButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.Image")));
            this.SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(35, 22);
            this.SaveButton.Text = "Save";
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // SaveAsButton
            // 
            this.SaveAsButton.AutoToolTip = false;
            this.SaveAsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SaveAsButton.Enabled = false;
            this.SaveAsButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveAsButton.Image")));
            this.SaveAsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveAsButton.Name = "SaveAsButton";
            this.SaveAsButton.Size = new System.Drawing.Size(51, 22);
            this.SaveAsButton.Text = "Save As";
            this.SaveAsButton.Click += new System.EventHandler(this.SaveAsButton_Click);
            // 
            // HowtoUseButton
            // 
            this.HowtoUseButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.HowtoUseButton.AutoToolTip = false;
            this.HowtoUseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.HowtoUseButton.Image = ((System.Drawing.Image)(resources.GetObject("HowtoUseButton.Image")));
            this.HowtoUseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HowtoUseButton.Name = "HowtoUseButton";
            this.HowtoUseButton.Size = new System.Drawing.Size(72, 22);
            this.HowtoUseButton.Text = "How to Use";
            this.HowtoUseButton.Click += new System.EventHandler(this.HowtoUseButton_Click);
            // 
            // WEMLabel
            // 
            this.WEMLabel.AutoSize = true;
            this.WEMLabel.BackColor = System.Drawing.Color.Transparent;
            this.WEMLabel.Enabled = false;
            this.WEMLabel.ForeColor = System.Drawing.Color.Azure;
            this.WEMLabel.Location = new System.Drawing.Point(130, 75);
            this.WEMLabel.Name = "WEMLabel";
            this.WEMLabel.Size = new System.Drawing.Size(48, 13);
            this.WEMLabel.TabIndex = 1;
            this.WEMLabel.Text = "WEM ID";
            // 
            // StartLabel
            // 
            this.StartLabel.AutoSize = true;
            this.StartLabel.BackColor = System.Drawing.Color.Transparent;
            this.StartLabel.Enabled = false;
            this.StartLabel.ForeColor = System.Drawing.Color.Azure;
            this.StartLabel.Location = new System.Drawing.Point(120, 140);
            this.StartLabel.Name = "StartLabel";
            this.StartLabel.Size = new System.Drawing.Size(69, 13);
            this.StartLabel.TabIndex = 3;
            this.StartLabel.Text = "Start of Song";
            // 
            // LoopStartLabel
            // 
            this.LoopStartLabel.AutoSize = true;
            this.LoopStartLabel.BackColor = System.Drawing.Color.Transparent;
            this.LoopStartLabel.Enabled = false;
            this.LoopStartLabel.ForeColor = System.Drawing.Color.Azure;
            this.LoopStartLabel.Location = new System.Drawing.Point(128, 205);
            this.LoopStartLabel.Name = "LoopStartLabel";
            this.LoopStartLabel.Size = new System.Drawing.Size(56, 13);
            this.LoopStartLabel.TabIndex = 5;
            this.LoopStartLabel.Text = "Loop Start";
            // 
            // LoopEndLabel
            // 
            this.LoopEndLabel.AutoSize = true;
            this.LoopEndLabel.BackColor = System.Drawing.Color.Transparent;
            this.LoopEndLabel.Enabled = false;
            this.LoopEndLabel.ForeColor = System.Drawing.Color.Azure;
            this.LoopEndLabel.Location = new System.Drawing.Point(130, 270);
            this.LoopEndLabel.Name = "LoopEndLabel";
            this.LoopEndLabel.Size = new System.Drawing.Size(53, 13);
            this.LoopEndLabel.TabIndex = 7;
            this.LoopEndLabel.Text = "Loop End";
            // 
            // LengthLabel
            // 
            this.LengthLabel.AutoSize = true;
            this.LengthLabel.BackColor = System.Drawing.Color.Transparent;
            this.LengthLabel.Enabled = false;
            this.LengthLabel.ForeColor = System.Drawing.Color.Azure;
            this.LengthLabel.Location = new System.Drawing.Point(123, 335);
            this.LengthLabel.Name = "LengthLabel";
            this.LengthLabel.Size = new System.Drawing.Size(67, 13);
            this.LengthLabel.TabIndex = 9;
            this.LengthLabel.Text = "Total Length";
            // 
            // SectionCheckbox
            // 
            this.SectionCheckbox.AutoSize = true;
            this.SectionCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.SectionCheckbox.Enabled = false;
            this.SectionCheckbox.ForeColor = System.Drawing.Color.Azure;
            this.SectionCheckbox.Location = new System.Drawing.Point(110, 400);
            this.SectionCheckbox.Name = "SectionCheckbox";
            this.SectionCheckbox.Size = new System.Drawing.Size(97, 17);
            this.SectionCheckbox.TabIndex = 11;
            this.SectionCheckbox.Text = "Swap Sections";
            this.SectionCheckbox.UseVisualStyleBackColor = false;
            // 
            // StartNumeric
            // 
            this.StartNumeric.Enabled = false;
            this.StartNumeric.Location = new System.Drawing.Point(83, 155);
            this.StartNumeric.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.StartNumeric.Name = "StartNumeric";
            this.StartNumeric.Size = new System.Drawing.Size(154, 20);
            this.StartNumeric.TabIndex = 14;
            this.StartNumeric.Click += new System.EventHandler(this.StartNumeric_Click);
            this.StartNumeric.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StartNumeric_KeyDown);
            this.StartNumeric.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StartNumeric_KeyUp);
            // 
            // LoopStartNumeric
            // 
            this.LoopStartNumeric.Enabled = false;
            this.LoopStartNumeric.Location = new System.Drawing.Point(83, 220);
            this.LoopStartNumeric.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.LoopStartNumeric.Name = "LoopStartNumeric";
            this.LoopStartNumeric.Size = new System.Drawing.Size(154, 20);
            this.LoopStartNumeric.TabIndex = 15;
            this.LoopStartNumeric.Click += new System.EventHandler(this.LoopStartNumeric_Click);
            this.LoopStartNumeric.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoopStartNumeric_KeyDown);
            this.LoopStartNumeric.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LoopStartNumeric_KeyUp);
            // 
            // LoopEndNumeric
            // 
            this.LoopEndNumeric.Enabled = false;
            this.LoopEndNumeric.Location = new System.Drawing.Point(83, 285);
            this.LoopEndNumeric.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.LoopEndNumeric.Name = "LoopEndNumeric";
            this.LoopEndNumeric.Size = new System.Drawing.Size(154, 20);
            this.LoopEndNumeric.TabIndex = 16;
            this.LoopEndNumeric.Click += new System.EventHandler(this.LoopEndNumeric_Click);
            this.LoopEndNumeric.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoopEndNumeric_KeyDown);
            this.LoopEndNumeric.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LoopEndNumeric_KeyUp);
            // 
            // LengthNumeric
            // 
            this.LengthNumeric.Enabled = false;
            this.LengthNumeric.Location = new System.Drawing.Point(83, 350);
            this.LengthNumeric.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.LengthNumeric.Name = "LengthNumeric";
            this.LengthNumeric.Size = new System.Drawing.Size(154, 20);
            this.LengthNumeric.TabIndex = 17;
            this.LengthNumeric.Click += new System.EventHandler(this.LengthNumeric_Click);
            this.LengthNumeric.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LengthNumeric_KeyDown);
            this.LengthNumeric.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LengthNumeric_KeyUp);
            // 
            // FilesOpenedLabel
            // 
            this.FilesOpenedLabel.AutoSize = true;
            this.FilesOpenedLabel.BackColor = System.Drawing.Color.Transparent;
            this.FilesOpenedLabel.ForeColor = System.Drawing.Color.Azure;
            this.FilesOpenedLabel.Location = new System.Drawing.Point(6, 40);
            this.FilesOpenedLabel.Name = "FilesOpenedLabel";
            this.FilesOpenedLabel.Size = new System.Drawing.Size(67, 13);
            this.FilesOpenedLabel.TabIndex = 18;
            this.FilesOpenedLabel.Text = "Files Loaded";
            this.FilesOpenedLabel.Visible = false;
            // 
            // FilesSavedLabel
            // 
            this.FilesSavedLabel.AutoSize = true;
            this.FilesSavedLabel.BackColor = System.Drawing.Color.Transparent;
            this.FilesSavedLabel.ForeColor = System.Drawing.Color.Azure;
            this.FilesSavedLabel.Location = new System.Drawing.Point(6, 40);
            this.FilesSavedLabel.Name = "FilesSavedLabel";
            this.FilesSavedLabel.Size = new System.Drawing.Size(62, 13);
            this.FilesSavedLabel.TabIndex = 19;
            this.FilesSavedLabel.Text = "Files Saved";
            this.FilesSavedLabel.Visible = false;
            // 
            // WEMComboBox
            // 
            this.WEMComboBox.Enabled = false;
            this.WEMComboBox.FormattingEnabled = true;
            this.WEMComboBox.Items.AddRange(new object[] {
            "Public Enemy",
            "Ultra Violet",
            "Lock and Load",
            "Fire Away",
            "Wings of the GUARDIAN",
            "Shoot the Works",
            "Taste the Blood",
            "Vergil Battle-2",
            "Devils Never Cry",
            "The Time Has Come",
            "Lock and Load -Blackened Angel mix-",
            "Sworn Through Swords"});
            this.WEMComboBox.Location = new System.Drawing.Point(83, 90);
            this.WEMComboBox.MaxDropDownItems = 12;
            this.WEMComboBox.Name = "WEMComboBox";
            this.WEMComboBox.Size = new System.Drawing.Size(155, 21);
            this.WEMComboBox.TabIndex = 20;
            this.WEMComboBox.TextChanged += new System.EventHandler(this.WEMComboBox_TextChanged);
            this.WEMComboBox.Click += new System.EventHandler(this.WEMComboBox_Click);
            this.WEMComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WEMComboBox_KeyDown);
            this.WEMComboBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.WEMComboBox_KeyUp);
            // 
            // WEMIDLabel
            // 
            this.WEMIDLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.WEMIDLabel.AutoSize = true;
            this.WEMIDLabel.BackColor = System.Drawing.Color.Transparent;
            this.WEMIDLabel.ForeColor = System.Drawing.Color.Azure;
            this.WEMIDLabel.Location = new System.Drawing.Point(246, 40);
            this.WEMIDLabel.Margin = new System.Windows.Forms.Padding(50, 0, 50, 0);
            this.WEMIDLabel.Name = "WEMIDLabel";
            this.WEMIDLabel.Size = new System.Drawing.Size(63, 13);
            this.WEMIDLabel.TabIndex = 21;
            this.WEMIDLabel.Text = "Placeholder";
            this.WEMIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.WEMIDLabel.Visible = false;
            // 
            // HowToUseTextbox
            // 
            this.HowToUseTextbox.AcceptsTab = true;
            this.HowToUseTextbox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.HowToUseTextbox.Location = new System.Drawing.Point(0, 25);
            this.HowToUseTextbox.Name = "HowToUseTextbox";
            this.HowToUseTextbox.ReadOnly = true;
            this.HowToUseTextbox.Size = new System.Drawing.Size(315, 414);
            this.HowToUseTextbox.TabIndex = 22;
            this.HowToUseTextbox.Text = resources.GetString("HowToUseTextbox.Text");
            this.HowToUseTextbox.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.BackgroundImage = global::DMC5MusicTool.Properties.Resources.sky;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(315, 438);
            this.Controls.Add(this.HowToUseTextbox);
            this.Controls.Add(this.WEMIDLabel);
            this.Controls.Add(this.WEMComboBox);
            this.Controls.Add(this.FilesSavedLabel);
            this.Controls.Add(this.FilesOpenedLabel);
            this.Controls.Add(this.LengthNumeric);
            this.Controls.Add(this.LoopEndNumeric);
            this.Controls.Add(this.LoopStartNumeric);
            this.Controls.Add(this.StartNumeric);
            this.Controls.Add(this.SectionCheckbox);
            this.Controls.Add(this.LengthLabel);
            this.Controls.Add(this.LoopEndLabel);
            this.Controls.Add(this.LoopStartLabel);
            this.Controls.Add(this.StartLabel);
            this.Controls.Add(this.WEMLabel);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Devil May Cry 5 Music Tool";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StartNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoopStartNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoopEndNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LengthNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton OpenButton;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripButton SaveAsButton;
        private System.Windows.Forms.ToolStripButton HowtoUseButton;
        private System.Windows.Forms.Label WEMLabel;
        private System.Windows.Forms.Label StartLabel;
        private System.Windows.Forms.Label LoopStartLabel;
        private System.Windows.Forms.Label LoopEndLabel;
        private System.Windows.Forms.Label LengthLabel;
        private System.Windows.Forms.CheckBox SectionCheckbox;
        private System.Windows.Forms.NumericUpDown StartNumeric;
        private System.Windows.Forms.NumericUpDown LoopStartNumeric;
        private System.Windows.Forms.NumericUpDown LoopEndNumeric;
        private System.Windows.Forms.NumericUpDown LengthNumeric;
        private System.Windows.Forms.Label FilesOpenedLabel;
        private System.Windows.Forms.Label FilesSavedLabel;
        private System.Windows.Forms.ComboBox WEMComboBox;
        private System.Windows.Forms.Label WEMIDLabel;
        private System.Windows.Forms.RichTextBox HowToUseTextbox;
    }
}

