
using Infrastructure.AppContext;
using Infrastructure.Utility.Cdc;
using Infrastructure.Utility.Shared;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Cdc;

public class CdcCvxManufacturerRepository : ICdcCvxManufacturer
{
    private readonly InventoryDbContext _context;

    public CdcCvxManufacturerRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public IEnumerable<CdcCvxManufacturer> GetAll()
    {
        return _context.CdcCvxManufacturers;
    }

    public CdcCvxManufacturer GetByCvxCode(string cvxCode)
    {
        throw new NotImplementedException();
    }

    public void SaveChanges(IEnumerable<CdcCvxManufacturer> fetchedManufacturers)
    { 
        IEnumerable<CdcCvxManufacturer> _currentData = _context.CdcCvxManufacturers;

        CdcCvxManufacturerComparer _comparer = new CdcCvxManufacturerComparer();


        if (!CollectionHelper<CdcCvxManufacturer>.CollectionEquals(_currentData, fetchedManufacturers, _comparer))
        {
            List<CdcCvxManufacturer> changes;
            IEnumerable<CdcCvxManufacturer> addition;

            // data changes > update
            changes = CollectionHelper<CdcCvxManufacturer>.Changes(_currentData, fetchedManufacturers, _comparer);
            // data missing in current > add
            addition = fetchedManufacturers.Except(_currentData, _comparer);
            // data missing in new > ignore vs delete in current vs mark as deleted


            try
            {
                _context.AddRange(addition);
                _context.UpdateRange(changes);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                var sqlException = ex.GetBaseException() as SqlException;
                if (sqlException?.Number == 2627)
                {
                    Console.WriteLine("Duplicate data entry");
                }
                else
                {
                    Console.WriteLine("Other Db Errors");
                }

            }
        }
        else
        {
            Console.WriteLine("current and new are same");
        }

    }
}
