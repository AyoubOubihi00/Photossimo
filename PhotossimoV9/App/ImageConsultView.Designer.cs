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
            textBox1 = new TextBox();
            labelTag = new Label();
            labelImage = new Label();
            labelTitle = new Label();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            tableLayoutPanel1.Controls.Add(textBox1, 0, 4);
            tableLayoutPanel1.Controls.Add(labelTag, 0, 3);
            tableLayoutPanel1.Controls.Add(labelImage, 0, 1);
            tableLayoutPanel1.Controls.Add(labelTitle, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.Size = new Size(542, 553);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonCancel
            // 
            buttonCancel.AutoSize = true;
            buttonCancel.Dock = DockStyle.Fill;
            buttonCancel.Location = new Point(40, 478);
            buttonCancel.Margin = new Padding(40, 10, 40, 10);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(191, 65);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Annuler";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            buttonSave.AutoSize = true;
            buttonSave.Dock = DockStyle.Fill;
            buttonSave.Location = new Point(311, 478);
            buttonSave.Margin = new Padding(40, 10, 40, 10);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(191, 65);
            buttonSave.TabIndex = 1;
            buttonSave.Text = "Enregistrer et Valider";
            buttonSave.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ColumnImage });
            tableLayoutPanel1.SetColumnSpan(dataGridView1, 2);
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 113);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(536, 242);
            dataGridView1.TabIndex = 3;
            // 
            // ColumnImage
            // 
            ColumnImage.HeaderText = "";
            ColumnImage.MinimumWidth = 6;
            ColumnImage.Name = "ColumnImage";
            ColumnImage.Width = 125;
            // 
            // textBox1
            // 
            tableLayoutPanel1.SetColumnSpan(textBox1, 2);
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(30, 416);
            textBox1.Margin = new Padding(30, 3, 30, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(482, 27);
            textBox1.TabIndex = 4;
            // 
            // labelTag
            // 
            labelTag.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelTag.AutoSize = true;
            labelTag.Location = new Point(3, 393);
            labelTag.Name = "labelTag";
            labelTag.Size = new Size(50, 20);
            labelTag.TabIndex = 5;
            labelTag.Text = "label1";
            // 
            // labelImage
            // 
            labelImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelImage.AutoSize = true;
            labelImage.Location = new Point(3, 90);
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
            labelTitle.Size = new Size(536, 55);
            labelTitle.TabIndex = 6;
            labelTitle.Text = "label2";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
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
            ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button buttonCancel;
        private Button buttonSave;
        private DataGridView dataGridView1;
        private TextBox textBox1;
        private Label labelTag;
        private Label labelImage;
        private Label labelTitle;
        private DataGridViewImageColumn ColumnImage;
    }
}