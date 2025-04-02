using _0_Framework.Application;
using _0_Framework.Domain;
using _0_Framework.Infrastructure;
using DiscountManagement.Contract.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EFCore;

namespace DiscountManager.Infrastructure.EFCore.Repository;

public class ColleagueDiscountRepository:RepositoryBase<Guid,ColleagueDiscount>, IColleagueDiscountRepository
{
    private readonly DiscountContext _discountContext;
    private readonly ShopContext _shopContext;

    public ColleagueDiscountRepository(DiscountContext context,ShopContext shopContext) : base(context)
    {
        _discountContext = context;
        _shopContext = shopContext;
    }

    public EditColleagueDiscount GetDetail(Guid id) => _discountContext.ColleagueDiscounts
        .Select(cd => new EditColleagueDiscount { Id = cd.Id,DiscountRate = cd.DiscountRate,ProductId = cd.ProductId}).FirstOrDefault(cd => cd.Id == id);

    public List<ColleagueDiscountViewModel> SeaModel(ColleagueDiscountSearchModel searchModel)
    {
        var products = _shopContext.Products.Select(p=>new {p.Id,p.Name}).ToList();
        var query = _discountContext.ColleagueDiscounts.Select(cd => new ColleagueDiscountViewModel
        {
            ProductId = cd.ProductId,
            Id = cd.Id,
            DiscountRate = cd.DiscountRate,
            CreateDate = cd.CreationDate.ToFarsi(),
            IsRemove = cd.IsRemove
        });
        if (searchModel.ProductId!=Guid.Empty)
            query.Where(q => q.ProductId == searchModel.ProductId);

        var discounts = query.OrderByDescending(q=>q.CreateDate).ToList();

        discounts.ForEach(d=>d.Product=products.FirstOrDefault(p=>p.Id==searchModel.ProductId)?.Name);
        return discounts;

    }
}