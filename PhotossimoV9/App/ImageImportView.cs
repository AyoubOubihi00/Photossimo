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
using PhotossimoV9.Utils;

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
            comboBoxTag.DropDownStyle = ComboBoxStyle.DropDown;

            // Récupère tous les noms de tag (hors racine)
            var tags = TagImg.GetTagDictionary()
                             .Values
                             .Where(t => t.IdTag != 0)
                             .OrderBy(t => t.NomTag)
                             .Select(t => t.NomTag)
                             .ToArray();

            comboBoxTag.Items.AddRange(tags);

            // Configure l'auto-complétion
            comboBoxTag.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxTag.AutoCompleteSource = AutoCompleteSource.CustomSource;
            comboBoxTag.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            comboBoxTag.AutoCompleteCustomSource.AddRange(tags);

            comboBoxTag.TextChanged -= ComboBoxTag_TextChanged;
            comboBoxTag.TextChanged += ComboBoxTag_TextChanged;
        }

        private void ComboBoxTag_TextChanged(object sender, EventArgs e)
        {
            string input = comboBoxTag.Text;
            if (string.IsNullOrEmpty(input)) return;

            // Normalise l'entrée
            string normInput = Utils.RemoveDiacritics(input).ToLowerInvariant();

            // Filtre en ignorant les diacritiques
            var matches = comboBoxTag.AutoCompleteCustomSource
                .Cast<string>()
                .Where(tag =>
                {
                    string normTag = Utils.RemoveDiacritics(tag).ToLowerInvariant();
                    return normTag.StartsWith(normInput);
                })
                .OrderBy(tag => tag)
                .ToArray();

            if (matches.Any())
            {
                // On remplit à nouveau la liste déroulante
                comboBoxTag.Items.Clear();
                comboBoxTag.Items.AddRange(matches);

                comboBoxTag.DroppedDown = true;
                comboBoxTag.SelectionStart = input.Length;
                comboBoxTag.SelectionLength = 0;
            }
        }


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
