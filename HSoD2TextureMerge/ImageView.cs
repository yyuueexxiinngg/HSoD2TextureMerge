using System;
using System.Drawing;
using System.Windows.Forms;

namespace HSoD2TextureMerge
{
    public partial class ImageView : Form
    {
        Bitmap image;
        public ImageView(Bitmap image)
        {
            InitializeComponent();
            this.image = new Bitmap(image);
        }

        private void ImageView_Load(object sender, EventArgs e)
        {
            pictureBox_image.Image = image;
        }
    }
}
