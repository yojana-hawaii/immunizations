
using Domain.Utility.CollectionHelper;
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

    public void UpdateFetchedData(IEnumerable<CdcCvxVis> fetchedVis)
    {
        IEnumerable<CdcCvxVis> _vis = _context.CdcCvxVises;

        var _result = CompareCollection<CdcCvxVis>
                    .CompareLists(
                        _vis,
                        fetchedVis,
                        keySelector: c => (c.CdcCvxCode, c.VisDocumentName, c.VisEditionDate),
                        propertyComparer: (oldItem, newItem) => CdcCvxVis.CdcFetchComparer(oldItem, newItem)
                    );

        _context.AddRangeAsync(_result.Added);
        _context.UpdateRange(_result.Changed);
        var task = _context.SaveChangesAsync();

    }
}
