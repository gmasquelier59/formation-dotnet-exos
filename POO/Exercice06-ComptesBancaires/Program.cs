using Exercice06_ComptesBancaires.Classes;
using System.Text;
using Console = Spectre.Console.AnsiConsole;

System.Console.OutputEncoding = Encoding.UTF8;

Client client = new Client("Dupont", "Jean", "DJ000001", "0601020304");

CompteCourant compteCourant = new CompteCourant();
compteCourant.NouvelleOperation(OperationStatut.DEPOT, 1000);
compteCourant.NouvelleOperation(OperationStatut.RETRAIT, 1200);

CompteEpargne compteEpargne = new CompteEpargne();
compteEpargne.NouvelleOperation(OperationStatut.DEPOT, 500);
compteEpargne.NouvelleOperation(OperationStatut.RETRAIT, 10);
compteEpargne.NouvelleOperation(OperationStatut.DEPOT, 50);

ComptePayant comptePayant = new ComptePayant();
comptePayant.NouvelleOperation(OperationStatut.DEPOT, 500);

client.AjouterCompte(compteCourant);
client.AjouterCompte(compteEpargne);
client.AjouterCompte(comptePayant);

client.Afficher();