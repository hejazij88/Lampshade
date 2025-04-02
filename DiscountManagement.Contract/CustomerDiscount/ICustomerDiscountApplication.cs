using _0_Framework.Application;

namespace DiscountManagement.Contract.CustomerDiscount;

public interface ICustomerDiscountApplication
{
    OperationResult Define(DefineColleagueDiscount defineCustomerDiscount);

    OperationResult Edit(EditColleagueDiscount editCustomerDiscount);

    EditColleagueDiscount GedDetail(Guid id);

    List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel);
}