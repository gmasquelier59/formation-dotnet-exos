using Exercice03_PizzeriaOnLine.Models;

namespace Exercice03_PizzeriaOnLine.Services;

public interface IOrderService
{
    public int DiscountRate { get; }
    public int DiscountAmount { get; }
    public bool hasDiscount { get; }
    public bool IsEmpty { get; }
    public Dictionary<Pizza, int> Items { get; set; }
    public int PizzasCount { get; }
    public int SubTotal { get; }
    public int Total { get; }
    public int VATRate { get; }
    public int VATSubTotal { get; }

    public void AddPizza(Pizza pizza);
    public void Empty();
    public void RemovePizza(Pizza pizza);
}