using Exercice02_FormulairePersonne.Models;
using Microsoft.AspNetCore.Components;

namespace Exercice02_FormulairePersonne.Pages
{
    public class FicheBase : ComponentBase
    {
        public Person Person {  get; set; }
        public bool ShowCard {  get; set; }

        protected override async Task OnInitializedAsync()
        {
            Person = new Person();
            Person.LastName = "MASQUELIER";
            Person.Birthday = new DateTime(1981, 1, 23);
        }
    }
}
