namespace DuplicateFinder
{
    partial class DuplicateFinder
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
            this.textBoxFolder = new System.Windows.Forms.TextBox();
            this.dataGridViewFiles = new System.Windows.Forms.DataGridView();
            this.buttonImportFiles = new System.Windows.Forms.Button();
            this.buttonAddFolder = new System.Windows.Forms.Button();
            this.listBoxFolder = new System.Windows.Forms.ListBox();
            this.buttonDelFolder = new System.Windows.Forms.Button();
            this.buttonDelMarkFiles = new System.Windows.Forms.Button();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.buttonImportMods = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxFolder
            // 
            this.textBoxFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFolder.Location = new System.Drawing.Point(12, 12);
            this.textBoxFolder.Name = "textBoxFolder";
            this.textBoxFolder.ReadOnly = true;
            this.textBoxFolder.Size = new System.Drawing.Size(776, 21);
            this.textBoxFolder.TabIndex = 0;
            // 
            // dataGridViewFiles
            // 
            this.dataGridViewFiles.AllowUserToAddRows = false;
            this.dataGridViewFiles.AllowUserToDeleteRows = false;
            this.dataGridViewFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFiles.Location = new System.Drawing.Point(12, 97);
            this.dataGridViewFiles.Name = "dataGridViewFiles";
            this.dataGridViewFiles.RowTemplate.Height = 23;
            this.dataGridViewFiles.Size = new System.Drawing.Size(776, 441);
            this.dataGridViewFiles.TabIndex = 3;
            this.dataGridViewFiles.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewFiles_DataBindingComplete);
            // 
            // buttonImportFiles
            // 
            this.buttonImportFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonImportFiles.Location = new System.Drawing.Point(794, 97);
            this.buttonImportFiles.Name = "buttonImportFiles";
            this.buttonImportFiles.Size = new System.Drawing.Size(103, 23);
            this.buttonImportFiles.TabIndex = 4;
            this.buttonImportFiles.Text = "Import Files";
            this.buttonImportFiles.UseVisualStyleBackColor = true;
            this.buttonImportFiles.Click += new System.EventHandler(this.buttonImportFiles_Click);
            // 
            // buttonAddFolder
            // 
            this.buttonAddFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddFolder.Location = new System.Drawing.Point(794, 12);
            this.buttonAddFolder.Name = "buttonAddFolder";
            this.buttonAddFolder.Size = new System.Drawing.Size(103, 23);
            this.buttonAddFolder.TabIndex = 2;
            this.buttonAddFolder.Text = "Add Folder";
            this.buttonAddFolder.UseVisualStyleBackColor = true;
            this.buttonAddFolder.Click += new System.EventHandler(this.buttonAddFolder_Click);
            // 
            // listBoxFolder
            // 
            this.listBoxFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxFolder.FormattingEnabled = true;
            this.listBoxFolder.ItemHeight = 12;
            this.listBoxFolder.Location = new System.Drawing.Point(12, 39);
            this.listBoxFolder.Name = "listBoxFolder";
            this.listBoxFolder.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxFolder.Size = new System.Drawing.Size(776, 52);
            this.listBoxFolder.TabIndex = 7;
            // 
            // buttonDelFolder
            // 
            this.buttonDelFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelFolder.Location = new System.Drawing.Point(794, 41);
            this.buttonDelFolder.Name = "buttonDelFolder";
            this.buttonDelFolder.Size = new System.Drawing.Size(103, 23);
            this.buttonDelFolder.TabIndex = 8;
            this.buttonDelFolder.Text = "Del Folder";
            this.buttonDelFolder.UseVisualStyleBackColor = true;
            this.buttonDelFolder.Click += new System.EventHandler(this.buttonDelFolder_Click);
            // 
            // buttonDelMarkFiles
            // 
            this.buttonDelMarkFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelMarkFiles.Location = new System.Drawing.Point(794, 126);
            this.buttonDelMarkFiles.Name = "buttonDelMarkFiles";
            this.buttonDelMarkFiles.Size = new System.Drawing.Size(103, 23);
            this.buttonDelMarkFiles.TabIndex = 9;
            this.buttonDelMarkFiles.Text = "Del Mark Files";
            this.buttonDelMarkFiles.UseVisualStyleBackColor = true;
            this.buttonDelMarkFiles.Click += new System.EventHandler(this.buttonDelMarkFiles_Click);
            // 
            // listBoxLog
            // 
            this.listBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.ItemHeight = 12;
            this.listBoxLog.Location = new System.Drawing.Point(12, 544);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(776, 76);
            this.listBoxLog.TabIndex = 10;
            // 
            // buttonImportMods
            // 
            this.buttonImportMods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonImportMods.Location = new System.Drawing.Point(794, 181);
            this.buttonImportMods.Name = "buttonImportMods";
            this.buttonImportMods.Size = new System.Drawing.Size(103, 23);
            this.buttonImportMods.TabIndex = 11;
            this.buttonImportMods.Text = "Import Mods";
            this.buttonImportMods.UseVisualStyleBackColor = true;
            this.buttonImportMods.Click += new System.EventHandler(this.buttonImportMods_Click);
            // 
            // DuplicateFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 624);
            this.Controls.Add(this.buttonImportMods);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.buttonDelMarkFiles);
            this.Controls.Add(this.buttonDelFolder);
            this.Controls.Add(this.listBoxFolder);
            this.Controls.Add(this.buttonImportFiles);
            this.Controls.Add(this.dataGridViewFiles);
            this.Controls.Add(this.buttonAddFolder);
            this.Controls.Add(this.textBoxFolder);
            this.Name = "DuplicateFinder";
            this.Text = "DuplicateFinder";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFolder;
        private System.Windows.Forms.DataGridView dataGridViewFiles;
        private System.Windows.Forms.Button buttonImportFiles;
        private System.Windows.Forms.Button buttonAddFolder;
        private System.Windows.Forms.ListBox listBoxFolder;
        private System.Windows.Forms.Button buttonDelFolder;
        private System.Windows.Forms.Button buttonDelMarkFiles;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.Button buttonImportMods;
    }
}