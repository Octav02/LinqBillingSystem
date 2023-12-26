using BillingSystem.models;
using BillingSystem.utils.mappers;

namespace BillingSystem.repositories;

public class BillFileRepository : AbstractFileRepository<string, Bill>
{
    public BillFileRepository(string fileName, CreateEntity<Bill> createEntity) : base(fileName, createEntity)
    {
        loadFromFile();
    }

    private new void loadFromFile()
    {
        var documents = DataReader.ReadData("../../../data/documents.txt", EntityToFileMapping.CreateDocument);

        var purchases = DataReader.ReadData("../../../data/purchases.txt", EntityToFileMapping.CreatePurchase);

        var bills = DataReader.ReadData(_fileName, EntityToFileMapping.CreateBill);


        bills.ForEach(bill =>
        {
            bill.emmisionDate = documents.Find(document => document.Id == bill.Id)!.emmisionDate;
            bill.name = documents.Find(document => document.Id == bill.Id)!.name;
            bill.purchases = purchases.FindAll(purchase => purchase.bill.Id == bill.Id);
            _entities[bill.Id] = bill;
        });
    }
}