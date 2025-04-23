namespace Photossimo
{
    partial class ImageImportView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonBrowse = new Button();
            buttonCancel = new Button();
            buttonValiderImport = new Button();
            buttonAjouterTag = new Button();
            buttonSupprimerTag = new Button();
            comboBoxTag = new ComboBox();
            listBoxTagsSelectionnes = new ListBox();
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            panelDroit = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panelDroit.SuspendLayout();
            SuspendLayout();
            // 
            // buttonBrowse
            // 
            buttonBrowse.Dock = DockStyle.Fill;
            buttonBrowse.Location = new Point(803, 103);
            buttonBrowse.Name = "buttonBrowse";
            buttonBrowse.Size = new Size(216, 34);
            buttonBrowse.TabIndex = 2;
            buttonBrowse.Text = "Parcourir";
            buttonBrowse.Click += buttonBrowse_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Dock = DockStyle.Fill;
            buttonCancel.Location = new Point(3, 856);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(794, 54);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Annuler";
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonValiderImport
            // 
            buttonValiderImport.Dock = DockStyle.Fill;
            buttonValiderImport.Location = new Point(803, 856);
            buttonValiderImport.Name = "buttonValiderImport";
            buttonValiderImport.Size = new Size(216, 54);
            buttonValiderImport.TabIndex = 6;
            buttonValiderImport.Text = "Valider Import";
            buttonValiderImport.Click += buttonValiderImport_Click;
            // 
            // buttonAjouterTag
            // 
            buttonAjouterTag.Dock = DockStyle.Top;
            buttonAjouterTag.Location = new Point(3, 40);
            buttonAjouterTag.Margin = new Padding(3, 10, 3, 20);
            buttonAjouterTag.MaximumSize = new Size(194, 30);
            buttonAjouterTag.MinimumSize = new Size(194, 30);
            buttonAjouterTag.Name = "buttonAjouterTag";
            buttonAjouterTag.Size = new Size(194, 30);
            buttonAjouterTag.TabIndex = 1;
            buttonAjouterTag.Text = "Ajouter Tag";
            buttonAjouterTag.Click += buttonAjouterTag_Click;
            // 
            // buttonSupprimerTag
            // 
            buttonSupprimerTag.Dock = DockStyle.Top;
            buttonSupprimerTag.Location = new Point(3, 73);
            buttonSupprimerTag.Margin = new Padding(3, 10, 3, 20);
            buttonSupprimerTag.MaximumSize = new Size(194, 30);
            buttonSupprimerTag.MinimumSize = new Size(194, 30);
            buttonSupprimerTag.Name = "buttonSupprimerTag";
            buttonSupprimerTag.Size = new Size(194, 30);
            buttonSupprimerTag.TabIndex = 2;
            buttonSupprimerTag.Text = "Supprimer Tag";
            buttonSupprimerTag.Click += buttonSupprimerTag_Click;
            // 
            // comboBoxTag
            // 
            comboBoxTag.Dock = DockStyle.Top;
            comboBoxTag.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTag.Location = new Point(3, 3);
            comboBoxTag.Name = "comboBoxTag";
            comboBoxTag.Size = new Size(194, 28);
            comboBoxTag.TabIndex = 0;
            // 
            // listBoxTagsSelectionnes
            // 
            listBoxTagsSelectionnes.Dock = DockStyle.Fill;
            listBoxTagsSelectionnes.Location = new Point(3, 110);
            listBoxTagsSelectionnes.Margin = new Padding(3, 20, 3, 20);
            listBoxTagsSelectionnes.MaximumSize = new Size(194, 400);
            listBoxTagsSelectionnes.MinimumSize = new Size(194, 400);
            listBoxTagsSelectionnes.Name = "listBoxTagsSelectionnes";
            listBoxTagsSelectionnes.SelectionMode = SelectionMode.MultiExtended;
            listBoxTagsSelectionnes.Size = new Size(194, 400);
            listBoxTagsSelectionnes.TabIndex = 3;
            // 
            // label1
            // 
            tableLayoutPanel1.SetColumnSpan(label1, 2);
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 24F);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(1016, 60);
            label1.TabIndex = 0;
            label1.Text = "Importer une image";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            tableLayoutPanel1.SetColumnSpan(label2, 2);
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 60);
            label2.Name = "label2";
            label2.Size = new Size(1016, 40);
            label2.TabIndex = 1;
            label2.Text = "Sélection de l'image à importer (Format JPEG)";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(3, 143);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(794, 678);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 78.2778854F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.7221127F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(buttonBrowse, 1, 2);
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 3);
            tableLayoutPanel1.Controls.Add(panelDroit, 1, 3);
            tableLayoutPanel1.Controls.Add(buttonCancel, 0, 5);
            tableLayoutPanel1.Controls.Add(buttonValiderImport, 1, 5);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.Size = new Size(1022, 913);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panelDroit
            // 
            panelDroit.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            panelDroit.Controls.Add(comboBoxTag, 0, 0);
            panelDroit.Controls.Add(buttonAjouterTag, 0, 1);
            panelDroit.Controls.Add(buttonSupprimerTag, 0, 2);
            panelDroit.Controls.Add(listBoxTagsSelectionnes, 0, 3);
            panelDroit.Location = new Point(803, 143);
            panelDroit.Name = "panelDroit";
            panelDroit.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            panelDroit.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            panelDroit.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            panelDroit.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelDroit.Size = new Size(200, 555);
            panelDroit.TabIndex = 4;
            // 
            // ImageImportView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1022, 913);
            Controls.Add(tableLayoutPanel1);
            MaximizeBox = false;
            MaximumSize = new Size(1040, 960);
            MinimumSize = new Size(1040, 960);
            Name = "ImageImportView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Importer une image";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            panelDroit.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button buttonBrowse;
        private Button buttonCancel;
        private Button buttonValiderImport;
        private Button buttonAjouterTag;
        private Button buttonSupprimerTag;
        private ComboBox comboBoxTag;
        private ListBox listBoxTagsSelectionnes;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel panelDroit;
    }
}