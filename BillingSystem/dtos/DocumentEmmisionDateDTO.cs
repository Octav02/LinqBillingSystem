namespace BillingSystem.dtos;

public class DocumentEmmisionDateDTO
{
    public string name { get; set; }
    public DateTime emmisionDate { get; set; }

    public override string ToString()
    {
        return $"Document name: {name}, Emmision date: {emmisionDate}";
    }
}