
using Infrastructure.AppContext;

namespace Infrastructure.Repository.Cdc;

public class CdcCvxRepository : ICdcCvx
{
    private readonly InventoryDbContext _context;

    public CdcCvxRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public IEnumerable<CdcCvx> FetchAll()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<CdcCvx> GetAll()
    {
        return _context.CdcCvxes;
    }

    public CdcCvx GetByCvxCode(string cvxCode)
    {
        if (string.IsNullOrWhiteSpace(cvxCode)) 
        { 
            throw new ArgumentNullException(nameof(cvxCode)); 
        }
        
        var _cdcCvx = _context.CdcCvxes.FirstOrDefault(c => c.CdcCvxCode == cvxCode);
        
        if (_cdcCvx == null) 
        { 
            throw new NullReferenceException(nameof(cvxCode)); 
        }
        
        return _cdcCvx;
    }
}
