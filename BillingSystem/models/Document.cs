namespace BillingSystem.models;

public class Document : Entity<string>
{
    public string name { get; set; }
    public DateTime emmisionDate { get; set; }

    public override string ToString()
    {
        return $"Document : Id = {Id}, Name = {name}, EmmisionDate = {emmisionDate}";
    }
}