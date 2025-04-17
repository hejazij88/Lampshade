namespace AccountingManagement.Application.Contract.Account
{
    public class AccountViewModel
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Mobile { get; set; }
        public Guid RoleId { get; set; }
        public string Role { get; set; }
        public string ProfilePhoto { get; set; }
        public string CreationDate { get; set; }
    }
}
