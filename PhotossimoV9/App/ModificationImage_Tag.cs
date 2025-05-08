using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhotossimoV9.DB.DAO;
using PhotossimoV9.DB;
using PhotossimoV9.Object;
using Photossimo;

namespace PhotossimoV9.App
{
    public partial class ModificationImage_Tag : Form
    {
        private List<Img> images;
        private readonly DAO_Image _dao = new DAO_Image();
        private readonly MainView _parent;
        public ModificationImage_Tag(List<Img> ImagesSelectionnes, MainView parent)
        {
            InitializeComponent();
            images = ImagesSelectionnes;
            _parent = parent;
            AfficherImages(images);

            listViewImages.SelectedIndexChanged += listViewImages_SelectedIndexChanged;

            treeViewTagImage.AfterCheck += treeViewTags_AfterCheck;

        }

        private void AfficherImages(List<Img> images)
        {
            listViewImages.Clear();
            int imageWidth = 100;
            int imageHeight = 100;

            ImageList imageList = new();
            imageList.ImageSize = new Size(imageWidth, imageHeight);
            listViewImages.LargeImageList = imageList;

            foreach (Img img in images)
            {
                AddNewImageToListViewimage(img);
            }
        }

        private void AddNewImageToListViewimage(Img image)
        {
            if (listViewImages.LargeImageList is not null)
                listViewImages.LargeImageList.Images.Add(image.Image);
            else
            {
                int imageWidth = 100;
                int imageHeight = 100;
                ImageList imageList = new();
                imageList.ImageSize = new Size(imageWidth, imageHeight);
                imageList.Images.Add(image.Image);
                listViewImages.LargeImageList = imageList;
            }

            ListViewItem item = new(image.NomImage, listViewImages.Items.Count);
            item.Tag = image;
            listViewImages.Items.Add(item);
        }

        private void listViewImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewImages.SelectedItems.Count > 0)
            {
                ListViewItem imagesselctionne = listViewImages.SelectedItems[0];
                if (imagesselctionne.Tag is Img selectedImage)
                {
                    listBoxTag.Items.Clear();

                    foreach (TagImg tag in selectedImage.Tags)
                    {
                        listBoxTag.Items.Add(tag.NomTag);
                    }

                    LoadTagTreeView(selectedImage);
                }

            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            var confirmation = MessageBox.Show("Voulez-vous vraiment annuler ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmation == DialogResult.Yes)
                Close();

        }

        private void LoadTagTreeView(Img img)
        {
            treeViewTagImage.Nodes.Clear();

            if (!TagImg.GetTagDictionary().TryGetValue(0, out TagImg? rootTag)) return;

            TreeNode rootNode = new(rootTag.NomTag) { Tag = rootTag };
            BuildTree(rootTag, rootNode);
            treeViewTagImage.Nodes.Add(rootNode);
            rootNode.Expand();

            var leafIds = img.Tags.Select(t => t.IdTag).ToHashSet();
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
            treeViewTagImage.AfterCheck -= treeViewTags_AfterCheck;
            foreach (TreeNode c in e.Node.Nodes)
                c.Checked = e.Node.Checked;
            treeViewTagImage.AfterCheck += treeViewTags_AfterCheck;
        }

        private void Valider(object sender, EventArgs e)
        {
            if (listViewImages.SelectedItems.Count == 0) return;
            ListViewItem imagesselctionne = listViewImages.SelectedItems[0];
            if (imagesselctionne.Tag is Img selectedImage)
            {
                selectedImage.Tags.Clear();

                foreach (var leaf in GetLeaves(treeViewTagImage.Nodes[0]))
                    if (leaf.Checked && leaf.Tag is TagImg tg)
                        selectedImage.Tags.Add(tg);

                using var tx = DataBase.GetInstance().BeginTransaction();
                _dao.Update(selectedImage, tx);
                tx.Commit();

                _parent.RefreshListView();
                MessageBox.Show("Tags mis à jour.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
