using Domain.Models.Cdc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.AppContext;

public class InventoryDbContext : DbContext
{
    public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }

    public DbSet<CdcCvx> CdcCvxes { get; set; }
    public DbSet<CdcCvxCpt> CdcCvxCpts { get; set; }
    public DbSet<CdcCvxManufacturer> CdcCvxManufacturers { get; set; }
    public DbSet<CdcCvxVaccineGroup> CdcCvxVaccineGroups { get; set; }
    public DbSet<CdcCvxVis> CdcCvxVises { get; set; }
    public DbSet<CdcLookupNdc> CdcLookupNdcs { get; set; }
    public DbSet<CdcLookupBarcode> CdcLoopupBarcodes { get; set; }
    public DbSet<CdcManufacturer> CdcManufacturers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //apply all fluent api configuratio to entity using reflection
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
