namespace MyTextSplit
{
    partial class MyTextSplit
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
            this.groupBoxInput = new System.Windows.Forms.GroupBox();
            this.richTextBoxInput = new System.Windows.Forms.RichTextBox();
            this.buttonNext = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.groupBoxOutput = new System.Windows.Forms.GroupBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonShort2Long = new System.Windows.Forms.Button();
            this.buttonRemoveBlank = new System.Windows.Forms.Button();
            this.buttonAddBlankLine = new System.Windows.Forms.Button();
            this.buttonRemoveBlankLine = new System.Windows.Forms.Button();
            this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
            this.textBoxSuffix = new System.Windows.Forms.TextBox();
            this.textBoxChapter = new System.Windows.Forms.TextBox();
            this.textBoxPrefix = new System.Windows.Forms.TextBox();
            this.textBoxFolder = new System.Windows.Forms.TextBox();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.groupBoxInput.SuspendLayout();
            this.groupBoxOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxInput
            // 
            this.groupBoxInput.Controls.Add(this.richTextBoxInput);
            this.groupBoxInput.Controls.Add(this.buttonNext);
            this.groupBoxInput.Controls.Add(this.textBoxName);
            this.groupBoxInput.Location = new System.Drawing.Point(12, 12);
            this.groupBoxInput.Name = "groupBoxInput";
            this.groupBoxInput.Size = new System.Drawing.Size(712, 706);
            this.groupBoxInput.TabIndex = 0;
            this.groupBoxInput.TabStop = false;
            this.groupBoxInput.Text = "Input";
            // 
            // richTextBoxInput
            // 
            this.richTextBoxInput.Location = new System.Drawing.Point(6, 47);
            this.richTextBoxInput.Name = "richTextBoxInput";
            this.richTextBoxInput.Size = new System.Drawing.Size(700, 653);
            this.richTextBoxInput.TabIndex = 2;
            this.richTextBoxInput.Text = "";
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(631, 18);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 1;
            this.buttonNext.Text = "下一个";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(6, 20);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(619, 21);
            this.textBoxName.TabIndex = 0;
            // 
            // groupBoxOutput
            // 
            this.groupBoxOutput.Controls.Add(this.buttonCopy);
            this.groupBoxOutput.Controls.Add(this.buttonSave);
            this.groupBoxOutput.Controls.Add(this.buttonShort2Long);
            this.groupBoxOutput.Controls.Add(this.buttonRemoveBlank);
            this.groupBoxOutput.Controls.Add(this.buttonAddBlankLine);
            this.groupBoxOutput.Controls.Add(this.buttonRemoveBlankLine);
            this.groupBoxOutput.Controls.Add(this.richTextBoxOutput);
            this.groupBoxOutput.Controls.Add(this.textBoxSuffix);
            this.groupBoxOutput.Controls.Add(this.textBoxChapter);
            this.groupBoxOutput.Controls.Add(this.textBoxPrefix);
            this.groupBoxOutput.Controls.Add(this.textBoxFolder);
            this.groupBoxOutput.Location = new System.Drawing.Point(730, 12);
            this.groupBoxOutput.Name = "groupBoxOutput";
            this.groupBoxOutput.Size = new System.Drawing.Size(750, 706);
            this.groupBoxOutput.TabIndex = 1;
            this.groupBoxOutput.TabStop = false;
            this.groupBoxOutput.Text = "Output";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(669, 20);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonShort2Long
            // 
            this.buttonShort2Long.Location = new System.Drawing.Point(669, 272);
            this.buttonShort2Long.Name = "buttonShort2Long";
            this.buttonShort2Long.Size = new System.Drawing.Size(75, 23);
            this.buttonShort2Long.TabIndex = 8;
            this.buttonShort2Long.Text = "短行变长行";
            this.buttonShort2Long.UseVisualStyleBackColor = true;
            this.buttonShort2Long.Click += new System.EventHandler(this.buttonShort2Long_Click);
            // 
            // buttonRemoveBlank
            // 
            this.buttonRemoveBlank.Location = new System.Drawing.Point(669, 174);
            this.buttonRemoveBlank.Name = "buttonRemoveBlank";
            this.buttonRemoveBlank.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveBlank.TabIndex = 7;
            this.buttonRemoveBlank.Text = "去空白";
            this.buttonRemoveBlank.UseVisualStyleBackColor = true;
            this.buttonRemoveBlank.Click += new System.EventHandler(this.buttonRemoveBlank_Click);
            // 
            // buttonAddBlankLine
            // 
            this.buttonAddBlankLine.Location = new System.Drawing.Point(669, 326);
            this.buttonAddBlankLine.Name = "buttonAddBlankLine";
            this.buttonAddBlankLine.Size = new System.Drawing.Size(75, 23);
            this.buttonAddBlankLine.TabIndex = 6;
            this.buttonAddBlankLine.Text = "增空白行";
            this.buttonAddBlankLine.UseVisualStyleBackColor = true;
            this.buttonAddBlankLine.Click += new System.EventHandler(this.buttonAddBlankLine_Click);
            // 
            // buttonRemoveBlankLine
            // 
            this.buttonRemoveBlankLine.Location = new System.Drawing.Point(669, 220);
            this.buttonRemoveBlankLine.Name = "buttonRemoveBlankLine";
            this.buttonRemoveBlankLine.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveBlankLine.TabIndex = 5;
            this.buttonRemoveBlankLine.Text = "去空白行";
            this.buttonRemoveBlankLine.UseVisualStyleBackColor = true;
            this.buttonRemoveBlankLine.Click += new System.EventHandler(this.buttonRemoveBlankLine_Click);
            // 
            // richTextBoxOutput
            // 
            this.richTextBoxOutput.Location = new System.Drawing.Point(6, 47);
            this.richTextBoxOutput.Name = "richTextBoxOutput";
            this.richTextBoxOutput.Size = new System.Drawing.Size(657, 653);
            this.richTextBoxOutput.TabIndex = 3;
            this.richTextBoxOutput.Text = "";
            // 
            // textBoxSuffix
            // 
            this.textBoxSuffix.Location = new System.Drawing.Point(480, 20);
            this.textBoxSuffix.Name = "textBoxSuffix";
            this.textBoxSuffix.Size = new System.Drawing.Size(183, 21);
            this.textBoxSuffix.TabIndex = 3;
            this.textBoxSuffix.Text = "章";
            // 
            // textBoxChapter
            // 
            this.textBoxChapter.Location = new System.Drawing.Point(396, 20);
            this.textBoxChapter.Name = "textBoxChapter";
            this.textBoxChapter.Size = new System.Drawing.Size(78, 21);
            this.textBoxChapter.TabIndex = 2;
            this.textBoxChapter.Text = "1";
            // 
            // textBoxPrefix
            // 
            this.textBoxPrefix.Location = new System.Drawing.Point(276, 20);
            this.textBoxPrefix.Name = "textBoxPrefix";
            this.textBoxPrefix.Size = new System.Drawing.Size(114, 21);
            this.textBoxPrefix.TabIndex = 1;
            this.textBoxPrefix.Text = "第";
            this.textBoxPrefix.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxFolder
            // 
            this.textBoxFolder.Location = new System.Drawing.Point(6, 20);
            this.textBoxFolder.Name = "textBoxFolder";
            this.textBoxFolder.Size = new System.Drawing.Size(210, 21);
            this.textBoxFolder.TabIndex = 0;
            // 
            // buttonCopy
            // 
            this.buttonCopy.Location = new System.Drawing.Point(669, 82);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(75, 23);
            this.buttonCopy.TabIndex = 10;
            this.buttonCopy.Text = "复制";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // MyTextSplit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1492, 730);
            this.Controls.Add(this.groupBoxOutput);
            this.Controls.Add(this.groupBoxInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MyTextSplit";
            this.Text = "MyTextSplit";
            this.Load += new System.EventHandler(this.MyTextSplit_Load);
            this.groupBoxInput.ResumeLayout(false);
            this.groupBoxInput.PerformLayout();
            this.groupBoxOutput.ResumeLayout(false);
            this.groupBoxOutput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxInput;
        private System.Windows.Forms.GroupBox groupBoxOutput;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.RichTextBox richTextBoxInput;
        private System.Windows.Forms.TextBox textBoxChapter;
        private System.Windows.Forms.TextBox textBoxPrefix;
        private System.Windows.Forms.TextBox textBoxFolder;
        private System.Windows.Forms.TextBox textBoxSuffix;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonShort2Long;
        private System.Windows.Forms.Button buttonRemoveBlank;
        private System.Windows.Forms.Button buttonAddBlankLine;
        private System.Windows.Forms.Button buttonRemoveBlankLine;
        private System.Windows.Forms.RichTextBox richTextBoxOutput;
        private System.Windows.Forms.Button buttonCopy;
    }
}