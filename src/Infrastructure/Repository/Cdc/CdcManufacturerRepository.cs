
using Domain.Utility.CollectionHelper;
using Infrastructure.AppContext;

namespace Infrastructure.Repository.Cdc;

public class CdcManufacturerRepository : ICdcManufacturer
{
    private readonly YojanaContext _context;

    public CdcManufacturerRepository(YojanaContext context)
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
        _context.SaveChanges();
    }
}
