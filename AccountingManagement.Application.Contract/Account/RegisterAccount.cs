using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using AccountingManagement.Application.Contract.Role;
using Microsoft.AspNetCore.Http;

namespace AccountingManagement.Application.Contract.Account
{
    public class RegisterAccount
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Fullname { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Username { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Password { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Mobile { get; set; }

        public Guid RoleId { get; set; }

        public IFormFile ProfilePhoto { get; set; }
        public List<RoleViewModel> Roles { get; set; }
    }
}
