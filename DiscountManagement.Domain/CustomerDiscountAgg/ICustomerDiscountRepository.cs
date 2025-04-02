using _0_Framework.Domain;
using DiscountManagement.Contract.CustomerDiscount;

namespace DiscountManagement.Domain.CustomerDiscountAgg;

public interface ICustomerDiscountRepository:IRepository<Guid,CustomerDiscount>
{
    EditCustomerDiscount GedDetail(Guid Id);

    List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel);
}