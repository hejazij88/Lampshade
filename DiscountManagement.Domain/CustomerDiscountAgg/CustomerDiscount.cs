using _0_Framework.Domain;

namespace DiscountManagement.Domain.CustomerDiscountAgg;

public class CustomerDiscount : EntityBase
{
    public Guid ProductId { get; set; }
    public string Reasen { get; set; }
    public int DiscountRate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public CustomerDiscount(Guid productId, string reasen, int discountRate, DateTime startDate, DateTime endDate)
    {
        ProductId = productId;
        Reasen = reasen;
        DiscountRate = discountRate;
        StartDate = startDate;
        EndDate = endDate;
    }


    public void Edit(Guid productId, string reasen, int discountRate, DateTime startDate, DateTime endDate)
    {
        ProductId = productId;
        Reasen = reasen;
        DiscountRate = discountRate;
        StartDate = startDate;
        EndDate = endDate;

    }
}