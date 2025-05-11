using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

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
            tableLayoutPanel4 = new TableLayoutPanel();
            tagTreeView = new TreeView();
            label1 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            label3 = new Label();
            buttonImport = new Button();
            buttonDelete = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            textBox1 = new TextBox();
            listBoxSuggestions = new ListBox();
            buttonCreateTag = new Button();
            labelTags = new Label();
            listViewImage = new ListView();
            buttonEdit = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.WhiteSmoke;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10);
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(tagTreeView, 0, 1);
            tableLayoutPanel4.Controls.Add(label1, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(13, 13);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel4.Size = new Size(150, 424);
            tableLayoutPanel4.TabIndex = 2;
            // 
            // tagTreeView
            // 
            tagTreeView.BackColor = Color.White;
            tagTreeView.CheckBoxes = true;
            tagTreeView.Dock = DockStyle.Fill;
            tagTreeView.Font = new Font("Segoe UI", 9F);
            tagTreeView.ForeColor = Color.DimGray;
            tagTreeView.Location = new Point(5, 89);
            tagTreeView.Margin = new Padding(5);
            tagTreeView.Name = "tagTreeView";
            tagTreeView.Size = new Size(140, 330);
            tagTreeView.TabIndex = 1;
            tagTreeView.AfterCheck += tagTreeView_AfterCheck;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Bottom;
            label1.Font = new Font("Segoe UI Semibold", 14F);
            label1.ForeColor = Color.DarkSlateGray;
            label1.Location = new Point(3, 42);
            label1.Margin = new Padding(3, 40, 3, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(5);
            label1.Size = new Size(144, 42);
            label1.TabIndex = 0;
            label1.Text = "Hiérarchie des tags";
            label1.TextAlign = ContentAlignment.BottomLeft;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67.35016F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.2460575F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.2460575F));
            tableLayoutPanel2.Controls.Add(label3, 0, 0);
            tableLayoutPanel2.Controls.Add(buttonImport, 1, 0);
            tableLayoutPanel2.Controls.Add(buttonDelete, 2, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 1);
            tableLayoutPanel2.Controls.Add(buttonCreateTag, 2, 1);
            tableLayoutPanel2.Controls.Add(labelTags, 0, 2);
            tableLayoutPanel2.Controls.Add(listViewImage, 0, 3);
            tableLayoutPanel2.Controls.Add(buttonEdit, 1, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(169, 13);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(618, 424);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(107, 0);
            label3.Name = "label3";
            label3.Size = new Size(201, 56);
            label3.TabIndex = 4;
            label3.Text = "Photossimo";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonImport
            // 
            buttonImport.BackColor = SystemColors.GradientInactiveCaption;
            buttonImport.Dock = DockStyle.Fill;
            buttonImport.FlatAppearance.BorderColor = Color.Black;
            buttonImport.FlatStyle = FlatStyle.Flat;
            buttonImport.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonImport.ForeColor = Color.DimGray;
            buttonImport.Location = new Point(421, 5);
            buttonImport.Margin = new Padding(5);
            buttonImport.Name = "buttonImport";
            buttonImport.Size = new Size(90, 46);
            buttonImport.TabIndex = 0;
            buttonImport.Text = "Importer une image";
            buttonImport.UseCompatibleTextRendering = true;
            buttonImport.UseVisualStyleBackColor = false;
            buttonImport.Click += buttonImport_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = SystemColors.GradientInactiveCaption;
            buttonDelete.Dock = DockStyle.Fill;
            buttonDelete.FlatAppearance.BorderColor = Color.Black;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonDelete.ForeColor = Color.DimGray;
            buttonDelete.Location = new Point(521, 5);
            buttonDelete.Margin = new Padding(5);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(92, 46);
            buttonDelete.TabIndex = 5;
            buttonDelete.Text = "Supprimer la séléction";
            buttonDelete.UseCompatibleTextRendering = true;
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(textBox1, 0, 0);
            tableLayoutPanel3.Controls.Add(listBoxSuggestions, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 59);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 54.54546F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 45.45454F));
            tableLayoutPanel3.Size = new Size(410, 170);
            tableLayoutPanel3.TabIndex = 8;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Dock = DockStyle.Top;
            textBox1.Font = new Font("Segoe UI", 9F);
            textBox1.ForeColor = Color.DimGray;
            textBox1.Location = new Point(5, 5);
            textBox1.Margin = new Padding(5);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Chercher un tag";
            textBox1.Size = new Size(400, 27);
            textBox1.TabIndex = 0;
            // 
            // listBoxSuggestions
            // 
            listBoxSuggestions.BackColor = Color.White;
            listBoxSuggestions.Dock = DockStyle.Fill;
            listBoxSuggestions.Font = new Font("Segoe UI", 9F);
            listBoxSuggestions.ForeColor = Color.DimGray;
            listBoxSuggestions.Location = new Point(5, 42);
            listBoxSuggestions.Margin = new Padding(5);
            listBoxSuggestions.MaximumSize = new Size(0, 200);
            listBoxSuggestions.Name = "listBoxSuggestions";
            listBoxSuggestions.Size = new Size(400, 123);
            listBoxSuggestions.TabIndex = 1;
            listBoxSuggestions.Visible = false;
            listBoxSuggestions.Click += ListBoxSuggestions_Click;
            // 
            // buttonCreateTag
            // 
            buttonCreateTag.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonCreateTag.AutoSize = true;
            buttonCreateTag.BackColor = SystemColors.GradientInactiveCaption;
            buttonCreateTag.FlatAppearance.BorderColor = Color.Black;
            buttonCreateTag.FlatStyle = FlatStyle.Flat;
            buttonCreateTag.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonCreateTag.ForeColor = Color.DimGray;
            buttonCreateTag.Location = new Point(521, 111);
            buttonCreateTag.Margin = new Padding(5, 55, 5, 5);
            buttonCreateTag.Name = "buttonCreateTag";
            buttonCreateTag.Size = new Size(92, 116);
            buttonCreateTag.TabIndex = 7;
            buttonCreateTag.Text = "Gestion des tags";
            buttonCreateTag.UseVisualStyleBackColor = false;
            buttonCreateTag.Click += ButtonGestionTag;
            // 
            // labelTags
            // 
            labelTags.AutoSize = true;
            labelTags.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            labelTags.ForeColor = Color.DarkSlateGray;
            labelTags.Location = new Point(3, 232);
            labelTags.Name = "labelTags";
            labelTags.Padding = new Padding(5);
            labelTags.Size = new Size(10, 30);
            labelTags.TabIndex = 1;
            // 
            // listViewImage
            // 
            listViewImage.BackColor = Color.White;
            tableLayoutPanel2.SetColumnSpan(listViewImage, 3);
            listViewImage.Dock = DockStyle.Fill;
            listViewImage.Location = new Point(10, 272);
            listViewImage.Margin = new Padding(10);
            listViewImage.Name = "listViewImage";
            listViewImage.Size = new Size(598, 142);
            listViewImage.TabIndex = 9;
            listViewImage.UseCompatibleStateImageBehavior = false;
            listViewImage.MouseDoubleClick += ListViewImage_MouseDoubleClick;
            // 
            // buttonEdit
            // 
            buttonEdit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonEdit.BackColor = SystemColors.GradientInactiveCaption;
            buttonEdit.FlatAppearance.BorderColor = Color.Black;
            buttonEdit.FlatStyle = FlatStyle.Flat;
            buttonEdit.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonEdit.ForeColor = Color.DimGray;
            buttonEdit.Location = new Point(421, 111);
            buttonEdit.Margin = new Padding(5, 55, 5, 5);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(90, 116);
            buttonEdit.TabIndex = 6;
            buttonEdit.Text = "Modifier la séléction";
            buttonEdit.UseVisualStyleBackColor = false;
            buttonEdit.Click += ButtonModifSelection;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "MainView";
            Text = "Photossimo";
            WindowState = FormWindowState.Maximized;
            Load += MainViewLoad;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
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
        private ListBox listBoxSuggestions;
    }
}