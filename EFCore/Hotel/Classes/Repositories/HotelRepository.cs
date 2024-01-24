using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Classes.Repositories
{
    internal class HotelRepository : IRepository<Hotel, int>
    {
        public static void Save(Hotel entity)
        {
            using HotelDbContext context = new HotelDbContext();
            context.Add(entity);
            context.SaveChanges();
        }

        public static void Update(Hotel entity)
        {
            using HotelDbContext context = new HotelDbContext();
            context.Update(entity);
            context.SaveChanges();
        }

        public static Hotel? GetById(int id)
        {
            using HotelDbContext context = new HotelDbContext();
            return context.Hotels.Find(id);
        }
    }
}
