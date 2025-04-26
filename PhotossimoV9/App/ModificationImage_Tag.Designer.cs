namespace PhotossimoV9.App
{
    partial class ModificationImage_Tag
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
            label1 = new Label();
            label2 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            listViewImages = new ListView();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            listBoxTag = new ListBox();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(190, 9);
            label1.Name = "label1";
            label1.Size = new Size(409, 54);
            label1.TabIndex = 0;
            label1.Text = "Modification des Tags";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(28, 63);
            label2.Name = "label2";
            label2.Size = new Size(209, 28);
            label2.TabIndex = 2;
            label2.Text = "Image(s) concernée(s) :";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(listViewImages);
            flowLayoutPanel1.Location = new Point(28, 108);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(725, 155);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // listViewImages
            // 
            listViewImages.Location = new Point(3, 3);
            listViewImages.Name = "listViewImages";
            listViewImages.Size = new Size(722, 152);
            listViewImages.TabIndex = 0;
            listViewImages.UseCompatibleStateImageBehavior = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(28, 277);
            label3.Name = "label3";
            label3.Size = new Size(266, 28);
            label3.TabIndex = 4;
            label3.Text = "Tags communs à la séléction :";
            // 
            // button1
            // 
            button1.Location = new Point(22, 409);
            button1.Name = "button1";
            button1.Size = new Size(215, 29);
            button1.TabIndex = 6;
            button1.Text = "Annuler";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(556, 409);
            button2.Name = "button2";
            button2.Size = new Size(197, 29);
            button2.TabIndex = 7;
            button2.Text = "Enregister et Valider";
            button2.UseVisualStyleBackColor = true;
            // 
            // listBoxTag
            // 
            listBoxTag.FormattingEnabled = true;
            listBoxTag.Location = new Point(300, 277);
            listBoxTag.Name = "listBoxTag";
            listBoxTag.Size = new Size(150, 144);
            listBoxTag.TabIndex = 8;
            // 
            // ModificationImage_Tag
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listBoxTag);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ModificationImage_Tag";
            Text = "ModificationImage_Tag";
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanel1;
        private ListView listViewImages;
        private Label label3;
        private Button button1;
        private Button button2;
        private ListBox listBoxTag;
    }
}