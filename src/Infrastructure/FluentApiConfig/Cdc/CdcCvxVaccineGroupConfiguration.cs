using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Cdc;

namespace Infrastructure.FluentApiConfig.Cdc;

internal class CdcCvxVaccineGroupConfiguration : IEntityTypeConfiguration<CdcCvxVaccineGroup>
{
    public void Configure(EntityTypeBuilder<CdcCvxVaccineGroup> builder)
    {
        builder.HasIndex(c => new { c.CdcCvxCode, c.VaccineGroupCvxCode }).IsUnique().HasDatabaseName("IX_cvx_groupcvx");
    }
}