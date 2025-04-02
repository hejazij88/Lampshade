namespace DiscountManagement.Contract.CustomerDiscount;

public class CustomerDiscountViewModel:DefineCustomerDiscount
{
    public Guid Id { get; set; }
    public string Product { get; set; }
    public DateTime StartDateGre { get; set; }
    public DateTime EndDateGre { get; set; }

}