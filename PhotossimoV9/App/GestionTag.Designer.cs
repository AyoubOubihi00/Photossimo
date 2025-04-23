namespace PhotossimoV9.App
{
    partial class GestionTag
    {
        private System.ComponentModel.IContainer components = null;
        private GroupBox groupRecherche;
        private TextBox txtRecherche;
        private Label lblRechercheResult;

        private GroupBox groupListe;
        private DataGridView dgvTags;
        private Button btnSupprimerSelection;

        private GroupBox groupActions;
        private Button btnCreer;
        private Button btnModifier;
        private Button btnSupprimerTag;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // ==== groupRecherche ====
            groupRecherche = new GroupBox
            {
                Text = "Recherche de tag",
                Dock = DockStyle.Top,
                Height = 60
            };

            txtRecherche = new TextBox
            {
                Name = "txtRecherche",
                PlaceholderText = "Tapez pour filtrer...",
                Dock = DockStyle.Top
            };
            txtRecherche.TextChanged += TxtRecherche_TextChanged;

            lblRechercheResult = new Label
            {
                Name = "lblRechercheResult",
                Text = string.Empty,
                Dock = DockStyle.Top,
                Padding = new Padding(5)
            };

            groupRecherche.Controls.Add(lblRechercheResult);
            groupRecherche.Controls.Add(txtRecherche);

            // ==== groupListe ====
            groupListe = new GroupBox
            {
                Name = "groupListe",
                Text = "Liste des tags",
                Dock = DockStyle.Fill
            };

            dgvTags = new DataGridView
            {
                Name = "dgvTags",
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                EditMode = DataGridViewEditMode.EditOnEnter,
                RowHeadersVisible = false
            };

            // Colonne de case à cocher
            var colSelect = new DataGridViewCheckBoxColumn
            {
                Name = "colSelect",
                HeaderText = string.Empty,
                Width = 30,
                DataPropertyName = "IsSelected"
            };

            // Colonne ID
            var colId = new DataGridViewTextBoxColumn
            {
                Name = "IdTag",
                HeaderText = "ID",
                DataPropertyName = "IdTag",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            // Colonne Nom
            var colNom = new DataGridViewTextBoxColumn
            {
                Name = "NomTag",
                HeaderText = "Nom",
                DataPropertyName = "NomTag",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            // Colonne Parent
            var colParent = new DataGridViewTextBoxColumn
            {
                Name = "ParentNom",
                HeaderText = "Parent",
                DataPropertyName = "ParentNom",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            dgvTags.Columns.AddRange(colSelect, colId, colNom, colParent);

            dgvTags.CurrentCellDirtyStateChanged += DgvTags_CurrentCellDirtyStateChanged;
            dgvTags.DataBindingComplete += DgvTags_DataBindingComplete;
            dgvTags.CellValueChanged += DgvTags_CellValueChanged;
            dgvTags.CellContentClick += DgvTags_CellContentClick;
            btnSupprimerSelection = new Button
            {
                Name = "btnSupprimerSelection",
                Text = "Décocher tout",
                Dock = DockStyle.Bottom,
                Enabled = false,
                Margin = new Padding(25),
                Height = 35,
                Width = 200
            };
            btnSupprimerSelection.Click += BtnSupprimerSelection_Click;

            groupListe.Controls.Add(btnSupprimerSelection);
            groupListe.Controls.Add(dgvTags);

            // ==== groupActions ====
            groupActions = new GroupBox
            {
                Name = "groupActions",
                Text = "Actions possibles sur les tags :",
                Dock = DockStyle.Bottom,
                Height = 80
            };

            btnCreer = new Button
            {
                Name = "btnCreer",
                Text = "Créer un tag",
                Size = new Size(120, 30),
                Left = 20,
                Top = 25
            };
            btnCreer.Click += BtnCreer_Click;

            btnModifier = new Button
            {
                Name = "btnModifier",
                Text = "Modifier un tag",
                Size = new Size(120, 30),
                Left = 160,
                Top = 25,
                Enabled = false
            };
            btnModifier.Click += BtnModifier_Click;

            btnSupprimerTag = new Button
            {
                Name = "btnSupprimerTag",
                Text = "Supprimer tag(s)",
                Size = new Size(120, 30),
                Left = 300,
                Top = 25,
                Enabled = false
            };
            btnSupprimerTag.Click += BtnSupprimerTag_Click;

            groupActions.Controls.Add(btnCreer);
            groupActions.Controls.Add(btnModifier);
            groupActions.Controls.Add(btnSupprimerTag);

            // ==== GestionTag Form ====
            this.Text = "Gestion des Tags";
            this.ClientSize = new Size(1040, 585);
            this.Controls.Add(groupListe);
            this.Controls.Add(groupActions);
            this.Controls.Add(groupRecherche);
        }
    }
}