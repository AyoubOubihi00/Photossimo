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
            pictureBoxFull.Size = pictureBoxFull.Image.Size;
            pictureBoxFull.SizeMode = PictureBoxSizeMode.Normal;

            // Affiche le nom sous l’image
            labelName.Text = _img.NomImage;

            // Charge les tags (sans le root)
            listBoxTags.DataSource = _img.Tags
                                         .Where(t => t.IdTag != 0)
                                         .Select(t => t.NomTag)
                                         .ToList();

            this.Shown += ImageDetailView_Shown;
        }

        private void ImageDetailView_Shown(object sender, EventArgs e)
        {
            int controlsHeight = rightPanel.Height;
            int deltaHeight = this.Height - this.ClientSize.Height;
            int deltaWidth = this.Width - this.ClientSize.Width;

            int desiredClientWidth = pictureBoxFull.Image.Width;
            int desiredClientHeight = pictureBoxFull.Image.Height + controlsHeight;

            var screenArea = Screen.FromControl(this).WorkingArea;
            desiredClientWidth = Math.Min(desiredClientWidth, screenArea.Width);
            desiredClientHeight = Math.Min(desiredClientHeight, screenArea.Height);

            this.Size = new Size(desiredClientWidth + deltaWidth, desiredClientHeight + deltaHeight);
            panelImage.AutoScrollMinSize = pictureBoxFull.Image.Size;

            // Recharger les tags (au cas où)
            listBoxTags.DataSource = null;
            listBoxTags.DataSource = _img.Tags
                                     .Where(t => t.IdTag != 0)
                                     .Select(t => t.NomTag)
                                     .ToList();
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            using var ren = new NomImageModif(_img.NomImage);
            if (ren.ShowDialog() != DialogResult.OK)
                return;

            string oldName = _img.NomImage;
            string extension = System.IO.Path.GetExtension(oldName);
            _img.NomImage = ren.NouveauNom + extension;

            // 1) MAJ BDD
            using (var tx = DataBase.GetInstance().BeginTransaction())
            {
                _dao.Update(_img, tx);
                tx.Commit();
            }

            // 2) Dispose de TOUTES les images pour libérer le fichier
            if (_img.Image != null)
            {
                _img.Image.Dispose();
                _img.Image = null!;
            }
            if (pictureBoxFull.Image != null)
            {
                pictureBoxFull.Image.Dispose();
                pictureBoxFull.Image = null;
            }

            // 3) Renommage physique
            var folder = Path.GetDirectoryName(_img.GetCheminImage());
            var oldPath = Path.Combine(folder!, oldName);
            var newPath = Path.Combine(folder, _img.NomImage);
            if (File.Exists(oldPath))
                File.Move(oldPath, newPath);

            // 4) Recharger l’image clonée
            using (var fs = new FileStream(newPath, FileMode.Open, FileAccess.Read))
            {
                var tmp = Image.FromStream(fs);
                var bmp = new Bitmap(tmp);
                tmp.Dispose();

                _img.Image = bmp;
                pictureBoxFull.Image = bmp;
                pictureBoxFull.Size = bmp.Size;
            }

            // 5) Mise à jour du label et de la vue principale
            labelName.Text = _img.NomImage;
            _parent.RefreshListView();
        }


        private void btnEditTags_Click(object sender, EventArgs e)
        {
            using var et = new ModificationImage_Tag(new System.Collections.Generic.List<Img> { _img });
            if (et.ShowDialog() != DialogResult.OK) return;

            using var tx = DataBase.GetInstance().BeginTransaction();
            _dao.Update(_img, tx);
            tx.Commit();

            listBoxTags.DataSource = _img.Tags
                                     .Where(t => t.IdTag != 0)
                                     .Select(t => t.NomTag)
                                     .ToList();
            _parent.RefreshListView();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Supprimer cette image définitivement ?", "Confirmation",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            using var tx = DataBase.GetInstance().BeginTransaction();
            _dao.Delete(_img, tx);
            tx.Commit();

            string path = _img.GetCheminImage();
            pictureBoxFull.Image.Dispose();
            if (File.Exists(path)) File.Delete(path);

            _parent.RemoveImage(_img, _parent.listImg.IndexOf(_img));
            Close();
        }
    }
}