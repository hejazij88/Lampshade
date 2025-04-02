namespace DiscountManagement.Contract.CustomerDiscount;

public class DefineCustomerDiscount
{
    public Guid ProductId { get; set; }
    public string Reasen { get; set; }
    public int DiscountRate { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
}