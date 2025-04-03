using System.ComponentModel.Design;
using DiscountManagement.Contract.ColleagueDiscount;
using DiscountManagement.Contract.CustomerDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManager.Application;
using DiscountManager.Infrastructure.EFCore;
using DiscountManager.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DiscountManagerInfrastructure.Configuration;

public class DiscountManagerBootstrapper
{
    public static void Configure(IServiceCollection services,string connectionString)
    {
        services.AddTransient<ICustomerDiscountRepository, CustomerDiscountRepository>();
        services.AddTransient<ICustomerDiscountApplication, CustomerDiscountApplication>();

        services.AddTransient<IColleagueDiscountRepository, ColleagueDiscountRepository>();
        services.AddTransient<IColleagueDiscountApplication, ColleagueDiscountApplication>();

        services.AddDbContext<DiscountContext>(db => db.UseSqlServer(connectionString));

    }
}