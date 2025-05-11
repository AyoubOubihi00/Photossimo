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
        private Button btnValidateTags;
        private TreeView treeViewTags;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // mainLayout
            mainLayout = new TableLayoutPanel
            {
                ColumnCount = 2,
                Dock = DockStyle.Fill
            };
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));

            // leftPanel
            leftPanel = new TableLayoutPanel
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill
            };
            leftPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            leftPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // panelImage & pictureBoxFull
            panelImage = new Panel { AutoScroll = true, Dock = DockStyle.Fill };
            pictureBoxFull = new PictureBox
            {
                Dock = DockStyle.Fill,   // remplit tout le panel
                SizeMode = PictureBoxSizeMode.Zoom, // s’adapte pour montrer l'image entière
            };

            panelImage.Controls.Add(pictureBoxFull);

            // bottomLeftFlow
            bottomLeftFlow = new FlowLayoutPanel { AutoSize = true, Dock = DockStyle.Bottom, Padding = new Padding(0, 5, 0, 5) };
            labelName = new Label { AutoSize = true, TextAlign = ContentAlignment.MiddleCenter };
            btnRename = new Button { AutoSize = true, Text = "Renommer l'image" };
            btnDelete = new Button { AutoSize = true, Text = "Supprimer l'image" };
            bottomLeftFlow.Controls.AddRange(new Control[] { labelName, btnRename, btnDelete });

            leftPanel.Controls.Add(panelImage, 0, 0);
            leftPanel.Controls.Add(bottomLeftFlow, 0, 1);

            // rightPanel
            rightPanel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(5) };
            btnValidateTags = new Button { AutoSize = true, Dock = DockStyle.Top, Text = "Valider Tags", Margin = new Padding(0, 5, 0, 15), BackColor = Color.FromArgb(192, 255, 192) };
            treeViewTags = new TreeView { Dock = DockStyle.Fill, CheckBoxes = true };

            rightPanel.Controls.Add(treeViewTags);
            rightPanel.Controls.Add(btnValidateTags);

            // assemble
            mainLayout.Controls.Add(leftPanel, 0, 0);
            mainLayout.Controls.Add(rightPanel, 1, 0);

            // form
            Controls.Add(mainLayout);
            this.WindowState = FormWindowState.Maximized;
            Text = "Détail de l'image";

            // events
            btnRename.Click += btnRename_Click;
            btnDelete.Click += btnDelete_Click;
            btnValidateTags.Click += btnValidateTags_Click;
            treeViewTags.AfterCheck += treeViewTags_AfterCheck;
        }
    }
}
