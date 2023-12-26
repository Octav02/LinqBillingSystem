namespace BillingSystem.dtos;

public class PurchaseBillNameDTO
{
    public string product { get; set; }
    public string billName { get; set; }
    
    public override string ToString()
    {
        return $"Purchase : Product = {product}, BillName = {billName}";
    }
}