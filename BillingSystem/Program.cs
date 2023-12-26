using BillingSystem.models;
using BillingSystem.repositories;
using BillingSystem.services;
using BillingSystem.ui;
using BillingSystem.utils.mappers;

namespace BillingSystem;

internal class Program
{
    private static void Main(string[] args)
    {
        IRepository<string, Bill> billFileRepository =
            new BillFileRepository("../../../data/bills.txt", EntityToFileMapping.CreateBill);
        IRepository<string, Document> documentFileRepository =
            new DocumentFileRepository("../../../data/documents.txt", EntityToFileMapping.CreateDocument);
        IRepository<string, Purchase> purchaseFileRepository =
            new PurchaseFileRepository("../../../data/purchases.txt", EntityToFileMapping.CreatePurchase);


        var billService = new BillService(billFileRepository);

        var documentService = new DocumentService(documentFileRepository);

        var purchaseService = new PurchaseService(purchaseFileRepository);


        var ui = new UI(documentService, billService, purchaseService);

        ui.runUI();
    }
}