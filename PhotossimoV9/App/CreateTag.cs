using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using PhotossimoV9.DB;
using PhotossimoV9.DB.DAO;
using PhotossimoV9.Object;

namespace Photossimo
{
    public partial class CreateTag : Form
    {
        public CreateTag()
        {
            InitializeComponent();
        }

        //Fonction pour valider la création d'un tag
        private void buttonValider(object sender, EventArgs e)
        {
            string nomTag = textBoxNomTag.Text.Trim();// on récupére le nom du tag
            string nomParentTag = textBoxParent.Text.Trim(); // on récupére le nom du parent tag

            if (string.IsNullOrEmpty(nomTag)) //on verifie si le nom du tag est vide
            {
                MessageBox.Show("Veuillez entrer un nom de tag.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TagImg? parentTag = null;
            if (!string.IsNullOrEmpty(nomParentTag)) // on verifie si le nome du parent du tag qu'on veut creer est vide
            {
                parentTag = TagImg.GetTagDictionary().Values
                    .FirstOrDefault(tag => tag.NomTag.Equals(nomParentTag, StringComparison.OrdinalIgnoreCase));

            }

            if (parentTag == null) 
            {
                TagImg.GetTagDictionary().TryGetValue(0, out parentTag);
            }

            try
            {
                TagImg nouveauTag = TagImg.GetOrCreate(0, nomTag, parentTag); // On crre un nouveau tag 

                //on l'ajoute à la base de données
                DAO_Tag daoTag = new DAO_Tag();
                daoTag.Insert(nomTag, parentTag?.IdTag);

                MessageBox.Show($"Tag '{nomTag}' créé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la création du tag : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
        }
    }
}
