using BillingSystem.models;
using BillingSystem.utils.enums;

namespace BillingSystem.utils.mappers;

public class EntityToFileMapping
{
    public static Document CreateDocument(string line)
    {
        var fields = line.Split(",");
        Document document = new()
        {
            Id = fields[0],
            name = fields[1],
            emmisionDate = DateTime.ParseExact(fields[2].Trim(), "yyyy-MM-dd", null)
        };
        return document;
    }

    public static Bill CreateBill(string line)
    {
        var fields = line.Split(",");
        Bill bill = new()
        {
            Id = fields[0],
            dueDate = DateTime.ParseExact(fields[1].Trim(), "yyyy-MM-dd", null),
            category = (BillCategory)Enum.Parse(typeof(BillCategory), fields[2])
        };
        return bill;
    }

    public static Purchase CreatePurchase(string line)
    {
        var fields = line.Split(",");
        Purchase purchase = new()
        {
            Id = fields[0],
            product = fields[1],
            quantity = int.Parse(fields[2]),
            price = double.Parse(fields[3]),
            bill = new Bill { Id = fields[4] }
        };
        return purchase;
    }
}