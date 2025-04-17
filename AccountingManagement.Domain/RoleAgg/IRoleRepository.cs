using _0_Framework.Domain;
using AccountingManagement.Application.Contract.Role;

namespace AccountingManagement.Domain.RoleAgg
{
    public interface IRoleRepository : IRepository<Guid, Role>
    {
        List<RoleViewModel> List();
        EditRole GetDetails(Guid id);
    }
}
