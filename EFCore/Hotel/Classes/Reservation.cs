using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Classes
{
    public enum ReservationStatut
    {
        Prevu = 1,
        EnCours = 2,
        Fini = 3,
        Annule = 4
    }

    internal class Reservation
    {
        public int Id { get; set; }
        public ReservationStatut Statut { get; set; }
        public Client Client {  get; set; }
        public List<Chambre> Chambres { get; } = new List<Chambre>();
    }
}
