using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PhotossimoV9.DB;
using PhotossimoV9.DB.DAO;

namespace PhotossimoV9.Object
{
    public class TagImg
    {
        private TagImg? _parent;
        private static Dictionary<int, TagImg> _tagDictionary = [];
        public int IdTag { get; set; }
        public string NomTag { get; set; }
        public TagImg? Parent
        {
            get { return _parent; }
            set
            {
                _parent = value;
                _parent?.Enfants.Add(this);
            }
        }
        public List<TagImg> Enfants { get; } = [];

        private TagImg(int idTag, string nomTag, TagImg? parent)
        {
            this.IdTag = idTag;
            this.NomTag = nomTag;
            this.Parent = parent;
        }

        public static TagImg GetOrCreate(int id, string nomTag, TagImg? parent)
        {
            if (_tagDictionary.TryGetValue(id, out TagImg? tag)) return tag;
            else
            {
                if (parent is null) GetTagDictionary().TryGetValue(0, out parent);
                tag = new TagImg(id, nomTag, parent);
                _tagDictionary.Add(id, tag);
                return tag;
            }
        }

        public static void InitializeDictionary()
        {
            TagImg root = new(0, "root", null);
            _tagDictionary.Add(root.IdTag, root);

            List<TagImg> tags = new DAO_TagImg().FindAll();
        }

        public static Dictionary<int, TagImg> GetTagDictionary()
        {
            if (_tagDictionary.Count == 0)
            {
                InitializeDictionary();
            }
            return _tagDictionary;
        }

        public static void ClearDictionary()
        {
            _tagDictionary.Clear();
        }


        // Cette fonction permet  ne pas perdre les enfants et aussi  et aussi de Supprimer proprement un tag parent sans erreur.
        public void SupprimerParent()
        {
            DAO_TagImg dao = new DAO_TagImg();
            MySqlConnection connection = DataBase.GetInstance();
            MySqlTransaction transaction = connection.BeginTransaction();

            try
            {
                // on va rattacher tous les enfants à le parent de tag qu'on veut supprimer
                foreach (var enfant in this.Enfants)
                {
                    enfant.Parent = this.Parent; // Changer le parent dans l'objet
                    dao.Update(enfant, transaction); // Mettre à jour en BDD
                }

                //  On doir supprimer ce tag
                dao.Delete(this, transaction);

                //  On doit valider la transaction
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur dans DeleteTag() : " + ex.Message);
                transaction.Rollback();
            }
        }

        public void SupprimerEnfant()
        {
            DAO_TagImg dao = new DAO_TagImg();
            MySqlConnection connection = DataBase.GetInstance();
            MySqlTransaction transaction = connection.BeginTransaction();
            try
            {
                // On fait la verification pour supprimer des enfants qui sont vraiment des enfants( qui ont pas de fils)
                if(this.Enfants.Count > 0)
                {
                   throw new InvalidOperationException("Impossible de supprimer un tag qui a des enfants");
                }
                // On doit supprimer ce tag
                dao.Delete(this, transaction);
                // On doit valider la transaction
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur dans SupprimeEnfant() : " + ex.Message);
                transaction.Rollback();
            }
        }

    }
}