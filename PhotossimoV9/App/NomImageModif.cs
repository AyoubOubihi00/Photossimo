using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotossimoV9.App
{
    public partial class NomImageModif : Form
    {
        public string NouveauNom { get; set; }
        public NomImageModif(string anciennom)
        {
            InitializeComponent();
            textBoxAncienNom.ReadOnly = true;
            textBoxAncienNom.Text = anciennom;
        }

        private void buttonValider_Click(object sender, EventArgs e)
        {
            string nouveaunomsansExtension = textBoxNewNom.Text.Trim();
            string anciennom = textBoxAncienNom.Text.Trim();
            if (string.IsNullOrEmpty(nouveaunomsansExtension))
            {
                MessageBox.Show("Veuillez entrer un nom valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string extension = System.IO.Path.GetExtension(anciennom);

            NouveauNom = nouveaunomsansExtension + extension;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_click(object sender, EventArgs e)
        {
            var confirmation = MessageBox.Show("Voulez-vous vraiment annuler ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmation == DialogResult.Yes)
                Close();
        }
    }
  
}
