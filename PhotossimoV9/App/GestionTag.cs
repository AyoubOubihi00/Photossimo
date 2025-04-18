using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhotossimoV9.DB.DAO;
using PhotossimoV9.Object;
using PhotossimoV9.App;
using Photossimo;

namespace PhotossimoV9.App
{
    public partial class GestionTag : Form
    {
        private TagImg? tagTrouve = null;
        public GestionTag()
        {
            InitializeComponent();
        }

        public void buttonRecherche_Click(object sender, EventArgs e)
        {
            string recherhceTag = rechercheBox.Text.Trim().ToLower();

            tagTrouve = TagImg.GetTagDictionary().Values
                .FirstOrDefault(tag => tag.NomTag.ToLower().Contains(recherhceTag));

            if (tagTrouve != null)
            {
                labelResultat.Text = $"Tag trouvé : {tagTrouve.NomTag}";
            }
            else
            {
                labelResultat.Text = "Aucun tag trouvé.";
                rechercheBox.Text = "";
                labelResultat.Text = "";
                tagTrouve = null;
            }


        }
        // Button pour la suppression d'un tag
        public void ButtonSuppresion(object sender, EventArgs e)
        {
            if (tagTrouve == null) // Vérifie si un tag a été trouvé
            {
                MessageBox.Show("Aucun tag sélectionné pour suppression.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tagTrouve.IdTag == 0) // Vérifie si le tag trouvé est la racine
            {
                MessageBox.Show("Impossible de supprimer le tag racine.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tagTrouve.Enfants.Count == 0) // Verfie si le tag qu'on veut supprimer est un enfant ou un parent qui a des fils
            {
                tagTrouve.SupprimerEnfant();
            }
            else
            {
                tagTrouve.SupprimerParent();
            }

            MessageBox.Show("Tag supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

            rechercheBox.Text = "";// on vide la zone de recherche
            labelResultat.Text = "";// on vide le label de resultat
            tagTrouve = null;// on vide le tag trouvé


            this.DialogResult = DialogResult.OK; // on indique que l'opération a été effectuée avec succès
            this.Close();// on ferme la fenêtre de gestion des tags


        }


        //Fonction qui permet d'ouvrir la fenetre de création d'un tag
        private void CreationTag(object sender, EventArgs e)
        {
            CreateTag createTagForm = new CreateTag(); // On va creer l'instance de la fenêtre de création de tag
            var result = createTagForm.ShowDialog(); // Affiche la fenêtre de création de tag 

            if (result == DialogResult.OK) // On verifie si le tag a ete cree avec succes , et alors on rafrachit la liste des tag ds la mainview
            {

                TagImg.ClearDictionary();
                TagImg.InitializeDictionary();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
