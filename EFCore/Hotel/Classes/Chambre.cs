using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Classes
{
    public enum ChambreStatut
    {
        Libre = 1,
        Occupé = 2,
        Nettoyage = 3
    }

    internal class Chambre
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public ChambreStatut Statut { get; set; }
        public int NbLits { get; set; }
        [Column(TypeName = "DECIMAL(5,2)")]
        public decimal Tarif { get; set; }
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

        public Chambre(int numero, int nbLits, decimal tarif)
        {
            Numero = numero;
            Statut = ChambreStatut.Libre;
            NbLits = nbLits;
            Tarif = tarif;
        }
    }
}
