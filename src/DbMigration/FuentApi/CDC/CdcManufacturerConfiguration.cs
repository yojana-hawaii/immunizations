using Domain.CDC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbMigration.FuentApi.CDC
{
    internal class CdcManufacturerConfiguration : IEntityTypeConfiguration<CdcManufacturer>
    {
        public void Configure(EntityTypeBuilder<CdcManufacturer> builder)
        {
            builder.HasAlternateKey(c=>c.MvxCode);
        }
    }
}
