using _0_Framework.Application;

namespace AccountingManagement.Application.Contract.Account
{
    public interface IAccountApplication
    {
        AccountViewModel GetAccountBy(Guid id);
        OperationResult Register(RegisterAccount command);
        OperationResult Edit(EditAccount command);
        OperationResult ChangePassword(ChangePassword command);
        OperationResult Login(Login command);
        EditAccount GetDetails(Guid id);
        List<AccountViewModel> Search(AccountSearchModel searchModel);
        void Logout();
        List<AccountViewModel> GetAccounts();
    }
}
