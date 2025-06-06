﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Cdc;

namespace Infrastructure.FluentApiConfig.Cdc;

internal class CdcManufacturerConfiguration : IEntityTypeConfiguration<CdcManufacturer>
{
    public void Configure(EntityTypeBuilder<CdcManufacturer> builder)
    {
        builder.HasAlternateKey(c => c.MvxCode);
    }
}