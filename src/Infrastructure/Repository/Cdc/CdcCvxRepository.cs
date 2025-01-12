
using Infrastructure.AppContext;

namespace Infrastructure.Repository.Cdc;

public class CdcCvxRepository : ICdcCvx
{
    private readonly InventoryDbContext _context;


    public CdcCvxRepository(InventoryDbContext context)
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

    public void SaveChanges(List<string[]> data) {

        // convert list of array into list of object > easy to understand during comparision
        var newData = data.Select(d => new CdcCvx()
        {
            CdcCvxCode = d[0],
            ShortDescription = d[1],
            FullVaccineName = d[2],
            Notes = d[3],
            VaccineStatus = d[4],
            NonVaccine = bool.Parse(d[5]),
            LastUpdatedDate = DateOnly.Parse(d[6])

        })
            .OrderBy(x => x.CdcCvxCode)
            .ToList();

        var currentData = _context.CdcCvxes.ToList();

        var changes = SaveModifiedCvxCodes(newData, currentData);
        var additions = AddNewCdcCvx(newData, currentData);

        _context.UpdateRange(changes);
        _context.AddRange(additions);
        _context.SaveChanges();
    }

    private List<CdcCvx> AddNewCdcCvx(List<CdcCvx> newData, List<CdcCvx> currentData)
    {
        return newData.Where(ndata => currentData.All(cdata => ndata.CdcCvxCode != cdata.CdcCvxCode)).ToList();
    }

    private List<CdcCvx> SaveModifiedCvxCodes(List<CdcCvx> newData, List<CdcCvx> currentData)
    {
        //order by cvx code
        var updatedCvxData = newData
            .Select(n => n.CdcCvxCode)
            .ToList();


        //get data from database where cvx code matches and order by cvx code
        var entities = currentData
            .Where(cvx => updatedCvxData.Any(u => u == cvx.CdcCvxCode))
            .OrderBy(x => x.CdcCvxCode)
            .ToList();

        List<CdcCvx> changes = new List<CdcCvx>();

        // one loop enough since both ordered by cvx code
        for (var i = 0; i < entities.Count; i++)
        {
            if (entities[i].CdcCvxCode == newData[i].CdcCvxCode && entities[i].LastUpdatedDate != newData[i].LastUpdatedDate)
            {
                entities[i].ShortDescription = newData[i].ShortDescription;
                entities[i].FullVaccineName = newData[i].FullVaccineName;
                entities[i].Notes = newData[i].Notes;
                entities[i].VaccineStatus = newData[i].VaccineStatus;
                entities[i].LastUpdatedDate = newData[i].LastUpdatedDate;
                entities[i].NonVaccine = newData[i].NonVaccine;
                changes.Add(entities[i]);
            }
            
        }

        return changes;
    }


}
