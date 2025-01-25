using Domain.Utility.CollectionHelper;
using Infrastructure.AppContext;


namespace Infrastructure.Repository.Cdc;

public class CdcCvxCptRepository : ICdcCvxCpt
{
    private readonly InventoryDbContext _context;


    public CdcCvxCptRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public IEnumerable<CdcCvxCpt> GetAll()
    {
        return _context.CdcCvxCpts;
    }

    public CdcCvxCpt GetByCvxCode(string cvxCode)
    {
        throw new NotImplementedException();
    }

    public void SaveChanges(IEnumerable<CdcCvxCpt> fetchedCpts)
    {
        IEnumerable<CdcCvxCpt> _cpts = _context.CdcCvxCpts;

        var _result = CompareCollection<CdcCvxCpt>
                    .CompareLists(
                        _cpts, 
                        fetchedCpts,
                        keySelector: c => (c.CdcCvxCode, c.CptCode),
                        propertyComparer: (oldItem, newItem) => CdcCvxCpt.CdcFetchComparer(oldItem, newItem)
                    );

        _context.AddRangeAsync(_result.Added);
        _context.UpdateRange(_result.Changed);
        _context.SaveChangesAsync();

    }

}
