﻿using Domain.CDC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbMigration.FuentApi.CDC
{
    internal class CdcCvxVisConfiguration : IEntityTypeConfiguration<CdcCvxVis>
    {
        public void Configure(EntityTypeBuilder<CdcCvxVis> builder)
        {
            builder.HasIndex(c => new { c.CdcCvxCode, c.VisDocumentName, c.VisEditionDate })
                .IsUnique()
                .HasDatabaseName("IX_cvx_visname_visdate");
            // Any given vis document name can have 0 or 1 current status. All other vis document with same name has to be historical. 
            //builder.HasIndex(c => new { c.VisDocumentName, c.VisEditionStatus }).HasFilter("[VisEditionStatus] = "Current"").IsUnique();
        }
    }
}