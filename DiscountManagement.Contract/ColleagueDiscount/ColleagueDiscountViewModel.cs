namespace DiscountManagement.Contract.ColleagueDiscount;

public class ColleagueDiscountViewModel:DefineColleagueDiscount
{
    public Guid Id { get; set; }
    public string Product { get; set; }
    public string CreateDate { get; set; }
    public bool IsRemove { get; set; }

}