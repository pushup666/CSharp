namespace MultipleCMD
{
    partial class Main
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
            this.richTextBoxCmdInput = new System.Windows.Forms.RichTextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelCount = new System.Windows.Forms.Label();
            this.buttonGenCMD = new System.Windows.Forms.Button();
            this.labelWorkingDirectory = new System.Windows.Forms.Label();
            this.textBoxWorkingDirectory = new System.Windows.Forms.TextBox();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.labelFileName = new System.Windows.Forms.Label();
            this.numericUpDownMaxThread = new System.Windows.Forms.NumericUpDown();
            this.labelMaxThread = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxThread)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBoxCmdInput
            // 
            this.richTextBoxCmdInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxCmdInput.DetectUrls = false;
            this.richTextBoxCmdInput.Location = new System.Drawing.Point(12, 12);
            this.richTextBoxCmdInput.Name = "richTextBoxCmdInput";
            this.richTextBoxCmdInput.Size = new System.Drawing.Size(695, 317);
            this.richTextBoxCmdInput.TabIndex = 0;
            this.richTextBoxCmdInput.Text = "";
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.Location = new System.Drawing.Point(713, 62);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(103, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelCount
            // 
            this.labelCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(713, 110);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(35, 12);
            this.labelCount.TabIndex = 2;
            this.labelCount.Text = "0 / 0";
            // 
            // buttonGenCMD
            // 
            this.buttonGenCMD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGenCMD.Location = new System.Drawing.Point(713, 12);
            this.buttonGenCMD.Name = "buttonGenCMD";
            this.buttonGenCMD.Size = new System.Drawing.Size(103, 23);
            this.buttonGenCMD.TabIndex = 3;
            this.buttonGenCMD.Text = "GenCMD";
            this.buttonGenCMD.UseVisualStyleBackColor = true;
            this.buttonGenCMD.Click += new System.EventHandler(this.ButtonGenCMD_Click);
            // 
            // labelWorkingDirectory
            // 
            this.labelWorkingDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelWorkingDirectory.AutoSize = true;
            this.labelWorkingDirectory.Location = new System.Drawing.Point(10, 343);
            this.labelWorkingDirectory.Name = "labelWorkingDirectory";
            this.labelWorkingDirectory.Size = new System.Drawing.Size(101, 12);
            this.labelWorkingDirectory.TabIndex = 4;
            this.labelWorkingDirectory.Text = "WorkingDirectory";
            // 
            // textBoxWorkingDirectory
            // 
            this.textBoxWorkingDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxWorkingDirectory.Location = new System.Drawing.Point(117, 340);
            this.textBoxWorkingDirectory.Name = "textBoxWorkingDirectory";
            this.textBoxWorkingDirectory.Size = new System.Drawing.Size(339, 21);
            this.textBoxWorkingDirectory.TabIndex = 5;
            this.textBoxWorkingDirectory.Text = "Z:\\you-get-develop";
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxFileName.Location = new System.Drawing.Point(117, 367);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(339, 21);
            this.textBoxFileName.TabIndex = 7;
            this.textBoxFileName.Text = "python";
            // 
            // labelFileName
            // 
            this.labelFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(10, 370);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(53, 12);
            this.labelFileName.TabIndex = 6;
            this.labelFileName.Text = "FileName";
            // 
            // numericUpDownMaxThread
            // 
            this.numericUpDownMaxThread.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownMaxThread.Location = new System.Drawing.Point(778, 145);
            this.numericUpDownMaxThread.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMaxThread.Name = "numericUpDownMaxThread";
            this.numericUpDownMaxThread.Size = new System.Drawing.Size(38, 21);
            this.numericUpDownMaxThread.TabIndex = 8;
            this.numericUpDownMaxThread.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // labelMaxThread
            // 
            this.labelMaxThread.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMaxThread.AutoSize = true;
            this.labelMaxThread.Location = new System.Drawing.Point(713, 149);
            this.labelMaxThread.Name = "labelMaxThread";
            this.labelMaxThread.Size = new System.Drawing.Size(59, 12);
            this.labelMaxThread.TabIndex = 9;
            this.labelMaxThread.Text = "MaxThread";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 411);
            this.Controls.Add(this.labelMaxThread);
            this.Controls.Add(this.numericUpDownMaxThread);
            this.Controls.Add(this.textBoxFileName);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.textBoxWorkingDirectory);
            this.Controls.Add(this.labelWorkingDirectory);
            this.Controls.Add(this.buttonGenCMD);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.richTextBoxCmdInput);
            this.Name = "Main";
            this.Text = "MultipleCMD";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxThread)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxCmdInput;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Button buttonGenCMD;
        private System.Windows.Forms.Label labelWorkingDirectory;
        private System.Windows.Forms.TextBox textBoxWorkingDirectory;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxThread;
        private System.Windows.Forms.Label labelMaxThread;
    }
}