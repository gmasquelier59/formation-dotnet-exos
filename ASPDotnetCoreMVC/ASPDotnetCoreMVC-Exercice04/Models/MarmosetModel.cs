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
            Name = StringGenerator.Generate();
            Description = StringGenerator.Generate(length: 500);
        }
    }
}
