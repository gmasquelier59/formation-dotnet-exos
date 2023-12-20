Console.WriteLine("--- Quelle est la nature du triangle ABC ? ---");

Console.Write("Entrez la longueur du segment AB : ");
if (!double.TryParse(Console.ReadLine(), out double segmentAB))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Error.WriteLine("La longueur doit être numérique !");
    Console.ResetColor();
    return;
}

Console.Write("Entrez la longueur du segment BC : ");
if (!double.TryParse(Console.ReadLine(), out double segmentBC))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Error.WriteLine("La longueur doit être numérique !");
    Console.ResetColor();
    return;
}

Console.Write("Entrez la longueur du segment CA : ");
if (!double.TryParse(Console.ReadLine(), out double segmentCA))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Error.WriteLine("La longueur doit être numérique !");
    Console.ResetColor();
    return;
}

if (segmentAB == segmentBC && segmentBC == segmentCA && segmentAB == segmentCA)
{
    Console.WriteLine("Le triangle est équilatéral");
}
else if (segmentAB == segmentCA)
{
    Console.WriteLine("Le triangle est isocèle en A mais n'est pas équilatéral");
}
else if (segmentAB == segmentBC)
{
    Console.WriteLine("Le triangle est isocèle en B mais n'est pas équilatéral");
}
else if (segmentBC == segmentCA)
{
    Console.WriteLine("Le triangle est isocèle en C mais n'est pas équilatéral");
}
else
{
    Console.WriteLine("Le triangle n'est ni isocèle en A, ni en B, ni en C");
}