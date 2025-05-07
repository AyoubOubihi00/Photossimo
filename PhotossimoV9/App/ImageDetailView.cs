// ImageDetailView.cs
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Photossimo;
using PhotossimoV9.DB;
using PhotossimoV9.DB.DAO;
using PhotossimoV9.Object;

namespace PhotossimoV9.App
{
    public partial class ImageDetailView : Form
    {
        private readonly Img _img;
        private readonly MainView _parent;
        private readonly DAO_Image _dao = new DAO_Image();

        public ImageDetailView(Img img, MainView parent)
        {
            InitializeComponent();
            _img = img;
            _parent = parent;

            // — Charge l’image sans verrouiller le fichier —
            using (var fs = new FileStream(_img.GetCheminImage(), FileMode.Open, FileAccess.Read))
            {
                var temp = Image.FromStream(fs);
                pictureBoxFull.Image = new Bitmap(temp);
                temp.Dispose();
            }
            // restaure l'affichage à taille réelle
            pictureBoxFull.Size = pictureBoxFull.Image.Size;
            pictureBoxFull.SizeMode = PictureBoxSizeMode.Normal;
            panelImage.AutoScrollMinSize = pictureBoxFull.Image.Size;

            labelName.Text = _img.NomImage;

            // Construire l'arbre sans déclencher AfterCheck
            treeViewTags.AfterCheck -= treeViewTags_AfterCheck;
            LoadTagTree();
            treeViewTags.AfterCheck += treeViewTags_AfterCheck;

            this.Shown += ImageDetailView_Shown;
        }

        private void ImageDetailView_Shown(object sender, EventArgs e)
        {
            // ajuste la fenêtre pour afficher l'image en taille réelle
            int controlsHeight = bottomLeftFlow.Height;
            int deltaHeight = this.Height - this.ClientSize.Height;
            int deltaWidth = this.Width - this.ClientSize.Width;

            int desiredClientWidth = pictureBoxFull.Image.Width;
            int desiredClientHeight = pictureBoxFull.Image.Height + controlsHeight;

            var screenArea = Screen.FromControl(this).WorkingArea;
            desiredClientWidth = Math.Min(desiredClientWidth, screenArea.Width);
            desiredClientHeight = Math.Min(desiredClientHeight, screenArea.Height);

            this.Size = new Size(desiredClientWidth + deltaWidth, desiredClientHeight + deltaHeight);
            panelImage.AutoScrollMinSize = pictureBoxFull.Image.Size;
        }

        private void LoadTagTree()
        {
            treeViewTags.Nodes.Clear();
            var rootTag = TagImg.GetTagDictionary()[0];
            var rootNode = new TreeNode(rootTag.NomTag) { Tag = rootTag };
            BuildTree(rootTag, rootNode);
            treeViewTags.Nodes.Add(rootNode);
            rootNode.Expand();

            // coche uniquement les feuilles associées
            var leafIds = _img.Tags.Where(t => t.IdTag != 0).Select(t => t.IdTag).ToHashSet();
            foreach (var leaf in GetLeaves(rootNode))
            {
                if (leaf.Tag is TagImg tg && leafIds.Contains(tg.IdTag))
                {
                    var p = leaf.Parent;
                    while (p != null) { p.Expand(); p = p.Parent; }
                    leaf.Checked = true;
                }
            }
        }

        private void BuildTree(TagImg parent, TreeNode node)
        {
            foreach (var child in parent.Enfants)
            {
                var n = new TreeNode(child.NomTag) { Tag = child };
                node.Nodes.Add(n);
                BuildTree(child, n);
            }
        }

        private IEnumerable<TreeNode> GetLeaves(TreeNode node)
        {
            if (node.Nodes.Count == 0) yield return node;
            else foreach (TreeNode c in node.Nodes)
                    foreach (var leaf in GetLeaves(c))
                        yield return leaf;
        }

        private void treeViewTags_AfterCheck(object sender, TreeViewEventArgs e)
        {
            treeViewTags.AfterCheck -= treeViewTags_AfterCheck;
            foreach (TreeNode c in e.Node.Nodes)
                c.Checked = e.Node.Checked;
            treeViewTags.AfterCheck += treeViewTags_AfterCheck;
        }

        private void btnValidateTags_Click(object sender, EventArgs e)
        {
            _img.Tags.Clear();
            foreach (var leaf in GetLeaves(treeViewTags.Nodes[0]))
                if (leaf.Checked && leaf.Tag is TagImg tg)
                    _img.Tags.Add(tg);

            using var tx = DataBase.GetInstance().BeginTransaction();
            _dao.Update(_img, tx);
            tx.Commit();

            _parent.RefreshListView();
            MessageBox.Show("Tags mis à jour.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            using var ren = new NomImageModif(_img.NomImage);
            if (ren.ShowDialog() != DialogResult.OK) return;
            string oldName = _img.NomImage;
            string ext = Path.GetExtension(oldName);
            _img.NomImage = ren.NouveauNom + ext;
            using (var tx = DataBase.GetInstance().BeginTransaction()) { _dao.Update(_img, tx); tx.Commit(); }
            pictureBoxFull.Image.Dispose();
            File.Move(Path.Combine(Path.GetDirectoryName(_img.GetCheminImage())!, oldName), _img.GetCheminImage());
            using var fs = new FileStream(_img.GetCheminImage(), FileMode.Open, FileAccess.Read);
            pictureBoxFull.Image = new Bitmap(Image.FromStream(fs));
            labelName.Text = _img.NomImage;
            _parent.RefreshListView();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Supprimer cette image définitivement ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;
            using var tx = DataBase.GetInstance().BeginTransaction();
            _dao.Delete(_img, tx);
            tx.Commit();
            File.Delete(_img.GetCheminImage());
            _parent.RemoveImage(_img, _parent.listImg.IndexOf(_img));
            Close();
        }
    }
}
