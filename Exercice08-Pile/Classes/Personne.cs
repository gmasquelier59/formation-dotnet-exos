using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice08_Pile.Classes
{
    internal class Personne
    {
        public string Lastname {  get; set; }
        public string Firstname { get; set; }
        public int Age { get; set; }

        public Personne(string lastname, string firstname, int age)
        {
            Lastname = lastname;
            Firstname = firstname;
            Age = age;
        }

        public override string ToString()
        {
            return $"{Firstname} {Lastname}, {Age} years old";
        }
    }
}
