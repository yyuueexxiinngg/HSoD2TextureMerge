using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HSoD2TextureMerge
{
    public partial class PreviewForm : Form
    {
        String rgbPath = "";
        String alphaPath = "";
        Bitmap rgbTexture;
        Bitmap alphaTexture;
        Bitmap textureWithAlpha;

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
            if (rgbPath != "" && alphaPath != "")
            {
                try
                {
                    textureWithAlpha = new Bitmap(rgbTexture.Width, rgbTexture.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                    for (int i = 0; i < rgbTexture.Width; i++)
                    {
                        for (int j = 0; j < rgbTexture.Height; j++)
                        {
                            Color withAlpha = Color.FromArgb(alphaTexture.GetPixel(i, j).R, rgbTexture.GetPixel(i, j));

                            textureWithAlpha.SetPixel(i, j, withAlpha);
                        }
                    }   //for end
                    pictureBox_mergeResult.Image = textureWithAlpha;

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
        }

        private void btn_preview_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            ImageView imageView = new ImageView(textureWithAlpha);
            imageView.ShowDialog();
            this.Enabled = true;
        }

        private void btn_SaveReasult_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            string[] fileNameSplit = rgbPath.Split('\\');
            string fileName = fileNameSplit[fileNameSplit.Length - 1];

            Console.WriteLine(folderBrowserDialog1.SelectedPath);

            textureWithAlpha.Save(folderBrowserDialog1.SelectedPath + "\\" + fileName, System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
