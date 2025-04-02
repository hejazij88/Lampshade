using _0_Framework.Domain;
using DiscountManagement.Contract.CustomerDiscount;

namespace DiscountManagement.Domain.CustomerDiscountAgg;

public interface ICustomerDiscountRepository:IRepository<Guid,CustomerDiscount>
{
    EditColleagueDiscount GedDetail(Guid Id);

    List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel);
}