using System.Windows.Forms;

namespace TextEditor
{
    partial class TextEditor
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.richTextBoxMain = new System.Windows.Forms.RichTextBox();
            this.checkBoxUTF8 = new System.Windows.Forms.CheckBox();
            this.richTextBoxSide = new System.Windows.Forms.RichTextBox();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.blankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trimLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addHeadBlankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blankLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeBlankLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBlankLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreBlankLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shortLongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.short2LongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.long2ShortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.textBoxRegex = new System.Windows.Forms.TextBox();
            this.buttonRegex = new System.Windows.Forms.Button();
            this.buttonAddLabel = new System.Windows.Forms.Button();
            this.menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(956, 446);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // richTextBoxMain
            // 
            this.richTextBoxMain.AllowDrop = true;
            this.richTextBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxMain.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxMain.Name = "richTextBoxMain";
            this.richTextBoxMain.Size = new System.Drawing.Size(699, 412);
            this.richTextBoxMain.TabIndex = 7;
            this.richTextBoxMain.Text = "";
            this.richTextBoxMain.DragDrop += new System.Windows.Forms.DragEventHandler(this.RichTextBoxMain_DragDrop);
            this.richTextBoxMain.DragEnter += new System.Windows.Forms.DragEventHandler(this.RichTextBoxMain_DragEnter);
            // 
            // checkBoxUTF8
            // 
            this.checkBoxUTF8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxUTF8.AutoSize = true;
            this.checkBoxUTF8.Location = new System.Drawing.Point(896, 450);
            this.checkBoxUTF8.Name = "checkBoxUTF8";
            this.checkBoxUTF8.Size = new System.Drawing.Size(54, 16);
            this.checkBoxUTF8.TabIndex = 8;
            this.checkBoxUTF8.Text = "UTF-8";
            this.checkBoxUTF8.UseVisualStyleBackColor = true;
            // 
            // richTextBoxSide
            // 
            this.richTextBoxSide.AllowDrop = true;
            this.richTextBoxSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxSide.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxSide.Name = "richTextBoxSide";
            this.richTextBoxSide.Size = new System.Drawing.Size(316, 412);
            this.richTextBoxSide.TabIndex = 12;
            this.richTextBoxSide.Text = "";
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blankToolStripMenuItem,
            this.blankLineToolStripMenuItem,
            this.shortLongToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(1043, 25);
            this.menuStripMain.TabIndex = 13;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // blankToolStripMenuItem
            // 
            this.blankToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trimLineToolStripMenuItem,
            this.addHeadBlankToolStripMenuItem});
            this.blankToolStripMenuItem.Name = "blankToolStripMenuItem";
            this.blankToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.blankToolStripMenuItem.Text = "空白";
            // 
            // trimLineToolStripMenuItem
            // 
            this.trimLineToolStripMenuItem.Name = "trimLineToolStripMenuItem";
            this.trimLineToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.trimLineToolStripMenuItem.Text = "去首尾空白";
            this.trimLineToolStripMenuItem.Click += new System.EventHandler(this.TrimLineToolStripMenuItem_Click);
            // 
            // addHeadBlankToolStripMenuItem
            // 
            this.addHeadBlankToolStripMenuItem.Name = "addHeadBlankToolStripMenuItem";
            this.addHeadBlankToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.addHeadBlankToolStripMenuItem.Text = "加首空白";
            this.addHeadBlankToolStripMenuItem.Click += new System.EventHandler(this.AddHeadBlankToolStripMenuItem_Click);
            // 
            // blankLineToolStripMenuItem
            // 
            this.blankLineToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeBlankLineToolStripMenuItem,
            this.addBlankLineToolStripMenuItem,
            this.restoreBlankLineToolStripMenuItem});
            this.blankLineToolStripMenuItem.Name = "blankLineToolStripMenuItem";
            this.blankLineToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.blankLineToolStripMenuItem.Text = "空白行";
            // 
            // removeBlankLineToolStripMenuItem
            // 
            this.removeBlankLineToolStripMenuItem.Name = "removeBlankLineToolStripMenuItem";
            this.removeBlankLineToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.removeBlankLineToolStripMenuItem.Text = "去空白行";
            this.removeBlankLineToolStripMenuItem.Click += new System.EventHandler(this.RemoveBlankLineToolStripMenuItem_Click);
            // 
            // addBlankLineToolStripMenuItem
            // 
            this.addBlankLineToolStripMenuItem.Name = "addBlankLineToolStripMenuItem";
            this.addBlankLineToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.addBlankLineToolStripMenuItem.Text = "增空白行";
            this.addBlankLineToolStripMenuItem.Click += new System.EventHandler(this.AddBlankLineToolStripMenuItem_Click);
            // 
            // restoreBlankLineToolStripMenuItem
            // 
            this.restoreBlankLineToolStripMenuItem.Name = "restoreBlankLineToolStripMenuItem";
            this.restoreBlankLineToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.restoreBlankLineToolStripMenuItem.Text = "还原空白行";
            this.restoreBlankLineToolStripMenuItem.Click += new System.EventHandler(this.RestoreBlankLineToolStripMenuItem_Click);
            // 
            // shortLongToolStripMenuItem
            // 
            this.shortLongToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.short2LongToolStripMenuItem,
            this.long2ShortToolStripMenuItem});
            this.shortLongToolStripMenuItem.Name = "shortLongToolStripMenuItem";
            this.shortLongToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.shortLongToolStripMenuItem.Text = "长短行";
            // 
            // short2LongToolStripMenuItem
            // 
            this.short2LongToolStripMenuItem.Name = "short2LongToolStripMenuItem";
            this.short2LongToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.short2LongToolStripMenuItem.Text = "短行变长行";
            this.short2LongToolStripMenuItem.Click += new System.EventHandler(this.Short2LongToolStripMenuItem_Click);
            // 
            // long2ShortToolStripMenuItem
            // 
            this.long2ShortToolStripMenuItem.Name = "long2ShortToolStripMenuItem";
            this.long2ShortToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.long2ShortToolStripMenuItem.Text = "长行变短行";
            this.long2ShortToolStripMenuItem.Click += new System.EventHandler(this.Long2ShortToolStripMenuItem_Click);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerMain.Location = new System.Drawing.Point(12, 28);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.richTextBoxMain);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.richTextBoxSide);
            this.splitContainerMain.Size = new System.Drawing.Size(1019, 412);
            this.splitContainerMain.SplitterDistance = 699;
            this.splitContainerMain.TabIndex = 14;
            // 
            // textBoxRegex
            // 
            this.textBoxRegex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxRegex.Location = new System.Drawing.Point(12, 450);
            this.textBoxRegex.Name = "textBoxRegex";
            this.textBoxRegex.Size = new System.Drawing.Size(170, 21);
            this.textBoxRegex.TabIndex = 15;
            this.textBoxRegex.Text = "^第.+章.+$";
            // 
            // buttonRegex
            // 
            this.buttonRegex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRegex.Location = new System.Drawing.Point(188, 448);
            this.buttonRegex.Name = "buttonRegex";
            this.buttonRegex.Size = new System.Drawing.Size(75, 23);
            this.buttonRegex.TabIndex = 16;
            this.buttonRegex.Text = "正则";
            this.buttonRegex.UseVisualStyleBackColor = true;
            this.buttonRegex.Click += new System.EventHandler(this.ButtonRegex_Click);
            // 
            // buttonAddLabel
            // 
            this.buttonAddLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddLabel.Location = new System.Drawing.Point(269, 448);
            this.buttonAddLabel.Name = "buttonAddLabel";
            this.buttonAddLabel.Size = new System.Drawing.Size(75, 23);
            this.buttonAddLabel.TabIndex = 17;
            this.buttonAddLabel.Text = "添加标签";
            this.buttonAddLabel.UseVisualStyleBackColor = true;
            this.buttonAddLabel.Click += new System.EventHandler(this.ButtonAddLabel_Click);
            // 
            // TextEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 481);
            this.Controls.Add(this.buttonAddLabel);
            this.Controls.Add(this.buttonRegex);
            this.Controls.Add(this.textBoxRegex);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.checkBoxUTF8);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "TextEditor";
            this.Text = "TextEditor";
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button buttonSave;
        private RichTextBox richTextBoxMain;
        private CheckBox checkBoxUTF8;
        private RichTextBox richTextBoxSide;
        private MenuStrip menuStripMain;
        private ToolStripMenuItem blankToolStripMenuItem;
        private ToolStripMenuItem blankLineToolStripMenuItem;
        private ToolStripMenuItem shortLongToolStripMenuItem;
        private ToolStripMenuItem trimLineToolStripMenuItem;
        private ToolStripMenuItem addHeadBlankToolStripMenuItem;
        private ToolStripMenuItem removeBlankLineToolStripMenuItem;
        private ToolStripMenuItem addBlankLineToolStripMenuItem;
        private ToolStripMenuItem restoreBlankLineToolStripMenuItem;
        private ToolStripMenuItem short2LongToolStripMenuItem;
        private ToolStripMenuItem long2ShortToolStripMenuItem;
        private SplitContainer splitContainerMain;
        private TextBox textBoxRegex;
        private Button buttonRegex;
        private Button buttonAddLabel;
    }
}

