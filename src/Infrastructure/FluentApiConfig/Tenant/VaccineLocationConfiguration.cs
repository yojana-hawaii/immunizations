using Domain.Models.Tenant;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.FluentApiConfig.Tenant;

internal class VaccineLocationConfiguration : IEntityTypeConfiguration<VaccineLocation>
{
    public void Configure(EntityTypeBuilder<VaccineLocation> builder)
    {
        builder
           .Property(c => c.ComputedSubLocationForUniqueness)
           .HasComputedColumnSql("isnull(SubLocation, 'NULL-MARKER')");
        builder
            .HasIndex(i => new { i.LocationName, i.ComputedSubLocationForUniqueness })
            .IsUnique()
            .HasDatabaseName("ix_location");

    }
}