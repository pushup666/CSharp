using System.Windows.Forms;

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
            this.buttonRemoveBlankLine = new System.Windows.Forms.Button();
            this.buttonAddBlankLine = new System.Windows.Forms.Button();
            this.buttonShort2Long = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonTrimLine = new System.Windows.Forms.Button();
            this.richTextBoxMain = new System.Windows.Forms.RichTextBox();
            this.checkBoxUTF8Read = new System.Windows.Forms.CheckBox();
            this.buttonAddHeadBlank = new System.Windows.Forms.Button();
            this.buttonLong2Short = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonRemoveBlankLine
            // 
            this.buttonRemoveBlankLine.Location = new System.Drawing.Point(194, 12);
            this.buttonRemoveBlankLine.Name = "buttonRemoveBlankLine";
            this.buttonRemoveBlankLine.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveBlankLine.TabIndex = 1;
            this.buttonRemoveBlankLine.Text = "去空白行";
            this.buttonRemoveBlankLine.UseVisualStyleBackColor = true;
            this.buttonRemoveBlankLine.Click += new System.EventHandler(this.buttonRemoveBlankLine_Click);
            // 
            // buttonAddBlankLine
            // 
            this.buttonAddBlankLine.Location = new System.Drawing.Point(275, 12);
            this.buttonAddBlankLine.Name = "buttonAddBlankLine";
            this.buttonAddBlankLine.Size = new System.Drawing.Size(75, 23);
            this.buttonAddBlankLine.TabIndex = 2;
            this.buttonAddBlankLine.Text = "增空白行";
            this.buttonAddBlankLine.UseVisualStyleBackColor = true;
            this.buttonAddBlankLine.Click += new System.EventHandler(this.buttonAddBlankLine_Click);
            // 
            // buttonShort2Long
            // 
            this.buttonShort2Long.Location = new System.Drawing.Point(378, 12);
            this.buttonShort2Long.Name = "buttonShort2Long";
            this.buttonShort2Long.Size = new System.Drawing.Size(75, 23);
            this.buttonShort2Long.TabIndex = 4;
            this.buttonShort2Long.Text = "短行变长行";
            this.buttonShort2Long.UseVisualStyleBackColor = true;
            this.buttonShort2Long.Click += new System.EventHandler(this.buttonShort2Long_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(969, 12);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonTrimLine
            // 
            this.buttonTrimLine.Location = new System.Drawing.Point(12, 12);
            this.buttonTrimLine.Name = "buttonTrimLine";
            this.buttonTrimLine.Size = new System.Drawing.Size(75, 23);
            this.buttonTrimLine.TabIndex = 6;
            this.buttonTrimLine.Text = "去首尾空白";
            this.buttonTrimLine.UseVisualStyleBackColor = true;
            this.buttonTrimLine.Click += new System.EventHandler(this.buttonTrimLine_Click);
            // 
            // richTextBoxMain
            // 
            this.richTextBoxMain.AllowDrop = true;
            this.richTextBoxMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxMain.Location = new System.Drawing.Point(12, 41);
            this.richTextBoxMain.Name = "richTextBoxMain";
            this.richTextBoxMain.Size = new System.Drawing.Size(1032, 562);
            this.richTextBoxMain.TabIndex = 7;
            this.richTextBoxMain.Text = "";
            this.richTextBoxMain.DragDrop += new System.Windows.Forms.DragEventHandler(this.richTextBoxMain_DragDrop);
            this.richTextBoxMain.DragEnter += new System.Windows.Forms.DragEventHandler(this.richTextBoxMain_DragEnter);
            // 
            // checkBoxUTF8Read
            // 
            this.checkBoxUTF8Read.AutoSize = true;
            this.checkBoxUTF8Read.Location = new System.Drawing.Point(587, 16);
            this.checkBoxUTF8Read.Name = "checkBoxUTF8Read";
            this.checkBoxUTF8Read.Size = new System.Drawing.Size(66, 16);
            this.checkBoxUTF8Read.TabIndex = 8;
            this.checkBoxUTF8Read.Text = "UTF-8读";
            this.checkBoxUTF8Read.UseVisualStyleBackColor = true;
            // 
            // buttonAddHeadBlank
            // 
            this.buttonAddHeadBlank.Location = new System.Drawing.Point(93, 12);
            this.buttonAddHeadBlank.Name = "buttonAddHeadBlank";
            this.buttonAddHeadBlank.Size = new System.Drawing.Size(75, 23);
            this.buttonAddHeadBlank.TabIndex = 9;
            this.buttonAddHeadBlank.Text = "加首空白";
            this.buttonAddHeadBlank.UseVisualStyleBackColor = true;
            this.buttonAddHeadBlank.Click += new System.EventHandler(this.buttonAddHeadBlank_Click);
            // 
            // buttonLong2Short
            // 
            this.buttonLong2Short.Location = new System.Drawing.Point(459, 12);
            this.buttonLong2Short.Name = "buttonLong2Short";
            this.buttonLong2Short.Size = new System.Drawing.Size(75, 23);
            this.buttonLong2Short.TabIndex = 10;
            this.buttonLong2Short.Text = "长行变短行";
            this.buttonLong2Short.UseVisualStyleBackColor = true;
            this.buttonLong2Short.Click += new System.EventHandler(this.buttonLong2Short_Click);
            // 
            // TextEditer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 618);
            this.Controls.Add(this.buttonLong2Short);
            this.Controls.Add(this.buttonAddHeadBlank);
            this.Controls.Add(this.checkBoxUTF8Read);
            this.Controls.Add(this.richTextBoxMain);
            this.Controls.Add(this.buttonTrimLine);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonShort2Long);
            this.Controls.Add(this.buttonAddBlankLine);
            this.Controls.Add(this.buttonRemoveBlankLine);
            this.Name = "TextEditer";
            this.Text = "TextEditer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRemoveBlankLine;
        private System.Windows.Forms.Button buttonAddBlankLine;
        private System.Windows.Forms.Button buttonShort2Long;
        private Button buttonSave;
        private Button buttonTrimLine;
        private RichTextBox richTextBoxMain;
        private CheckBox checkBoxUTF8Read;
        private Button buttonAddHeadBlank;
        private Button buttonLong2Short;
    }
}

