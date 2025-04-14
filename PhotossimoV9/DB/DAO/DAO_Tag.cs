using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using MySql.Data.MySqlClient;
using PhotossimoV9.Object;

namespace PhotossimoV9.DB.DAO
{
    class DAO_Tag : DAO<Object.Tag>
    {
        public override void Create(Tag tag, MySqlTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Tag tag, MySqlTransaction transaction)
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

        public override List<Tag> FindAll()
        {
            MySqlConnection connection = DataBase.GetInstance();
            MySqlCommand command = connection.CreateCommand();
            command.Connection = connection;

            List<Tag> listTag = [];

            try
            {
                command.CommandText = "SELECT * FROM tags";

                MySqlDataReader msdr = command.ExecuteReader();
                if (msdr.HasRows)
                    while (msdr.Read())
                    {
                        if (!Int32.TryParse(msdr["id_tag"].ToString(), out int idTag)) throw new ArgumentNullException("IdTag invalide");
                        if (msdr["nom_tag"] is not string nomTag) throw new ArgumentNullException("NomTag invalide");
                        if (!Int32.TryParse(msdr["id_parent"].ToString(), out int idParent)) throw new ArgumentNullException("IdParent invalide");

                        if(!Tag.GetTagDictionary().TryGetValue(idParent, out Tag? parent)) throw new ArgumentException("Le parent n'existe pas");
                        Tag newTag = Tag.GetOrCreate(idTag,  nomTag, parent);
                        listTag.Add(newTag);
                    }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur : " + e.Message);
            }
            return listTag;
        }

        public override void Update(Tag tag, MySqlTransaction transaction)
        {
            try
            {
                MySqlCommand command = DataBase.GetInstance().CreateCommand();
                command.Transaction = transaction;
                command.CommandText = "UPDATE tags SET nom_tag=@nom_tag, id_parent=@id_parent WHERE id_tag=@id_tag";
                command.Parameters.AddWithValue("@nom_tag", tag.NomTag);
                command.Parameters.AddWithValue("@id_parent", tag.IdTag);
                if(tag.Parent is not null)
                    command.Parameters.AddWithValue("@id_tag", tag.Parent.IdTag);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur : " + e.Message);
            }
        }
    }
}
