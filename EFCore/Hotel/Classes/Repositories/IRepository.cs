using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Classes.Repositories
{
    internal interface IRepository<T, Tid> where T : new()
    {
        static void Save(T entity) { }
    }
}
