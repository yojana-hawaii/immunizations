using Domain.Model.Extension;
using Domain.Models.Tenant;
using Infrastructure.FluentApiConfig.Tenant;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.AppContext.Tenant;

public class TenantContext : DbContext
{
    // access to IHttpContextAccessor
    private readonly IHttpContextAccessor? _httpContextAccessor;
    public string? LoggedInUser { get; private set; }

    //overload controller
    public TenantContext(DbContextOptions<TenantContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
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

    public TenantContext(DbContextOptions<TenantContext> options) : base(options) { }

    public DbSet<VaccineProgram> VaccinePrograms { get; set; }
    public DbSet<VaccineSource> VaccineSources { get; set; }
    public DbSet<VaccineLocation> VaccineLocations { get; set; }

    public DbSet<VaccineCvxCode> VaccineCveCodes { get; set; }
    public DbSet<VaccineGroup> VaccineGroups { get; set; }
    public DbSet<VaccineBrand> VaccineBrands { get; set; }

    public DbSet<VaccineLotNumber> VaccineLotNumbers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //apply all fluent api configuratio to entity using reflection - Relection takes all classes with IEntityTypeConfiguration including those not in this context
        //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        //dependent on organization but mostly similar
        modelBuilder.Entity<VaccineProgram>();
        modelBuilder.Entity<VaccineSource>();

        //org specific 
        modelBuilder.Entity<VaccineLocation>();

        //api call to yojana from mvc > pick and choose what to use
        modelBuilder.Entity<VaccineCvxCode>();
        modelBuilder.Entity<VaccineBrand>();
        modelBuilder.Entity<VaccineGroup>();

        //different for each org and dependent on vaccines
        modelBuilder.Entity<VaccineLotNumber>();

        modelBuilder.ApplyConfiguration(new VaccineProgramConfiguration());
        modelBuilder.ApplyConfiguration(new VaccineSourceConfiguration());
        modelBuilder.ApplyConfiguration(new VaccineLocationConfiguration());
        modelBuilder.ApplyConfiguration(new VaccineCvxCodeConfiguration());

        modelBuilder.HasDefaultSchema("dbo");
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
