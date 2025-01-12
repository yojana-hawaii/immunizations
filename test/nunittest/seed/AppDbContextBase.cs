using Infrastructure.AppContext;
using Microsoft.EntityFrameworkCore;
using nunittest.seed.Cdc;

namespace nunittest.seed;

public class AppDbContextBase : IDisposable
{
    private bool disposedvalue;
    protected readonly InventoryDbContext _context;

    public AppDbContextBase()
    {
        //different database name everytime. otherwise probloem
        var dbname = "InvDb_" + DateTime.Now.ToFileTimeUtc();

        //insert seed data into database using one instance of the context
        var options = new DbContextOptionsBuilder<InventoryDbContext>()
            .UseInMemoryDatabase(databaseName: dbname)
            .EnableSensitiveDataLogging()
            .Options;

        _context = new InventoryDbContext(options);
        _context.Database.EnsureCreated();

        CdcDbInitializer.Initialize(_context);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (_context != null)
            {
                _context.Database.EnsureDeleted();
                _context.Dispose();
            }

            disposedvalue = true;
        }
    }
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
