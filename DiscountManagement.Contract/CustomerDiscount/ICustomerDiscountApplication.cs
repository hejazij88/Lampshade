using _0_Framework.Application;

namespace DiscountManagement.Contract.CustomerDiscount;

public interface ICustomerDiscountApplication
{
    OperationResult Define(DefineCustomerDiscount defineCustomerDiscount);

    OperationResult Edit(EditCustomerDiscount editCustomerDiscount);

    EditCustomerDiscount GedDetail(Guid Id);

    List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel);
}