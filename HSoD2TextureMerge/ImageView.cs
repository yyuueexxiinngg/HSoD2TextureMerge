using System;
using System.Drawing;
using System.Windows.Forms;

namespace HSoD2TextureMerge
{
    public partial class ImageView : Form
    {
        public ImageView(Image image)
        {
            InitializeComponent();
            pictureBox_image.Image = image;
        }
    }
}
