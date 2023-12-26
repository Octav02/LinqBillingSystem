using BillingSystem.dtos;
using BillingSystem.models;
using BillingSystem.repositories;
using BillingSystem.utils.enums;

namespace BillingSystem.services;

public class PurchaseService
{
    private readonly IRepository<string, Purchase> _purchaseRepository;

    public PurchaseService(IRepository<string, Purchase> purchaseRepository)
    {
        _purchaseRepository = purchaseRepository;
    }

    public List<Purchase> GetAllPurchases()
    {
        return _purchaseRepository.FindAll().ToList();
    }

    public List<PurchaseBillNameDTO> getAllPurchasesInCategory(string utilities)
    {
        return _purchaseRepository.FindAll().Where(purchase => purchase.bill.category == BillCategory.Utilities)
            .Select(purchase => new PurchaseBillNameDTO
            {
                product = purchase.product,
                billName = purchase.bill.name
            }).ToList();
    }
}