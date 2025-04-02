using _0_Framework.Domain;
using DiscountManagement.Contract.ColleagueDiscount;

namespace DiscountManagement.Domain.ColleagueDiscountAgg;

public interface IColleagueDiscountRepository:IRepository<Guid,ColleagueDiscount>
{
    public EditColleagueDiscount GetDetail(Guid id);

    public List<ColleagueDiscountViewModel> SeaModel(ColleagueDiscountSearchModel searchModel);
}