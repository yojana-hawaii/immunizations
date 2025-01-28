
using Domain.Utility.CollectionHelper;
using Infrastructure.AppContext;

namespace Infrastructure.Repository.Cdc;

public class CdcManufacturerRepository : ICdcManufacturer
{
    private readonly InventoryDbContext _context;

    public CdcManufacturerRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public IEnumerable<CdcManufacturer> GetAll()
    {
        return _context.CdcManufacturers;
    }

    public CdcManufacturer GetByMvxCode(string mvxCode)
    {
        throw new NotImplementedException();
    }

    public void UpdateFetchedData(IEnumerable<CdcManufacturer> fetchedManufacturer)
    {
        IEnumerable<CdcManufacturer> _mfr = _context.CdcManufacturers;

        var _result = CompareCollection<CdcManufacturer>
                    .CompareLists(
                        _mfr,
                        fetchedManufacturer,
                        keySelector: c => c.MvxCode,
                        propertyComparer: (oldItem, newItem) => CdcManufacturer.CdcFetchComparer(oldItem, newItem)
                    );

        _context.AddRangeAsync(_result.Added);
        _context.UpdateRange(_result.Changed);
        var task = _context.SaveChangesAsync();

    }
}
