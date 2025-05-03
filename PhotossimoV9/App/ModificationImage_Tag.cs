using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhotossimoV9.Object;

namespace PhotossimoV9.App
{
    public partial class ModificationImage_Tag : Form
    {
        private List<Img> images;
        public ModificationImage_Tag(List<Img> ImagesSelectionnes)
        {
            InitializeComponent();
            images = ImagesSelectionnes;
            AfficherImages(images);

            listViewImages.SelectedIndexChanged += listViewImages_SelectedIndexChanged;

        }

        private void AfficherImages(List<Img> images)
        {
            listViewImages.Clear();
            int imageWidth = 100;
            int imageHeight = 100;

            ImageList imageList = new();
            imageList.ImageSize = new Size(imageWidth, imageHeight);
            listViewImages.LargeImageList = imageList;

            foreach (Img img in images)
            {
                AddNewImageToListViewimage(img);
            }
        }

        private void AddNewImageToListViewimage(Img image)
        {
            if (listViewImages.LargeImageList is not null)
                listViewImages.LargeImageList.Images.Add(image.Image);
            else
            {
                int imageWidth = 100;
                int imageHeight = 100;
                ImageList imageList = new();
                imageList.ImageSize = new Size(imageWidth, imageHeight);
                imageList.Images.Add(image.Image);
                listViewImages.LargeImageList = imageList;
            }

            ListViewItem item = new(image.NomImage, listViewImages.Items.Count);
            item.Tag = image;
            listViewImages.Items.Add(item);
        }

        private void listViewImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewImages.SelectedItems.Count > 0)
            {
                ListViewItem imagesselctionne = listViewImages.SelectedItems[0];
                if (imagesselctionne.Tag is Img selectedImage)
                {
                    listBoxTag.Items.Clear();

                    foreach (TagImg tag in selectedImage.Tags)
                    {
                        listBoxTag.Items.Add(tag.NomTag);
                    }

                }

            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            var confirmation = MessageBox.Show("Voulez-vous vraiment annuler ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmation == DialogResult.Yes)
                Close();
      
        }
    }
}
