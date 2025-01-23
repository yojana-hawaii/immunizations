
using Domain.Utility.CollectionHelper;
using Infrastructure.AppContext;

namespace Infrastructure.Repository.Cdc;

public class CdcCvxVaccineGroupRepository : ICdcCvxVaccineGroup
{
    private readonly InventoryDbContext _context;
    public CdcCvxVaccineGroupRepository(InventoryDbContext context)
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

    public void SaveChanges(IEnumerable<CdcCvxVaccineGroup> fetchedData)
    {
        IEnumerable<CdcCvxVaccineGroup> _vaccineGroup = _context.CdcCvxVaccineGroups;

        var result = CompareCollection<CdcCvxVaccineGroup>
                        .CompareLists(_vaccineGroup, fetchedData,
                            keySelector: c => (c.CdcCvxCode, c.VaccineGroupCvxCode),
                            propertyComparer: (oldItem, newItem) => oldItem.VaccineStatus == newItem.VaccineStatus && oldItem.VaccineGroupName == newItem.VaccineGroupName
                        );

        _context.AddRangeAsync(result.Added);
        _context.SaveChangesAsync();

    }
}
