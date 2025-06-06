﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Cdc;

namespace Infrastructure.FluentApiConfig.Cdc;

internal class CdcCvxManufacturerConfiguration : IEntityTypeConfiguration<CdcCvxManufacturer>
{
    public void Configure(EntityTypeBuilder<CdcCvxManufacturer> builder)
    {
        builder.HasIndex(c => new { c.CdcProductName, c.MvxCode, c.CdcCvxCode }).IsUnique().HasDatabaseName("IX_name_mvx_cvx");
    }
}
