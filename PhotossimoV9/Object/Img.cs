using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Bcpg;
using System.IO;

namespace PhotossimoV9.Object
{
    public class Img
    {
        private List<TagImg> _tags;
        public int IdImage { get; set; }
        public string NomImage { get; set; } 
        public DateTime DateImport { get; set; }
        public List<TagImg> Tags
        {
            get { return _tags; }
            set
            {
                _tags = value ?? [];
            }
        }

        public Image Image { get; set; }

        public Img(int idImage, string nomImage, DateTime dateImport, List<TagImg> Tags)
        {
            IdImage = idImage;
            NomImage = nomImage;
            DateImport = dateImport;
            this.Tags = Tags ?? []; // Si Tags est null, on initialise une liste vide

            try { 
                    Image = Image.FromFile(GetCheminImage());
            }
            catch (FileNotFoundException e) {
                // Image par défaut (pour ne pas que Image soit null)
                Image = Image.FromFile(Path.Combine(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\")), "Ressources", "Images", "NotFound.jpg"));
                Console.WriteLine(e.Message);
            }
            foreach(TagImg tag in this.Tags.ToList())
                AddTagsAncestors(tag);
        }

        public string GetCheminImage()
        {
            // 1) Répertoire où est lancé l'assembly (bin\Debug\net9.0-windows)
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            // 2) Remonter de trois niveaux pour atteindre le dossier racine du projet
            string projectRoot = Path.GetFullPath(Path.Combine(baseDir, @"..\..\..\"));

            // 3) Construire le dossier « Ressources/Images » à partir de la racine
            string imagesFolder = Path.Combine(projectRoot, "Ressources", "Images");

            // 4) (Optionnel) s'assurer que le dossier existe avant d'y écrire
            if (!Directory.Exists(imagesFolder))
                Directory.CreateDirectory(imagesFolder);

            // 5) Retourner le chemin complet vers le fichier image
            return Path.Combine(imagesFolder, NomImage);
        }

        public List<int> ListTagToListInt()
        {
            List<int> listTagsInt = [];
            foreach (TagImg tag in Tags)
                listTagsInt.Add(tag.IdTag);
            return listTagsInt;
        }

        public void AddTagsAncestors(TagImg tag)
        {
            List<TagImg> ancestorsToAdd = [];
            TagImg? tempTag = tag.Parent;
            while (tempTag is not null)
            {
                if(!Tags.Contains(tempTag) && !ancestorsToAdd.Contains(tempTag))
                {
                    ancestorsToAdd.Add(tempTag);
                }
                tempTag = tempTag.Parent;
            }
            Tags.AddRange(ancestorsToAdd);
        }

        public void AddTag(TagImg tag)
        {
            Tags.Add(tag);
            AddTagsAncestors(tag);
        }

        public void RemoveTag(TagImg tag)
        {
            Tags.Remove(tag);
        }
    }
}
