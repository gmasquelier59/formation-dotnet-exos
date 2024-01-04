using XmasTree;

internal class Program
{
    private static void Main(string[] args)
    {
        int treeHeight;

        Console.Title = "Xmas Tree !";

        do
        {
            Console.Write("Quelle doit être la hauteur du sapin ? (entier compris entre 1 et 30) : ");
        } while (!int.TryParse(Console.ReadLine(), out treeHeight) || treeHeight < 1 || treeHeight > 30);

        Tree tree = new Tree(treeHeight);
        tree.Draw();
    }
}