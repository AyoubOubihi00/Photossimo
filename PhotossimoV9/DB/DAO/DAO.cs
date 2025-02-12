using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotossimoV9.DB.DAO
{
    abstract class DAO<T>
    {
        public abstract List<T> FindAll();
        public abstract void Create(T obj, MySqlTransaction transaction);
        public abstract void Delete(T obj, MySqlTransaction transaction);
    }
}
