using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using MySql.Data.MySqlClient;
using PhotossimoV9.Object;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PhotossimoV9.DB.DAO
{
    class DAO_Tag : DAO<Object.TagImg>
    {
        public override void Create(TagImg tag, MySqlTransaction transaction)
        {
            MySqlConnection connection = DataBase.GetInstance();
            MySqlCommand command = connection.CreateCommand();
            command.Connection = connection;
            command.Transaction = transaction;

            try
            {
                command.CommandText = "INSERT INTO tags(" +
                    "nom_tag, id_parent)" +
                    "VALUES(@nom_tag, @id_parent);";
                command.Parameters.AddWithValue("@nom_tag", tag.IdTag);
                if (tag.Parent is not null) command.Parameters.AddWithValue("@chemin_image", tag.Parent.IdTag);
                else throw new ArgumentNullException("Le parent est null lors de la création dans la BDD");
                command.ExecuteNonQuery();

                //On récupére l'ID du tag créé par la bdd
                command.CommandText = "SELECT LAST_INSERT_ID();";
                tag.IdTag = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur : " + e.Message);
            }
        }

        public override void Delete(TagImg tag, MySqlTransaction transaction)
        {
            MySqlConnection connection = DataBase.GetInstance();
            MySqlCommand command = connection.CreateCommand();
            command.Connection = connection;
            command.Transaction = transaction;

            try
            {
                command.CommandText = "DELETE FROM tags WHERE id_tag=@id_tag;";
                command.Parameters.AddWithValue("@id_tag", tag.IdTag);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur : " + e.Message);
            }
        }

        public override List<TagImg> FindAll()
        {
            MySqlConnection connection = DataBase.GetInstance();
            MySqlCommand command = connection.CreateCommand();
            command.Connection = connection;

            List<TagImg> listTag = [];

            try
            {
                command.CommandText = "SELECT * FROM tags ORDER BY id_parent IS NULL DESC, id_parent ASC";

                using (MySqlDataReader msdr = command.ExecuteReader())
                {
                    if (msdr.HasRows)
                    {
                        while (msdr.Read())
                        {
                            if (!Int32.TryParse(msdr["id_tag"].ToString(), out int idTag)) throw new ArgumentNullException("IdTag invalide");
                            if (msdr["nom_tag"] is not string nomTag) throw new ArgumentNullException("NomTag invalide");
                            if (!Int32.TryParse(msdr["id_parent"].ToString(), out int idParent)) throw new ArgumentNullException("IdParent invalide");

                            if (!TagImg.GetTagDictionary().TryGetValue(idParent, out TagImg? parent)) throw new ArgumentException("Le parent n'existe pas");
                            TagImg newTag = TagImg.GetOrCreate(idTag, nomTag, parent);
                            listTag.Add(newTag);
                        }
                    }
                } 
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur : " + e.Message);
            }
            return listTag;
        }


        public override void Update(TagImg tag, MySqlTransaction transaction)
        {
            try
            {
                MySqlCommand command = DataBase.GetInstance().CreateCommand();
                command.Transaction = transaction;
                command.CommandText = "UPDATE tags SET nom_tag=@nom_tag, id_parent=@id_parent WHERE id_tag=@id_tag";
                command.Parameters.AddWithValue("@nom_tag", tag.NomTag);
                command.Parameters.AddWithValue("@id_parent", tag.Parent?.IdTag ?? 0);
                if (tag.Parent is not null)
                    command.Parameters.AddWithValue("@id_tag", tag.IdTag);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur : " + e.Message);
            }
        }
    }
}
