using _0_Framework.Domain;
using AccountingManagement.Application.Contract.Account;

namespace AccountingManagement.Domain.AccountAgg
{
    public interface IAccountRepository : IRepository<Guid, Account>
    {
        Account GetBy(string username);
        EditAccount GetDetails(Guid id);
        List<AccountViewModel> GetAccounts();
        List<AccountViewModel> Search(AccountSearchModel searchModel);
    }
}
