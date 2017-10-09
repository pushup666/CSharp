namespace BatchTextEditer
{
    partial class BatchTextEditer
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
            this.richTextBoxInput = new System.Windows.Forms.RichTextBox();
            this.buttonNext = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonShort2Long = new System.Windows.Forms.Button();
            this.buttonRemoveBlank = new System.Windows.Forms.Button();
            this.buttonAddBlankLine = new System.Windows.Forms.Button();
            this.buttonRemoveBlankLine = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBoxInput
            // 
            this.richTextBoxInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxInput.Location = new System.Drawing.Point(12, 42);
            this.richTextBoxInput.Name = "richTextBoxInput";
            this.richTextBoxInput.Size = new System.Drawing.Size(772, 654);
            this.richTextBoxInput.TabIndex = 5;
            this.richTextBoxInput.Text = "";
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNext.Location = new System.Drawing.Point(803, 12);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 4;
            this.buttonNext.Text = "下一个";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.Location = new System.Drawing.Point(12, 12);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(772, 21);
            this.textBoxName.TabIndex = 3;
            // 
            // buttonShort2Long
            // 
            this.buttonShort2Long.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShort2Long.Location = new System.Drawing.Point(803, 255);
            this.buttonShort2Long.Name = "buttonShort2Long";
            this.buttonShort2Long.Size = new System.Drawing.Size(75, 23);
            this.buttonShort2Long.TabIndex = 12;
            this.buttonShort2Long.Text = "短行变长行";
            this.buttonShort2Long.UseVisualStyleBackColor = true;
            this.buttonShort2Long.Click += new System.EventHandler(this.buttonShort2Long_Click);
            // 
            // buttonRemoveBlank
            // 
            this.buttonRemoveBlank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemoveBlank.Location = new System.Drawing.Point(803, 155);
            this.buttonRemoveBlank.Name = "buttonRemoveBlank";
            this.buttonRemoveBlank.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveBlank.TabIndex = 11;
            this.buttonRemoveBlank.Text = "去空白";
            this.buttonRemoveBlank.UseVisualStyleBackColor = true;
            this.buttonRemoveBlank.Click += new System.EventHandler(this.buttonRemoveBlank_Click);
            // 
            // buttonAddBlankLine
            // 
            this.buttonAddBlankLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddBlankLine.Location = new System.Drawing.Point(803, 305);
            this.buttonAddBlankLine.Name = "buttonAddBlankLine";
            this.buttonAddBlankLine.Size = new System.Drawing.Size(75, 23);
            this.buttonAddBlankLine.TabIndex = 10;
            this.buttonAddBlankLine.Text = "增空白行";
            this.buttonAddBlankLine.UseVisualStyleBackColor = true;
            this.buttonAddBlankLine.Click += new System.EventHandler(this.buttonAddBlankLine_Click);
            // 
            // buttonRemoveBlankLine
            // 
            this.buttonRemoveBlankLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemoveBlankLine.Location = new System.Drawing.Point(803, 205);
            this.buttonRemoveBlankLine.Name = "buttonRemoveBlankLine";
            this.buttonRemoveBlankLine.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveBlankLine.TabIndex = 9;
            this.buttonRemoveBlankLine.Text = "去空白行";
            this.buttonRemoveBlankLine.UseVisualStyleBackColor = true;
            this.buttonRemoveBlankLine.Click += new System.EventHandler(this.buttonRemoveBlankLine_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Location = new System.Drawing.Point(803, 489);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 13;
            this.buttonDelete.Text = "删除";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // BatchTextEditer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 708);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonShort2Long);
            this.Controls.Add(this.buttonRemoveBlank);
            this.Controls.Add(this.buttonAddBlankLine);
            this.Controls.Add(this.buttonRemoveBlankLine);
            this.Controls.Add(this.richTextBoxInput);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.textBoxName);
            this.Name = "BatchTextEditer";
            this.Text = "BatchTextEditer";
            this.Load += new System.EventHandler(this.BatchTextEditer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxInput;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonShort2Long;
        private System.Windows.Forms.Button buttonRemoveBlank;
        private System.Windows.Forms.Button buttonAddBlankLine;
        private System.Windows.Forms.Button buttonRemoveBlankLine;
        private System.Windows.Forms.Button buttonDelete;
    }
}