bool VerificationAdn(string chaineADN)
{
    if (string.IsNullOrEmpty(chaineADN))
        return false;

    foreach(char letter in chaineADN)
        if (!"atcg".Contains(letter))
            return false;

    return true;
}

string SaisieAdn()
{
    Console.WriteLine("Merci de saisir ci-dessous la chaîne ADN  :");
    string chaineADN;
    chaineADN = Console.ReadLine()!;
    while (string.IsNullOrEmpty(chaineADN) || !VerificationAdn(chaineADN))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("La chaîne ADN n'est pas valide !");
        Console.ResetColor();
        Console.WriteLine("Merci de saisir ci-dessous la chaîne ADN  :");
        chaineADN = Console.ReadLine()!;
    }

    return chaineADN;
}

int Proportion(string chaine, string sequence)
{
    int nbOccurencesDeSequence = chaine.Split(sequence).Length - 1;

    return (nbOccurencesDeSequence * sequence.Length * 100) / chaine.Length;
}

string chaineAdn = SaisieAdn();

const string sequence = "aaa";
int pourcentageOccurences = Proportion(chaineAdn, sequence);
Console.WriteLine();
Console.WriteLine($"===> La chaîne ADN [\x1b[36m{chaineAdn}\x1b[0m] est composée à \x1b[32m{pourcentageOccurences}%\u001b[0m de la séquence [\u001b[36m{sequence}\x1b[0m]");
