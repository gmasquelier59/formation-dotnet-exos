namespace ASPDotnetCoreMVC_Exercice04.Utils
{
    public class StringGenerator
    {
        private static List<string> Names = new List<string>
        {
            "Banjo", "Coco", "Mango", "Simba", "Kiki", "Charlie", "Bubbles", "Oscar", "Lola", "Ziggy",
            "Aria", "Milo", "Peanut", "Bella", "Oliver", "Max", "Luna", "Leo", "Lucy", "Rocky",
            "Chloe", "Jack", "Zoe", "Ruby", "Tiger", "Cleo", "Rocco", "Sasha", "Daisy", "Jax",
            "Maddie", "Buddy", "Duke", "Ruby", "Rosie", "Mochi", "Simona", "Finn", "Zara", "Apollo",
            "Nala", "Zeus", "Lola", "Mia", "Winston", "Coco", "Ruby", "Louie", "Milo", "Mia"
        };

        public static string Generate(string chars = " .ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", int length = 20)
        {
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GetRandomName()
        {
            Random rand = new Random();
            return Names[rand.Next(0, Names.Count - 1)];
        }
    }
}
