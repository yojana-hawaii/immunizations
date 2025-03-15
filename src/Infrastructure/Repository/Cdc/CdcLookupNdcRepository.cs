
using Application.Interface.Cdc;
using Domain.Models.Cdc;
using Domain.Utility.CollectionHelper;
using Infrastructure.AppContext.Yojana;

namespace Infrastructure.Repository.Cdc;

public class CdcLookupNdcRepository : ICdcLookupNdc
{
    private readonly YojanaContext _context;

    public CdcLookupNdcRepository(YojanaContext dbContext)
    {
        _context = dbContext;
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

    public void UpdateFetchedData(IEnumerable<CdcLookupNdc> fetchedNdc)
    {
        IEnumerable<CdcLookupNdc> _ndc = _context.CdcLookupNdcs;

        var _result = CompareCollection<CdcLookupNdc>
                    .CompareLists(
                        _ndc,
                        fetchedNdc,
                        keySelector: c => (c.SaleNdc10, c.SaleNdc11, c.UseNdc10, c.UseNdc11, c.CdcCvxCode, c.MvxCode, c.CptCode),
                        propertyComparer: (oldItem, newItem) => CdcLookupNdc.CdcFetchComparer(oldItem, newItem)
                    );

        _context.AddRange(_result.Added);
        _context.UpdateRange(_result.Changed);
        _context.SaveChanges();
    }
}
