namespace bitcoin_GenAddress
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            lblLoadedAddresses = new Label();
            label1 = new Label();
            cmbWordCount = new ComboBox();
            cmbLanguage = new ComboBox();
            txtReloadInterval = new TextBox();
            cmbProcessorCount = new ComboBox();
            btnStart = new Button();
            btnStop = new Button();
            LbFound = new Label();
            lblCount = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // lblLoadedAddresses
            // 
            lblLoadedAddresses.AutoSize = true;
            lblLoadedAddresses.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLoadedAddresses.Location = new Point(12, 9);
            lblLoadedAddresses.Name = "lblLoadedAddresses";
            lblLoadedAddresses.Size = new Size(163, 21);
            lblLoadedAddresses.TabIndex = 0;
            lblLoadedAddresses.Text = "Loaded Addresses: 0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 67);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 1;
            label1.Text = "Word count:";
            // 
            // cmbWordCount
            // 
            cmbWordCount.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbWordCount.FormattingEnabled = true;
            cmbWordCount.Location = new Point(126, 64);
            cmbWordCount.Name = "cmbWordCount";
            cmbWordCount.Size = new Size(121, 23);
            cmbWordCount.TabIndex = 2;
            // 
            // cmbLanguage
            // 
            cmbLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLanguage.FormattingEnabled = true;
            cmbLanguage.Location = new Point(126, 93);
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new Size(121, 23);
            cmbLanguage.TabIndex = 3;
            // 
            // txtReloadInterval
            // 
            txtReloadInterval.Location = new Point(126, 123);
            txtReloadInterval.Name = "txtReloadInterval";
            txtReloadInterval.Size = new Size(121, 23);
            txtReloadInterval.TabIndex = 4;
            // 
            // cmbProcessorCount
            // 
            cmbProcessorCount.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProcessorCount.FormattingEnabled = true;
            cmbProcessorCount.Location = new Point(125, 152);
            cmbProcessorCount.Name = "cmbProcessorCount";
            cmbProcessorCount.Size = new Size(121, 23);
            cmbProcessorCount.TabIndex = 5;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(12, 198);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(235, 23);
            btnStart.TabIndex = 6;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(12, 227);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(235, 23);
            btnStop.TabIndex = 7;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // LbFound
            // 
            LbFound.AutoSize = true;
            LbFound.Location = new Point(12, 288);
            LbFound.Name = "LbFound";
            LbFound.Size = new Size(119, 15);
            LbFound.TabIndex = 8;
            LbFound.Text = "Mnemonics Found: 0";
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Location = new Point(12, 262);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(52, 15);
            lblCount.TabIndex = 9;
            lblCount.Text = "Count: 0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 96);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 10;
            label2.Text = "Language:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 126);
            label3.Name = "label3";
            label3.Size = new Size(89, 15);
            label3.TabIndex = 11;
            label3.Text = "Reload address:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 155);
            label4.Name = "label4";
            label4.Size = new Size(72, 15);
            label4.TabIndex = 12;
            label4.Text = "Multithread:";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(258, 320);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblCount);
            Controls.Add(LbFound);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(cmbProcessorCount);
            Controls.Add(txtReloadInterval);
            Controls.Add(cmbLanguage);
            Controls.Add(cmbWordCount);
            Controls.Add(label1);
            Controls.Add(lblLoadedAddresses);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLoadedAddresses;
        private Label label1;
        private ComboBox cmbWordCount;
        private ComboBox cmbLanguage;
        private TextBox txtReloadInterval;
        private ComboBox cmbProcessorCount;
        private Button btnStart;
        private Button btnStop;
        private Label LbFound;
        private Label lblCount;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
