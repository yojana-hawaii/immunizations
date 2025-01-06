using Infrastructure.AppContext;
using System.Globalization;

namespace nunittest.seed.Cdc;

internal class CdcDbInitializer
{
    internal static void Initialize(InventoryDbContext _context)
    {
        if (!_context.CdcCvxes.Any())
            SeedCdcCvxes(_context);
    }

    private static void SeedCdcCvxes(InventoryDbContext _context)
    {
        CultureInfo culture = CultureInfo.InvariantCulture;
        DateTimeStyles styles = DateTimeStyles.None;

        var _cdcCvx = new[]
        {
            new CdcCvx { CdcCvxCode = "012", ShortDescription = "short desc 012", FullVaccineName = "vaccine 012", Notes = "some note 012", VaccineStatus = "", LastUpdatedDate = DateOnly.Parse("2018-01-06", culture, styles) },
            new CdcCvx { CdcCvxCode = "345", ShortDescription = "short desc 345", FullVaccineName = "vaccine 345", Notes = "some note 345", VaccineStatus = "", LastUpdatedDate = DateOnly.Parse("2024-11-02", culture, styles) },
            new CdcCvx { CdcCvxCode = "567", ShortDescription = "short desc 567", FullVaccineName = "vaccine 567", Notes = "some note 678", VaccineStatus = "", LastUpdatedDate = DateOnly.Parse("2015-05-08", culture, styles) },
            new CdcCvx { CdcCvxCode = "901", ShortDescription = "short desc 901", FullVaccineName = "vaccine 901", Notes = "some note 901", VaccineStatus = "", LastUpdatedDate = DateOnly.Parse("1998-07-21", culture, styles) },
        };

        _context.CdcCvxes.AddRange(_cdcCvx);
        _context.SaveChanges();
    }
}
