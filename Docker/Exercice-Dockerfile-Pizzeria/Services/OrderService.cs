using Exercice03_PizzeriaOnLine.Models;
using Exercice03_PizzeriaOnLine.Services;

namespace Services;

public class OrderService : IOrderService
{
    public int DiscountRate => 30;

    public int VATRate => 20;

    public Dictionary<Pizza, int> Items { get; set; } = new Dictionary<Pizza, int>();

    public int Total => SubTotal - DiscountAmount;

    public int SubTotal => Items.Sum(i => i.Key.Price * i.Value);

    public int DiscountAmount => !hasDiscount ? 0 : (int)(SubTotal * ((double)DiscountRate / 100));

    public int VATSubTotal => (int)Math.Round((SubTotal - DiscountAmount) * ((double)VATRate / 100), 0);

    public int PizzasCount => Items.Values.Sum();

    public bool IsEmpty { get => Items.Count == 0; }

    public bool hasDiscount { get => PizzasCount >= 3; }

    public void AddPizza(Pizza pizza)
    {
        if (Items.ContainsKey(pizza))
            Items[pizza]++;
        else
            Items.Add(pizza, 1);
    }

    public void RemovePizza(Pizza pizza)
    {
        if (Items[pizza] == 1)
            Items.Remove(pizza);
        else
            Items[pizza]--;
    }

    public void Empty()
    {
        Items.Clear();
    }
}
