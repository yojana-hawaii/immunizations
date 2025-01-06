
using Infrastructure.AppContext;

namespace Infrastructure.Repository.Cdc;

public class CdcLookupNdcRepository : ICdcLookupNdc
{
    private readonly InventoryDbContext _context;

    public CdcLookupNdcRepository(InventoryDbContext dbContext)
    {
        _context = dbContext;
    }

    public IEnumerable<CdcLookupNdc> FetchAll()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<CdcLookupNdc> GetAll()
    {
        return _context.CdcLookupNdcs;
    }

    public CdcLookupNdc GetByCvxCode(string cvxCode)
    {
        if (string.IsNullOrWhiteSpace(cvxCode)) 
        { 
            throw new ArgumentNullException(nameof(cvxCode)); 
        }
        
        var _ndc = _context.CdcLookupNdcs.FirstOrDefault(n => n.CdcCvxCode == cvxCode);
        
        if (_ndc == null) 
        { 
            throw new NullReferenceException(nameof(cvxCode)); 
        }

        return _ndc;
    }
}
