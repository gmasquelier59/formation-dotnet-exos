List<int> alphabet = new List<int> ();
for (int i = 65; i <= 90; i++)
{
    alphabet.Add(i);
}

int increment = 0;
foreach(int asciiCode in alphabet)
{
    Console.WriteLine(string.Concat(Enumerable.Repeat("  ", increment)) + Convert.ToChar(asciiCode));
    increment++;
}