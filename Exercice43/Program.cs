int compter_lettre_a(string chaine)
{
    int count = 0;

    foreach(char lettre in chaine)
    {
        if (lettre == 'a')
            count++;
    }

    return count;
}

int compter_lettre_a_bis(string chaine)
{
    return chaine.Count(x => x == 'a');
}

Console.WriteLine(compter_lettre_a("C'est le b-a ba"));
Console.WriteLine(compter_lettre_a("mixer"));

Console.WriteLine(compter_lettre_a_bis("C'est le b-a ba"));
Console.WriteLine(compter_lettre_a_bis("mixer"));