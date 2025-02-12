using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PhotossimoV9.Object;

namespace PhotossimoV9.DB.DAO
{
    class DAO_Image : DAO<Object.Img>
    {
        public override Img Create(Img obj, MySqlTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Img obj, MySqlTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public override List<Img> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
