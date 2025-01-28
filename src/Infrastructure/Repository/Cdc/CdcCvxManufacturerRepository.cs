using Domain.Utility.CollectionHelper;
using Infrastructure.AppContext;

namespace Infrastructure.Repository.Cdc;

public class CdcCvxManufacturerRepository : ICdcCvxManufacturer
{
    private readonly InventoryDbContext _context;

    public CdcCvxManufacturerRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public IEnumerable<CdcCvxManufacturer> GetAll()
    {
        return _context.CdcCvxManufacturers;
    }

    public CdcCvxManufacturer GetByCvxCode(string cvxCode)
    {
        throw new NotImplementedException();
    }

    public void UpdateFetchedData(IEnumerable<CdcCvxManufacturer> fetchedManufacturers)
    { 
        IEnumerable<CdcCvxManufacturer> _mfr = _context.CdcCvxManufacturers;

        var _result = CompareCollection<CdcCvxManufacturer>
                     .CompareLists(
                         _mfr,
                         fetchedManufacturers,
                         keySelector: c => (c.CdcCvxCode, c.CdcProductName, c.MvxCode),
                         propertyComparer: (oldItem, newItem) => CdcCvxManufacturer.CdcFetchComparer(oldItem, newItem)
                     );

        _context.AddRangeAsync(_result.Added);
        _context.UpdateRange(_result.Changed);
        var task = _context.SaveChangesAsync();

    }
}
