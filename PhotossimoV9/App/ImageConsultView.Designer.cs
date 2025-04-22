namespace Photossimo
{
    partial class ImageConsultView
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
            tableLayoutPanel1 = new TableLayoutPanel();
            buttonCancel = new Button();
            buttonSave = new Button();
            dataGridView1 = new DataGridView();
            ColumnImage = new DataGridViewImageColumn();
            labelTag = new Label();
            labelImage = new Label();
            labelTitle = new Label();
            buttonAjouter = new Button();
            listBox1 = new ListBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            comboBoxTag = new ComboBox();
            listBoxTagsSelectionnes = new ListBox();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(buttonCancel, 0, 5);
            tableLayoutPanel1.Controls.Add(buttonSave, 0, 5);
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 2);
            tableLayoutPanel1.Controls.Add(labelTag, 0, 3);
            tableLayoutPanel1.Controls.Add(labelImage, 0, 1);
            tableLayoutPanel1.Controls.Add(labelTitle, 0, 0);
            tableLayoutPanel1.Controls.Add(buttonAjouter, 1, 4);
            tableLayoutPanel1.Controls.Add(listBox1, 1, 3);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 4);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.222424F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.148282F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 49.54792F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.052441F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15.1898737F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.6582279F));
            tableLayoutPanel1.Size = new Size(542, 553);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonCancel
            // 
            buttonCancel.AutoSize = true;
            buttonCancel.Dock = DockStyle.Fill;
            buttonCancel.Location = new Point(40, 492);
            buttonCancel.Margin = new Padding(40, 10, 40, 10);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(191, 51);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Annuler";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonAnnuler;
            // 
            // buttonSave
            // 
            buttonSave.AutoSize = true;
            buttonSave.Dock = DockStyle.Fill;
            buttonSave.Location = new Point(311, 492);
            buttonSave.Margin = new Padding(40, 10, 40, 10);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(191, 51);
            buttonSave.TabIndex = 1;
            buttonSave.Text = "Enregistrer et Valider";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonValiderTag;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ColumnImage });
            tableLayoutPanel1.SetColumnSpan(dataGridView1, 2);
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 88);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(536, 268);
            dataGridView1.TabIndex = 3;
            // 
            // ColumnImage
            // 
            ColumnImage.HeaderText = "";
            ColumnImage.MinimumWidth = 6;
            ColumnImage.Name = "ColumnImage";
            ColumnImage.Width = 125;
            // 
            // labelTag
            // 
            labelTag.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelTag.AutoSize = true;
            labelTag.Location = new Point(3, 378);
            labelTag.Name = "labelTag";
            labelTag.Size = new Size(50, 20);
            labelTag.TabIndex = 5;
            labelTag.Text = "label1";
            // 
            // labelImage
            // 
            labelImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelImage.AutoSize = true;
            labelImage.Location = new Point(3, 65);
            labelImage.Name = "labelImage";
            labelImage.Size = new Size(50, 20);
            labelImage.TabIndex = 7;
            labelImage.Text = "label3";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(labelTitle, 2);
            labelTitle.Dock = DockStyle.Fill;
            labelTitle.Font = new Font("Segoe UI", 24F);
            labelTitle.Location = new Point(3, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(536, 51);
            labelTitle.TabIndex = 6;
            labelTitle.Text = "label2";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonAjouter
            // 
            buttonAjouter.Location = new Point(274, 401);
            buttonAjouter.Name = "buttonAjouter";
            buttonAjouter.Size = new Size(180, 29);
            buttonAjouter.TabIndex = 9;
            buttonAjouter.Text = "Ajouter Tag";
            buttonAjouter.UseVisualStyleBackColor = true;
            buttonAjouter.Click += buttonAjouterTag;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(274, 362);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(8, 4);
            listBox1.TabIndex = 10;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(comboBoxTag);
            flowLayoutPanel1.Controls.Add(listBoxTagsSelectionnes);
            flowLayoutPanel1.Location = new Point(3, 401);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(265, 78);
            flowLayoutPanel1.TabIndex = 11;
            // 
            // comboBoxTag
            // 
            comboBoxTag.FormattingEnabled = true;
            comboBoxTag.Location = new Point(3, 3);
            comboBoxTag.Name = "comboBoxTag";
            comboBoxTag.Size = new Size(186, 28);
            comboBoxTag.TabIndex = 0;
            // 
            // listBoxTagsSelectionnes
            // 
            listBoxTagsSelectionnes.FormattingEnabled = true;
            listBoxTagsSelectionnes.Location = new Point(3, 37);
            listBoxTagsSelectionnes.Name = "listBoxTagsSelectionnes";
            listBoxTagsSelectionnes.Size = new Size(186, 24);
            listBoxTagsSelectionnes.TabIndex = 1;
            // 
            // ImageConsultView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(542, 553);
            Controls.Add(tableLayoutPanel1);
            Name = "ImageConsultView";
            Text = "ImageConsultView";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button buttonCancel;
        private Button buttonSave;
        private Label labelTag;
        private Label labelImage;
        private Label labelTitle;
        private DataGridView dataGridView1;
        private DataGridViewImageColumn ColumnImage;
        private ListBox listBox1;
        private Button buttonAjouter;
        private FlowLayoutPanel flowLayoutPanel1;
        private ComboBox comboBoxTag;
        private ListBox listBoxTagsSelectionnes;
    }
}