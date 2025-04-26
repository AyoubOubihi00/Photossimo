using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Photossimo;
using PhotossimoV9.DB;
using PhotossimoV9.DB.DAO;
using PhotossimoV9.Object;

namespace PhotossimoV9.App
{
    public partial class GestionTag : Form
    {
        private readonly BindingSource _bsTags = new BindingSource();

        public GestionTag()
        {
            InitializeComponent();
            dgvTags.SelectionChanged += DgvTags_SelectionChanged;
            LoadTags();
            AttachEvents();
        }

        private void DgvTags_SelectionChanged(object sender, EventArgs e)
        {
            UpdateDeleteButtons();
        }

        // Charge et filtre les tags, triés alphabétiquement
        private void LoadTags(string filter = "")
        {
            var normalizedFilter = Utils.Utils.RemoveDiacritics(filter).ToLowerInvariant();

            var list = TagImg.GetTagDictionary().Values
                .Where(t => string.IsNullOrEmpty(normalizedFilter) ||
                            Utils.Utils.RemoveDiacritics(t.NomTag).ToLowerInvariant().Contains(normalizedFilter))
                .OrderBy(t => t.NomTag)
                .Select(t => new
                {
                    t.IdTag,
                    t.NomTag,
                    ParentNom = t.Parent?.NomTag ?? "<racine>"
                })
                .ToList();

            _bsTags.DataSource = list;
            dgvTags.DataSource = _bsTags;
        }

        private void AttachEvents()
        {
            txtRecherche.TextChanged += TxtRecherche_TextChanged;
            dgvTags.CurrentCellDirtyStateChanged += DgvTags_CurrentCellDirtyStateChanged;
            dgvTags.DataBindingComplete += DgvTags_DataBindingComplete;
            dgvTags.CellValueChanged += DgvTags_CellValueChanged;
            dgvTags.CellContentClick += DgvTags_CellContentClick;
            dgvTags.SelectionChanged += (s, e) => UpdateDeleteButtons();
            dgvTags.CellDoubleClick += DgvTags_CellDoubleClick; // double-clic pour cocher
        }

        private void TxtRecherche_TextChanged(object sender, EventArgs e)
        {
            var raw = txtRecherche.Text.Trim();
            LoadTags(raw);
        }

        // Gère l'édition des checkbox et rafraîchit les boutons
        private void DgvTags_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvTags.Columns["colSelect"].Index && e.RowIndex >= 0)
            {
                dgvTags.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DgvTags_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvTags.IsCurrentCellDirty)
                dgvTags.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void DgvTags_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvTags.ClearSelection();
            UpdateDeleteButtons();
        }

        private void DgvTags_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Si case cochée/décochée, mise à jour des boutons
            if (e.ColumnIndex == dgvTags.Columns["colSelect"].Index)
            {
                UpdateDeleteButtons();
                return;
            }

            // Si nom modifié, commit en base
            if (e.ColumnIndex == dgvTags.Columns["NomTag"].Index && e.RowIndex >= 0)
            {
                var row = dgvTags.Rows[e.RowIndex];
                int id = (int)row.Cells["IdTag"].Value;
                string newName = row.Cells["NomTag"].Value?.ToString() ?? string.Empty;
                var tag = TagImg.GetTagDictionary()[id];
                tag.NomTag = newName;

                var db = DataBase.GetInstance();
                using var trx = db.BeginTransaction();
                try
                {
                    new DAO_TagImg().Update(tag, trx);
                    trx.Commit();
                }
                catch
                {
                    trx.Rollback();
                    MessageBox.Show("Erreur lors de la mise à jour du tag.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateDeleteButtons()
        {
            // Construire l'ensemble des lignes à traiter (cochées ou sélectionnées)
            var involvedRows = new HashSet<DataGridViewRow>();
            foreach (DataGridViewRow row in dgvTags.Rows)
            {
                if (Convert.ToBoolean(row.Cells["colSelect"].Value))
                    involvedRows.Add(row);
            }

            // Bouton "Décocher tout" si au moins une case cochée
            bool anyChecked = involvedRows.Any(r => Convert.ToBoolean(r.Cells["colSelect"].Value));
            btnSupprimerSelection.Enabled = anyChecked;

            // Bouton "Supprimer tag(s)" si au moins une ligne impliquée
            btnSupprimerTag.Enabled = involvedRows.Count > 0;

            // Bouton "Modifier" si exactement une ligne impliquée
            btnModifier.Enabled = involvedRows.Count == 1;
        }

        private void BtnSupprimerSelection_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvTags.Rows)
                row.Cells["colSelect"].Value = false;
            dgvTags.Refresh();
            UpdateDeleteButtons();
        }

        private void BtnSupprimerTag_Click(object sender, EventArgs e)
        {
            var rows = dgvTags.Rows.Cast<DataGridViewRow>()
                .Where(r => Convert.ToBoolean(r.Cells["colSelect"].Value))
                .ToList();
            if (!rows.Any()) return;

            var names = rows.Select(r => r.Cells["NomTag"].Value?.ToString()).Where(n => n != null).ToList();
            var msg = "Confirmez la suppression :\n" + string.Join("\n", names);
            if (MessageBox.Show(msg, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            try
            {
                foreach (var row in rows)
                {
                    int id = (int)row.Cells["IdTag"].Value;
                    var tag = TagImg.GetTagDictionary()[id];
                    if (tag.IdTag != 0)
                        tag.SupprimerEnfant();
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

            TagImg.ClearDictionary();
            TagImg.InitializeDictionary();
            LoadTags(txtRecherche.Text.Trim());
        }

        private void BtnCreer_Click(object sender, EventArgs e)
        {
            using var f = new CreateTag();
            if (f.ShowDialog() == DialogResult.OK)
            {
                TagImg.ClearDictionary();
                TagImg.InitializeDictionary();
                LoadTags(txtRecherche.Text.Trim());
            }
        }

        // Double-clic pour basculer la checkbox
        private void DgvTags_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvTags.Rows[e.RowIndex];
            var cell = row.Cells["colSelect"];
            bool current = Convert.ToBoolean(cell.Value);
            cell.Value = !current;
            dgvTags.Refresh();
            UpdateDeleteButtons();
        }

        // Modification via fenêtré externe
        private void BtnModifier_Click(object sender, EventArgs e)
        {
            // 1) Déterminer la ligne à modifier : priorité aux cases cochées, sinon à la ligne sélectionnée
            var checkedRows = dgvTags.Rows
                .Cast<DataGridViewRow>()
                .Where(r => Convert.ToBoolean(r.Cells["colSelect"].Value))
                .ToList();

            DataGridViewRow rowToModify;
            if (checkedRows.Count == 1)
            {
                rowToModify = checkedRows[0];
            }
            else
            {
                MessageBox.Show(
                    "Sélectionnez exactement un tag à modifier (case cochée ou ligne sélectionnée).",
                    "Attention",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // 2) Récupérer l'objet TagImg lié à cette ligne
            dynamic data = rowToModify.DataBoundItem;
            int id = data.IdTag;
            var tag = TagImg.GetTagDictionary()[id];

            // 3) Ouvrir le formulaire de modification
            using (var form = new ModificationTag(tag))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // 4) Si OK, recharger les tags
                    TagImg.ClearDictionary();
                    TagImg.InitializeDictionary();
                    LoadTags(txtRecherche.Text.Trim());
                }
            }
        }

    }
}