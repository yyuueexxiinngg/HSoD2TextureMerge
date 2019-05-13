namespace HSoD2TextureMerge
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btn_FolderSelect = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_Process = new System.Windows.Forms.Button();
            this.folderBrowserDialog_Save = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_Preview = new System.Windows.Forms.Button();
            this.richTextBox_Console = new System.Windows.Forms.RichTextBox();
            this.folderBrowserDialog2_unmatched = new System.Windows.Forms.FolderBrowserDialog();
            this.openSampleFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.textBox_Suffix = new System.Windows.Forms.TextBox();
            this.label_Suffix = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_FolderSelect
            // 
            this.btn_FolderSelect.Location = new System.Drawing.Point(131, 214);
            this.btn_FolderSelect.Name = "btn_FolderSelect";
            this.btn_FolderSelect.Size = new System.Drawing.Size(118, 58);
            this.btn_FolderSelect.TabIndex = 7;
            this.btn_FolderSelect.Text = "Select Res Folder";
            this.btn_FolderSelect.UseVisualStyleBackColor = true;
            this.btn_FolderSelect.Click += new System.EventHandler(this.btn_FolderSelect_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Select the parent folder";
            // 
            // btn_Process
            // 
            this.btn_Process.Enabled = false;
            this.btn_Process.Location = new System.Drawing.Point(426, 214);
            this.btn_Process.Name = "btn_Process";
            this.btn_Process.Size = new System.Drawing.Size(131, 58);
            this.btn_Process.TabIndex = 8;
            this.btn_Process.Text = "Start Merge";
            this.btn_Process.UseVisualStyleBackColor = true;
            this.btn_Process.Click += new System.EventHandler(this.btn_Process_Click);
            // 
            // folderBrowserDialog_Save
            // 
            this.folderBrowserDialog_Save.Description = "Please select save folder";
            // 
            // btn_Preview
            // 
            this.btn_Preview.Location = new System.Drawing.Point(590, 214);
            this.btn_Preview.Name = "btn_Preview";
            this.btn_Preview.Size = new System.Drawing.Size(229, 58);
            this.btn_Preview.TabIndex = 9;
            this.btn_Preview.Text = "Preview or Single File Merge";
            this.btn_Preview.UseVisualStyleBackColor = true;
            this.btn_Preview.Click += new System.EventHandler(this.btn_Preview_Click);
            // 
            // richTextBox_Console
            // 
            this.richTextBox_Console.Location = new System.Drawing.Point(96, 12);
            this.richTextBox_Console.Name = "richTextBox_Console";
            this.richTextBox_Console.ReadOnly = true;
            this.richTextBox_Console.Size = new System.Drawing.Size(761, 184);
            this.richTextBox_Console.TabIndex = 10;
            this.richTextBox_Console.Text = "";
            this.richTextBox_Console.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox_Console_LinkClicked);
            // 
            // folderBrowserDialog2_unmatched
            // 
            this.folderBrowserDialog2_unmatched.Description = "Please select a folder to store unmatched file(s)";
            // 
            // openSampleFileDialog
            // 
            this.openSampleFileDialog.FileName = "openSampleFileDialog";
            // 
            // textBox_Suffix
            // 
            this.textBox_Suffix.Location = new System.Drawing.Point(283, 234);
            this.textBox_Suffix.Name = "textBox_Suffix";
            this.textBox_Suffix.Size = new System.Drawing.Size(100, 21);
            this.textBox_Suffix.TabIndex = 11;
            this.textBox_Suffix.Text = "_Alpha";
            // 
            // label_Suffix
            // 
            this.label_Suffix.AutoSize = true;
            this.label_Suffix.Location = new System.Drawing.Point(281, 214);
            this.label_Suffix.Name = "label_Suffix";
            this.label_Suffix.Size = new System.Drawing.Size(113, 12);
            this.label_Suffix.TabIndex = 12;
            this.label_Suffix.Text = "Alpha File Suffix:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 297);
            this.Controls.Add(this.label_Suffix);
            this.Controls.Add(this.textBox_Suffix);
            this.Controls.Add(this.richTextBox_Console);
            this.Controls.Add(this.btn_Preview);
            this.Controls.Add(this.btn_Process);
            this.Controls.Add(this.btn_FolderSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "ETC1 Texture Merger V1.2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_FolderSelect;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btn_Process;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_Save;
        private System.Windows.Forms.Button btn_Preview;
        private System.Windows.Forms.RichTextBox richTextBox_Console;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2_unmatched;
        private System.Windows.Forms.OpenFileDialog openSampleFileDialog;
        private System.Windows.Forms.TextBox textBox_Suffix;
        private System.Windows.Forms.Label label_Suffix;
    }
}

