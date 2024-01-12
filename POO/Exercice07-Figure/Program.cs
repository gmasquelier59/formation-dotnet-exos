using Exercice07_Figure.Classes;

Carre carre = new Carre(2, 4, 2);
Console.WriteLine(carre);

Console.WriteLine("\n==================================================================\n");

Rectangle rectangle = new Rectangle(2, 4, 10, 5);
Console.WriteLine(rectangle);

Console.WriteLine("\n==================================================================\n");

Triangle triangle = new Triangle(2, 4, 4, 5);
Console.WriteLine(triangle);

Console.WriteLine("\n==================================================================\n");

Console.WriteLine("Déplacement du carré par (1,3)");
carre.Deplacer(1, 3);
//  carre.Origine.Deplacer(1, 3);

Console.WriteLine(carre);