using Domain.Models.Cdc;
using Domain.Utility.CollectionHelper;
using System.Numerics;

namespace nunittest;

[TestFixture]
public class CollectionHelperTests
{
    private List<CdcCvxVaccineGroup> _oldvaccineGrp;
    private List<CdcCvxVaccineGroup> _newVaccineGrp;
    private List<CdcCvxVaccineGroup> _emptyList;
    private List<CdcCvxCode> _oldCvx;
    private List<CdcCvxCode> _newCvx;
    private List<CdcCvxCpt> _oldCpt;
    private List<CdcCvxCpt> _newCpt;
    private IEnumerable<CdcManufacturer> _oldMfr;
    private IEnumerable<CdcManufacturer> _newMfr;
    //private List<CdcCvxVis> _oldVis;
    //private List<CdcCvxVis> _newVis;

    [SetUp]
    public void Setup()
    {
        _oldvaccineGrp = new List<CdcCvxVaccineGroup>
        {
            new CdcCvxVaccineGroup {ShortDescription = "DTP", CdcCvxCode = "01", VaccineStatus = "Inactive", VaccineGroupName = "DTAP", VaccineGroupCvxCode = "107"},
            new CdcCvxVaccineGroup {ShortDescription = "IPV", CdcCvxCode = "10", VaccineStatus = "Active", VaccineGroupName = "POLIO", VaccineGroupCvxCode = "89"},

            new CdcCvxVaccineGroup {ShortDescription = "MMR", CdcCvxCode = "03", VaccineStatus = "Active", VaccineGroupName = "MMR", VaccineGroupCvxCode = "03"},
            new CdcCvxVaccineGroup {ShortDescription = "measles", CdcCvxCode = "05", VaccineStatus = "Inactive", VaccineGroupName = "MMR", VaccineGroupCvxCode = "03"},
            new CdcCvxVaccineGroup {ShortDescription = "mumps", CdcCvxCode = "07", VaccineStatus = "Inactive", VaccineGroupName = "MMR", VaccineGroupCvxCode = "03"},
            new CdcCvxVaccineGroup {ShortDescription = "rubella/mumps", CdcCvxCode = "38", VaccineStatus = "Inactive", VaccineGroupName = "MMR", VaccineGroupCvxCode = "03"},
            new CdcCvxVaccineGroup {ShortDescription = "MMRV", CdcCvxCode = "94", VaccineStatus = "Active", VaccineGroupName = "MMR", VaccineGroupCvxCode = "03"},

            new CdcCvxVaccineGroup {ShortDescription = "rubella", CdcCvxCode = "06", VaccineStatus = "Active", VaccineGroupName = "MMR", VaccineGroupCvxCode = "03"},
            new CdcCvxVaccineGroup {ShortDescription = "M/R", CdcCvxCode = "04", VaccineStatus = "Active", VaccineGroupName = "MMR", VaccineGroupCvxCode = "03"},
        };
        _newVaccineGrp = new List<CdcCvxVaccineGroup>
        {
            new CdcCvxVaccineGroup {ShortDescription = "MMR", CdcCvxCode = "03", VaccineStatus = "Active", VaccineGroupName = "MMR", VaccineGroupCvxCode = "03"},
            new CdcCvxVaccineGroup {ShortDescription = "measles", CdcCvxCode = "05", VaccineStatus = "Inactive", VaccineGroupName = "MMR", VaccineGroupCvxCode = "03"},
            new CdcCvxVaccineGroup {ShortDescription = "mumps", CdcCvxCode = "07", VaccineStatus = "Inactive", VaccineGroupName = "MMR", VaccineGroupCvxCode = "03"},
            new CdcCvxVaccineGroup {ShortDescription = "rubella/mumps", CdcCvxCode = "38", VaccineStatus = "Inactive", VaccineGroupName = "MMR", VaccineGroupCvxCode = "03"},
            new CdcCvxVaccineGroup {ShortDescription = "MMRV", CdcCvxCode = "94", VaccineStatus = "Active", VaccineGroupName = "MMR", VaccineGroupCvxCode = "03"},

            new CdcCvxVaccineGroup {ShortDescription = "M/R", CdcCvxCode = "04", VaccineStatus = "Inactive", VaccineGroupName = "MMR", VaccineGroupCvxCode = "03"},
            new CdcCvxVaccineGroup {ShortDescription = "rubella", CdcCvxCode = "06", VaccineStatus = "Inactive", VaccineGroupName = "MMR", VaccineGroupCvxCode = "03"},

            new CdcCvxVaccineGroup {ShortDescription = "DTaP", CdcCvxCode = "20", VaccineStatus = "Active", VaccineGroupName = "DTAP", VaccineGroupCvxCode = "107"},
            new CdcCvxVaccineGroup {ShortDescription = "DTP-Hib", CdcCvxCode = "22", VaccineStatus = "Inactive", VaccineGroupName = "DTAP", VaccineGroupCvxCode = "107"},
            new CdcCvxVaccineGroup {ShortDescription = "DTP-Hib", CdcCvxCode = "22", VaccineStatus = "Inactive", VaccineGroupName = "HIB", VaccineGroupCvxCode = "17"},

        };
        _emptyList = new List<CdcCvxVaccineGroup>();

        _oldCvx = new List<CdcCvxCode>
        {
            new CdcCvxCode { CvxCode = "02", FullVaccineName = "polio", ShortDescription = "OPV", VaccineStatus = "Active", NonVaccine = false, LastUpdatedDate = DateOnly.Parse("2015-02-10")},
            new CdcCvxCode { CvxCode = "03", FullVaccineName = "measles", ShortDescription = "MMR", VaccineStatus = "Active", NonVaccine = false, LastUpdatedDate = DateOnly.Parse("2015-05-28")},
        };
        _newCvx = new List<CdcCvxCode>
        {
            new CdcCvxCode { CvxCode = "02", FullVaccineName = "polio", ShortDescription = "OPV", VaccineStatus = "Inactive", NonVaccine = false, LastUpdatedDate = DateOnly.Parse("2017-02-10")},
            new CdcCvxCode { CvxCode = "107", FullVaccineName = "dipth", ShortDescription = "dtap", VaccineStatus = "Inactive", NonVaccine = false, LastUpdatedDate = DateOnly.Parse("2010-09-30")},
        };

        _oldCpt = new List<CdcCvxCpt>
        {
            new CdcCvxCpt { CdcCvxCode = "01", CptCode = "98811", CptDescription ="cpt01", CvxDescription = "cvx01", Comments = "comments01", CptCodeId = "101", LastUpdatedDate = DateOnly.Parse("2011-01-01")},
            new CdcCvxCpt { CdcCvxCode = "02", CptCode = "98812", CptDescription ="cpt02", CvxDescription = "cvx02", Comments = "comments02", CptCodeId = "102", LastUpdatedDate = DateOnly.Parse("2011-02-02")},
            new CdcCvxCpt { CdcCvxCode = "03", CptCode = "98813", CptDescription ="cpt03", CvxDescription = "cvx03", Comments = "comments03", CptCodeId = "103", LastUpdatedDate = DateOnly.Parse("2011-03-03")},
        };
        _newCpt = new List<CdcCvxCpt>
        {
            new CdcCvxCpt { CdcCvxCode = "01", CptCode = "98811", CptDescription ="cpt01", CvxDescription = "cvx01", Comments = "comments01", CptCodeId = "101", LastUpdatedDate = DateOnly.Parse("2011-01-01")},
            new CdcCvxCpt { CdcCvxCode = "02", CptCode = "98812", CptDescription ="cpt02", CvxDescription = "cvx02", Comments = "comments02+22", CptCodeId = "102", LastUpdatedDate = DateOnly.Parse("2012-02-02")},
            new CdcCvxCpt { CdcCvxCode = "04", CptCode = "98814", CptDescription ="cpt04", CvxDescription = "cvx04", Comments = "comments04", CptCodeId = "104", LastUpdatedDate = DateOnly.Parse("2011-04-04")},
        };

        _oldMfr = new List<CdcManufacturer>
        {
            new CdcManufacturer { ManufacturerName = "mfr01", ManufacturerStatus = "Active", MvxCode = "01", LastUpdatedDate = DateOnly.Parse("2011-01-01"), ManufacturerNotes = "note01", },
            new CdcManufacturer { ManufacturerName = "mfr02", ManufacturerStatus = "Active", MvxCode = "02", LastUpdatedDate = DateOnly.Parse("2011-01-02"), ManufacturerNotes = "note02", },
            new CdcManufacturer { ManufacturerName = "mfr03", ManufacturerStatus = "Active", MvxCode = "03", LastUpdatedDate = DateOnly.Parse("2011-01-03"), ManufacturerNotes = "note03", }
        };

        _newMfr = new List<CdcManufacturer>
        {
            new CdcManufacturer { ManufacturerName = "mfr01", ManufacturerStatus = "Active", MvxCode = "01", LastUpdatedDate = DateOnly.Parse("2011-01-01"), ManufacturerNotes = "note01", },
            new CdcManufacturer { ManufacturerName = "mfr02", ManufacturerStatus = "Inactive", MvxCode = "02", LastUpdatedDate = DateOnly.Parse("2011-01-03"), ManufacturerNotes = "note02", },
            new CdcManufacturer { ManufacturerName = "mfr04", ManufacturerStatus = "Active", MvxCode = "04", LastUpdatedDate = DateOnly.Parse("2011-01-04"), ManufacturerNotes = "note04", }
        };

        //_oldVis = new List<CdcCvxVis>
        //{
        //    new CdcCvxVis { CdcCvxCode = "vis01", CvxVaccineDescription = "desc01", VisDocumentName = "doc01", VisFullyEncodedTextString = "encode01", VisEditionStatus = "historical"}
        //}
    }
    [Test]
    public void GetChanges_AllMfrChanges()
    {
        var changes = CompareCollection<CdcManufacturer>
                            .CompareLists
                            (
                                oldList: _oldMfr,
                                newList: _newMfr,
                                keySelector: k => k.MvxCode,
                                propertyComparer: (o, n) => CdcManufacturer.CdcFetchComparer(o,n)
                            );
        Assert.That(changes.Added, Has.Exactly(1).Items);
        Assert.That(changes.Removed, Has.Exactly(1).Items);
        Assert.That(changes.Changed, Has.Exactly(1).Items);
        Assert.That(changes.Unchanged, Has.Exactly(1).Items);
        Assert.That(changes.Added.Any(c => c.MvxCode == "04"));
        Assert.That(changes.Removed.Any(r => r.ManufacturerName == "mfr03"));
        Assert.That(changes.Changed.Any(c => c.ManufacturerStatus == "Inactive"));
        Assert.That(changes.Unchanged.Any(u => u.ManufacturerNotes == "note01"));
    }

    [Test]
    public void GetChanges_AllCptChanges()
    {
        var changes = CompareCollection<CdcCvxCpt>
                        .CompareLists
                        (
                            _oldCpt,
                            _newCpt,
                            keySelector: k => (k.CptCode, k.CdcCvxCode),
                            propertyComparer: (o, n) => CdcCvxCpt.CdcFetchComparer(o, n)
                        );
        Assert.That(changes.Added, Has.Exactly(1).Items);
        Assert.That(changes.Removed, Has.Exactly(1).Items);
        Assert.That(changes.Changed, Has.Exactly(1).Items);
        Assert.That(changes.Unchanged, Has.Exactly(1).Items);
        Assert.That(changes.Added.Any(c => c.CdcCvxCode == "04"));
        Assert.That(changes.Removed.Any(r => r.CptCodeId == "103"));
        Assert.That(changes.Changed.Any(c => c.Comments == "comments02+22"));
        Assert.That(changes.Unchanged.Any(u => u.CptDescription == "cpt01"));
    }

    [Test]
    public void GetChanges_AllCvxChanges()
    {
        var changes = CompareCollection<CdcCvxCode>
                        .CompareLists(
                            _oldCvx,
                            _newCvx,
                            keySelector: k => k.CvxCode,
                            propertyComparer: (oldItem, newItem) => CdcCvxCode.CdcFetchComparer(oldItem, newItem)
                        );
        Assert.That(changes.Added, Has.Exactly(1).Items);
        Assert.That(changes.Added.Any(c => c.CvxCode == "107"));
        Assert.That(changes.Removed, Has.Exactly(1).Items);
        Assert.That(changes.Removed.Any(r => r.ShortDescription == "MMR"));
        Assert.That(changes.Unchanged, Has.Exactly(0).Items);
        Assert.That(changes.Changed, Has.Exactly(1).Items);
        Assert.That(changes.Changed.Any(c => c.VaccineStatus == "Inactive"));

    }

    [Test]
    public void FindAddedItems_ShouldResultOnlyInNewList()
    {
        //act
        var _result = CompareCollection<CdcCvxVaccineGroup>.CompareLists(_oldvaccineGrp, _newVaccineGrp, keySelector: c => (c.CdcCvxCode, c.VaccineGroupCvxCode));

        //Assert
        Assert.That(_result.Added.Count, Is.EqualTo(3));
        Assert.That(_result.Added.Count(a => a.CdcCvxCode == "22"), Is.EqualTo(2));
        Assert.That(_result.Added.Count(a => a.CdcCvxCode == "94"), Is.EqualTo(0));
    }

    [Test]
    public void FindRemovedItems_ShouldReturnOnlyInOldList()
    {
        //act
        var _result = CompareCollection<CdcCvxVaccineGroup>.CompareLists(_oldvaccineGrp, _newVaccineGrp, keySelector: c => (c.CdcCvxCode, c.VaccineGroupCvxCode));

        //Assert
        Assert.That(_result.Removed.Count, Is.EqualTo(2));
        Assert.That(_result.Removed.Count(a => a.CdcCvxCode == "01"), Is.EqualTo(1));
        Assert.That(_result.Removed.Count(a => a.CdcCvxCode == "06"), Is.EqualTo(0));
    }

    [Test]
    public void FindUnchangedItems_ShouldReturnOnlyUnchangedItems()
    {
        //act
        var _result = CompareCollection<CdcCvxVaccineGroup>
                        .CompareLists(_oldvaccineGrp, _newVaccineGrp,
                            keySelector: c => (c.CdcCvxCode, c.VaccineGroupCvxCode),
                            propertyComparer: (oldItem, newItem) => CdcCvxVaccineGroup.CdcFetchComparer(oldItem, newItem)
                        );


        //Assert
        Assert.That(_result.Unchanged.Count, Is.EqualTo(5));
        Assert.That(_result.Unchanged.Count(a => a.CdcCvxCode == "03"), Is.EqualTo(1));
        Assert.That(_result.Unchanged.Count(a => a.CdcCvxCode == "06"), Is.EqualTo(0));

    }
    [Test]
    public void FindChanged_ShouldReturnOnlyIfComparePropertiesNotMatch()
    {
        //act
        var _result = CompareCollection<CdcCvxVaccineGroup>
                        .CompareLists(_oldvaccineGrp, _newVaccineGrp,
                            keySelector: c => (c.CdcCvxCode, c.VaccineGroupCvxCode),
                            propertyComparer: (oldItem, newItem) => oldItem.VaccineStatus == newItem.VaccineStatus && oldItem.VaccineGroupName == newItem.VaccineGroupName
                        );


        //Assert
        Assert.That(_result.Changed.Count, Is.EqualTo(2));
        Assert.That(_result.Changed.Count(a => a.CdcCvxCode == "04"), Is.EqualTo(1));
        Assert.That(_result.Changed.Count(a => a.CdcCvxCode == "22"), Is.EqualTo(0));
    }

    [Test]
    public void GetChanges_AllItemsAdded()
    {
        var changes = CompareCollection<CdcCvxVaccineGroup>
                        .CompareLists(
                            _emptyList,
                            _newVaccineGrp,
                            keySelector: c => (c.CdcCvxCode, c.VaccineGroupCvxCode),
                            propertyComparer: (oldItem, newItem) => oldItem.Equals(newItem)
                        );
        Assert.That(changes.Added, Has.Exactly(10).Items);
        Assert.That(changes.Added.Any(c => c.VaccineGroupName == "MMR"));
        Assert.That(changes.Added.Any(c => c.CdcCvxCode == "04"));
        Assert.That(changes.Removed, Is.Empty);
        Assert.That(changes.Unchanged, Is.Empty);
        Assert.That(changes.Changed, Is.Empty);
    }

    [Test]
    public void GetChanges_AllItemsRemoved()
    {
        var changes = CompareCollection<CdcCvxVaccineGroup>
                        .CompareLists(
                            _newVaccineGrp,
                            _emptyList,
                            keySelector: c => (c.CdcCvxCode, c.VaccineGroupCvxCode),
                            propertyComparer: (oldItem, newItem) => PropertyComparer(oldItem, newItem)
                         );
        Assert.That(changes.Added, Is.Empty);
        Assert.That(changes.Removed, Has.Exactly(10).Items);
        Assert.That(changes.Removed.Any(c => c.VaccineGroupCvxCode == "03"));
        Assert.That(changes.Removed.Any(c => c.CdcCvxCode == "22"));
        Assert.That(changes.Unchanged, Is.Empty);
        Assert.That(changes.Changed, Is.Empty);
    }

    [Test]
    public void GetChanges_AllItemsUnchanged()
    {
        var changes = CompareCollection<CdcCvxVaccineGroup>
                        .CompareLists(
                            _oldvaccineGrp,
                            _oldvaccineGrp,
                            keySelector: c => (c.CdcCvxCode, c.VaccineGroupCvxCode),
                            propertyComparer: (oldItem, newItem) => CdcCvxVaccineGroup.CdcFetchComparer(oldItem, newItem)
                         );

        Assert.That(changes.Added, Is.Empty);
        Assert.That(changes.Removed, Is.Empty);
        Assert.That(changes.Unchanged, Has.Exactly(9).Items);
        Assert.That(changes.Unchanged.Any(u => u.VaccineGroupName == "MMR"));
        Assert.That(changes.Unchanged.Any(u => u.CdcCvxCode == "01"));
        Assert.That(changes.Changed, Is.Empty);
    }

    [Test]
    public void GetChanges_AllItemsChanged()
    {
        var _old = _oldvaccineGrp.Where(o => o.ShortDescription == "M/R" || o.ShortDescription == "rubella");
        var _new = _newVaccineGrp.Where(o => o.ShortDescription == "M/R" || o.ShortDescription == "rubella");


        var changes = CompareCollection<CdcCvxVaccineGroup>
                    .CompareLists(
                        _old,
                        _new,
                        keySelector: c => (c.CdcCvxCode, c.VaccineGroupCvxCode),
                        propertyComparer: (oldItem, newItem) => CdcCvxVaccineGroup.CdcFetchComparer(oldItem, newItem)
                     );

        Assert.That(changes.Added, Is.Empty);
        Assert.That(changes.Removed, Is.Empty);
        //Assert.That(changes.Unchanged, Is.Empty);
        Assert.That(changes.Changed, Has.Exactly(2).Items);
        //Assert.That(changes.Changed.Any(u => u.ShortDescription == "M/R"));
        //Assert.That(changes.Changed.Any(u => u.CdcCvxCode == "06"));
    }

    [Test]
    public void GetChanges_MixedChanges()
    {
        var changes = CompareCollection<CdcCvxVaccineGroup>
                    .CompareLists(
                        _oldvaccineGrp,
                        _newVaccineGrp,
                        keySelector: c => (c.CdcCvxCode, c.VaccineGroupCvxCode),
                        propertyComparer: (oldItem, newItem) => CdcCvxVaccineGroup.CdcFetchComparer(oldItem, newItem)
                     );

        Assert.That(changes.Added, Has.Exactly(3).Items);
        Assert.That(changes.Added.Any(c => c.ShortDescription == "DTaP"));
        Assert.That(changes.Removed, Has.Exactly(2).Items);
        Assert.That(changes.Removed.Any(r => r.CdcCvxCode == "01"));
        Assert.That(changes.Unchanged, Has.Exactly(5).Items);
        Assert.That(changes.Unchanged.Where(u => u.VaccineStatus == "Active"), Has.Exactly(2).Items);
        Assert.That(changes.Unchanged.Where(u => u.VaccineStatus == "what"), Has.Exactly(0).Items);
        Assert.That(changes.Changed, Has.Exactly(2).Items);
        Assert.That(changes.Changed.FirstOrDefault(c => c.CdcCvxCode == "04")?.VaccineStatus, Is.EqualTo("Inactive"));
        Assert.That(changes.Changed.FirstOrDefault(c => c.CdcCvxCode == "344")?.VaccineStatus, Is.Null);

    }

    private bool PropertyComparer(CdcCvxVaccineGroup oldItem, CdcCvxVaccineGroup newItem)
    {
        return oldItem.VaccineStatus == newItem.VaccineStatus && oldItem.VaccineGroupName == newItem.VaccineGroupName;
    }
}
