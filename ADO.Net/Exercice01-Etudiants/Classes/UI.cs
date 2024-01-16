using Microsoft.Data.SqlClient;
using System.Data;
using Spectre.Console;
using System.Text;

namespace Exercice01_Etudiants.Classes
{
    internal static class UI
    {
        public static void Start()
        {
            string[] menu =
        {
            "Ajouter un(e) étudiant(e)",
            "Modifier un(e) étudiant(e)",
            "Supprimer un(e) étudiant(e)",
            "Supprimer tous les étudiants",
            "Afficher la liste des étudiants",
            "Quitter"
        };

            while (true)
            {

                var choix = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Que souhaitez-vous faire avec les étudiant(e)s ?")
                        .AddChoices(menu)
                );

                switch (Array.IndexOf(menu, choix))
                {
                    case 0:
                        CreateStudent();
                        break;
                    case 1:
                        UpdateStudent();
                        break;
                    case 2:
                        DeleteStudent();
                        break;
                    case 3:
                        DeleteAllStudents();
                        break;
                    case 4:
                        ShowStudents();
                        break;
                    case 5:
                        return;
                }

                AnsiConsole.WriteLine("");
                AnsiConsole.WriteLine("Appuyez sur une touche pour continuer...");
                Console.ReadKey();
                AnsiConsole.Clear();
            }
        }

        private static void UpdateStudent()
        {
            AnsiConsole.MarkupLine("[yellow]Mettre à jour un(e) étudiant(e)[/]");
            AnsiConsole.WriteLine();

            using (SqlConnection connection = DbContext.GetConnection())
            {
                List<string> menu = new List<string>();

                string query = "SELECT * FROM etudiants ORDER BY nom, prenom";
                SqlDataReader reader = new SqlCommand(query, connection).ExecuteReader();
                while (reader.Read())
                    menu.Add($"{reader.GetGuid("id").ToString()} {reader.GetString("nom")} {reader.GetString("prenom")}");
                reader.Close();

                if (menu.Count == 0)
                {
                    AnsiConsole.MarkupLine("[yellow]Il n'y a aucun étudiant actuellement ![/]");
                    return;
                }

                menu.Add("Retour");
                int choice = Array.IndexOf(menu.ToArray(), AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Sélectionnez l'étudiant à modifier :")
                        .AddChoices(menu)
                ));

                if (choice == menu.Count)
                    return;

                string studentId = menu[choice].Split(" ")[0];

                Student student = Student.GetById(new Guid(studentId));

                string name = AnsiConsole.Ask<string>("[green]Nom[/] de l'étudiant ?", student.Name);
                string firstname = AnsiConsole.Ask<string>("[green]Prénom[/] de l'étudiant ?", student.Firstname);
                int classroom = AnsiConsole.Ask<int>("[green]Numéro de classe[/] de l'étudiant (compris entre 1 et 10) ?", student.Classroom);
                string graduationDate = AnsiConsole.Ask("[green]Date de diplôme[/] de l'étudiant (format JJ/MM/AAAA, vide si non diplômé) ?", student.GraduationDate.ToString("dd/MM/yyyy"));

                try
                {
                    student.Name = name;
                    student.Firstname = firstname;
                    student.Classroom = classroom;
                    student.GraduationDate = string.IsNullOrEmpty(graduationDate) ? DateOnly.MinValue : DateOnly.Parse(graduationDate);
                    student.Update();
                    AnsiConsole.WriteLine();
                    AnsiConsole.MarkupLine("[green]L'étudiant(e) a bien été modifié(e) ![/]");
                }
                catch (Exception e)
                {
                    AnsiConsole.WriteLine();
                    AnsiConsole.Write(new Markup("[red]Impossible de créer l'étudiant(e) pour la raison suivante : " + e.Message + "[/]"));
                }
            }
        }

        private static void DeleteAllStudents()
        {
            AnsiConsole.MarkupLine("[red]Supprimer tous les étudiants[/]");
            AnsiConsole.WriteLine();

            string confirmation = AnsiConsole.Ask<string>($"[red]La suppression est irréversible, êtes-vous sûr(e) de vouloir supprimer tous les étudiants ?[/] [[y/N]]", "N");
            if (confirmation == "y")
            {
                try
                {
                    Student.DeleteAll();
                    AnsiConsole.WriteLine();
                    AnsiConsole.MarkupLine("[green]Tous les étudiants ont été supprimés ![/]");
                }
                catch (Exception e)
                {
                    AnsiConsole.WriteLine();
                    AnsiConsole.Write(new Markup("[red]Impossible de supprimer les étudiants pour la raison suivante : " + e.Message + "[/]"));
                }
            }
            else
                AnsiConsole.MarkupLine("[green]Aucun étudant n'a été supprimé[/]");
        }

        private static void DeleteStudent()
        {
            AnsiConsole.MarkupLine("[red]Supprimer un(e) étudiant(e)[/]");
            AnsiConsole.WriteLine();

            using (SqlConnection connection = DbContext.GetConnection())
            {
                List<string> menu = new List<string>();

                string query = "SELECT * FROM etudiants ORDER BY nom, prenom";
                SqlDataReader reader = new SqlCommand(query, connection).ExecuteReader();
                while (reader.Read())
                    menu.Add($"{reader.GetGuid("id").ToString()} {reader.GetString("nom")} {reader.GetString("prenom")}");
                reader.Close();

                if (menu.Count == 0)
                {
                    AnsiConsole.MarkupLine("[yellow]Il n'y a aucun étudiant actuellement ![/]");
                    return;
                }

                menu.Add("Retour");
                int choice = Array.IndexOf(menu.ToArray(), AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Sélectionnez l'étudiant à supprimer :")
                        .AddChoices(menu)
                ));

                if (choice == menu.Count)
                    return;

                string studentId = menu[choice].Split(" ")[0];

                string confirmation = AnsiConsole.Ask<string>($"[red]La suppression est irréversible, êtes-vous sûr(e) de vouloir supprimer l'étudiant(e) {studentId} ?[/] [[y/N]]", "N");
                if (confirmation == "y")
                {
                    try
                    {
                        Student.DeleteById(studentId);
                        AnsiConsole.WriteLine();
                        AnsiConsole.MarkupLine("[green]L'étudiant(e) a bien été supprimé(e) ![/]");
                    }
                    catch (Exception e)
                    {
                        AnsiConsole.WriteLine();
                        AnsiConsole.Write(new Markup("[red]Impossible de supprimer l'étudiant(e) pour la raison suivante : " + e.Message + "[/]"));
                    }
                }
                else
                    AnsiConsole.MarkupLine("[green]L'étudiant(e) n'a pas été supprimé(e)[/]");
            }
        }

        private static void ShowStudents()
        {
            AnsiConsole.MarkupLine("[blue]Liste des étudiant(e)s[/]");
            AnsiConsole.WriteLine();

            var table = new Table();
            table.AddColumn("Identifiant");
            table.AddColumn("Nom");
            table.AddColumn("Prénom");
            table.AddColumn("Classe");
            table.AddColumn("Date du diplôme");

            List<Student> students = Student.All();

            AnsiConsole.MarkupLine($"[yellow]{students.Count} étudiant(s)[/]");
            AnsiConsole.WriteLine();

            foreach (Student student in students)
            {
                table.AddRow(new string[] {
                student.Id.ToString(),
                student.Name,
                student.Firstname,
                student.Classroom.ToString(),
                !student.GraduationDate.Equals(DateOnly.MinValue) ? student.GraduationDate.ToString("dd/MM/yyyy") : ""
            });
            }

            AnsiConsole.Write(table);
        }

        private static void CreateStudent()
        {
            AnsiConsole.MarkupLine("[blue]Ajouter un(e) étudiant(e)[/]");
            AnsiConsole.WriteLine();

            using (SqlConnection connection = DbContext.GetConnection())
            {
                string name = AnsiConsole.Ask<string>("[green]Nom[/] de l'étudiant ?");
                string firstname = AnsiConsole.Ask<string>("[green]Prénom[/] de l'étudiant ?");
                int classroom = AnsiConsole.Ask<int>("[green]Numéro de classe[/] de l'étudiant (compris entre 1 et 10) ?");
                string graduationDate = AnsiConsole.Ask("[green]Date de diplôme[/] de l'étudiant (format JJ/MM/AAAA, vide si non diplômé) ?", "");

                try
                {
                    Student student = new Student(name, firstname, classroom, string.IsNullOrEmpty(graduationDate) ? DateOnly.MinValue : DateOnly.Parse(graduationDate));
                    student.Save();
                    AnsiConsole.WriteLine();
                    AnsiConsole.Write(new Markup("[green]Etudiant(e) créé(e) avec succès ![/]"));
                }
                catch (Exception e)
                {
                    AnsiConsole.WriteLine();
                    AnsiConsole.Write(new Markup("[red]Impossible de créer l'étudiant(e) pour la raison suivante : " + e.Message + "[/]"));
                }
            }
        }
    }
}