
using Application.Interface.Cdc;
using Domain.Models.Cdc;
using Domain.Utility.CollectionHelper;
using Infrastructure.AppContext.Yojana;

namespace Infrastructure.Repository.Cdc;

public class CdcCvxRepository : ICdcCvx
{
    private readonly YojanaContext _context;


    public CdcCvxRepository(YojanaContext context)
    {
        _context = context;
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


    public void UpdateFetchedData(IEnumerable<CdcCvx> fetchedCvxes)
    {
        IEnumerable<CdcCvx> _cvx = _context.CdcCvxes;

        var result = CompareCollection<CdcCvx>
                    .CompareLists(_cvx, fetchedCvxes,
                        keySelector: c => c.CdcCvxCode,
                        propertyComparer: (oldItem, newItem) => CdcCvx.CdcFetchComparer(oldItem, newItem)
                    );

        _context.AddRangeAsync(result.Added);
        _context.UpdateRange(result.Changed);
        _context.SaveChanges();
    }


}
