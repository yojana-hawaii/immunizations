using Domain.Models.Cdc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FluentApiConfig.Cdc;

internal class CdcCvxConfiguration : IEntityTypeConfiguration<CdcCvx>
{
    public void Configure(EntityTypeBuilder<CdcCvx> builder)
    {
        builder.HasAlternateKey(c => c.CdcCvxCode).HasName("IX_cvx");
    }
}
