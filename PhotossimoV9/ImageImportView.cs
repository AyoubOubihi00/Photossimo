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
    public partial class ImageImportView : Form
    {
        Image imgSelected;
        public ImageImportView()
        {
            InitializeComponent();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Title = "Choisissez une image à importer";
            openFileDialog.Filter = "Fichiers JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imgSelected = Image.FromFile(openFileDialog.FileName);
                pictureBox1.Image = imgSelected;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTagSelection_Click(object sender, EventArgs e)
        {
            if(imgSelected == null)
            {
                MessageBox.Show("Aucune image sélectionnée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ImageConsultView imgConsultView = new ImageConsultView(
                                                  "Sélection des Tags",
                                                  "Prévisualisation de l'image",
                                                  "Tag(s) de l'image", imgSelected);
            imgConsultView.ShowDialog();
        }
    }
}
