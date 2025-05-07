namespace Photossimo
{
    partial class MainView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            buttonDelete = new Button();
            label3 = new Label();
            labelTags = new Label();
            buttonImport = new Button();
            buttonCreateTag = new Button();
            buttonEdit = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            textBox1 = new TextBox();
            listViewImage = new ListView();
            tableLayoutPanel4 = new TableLayoutPanel();
            tagTreeView = new TreeView();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67.35016F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.2460575F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.2460575F));
            tableLayoutPanel2.Controls.Add(buttonDelete, 2, 0);
            tableLayoutPanel2.Controls.Add(label3, 0, 0);
            tableLayoutPanel2.Controls.Add(labelTags, 0, 2);
            tableLayoutPanel2.Controls.Add(buttonImport, 1, 0);
            tableLayoutPanel2.Controls.Add(buttonCreateTag, 2, 1);
            tableLayoutPanel2.Controls.Add(buttonEdit, 1, 1);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 1);
            tableLayoutPanel2.Controls.Add(listViewImage, 0, 3);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(163, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(634, 444);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // buttonDelete
            // 
            buttonDelete.Dock = DockStyle.Fill;
            buttonDelete.Location = new Point(540, 10);
            buttonDelete.Margin = new Padding(10);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(84, 46);
            buttonDelete.TabIndex = 5;
            buttonDelete.Text = "Supprimer Séléction";
            buttonDelete.UseCompatibleTextRendering = true;
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 24F);
            label3.Location = new Point(99, 0);
            label3.Name = "label3";
            label3.Size = new Size(229, 66);
            label3.TabIndex = 4;
            label3.Text = "Photossimo";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelTags
            // 
            labelTags.AutoSize = true;
            labelTags.Location = new Point(3, 158);
            labelTags.Name = "labelTags";
            labelTags.Size = new Size(0, 20);
            labelTags.TabIndex = 1;
            // 
            // buttonImport
            // 
            buttonImport.Dock = DockStyle.Fill;
            buttonImport.Location = new Point(437, 10);
            buttonImport.Margin = new Padding(10);
            buttonImport.Name = "buttonImport";
            buttonImport.Size = new Size(83, 46);
            buttonImport.TabIndex = 0;
            buttonImport.Text = "Importer Image";
            buttonImport.UseCompatibleTextRendering = true;
            buttonImport.UseVisualStyleBackColor = true;
            buttonImport.Click += buttonImport_Click;
            // 
            // buttonCreateTag
            // 
            buttonCreateTag.AutoSize = true;
            buttonCreateTag.Dock = DockStyle.Fill;
            buttonCreateTag.Location = new Point(540, 76);
            buttonCreateTag.Margin = new Padding(10);
            buttonCreateTag.Name = "buttonCreateTag";
            buttonCreateTag.Size = new Size(84, 72);
            buttonCreateTag.TabIndex = 7;
            buttonCreateTag.Text = "Gestion Tag";
            buttonCreateTag.UseVisualStyleBackColor = true;
            buttonCreateTag.Click += ButtonGestionTag;
            // 
            // buttonEdit
            // 
            buttonEdit.AutoSize = true;
            buttonEdit.Dock = DockStyle.Fill;
            buttonEdit.Location = new Point(437, 76);
            buttonEdit.Margin = new Padding(10);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(83, 72);
            buttonEdit.TabIndex = 6;
            buttonEdit.Text = "Modifier Séléction";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += ButtonModifSelection;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(textBox1, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 69);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 54.54546F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 45.45454F));
            tableLayoutPanel3.Size = new Size(421, 86);
            tableLayoutPanel3.TabIndex = 8;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(10, 4);
            textBox1.Margin = new Padding(10, 4, 10, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(401, 27);
            textBox1.TabIndex = 0;
            // 
            // listViewImage
            // 
            tableLayoutPanel2.SetColumnSpan(listViewImage, 3);
            listViewImage.Dock = DockStyle.Fill;
            listViewImage.Location = new Point(3, 181);
            listViewImage.Name = "listViewImage";
            listViewImage.Size = new Size(628, 260);
            listViewImage.TabIndex = 9;
            listViewImage.UseCompatibleStateImageBehavior = false;
            listViewImage.MouseDoubleClick += ListViewImage_MouseDoubleClick;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(tagTreeView, 0, 1);
            tableLayoutPanel4.Controls.Add(label1, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel4.Size = new Size(154, 444);
            tableLayoutPanel4.TabIndex = 2;
            // 
            // tagTreeView
            // 
            tagTreeView.CheckBoxes = true;
            tagTreeView.Dock = DockStyle.Fill;
            tagTreeView.Location = new Point(3, 91);
            tagTreeView.Name = "tagTreeView";
            tagTreeView.Size = new Size(148, 350);
            tagTreeView.TabIndex = 1;
            tagTreeView.AfterCheck += tagTreeView_AfterCheck;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(144, 38);
            label1.TabIndex = 0;
            label1.Text = "Hiérarchie";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "MainView";
            Text = "Photossimo";
            Load += MainViewLoad;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label3;
        private Label labelTags;
        private Button buttonImport;
        private Button buttonDelete;
        private Button buttonCreateTag;
        private Button buttonEdit;
        private TableLayoutPanel tableLayoutPanel3;
        private TextBox textBox1;
        private TableLayoutPanel tableLayoutPanel4;
        private TreeView tagTreeView;
        private Label label1;
        private ListView listViewImage;
    }
}