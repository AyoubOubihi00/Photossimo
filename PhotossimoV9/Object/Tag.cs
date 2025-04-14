using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotossimoV9.DB.DAO;

namespace PhotossimoV9.Object
{
    class Tag
    {
        private Tag? _parent;
        private static Dictionary<int, Tag> _tagDictionary = [];
        public int IdTag { get; set; }
        public string NomTag { get; set; }
        public Tag? Parent { 
            get { return _parent; } 
            set { 
                _parent = value;
                _parent?.Enfants.Add(this);
            } 
        }
        public List<Tag> Enfants { get; } = [];

        private Tag(int idTag, string nomTag, Tag? parent)
        {
            this.IdTag = idTag;
            this.NomTag = nomTag;
            this.Parent = parent;
        }

        public static Tag GetOrCreate(int id, string nomTag, Tag? parent)
        {
            if(_tagDictionary.TryGetValue(id, out Tag? tag)) return tag;
            else {
                if (parent is null) GetTagDictionary().TryGetValue(0, out parent);
                tag = new Tag(id, nomTag, parent);
                _tagDictionary.Add(id, tag);
                return tag;
            }
        }

        public static Dictionary<int, Tag> GetTagDictionary() { 
            if(_tagDictionary.Count == 0)
            {
                Tag root = new(0, "root", null);
                List<Tag> tags = new DAO_Tag().FindAll();

                foreach(Tag tag in tags)
                    GetOrCreate(tag.IdTag, tag.NomTag, tag.Parent);
                return _tagDictionary;
            }
            else return _tagDictionary;
        }
    }
}

