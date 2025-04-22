namespace PhotossimoV9.App
{
    partial class ModificationTag
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
            textBoxNomTag = new TextBox();
            label2 = new Label();
            textBoxParent = new TextBox();
            button1 = new Button();
            button2 = new Button();
            label3 = new Label();
            textBoxNomTagNew = new TextBox();
            label4 = new Label();
            comboBoxParent = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 41);
            label1.Name = "label1";
            label1.Size = new Size(178, 20);
            label1.TabIndex = 0;
            label1.Text = "Nom du Tag à modifier   :";
            // 
            // textBoxNomTag
            // 
            textBoxNomTag.Location = new Point(25, 77);
            textBoxNomTag.Name = "textBoxNomTag";
            textBoxNomTag.Size = new Size(165, 27);
            textBoxNomTag.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 152);
            label2.Name = "label2";
            label2.Size = new Size(231, 20);
            label2.TabIndex = 2;
            label2.Text = "Tag Parent à modfier (optionnel) :";
            // 
            // textBoxParent
            // 
            textBoxParent.Location = new Point(25, 207);
            textBoxParent.Name = "textBoxParent";
            textBoxParent.Size = new Size(225, 27);
            textBoxParent.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(25, 351);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 4;
            button1.Text = "Annuler";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(603, 351);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 5;
            button2.Text = "Valider";
            button2.UseVisualStyleBackColor = true;
            button2.Click += ValiderModification;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(420, 41);
            label3.Name = "label3";
            label3.Size = new Size(165, 20);
            label3.TabIndex = 6;
            label3.Text = "Nouveau nom du Tag   :";
            // 
            // textBoxNomTagNew
            // 
            textBoxNomTagNew.Location = new Point(420, 77);
            textBoxNomTagNew.Name = "textBoxNomTagNew";
            textBoxNomTagNew.Size = new Size(165, 27);
            textBoxNomTagNew.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(420, 152);
            label4.Name = "label4";
            label4.Size = new Size(225, 20);
            label4.TabIndex = 8;
            label4.Text = "Nouveau Tag Parent (optionnel) :";
            // 
            // comboBoxParent
            // 
            comboBoxParent.FormattingEnabled = true;
            comboBoxParent.Location = new Point(420, 207);
            comboBoxParent.Name = "comboBoxParent";
            comboBoxParent.Size = new Size(225, 28);
            comboBoxParent.TabIndex = 10;
            // 
            // ModificationTag
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboBoxParent);
            Controls.Add(label4);
            Controls.Add(textBoxNomTagNew);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBoxParent);
            Controls.Add(label2);
            Controls.Add(textBoxNomTag);
            Controls.Add(label1);
            Name = "ModificationTag";
            Text = "ModificationTag";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxNomTag;
        private Label label2;
        private TextBox textBoxParent;
        private Button button1;
        private Button button2;
        private Label label3;
        private TextBox textBoxNomTagNew;
        private Label label4;
        private ComboBox comboBoxParent;
    }
}