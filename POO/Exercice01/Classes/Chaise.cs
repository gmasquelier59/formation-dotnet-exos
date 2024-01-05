using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice01.Classes
{
    internal class Chaise
    {
        private int _nbPieds;

        public int NbPieds
        {
            get => _nbPieds;
            set
            {
                if (value < 1 || value > 10)
                    throw new ArgumentOutOfRangeException(nameof(value), "Le nombre de pieds doit être compris entre 1 et 10");
                _nbPieds = value;
            }
        }
        public string Materiau { get; set; }
        public string Couleur { get; set; }

        /// <summary>
        /// Instancie une chaise avec 4 pieds en Bois de couleur Blanche
        /// </summary>
        public Chaise() {
            NbPieds = 4;
            Materiau = "Bois";
            Couleur = "Blanche";
        }

        public Chaise(int nbPieds, string materiau, string couleur)
        {
            NbPieds = nbPieds;
            Materiau = materiau;
            Couleur = couleur;
        }

        public override string ToString()
        {
            return $"Je suis une {this.GetType().Name}, avec {NbPieds} pied(s) en {Materiau} et de couleur {Couleur}";
        }
    }
}
