namespace PhotossimoV9.App
{
    partial class GestionTag
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
            rechercheBox = new TextBox();
            button1 = new Button();
            labelResultat = new Label();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label1 = new Label();
            comboBoxTag = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // rechercheBox
            // 
            rechercheBox.Location = new Point(12, 61);
            rechercheBox.Name = "rechercheBox";
            rechercheBox.Size = new Size(306, 27);
            rechercheBox.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(447, 59);
            button1.Name = "button1";
            button1.Size = new Size(237, 29);
            button1.TabIndex = 1;
            button1.Text = "Recherche";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonRecherche_Click;
            // 
            // labelResultat
            // 
            labelResultat.AutoSize = true;
            labelResultat.Location = new Point(541, 100);
            labelResultat.Name = "labelResultat";
            labelResultat.Size = new Size(95, 20);
            labelResultat.TabIndex = 2;
            labelResultat.Text = "labelResultat";
            // 
            // button2
            // 
            button2.Location = new Point(12, 275);
            button2.Name = "button2";
            button2.Size = new Size(216, 29);
            button2.TabIndex = 3;
            button2.Text = "Supprimer Tag";
            button2.UseVisualStyleBackColor = true;
            button2.Click += ButtonSuppresion;
            // 
            // button3
            // 
            button3.Location = new Point(277, 275);
            button3.Name = "button3";
            button3.Size = new Size(211, 29);
            button3.TabIndex = 4;
            button3.Text = "Creation Tag";
            button3.UseVisualStyleBackColor = true;
            button3.Click += CreationTag;
            // 
            // button4
            // 
            button4.Location = new Point(541, 275);
            button4.Name = "button4";
            button4.Size = new Size(172, 29);
            button4.TabIndex = 5;
            button4.Text = "Modification Tag";
            button4.UseVisualStyleBackColor = true;
            button4.Click += ModificationTag;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(338, 9);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 6;
            // 
            // comboBoxTag
            // 
            comboBoxTag.FormattingEnabled = true;
            comboBoxTag.Location = new Point(12, 161);
            comboBoxTag.Name = "comboBoxTag";
            comboBoxTag.Size = new Size(306, 28);
            comboBoxTag.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(447, 100);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 8;
            label2.Text = "Resultat :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 127);
            label3.Name = "label3";
            label3.Size = new Size(159, 20);
            label3.TabIndex = 9;
            label3.Text = "Chercher dans la Liste :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 23);
            label4.Name = "label4";
            label4.Size = new Size(154, 20);
            label4.TabIndex = 10;
            label4.Text = "Entrez le nom du tag :";
            // 
            // GestionTag
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(comboBoxTag);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(labelResultat);
            Controls.Add(button1);
            Controls.Add(rechercheBox);
            Name = "GestionTag";
            Text = "Gestion_Tag";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox rechercheBox;
        private Button button1;
        private Label labelResultat;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label1;
        private ComboBox comboBoxTag;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}