using ShopManagement.Application.Contracts.Product;

namespace DiscountManagement.Contract.ColleagueDiscount;

public class DefineColleagueDiscount
{
    public Guid ProductId { get; set; }
    public int DiscountRate { get; set; }
    public List<ProductViewModel> Products { get; set; }
}