﻿namespace AccountingManagement.Application.Contract.Account
{
    public class AccountSearchModel
    {
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Mobile { get; set; }
        public Guid RoleId { get; set; }
    }
}
