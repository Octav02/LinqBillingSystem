namespace BillingSystem.models;

public class Purchase : Entity<string>
{
    public string product { get; set; }
    public int quantity { get; set; }
    public double price { get; set; }
    public Bill bill { get; set; }

    public override string ToString()
    {
        return $"Purchase : Id = {Id}, Product = {product}, Quantity = {quantity}, Price = {price}, Bill = {bill.Id}";
    }
}