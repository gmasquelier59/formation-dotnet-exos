namespace Exercice03_PizzeriaOnLine.Models;

public class Pizza
{
    public int Id { get; set; } = 0;
    public string Name { get; set; } = "";
    public int Price { get; set; } = 1;
    public string ImageLink { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/c/c8/Pizza_Margherita_stu_spivack.jpg";
    public bool IsMostOrdered { get; set; } = false;

    public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    public override string ToString()
    {
        return $"{Id} {Name} {Price} {ImageLink} {IsMostOrdered}";
    }
}
