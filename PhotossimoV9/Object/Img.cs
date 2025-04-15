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
        private string _cheminImage;
        private List<Tag> _tags;
        public int IdImage { get; set; }
        public string CheminImage { 
            get { return _cheminImage; } 
            set {
                if (!string.IsNullOrWhiteSpace(value))
                    _cheminImage = value;
                else
                    throw new ArgumentException("Le chemin de l'image ne peut pas être vide !");
            }
        }
        public DateTime DateImport { get; set; }
        public List<Tag> Tags
        {
            get { return _tags; }
            set
            {
                _tags = value ?? [];
            }
        }

        public Image? Image { get; set; }

        public Img(int idImage, string cheminImage, DateTime dateImport, List<Tag> Tags)
        {
            IdImage = idImage;
            CheminImage = cheminImage;
            DateImport = dateImport;
            this.Tags = Tags ?? []; // Si Tags est null, on initialise une liste vide

            try { 
                    Image = Image.FromFile(CheminImage);
            }
            catch (FileNotFoundException e) {
                Console.WriteLine(e.Message);
            }

            AddTagsAncestors();
        }

        public string GetNom()
        {
            if (string.IsNullOrWhiteSpace(CheminImage))
                return "Nom inconnu";
            
            int dernierIndex = CheminImage.LastIndexOf('/');
            return (dernierIndex != -1) ? CheminImage.Substring(dernierIndex + 1) : CheminImage;
           
        }

        public List<int> ListTagToListInt()
        {
            List<int> listTagsInt = [];
            foreach (Tag tag in Tags)
                listTagsInt.Add(tag.IdTag);
            return listTagsInt;
        }

        public void AddTagsAncestors()
        {
            List<Tag> ancestorsToAdd = [];
            foreach (Tag tag in Tags)
            {
                Tag? tempTag = tag.Parent;
                while(tempTag != null && !Tags.Contains(tempTag) && !ancestorsToAdd.Contains(tempTag))
                {
                    ancestorsToAdd.Add(tempTag);
                    tempTag = tempTag.Parent;
                }
            }
            Tags.AddRange(ancestorsToAdd);
        }
    }
}
