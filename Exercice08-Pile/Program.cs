using Exercice08_Pile.Classes;

Console.WriteLine("------------------------");
Console.WriteLine("--- Liste de strings ---");
Console.WriteLine("------------------------");

Pile<string> pileString = new Pile<string>(5);
pileString.Push("Element A");
pileString.Push("Element B");
pileString.Push("Element C");
pileString.Push("Element D");

pileString.Display();

Console.WriteLine();
Console.WriteLine("On retire le dernier élément de la liste");
pileString.Pop();
pileString.Display();

Console.WriteLine();
Console.WriteLine("On retire le dernier élément de la liste");
pileString.Pop();
pileString.Display();

Console.WriteLine();
Console.WriteLine("On nettoie la liste");
pileString.Clear();
pileString.Display();

Console.WriteLine();
Console.WriteLine("-------------------------");
Console.WriteLine("--- Liste de décimaux ---");
Console.WriteLine("-------------------------");

Pile<decimal> pileDecimaux = new Pile<decimal>(5);
pileDecimaux.Push(1.5M);
pileDecimaux.Push(2.0M);
pileDecimaux.Push(25.99985M);
pileDecimaux.Push(99999.999999M);

pileDecimaux.Display();

Console.WriteLine();
Console.WriteLine("On retire le dernier élément de la liste");
pileDecimaux.Pop();
pileDecimaux.Display();

Console.WriteLine();
Console.WriteLine("On retire le dernier élément de la liste");
pileDecimaux.Pop();
pileDecimaux.Display();

Console.WriteLine();
Console.WriteLine("On nettoie la liste");
pileDecimaux.Clear();
pileDecimaux.Display();

Console.WriteLine();
Console.WriteLine("--------------------------");
Console.WriteLine("--- Liste de personnes ---");
Console.WriteLine("--------------------------");

Pile<Personne> pilePersonnes = new Pile<Personne>(5);
pilePersonnes.Push(new Personne("Guillaume", "MASQUELIER", 42));
pilePersonnes.Push(new Personne("Jean", "DUPONT", 28));
pilePersonnes.Display();

Console.WriteLine();
Console.WriteLine("On retire le dernier élément de la liste");
pilePersonnes.Pop();
pilePersonnes.Display();

Console.WriteLine();
Console.WriteLine("On ajoute 2 personnes");
pilePersonnes.Push(new Personne("Jean", "MICHEL", 32));
pilePersonnes.Push(new Personne("Julie", "SMITH", 69));
pilePersonnes.Display();

Console.WriteLine();
Console.WriteLine("On retire le dernier élément de la liste");
pilePersonnes.Pop();
pilePersonnes.Display();

Console.WriteLine();
Console.WriteLine("On nettoie la liste");
pilePersonnes.Clear();
pilePersonnes.Display();
