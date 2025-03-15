using Domain.Models.Tenant;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Infrastructure.AppContext.Tenant;

public static class TenantInitializer
{
    /// <summary>
    /// prepare database and seed data
    /// </summary>
    /// <param name="serviceProvider">DI Container</param>
    /// <param name="DeleteDatabase">Delete database and start from scratch</param>
    /// <param name="UseMigrations">User Migration or EnsureCreated</param>
    /// <param name="SeedSampleData">Add Sample data</param>
    public static void Initialize(IServiceProvider serviceProvider, bool DeleteDatabase = false, bool UseMigrations = true, bool SeedSampleData = true)
    {
        using TenantContext _context = new(serviceProvider.GetRequiredService<DbContextOptions<TenantContext>>());

        #region Prepare the database (delete, migrate etc) depending on options
        try
        {
            //using migration
            if (UseMigrations)
            {
                if (DeleteDatabase)
                {
                    _context.Database.EnsureDeleted(); //delete exisiting version
                }
                _context.Database.Migrate(); // apply all migrationa
            }
            else //no migration.Delete everything and recreate
            {
                if (DeleteDatabase)
                {
                    _context.Database.EnsureDeleted();
                    _context.Database.EnsureCreated();
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.GetBaseException().Message);
        }
        #endregion

        #region Add data that is applicable to sample or production data
        if (SeedSampleData)
        {
            try
            {
                if (!_context.VaccinePrograms.Any())
                {
                    SeedVaccinePrograms(_context);
                }
                if (!_context.VaccineSources.Any())
                {
                    SeedVaccineSource(_context);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.GetBaseException().Message);
            }
        }
        #endregion

        #region Seed random data
        if (SeedSampleData)
        {
            Random rnd = new();
            try
            {
                if (!_context.VaccineGroups.Any())
                {
                    //SeedVaccineGroups(_context);
                }
                if (!_context.VaccineLocations.Any())
                {
                    SeedLocations(_context);
                }
                if (!_context.VaccineLotNumbers.Any())
                {
                    //SeedVVaccineLotNumbers(_context, rnd);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.GetBaseException().Message);
            }
        }

        #endregion
    }



    private static void SeedVVaccineLotNumbers(TenantContext context, Random rnd)
    {
        DateOnly startDate = new DateOnly(1980, 1, 1);
        DateOnly endDate = new DateOnly(2024, 12, 31);
        var range = endDate.DayNumber - startDate.DayNumber;

        string str = "abcdefghijklmnofqrstuvwxyz1234567890";

        var totalLot = 100;
        var lotSize = 8;
        var lotNumber = "";
        for (var i = 1; i <= totalLot; i++)
        {
            var expDate = startDate.AddDays(rnd.Next(0, range));

            for (var j = 1; j <= lotSize; j++)
            {
                lotNumber = lotNumber + rnd.Next(str.Length);
            }

            var lot = new VaccineLotNumber
            {
                VaccineExpirationDate = expDate,
                LotNumber = lotNumber
            };

        }

    }

    private static void SeedLocations(TenantContext context)
    {
        var buildings = new string[] { "Building-A", "Building-B", "Building-C", "Building-D" };

        var sub1 = new string[] { "Floor 1", "Floor 2", "Floor 3" };
        var sub2 = new string[] { "Exec", "Accounting", "Marketing" };
        var sub3 = new string[] { "Room 1", "Room 2", "Room 3" };
        var sub = new string[][] { sub1, sub2, sub3 };

        var buildingCount = buildings.Length;
        var subCount = sub.Length;
        var max = buildingCount > subCount ? buildingCount : subCount;

        for (int i = 0; i < max; i++)
        {

            if (i >= subCount)
            {
                var loc = new VaccineLocation
                {
                    LocationName = buildings[i]
                };
                context.VaccineLocations.Add(loc);
            }
            else
            {
                foreach (var s in sub[i])
                {
                    var loc = new VaccineLocation
                    {
                        LocationName = buildings[i],
                        SubLocation = s
                    };
                    context.VaccineLocations.Add(loc);
                }
            }
        }
        try
        {
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.GetBaseException().Message);
        }
    }

    private static void SeedVaccineSource(TenantContext context)
    {
        var sources = new[]
        {
            new VaccineSource { VaccineSourceName = "State", VaccineSourceDescription = "Department of Health" },
            new VaccineSource { VaccineSourceName = "Federal", VaccineSourceDescription = "Center for Disease Control" },
            new VaccineSource { VaccineSourceName = "Private", VaccineSourceDescription = "Purchased" },
            new VaccineSource { VaccineSourceName = "Donated", VaccineSourceDescription = "donated" }
        };
        context.VaccineSources.AddRange(sources);
        try
        {
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.GetBaseException().Message);
        }
    }

    private static void SeedVaccinePrograms(TenantContext context)
    {
        var programs = new[]
        {
            new VaccineProgram { VaccineProgramName = "VFC", VaccineProgramDescription = "Vaccine For Children" },
            new VaccineProgram { VaccineProgramName = "VFA", VaccineProgramDescription = "Vaccine For Adults" }
        };
        context.VaccinePrograms.AddRange(programs);

        try
        {
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.GetBaseException().Message);
        }

    }
}
