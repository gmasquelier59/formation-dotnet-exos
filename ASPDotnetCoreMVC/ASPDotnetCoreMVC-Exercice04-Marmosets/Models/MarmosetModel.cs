using ASPDotnetCoreMVC_Exercice04.Utils;
using System.ComponentModel.DataAnnotations;

namespace ASPDotnetCoreMVC_Exercice04.Models
{
    public class MarmosetModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Photo { get; set; } = "";

        public string Description { get; set; } = "";

        public string Areas { get; set; } = "";

        public MarmosetModel()
        {
            Name = StringGenerator.GetRandomName();
            Description = StringGenerator.Generate(length: 500);

            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("https://loremflickr.com/500/500/monkey?random=" + new Random().Next(1, 100000), HttpCompletionOption.ResponseHeadersRead).Result;

            Photo = response.RequestMessage.RequestUri.ToString();
        }

        public static MarmosetModel New()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("https://loremflickr.com/500/500/monkey?random=" + new Random().Next(1, 100000), HttpCompletionOption.ResponseHeadersRead).Result;
            string photoUrl = response.RequestMessage.RequestUri.ToString();

            MarmosetModel marmoset = new MarmosetModel()
            {
                Name = StringGenerator.GetRandomName(),
                Description = StringGenerator.Generate(length: 500),
                Photo = photoUrl
            };

            return marmoset;
        }
    }
}
