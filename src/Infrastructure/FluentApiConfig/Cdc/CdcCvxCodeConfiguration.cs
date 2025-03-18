using Domain.Models.Cdc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FluentApiConfig.Cdc;

internal class CdcCvxCodeConfiguration : IEntityTypeConfiguration<CdcCvxCode>
{
    public void Configure(EntityTypeBuilder<CdcCvxCode> builder)
    {
        builder.HasAlternateKey(c => c.CvxCode).HasName("IX_cvx");
    }
}
