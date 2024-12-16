using Domain.CDC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbMigration.FuentApi.CDC
{
    internal class CdcCvxConfiguration : IEntityTypeConfiguration<CdcCvx>
    {

        public void Configure(EntityTypeBuilder<CdcCvx> builder)
        {
            builder.HasAlternateKey(c => c.CdcCvxCode).HasName("IX_cvx");
        }
    }
}
