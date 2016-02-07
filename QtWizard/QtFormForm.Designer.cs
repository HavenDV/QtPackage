namespace QtWizard {
    partial class QtFormForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QtFormForm));
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.qtPictureBox = new System.Windows.Forms.PictureBox();
            this.previewPictureBox = new System.Windows.Forms.PictureBox();
            this.dialogBottomRadioButton = new System.Windows.Forms.RadioButton();
            this.selectGroupBox = new System.Windows.Forms.GroupBox();
            this.widgetRadioButton = new System.Windows.Forms.RadioButton();
            this.mainWindowRadioButton = new System.Windows.Forms.RadioButton();
            this.dialogRightRadioButton = new System.Windows.Forms.RadioButton();
            this.previewGroupBox = new System.Windows.Forms.GroupBox();
            this.backButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.finishButton = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.locationLabel = new System.Windows.Forms.Label();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.locationToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.qtPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).BeginInit();
            this.selectGroupBox.SuspendLayout();
            this.previewGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(-9, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(555, 2);
            this.label2.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(-7, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(490, 36);
            this.label8.TabIndex = 24;
            this.label8.Text = "       This wizard will add a new Qt Forn(.ui) to your project.";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(-12, -2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(495, 31);
            this.label7.TabIndex = 23;
            this.label7.Text = "   Welcome to the Qt Form Wizard:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // qtPictureBox
            // 
            this.qtPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.qtPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.qtPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("qtPictureBox.Image")));
            this.qtPictureBox.Location = new System.Drawing.Point(479, -2);
            this.qtPictureBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.qtPictureBox.Name = "qtPictureBox";
            this.qtPictureBox.Size = new System.Drawing.Size(71, 67);
            this.qtPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.qtPictureBox.TabIndex = 22;
            this.qtPictureBox.TabStop = false;
            // 
            // previewPictureBox
            // 
            this.previewPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.previewPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("previewPictureBox.Image")));
            this.previewPictureBox.Location = new System.Drawing.Point(14, 19);
            this.previewPictureBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.previewPictureBox.Name = "previewPictureBox";
            this.previewPictureBox.Size = new System.Drawing.Size(293, 271);
            this.previewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.previewPictureBox.TabIndex = 26;
            this.previewPictureBox.TabStop = false;
            // 
            // dialogBottomRadioButton
            // 
            this.dialogBottomRadioButton.AutoSize = true;
            this.dialogBottomRadioButton.Checked = true;
            this.dialogBottomRadioButton.Location = new System.Drawing.Point(18, 19);
            this.dialogBottomRadioButton.Name = "dialogBottomRadioButton";
            this.dialogBottomRadioButton.Size = new System.Drawing.Size(150, 17);
            this.dialogBottomRadioButton.TabIndex = 27;
            this.dialogBottomRadioButton.TabStop = true;
            this.dialogBottomRadioButton.Text = "Dialog With Button Bottom";
            this.dialogBottomRadioButton.UseVisualStyleBackColor = true;
            this.dialogBottomRadioButton.CheckedChanged += new System.EventHandler(this.dialogBottomRadioButton_CheckedChanged);
            // 
            // selectGroupBox
            // 
            this.selectGroupBox.Controls.Add(this.widgetRadioButton);
            this.selectGroupBox.Controls.Add(this.mainWindowRadioButton);
            this.selectGroupBox.Controls.Add(this.dialogRightRadioButton);
            this.selectGroupBox.Controls.Add(this.dialogBottomRadioButton);
            this.selectGroupBox.Location = new System.Drawing.Point(12, 68);
            this.selectGroupBox.Name = "selectGroupBox";
            this.selectGroupBox.Size = new System.Drawing.Size(190, 247);
            this.selectGroupBox.TabIndex = 31;
            this.selectGroupBox.TabStop = false;
            this.selectGroupBox.Text = "Select need form:";
            // 
            // widgetRadioButton
            // 
            this.widgetRadioButton.AutoSize = true;
            this.widgetRadioButton.Location = new System.Drawing.Point(18, 88);
            this.widgetRadioButton.Name = "widgetRadioButton";
            this.widgetRadioButton.Size = new System.Drawing.Size(59, 17);
            this.widgetRadioButton.TabIndex = 30;
            this.widgetRadioButton.TabStop = true;
            this.widgetRadioButton.Text = "Widget";
            this.widgetRadioButton.UseVisualStyleBackColor = true;
            this.widgetRadioButton.CheckedChanged += new System.EventHandler(this.widgetRadioButton_CheckedChanged);
            // 
            // mainWindowRadioButton
            // 
            this.mainWindowRadioButton.AutoSize = true;
            this.mainWindowRadioButton.Location = new System.Drawing.Point(18, 65);
            this.mainWindowRadioButton.Name = "mainWindowRadioButton";
            this.mainWindowRadioButton.Size = new System.Drawing.Size(90, 17);
            this.mainWindowRadioButton.TabIndex = 29;
            this.mainWindowRadioButton.TabStop = true;
            this.mainWindowRadioButton.Text = "Main Window";
            this.mainWindowRadioButton.UseVisualStyleBackColor = true;
            this.mainWindowRadioButton.CheckedChanged += new System.EventHandler(this.mainWindowRadioButton_CheckedChanged);
            // 
            // dialogRightRadioButton
            // 
            this.dialogRightRadioButton.AutoSize = true;
            this.dialogRightRadioButton.Location = new System.Drawing.Point(18, 42);
            this.dialogRightRadioButton.Name = "dialogRightRadioButton";
            this.dialogRightRadioButton.Size = new System.Drawing.Size(142, 17);
            this.dialogRightRadioButton.TabIndex = 28;
            this.dialogRightRadioButton.TabStop = true;
            this.dialogRightRadioButton.Text = "Dialog With Button Right";
            this.dialogRightRadioButton.UseVisualStyleBackColor = true;
            this.dialogRightRadioButton.CheckedChanged += new System.EventHandler(this.dialogRightRadioButton_CheckedChanged);
            // 
            // previewGroupBox
            // 
            this.previewGroupBox.Controls.Add(this.previewPictureBox);
            this.previewGroupBox.Location = new System.Drawing.Point(208, 68);
            this.previewGroupBox.Name = "previewGroupBox";
            this.previewGroupBox.Size = new System.Drawing.Size(325, 302);
            this.previewGroupBox.TabIndex = 32;
            this.previewGroupBox.TabStop = false;
            this.previewGroupBox.Text = "Preview:";
            // 
            // backButton
            // 
            this.backButton.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.backButton.Location = new System.Drawing.Point(221, 433);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(100, 23);
            this.backButton.TabIndex = 35;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(433, 433);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 23);
            this.cancelButton.TabIndex = 34;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // finishButton
            // 
            this.finishButton.Location = new System.Drawing.Point(327, 433);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(100, 23);
            this.finishButton.TabIndex = 33;
            this.finishButton.Text = "Finish";
            this.finishButton.UseVisualStyleBackColor = true;
            this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(449, 378);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(84, 23);
            this.browseButton.TabIndex = 40;
            this.browseButton.Text = "Browse...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(9, 362);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(51, 13);
            this.locationLabel.TabIndex = 39;
            this.locationLabel.Text = "Location:";
            // 
            // locationTextBox
            // 
            this.locationTextBox.Location = new System.Drawing.Point(12, 380);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(431, 20);
            this.locationTextBox.TabIndex = 38;
            this.locationTextBox.TextChanged += new System.EventHandler(this.locationTextBox_TextChanged);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(12, 338);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(141, 20);
            this.nameTextBox.TabIndex = 36;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(9, 322);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(62, 13);
            this.nameLabel.TabIndex = 37;
            this.nameLabel.Text = "Form name:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // QtFormForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 464);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.locationLabel);
            this.Controls.Add(this.locationTextBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.finishButton);
            this.Controls.Add(this.previewGroupBox);
            this.Controls.Add(this.selectGroupBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.qtPictureBox);
            this.Name = "QtFormForm";
            this.Text = "QtFormForm";
            ((System.ComponentModel.ISupportInitialize)(this.qtPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).EndInit();
            this.selectGroupBox.ResumeLayout(false);
            this.selectGroupBox.PerformLayout();
            this.previewGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox qtPictureBox;
        private System.Windows.Forms.PictureBox previewPictureBox;
        private System.Windows.Forms.RadioButton dialogBottomRadioButton;
        private System.Windows.Forms.GroupBox selectGroupBox;
        private System.Windows.Forms.RadioButton widgetRadioButton;
        private System.Windows.Forms.RadioButton mainWindowRadioButton;
        private System.Windows.Forms.RadioButton dialogRightRadioButton;
        private System.Windows.Forms.GroupBox previewGroupBox;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button finishButton;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.ToolTip nameToolTip;
        private System.Windows.Forms.ToolTip locationToolTip;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}