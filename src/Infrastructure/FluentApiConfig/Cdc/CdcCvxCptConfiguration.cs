using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Cdc;

namespace Infrastructure.FluentApiConfig.Cdc;

internal class CdcCvxCptConfiguration : IEntityTypeConfiguration<CdcCvxCpt>
{
    public void Configure(EntityTypeBuilder<CdcCvxCpt> builder)
    {
        builder.HasAlternateKey(c => new { c.CdcCvxCode, c.CptCode }).HasName("IX_cvx_cpt");
    }
}