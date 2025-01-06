using Infrastructure.AppContext;

namespace Infrastructure.Repository.Shared;

public class DisposableRepository : IDisposable
{
    private bool disposedvalue;
    protected readonly InventoryDbContext? _context;

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
