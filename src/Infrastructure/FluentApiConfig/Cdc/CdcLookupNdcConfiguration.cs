using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FluentApiConfig.Cdc;

internal class CdcLookupNdcConfiguration : IEntityTypeConfiguration<CdcLookupNdc>
{
    public void Configure(EntityTypeBuilder<CdcLookupNdc> builder)
    {
        builder.HasIndex(c => new { c.SaleNdc11, c.SaleNdc10, c.UseNdc11, c.UseNdc10, c.CdcCvxCode, c.MvxCode, c.CptCode }).IsUnique().HasDatabaseName("IX_ndc11_ndc10_cvx_mvx_cpt");
        builder.HasIndex(c => new { c.SaleNdc10 }).HasDatabaseName("IX_sale_ndc10");
        builder.HasIndex(c => new { c.SaleNdc11 }).HasDatabaseName("IX_sale_ndc11");
        builder.HasIndex(c => new { c.UseNdc10 }).HasDatabaseName("IX_use_ndc10");
        builder.HasIndex(c => new { c.UseNdc11 }).HasDatabaseName("IX_use_ndc11");
        builder.HasIndex(c => new { c.CdcCvxCode }).HasDatabaseName("IX_cvx");
        builder.HasIndex(c => new { c.MvxCode }).HasDatabaseName("IX_mvx");
        builder.HasIndex(c => new { c.CptCode }).HasDatabaseName("IX_cpt");
    }
}
