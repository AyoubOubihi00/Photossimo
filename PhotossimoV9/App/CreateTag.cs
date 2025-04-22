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

            if(TagImg.GetTagDictionary().TryGetValue(0,out var rootTag))
            {
                comboBoxParent.Items.Add(rootTag.NomTag);
            }

            var tagTries = TagImg.GetTagDictionary().Values.Where(tag => tag.IdTag !=0).OrderBy(tag => tag.NomTag).ToList();

            foreach (var tag in tagTries)
            {
                
                comboBoxParent.Items.Add(tag.NomTag);
                

            }
        }

        //Fonction pour valider la création d'un tag
        private void buttonValider(object sender, EventArgs e)
        {
            string nomTag = textBoxNomTag.Text.Trim();// on récupére le nom du tag
            string nomParentTag = comboBoxParent.SelectedItem?.ToString(); // on récupére le nom du parent tag

            if (string.IsNullOrEmpty(nomTag)) //on verifie si le nom du tag est vide
            {
                MessageBox.Show("Veuillez entrer un nom de tag.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TagImg? parentTag = null;
            if (!string.IsNullOrEmpty(nomParentTag)) // on verifie si le nome du parent du tag qu'on veut creer n'es pas vide
            {

                parentTag = TagImg.GetTagDictionary().Values
                    .FirstOrDefault(tag => tag.NomTag.Equals(nomParentTag, StringComparison.OrdinalIgnoreCase));

            }

            // Si le parentTag n'existe pas, on vas l'associer au tag racine (id 0)
            if (parentTag == null)
            {
                TagImg.GetTagDictionary().TryGetValue(0, out parentTag);
            }

            try
            {
                TagImg nouveauTag = TagImg.GetOrCreate(0, nomTag, parentTag); // On cree un nouveau tag 

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

        // Fonction pour annuler la création d'un tag
        private void buttonAnnuler(object sender, EventArgs e)
        {

            var confirmation = MessageBox.Show("Vous êtes sur le point d'annuler la création du tag. Voulez-vous vraiment continuer ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


            if (confirmation == DialogResult.Yes)
            {
                // On ferme la fenêtre de création de tag si on a clique sur le bouton annuler
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
