using System;
using System.Drawing;
using System.Windows.Forms;

namespace HSoD2TextureMerge
{
    public partial class PreviewForm : Form
    {
        String rgbPath = "";
        String alphaPath = "";
        Bitmap rgbTexture;
        Bitmap alphaTexture;

        public PreviewForm()
        {
            InitializeComponent();
        }

        private void btn_OpenRGBImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            rgbPath = openFileDialog1.FileName;
            try
            {
                rgbTexture = new Bitmap(rgbPath);
                pictureBox_RGB.Image = rgbTexture;
                btn_preview.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Unable to open the image");
            }
        }

        private void btn_OpenAlphaImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            alphaPath = openFileDialog1.FileName;
            try
            {
                alphaTexture = new Bitmap(alphaPath);
                pictureBox_Alpha.Image = alphaTexture;
                btn_preview.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Unable to open the image");
            }
        }

        private void btn_Merge_Click(object sender, EventArgs e)
        {
            MainForm m = new MainForm();

            DateTime beforDT = System.DateTime.Now;
            if (rgbTexture != null && alphaTexture != null)
            {
                try
                {
                    pictureBox_mergeResult.Image = m.mergeImage(rgbTexture, alphaTexture);

                    btn_preview.Enabled = true;
                    btn_SaveReasult.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("Unable to process images, please make sure RGB image and Alpha image share the same resolution");
                }
            }
            else
            {
                MessageBox.Show("Please open both RGB and Alpha images first");
            }   //if end

            DateTime afterDT = System.DateTime.Now;
            TimeSpan ts = afterDT.Subtract(beforDT);
            richTextBox_ProcessTime.Text = "Time:" + ts.TotalSeconds + " s";
        }

        private void btn_preview_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            ImageView imageView = new ImageView(pictureBox_mergeResult.Image);
            imageView.ShowDialog();
            this.Enabled = true;
        }

        private void btn_SaveReasult_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            string[] fileNameSplit = rgbPath.Split('\\');
            string fileName = fileNameSplit[fileNameSplit.Length - 1];

            Console.WriteLine(folderBrowserDialog1.SelectedPath);

            pictureBox_mergeResult.Image.Save(folderBrowserDialog1.SelectedPath + "\\" + fileName, System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
