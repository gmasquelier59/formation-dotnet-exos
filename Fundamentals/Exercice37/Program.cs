string[] months = {"Janvier", "Février", "Mars", "Avril", "Mai", "Juin", "Juillet", "Août", "Septembre", "Octobre", "Novembre", "Décembre"};
Console.WriteLine("Enumération du tableau avec un foreach :");

int increment = 0;
foreach(string month in months)
{
    Console.WriteLine(string.Concat(Enumerable.Repeat("\t", increment)) + month);
    increment++;
}