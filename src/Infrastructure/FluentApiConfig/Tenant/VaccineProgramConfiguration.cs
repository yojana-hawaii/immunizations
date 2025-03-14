using Domain.Models.Tenant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FluentApiConfig.Tenant;

internal class VaccineProgramConfiguration : IEntityTypeConfiguration<VaccineProgram>
{
    public void Configure(EntityTypeBuilder<VaccineProgram> builder)
    {
        builder
            .HasIndex(p => p.VaccineProgramName)
            .IsUnique()
            .HasDatabaseName("ix_vaccine_program");
    }
}
