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

            if(!TagImg.GetTagDictionary().TryGetValue(0, out TagImg? racine)) throw new ArgumentNullException("Racine introuvable");
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
    }
}