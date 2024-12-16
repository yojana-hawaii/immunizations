using Domain.CDC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbMigration.FuentApi.CDC
{
    internal class CdcLookupBarcodeConfiguration : IEntityTypeConfiguration<CdcLookupBarcode>
    {
        public void Configure(EntityTypeBuilder<CdcLookupBarcode> builder)
        {
            builder.HasAlternateKey(c => c.VisFullyEncodedString).HasName("IX_encodedString");

        }
    }
}
