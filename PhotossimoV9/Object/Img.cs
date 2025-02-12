using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Bcpg;
using System.IO;

namespace PhotossimoV9.Object
{
    class Img
    {
        public int id_image { get; set; }
        public string chemin_image { get; set; }
        public DateTime date_import { get; set; }
        public List<Tag>tags { get; set; }

        //Constructeur par défaut
        public Img() {
            tags = new List<Tag>();
        }


        //Constructeur avec parametres
        public Img(int idImage,string cheminImage,DateTime dateImport,string Tags)
        {
            id_image = idImage;
            chemin_image = cheminImage;
            date_import = dateImport;
            tags = (tags != null) ? tags : new List<Tag>(); // Si tags est null, on initialise une liste vide

        }

        public int GetID()
        {
            return id_image;
        }
        public void SetId(int IdImage)
        {
            id_image = IdImage;
        }

        public string GetNom()
        {
            if (string.IsNullOrWhiteSpace(chemin_image))
                return "Nom inconnu";
            
            int dernierIndex = chemin_image.LastIndexOf('/');
            return (dernierIndex != -1) ? chemin_image.Substring(dernierIndex + 1) : chemin_image;
           
        }

        public string GetChemin()
        {
            return chemin_image;
        }
        public void SetChemin( string CheminImage)
        {
            if(!string.IsNullOrWhiteSpace(CheminImage))
            {
                chemin_image = CheminImage;
            }
            else
            {
                throw new ArgumentException("Le chemin de l'image ne peut pas être vide !");
            }
        }

        public DateTime GetDateImport()
        {
            return date_import;
        }

        public void SetDateImport( DateTime date)
        {
            date_import = date;
        }

        public List<Tag> GetTags()
        {
            return tags;
        }

        public void SetTags(List<Tag> Tags)
        {
            tags = Tags ?? new List<Tag>(); // Si null, on initialise une liste vide
        }

        public List<int> GetTagsToListInt()
        {
            List<int> ListIdTags = new();

            foreach(Tag t in tags)
            {
                ListIdTags.Add(t.GetID());
            }
            return ListIdTags;
        }

    }
}
