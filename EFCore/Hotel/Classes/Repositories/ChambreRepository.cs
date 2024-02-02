using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Classes.Repositories
{
    internal class ChambreRepository : IRepository<Hotel, int>
    {
        public static void Save(Chambre entity)
        {
            using HotelDbContext context = new HotelDbContext();
            context.Add(entity);
            context.SaveChanges();
        }
    }
}
