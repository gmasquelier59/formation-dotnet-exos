using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice03.Classes
{
    internal class Pendu
    {
        /// <summary>
        /// Caractère de masquage utilisé pour masquer les lettres non trouvées du mot à deviner
        /// </summary>
        private const char caractereDeMasque = '-';

        /// <summary>
        /// Liste des lettres trouvées par le joueur
        /// </summary>
        public List<string> LettresTrouvees { get; private set; } = new List<string>();

        /// <summary>
        /// Mot à trouver par le joueur
        /// </summary>
        public string MotADeviner { get; private set; }

        /// <summary>
        /// Nombre d'essais au départ du jeu
        /// </summary>
        public int NbEssais { get; private set; }

        public Pendu(int nbEssais)
        {
            NbEssais = nbEssais;

            MotADeviner = MotsATrouver.ObtenirUnMot();
        }

        /// <summary>
        /// Indique si la lettre spécifiée fait partie du mot à trouver. Si c'est le cas, ajoute la lettre
        /// aux lettres trouvées par le joueur
        /// </summary>
        /// <param name="lettre">Lettre à tester</param>
        /// <returns>Un bool indiquant si la lettre est valide ou non</returns>
        public bool TestChar(string lettre)
        {
            if (string.IsNullOrEmpty(lettre))
                return false;

            if (MotADeviner.Contains(lettre))
            {
                LettresTrouvees.Add(lettre);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Indique si le joueur a trouvé toutes les lettres
        /// </summary>
        public bool TestWin()
        {
            return !this.GenererMasque().Contains(caractereDeMasque);
        }

        /// <summary>
        /// Génère le masque d'affichage du mot à trouver en prenant en compte les lettres déjà
        /// trouvées par le joueur
        /// </summary>
        /// <returns>Le masque d'affichage. Les lettres non trouvées sont remplacées par *</returns>
        public string GenererMasque()
        {
            string masque = "";
            foreach (char lettre in MotADeviner)
                masque += LettresTrouvees.Contains("" + lettre) ? lettre : caractereDeMasque;
            return masque;
        }
    }
}
