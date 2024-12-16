using Domain.CDC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbMigration.FuentApi.CDC
{
    internal class CdcCvxCptConfiguration : IEntityTypeConfiguration<CdcCvxCpt>
    {
        public void Configure(EntityTypeBuilder<CdcCvxCpt> builder)
        {
            builder.HasAlternateKey(c => new { c.CdcCvxCode, c.CptCode }).HasName("IX_cvx_cpt");
        }
    }
}
