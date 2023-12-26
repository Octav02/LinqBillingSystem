using BillingSystem.dtos;
using BillingSystem.models;
using BillingSystem.repositories;
using BillingSystem.utils.enums;

namespace BillingSystem.services;

public class BillService
{
    private readonly IRepository<string, Bill> _billRepository;

    public BillService(IRepository<string, Bill> billRepository)
    {
        _billRepository = billRepository;
    }

    public List<Bill> GetAllBills()
    {
        return _billRepository.FindAll().ToList();
    }

    public List<BillDueDateDTO> GetBillsDueToCurrentMonth()
    {
        return _billRepository.FindAll().Where(bill =>
                bill.dueDate.Month == DateTime.Now.Month && bill.dueDate.Year == DateTime.Now.Year)
            .Select(bill => new BillDueDateDTO
            {
                name = bill.name,
                dueDate = bill.dueDate
            }).ToList();
    }

    public List<BillProductsDTO> GetBillsWithAtLeast3ProductsPurchased()
    {
        return _billRepository.FindAll().Where(bill =>
        {
            return bill.purchases.Sum(purchase => purchase.quantity) >= 3;
        }).Select(bill => new BillProductsDTO
        {
            name = bill.name,
            numberOfProducts = bill.purchases.Sum(purchase => purchase.quantity)
        }).ToList();
    }

    public BillCategory GetCategoryWithHighestTotalAmountOfMoneySpent()
    {
        BillCategory category = _billRepository.FindAll().GroupBy(bill => bill.category)
            .Select(group => new
            {
                category = group.Key,
                totalAmount = group.Sum(bill => bill.purchases.Sum(purchase => purchase.price * purchase.quantity))
            }).OrderByDescending(group => group.totalAmount).First().category;
        return category;
    }
}