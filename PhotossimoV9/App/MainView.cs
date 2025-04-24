using Google.Protobuf.Collections;
using MySql.Data.MySqlClient;
using PhotossimoV9.App;
using PhotossimoV9.DB.DAO;
using PhotossimoV9.Object;

namespace Photossimo
{
    public partial class MainView : Form
    {
        private List<Img> listImg = [];
        public MainView()
        {
            InitializeComponent();
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            ImageImportView imgImportView = new ImageImportView();
            imgImportView.ShowDialog();
        }

        private void MainViewLoad(object sender, EventArgs e)
        {

            TagImg.InitializeDictionary();
            listImg = new DAO_Image().FindAll();
            LoadTagTreeView();
            AfficherImages();
        }

        private void MainView_Resize(object sender, EventArgs e)
        {
            AfficherImages();
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

        private void AfficherImages()
        {
            string dossierImages = Path.Combine(Application.StartupPath, @"..\..\..\Ressources\Images");

            if (!Directory.Exists(dossierImages))
            {
                MessageBox.Show("Le dossier d'images n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var fichierJPEG = Directory.GetFiles(dossierImages, "*.jpeg");
            var fichierJPG = Directory.GetFiles(dossierImages, "*.jpg");

            var fichiers = fichierJPEG.Concat(fichierJPG).ToArray();

            flowLayoutImages.Controls.Clear();


            // C'est pour le resize (pas encore termine)
            int nbcolonne = 4;
            int espace = 10;
            int largeurImage = (flowLayoutImages.ClientSize.Width / nbcolonne) - espace;

            foreach (string fichier in fichiers)
            {
                System.Drawing.Image image = System.Drawing.Image.FromFile(fichier);
                PictureBox pb = new PictureBox()
                {

                    Image = image,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    //Dock = DockStyle.Top,
                    Height = 90,
                    Width = largeurImage,
                    Cursor = Cursors.Hand
                };

                Label label = new Label()
                {
                    Text = Path.GetFileName(fichier),
                    TextAlign = ContentAlignment.MiddleCenter,
                   // Dock = DockStyle.Bottom,
                    Width = largeurImage,
                    Height = 30,
                    AutoEllipsis = true
                };

                Panel panel = new Panel()
                {
                    Width = largeurImage,
                    Height = 150,
                    Margin = new Padding(5)
                };

                panel.Controls.Add(label);

                panel.Controls.Add(pb);

                flowLayoutImages.Controls.Add(panel);



            }

        }
    }
}