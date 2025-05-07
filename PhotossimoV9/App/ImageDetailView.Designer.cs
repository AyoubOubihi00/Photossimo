// ImageDetailView.Designer.cs
namespace PhotossimoV9.App
{
    partial class ImageDetailView
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel mainLayout;
        private TableLayoutPanel leftPanel;
        private Panel panelImage;
        private PictureBox pictureBoxFull;
        private FlowLayoutPanel bottomLeftFlow;
        private Label labelName;
        private Button btnRename;
        private Button btnDelete;
        private Panel rightPanel;
        private Button btnEditTags;
        private ListBox listBoxTags;

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

            mainLayout = new TableLayoutPanel();
            leftPanel = new TableLayoutPanel();
            panelImage = new Panel();
            pictureBoxFull = new PictureBox();
            bottomLeftFlow = new FlowLayoutPanel();
            labelName = new Label();
            btnRename = new Button();
            btnDelete = new Button();
            rightPanel = new Panel();
            btnEditTags = new Button();
            listBoxTags = new ListBox();

            mainLayout.SuspendLayout();
            leftPanel.SuspendLayout();
            panelImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxFull).BeginInit();
            bottomLeftFlow.SuspendLayout();
            rightPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 2;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            mainLayout.Controls.Add(leftPanel, 0, 0);
            mainLayout.Controls.Add(rightPanel, 1, 0);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 1;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.Size = new Size(800, 600);
            mainLayout.TabIndex = 0;
            // 
            // leftPanel
            // 
            leftPanel.ColumnCount = 1;
            leftPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            leftPanel.Controls.Add(panelImage, 0, 0);
            leftPanel.Controls.Add(bottomLeftFlow, 0, 1);
            leftPanel.Dock = DockStyle.Fill;
            leftPanel.Location = new Point(3, 3);
            leftPanel.Name = "leftPanel";
            leftPanel.RowCount = 2;
            leftPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            leftPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            leftPanel.Size = new Size(554, 594);
            leftPanel.TabIndex = 0;
            // 
            // panelImage
            // 
            panelImage.AutoScroll = true;
            panelImage.Controls.Add(pictureBoxFull);
            panelImage.Dock = DockStyle.Fill;
            panelImage.Location = new Point(3, 3);
            panelImage.Name = "panelImage";
            panelImage.Size = new Size(548, 546);
            panelImage.TabIndex = 0;
            // 
            // pictureBoxFull
            // 
            pictureBoxFull.Location = new Point(0, 0);
            pictureBoxFull.Name = "pictureBoxFull";
            pictureBoxFull.Size = new Size(100, 50);
            pictureBoxFull.TabIndex = 0;
            pictureBoxFull.TabStop = false;
            // 
            // bottomLeftFlow
            // 
            bottomLeftFlow.AutoSize = true;
            bottomLeftFlow.Controls.Add(labelName);
            bottomLeftFlow.Controls.Add(btnRename);
            bottomLeftFlow.Controls.Add(btnDelete);
            bottomLeftFlow.Dock = DockStyle.Bottom;
            bottomLeftFlow.Location = new Point(3, 555);
            bottomLeftFlow.Name = "bottomLeftFlow";
            bottomLeftFlow.Padding = new Padding(0, 5, 0, 5);
            bottomLeftFlow.Size = new Size(548, 36);
            bottomLeftFlow.TabIndex = 1;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(3, 5);
            labelName.Name = "labelName";
            labelName.Size = new Size(0, 20);
            labelName.TabIndex = 0;
            labelName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnRename
            // 
            btnRename.AutoSize = true;
            btnRename.Location = new Point(12, 5);
            btnRename.Name = "btnRename";
            btnRename.Size = new Size(140, 30);
            btnRename.TabIndex = 1;
            btnRename.Text = "Renommer l'image";
            btnRename.Click += btnRename_Click;
            // 
            // btnDelete
            // 
            btnDelete.AutoSize = true;
            btnDelete.Location = new Point(158, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(140, 30);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Supprimer l'image";
            btnDelete.Click += btnDelete_Click;
            // 
            // rightPanel
            // 
            rightPanel.Controls.Add(listBoxTags);
            rightPanel.Controls.Add(btnEditTags);
            rightPanel.Dock = DockStyle.Fill;
            rightPanel.Location = new Point(563, 3);
            rightPanel.Name = "rightPanel";
            rightPanel.Padding = new Padding(5);
            rightPanel.Size = new Size(234, 594);
            rightPanel.TabIndex = 1;
            // 
            // btnEditTags
            // 
            btnEditTags.AutoSize = true;
            btnEditTags.Dock = DockStyle.Top;
            btnEditTags.Location = new Point(5, 5);
            btnEditTags.Margin = new Padding(5, 5, 5, 10);
            btnEditTags.Name = "btnEditTags";
            btnEditTags.Size = new Size(224, 30);
            btnEditTags.TabIndex = 0;
            btnEditTags.Text = "Modifier Tags";
            btnEditTags.Click += btnEditTags_Click;
            // 
            // listBoxTags
            // 
            listBoxTags.Dock = DockStyle.Fill;
            listBoxTags.Location = new Point(5, 50);
            listBoxTags.Margin = new Padding(5, 10, 5, 5);
            listBoxTags.Name = "listBoxTags";
            listBoxTags.Size = new Size(224, 539);
            listBoxTags.TabIndex = 1;
            // 
            // ImageDetailView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            // ouvrir en plein écran
            this.WindowState = FormWindowState.Maximized;
            Controls.Add(mainLayout);
            Name = "ImageDetailView";
            Text = "Détail de l'image";
            mainLayout.ResumeLayout(false);
            leftPanel.ResumeLayout(false);
            leftPanel.PerformLayout();
            panelImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxFull).EndInit();
            bottomLeftFlow.ResumeLayout(false);
            bottomLeftFlow.PerformLayout();
            rightPanel.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
