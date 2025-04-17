using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotossimoV9.DB.DAO;

namespace PhotossimoV9.Object
{
    class TagImg
    {
        private TagImg? _parent;
        private static Dictionary<int, TagImg> _tagDictionary = [];
        public int IdTag { get; set; }
        public string NomTag { get; set; }
        public TagImg? Parent { 
            get { return _parent; } 
            set { 
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
            if(_tagDictionary.TryGetValue(id, out TagImg? tag)) return tag;
            else {
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

            List<TagImg> tags = new DAO_Tag().FindAll();
        }

        public static Dictionary<int, TagImg> GetTagDictionary() { 
            if(_tagDictionary.Count == 0)
            {
                InitializeDictionary();
            }
            return _tagDictionary;
        }
    }
}

