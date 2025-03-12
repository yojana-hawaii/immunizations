
using Domain.Utility.CollectionHelper;
using Infrastructure.AppContext;

namespace Infrastructure.Repository.Cdc;

public class CdcCvxVaccineGroupRepository : ICdcCvxVaccineGroup
{
    private readonly YojanaContext _context;
    public CdcCvxVaccineGroupRepository(YojanaContext context)
    {
        _context = context;
    }

    public IEnumerable<CdcCvxVaccineGroup> GetAll()
    {
        throw new NotImplementedException();
    }

    public CdcCvxVaccineGroup GetByCvxCode(string cvxCode)
    {
        throw new NotImplementedException();
    }

    public void UpdateFetchedData(IEnumerable<CdcCvxVaccineGroup> fetchedVaccineData)
    {
        IEnumerable<CdcCvxVaccineGroup> _vaccineGroup = _context.CdcCvxVaccineGroups;

        var result = CompareCollection<CdcCvxVaccineGroup>
                        .CompareLists(_vaccineGroup, fetchedVaccineData,
                            keySelector: c => (c.CdcCvxCode, c.VaccineGroupCvxCode),
                            propertyComparer: (oldItem, newItem) => CdcCvxVaccineGroup.CdcFetchComparer(oldItem, newItem)
                        );

        _context.AddRangeAsync(result.Added);
        _context.UpdateRange(result.Changed);
        _context.SaveChanges();
    }
}
