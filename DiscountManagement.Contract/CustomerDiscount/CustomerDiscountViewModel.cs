﻿namespace DiscountManagement.Contract.CustomerDiscount;

public class ColleagueDiscountViewModel:DefineColleagueDiscount
{
    public Guid Id { get; set; }
    public string Product { get; set; }
    public DateTime StartDateGre { get; set; }
    public DateTime EndDateGre { get; set; }

    public string CreateDate { get; set; }

}