using AccountingManagement.Application;
using AccountingManagement.Application.Contract.Account;
using AccountingManagement.Application.Contract.Role;
using AccountingManagement.Domain.AccountAgg;
using AccountingManagement.Domain.RoleAgg;
using AccountMangement.Infrastructure.EFCore;
using AccountMangement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AccountManagement.Configuration
{
    public class AccountManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IAccountApplication, AccountApplication>();
            services.AddTransient<IAccountRepository, AccountRepository>();

            services.AddTransient<IRoleApplication, RoleApplication>();
            services.AddTransient<IRoleRepository, RoleRepository>();

            services.AddDbContext<AccountContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
