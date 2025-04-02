using _0_Framework.Application;
using DiscountManagement.Contract.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;

namespace DiscountManager.Application;

public class CustomerDiscountApplication:ICustomerDiscountApplication
{
    private readonly ICustomerDiscountRepository _customerDiscountRepository;

    public CustomerDiscountApplication(ICustomerDiscountRepository customerDiscountRepository)
    {
        _customerDiscountRepository = customerDiscountRepository;
    }
    public OperationResult Define(DefineColleagueDiscount defineCustomerDiscount)
    {
        var operation = new OperationResult();

        var startdDate = defineCustomerDiscount.StartDate.ToGeorgianDateTime();
        var enddDate = defineCustomerDiscount.StartDate.ToGeorgianDateTime();

        var data = new CustomerDiscount(defineCustomerDiscount.ProductId,defineCustomerDiscount.Reasen,defineCustomerDiscount.DiscountRate,startdDate,enddDate);
        _customerDiscountRepository.Create(data);
        _customerDiscountRepository.SaveChanges();
        return operation.Succedded();
    }

    public OperationResult Edit(EditColleagueDiscount editCustomerDiscount)
    {
        var operation = new OperationResult();

        var customerDiscount = _customerDiscountRepository.Get(editCustomerDiscount.Id);

        if (customerDiscount == null)
            return operation.Failed(ApplicationMessages.RecordNotFound);

        var startdDate = editCustomerDiscount.StartDate.ToGeorgianDateTime();
        var enddDate = editCustomerDiscount.StartDate.ToGeorgianDateTime();

        customerDiscount.Edit(editCustomerDiscount.Id,editCustomerDiscount.Reasen,editCustomerDiscount.DiscountRate,startdDate,enddDate);
        _customerDiscountRepository.SaveChanges();
        return operation.Succedded();
    }

    public EditColleagueDiscount GedDetail(Guid id) => _customerDiscountRepository.GedDetail(id);


    public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel) =>
        _customerDiscountRepository.Search(searchModel);
}