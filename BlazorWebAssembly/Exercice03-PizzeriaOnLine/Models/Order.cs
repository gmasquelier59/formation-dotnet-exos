namespace Exercice03_PizzeriaOnLine.Models;

public class Order
{
    public Dictionary<Pizza, int> Items { get; set; }

    public Order()
    {
        Items = new Dictionary<Pizza, int>();
    }

    public int Total
    {
        get {
            return SubTotal - DiscountAmount;
        }
    }

    public int SubTotal
    {
        get
        {
            int subTotal = 0;
            foreach (KeyValuePair<Pizza, int> entry in Items)
                subTotal += entry.Key.Price * entry.Value;
            return subTotal;
        }
    }

    public int Discount
    {
        get => 30;
    }

    public int DiscountAmount
    {
        get
        {
            if (!hasDiscount)
                return 0;

            return (int)(SubTotal * ((double)Discount / 100));
        }
    }

    public int VAT
    {
        get => 20;
    }

    public int VATSubTotal
    {
        get
        {
            return (int)Math.Round((double)(SubTotal - DiscountAmount) * ((double)VAT / 100), 0);
        }
    }

    public int ItemsCount
    {
        get
        {
            return Items.Values.Sum();
        }
    }

    public bool IsEmpty { get => Items.Count == 0; }

    public bool hasDiscount { get => ItemsCount >= 3; }

    public void AddItem(Pizza pizza)
    {
        if (Items.ContainsKey(pizza))
        {
            Items[pizza]++;
            return;
        }
        Items.Add(pizza, 1);
    }

    public void RemoveItem(Pizza pizza)
    {
        Items.Remove(pizza);
    }

    public void Empty()
    {
        Items.Clear();
    }
}
