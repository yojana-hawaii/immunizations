using Domain.Models.Tenant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FluentApiConfig.Tenant;

internal class VaccineSourceConfiguration : IEntityTypeConfiguration<VaccineSource>
{
    public void Configure(EntityTypeBuilder<VaccineSource> builder)
    {
        builder
            .HasIndex(src => src.VaccineSourceName)
            .IsUnique()
            .HasDatabaseName("ix_vaccine_source");
    }

}
