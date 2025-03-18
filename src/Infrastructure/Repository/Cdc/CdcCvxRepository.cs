
using Application.Interface.Cdc;
using Domain.Models.Cdc;
using Domain.Utility.CollectionHelper;
using Infrastructure.AppContext.Yojana;

namespace Infrastructure.Repository.Cdc;

public class CdcCvxRepository : ICdcCvxCode
{
    private readonly YojanaContext _context;


    public CdcCvxRepository(YojanaContext context)
    {
        _context = context;
    }

    public IEnumerable<CdcCvxCode> GetAll()
    {
        return _context.CdcCvxCodes;
    }

    public CdcCvxCode GetByCvxCode(string cvxCode)
    {
        if (string.IsNullOrWhiteSpace(cvxCode))
        {
            throw new ArgumentNullException(nameof(cvxCode));
        }

        var _cdcCvx = _context.CdcCvxCodes.FirstOrDefault(c => c.CvxCode == cvxCode);

        if (_cdcCvx == null)
        {
            throw new NullReferenceException(nameof(cvxCode));
        }

        return _cdcCvx;
    }


    public void UpdateFetchedData(IEnumerable<CdcCvxCode> fetchedCvxes)
    {
        IEnumerable<CdcCvxCode> _cvx = _context.CdcCvxCodes;

        var result = CompareCollection<CdcCvxCode>
                    .CompareLists(_cvx, fetchedCvxes,
                        keySelector: c => c.CvxCode,
                        propertyComparer: (oldItem, newItem) => CdcCvxCode.CdcFetchComparer(oldItem, newItem)
                    );

        _context.AddRangeAsync(result.Added);
        _context.UpdateRange(result.Changed);
        _context.SaveChanges();
    }


}
