using System;
using System.Linq;
using System.Windows.Forms;
using Photossimo;
using PhotossimoV9.DB;
using PhotossimoV9.DB.DAO;
using PhotossimoV9.Object;

namespace PhotossimoV9.App
{
    public partial class GestionTag : Form
    {
        private BindingSource _bsTags = new BindingSource();

        public GestionTag()
        {
            InitializeComponent();
            LoadTags();
            AttachEvents();
        }

        // Charge et filtre les tags, triés alphabétiquement
        private void LoadTags(string filter = "")
        {
            var list = TagImg.GetTagDictionary().Values
                .Where(t => string.IsNullOrEmpty(filter) ||
                            t.NomTag.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0)
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
            dgvTags.CurrentCellDirtyStateChanged += DgvTags_CurrentCellDirtyStateChanged;
            dgvTags.DataBindingComplete += DgvTags_DataBindingComplete;
            dgvTags.CellValueChanged += DgvTags_CellValueChanged;
            dgvTags.CellContentClick += DgvTags_CellContentClick;
        }

        // Commit click on checkbox
        private void DgvTags_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvTags.Columns["colSelect"].Index && e.RowIndex >= 0)
            {
                dgvTags.CommitEdit(DataGridViewDataErrorContexts.Commit);
                UpdateDeleteButtons();
            }
        }

        // Filtrage live à la frappe
        private void TxtRecherche_TextChanged(object sender, EventArgs e)
        {
            LoadTags(txtRecherche.Text.Trim());
        }

        // Inline modification du nom via transaction
        private void DgvTags_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Si checkbox, actualise les boutons
            if (e.ColumnIndex == dgvTags.Columns["colSelect"].Index)
            {
                UpdateDeleteButtons();
                return;
            }
            // Si nom modifié
            if (e.ColumnIndex == dgvTags.Columns[1].Index) // colonne Nom
            {
                var row = dgvTags.Rows[e.RowIndex];
                int id = (int)row.Cells[0].Value;
                string nouveauNom = row.Cells[1].Value.ToString();
                var tag = TagImg.GetTagDictionary()[id];
                tag.NomTag = nouveauNom;

                var db = DataBase.GetInstance();
                using var transaction = db.BeginTransaction();
                try
                {
                    new DAO_Tag().Update(tag, transaction);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Erreur mise à jour : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        // Active/Desactive boutons de suppression
        private void UpdateDeleteButtons()
        {
            bool anyChecked = dgvTags.Rows.Cast<DataGridViewRow>()
                .Any(r => Convert.ToBoolean(r.Cells["colSelect"].Value));
            btnSupprimerSelection.Enabled = anyChecked;
            btnSupprimerTag.Enabled = anyChecked;
        }

        // Suppression multiple avec confirmation
        private void BtnSupprimerTag_Click(object sender, EventArgs e)
        {
            var selectedRows = dgvTags.Rows.Cast<DataGridViewRow>()
                .Where(r => Convert.ToBoolean(r.Cells["colSelect"].Value))
                .ToList();
            if (!selectedRows.Any()) return;

            var names = selectedRows.Select(r => r.Cells[1].Value.ToString()).ToList();
            string message = "Êtes-vous sûr de vouloir supprimer les tags suivants ?\n" + string.Join("\n", names);
            if (MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            var db = DataBase.GetInstance();
            using var transaction = db.BeginTransaction();
            try
            {
                foreach (var row in selectedRows)
                {
                    int id = (int)row.Cells[0].Value;
                    var tag = TagImg.GetTagDictionary()[id];
                    if (tag.IdTag != 0)
                        tag.SupprimerEnfant();
                }
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }

            TagImg.ClearDictionary();
            TagImg.InitializeDictionary();
            LoadTags(txtRecherche.Text.Trim());
        }

        private void BtnSupprimerSelection_Click(object sender, EventArgs e)
        {
            // Décoche toutes les cases sélectionnées
            foreach (DataGridViewRow row in dgvTags.Rows)
            {
                row.Cells["colSelect"].Value = false;
            }
            dgvTags.Refresh();
            UpdateDeleteButtons();
        }

        // Création via fenêtre externe
        private void BtnCreer_Click(object sender, EventArgs e)
        {
            using var form = new CreateTag();
            if (form.ShowDialog() == DialogResult.OK)
            {
                TagImg.ClearDictionary();
                TagImg.InitializeDictionary();
                LoadTags(txtRecherche.Text.Trim());
            }
        }

        // Modification via fenêtre externe
        private void BtnModifier_Click(object sender, EventArgs e)
        {
            var checkedRows = dgvTags.Rows.Cast<DataGridViewRow>()
                .Where(r => Convert.ToBoolean(r.Cells["colSelect"].Value))
                .ToList();
            if (checkedRows.Count != 1)
            {
                MessageBox.Show("Sélectionnez exactement un tag à modifier.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int id = (int)checkedRows[0].Cells["IdTag"].Value;
            var tag = TagImg.GetTagDictionary()[id];
            using var form = new ModificationTag(tag);
            if (form.ShowDialog() == DialogResult.OK)
            {
                TagImg.ClearDictionary();
                TagImg.InitializeDictionary();
                LoadTags(txtRecherche.Text.Trim());
            }
        }
    }
}
