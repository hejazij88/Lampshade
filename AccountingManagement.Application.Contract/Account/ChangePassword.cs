namespace AccountingManagement.Application.Contract.Account
{
    public class ChangePassword
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }
}
