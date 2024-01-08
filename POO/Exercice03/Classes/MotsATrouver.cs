using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice03.Classes
{
    internal static class MotsATrouver
    {
        private static string[] mots = {
            "hippocampe",
            "dragon",
            "perdrix",
            "pomme",
            "couteau",
            "abeille",
            "silhouette",
            "cheval",
            "jaguar",
            "chat",
            "chevre",
            "lezard",
            "hippopotame",
            "autruche",
            "escargot",
            "hamster",
            "alpaga",
            "dromadaire",
            "vison",
            "jaguar",
            "cochon",
            "iguane",
            "kangourou",
            "sauterelle",
            "autruche",
            "poule",
            "poney",
            "phoque",
            "cacatoes",
            "moineau",
            "chameau",
            "moustique"
        };

        public static string ObtenirUnMot()
        {
            Random random = new Random();

            return mots[random.Next(0, mots.Length)];
        }
    }
}
