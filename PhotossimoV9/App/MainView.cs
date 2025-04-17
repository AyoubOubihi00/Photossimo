using Google.Protobuf.Collections;
using MySql.Data.MySqlClient;
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
            listImg = new DAO_Image().FindAll();
            TagImg.InitializeDictionary();
            LoadTagTreeView();
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

        private void buttonSupprimerTag_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tagTreeView.SelectedNode;

            if (selectedNode == null)
            {
                MessageBox.Show("Veuillez sélectionner un tag à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (selectedNode.Tag is TagImg selectedTag)
            {
                // On traite le cas de la racine donc on la suprrimer pas root
                if (selectedTag.IdTag == 0)
                {
                    MessageBox.Show("Impossible de supprimer le tag racine.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // On traite le cas de suppriemr l'enfant
                if (selectedTag.Enfants.Count == 0) {

                    selectedTag.SupprimerEnfant();
                    MessageBox.Show("Tag supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // On traite le cas de supprimer le parent qui a des fills 
                else
                {
                    selectedTag.SupprimerParent();
                    MessageBox.Show("Tag supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                TagImg.ClearDictionary();
                TagImg.InitializeDictionary();
                LoadTagTreeView();
            }
            else
            {
                MessageBox.Show("Erreur lors de la suppression du tag.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}