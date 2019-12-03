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
            this.richTextBoxCmdOutput = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBoxCmdInput
            // 
            this.richTextBoxCmdInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxCmdInput.Location = new System.Drawing.Point(12, 12);
            this.richTextBoxCmdInput.Name = "richTextBoxCmdInput";
            this.richTextBoxCmdInput.Size = new System.Drawing.Size(662, 367);
            this.richTextBoxCmdInput.TabIndex = 0;
            this.richTextBoxCmdInput.Text = "";
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.Location = new System.Drawing.Point(680, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelCount
            // 
            this.labelCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(680, 60);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(35, 12);
            this.labelCount.TabIndex = 2;
            this.labelCount.Text = "0 / 0";
            // 
            // buttonGenCMD
            // 
            this.buttonGenCMD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGenCMD.Location = new System.Drawing.Point(680, 532);
            this.buttonGenCMD.Name = "buttonGenCMD";
            this.buttonGenCMD.Size = new System.Drawing.Size(75, 23);
            this.buttonGenCMD.TabIndex = 3;
            this.buttonGenCMD.Text = "GenCMD";
            this.buttonGenCMD.UseVisualStyleBackColor = true;
            this.buttonGenCMD.Click += new System.EventHandler(this.ButtonGenCMD_Click);
            // 
            // richTextBoxCmdOutput
            // 
            this.richTextBoxCmdOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxCmdOutput.Location = new System.Drawing.Point(12, 395);
            this.richTextBoxCmdOutput.Name = "richTextBoxCmdOutput";
            this.richTextBoxCmdOutput.Size = new System.Drawing.Size(662, 160);
            this.richTextBoxCmdOutput.TabIndex = 4;
            this.richTextBoxCmdOutput.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 567);
            this.Controls.Add(this.richTextBoxCmdOutput);
            this.Controls.Add(this.buttonGenCMD);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.richTextBoxCmdInput);
            this.Name = "Main";
            this.Text = "MultipleCMD";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxCmdInput;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Button buttonGenCMD;
        private System.Windows.Forms.RichTextBox richTextBoxCmdOutput;
    }
}