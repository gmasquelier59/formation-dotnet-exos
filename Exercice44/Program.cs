bool VerificationAdn(string chaine)
{
    if (string.IsNullOrEmpty(chaine))
        return false;

    foreach(char letter in chaine)
        if (!"atcg".Contains(letter))
            return false;

    return true;
}

string SaisieAdn()
{
    Console.WriteLine("Merci de saisir la chaîne ADN ci-dessous :");
    string chaine;
    chaine = Console.ReadLine()!;
    while (string.IsNullOrEmpty(chaine) || !VerificationAdn(chaine))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("La chaîne ADN n'est pas valide !");
        Console.ResetColor();
        Console.WriteLine("Merci de saisir la chaîne ADN ci-dessous :");
        chaine = Console.ReadLine()!;
    }

    return chaine;
}

int Proportion(string chaine, string sequence)
{
    int nbOccurences = chaine.Split(sequence).Length - 1;

    return (nbOccurences * sequence.Length * 100) / chaine.Length;
}

string chaineAdn = SaisieAdn();

const string sequence = "aaa";
int pourcentageOccurences = Proportion(chaineAdn, sequence);
Console.WriteLine();
Console.WriteLine($"===> La chaîne ADN [\x1b[36m{chaineAdn}\x1b[0m] est composée à \x1b[32m{pourcentageOccurences}%\u001b[0m de la séquence [\u001b[36m{sequence}\x1b[0m]");
