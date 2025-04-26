using System;
using Google.Protobuf.Collections;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using PhotossimoV9.App;
using PhotossimoV9.DB;
using PhotossimoV9.DB.DAO;
using PhotossimoV9.Object;

namespace Photossimo
{
    public partial class MainView : Form
    {
        public List<Img> listImg = [];
        public MainView()
        {
            InitializeComponent();
        }

        public void AddImage(Img newImage)
        {
            listImg.Add(newImage);
            AddNewImageToListViewimage(newImage);
        }

        public void RemoveImage(Img image, int index)
        {
            listImg.Remove(image);
            listViewImage.Items.RemoveAt(index);
            listViewImage.LargeImageList.Images.RemoveAt(index);
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            ImageImportView imgImportView = new ImageImportView(this);
            imgImportView.ShowDialog();
        }

        private void MainViewLoad(object sender, EventArgs e)
        {

            TagImg.InitializeDictionary();
            listImg = new DAO_Image().FindAll();
            LoadTagTreeView();
            AfficherImages(listImg);
        }

        private void LoadTagTreeView()
        {
            tagTreeView.Nodes.Clear();

            if (!TagImg.GetTagDictionary().TryGetValue(0, out TagImg? racine)) throw new ArgumentNullException("Racine introuvable");
            TreeNode racineNode = new(racine.NomTag) { Tag = racine };
            AddChildrenTagTreeView(racine, racineNode);
            tagTreeView.Nodes.Add(racineNode);
        }

        private void AddChildrenTagTreeView(TagImg parent, TreeNode parentNode)
        {
            foreach (TagImg enfant in parent.Enfants)
            {
                TreeNode enfantNode = new(enfant.NomTag) { Tag = enfant };
                parentNode.Nodes.Add(enfantNode);
                AddChildrenTagTreeView(enfant, enfantNode);
            }
        }


        private void ButtonGestionTag(object sender, EventArgs e)
        {
            GestionTag gestionTagForm = new GestionTag();
            var result = gestionTagForm.ShowDialog();

            // On vérifie si le tag a été supprimer et si le cas "oui" on recharge l'arbre
            if (result == DialogResult.OK)
            {

                TagImg.ClearDictionary();
                TagImg.InitializeDictionary();
                LoadTagTreeView();  // On recharge l'arbre avce les tag ajoute , ou avec le tag supprimé
            }


        }

        private void AfficherImages(List<Img> images)
        {
            listViewImage.Clear();
            int imageWidth = 100;
            int imageHeight = 100;

            ImageList imageList = new();
            imageList.ImageSize = new Size(imageWidth, imageHeight);
            listViewImage.LargeImageList = imageList;

            foreach (Img img in images)
            {
                AddNewImageToListViewimage(img);
            }
        }

        private void AddNewImageToListViewimage(Img image)
        {
            if (listViewImage.LargeImageList is not null)
                listViewImage.LargeImageList.Images.Add(image.Image);
            else
            {
                int imageWidth = 100;
                int imageHeight = 100;
                ImageList imageList = new();
                imageList.ImageSize = new Size(imageWidth, imageHeight);
                imageList.Images.Add(image.Image);
                listViewImage.LargeImageList = imageList;
            }

            ListViewItem item = new(image.NomImage, listViewImage.Items.Count);
            item.Tag = image;
            listViewImage.Items.Add(item);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listViewImage.SelectedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("Voulez-vous vraiment supprimer " + listViewImage.SelectedItems.Count + " image(s) ? ", "Confirmer la suppression", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    int nbDeleted = 0;
                    foreach (ListViewItem item in listViewImage.SelectedItems)
                    {
                        Img? imageToDelete = item.Tag as Img;
                        if (imageToDelete is not null)
                        {
                            // Suppression de l'image dans la MainView (liste d'image et listViewImage)
                            RemoveImage(imageToDelete, item.Index);

                            // Suppression de l'image dans la BDD
                            MySqlTransaction transaction = DataBase.GetInstance().BeginTransaction();
                            new DAO_Image().Delete(imageToDelete, transaction);
                            transaction.Commit();

                            // Suppression de l'image dans le dossier ressource
                            string imageFileToDelete = imageToDelete.GetCheminImage();
                            imageToDelete.Image.Dispose();
                            if (File.Exists(imageFileToDelete))
                                File.Delete(imageFileToDelete);
                            nbDeleted++;
                        }
                        else
                            throw new ArgumentNullException("L'item n'est pas relié à une Img");
                    }
                    MessageBox.Show(nbDeleted + " image(s) supprimée(s)");
                }
            }
            else
                MessageBox.Show("Veuillez sélectionner une ou plusieurs image(s)", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ButtonModifSelection(object sender, EventArgs e)
        {
            // Vérifie si au moins une image est sélectionnée
            if (listViewImage.SelectedItems.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une image", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Récupère les images sélectionnées

            List<Img> imagesSelectionnes = new List<Img>();

            foreach (ListViewItem item in listViewImage.SelectedItems)
            {
                if(item.Tag is Img image)
                {
                    imagesSelectionnes.Add(image);
                }
            }

            // Ouvre la fenêtre de modification des tags et on lui passe les images sélectionnées
            ModificationImage_Tag modifImgTag = new ModificationImage_Tag(imagesSelectionnes);
            modifImgTag.ShowDialog();
        }
    }
}