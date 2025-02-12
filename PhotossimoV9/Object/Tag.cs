using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotossimoV9.Object
{
    class Tag
    {
        public int id_tag;
        public string nom_tag;
        public int id_parent;

        public int GetID()
        {
            return id_tag;
        }

    }
}
