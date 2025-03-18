
using Application.Interface.Cdc;
using Domain.Models.Cdc;
using Domain.Utility.CollectionHelper;
using Infrastructure.AppContext.Yojana;

namespace Infrastructure.Repository.Cdc;

public class CdcLookupBarcodeRepository : ICdcLookupBarcode
{
    private readonly YojanaContext _context;

    public CdcLookupBarcodeRepository(YojanaContext context)
    {
        _context = context;
    }

    public IEnumerable<CdcLookupBarcode> GetAll()
    {
        return _context.CdcLookupBarcodes;
    }

    public CdcLookupBarcode GetByCvxCode(string cvxCode)
    {
        throw new NotImplementedException();
    }

    public void UpdateFetchedData(IEnumerable<CdcLookupBarcode> fetchedBarcode)
    {
        IEnumerable<CdcLookupBarcode> _barcode = _context.CdcLookupBarcodes;

        var _result = CompareCollection<CdcLookupBarcode>
                    .CompareLists(
                        _barcode,
                        fetchedBarcode,
                        keySelector: c => (c.VisFullyEncodedString, c.EditionStatus),
                        propertyComparer: (oldItem, newItem) => CdcLookupBarcode.CdcFetchComparer(oldItem, newItem)
                    );

        _context.AddRangeAsync(_result.Added);
        _context.UpdateRange(_result.Changed);
        _context.SaveChanges();
    }
}
