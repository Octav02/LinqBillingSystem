namespace BillingSystem.dtos;

public class BillDueDateDTO
{
    public string name { get; set; }
    public DateTime dueDate { get; set; }
    
    public override string ToString()
    {
        return $"Bill name: {name}, Due date: {dueDate}";
    }
}