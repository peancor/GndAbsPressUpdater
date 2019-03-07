namespace GndAbsPressUpdater
{
    partial class PluginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginForm));
            this.label1 = new System.Windows.Forms.Label();
            this.mComPortTextBox = new System.Windows.Forms.TextBox();
            this.mSaveButton = new System.Windows.Forms.Button();
            this.mMessagesListBox = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mEdronicalLinkLabel = new System.Windows.Forms.LinkLabel();
            this.mUpdatePeriodTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mIsEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.mDeltaPressureMax = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mGroundUnitsComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM port:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mComPortTextBox
            // 
            this.mComPortTextBox.Location = new System.Drawing.Point(115, 27);
            this.mComPortTextBox.Name = "mComPortTextBox";
            this.mComPortTextBox.Size = new System.Drawing.Size(100, 20);
            this.mComPortTextBox.TabIndex = 1;
            // 
            // mSaveButton
            // 
            this.mSaveButton.Location = new System.Drawing.Point(689, 426);
            this.mSaveButton.Name = "mSaveButton";
            this.mSaveButton.Size = new System.Drawing.Size(75, 23);
            this.mSaveButton.TabIndex = 2;
            this.mSaveButton.Text = "Save";
            this.mSaveButton.UseVisualStyleBackColor = true;
            // 
            // mMessagesListBox
            // 
            this.mMessagesListBox.FormattingEnabled = true;
            this.mMessagesListBox.Location = new System.Drawing.Point(12, 137);
            this.mMessagesListBox.Name = "mMessagesListBox";
            this.mMessagesListBox.Size = new System.Drawing.Size(752, 264);
            this.mMessagesListBox.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GndAbsPressUpdater.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(669, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // mEdronicalLinkLabel
            // 
            this.mEdronicalLinkLabel.AutoSize = true;
            this.mEdronicalLinkLabel.Location = new System.Drawing.Point(666, 115);
            this.mEdronicalLinkLabel.Name = "mEdronicalLinkLabel";
            this.mEdronicalLinkLabel.Size = new System.Drawing.Size(98, 13);
            this.mEdronicalLinkLabel.TabIndex = 5;
            this.mEdronicalLinkLabel.TabStop = true;
            this.mEdronicalLinkLabel.Text = "www.edronica.com";
            this.mEdronicalLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.MEdronicalLinkLabel_LinkClicked);
            // 
            // mUpdatePeriodTextBox
            // 
            this.mUpdatePeriodTextBox.Location = new System.Drawing.Point(115, 57);
            this.mUpdatePeriodTextBox.Name = "mUpdatePeriodTextBox";
            this.mUpdatePeriodTextBox.Size = new System.Drawing.Size(100, 20);
            this.mUpdatePeriodTextBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Update period (sg):";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mIsEnabledCheckBox
            // 
            this.mIsEnabledCheckBox.AutoSize = true;
            this.mIsEnabledCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mIsEnabledCheckBox.Location = new System.Drawing.Point(12, 84);
            this.mIsEnabledCheckBox.Name = "mIsEnabledCheckBox";
            this.mIsEnabledCheckBox.Size = new System.Drawing.Size(137, 28);
            this.mIsEnabledCheckBox.TabIndex = 9;
            this.mIsEnabledCheckBox.Text = "Is enabled?";
            this.mIsEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // mDeltaPressureMax
            // 
            this.mDeltaPressureMax.Location = new System.Drawing.Point(361, 23);
            this.mDeltaPressureMax.Name = "mDeltaPressureMax";
            this.mDeltaPressureMax.Size = new System.Drawing.Size(100, 20);
            this.mDeltaPressureMax.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(221, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Max pressure change (Pa):";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Ground pressure in: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mGroundUnitsComboBox
            // 
            this.mGroundUnitsComboBox.FormattingEnabled = true;
            this.mGroundUnitsComboBox.Location = new System.Drawing.Point(361, 55);
            this.mGroundUnitsComboBox.Name = "mGroundUnitsComboBox";
            this.mGroundUnitsComboBox.Size = new System.Drawing.Size(100, 21);
            this.mGroundUnitsComboBox.TabIndex = 13;
            // 
            // PluginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.mGroundUnitsComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mDeltaPressureMax);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mIsEnabledCheckBox);
            this.Controls.Add(this.mUpdatePeriodTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mEdronicalLinkLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.mMessagesListBox);
            this.Controls.Add(this.mSaveButton);
            this.Controls.Add(this.mComPortTextBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PluginForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Ground Absolute Pressure Updater";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ListBox mMessagesListBox;
        internal System.Windows.Forms.Button mSaveButton;
        internal System.Windows.Forms.TextBox mComPortTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel mEdronicalLinkLabel;
        internal System.Windows.Forms.TextBox mUpdatePeriodTextBox;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.CheckBox mIsEnabledCheckBox;
        internal System.Windows.Forms.TextBox mDeltaPressureMax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox mGroundUnitsComboBox;
    }
}