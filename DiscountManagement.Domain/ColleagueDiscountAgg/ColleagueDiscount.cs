using _0_Framework.Domain;

namespace DiscountManagement.Domain.ColleagueDiscountAgg;

public class ColleagueDiscount:EntityBase
{
    public Guid ProductId { get; set; }

    public int DiscountRate { get; set; }

    public bool IsRemove { get; set; }

    public ColleagueDiscount(Guid productId,int discountRate)
    {
        ProductId=productId;
        DiscountRate=discountRate;
    }

    public void Edit(Guid productId, int discountRate)
    {
        ProductId = productId;
        DiscountRate = discountRate;
    }

    public void Remove()
    {
        IsRemove=true;
    }

    public void Restore()
    {
        IsRemove=false;
    }

}