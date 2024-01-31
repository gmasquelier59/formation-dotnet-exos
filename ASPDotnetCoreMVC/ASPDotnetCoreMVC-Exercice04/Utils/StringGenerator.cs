namespace ASPDotnetCoreMVC_Exercice04.Utils
{
    public class StringGenerator
    {
        public static string Generate(string chars = " .ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", int length = 20)
        {
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
