
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

        var _newData = fetchedData.Except(_vaccineGroup);
        _context.AddRange(_newData);
        _context.SaveChanges();

    }
}
