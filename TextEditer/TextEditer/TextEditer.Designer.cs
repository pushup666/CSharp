namespace TextEditer
{
    partial class TextEditer
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBoxMain = new System.Windows.Forms.RichTextBox();
            this.buttonRemoveBlankLine = new System.Windows.Forms.Button();
            this.buttonAddBlankLine = new System.Windows.Forms.Button();
            this.buttonRemoveBlank = new System.Windows.Forms.Button();
            this.buttonShort2Long = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBoxMain
            // 
            this.richTextBoxMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxMain.Location = new System.Drawing.Point(12, 41);
            this.richTextBoxMain.Name = "richTextBoxMain";
            this.richTextBoxMain.Size = new System.Drawing.Size(1032, 565);
            this.richTextBoxMain.TabIndex = 0;
            this.richTextBoxMain.Text = "";
            // 
            // buttonRemoveBlankLine
            // 
            this.buttonRemoveBlankLine.Location = new System.Drawing.Point(93, 12);
            this.buttonRemoveBlankLine.Name = "buttonRemoveBlankLine";
            this.buttonRemoveBlankLine.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveBlankLine.TabIndex = 1;
            this.buttonRemoveBlankLine.Text = "去空白行";
            this.buttonRemoveBlankLine.UseVisualStyleBackColor = true;
            this.buttonRemoveBlankLine.Click += new System.EventHandler(this.buttonRemoveBlankLine_Click);
            // 
            // buttonAddBlankLine
            // 
            this.buttonAddBlankLine.Location = new System.Drawing.Point(174, 12);
            this.buttonAddBlankLine.Name = "buttonAddBlankLine";
            this.buttonAddBlankLine.Size = new System.Drawing.Size(75, 23);
            this.buttonAddBlankLine.TabIndex = 2;
            this.buttonAddBlankLine.Text = "增空白行";
            this.buttonAddBlankLine.UseVisualStyleBackColor = true;
            this.buttonAddBlankLine.Click += new System.EventHandler(this.buttonAddBlankLine_Click);
            // 
            // buttonRemoveBlank
            // 
            this.buttonRemoveBlank.Location = new System.Drawing.Point(12, 12);
            this.buttonRemoveBlank.Name = "buttonRemoveBlank";
            this.buttonRemoveBlank.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveBlank.TabIndex = 3;
            this.buttonRemoveBlank.Text = "去空白";
            this.buttonRemoveBlank.UseVisualStyleBackColor = true;
            this.buttonRemoveBlank.Click += new System.EventHandler(this.buttonRemoveBlank_Click);
            // 
            // buttonShort2Long
            // 
            this.buttonShort2Long.Location = new System.Drawing.Point(255, 12);
            this.buttonShort2Long.Name = "buttonShort2Long";
            this.buttonShort2Long.Size = new System.Drawing.Size(75, 23);
            this.buttonShort2Long.TabIndex = 4;
            this.buttonShort2Long.Text = "短行变长行";
            this.buttonShort2Long.UseVisualStyleBackColor = true;
            this.buttonShort2Long.Click += new System.EventHandler(this.buttonShort2Long_Click);
            // 
            // TextEditer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 618);
            this.Controls.Add(this.buttonShort2Long);
            this.Controls.Add(this.buttonRemoveBlank);
            this.Controls.Add(this.buttonAddBlankLine);
            this.Controls.Add(this.buttonRemoveBlankLine);
            this.Controls.Add(this.richTextBoxMain);
            this.Name = "TextEditer";
            this.Text = "TextEditer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxMain;
        private System.Windows.Forms.Button buttonRemoveBlankLine;
        private System.Windows.Forms.Button buttonAddBlankLine;
        private System.Windows.Forms.Button buttonRemoveBlank;
        private System.Windows.Forms.Button buttonShort2Long;
    }
}

