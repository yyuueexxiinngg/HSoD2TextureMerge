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
            this.btn_FolderSelect = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_Process = new System.Windows.Forms.Button();
            this.folderBrowserDialog_Save = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_Preview = new System.Windows.Forms.Button();
            this.richTextBox_Console = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btn_FolderSelect
            // 
            this.btn_FolderSelect.Location = new System.Drawing.Point(131, 214);
            this.btn_FolderSelect.Name = "btn_FolderSelect";
            this.btn_FolderSelect.Size = new System.Drawing.Size(202, 58);
            this.btn_FolderSelect.TabIndex = 7;
            this.btn_FolderSelect.Text = "Select a Folder";
            this.btn_FolderSelect.UseVisualStyleBackColor = true;
            this.btn_FolderSelect.Click += new System.EventHandler(this.btn_FolderSelect_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Select the parent folder";
            // 
            // btn_Process
            // 
            this.btn_Process.Location = new System.Drawing.Point(375, 214);
            this.btn_Process.Name = "btn_Process";
            this.btn_Process.Size = new System.Drawing.Size(202, 58);
            this.btn_Process.TabIndex = 8;
            this.btn_Process.Text = "Proceed";
            this.btn_Process.UseVisualStyleBackColor = true;
            this.btn_Process.Click += new System.EventHandler(this.btn_Process_Click);
            // 
            // folderBrowserDialog_Save
            // 
            this.folderBrowserDialog_Save.Description = "Please select save folder";
            // 
            // btn_Preview
            // 
            this.btn_Preview.Location = new System.Drawing.Point(617, 214);
            this.btn_Preview.Name = "btn_Preview";
            this.btn_Preview.Size = new System.Drawing.Size(202, 58);
            this.btn_Preview.TabIndex = 9;
            this.btn_Preview.Text = "Preview and Single Output";
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 297);
            this.Controls.Add(this.richTextBox_Console);
            this.Controls.Add(this.btn_Preview);
            this.Controls.Add(this.btn_Process);
            this.Controls.Add(this.btn_FolderSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "HSoD2 Texture Merge";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_FolderSelect;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btn_Process;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_Save;
        private System.Windows.Forms.Button btn_Preview;
        private System.Windows.Forms.RichTextBox richTextBox_Console;
    }
}

