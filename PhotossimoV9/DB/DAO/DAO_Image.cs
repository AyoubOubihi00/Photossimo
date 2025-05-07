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
                    "nom_image, date_import, tags)" +
                    "VALUES(@nom_image, @date_import, @tags);";
                command.Parameters.AddWithValue("@nom_image", img.NomImage);
                command.Parameters.AddWithValue("@date_import", img.DateImport);
                command.Parameters.AddWithValue("@tags", Utils.Utils.ParseListToString(img.ListTagToListInt()));
                command.ExecuteNonQuery();

                //On récupére l'ID de l'image créé par la bdd
                command.CommandText = "SELECT LAST_INSERT_ID();";
                img.IdImage = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception e)
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
            catch (Exception e)
            {
                Console.WriteLine("Erreur : " + e.Message);
            }
        }

        public override List<Img> FindAll()
        {
            var connection = DataBase.GetInstance();

            // 1) Charger d'abord le dictionnaire des tags en mémoire, AVANT d'ouvrir le reader des images
            var dictTags = TagImg.GetTagDictionary();  // n'ouvre qu'un reader, et le ferme

            var listImg = new List<Img>();

            try
            {
                using var cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM images";

                // 2) Ouvrir le reader des images
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Lecture des champs
                    int idImage = reader.GetInt32("id_image");
                    string nomImage = reader.GetString("nom_image");
                    DateTime dateImport = reader.GetDateTime("date_import");
                    string stringTags = reader.GetString("tags");

                    // Transformation de la chaîne de tags en liste d'int
                    var intTags = Utils.Utils.ParseNumbers(stringTags);

                    // 3) Récupérer les TagImg depuis le dict chargé
                    var tagList = intTags
                        .Where(id => dictTags.ContainsKey(id))
                        .Select(id => dictTags[id])
                        .ToList();

                    // Construction de l'objet Img
                    var img = new Img(idImage, nomImage, dateImport, tagList);

                    // Compléter avec les ancêtres
                    foreach (var tag in img.Tags.ToList())
                        img.AddTagsAncestors(tag);

                    listImg.Add(img);
                }
                reader.Close();
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
                command.CommandText = "UPDATE images SET nom_image=@nom_image, date_import=@date_import, tags=@tags WHERE id_image=@id_image";
                command.Parameters.AddWithValue("@nom_image", img.NomImage);
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
