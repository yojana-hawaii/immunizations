using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using Domain.Models.Cdc;
namespace Infrastructure.FluentApiConfig.Cdc;

internal class CdcLookupBarcodeConfiguration : IEntityTypeConfiguration<CdcLookupBarcode>
{
    public void Configure(EntityTypeBuilder<CdcLookupBarcode> builder)
    {
        builder.HasAlternateKey(c => new {c.VisFullyEncodedString, c.EditionStatus }).HasName("IX_encodedString");

    }
}