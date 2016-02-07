namespace QtWizard
{
    partial class QtClassForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QtClassForm));
            this.finishButton = new System.Windows.Forms.Button();
            this.classTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.hppFileLabel = new System.Windows.Forms.Label();
            this.hppFileTextBox = new System.Windows.Forms.TextBox();
            this.cppFileLabel = new System.Windows.Forms.Label();
            this.cppFileTextBox = new System.Windows.Forms.TextBox();
            this.baseClassLabel = new System.Windows.Forms.Label();
            this.baseClassTextBox = new System.Windows.Forms.TextBox();
            this.constructorLabel = new System.Windows.Forms.Label();
            this.insertQObjectCheckBox = new System.Windows.Forms.CheckBox();
            this.lowerCaseCheckBox = new System.Windows.Forms.CheckBox();
            this.signatureComboBox = new System.Windows.Forms.ComboBox();
            this.locationLabel = new System.Windows.Forms.Label();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.qtPictureBox = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.uiFileLabel = new System.Windows.Forms.Label();
            this.uiFileTextBox = new System.Windows.Forms.TextBox();
            this.selectClassTypeLabel = new System.Windows.Forms.Label();
            this.normalClassRadioButton = new System.Windows.Forms.RadioButton();
            this.guiClassRadioButton = new System.Windows.Forms.RadioButton();
            this.uiInitTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.internalUiButton = new System.Windows.Forms.RadioButton();
            this.inheritUiButton = new System.Windows.Forms.RadioButton();
            this.pointerUiButton = new System.Windows.Forms.RadioButton();
            this.backButton = new System.Windows.Forms.Button();
            this.hppToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cppToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.uiToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.classToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.locationToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.includeGuardCheckBox = new System.Windows.Forms.CheckBox();
            this.valueLabel = new System.Windows.Forms.Label();
            this.defaultValueComboBox = new System.Windows.Forms.ComboBox();
            this.baseClassToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.qtPictureBox)).BeginInit();
            this.uiInitTypeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // finishButton
            // 
            this.finishButton.Location = new System.Drawing.Point(336, 379);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(100, 23);
            this.finishButton.TabIndex = 0;
            this.finishButton.Text = "Finish";
            this.finishButton.UseVisualStyleBackColor = true;
            this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
            // 
            // classTextBox
            // 
            this.classTextBox.Location = new System.Drawing.Point(15, 134);
            this.classTextBox.Name = "classTextBox";
            this.classTextBox.Size = new System.Drawing.Size(141, 20);
            this.classTextBox.TabIndex = 1;
            this.classTextBox.TextChanged += new System.EventHandler(this.classTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Class name:";
            // 
            // hppFileLabel
            // 
            this.hppFileLabel.AutoSize = true;
            this.hppFileLabel.Location = new System.Drawing.Point(159, 118);
            this.hppFileLabel.Name = "hppFileLabel";
            this.hppFileLabel.Size = new System.Drawing.Size(47, 13);
            this.hppFileLabel.TabIndex = 4;
            this.hppFileLabel.Text = ".hpp file:";
            // 
            // hppFileTextBox
            // 
            this.hppFileTextBox.Location = new System.Drawing.Point(162, 134);
            this.hppFileTextBox.Name = "hppFileTextBox";
            this.hppFileTextBox.Size = new System.Drawing.Size(141, 20);
            this.hppFileTextBox.TabIndex = 3;
            this.hppFileTextBox.TextChanged += new System.EventHandler(this.hppFileTextBox_TextChanged);
            // 
            // cppFileLabel
            // 
            this.cppFileLabel.AutoSize = true;
            this.cppFileLabel.Location = new System.Drawing.Point(306, 118);
            this.cppFileLabel.Name = "cppFileLabel";
            this.cppFileLabel.Size = new System.Drawing.Size(47, 13);
            this.cppFileLabel.TabIndex = 6;
            this.cppFileLabel.Text = ".cpp file:";
            // 
            // cppFileTextBox
            // 
            this.cppFileTextBox.Location = new System.Drawing.Point(309, 134);
            this.cppFileTextBox.Name = "cppFileTextBox";
            this.cppFileTextBox.Size = new System.Drawing.Size(141, 20);
            this.cppFileTextBox.TabIndex = 5;
            this.cppFileTextBox.TextChanged += new System.EventHandler(this.cppFileTextBox_TextChanged);
            // 
            // baseClassLabel
            // 
            this.baseClassLabel.AutoSize = true;
            this.baseClassLabel.Location = new System.Drawing.Point(12, 161);
            this.baseClassLabel.Name = "baseClassLabel";
            this.baseClassLabel.Size = new System.Drawing.Size(61, 13);
            this.baseClassLabel.TabIndex = 8;
            this.baseClassLabel.Text = "Base class:";
            // 
            // baseClassTextBox
            // 
            this.baseClassTextBox.Location = new System.Drawing.Point(15, 177);
            this.baseClassTextBox.Name = "baseClassTextBox";
            this.baseClassTextBox.Size = new System.Drawing.Size(141, 20);
            this.baseClassTextBox.TabIndex = 7;
            this.baseClassTextBox.Text = "QObject";
            this.baseClassTextBox.TextChanged += new System.EventHandler(this.baseClassTextBox_TextChanged);
            // 
            // constructorLabel
            // 
            this.constructorLabel.AutoSize = true;
            this.constructorLabel.Location = new System.Drawing.Point(12, 205);
            this.constructorLabel.Name = "constructorLabel";
            this.constructorLabel.Size = new System.Drawing.Size(110, 13);
            this.constructorLabel.TabIndex = 10;
            this.constructorLabel.Text = "Constructor signature:";
            // 
            // insertQObjectCheckBox
            // 
            this.insertQObjectCheckBox.AutoSize = true;
            this.insertQObjectCheckBox.Checked = true;
            this.insertQObjectCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.insertQObjectCheckBox.Location = new System.Drawing.Point(333, 177);
            this.insertQObjectCheckBox.Name = "insertQObjectCheckBox";
            this.insertQObjectCheckBox.Size = new System.Drawing.Size(110, 17);
            this.insertQObjectCheckBox.TabIndex = 11;
            this.insertQObjectCheckBox.Text = "Insert Q_OBJECT";
            this.insertQObjectCheckBox.UseVisualStyleBackColor = true;
            // 
            // lowerCaseCheckBox
            // 
            this.lowerCaseCheckBox.AutoSize = true;
            this.lowerCaseCheckBox.Checked = true;
            this.lowerCaseCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lowerCaseCheckBox.Location = new System.Drawing.Point(333, 201);
            this.lowerCaseCheckBox.Name = "lowerCaseCheckBox";
            this.lowerCaseCheckBox.Size = new System.Drawing.Size(131, 17);
            this.lowerCaseCheckBox.TabIndex = 12;
            this.lowerCaseCheckBox.Text = "Lower case file names";
            this.lowerCaseCheckBox.UseVisualStyleBackColor = true;
            this.lowerCaseCheckBox.CheckedChanged += new System.EventHandler(this.lowerCaseCheckBox_CheckedChanged);
            // 
            // signatureComboBox
            // 
            this.signatureComboBox.FormattingEnabled = true;
            this.signatureComboBox.Items.AddRange(new object[] {
            "QObject * parent",
            "QWidget * parent",
            " "});
            this.signatureComboBox.Location = new System.Drawing.Point(15, 224);
            this.signatureComboBox.Name = "signatureComboBox";
            this.signatureComboBox.Size = new System.Drawing.Size(141, 21);
            this.signatureComboBox.TabIndex = 13;
            this.signatureComboBox.Text = "QObject * parent";
            this.signatureComboBox.EnabledChanged += new System.EventHandler(this.signatureComboBox_EnabledChanged);
            this.signatureComboBox.TextChanged += new System.EventHandler(this.signatureComboBox_TextChanged);
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(12, 253);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(51, 13);
            this.locationLabel.TabIndex = 15;
            this.locationLabel.Text = "Location:";
            // 
            // locationTextBox
            // 
            this.locationTextBox.Location = new System.Drawing.Point(15, 269);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(437, 20);
            this.locationTextBox.TabIndex = 14;
            this.locationTextBox.TextChanged += new System.EventHandler(this.locationTextBox_TextChanged);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(458, 267);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(84, 23);
            this.browseButton.TabIndex = 16;
            this.browseButton.Text = "Browse...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // qtPictureBox
            // 
            this.qtPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.qtPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.qtPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("qtPictureBox.Image")));
            this.qtPictureBox.Location = new System.Drawing.Point(488, -2);
            this.qtPictureBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.qtPictureBox.Name = "qtPictureBox";
            this.qtPictureBox.Size = new System.Drawing.Size(71, 67);
            this.qtPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.qtPictureBox.TabIndex = 17;
            this.qtPictureBox.TabStop = false;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(-3, -2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(495, 31);
            this.label7.TabIndex = 18;
            this.label7.Text = "   Welcome to the Qt Class Wizard:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(2, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(490, 36);
            this.label8.TabIndex = 19;
            this.label8.Text = "       This wizard will add a new Qt Class to your project. The wizard creates ne" +
    "ed files for our class.";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(442, 379);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 23);
            this.cancelButton.TabIndex = 20;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(0, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(555, 2);
            this.label2.TabIndex = 21;
            // 
            // uiFileLabel
            // 
            this.uiFileLabel.AutoSize = true;
            this.uiFileLabel.Enabled = false;
            this.uiFileLabel.Location = new System.Drawing.Point(159, 161);
            this.uiFileLabel.Name = "uiFileLabel";
            this.uiFileLabel.Size = new System.Drawing.Size(37, 13);
            this.uiFileLabel.TabIndex = 24;
            this.uiFileLabel.Text = ".ui file:";
            // 
            // uiFileTextBox
            // 
            this.uiFileTextBox.Enabled = false;
            this.uiFileTextBox.Location = new System.Drawing.Point(162, 177);
            this.uiFileTextBox.Name = "uiFileTextBox";
            this.uiFileTextBox.Size = new System.Drawing.Size(141, 20);
            this.uiFileTextBox.TabIndex = 23;
            this.uiFileTextBox.TextChanged += new System.EventHandler(this.uiFileTextBox_TextChanged);
            // 
            // selectClassTypeLabel
            // 
            this.selectClassTypeLabel.AutoSize = true;
            this.selectClassTypeLabel.Location = new System.Drawing.Point(12, 85);
            this.selectClassTypeLabel.Name = "selectClassTypeLabel";
            this.selectClassTypeLabel.Size = new System.Drawing.Size(90, 13);
            this.selectClassTypeLabel.TabIndex = 25;
            this.selectClassTypeLabel.Text = "Select class type:";
            // 
            // normalClassRadioButton
            // 
            this.normalClassRadioButton.AutoSize = true;
            this.normalClassRadioButton.Checked = true;
            this.normalClassRadioButton.Location = new System.Drawing.Point(120, 83);
            this.normalClassRadioButton.Name = "normalClassRadioButton";
            this.normalClassRadioButton.Size = new System.Drawing.Size(86, 17);
            this.normalClassRadioButton.TabIndex = 26;
            this.normalClassRadioButton.TabStop = true;
            this.normalClassRadioButton.Text = "Normal Class";
            this.normalClassRadioButton.UseVisualStyleBackColor = true;
            // 
            // guiClassRadioButton
            // 
            this.guiClassRadioButton.AutoSize = true;
            this.guiClassRadioButton.Location = new System.Drawing.Point(212, 83);
            this.guiClassRadioButton.Name = "guiClassRadioButton";
            this.guiClassRadioButton.Size = new System.Drawing.Size(69, 17);
            this.guiClassRadioButton.TabIndex = 27;
            this.guiClassRadioButton.Text = "Gui Class";
            this.guiClassRadioButton.UseVisualStyleBackColor = true;
            this.guiClassRadioButton.CheckedChanged += new System.EventHandler(this.guiClassRadioButton_CheckedChanged);
            // 
            // uiInitTypeGroupBox
            // 
            this.uiInitTypeGroupBox.Controls.Add(this.internalUiButton);
            this.uiInitTypeGroupBox.Controls.Add(this.inheritUiButton);
            this.uiInitTypeGroupBox.Controls.Add(this.pointerUiButton);
            this.uiInitTypeGroupBox.Enabled = false;
            this.uiInitTypeGroupBox.Location = new System.Drawing.Point(287, 68);
            this.uiInitTypeGroupBox.Name = "uiInitTypeGroupBox";
            this.uiInitTypeGroupBox.Size = new System.Drawing.Size(195, 38);
            this.uiInitTypeGroupBox.TabIndex = 28;
            this.uiInitTypeGroupBox.TabStop = false;
            this.uiInitTypeGroupBox.Text = "Ui Init Type:";
            // 
            // internalUiButton
            // 
            this.internalUiButton.AutoSize = true;
            this.internalUiButton.Checked = true;
            this.internalUiButton.Location = new System.Drawing.Point(6, 15);
            this.internalUiButton.Name = "internalUiButton";
            this.internalUiButton.Size = new System.Drawing.Size(60, 17);
            this.internalUiButton.TabIndex = 31;
            this.internalUiButton.TabStop = true;
            this.internalUiButton.Text = "Internal";
            this.internalUiButton.UseVisualStyleBackColor = true;
            // 
            // inheritUiButton
            // 
            this.inheritUiButton.AutoSize = true;
            this.inheritUiButton.Location = new System.Drawing.Point(72, 15);
            this.inheritUiButton.Name = "inheritUiButton";
            this.inheritUiButton.Size = new System.Drawing.Size(54, 17);
            this.inheritUiButton.TabIndex = 30;
            this.inheritUiButton.Text = "Inherit";
            this.inheritUiButton.UseVisualStyleBackColor = true;
            // 
            // pointerUiButton
            // 
            this.pointerUiButton.AutoSize = true;
            this.pointerUiButton.Location = new System.Drawing.Point(132, 15);
            this.pointerUiButton.Name = "pointerUiButton";
            this.pointerUiButton.Size = new System.Drawing.Size(58, 17);
            this.pointerUiButton.TabIndex = 29;
            this.pointerUiButton.Text = "Pointer";
            this.pointerUiButton.UseVisualStyleBackColor = true;
            // 
            // backButton
            // 
            this.backButton.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.backButton.Location = new System.Drawing.Point(230, 379);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(100, 23);
            this.backButton.TabIndex = 29;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // includeGuardCheckBox
            // 
            this.includeGuardCheckBox.AutoSize = true;
            this.includeGuardCheckBox.Location = new System.Drawing.Point(333, 224);
            this.includeGuardCheckBox.Name = "includeGuardCheckBox";
            this.includeGuardCheckBox.Size = new System.Drawing.Size(112, 17);
            this.includeGuardCheckBox.TabIndex = 30;
            this.includeGuardCheckBox.Text = "Add include guard";
            this.includeGuardCheckBox.UseVisualStyleBackColor = true;
            // 
            // valueLabel
            // 
            this.valueLabel.AutoSize = true;
            this.valueLabel.Location = new System.Drawing.Point(159, 205);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.Size = new System.Drawing.Size(73, 13);
            this.valueLabel.TabIndex = 31;
            this.valueLabel.Text = "Default value:";
            // 
            // defaultValueComboBox
            // 
            this.defaultValueComboBox.FormattingEnabled = true;
            this.defaultValueComboBox.Items.AddRange(new object[] {
            "Q_NULLPTR",
            "0",
            " "});
            this.defaultValueComboBox.Location = new System.Drawing.Point(162, 224);
            this.defaultValueComboBox.Name = "defaultValueComboBox";
            this.defaultValueComboBox.Size = new System.Drawing.Size(141, 21);
            this.defaultValueComboBox.TabIndex = 32;
            this.defaultValueComboBox.Text = "Q_NULLPTR";
            // 
            // QtClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 413);
            this.Controls.Add(this.defaultValueComboBox);
            this.Controls.Add(this.valueLabel);
            this.Controls.Add(this.includeGuardCheckBox);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.uiInitTypeGroupBox);
            this.Controls.Add(this.guiClassRadioButton);
            this.Controls.Add(this.normalClassRadioButton);
            this.Controls.Add(this.selectClassTypeLabel);
            this.Controls.Add(this.uiFileLabel);
            this.Controls.Add(this.uiFileTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.qtPictureBox);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.locationLabel);
            this.Controls.Add(this.locationTextBox);
            this.Controls.Add(this.signatureComboBox);
            this.Controls.Add(this.lowerCaseCheckBox);
            this.Controls.Add(this.insertQObjectCheckBox);
            this.Controls.Add(this.constructorLabel);
            this.Controls.Add(this.baseClassLabel);
            this.Controls.Add(this.baseClassTextBox);
            this.Controls.Add(this.cppFileLabel);
            this.Controls.Add(this.cppFileTextBox);
            this.Controls.Add(this.hppFileLabel);
            this.Controls.Add(this.hppFileTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.classTextBox);
            this.Controls.Add(this.finishButton);
            this.Name = "QtClassForm";
            this.Text = "Qt Class";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserInputForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.qtPictureBox)).EndInit();
            this.uiInitTypeGroupBox.ResumeLayout(false);
            this.uiInitTypeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button finishButton;
        private System.Windows.Forms.TextBox classTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label hppFileLabel;
        private System.Windows.Forms.TextBox hppFileTextBox;
        private System.Windows.Forms.Label cppFileLabel;
        private System.Windows.Forms.TextBox cppFileTextBox;
        private System.Windows.Forms.Label baseClassLabel;
        private System.Windows.Forms.TextBox baseClassTextBox;
        private System.Windows.Forms.Label constructorLabel;
        private System.Windows.Forms.CheckBox insertQObjectCheckBox;
        private System.Windows.Forms.CheckBox lowerCaseCheckBox;
        private System.Windows.Forms.ComboBox signatureComboBox;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.PictureBox qtPictureBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label uiFileLabel;
        private System.Windows.Forms.TextBox uiFileTextBox;
        private System.Windows.Forms.Label selectClassTypeLabel;
        private System.Windows.Forms.RadioButton normalClassRadioButton;
        private System.Windows.Forms.RadioButton guiClassRadioButton;
        private System.Windows.Forms.GroupBox uiInitTypeGroupBox;
        private System.Windows.Forms.RadioButton internalUiButton;
        private System.Windows.Forms.RadioButton inheritUiButton;
        private System.Windows.Forms.RadioButton pointerUiButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.ToolTip hppToolTip;
        private System.Windows.Forms.ToolTip cppToolTip;
        private System.Windows.Forms.ToolTip uiToolTip;
        private System.Windows.Forms.ToolTip classToolTip;
        private System.Windows.Forms.ToolTip locationToolTip;
        private System.Windows.Forms.CheckBox includeGuardCheckBox;
        private System.Windows.Forms.Label valueLabel;
        private System.Windows.Forms.ComboBox defaultValueComboBox;
        private System.Windows.Forms.ToolTip baseClassToolTip;
    }
}