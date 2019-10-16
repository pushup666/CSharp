namespace RegExpTest
{
    partial class RegExpTest
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panelText = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.buttonRegex = new System.Windows.Forms.Button();
            this.buttonPreProcess = new System.Windows.Forms.Button();
            this.panelText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelText
            // 
            this.panelText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelText.Controls.Add(this.splitContainer1);
            this.panelText.Location = new System.Drawing.Point(12, 12);
            this.panelText.Name = "panelText";
            this.panelText.Size = new System.Drawing.Size(1127, 411);
            this.panelText.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.richTextBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1127, 411);
            this.splitContainer1.SplitterDistance = 560;
            this.splitContainer1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(560, 411);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.Location = new System.Drawing.Point(0, 0);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(563, 411);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "";
            // 
            // buttonRegex
            // 
            this.buttonRegex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRegex.Location = new System.Drawing.Point(119, 437);
            this.buttonRegex.Name = "buttonRegex";
            this.buttonRegex.Size = new System.Drawing.Size(75, 23);
            this.buttonRegex.TabIndex = 3;
            this.buttonRegex.Text = "Regex";
            this.buttonRegex.UseVisualStyleBackColor = true;
            this.buttonRegex.Click += new System.EventHandler(this.ButtonRegex_Click);
            // 
            // buttonPreProcess
            // 
            this.buttonPreProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPreProcess.Location = new System.Drawing.Point(12, 437);
            this.buttonPreProcess.Name = "buttonPreProcess";
            this.buttonPreProcess.Size = new System.Drawing.Size(75, 23);
            this.buttonPreProcess.TabIndex = 4;
            this.buttonPreProcess.Text = "PreProcess";
            this.buttonPreProcess.UseVisualStyleBackColor = true;
            this.buttonPreProcess.Click += new System.EventHandler(this.ButtonPreProcess_Click);
            // 
            // RegExpTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 472);
            this.Controls.Add(this.buttonPreProcess);
            this.Controls.Add(this.buttonRegex);
            this.Controls.Add(this.panelText);
            this.Name = "RegExpTest";
            this.Text = "RegExpTest";
            this.panelText.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelText;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button buttonRegex;
        private System.Windows.Forms.Button buttonPreProcess;
    }
}

