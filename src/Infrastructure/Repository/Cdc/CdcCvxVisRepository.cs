
using Application.Interface.Cdc;
using Domain.Models.Cdc;
using Domain.Utility.CollectionHelper;
using Infrastructure.AppContext.Yojana;

namespace Infrastructure.Repository.Cdc;

public class CdcCvxVisRepository : ICdcCvxVis
{
    private readonly YojanaContext _context;
    public CdcCvxVisRepository(YojanaContext context)
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
        _context.SaveChanges();
    }
}
