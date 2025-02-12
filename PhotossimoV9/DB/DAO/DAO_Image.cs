using MySql.Data.MySqlClient;
using PhotossimoV9.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotossimoV9.DB.DAO
{
    class DAO_Image : DAO<Object.Img>
    {
        public override void Create(Img img, MySqlTransaction transaction)
        {
            MySqlConnection connection = DataBase.GetInstance();
            MySqlCommand command = connection.CreateCommand();
            command.Connection = connection;
            command.Transaction = transaction;

            try
            {
                command.CommandText = "INSERT INTO IMAGES(" +
                    "id_image, nom_image, chemin_image, date_import, tags)" +
                    "VALUES(@nom_image, @chemin_image, @date_import, @tags);";
                command.Parameters.AddWithValue("@nom_image", img.GetNom());
                command.Parameters.AddWithValue("@chemin_image", img.GetChemin());
                command.Parameters.AddWithValue("@date_import", img.GetDateImport());
                command.Parameters.AddWithValue("@tags", Utils.ParseListToString(img.GetTagsToListInt()));
                command.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine("Erreur : " + e.Message);
            }
        }

        public override void Delete(Img img, MySqlTransaction transaction)
        {
            MySqlConnection connection = DataBase.GetInstance();
            MySqlCommand command = connection.CreateCommand();
            command.Connection = connection;
            command.Transaction = transaction;

            try
            {
                command.CommandText = "DELETE FROM Images WHERE id_image=@id_image;";
                command.Parameters.AddWithValue("@id_image", img.GetID());
                command.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine("Erreur : " + e.Message);
            }
        }

        public override List<Img> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
