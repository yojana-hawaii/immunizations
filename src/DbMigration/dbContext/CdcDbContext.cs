using Domain.CDC;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DbMigration.dbContext
{
    public class CdcDbContext : DbContext
    {
        public CdcDbContext(DbContextOptions<CdcDbContext> options) : base(options) {}

        public DbSet<CdcCvx> CdcCvxes { get; set; }
        public DbSet<CdcCvxCpt> CdcCvxCpts { get; set; }
        public DbSet<CdcCvxManufacturer> CdcCvxManufacturers { get; set; }
        public DbSet<CdcCvxVaccineGroup> cdcCvxVaccineGroups { get; set; }
        public DbSet<CdcCvxVis> cdcCvxes { get; set; }
        public DbSet<CdcLookupNdc> cdcLookupNdcs { get; set; }
        public DbSet<CdcLookupBarcode> cdcLoopupBarcodes { get; set; }
        public DbSet<CdcManufacturer> CdcManufacturers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //apply all fluent api configuratio to entity using reflection
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

}
}
