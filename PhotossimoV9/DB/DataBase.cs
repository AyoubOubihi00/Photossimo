using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotossimoV9.DB
{
    internal class DataBase
    {
        private static MySqlConnection? connection;

        public static MySqlConnection GetInstance()
        {
            if (connection == null)
            {
                string connectionString = "Server=127.0.0.1;Database=archivage_images;User ID=root;Password=;";

                try
                {
                    connection = new MySqlConnection(connectionString);
                    connection.Open();
                    Console.WriteLine("Connexion réussie !");
                    return connection;
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                    throw new NullReferenceException(ex.Message);
                }
            }
            return connection;
        }
    }
}
