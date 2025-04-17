using _0_Framework.Infrastructure;

namespace AccountingManagement.Application.Contract.Role
{
    public class EditRole : CreateRole
    {
        public Guid Id { get; set; }
        public List<PermissionDto> MappedPermissions { get; set; }

        public EditRole()
        {
            Permissions = new List<int>();
        }
    }
}