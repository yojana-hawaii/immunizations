﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.FluentApiConfig.Cdc;

internal class CdcLookupBarcodeConfiguration : IEntityTypeConfiguration<CdcLookupBarcode>
{
    public void Configure(EntityTypeBuilder<CdcLookupBarcode> builder)
    {
        builder.HasAlternateKey(c => c.VisFullyEncodedString).HasName("IX_encodedString");

    }
}