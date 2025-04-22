using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhotossimoV9.DB;
using PhotossimoV9.DB.DAO;
using PhotossimoV9.Object;

namespace PhotossimoV9.App
{
    public partial class ModificationTag : Form
    {
        private TagImg tagmodifier;
        public ModificationTag(TagImg tag)
        {
            InitializeComponent();
            tagmodifier = tag; // ici on recupére le tag qu'on veut modifier

            textBoxNomTag.Text = tagmodifier.NomTag; // ici on affiche le nom du tag qu'on veut modifier
            textBoxNomTag.ReadOnly = true;
            textBoxParent.ReadOnly = true;

            if (tagmodifier.Parent != null) // ici on verifie si le tag qu'on veut modifier a un parent
            {
                if (TagImg.GetTagDictionary().TryGetValue(tagmodifier.Parent.IdTag, out TagImg? vraiParent)) 
                {
                    textBoxParent.Text = vraiParent.NomTag; // ici on affiche le nom du parent tag
                }

            }

            if (TagImg.GetTagDictionary().TryGetValue(0, out var rootTag))
            {
                comboBoxParent.Items.Add(rootTag.NomTag);
            }

            var tagTries = TagImg.GetTagDictionary().Values.Where(tag => tag.IdTag != 0).OrderBy(tag => tag.NomTag).ToList();

            foreach (var parent in tagTries)
            {

                comboBoxParent.Items.Add(parent.NomTag);


            }


        }

        // Fonction pour valider la modification d'un tag
        private void ValiderModification(object sender, EventArgs e)
        {
            string nouveauNomTag = textBoxNomTagNew.Text.Trim(); // ici on récupére le nom du tag
            string nouveauNomParentTag;// ici on récupére le nom du parent tag selectione dans la liste 
            if(comboBoxParent.SelectedItem != null)
            {
                nouveauNomParentTag = comboBoxParent.SelectedItem.ToString();
            }else
            {
                nouveauNomParentTag = "";
            }


            if (string.IsNullOrEmpty(nouveauNomTag)) // on verifie si le nom du tag est vide
            {
                MessageBox.Show("Veuillez entrer un nom de tag valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ici , on va se connecter à la base de données pour modifier le tag
            var dao = new DAO_Tag();
            var connexion = DataBase.GetInstance();
            var transaction = connexion.BeginTransaction();

            try
            {
                tagmodifier.NomTag = nouveauNomTag;

                if(!string.IsNullOrEmpty(nouveauNomParentTag)) // ici on verifie si le nom du parent tag n'est pas vide
                {
                    var parentTag = TagImg.GetTagDictionary().Values
                        .FirstOrDefault(tag => tag.NomTag.Equals(nouveauNomParentTag, StringComparison.OrdinalIgnoreCase)); // ici on va chercher le parent tag dans la base de données

                    if (parentTag == null) // si le parent tag n'existe pas
                    {
                        MessageBox.Show("Le parent tag n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        transaction.Rollback();
                        return;
                    }
                    else
                    {
                        tagmodifier.Parent = parentTag; // ici on associe le parent tag au tag qu'on veut modifier
                    }
                }
                // ici on va modifier le tag dans la base de données
                dao.Update(tagmodifier, transaction);

                transaction.Commit();

                MessageBox.Show($"Tag '{tagmodifier.NomTag}' modifié avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch( Exception ex)
            {
                MessageBox.Show($"Erreur lors de la modification du tag : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                transaction.Rollback();
            }

        }
    }
}
