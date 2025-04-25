using Google.Protobuf.Collections;
using MySql.Data.MySqlClient;
using PhotossimoV9.App;
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

        public void AddNewImage(Img newImage)
        {
            listImg.Add(newImage);
            AfficherImages(listImg);
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

            int index = 0;
            foreach(Img img in images)
            {
                imageList.Images.Add(img.Image);

                ListViewItem item = new(img.NomImage, index);
                item.Tag = img; // Fait le lien avec notre objet Img
                listViewImage.Items.Add(item);

                index++;
            }
        }

    }
}