using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice02_Commandes.Classes.DAO
{
    internal interface IBaseDAO<T>
    {
        public static abstract T Save(T element);
        public static abstract List<T> All();
        public static abstract T? GetById(int id);
        public static abstract bool Delete(T element);
        public static abstract T? CreateFromReader(SqlDataReader reader);
    }
}
