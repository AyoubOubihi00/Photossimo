using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Photossimo
{
    public partial class ImageConsultView : Form
    {
        public ImageConsultView(String title, String selectedImageLabelText, String tagLabelText, Image img)
        {
            InitializeComponent();

            this.labelTitle.Text = title;
            this.labelImage.Text = selectedImageLabelText;
            this.labelTag.Text = tagLabelText;

            this.dataGridView1.Rows.Add(img);
           
        }
    }
}
