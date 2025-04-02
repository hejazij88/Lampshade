using _0_Framework.Application;

namespace DiscountManagement.Contract.ColleagueDiscount;

public interface IColleagueDiscountApplication
{
    OperationResult Define(DefineColleagueDiscount colleagueDiscount);

    OperationResult Edit(EditColleagueDiscount colleagueDiscount);

    OperationResult Remove(Guid Id);
    OperationResult Restore(Guid Id);

    EditColleagueDiscount GetDetail(Guid Id);

    List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel);

}