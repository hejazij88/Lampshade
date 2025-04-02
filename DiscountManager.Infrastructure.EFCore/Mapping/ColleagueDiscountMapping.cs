using DiscountManagement.Domain.ColleagueDiscountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountManager.Infrastructure.EFCore.Mapping;

public class ColleagueDiscountMapping:IEntityTypeConfiguration<ColleagueDiscount>
{
    public void Configure(EntityTypeBuilder<ColleagueDiscount> builder)
    {
        builder.ToTable("ColleagueDiscounts");
        builder.HasKey(cd => cd.Id);
    }
}