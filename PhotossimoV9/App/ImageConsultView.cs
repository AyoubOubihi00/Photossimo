using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mysqlx;
using PhotossimoV9.DB.DAO;
using PhotossimoV9.Object;

namespace Photossimo
{
    public partial class ImageConsultView : Form
    {
        private string nomFichierImage;

        public ImageConsultView(String title, String selectedImageLabelText, String tagLabelText, Image img, string nomFichier)
        {
            InitializeComponent();

            this.labelTitle.Text = title;
            this.labelImage.Text = selectedImageLabelText;
            this.labelTag.Text = tagLabelText;
            this.nomFichierImage = nomFichier;

            if (TagImg.GetTagDictionary().TryGetValue(0, out var rootTag))
            {
                comboBoxTag.Items.Add(rootTag.NomTag);
            }

            var tagTries = TagImg.GetTagDictionary().Values.Where(tag => tag.IdTag != 0).OrderBy(tag => tag.NomTag).ToList();

            foreach (var tag in tagTries)
            {

                comboBoxTag.Items.Add(tag.NomTag);


            }

            this.dataGridView1.Rows.Add(img);

        }

        private void buttonAjouterTag(object sender, EventArgs e)
        {
            if (comboBoxTag.SelectedItem != null)
            {
                string tagNom = comboBoxTag.SelectedItem.ToString();

                if (!listBoxTagsSelectionnes.Items.Contains(tagNom))
                {
                    listBoxTagsSelectionnes.Items.Add(tagNom);
                }
                else
                {
                    MessageBox.Show("Tag déjà sélectionné", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonValiderTag(object sender, EventArgs e)
        {
            if (listBoxTagsSelectionnes.Items.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner au moins un tag", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<TagImg> Tagassocies = new List<TagImg>();

            foreach (var item in listBoxTagsSelectionnes.Items)
            {
                string nomTag = item.ToString();
                TagImg? tagtrouve = TagImg.GetTagDictionary().Values.FirstOrDefault(tag => tag.NomTag.Equals(nomTag, StringComparison.OrdinalIgnoreCase));

                if (tagtrouve != null)
                {
                    Tagassocies.Add(tagtrouve);
                }
            }

            Image img = (Image)dataGridView1.CurrentRow.Cells[0].Value;

            Img nouvelleImage = new Img(0, nomFichierImage, DateTime.Now, Tagassocies);

            string cheminimage = nouvelleImage.GetCheminImage();
            Directory.CreateDirectory(Path.GetDirectoryName(cheminimage));

            img.Save(cheminimage, System.Drawing.Imaging.ImageFormat.Jpeg);

            DAO_Image daoImage = new DAO_Image();

            daoImage.Insert(nouvelleImage);

            MessageBox.Show("Image et tags associés enregistrés avec succès", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void buttonAnnuler(object sender, EventArgs e)
        {
            var confirmation = MessageBox.Show("Vous êtes sur le point d'annuler l'importation de l'image avec les tags associeés. Voulez-vous vraiment continuer ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


            if (confirmation == DialogResult.Yes)
            {
                // On ferme la fenêtre de création de tag si on a clique sur le bouton annuler
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
