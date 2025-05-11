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
            // Le PictureBox est déjà en Dock=Fill & SizeMode=Zoom, il ajuste tout seul.

            labelName.Text = _img.NomImage;

            // Construire l'arbre sans déclencher AfterCheck
            treeViewTags.AfterCheck -= treeViewTags_AfterCheck;
            LoadTagTree();
            treeViewTags.AfterCheck += treeViewTags_AfterCheck;

            this.Shown += ImageDetailView_Shown;
        }

        private void ImageDetailView_Shown(object sender, EventArgs e)
        {/*
            // ajuste la fenêtre pour afficher l'image en taille réelle
            pictureBoxFull.SizeMode = PictureBoxSizeMode.Normal;
            pictureBoxFull.Size = pictureBoxFull.Image.Size;
            panelImage.AutoScrollMinSize = pictureBoxFull.Image.Size;*/
        }

        // Charge l'arbre sans afficher le tag root (id = 0) et coche seulement les feuilles associées
        private void LoadTagTree()
        {
            treeViewTags.Nodes.Clear();

            // Récupère le tag racine (id = 0)
            var rootTag = TagImg.GetTagDictionary()[0];

            // Ajoute chacun de ses enfants comme nœud racine
            foreach (var child in rootTag.Enfants)
            {
                var childNode = new TreeNode(child.NomTag) { Tag = child };
                BuildTree(child, childNode);
                treeViewTags.Nodes.Add(childNode);
                childNode.Expand();
            }

            // Prépare set des feuilles à cocher
            var leafIds = _img.Tags.Where(t => t.IdTag != 0)
                                   .Select(t => t.IdTag)
                                   .ToHashSet();

            // Coche uniquement les feuilles correspondantes
            foreach (TreeNode top in treeViewTags.Nodes)
            {
                foreach (var leaf in GetLeaves(top))
                {
                    if (leaf.Tag is TagImg tg && leafIds.Contains(tg.IdTag))
                    {
                        // Déplie jusqu'en haut
                        var p = leaf.Parent;
                        while (p != null)
                        {
                            p.Expand();
                            p = p.Parent;
                        }
                        leaf.Checked = true;
                    }
                }
            }
        }

        // Valide les tags cochés (ne plus se limiter à treeViewTags.Nodes[0])
        private void btnValidateTags_Click(object sender, EventArgs e)
        {
            _img.Tags.Clear();

            // Pour chaque arbre de premier niveau
            foreach (TreeNode top in treeViewTags.Nodes)
            {
                // Pour chaque feuille de cet arbre
                foreach (var leaf in GetLeaves(top))
                {
                    if (leaf.Checked && leaf.Tag is TagImg tg)
                    {
                        _img.Tags.Add(tg);
                    }
                }
            }

            using var tx = DataBase.GetInstance().BeginTransaction();
            _dao.Update(_img, tx);
            tx.Commit();

            _parent.RefreshListView();
            MessageBox.Show("Tags mis à jour.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (MessageBox.Show("Supprimer cette image définitivement ?", "Confirmation",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                != DialogResult.Yes)
                return;

            // 1) Dispose tous les bitmaps qui pointent sur ce fichier
            pictureBoxFull.Image?.Dispose();
            pictureBoxFull.Image = null!;
            _img.Image?.Dispose();
            _img.Image = null!;

            // 2) Collecte immédiate des finaliseurs pour libérer tout handle restant
            GC.Collect();
            GC.WaitForPendingFinalizers();

            // 3) Supprime de la BDD
            using var tx = DataBase.GetInstance().BeginTransaction();
            _dao.Delete(_img, tx);
            tx.Commit();

            // 4) Supprime physiquement le fichier
            try
            {
                File.Delete(_img.GetCheminImage());
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Impossible de supprimer le fichier :\n{ex.Message}", "Erreur",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 5) Mets à jour la vue principale et ferme
            _parent.RemoveImage(_img, _parent.listImg.IndexOf(_img));
            Close();
        }


    }
}
