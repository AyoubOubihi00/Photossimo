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
            if (disposing && (components != null)) components.Dispose();
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
                Height = 100
            };

            txtRecherche = new TextBox
            {
                PlaceholderText = "Tapez pour filtrer...",
                Dock = DockStyle.Top
            };
            txtRecherche.TextChanged += TxtRecherche_TextChanged;

            lblRechercheResult = new Label
            {
                Text = string.Empty,
                Dock = DockStyle.Top,
                Padding = new Padding(5)
            };

            groupRecherche.Controls.Add(lblRechercheResult);
            groupRecherche.Controls.Add(txtRecherche);

            // ==== groupListe ====
            groupListe = new GroupBox
            {
                Text = "Liste des tags",
                Dock = DockStyle.Fill
            };

            dgvTags = new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 250,
                AutoGenerateColumns = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                EditMode = DataGridViewEditMode.EditOnEnter
            };

            // Colonne de sélection
            var colSelect = new DataGridViewCheckBoxColumn
            {
                HeaderText = "",
                Width = 30,
                Name = "colSelect"
            };
            dgvTags.Columns.Add(colSelect);

            var colId = new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "IdTag", ReadOnly = true };
            var colNom = new DataGridViewTextBoxColumn { HeaderText = "Nom", DataPropertyName = "NomTag" };
            var colParent = new DataGridViewTextBoxColumn { HeaderText = "Parent", DataPropertyName = "ParentNom", ReadOnly = true };
            dgvTags.Columns.AddRange(colId, colNom, colParent);

            dgvTags.CellValueChanged += DgvTags_CellValueChanged;
            dgvTags.CurrentCellDirtyStateChanged += DgvTags_CurrentCellDirtyStateChanged;
            dgvTags.DataBindingComplete += DgvTags_DataBindingComplete;
            dgvTags.CellContentClick += DgvTags_CellContentClick;

            btnSupprimerSelection = new Button
            {
                Text = "Supprimer sélection",
                Dock = DockStyle.Top,
                Enabled = false,
                Width = 200,
                Height = 30,
                Margin = new Padding(3, 20, 3, 3) // ajoute un espace au-dessus
            };
            btnSupprimerSelection.Click += BtnSupprimerSelection_Click;

            groupListe.Controls.Add(btnSupprimerSelection);
            groupListe.Controls.Add(dgvTags);

            // ==== groupActions ====
            groupActions = new GroupBox
            {
                Text = "Actions",
                Dock = DockStyle.Bottom,
                Height = 80
            };

            btnCreer = new Button
            {
                Text = "Créer un tag",
                Size = new Size(120, 30),
                Left = 20,
                Top = 25
            };
            btnCreer.Click += BtnCreer_Click;

            btnModifier = new Button
            {
                Text = "Modifier un tag",
                Size = new Size(120, 30),
                Left = 160,
                Top = 25
            };
            btnModifier.Click += BtnModifier_Click;

            btnSupprimerTag = new Button
            {
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