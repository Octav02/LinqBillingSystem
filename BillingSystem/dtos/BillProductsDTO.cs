namespace BillingSystem.dtos;

public class BillProductsDTO
{
    public string name { get; set; }
    public int numberOfProducts { get; set; }

    public override string ToString()
    {
        return $"Bill name: {name}, Number of products: {numberOfProducts}";
    }
}