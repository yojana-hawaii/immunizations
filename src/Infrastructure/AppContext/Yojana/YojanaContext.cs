using Domain.Model.Extension;
using Domain.Models.Cdc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.AppContext.Yojana;

public class YojanaContext : DbContext
{
    // access to IHttpContextAccessor
    private readonly IHttpContextAccessor? _httpContextAccessor;
    public string? LoggedInUser { get; private set; }

    //overload controller
    public YojanaContext(DbContextOptions<YojanaContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
        if (_httpContextAccessor.HttpContext != null)
        {
            LoggedInUser = _httpContextAccessor.HttpContext.User.Identity?.Name;
            LoggedInUser = LoggedInUser ?? "Unknown";
        }
        else
        {
            //no httpcontext means user did not make the change
            LoggedInUser = "seed-data";
        }
    }
    public YojanaContext(DbContextOptions<YojanaContext> options) : base(options) { }

    public DbSet<CdcCvxCode> CdcCvxCodes { get; set; }
    public DbSet<CdcCvxCpt> CdcCvxCpts { get; set; }
    public DbSet<CdcCvxManufacturer> CdcCvxManufacturers { get; set; }
    public DbSet<CdcCvxVaccineGroup> CdcCvxVaccineGroups { get; set; }
    public DbSet<CdcCvxVis> CdcCvxVises { get; set; }
    public DbSet<CdcLookupNdc> CdcLookupNdcs { get; set; }
    public DbSet<CdcLookupBarcode> CdcLookupBarcodes { get; set; }
    public DbSet<CdcManufacturer> CdcManufacturers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //apply all fluent api configuratio to entity using reflection
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }


    //override save changes synchronous & async
    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        OnBeforeSaving();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }
    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken)
    {
        OnBeforeSaving();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void OnBeforeSaving()
    {
        var entities = ChangeTracker.Entries();
        foreach (var ent in entities)
        {
            if (ent.Entity is IAuditable trackable)
            {
                var now = DateTime.UtcNow;
                switch (ent.State)
                {
                    case EntityState.Modified:
                        trackable.ModifiedBy = LoggedInUser;
                        trackable.ModifiedDate = now;
                        break;
                    case EntityState.Added:
                        trackable.CreatedBy = LoggedInUser;
                        trackable.CreatedDate = now;
                        trackable.ModifiedBy = LoggedInUser;
                        trackable.ModifiedDate = now;
                        break;
                }
            }
        }
    }
}
