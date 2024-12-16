using Domain.CDC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbMigration.FuentApi.CDC
{
    internal class CdcCvxManufacturerConfiguration : IEntityTypeConfiguration<CdcCvxManufacturer>
    {
        public void Configure(EntityTypeBuilder<CdcCvxManufacturer> builder)
        {
            builder.HasIndex(c => new { c.CdcProductName, c.MvxCode, c.CdcCvxCode }).IsUnique();
        }
    }
}