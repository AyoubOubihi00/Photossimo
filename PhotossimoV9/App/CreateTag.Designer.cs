namespace Photossimo
{
    partial class CreateTag
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
            tableLayoutPanel1 = new TableLayoutPanel();
            textBoxNomTag = new TextBox();
            label3 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            textBoxParent = new TextBox();
            button1 = new Button();
            button2 = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F);
            label1.Location = new Point(254, 32);
            label1.Name = "label1";
            label1.Size = new Size(335, 54);
            label1.TabIndex = 3;
            label1.Text = "Création d'un Tag";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(83, 100);
            label2.Name = "label2";
            label2.Size = new Size(119, 28);
            label2.TabIndex = 4;
            label2.Text = "Nom du Tag";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(textBoxNomTag, 0, 0);
            tableLayoutPanel1.Location = new Point(92, 140);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(602, 30);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // textBoxNomTag
            // 
            textBoxNomTag.Location = new Point(3, 3);
            textBoxNomTag.Name = "textBoxNomTag";
            textBoxNomTag.Size = new Size(596, 27);
            textBoxNomTag.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(83, 214);
            label3.Name = "label3";
            label3.Size = new Size(291, 28);
            label3.TabIndex = 7;
            label3.Text = "Choisir le Tag parent (optionnel)";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(textBoxParent, 0, 0);
            tableLayoutPanel2.Location = new Point(95, 258);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(596, 31);
            tableLayoutPanel2.TabIndex = 8;
            // 
            // textBoxParent
            // 
            textBoxParent.Location = new Point(3, 3);
            textBoxParent.Name = "textBoxParent";
            textBoxParent.Size = new Size(590, 27);
            textBoxParent.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(92, 345);
            button1.Name = "button1";
            button1.Size = new Size(177, 66);
            button1.TabIndex = 9;
            button1.Text = "Annuler";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonAnnuler;
            // 
            // button2
            // 
            button2.Location = new Point(514, 345);
            button2.Name = "button2";
            button2.Size = new Size(177, 66);
            button2.TabIndex = 10;
            button2.Text = "Valider";
            button2.UseVisualStyleBackColor = true;
            button2.Click += buttonValider;
            // 
            // CreateTag
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(label3);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CreateTag";
            Text = "CreateTag";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox textBoxNomTag;
        private Label label3;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox textBoxParent;
        private Button button1;
        private Button button2;
    }
}