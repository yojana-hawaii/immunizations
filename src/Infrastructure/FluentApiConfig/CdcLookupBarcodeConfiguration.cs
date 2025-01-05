using Domain.Models.Cdc;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.FluentApiConfig;

internal class CdcLookupBarcodeConfiguration : IEntityTypeConfiguration<CdcLookupBarcode>
{
    public void Configure(EntityTypeBuilder<CdcLookupBarcode> builder)
    {
        builder.HasAlternateKey(c => c.VisFullyEncodedString).HasName("IX_encodedString");

    }
}