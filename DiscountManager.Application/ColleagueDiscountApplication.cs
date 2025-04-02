using _0_Framework.Application;
using DiscountManagement.Contract.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using DiscountManagement.Domain.CustomerDiscountAgg;

namespace DiscountManager.Application;

public class ColleagueDiscountApplication:IColleagueDiscountApplication
{
    private readonly IColleagueDiscountRepository _colleagueDiscountRepository;

    public ColleagueDiscountApplication(IColleagueDiscountRepository colleagueDiscountRepository)
    {
        _colleagueDiscountRepository = colleagueDiscountRepository;
    }
    public OperationResult Define(DefineColleagueDiscount colleagueDiscount)
    {
        var operation = new OperationResult();

        if (_colleagueDiscountRepository.Exists(c =>
                c.ProductId == colleagueDiscount.ProductId && c.DiscountRate == colleagueDiscount.DiscountRate))
            return operation.Failed(ApplicationMessages.DuplicatedRecord);

        var data = new ColleagueDiscount(colleagueDiscount.ProductId, colleagueDiscount.DiscountRate);
        _colleagueDiscountRepository.Create(data);
        _colleagueDiscountRepository.SaveChanges();
        return operation.Succedded();
    }

    public OperationResult Edit(EditColleagueDiscount colleagueDiscount)
    {
        var operation = new OperationResult();

        var colleague = _colleagueDiscountRepository.Get(colleagueDiscount.Id);

        if (colleague == null)
            return operation.Failed(ApplicationMessages.RecordNotFound);

        if (_colleagueDiscountRepository.Exists(c =>
                c.ProductId == colleagueDiscount.ProductId && c.DiscountRate == colleagueDiscount.DiscountRate))
            return operation.Failed(ApplicationMessages.DuplicatedRecord);

        colleague.Edit(colleagueDiscount.ProductId,colleagueDiscount.DiscountRate);
        _colleagueDiscountRepository.SaveChanges();
        return operation.Succedded();
    }

    public OperationResult Remove(Guid Id)
    {
        var operation = new OperationResult();

        var colleague = _colleagueDiscountRepository.Get(Id);

        if (colleague == null)
            return operation.Failed(ApplicationMessages.RecordNotFound);

        colleague.Remove();
        _colleagueDiscountRepository.SaveChanges();
        return operation.Succedded();
    }

    public OperationResult Restore(Guid Id)
    {
        var operation = new OperationResult();

        var colleague = _colleagueDiscountRepository.Get(Id);

        if (colleague == null)
            return operation.Failed(ApplicationMessages.RecordNotFound);

        colleague.Restore();
        _colleagueDiscountRepository.SaveChanges();
        return operation.Succedded();
    }

    public EditColleagueDiscount GetDetail(Guid Id) => _colleagueDiscountRepository.GetDetail(Id);

    public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel) =>
        _colleagueDiscountRepository.SeaModel(searchModel);
}