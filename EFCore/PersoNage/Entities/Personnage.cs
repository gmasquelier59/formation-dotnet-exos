using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using System.Runtime.InteropServices;

namespace PersoNage.Entities
{
    internal class Personnage
    {
        #region PROPRIETES
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public DateTime DateCreation { get; set; } = DateTime.Now;
        [Column(TypeName = "VARCHAR")]
        [MaxLength(50)]
        [Required]
        
        public string Pseudo { get; set; }
        [Required]
        
        public int PointsVie { get; set; } = 0;
        [Required]
        
        public int PointsArmure { get; set; } = 0;
        [Required]
        
        public int Degats { get; set; } = 0;
        [Required]
        
        public int NombrePersonnagesTues { get; set; } = 0;
        #endregion

        public void Attaquer(Personnage personnage)
        {
            string descriptionAttaque = "";

            if (personnage.PointsArmure >= Degats)
            {
                descriptionAttaque += $"{personnage.Pseudo} n'a pas perdu de points de vie, son armure est forte !";
            }
            else
            {
                int degatsReels = Degats - personnage.PointsArmure;
                personnage.PointsVie -= degatsReels;
                if (personnage.PointsVie <= 0)
                {
                    personnage.PointsVie = 0;
                    NombrePersonnagesTues++;
                }
                descriptionAttaque += $"[red]{Pseudo} fait perdre {degatsReels} points de dégats[/] à {personnage.Pseudo}";
                if (personnage.PointsVie > 0)
                    descriptionAttaque += $", il lui reste [green]{personnage.PointsVie}[/] points de vie";
                else
                    descriptionAttaque += $", [red]il l'a tué ![/]";
            }

            var panel = new Panel(descriptionAttaque);

            panel.Padding = new Padding(1);
            panel.BorderColor(Color.Yellow);
            panel.Header = new PanelHeader($"⚔️ [yellow]{Pseudo} attaque {personnage.Pseudo}...[/]");
            AnsiConsole.Write(panel);
            Console.WriteLine();
        }

        public void Afficher()
        {
            if (PointsVie == 0)
            {
                var panel = new Panel($"[red]💀 {Pseudo} est dead ![/]");
                panel.Padding = new Padding(1);
                panel.Header = new PanelHeader($"[red bold underline]{Pseudo}[/]");

                AnsiConsole.Write(panel);
            }
            else
            {
                BarChart chart = new BarChart();

                chart.Width(60)
                    .LeftAlignLabel()
                    .AddItem(PointsVie > 40 ? "💓 Points de vie" : "[blink]💓 Points de vie[/]", PointsVie, PointsVie > 40 ? Color.Green : PointsVie > 20 ? Color.Orange1 : Color.Red)
                    .AddItem("🛡️ Armure", PointsArmure, Color.DarkSlateGray1)
                    .AddItem("🗡️ Degats", Degats, Color.Red)
                    .AddItem("☠️ Personnages tués", NombrePersonnagesTues, Color.Red);
                chart.MaxValue = 100;

                var panel = new Panel(chart);
                panel.Padding = new Padding(1);
                panel.Header = new PanelHeader($"[green bold underline]{Pseudo}[/]");

                AnsiConsole.Write(panel);
            }
        }
    }
}
