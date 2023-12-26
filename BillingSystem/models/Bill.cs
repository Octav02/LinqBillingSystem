using BillingSystem.utils.enums;

namespace BillingSystem.models;

public class Bill : Document
{
    public DateTime dueDate { get; set; }
    public List<Purchase> purchases { get; set; }
    public BillCategory category { get; set; }

    public override string ToString()
    {
        return
            $"Bill : Id = {Id}, Name = {name}, EmmisionDate = {emmisionDate}, DueDate = {dueDate}, Category = {category}, Purchases = {purchases.Count}";
    }
}