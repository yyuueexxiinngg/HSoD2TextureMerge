namespace HSoD2TextureMerge
{
    partial class PreviewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreviewForm));
            this.btn_preview = new System.Windows.Forms.Button();
            this.pictureBox_mergeResult = new System.Windows.Forms.PictureBox();
            this.btn_Merge = new System.Windows.Forms.Button();
            this.pictureBox_Alpha = new System.Windows.Forms.PictureBox();
            this.btn_OpenAlphaImage = new System.Windows.Forms.Button();
            this.btn_OpenRGBImage = new System.Windows.Forms.Button();
            this.pictureBox_RGB = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_SaveReasult = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_mergeResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Alpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_RGB)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_preview
            // 
            this.btn_preview.Enabled = false;
            this.btn_preview.Location = new System.Drawing.Point(481, 510);
            this.btn_preview.Name = "btn_preview";
            this.btn_preview.Size = new System.Drawing.Size(202, 58);
            this.btn_preview.TabIndex = 13;
            this.btn_preview.Text = "Preview Reasult";
            this.btn_preview.UseVisualStyleBackColor = true;
            this.btn_preview.Click += new System.EventHandler(this.btn_preview_Click);
            // 
            // pictureBox_mergeResult
            // 
            this.pictureBox_mergeResult.Location = new System.Drawing.Point(960, 196);
            this.pictureBox_mergeResult.Name = "pictureBox_mergeResult";
            this.pictureBox_mergeResult.Size = new System.Drawing.Size(419, 296);
            this.pictureBox_mergeResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_mergeResult.TabIndex = 12;
            this.pictureBox_mergeResult.TabStop = false;
            // 
            // btn_Merge
            // 
            this.btn_Merge.Location = new System.Drawing.Point(1060, 82);
            this.btn_Merge.Name = "btn_Merge";
            this.btn_Merge.Size = new System.Drawing.Size(202, 58);
            this.btn_Merge.TabIndex = 11;
            this.btn_Merge.Text = "Merge Images";
            this.btn_Merge.UseVisualStyleBackColor = true;
            this.btn_Merge.Click += new System.EventHandler(this.btn_Merge_Click);
            // 
            // pictureBox_Alpha
            // 
            this.pictureBox_Alpha.Location = new System.Drawing.Point(524, 196);
            this.pictureBox_Alpha.Name = "pictureBox_Alpha";
            this.pictureBox_Alpha.Size = new System.Drawing.Size(419, 296);
            this.pictureBox_Alpha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Alpha.TabIndex = 10;
            this.pictureBox_Alpha.TabStop = false;
            // 
            // btn_OpenAlphaImage
            // 
            this.btn_OpenAlphaImage.Location = new System.Drawing.Point(615, 82);
            this.btn_OpenAlphaImage.Name = "btn_OpenAlphaImage";
            this.btn_OpenAlphaImage.Size = new System.Drawing.Size(202, 58);
            this.btn_OpenAlphaImage.TabIndex = 9;
            this.btn_OpenAlphaImage.Text = "Open an Alpha Image";
            this.btn_OpenAlphaImage.UseVisualStyleBackColor = true;
            this.btn_OpenAlphaImage.Click += new System.EventHandler(this.btn_OpenAlphaImage_Click);
            // 
            // btn_OpenRGBImage
            // 
            this.btn_OpenRGBImage.Location = new System.Drawing.Point(185, 82);
            this.btn_OpenRGBImage.Name = "btn_OpenRGBImage";
            this.btn_OpenRGBImage.Size = new System.Drawing.Size(202, 58);
            this.btn_OpenRGBImage.TabIndex = 8;
            this.btn_OpenRGBImage.Text = "Open a RGB Image";
            this.btn_OpenRGBImage.UseVisualStyleBackColor = true;
            this.btn_OpenRGBImage.Click += new System.EventHandler(this.btn_OpenRGBImage_Click);
            // 
            // pictureBox_RGB
            // 
            this.pictureBox_RGB.Location = new System.Drawing.Point(88, 196);
            this.pictureBox_RGB.Name = "pictureBox_RGB";
            this.pictureBox_RGB.Size = new System.Drawing.Size(419, 296);
            this.pictureBox_RGB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_RGB.TabIndex = 7;
            this.pictureBox_RGB.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_SaveReasult
            // 
            this.btn_SaveReasult.Enabled = false;
            this.btn_SaveReasult.Location = new System.Drawing.Point(817, 510);
            this.btn_SaveReasult.Name = "btn_SaveReasult";
            this.btn_SaveReasult.Size = new System.Drawing.Size(202, 58);
            this.btn_SaveReasult.TabIndex = 14;
            this.btn_SaveReasult.Text = "Save to...";
            this.btn_SaveReasult.UseVisualStyleBackColor = true;
            this.btn_SaveReasult.Click += new System.EventHandler(this.btn_SaveReasult_Click);
            // 
            // PreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1449, 579);
            this.Controls.Add(this.btn_SaveReasult);
            this.Controls.Add(this.btn_preview);
            this.Controls.Add(this.pictureBox_mergeResult);
            this.Controls.Add(this.btn_Merge);
            this.Controls.Add(this.pictureBox_Alpha);
            this.Controls.Add(this.btn_OpenAlphaImage);
            this.Controls.Add(this.btn_OpenRGBImage);
            this.Controls.Add(this.pictureBox_RGB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PreviewForm";
            this.Text = "PreviewForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_mergeResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Alpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_RGB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_preview;
        private System.Windows.Forms.PictureBox pictureBox_mergeResult;
        private System.Windows.Forms.Button btn_Merge;
        private System.Windows.Forms.PictureBox pictureBox_Alpha;
        private System.Windows.Forms.Button btn_OpenAlphaImage;
        private System.Windows.Forms.Button btn_OpenRGBImage;
        private System.Windows.Forms.PictureBox pictureBox_RGB;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_SaveReasult;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}