using Domain.CDC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbMigration.FuentApi.CDC
{
    internal class CdcCvxVaccineGroupConfiguration : IEntityTypeConfiguration<CdcCvxVaccineGroup>
    {
        public void Configure(EntityTypeBuilder<CdcCvxVaccineGroup> builder)
        {
            builder.HasIndex(c => new { c.CdcCvxCode, c.VaccineGroupCvxCode }).IsUnique().HasDatabaseName("IX_cvx_groupcvx");
        }
    }
}
