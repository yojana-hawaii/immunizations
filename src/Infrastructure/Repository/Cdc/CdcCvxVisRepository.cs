
using Infrastructure.AppContext;

namespace Infrastructure.Repository.Cdc;

public class CdcCvxVisRepository : ICdcCvxVis
{
    private readonly InventoryDbContext _context;
    public CdcCvxVisRepository(InventoryDbContext context)
    {
        _context = context;
    }
    public IEnumerable<CdcCvxVis> GetAll()
    {
        return _context.CdcCvxVises;
    }

    public CdcCvxVis GetByCvxCode(string cvxCode)
    {
        throw new NotImplementedException();
    }

    public void SaveChanges(IEnumerable<CdcCvxVis> fetchedVis)
    {
        IEnumerable<CdcCvxVis> _vis = _context.CdcCvxVises;

        var _newData = fetchedVis.Except(_vis);
        _context.AddRange(_newData);
        _context.SaveChanges();
    }
}
