using BillingSystem.services;

namespace BillingSystem.ui;

public class UI
{
    private readonly BillService _billService;
    private readonly DocumentService _documentService;

    private readonly PurchaseService _purchaseService;


    public UI(DocumentService documentService, BillService billService, PurchaseService purchaseService)
    {
        _documentService = documentService;
        _billService = billService;
        _purchaseService = purchaseService;
    }

    public void runUI()
    {
        while (true)
        {
            PrintMenu();
            var option = ReadOption();
            switch (option)
            {
                case 1:
                    PrintAllDocuments();
                    break;
                case 2:
                    PrintAllBills();
                    break;
                case 3:
                    PrintAllPurchases();
                    break;
                case 4:
                    RunTask1();
                    break;
                case 5:
                    RunTask2();
                    break;
                case 6:
                    RunTask3();
                    break;
                case 7:
                    RunTask4();
                    break;
                case 8:
                    RunTask5();
                    break;
                case 0:
                    return;
            }
        }
    }

    private void RunTask5()
    {
        //Billing category with the highest total amount of money spent
        Console.WriteLine(_billService.GetCategoryWithHighestTotalAmountOfMoneySpent());
    }

    private void RunTask4()
    {
        //All the purchases in Category Utilities
        _purchaseService.getAllPurchasesInCategory("Utilities").ForEach(Console.WriteLine);
    }

    private void RunTask3()
    {
        //Bills that have at least 3 products purchased (considering no of products from purchase)
        _billService.GetBillsWithAtLeast3ProductsPurchased().ForEach(Console.WriteLine);
    }

    private void RunTask2()
    {
        //All bills that are due to current month
        _billService.GetBillsDueToCurrentMonth().ForEach(Console.WriteLine);
    }

    private void RunTask1()
    {
        //All Documents that have been issued in 2023
        _documentService.getDocumentIssuedInYear(2023).ForEach(Console.WriteLine);
    }

    private void PrintAllPurchases()
    {
        _purchaseService.GetAllPurchases().ForEach(Console.WriteLine);
    }

    private void PrintAllBills()
    {
        _billService.GetAllBills().ForEach(Console.WriteLine);
    }

    private void PrintAllDocuments()
    {
        _documentService.GetAllDocuments().ForEach(Console.WriteLine);
    }

    private int ReadOption()
    {
        Console.WriteLine("Enter option: ");
        return Convert.ToInt32(Console.ReadLine());
    }

    private void PrintMenu()
    {
        Console.WriteLine("0. Exit");
        Console.WriteLine("1. Print all documents");
        Console.WriteLine("2. Print all bills");
        Console.WriteLine("3. Print all purchases");
        Console.WriteLine("4. Task 1");
        Console.WriteLine("5. Task 2");
        Console.WriteLine("6. Task 3");
        Console.WriteLine("7. Task 4");
        Console.WriteLine("8. Task 5");
    }
}