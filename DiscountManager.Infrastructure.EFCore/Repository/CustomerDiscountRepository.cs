using _0_Framework.Application;
using _0_Framework.Domain;
using _0_Framework.Infrastructure;
using DiscountManagement.Contract.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EFCore;

namespace DiscountManager.Infrastructure.EFCore.Repository;

public class CustomerDiscountRepository:RepositoryBase<Guid,CustomerDiscount>,ICustomerDiscountRepository
{

    private readonly DiscountContext _discountContext;
    private readonly ShopContext _shopContext;
    public CustomerDiscountRepository(DiscountContext context,ShopContext shopContext) : base(context)
    {
        _discountContext = context;
        _shopContext = shopContext;
    }

    public EditCustomerDiscount GedDetail(Guid Id) => _discountContext.CustomerDiscounts
        .Select(cd => new EditCustomerDiscount {Id = cd.Id,DiscountRate = cd.DiscountRate,EndDate = cd.EndDate.ToFarsi(),ProductId = cd.ProductId,Reasen = cd.Reasen,StartDate = cd.StartDate.ToFarsi()}).FirstOrDefault(cd => cd.Id == Id);

    public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
    {
        var products = _shopContext.Products.Select(p=>new  {p.Id,p.Name}).ToList();

        var query = _discountContext.CustomerDiscounts.Select(cd => new CustomerDiscountViewModel
        {
            Id=cd.Id,
            ProductId = cd.ProductId,
            Reasen = cd.Reasen,
            StartDate = cd.StartDate.ToFarsi(),
            EndDate = cd.EndDate.ToFarsi(),
            StartDateGre = cd.StartDate,
            EndDateGre = cd.EndDate,
            DiscountRate = cd.DiscountRate,
            CreateDate = cd.CreationDate.ToFarsi()
        });

        if (searchModel.ProductId != Guid.Empty)
            query = query.Where(q => q.ProductId == searchModel.ProductId);

        if (!string.IsNullOrWhiteSpace(searchModel.StartDate))
        {
            var startDate = searchModel.StartDate.ToGeorgianDateTime();
            query = query.Where(q => q.StartDateGre > startDate);

        }


        if (!string.IsNullOrWhiteSpace(searchModel.EndDate))
        {
            var endDate = searchModel.EndDate.ToGeorgianDateTime();
            query = query.Where(q => q.EndDateGre < endDate);

        }

        var discount = query.OrderByDescending(q => q.Id).ToList();

        discount.ForEach(d=>d.Product=products.FirstOrDefault(p=>p.Id==d.ProductId)?.Name);

        return discount;
    }
}