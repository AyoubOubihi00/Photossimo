using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using PhotossimoV9.App;
using PhotossimoV9.DB;
using PhotossimoV9.DB.DAO;
using PhotossimoV9.Object;

namespace Photossimo
{
    public partial class ImageImportView : Form
    {
        MainView mainView;
        Image? imgSelected;
        private string? FileImageSelectionne;
        // Partie initialisation des tags dans la fenêtre principale
        private void ChargerTags()
        {
            comboBoxTag.Items.Clear();

            if (TagImg.GetTagDictionary().TryGetValue(0, out var rootTag))
                comboBoxTag.Items.Add(rootTag.NomTag);

            foreach (var tag in TagImg.GetTagDictionary().Values.Where(tag => tag.IdTag != 0).OrderBy(t => t.NomTag))
                comboBoxTag.Items.Add(tag.NomTag);
        }

        // Appelle cette méthode dans ton constructeur après InitializeComponent()
        public ImageImportView(MainView mv)
        {
            mainView = mv;
            InitializeComponent();
            ChargerTags();
        }

        // Bouton "Ajouter Tag"
        private void buttonAjouterTag_Click(object sender, EventArgs e)
        {
            if (comboBoxTag.SelectedItem != null)
            {
                string? tagNom = comboBoxTag.SelectedItem.ToString();

                if (tagNom is not null && !listBoxTagsSelectionnes.Items.Contains(tagNom))
                    listBoxTagsSelectionnes.Items.Add(tagNom);
                else
                    MessageBox.Show("Tag déjà sélectionné", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSupprimerTag_Click(object sender, EventArgs e)
        {
            // Supprime tous les tags sélectionnés dans la ListBox
            var itemsToRemove = listBoxTagsSelectionnes
                .SelectedItems
                .Cast<string>()
                .ToList();

            foreach (var item in itemsToRemove)
                listBoxTagsSelectionnes.Items.Remove(item);
        }

        // Bouton "Valider Import"
        private void buttonValiderImport_Click(object sender, EventArgs e)
        {
            if (imgSelected == null)
            {
                MessageBox.Show("Veuillez sélectionner une image", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (listBoxTagsSelectionnes.Items.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner au moins un tag", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<TagImg> tagsAssocies = new();

            foreach (var item in listBoxTagsSelectionnes.Items)
            {
                var tagtrouve = TagImg.GetTagDictionary().Values.FirstOrDefault(
                    tag => tag.NomTag.Equals(item.ToString(), StringComparison.OrdinalIgnoreCase));

                if (tagtrouve != null)
                    tagsAssocies.Add(tagtrouve);
            }
            if (FileImageSelectionne is null) throw new ArgumentNullException("FileImageSelectionne est null");
            Img nouvelleImage = new(-1, FileImageSelectionne, DateTime.Now, tagsAssocies);
            string cheminImage = nouvelleImage.GetCheminImage();

            string? directoryPath = Path.GetDirectoryName(cheminImage);
            if (directoryPath is not null) Directory.CreateDirectory(directoryPath);
            if (!File.Exists(cheminImage)) imgSelected.Save(cheminImage, System.Drawing.Imaging.ImageFormat.Jpeg);

            nouvelleImage.Image = Image.FromFile(nouvelleImage.GetCheminImage());

            MySqlTransaction transaction = DataBase.GetInstance().BeginTransaction();
            new DAO_Image().Create(nouvelleImage, transaction);
            transaction.Commit();

            mainView.AddImage(nouvelleImage);

            MessageBox.Show("Image et tags associés enregistrés avec succès", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }

        // Bouton "Parcourir"
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Title = "Choisissez une image à importer";
            openFileDialog.Filter = "Fichiers JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imgSelected = Image.FromFile(openFileDialog.FileName);
                FileImageSelectionne = Path.GetFileName(openFileDialog.FileName);
                pictureBox1.Image = imgSelected;

                // Réinitialise les tags quand une nouvelle image est sélectionnée
                listBoxTagsSelectionnes.Items.Clear();
            }
        }

        // Bouton "Annuler"
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            var confirmation = MessageBox.Show("Voulez-vous vraiment annuler ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmation == DialogResult.Yes)
                Close();
        }

        private void ModifNom_click(object sender, EventArgs e)
        {
            if (FileImageSelectionne is null)
            {
                MessageBox.Show("Veuillez sélectionner une image", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NomImageModif nomImageModif = new NomImageModif(FileImageSelectionne);
            if (nomImageModif.ShowDialog() == DialogResult.OK)
            {
                FileImageSelectionne = nomImageModif.NouveauNom;
            }
        }
    }
}
