using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice03.Classes
{
    internal static class IHM
    {
        public static void Start(Pendu pendu)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ASCIIArt.Titre);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Vous avez {pendu.NbEssais} essais pour trouver le mot !");
            Console.WriteLine($"Indice : c'est un animal ou un insecte :-)");
            Console.ResetColor();
            Console.WriteLine();

            Sound.PlayStartup();

            int nbEssai = pendu.NbEssais;

            while (!pendu.TestWin() && nbEssai > 0)
            {
                string masque = pendu.GenererMasque();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Le mot à trouver : {masque}");

                char lettre = SaisieLettre();

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(ASCIIArt.Titre);

                if (!pendu.TestChar($"{lettre}"))
                {
                    nbEssai--;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Zut, mauvaise pioche :-(");

                    Console.WriteLine();
                    AfficherPotence(pendu.NbEssais - nbEssai, pendu.NbEssais);
                    Sound.PlayWrong();
                }
                else
                {
                    if (pendu.TestWin())
                        break;

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"Super, bonne pioche :-)");

                    Console.WriteLine();
                    AfficherPotence(pendu.NbEssais - nbEssai, pendu.NbEssais);
                    Sound.PlayCorrect();
                }

                Console.WriteLine();
                Console.ResetColor();
            }

            if (pendu.TestWin())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(ASCIIArt.Bravo);
                Console.WriteLine("");
                Console.WriteLine($"C'était bien le mot \"{pendu.MotADeviner}\" qu'il fallait trouver !");
                Console.WriteLine("");
                Sound.PlaySuccess();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(ASCIIArt.Dommage);
                Console.WriteLine("");
                Console.WriteLine($"Il fallait trouver le mot \"{pendu.MotADeviner}\" :-)");
                Console.WriteLine("");
                Sound.PlayFail();
            }

            Console.ResetColor();
        }

        private static char SaisieLettre()
        {
            char lettre;

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Veuillez saisir une lettre minuscule : ");
            while (!char.TryParse(Console.ReadLine(), out lettre) || lettre < 'a' || lettre > 'z')
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Saisie incorrecte !");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine();
                Console.Write("Veuillez saisir une lettre minuscule : ");
            }

            return lettre;
        }

        public static void AfficherPotence(int noEssai, int nbEssaiMax)
        {
            string[,] penduAscii = {
                {"           ",
                "            ",
                "            ",
                "            ",
                "            ",
                "            ",
                "--------    "},
                {"           ",
                "            ",
                "            ",
                "║          ",
                "║          ",
                "║          ",
                "--------    "},
                {"           ",
                "║          ",
                "║          ",
                "║          ",
                "║          ",
                "║          ",
                "--------    "},
                {"           ",
                "║/         ",
                "║          ",
                "║          ",
                "║          ",
                "║          ",
                "--------    "},
                {"╔═════     ",
                 "║/         ",
                 "║          ",
                 "║          ",
                 "║          ",
                 "║          ",
                 "--------    "},
                {"╔═════════╗",
                 "║/         ",
                 "║          ",
                 "║          ",
                 "║          ",
                 "║          ",
                 "--------    "},
                {
                "╔═════════╗",
                "║/        ║",
                "║          ",
                "║          ",
                "║          ",
                "║          ",
                "--------    "},
                {
                "╔═════════╗",
                "║/        ║",
                "║         O ",
                "║        /|\\",
                "║        / \\",
                "║          ",
                "--------    "},
            };
        int noPendu = noEssai == 0 ? 0 : (noEssai * 7 / nbEssaiMax);
            for (int i = 0; i< 7; i++)
            {
                Console.WriteLine(penduAscii[noPendu, i] + (i == 6 ? $"{nbEssaiMax - noEssai} essai(s) restant(s)": ""));
            }
}
    }
}
