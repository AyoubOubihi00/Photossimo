using System;
using Google.Protobuf.Collections;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using PhotossimoV9.App;
using PhotossimoV9.DB;
using PhotossimoV9.DB.DAO;
using PhotossimoV9.Object;
using PhotossimoV9.Utils;

namespace Photossimo
{
    public partial class MainView : Form
    {
        public List<Img> listImg = [];
        public MainView()
        {
            InitializeComponent();
            ConfigureTagSearch();
            // reposition & resize suggestions whenever la fenêtre change de taille
            this.Resize += (s, e) => UpdateSuggestionBoxLayout();
        }

        private AutoCompleteStringCollection _tagSource;

        private void ConfigureTagSearch()
        {
            textBox1.TextChanged += TextBox1_TextChanged;
        }

        private void UpdateSuggestionBoxLayout()
        {
            // même largeur que textBox1
            listBoxSuggestions.Width = textBox1.Width;
            // placer juste sous textBox1
            var screenPt = textBox1.PointToScreen(Point.Empty);
            var clientPt = this.PointToClient(screenPt);
            listBoxSuggestions.Location = new Point(clientPt.X, clientPt.Y + textBox1.Height);
            listBoxSuggestions.BringToFront();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string filter = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(filter))
            {
                // Masquer les suggestions, sans toucher à l'arborescence déjà sélectionnée
                listBoxSuggestions.Visible = false;
                return;
            }
            // Filtrer les suggestions sous la textbox
            // Normalize filter by removing diacritics
            var normalizedFilter = Utils.RemoveDiacritics(filter).ToLowerInvariant();
            // Collect all matching tag names ignoring diacritics
            var allMatches = TagImg.GetTagDictionary().Values
                             .Where(t => t.IdTag != 0 && Utils.RemoveDiacritics(t.NomTag).ToLowerInvariant().Contains(normalizedFilter))
                             .Select(t => t.NomTag)
                             .ToList();
            // Prioritize those starting with filter (ignoring diacritics), then others
            var prefixMatches = allMatches
                .Where(n => Utils.RemoveDiacritics(n).ToLowerInvariant().StartsWith(normalizedFilter))
                .OrderBy(n => n);
            var otherMatches = allMatches
                .Where(n => !Utils.RemoveDiacritics(n).ToLowerInvariant().StartsWith(normalizedFilter))
                .OrderBy(n => n);
            var matches = prefixMatches.Concat(otherMatches).ToArray(); (otherMatches).ToArray();


            // Si une seule correspondance exacte, sélectionner directement
            if (matches.Length == 1 && matches[0].Equals(filter, StringComparison.OrdinalIgnoreCase))
            {
                listBoxSuggestions.Visible = false;
                // coche et déploie dans l'arbre
                var tag = TagImg.GetTagDictionary().Values.First(t => t.NomTag.Equals(filter, StringComparison.OrdinalIgnoreCase));
                var node = FindNodeByTag(tagTreeView.Nodes, tag);
                if (node != null)
                {
                    // expand parents
                    TreeNode? p = node.Parent;
                    while (p != null)
                    {
                        p.Expand(); p = p.Parent;
                    }
                    node.Checked = true;
                    AfficheLabelTags();
                }
                return;
            }

            if (matches.Any())
            {
                listBoxSuggestions.Items.Clear();
                listBoxSuggestions.Items.AddRange(matches);
                listBoxSuggestions.Visible = true;
            }
            else
            {
                listBoxSuggestions.Visible = false;
            }
        }

        private void ListBoxSuggestions_Click(object sender, EventArgs e)
        {
            if (listBoxSuggestions.SelectedItem is string chosen)
            {
                textBox1.Text = chosen;
                listBoxSuggestions.Visible = false;

                // trouve l'objet TagImg
                var tag = TagImg.GetTagDictionary().Values
                             .FirstOrDefault(t => t.NomTag.Equals(chosen, StringComparison.OrdinalIgnoreCase));
                if (tag != null)
                {
                    // trouve et coche le noeud, en déployant les parents
                    var node = FindNodeByTag(tagTreeView.Nodes, tag);
                    if (node != null)
                    {
                        // décocher tous d'abord si souhaité ou laisser existants
                        // Déploiement
                        TreeNode? p = node.Parent;
                        while (p != null)
                        {
                            p.Expand();
                            p = p.Parent;
                        }
                        node.Checked = true;
                        // Met à jour l'affichage des images selon sélection
                        AfficheLabelTags();
                    }
                }
            }
        }


        // méthode récursive pour retrouver le TreeNode dont .Tag == tag
        private TreeNode? FindNodeByTag(TreeNodeCollection nodes, TagImg tag)
        {
            foreach (TreeNode n in nodes)
            {
                if (n.Tag is TagImg t && t.IdTag == tag.IdTag)
                    return n;
                var child = FindNodeByTag(n.Nodes, tag);
                if (child != null) return child;
            }
            return null;
        }

        private void ListViewImage_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewImage.SelectedItems.Count != 1) return;
            if (listViewImage.SelectedItems[0].Tag is Img img)
            {
                using var dlg = new ImageDetailView(img, this);
                dlg.ShowDialog();
            }
        }
        public void RefreshListView()
        {
            AfficherImages(listImg);
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

            // Récupère le tag racine (id = 0)
            if (!TagImg.GetTagDictionary().TryGetValue(0, out TagImg? racine))
                throw new ArgumentNullException("Racine introuvable");

            // Au lieu d'ajouter le node racine, on ajoute directement ses enfants
            foreach (TagImg enfant in racine.Enfants)
            {
                var enfantNode = new TreeNode(enfant.NomTag) { Tag = enfant };
                AddChildrenTagTreeView(enfant, enfantNode);
                tagTreeView.Nodes.Add(enfantNode);
            }

            /*// Optionnel : déplier tout par défaut
            foreach (TreeNode node in tagTreeView.Nodes)
                node.Expand();*/
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
            //var result = gestionTagForm.ShowDialog();

            gestionTagForm.FormClosed += (s, args) =>
            {
                TagImg.ClearDictionary();
                TagImg.InitializeDictionary();
                LoadTagTreeView();  // On recharge l'arbre avce les tag ajoute , ou avec le tag supprimé
            };

            gestionTagForm.ShowDialog();

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
                if (item.Tag is Img image)
                {
                    imagesSelectionnes.Add(image);
                }
            }

            // Ouvre la fenêtre de modification des tags et on lui passe les images sélectionnées
            ModificationImage_Tag modifImgTag = new ModificationImage_Tag(imagesSelectionnes,this);
            modifImgTag.ShowDialog();
        }

        // Ici on a cette fonction qui  va gérer l'événement de clic sur le TreeView des tags
        private void tagTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            tagTreeView.AfterCheck -= tagTreeView_AfterCheck; // Détache l'événement pour éviter la récursivité

            foreach (TreeNode fils in e.Node.Nodes)
            {
                fils.Checked = e.Node.Checked;
            }

            AfficheLabelTags();

            tagTreeView.AfterCheck += tagTreeView_AfterCheck; // Réattache l'événement
        }

        // Ensuite on a cette fonction qui  va afficher les tags les plus spécifiques dans le label.
        // en plus permet filtre les images en fonction des tags qu'on a coches.
        private void AfficheLabelTags()
        {
            List<TagImg> FeuillesCoches = recuperationTagsFeuilles(tagTreeView.Nodes);
            labelTags.Text = "Tag(s) le(s) plus spécifique(s) : " + string.Join(", ", FeuillesCoches.Select(t => t.NomTag));
        
            if (FeuillesCoches.Count == 0)
            {
                AfficherImages(listImg);
                return;
            }

            List<Img> imagesFiltrées = listImg.Where(img => img.Tags.Any(tag => FeuillesCoches.Any(t => t.IdTag == tag.IdTag))).ToList();

            AfficherImages(imagesFiltrées);

        }


        // Ici cette fonction va récuperer les tags qu'on a cochés dans l'arbre , pas besoin que soit forcment des feuilles 
        private void RecupererTagCoches(TreeNode node, List<string> tagsSelectionne)
        {
            if (node.Checked && node.Tag is TagImg tag)
            {
                tagsSelectionne.Add(tag.NomTag);
            }
            foreach (TreeNode fils in node.Nodes)
            {
                RecupererTagCoches(fils, tagsSelectionne);
            }
        }

        // Ici cette fonction prends en compte que les tags qui sont des feuilles et puis on renvoie la liste.
        private List<TagImg> recuperationTagsFeuilles(TreeNodeCollection nodes){ 

            List<TagImg> tagsFeuilles = new List<TagImg>();

            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                {
                    bool aucunFilsCoche = !node.Nodes.Cast<TreeNode>().Any(fils => fils.Checked);
                    if (aucunFilsCoche && node.Tag is TagImg tagFeuille)
                        tagsFeuilles.Add(tagFeuille);
                }
                tagsFeuilles.AddRange(recuperationTagsFeuilles(node.Nodes));
            }

            return tagsFeuilles;
        }
    }
}