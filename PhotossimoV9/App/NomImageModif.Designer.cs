namespace PhotossimoV9.App
{
    partial class NomImageModif
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
            textBoxAncienNom = new TextBox();
            label3 = new Label();
            textBoxNewNom = new TextBox();
            buttonAnnuler = new Button();
            buttonValider = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(205, 39);
            label1.Name = "label1";
            label1.Size = new Size(345, 54);
            label1.TabIndex = 0;
            label1.Text = "Modification Nom";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(70, 146);
            label2.Name = "label2";
            label2.Size = new Size(98, 20);
            label2.TabIndex = 1;
            label2.Text = "Ancien Nom :";
            // 
            // textBoxAncienNom
            // 
            textBoxAncienNom.Location = new Point(70, 181);
            textBoxAncienNom.Name = "textBoxAncienNom";
            textBoxAncienNom.Size = new Size(253, 27);
            textBoxAncienNom.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(70, 239);
            label3.Name = "label3";
            label3.Size = new Size(112, 20);
            label3.TabIndex = 3;
            label3.Text = "Nouveau Nom :";
            // 
            // textBoxNewNom
            // 
            textBoxNewNom.Location = new Point(70, 286);
            textBoxNewNom.Name = "textBoxNewNom";
            textBoxNewNom.Size = new Size(253, 27);
            textBoxNewNom.TabIndex = 4;
            // 
            // buttonAnnuler
            // 
            buttonAnnuler.Location = new Point(70, 376);
            buttonAnnuler.Name = "buttonAnnuler";
            buttonAnnuler.Size = new Size(253, 29);
            buttonAnnuler.TabIndex = 5;
            buttonAnnuler.Text = "Annuler";
            buttonAnnuler.UseVisualStyleBackColor = true;
            buttonAnnuler.Click += buttonCancel_click;
            // 
            // buttonValider
            // 
            buttonValider.Location = new Point(492, 376);
            buttonValider.Name = "buttonValider";
            buttonValider.Size = new Size(215, 29);
            buttonValider.TabIndex = 6;
            buttonValider.Text = "Valider";
            buttonValider.UseVisualStyleBackColor = true;
            buttonValider.Click += buttonValider_Click;
            // 
            // NomImageModif
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonValider);
            Controls.Add(buttonAnnuler);
            Controls.Add(textBoxNewNom);
            Controls.Add(label3);
            Controls.Add(textBoxAncienNom);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "NomImageModif";
            Text = "NomImageModif";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBoxAncienNom;
        private Label label3;
        private TextBox textBoxNewNom;
        private Button buttonAnnuler;
        private Button buttonValider;
    }
}