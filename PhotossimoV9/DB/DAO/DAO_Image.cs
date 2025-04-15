using MySql.Data.MySqlClient;
using PhotossimoV9.Object;
using PhotossimoV9.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

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
                command.CommandText = "INSERT INTO images(" +
                    "nom_image, chemin_image, date_import, tags)" +
                    "VALUES(@nom_image, @chemin_image, @date_import, @tags);";
                command.Parameters.AddWithValue("@nom_image", img.GetNom());
                command.Parameters.AddWithValue("@chemin_image", img.CheminImage);
                command.Parameters.AddWithValue("@date_import", img.DateImport);
                command.Parameters.AddWithValue("@tags", Utils.Utils.ParseListToString(img.ListTagToListInt()));
                command.ExecuteNonQuery();

                //On récupére l'ID de l'image créé par la bdd
                command.CommandText = "SELECT LAST_INSERT_ID();";
                img.IdImage = Convert.ToInt32(command.ExecuteScalar());
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
                command.Parameters.AddWithValue("@id_image", img.IdImage);
                command.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine("Erreur : " + e.Message);
            }
        }

        public override List<Img> FindAll()
        {
            MySqlConnection connection = DataBase.GetInstance();
            MySqlCommand command = connection.CreateCommand();
            command.Connection = connection;

            List<Img> listImg = [];

            try
            {
                command.CommandText = "SELECT * FROM images";

                MySqlDataReader msdr = command.ExecuteReader();
                if (msdr.HasRows)
                    while (msdr.Read())
                    {
                        if (!Int32.TryParse(msdr["id_image"].ToString(), out int idImage)) throw new ArgumentNullException("IdImage invalide");
                        if (msdr["chemin_image"] is not string cheminImage) throw new ArgumentNullException("cheminImage invalide");
                        if (!DateTime.TryParse(msdr["date_import"].ToString(), out DateTime dateImport)) throw new ArgumentNullException("dateimport invalide");
                        if (msdr["tags"] is not string stringTags) throw new ArgumentNullException("tags invalide");

                        List<int> intTags = Utils.Utils.ParseNumbers(stringTags);
                        // On récupére les Tags de l'image dans le dictionnaire de Tag (évite de créer des doublons du même Tag)
                        List<Tag> tagList = Tag.GetTagDictionary().Where(x => intTags.Contains(x.Key)).Select(x => x.Value).ToList();

                        Img newImg = new(idImage, cheminImage, dateImport, tagList);
                        // On complète la liste de Tags avec tous les ancêtres des Tags déjà présents
                        newImg.AddTagsAncestors();

                        listImg.Add(newImg);
                    }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur : " + e.Message);
            }
            return listImg;
        }

        public override void Update(Img img, MySqlTransaction transaction)
        {
            try
            {
                MySqlCommand command = DataBase.GetInstance().CreateCommand();
                command.Transaction = transaction;
                command.CommandText = "UPDATE images SET chemin_image=@chemin_image, date_import=@date_import, tags=@tags WHERE id_image=@id_image";
                command.Parameters.AddWithValue("@chemin_image", img.CheminImage);
                command.Parameters.AddWithValue("@date_import", img.DateImport);
                command.Parameters.AddWithValue("@tags", Utils.Utils.ParseListToString(img.ListTagToListInt()));
                command.Parameters.AddWithValue("@id_image", img.IdImage);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur : " + e.Message);
            }
        }
    }
}
