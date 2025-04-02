using DiscountManagement.Domain.CustomerDiscountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountManager.Infrastructure.EFCore.Mapping;

public class CustomerDiscountMapping:IEntityTypeConfiguration<CustomerDiscount>
{
    public void Configure(EntityTypeBuilder<CustomerDiscount> builder)
    {
        builder.ToTable("CustomerDiscounts");
        builder.HasKey(cd => cd.Id);
    }
}