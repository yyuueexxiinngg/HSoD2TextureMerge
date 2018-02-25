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
