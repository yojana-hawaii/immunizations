using Domain.CDC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbMigration.FuentApi.CDC
{
    internal class CdcLookupNdc10Configuration : IEntityTypeConfiguration<CdcLookupNdc>
    {
        public void Configure(EntityTypeBuilder<CdcLookupNdc> builder)
        {
            builder.HasIndex(c=> new {c.SaleNdc11, c.SaleNdc10, c.UseNdc11, c.UseNdc10, c.CdcCvxCode, c.MvxCode}).IsUnique().HasDatabaseName("IX_ndc11_ndc10_cvx_mvx");
        }
    }
}
