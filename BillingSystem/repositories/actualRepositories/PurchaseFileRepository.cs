using BillingSystem.models;
using BillingSystem.utils.mappers;

namespace BillingSystem.repositories;

public class PurchaseFileRepository : AbstractFileRepository<string, Purchase>
{
    public PurchaseFileRepository(string fileName, CreateEntity<Purchase> createEntity) : base(fileName, createEntity)
    {
        loadFromFile();
    }

    private new void loadFromFile()
    {
        var documents = DataReader.ReadData("../../../data/documents.txt", EntityToFileMapping.CreateDocument);

        var bills = DataReader.ReadData("../../../data/bills.txt", EntityToFileMapping.CreateBill);

        var purchases = DataReader.ReadData(_fileName, EntityToFileMapping.CreatePurchase);

        purchases.ForEach(purchase =>
        {
            purchase.bill = bills.Find(bill => bill.Id == purchase.bill.Id)!;
            purchase.bill.name = documents.Find(document => document.Id == purchase.bill.Id)!.name;
            _entities[purchase.Id] = purchase;
        });
    }
}