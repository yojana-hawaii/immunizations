
using Infrastructure.AppContext;
using System.Net.Http.Metrics;


namespace Infrastructure.Repository.Cdc;

public class CdcCvxCptRepository : ICdcCvxCpt
{
    private readonly InventoryDbContext _context;


    public CdcCvxCptRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public IEnumerable<CdcCvxCpt> GetAll()
    {
        return _context.CdcCvxCpts;
    }

    public CdcCvxCpt GetByCvxCode(string cvxCode)
    {
        throw new NotImplementedException();
    }

    public void SaveChanges(List<string[]> data)
    {
        List<CdcCvxCpt> newData = data.Select(d => new CdcCvxCpt()
        {
            CptCode = d[0],
            CptDescription = d[1],
            //d[2] always blank??
            CvxDescription = d[3],
            CdcCvxCode = d[4],
            Comments = d[5],
            LateUpdatedDate = DateOnly.Parse(d[6]),
            CptCodeId = string.IsNullOrWhiteSpace(d[7]) ? null : d[7]
        })
            .OrderBy(x => x.CptCode)
            .ThenByDescending( x => x.CdcCvxCode)
            .ToList();

        var currentData = _context.CdcCvxCpts.ToList();

        List<CdcCvxCpt> changes = SaveModifiedCvxCpts(newData, currentData);
        List<CdcCvxCpt> additions = AddNewCvxCpt(newData, currentData);

        _context.UpdateRange(changes);
        _context.AddRange(additions);
        _context.SaveChanges();
    }

    private List<CdcCvxCpt> AddNewCvxCpt(List<CdcCvxCpt> newData, List<CdcCvxCpt> currentData)
    {
        return newData.Where(n => currentData.All(c => c.CdcCvxCode != n.CdcCvxCode && c.CptCode != n.CptCode)).ToList();
    }

    private List<CdcCvxCpt> SaveModifiedCvxCpts(List<CdcCvxCpt> newData, List<CdcCvxCpt> currentData)
    {

        var entities = currentData
            .Where(c => newData.Any(u => u.CdcCvxCode == c.CdcCvxCode && c.CptCode == u.CptCode))
            .OrderBy(x => x.CptCode)
            .ThenByDescending(x => x.CdcCvxCode)
            .ToList();

        List<CdcCvxCpt> changes = new List<CdcCvxCpt>();

        for (int i = 0; i < entities.Count; i++)
        {
            if (entities[i].CptCode == newData[i].CptCode && entities[i].CdcCvxCode == newData[i].CdcCvxCode && entities[i].LateUpdatedDate != newData[i].LateUpdatedDate)
            {
                entities[i].CptDescription = newData[i].CptDescription;
                entities[i].Comments = newData[i].Comments;
                entities[i].LateUpdatedDate = newData[i].LateUpdatedDate;
                entities[i].CptCodeId = newData[i].CptCodeId;
                changes.Add(entities[i]);
            }
        }
        return changes;

    }
}
