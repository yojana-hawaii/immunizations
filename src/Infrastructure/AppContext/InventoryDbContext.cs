using Domain.Model.Extension;
using Domain.Models.Cdc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Runtime.InteropServices;

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

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        //get all entities that inherit from AuditableEntity and have state of Added or Modified
        var entities = ChangeTracker
            .Entries()
            .Where(e => e.Entity is AuditableEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

        var creator = "creator";
        var modifier = "modifier";

        foreach (var entity in entities)
        {

            // check if there is better option that HttpContextAccessor. Need to Inject Services.AddHttpContextAccessor();
            //var user = _httpContextAccessor?.HttpContext?.User?.Identity?.Name ?? "MyApp";

            //if entity statis is added, Utc createdAt and CreatedBy HttpContextAccessor
            if (entity.State == EntityState.Added)
            {
                ((AuditableEntity)entity.Entity).CreatedDate = DateTime.UtcNow;
                ((AuditableEntity)entity.Entity).CreatedBy = creator;
            }
            else
            {
                //last modified needs to be updated whether new is added or old updated
                ((AuditableEntity)entity.Entity).ModifiedDate = DateTime.UtcNow;
                ((AuditableEntity)entity.Entity).ModifiedBy = modifier;
            }

        }
        return await base.SaveChangesAsync(cancellationToken);

    }


}
