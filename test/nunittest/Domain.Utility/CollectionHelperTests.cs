using Domain.Utility.CollectionHelper;

namespace nunittest;

[TestFixture]
public class CollectionHelperTests
{
    private List<CdcCvxVaccineGroup> _oldList;
    private List<CdcCvxVaccineGroup> _newList;
    private List<CdcCvxVaccineGroup> _emptyList;

    [SetUp]
    public void Setup()
    {
        _oldList = new List<CdcCvxVaccineGroup>
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

        _newList = new List<CdcCvxVaccineGroup>
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

    }

    [Test]
    public void FindAddedItems_ShouldResultOnlyInNewList()
    {
        //act
        var _result = CompareCollection<CdcCvxVaccineGroup>.CompareLists(_oldList, _newList, keySelector: c => (c.CdcCvxCode, c.VaccineGroupCvxCode));

        //Assert
        Assert.That(_result.Added.Count, Is.EqualTo(3));
        Assert.That(_result.Added.Count(a => a.CdcCvxCode == "22"), Is.EqualTo(2));
        Assert.That(_result.Added.Count(a => a.CdcCvxCode == "94"), Is.EqualTo(0));
    }

    [Test]
    public void FindRemovedItems_ShouldReturnOnlyInOldList()
    {
        //act
        var _result = CompareCollection<CdcCvxVaccineGroup>.CompareLists(_oldList, _newList, keySelector: c => (c.CdcCvxCode, c.VaccineGroupCvxCode));

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
                        .CompareLists(_oldList, _newList,
                            keySelector: c => (c.CdcCvxCode, c.VaccineGroupCvxCode),
                            propertyComparer: (oldItem, newItem) => oldItem.VaccineStatus == newItem.VaccineStatus && oldItem.VaccineGroupName == newItem.VaccineGroupName
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
                        .CompareLists(_oldList, _newList,
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
                            _newList,
                            keySelector: c => (c.CdcCvxCode, c.VaccineGroupCvxCode),
                            propertyComparer: (oldItem, newItem) => oldItem.VaccineStatus == newItem.VaccineStatus && oldItem.VaccineGroupName == newItem.VaccineGroupName
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
                            _newList,
                            _emptyList,
                            keySelector: c => (c.CdcCvxCode, c.VaccineGroupCvxCode),
                            propertyComparer: (oldItem, newItem) => oldItem.VaccineStatus == newItem.VaccineStatus && oldItem.VaccineGroupName == newItem.VaccineGroupName
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
                            _oldList,
                            _oldList,
                            keySelector: c => (c.CdcCvxCode, c.VaccineGroupCvxCode),
                            propertyComparer: (oldItem, newItem) => oldItem.VaccineStatus == newItem.VaccineStatus && oldItem.VaccineGroupName == newItem.VaccineGroupName
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
        var _old = _oldList.Where(o => o.ShortDescription == "M/R" || o.ShortDescription == "rubella");
        var _new = _newList.Where(o => o.ShortDescription == "M/R" || o.ShortDescription == "rubella");


        var changes = CompareCollection<CdcCvxVaccineGroup>
                    .CompareLists(
                        _old,
                        _new,
                        keySelector: c => (c.CdcCvxCode, c.VaccineGroupCvxCode),
                        propertyComparer: (oldItem, newItem) => oldItem.VaccineStatus == newItem.VaccineStatus && oldItem.VaccineGroupName == newItem.VaccineGroupName
                     );

        Assert.That(changes.Added, Is.Empty);
        Assert.That(changes.Removed, Is.Empty);
        Assert.That(changes.Unchanged, Is.Empty);
        Assert.That(changes.Changed, Has.Exactly(2).Items);
        Assert.That(changes.Changed.Any(u => u.ShortDescription == "M/R"));
        Assert.That(changes.Changed.Any(u => u.CdcCvxCode == "06"));
    }

    [Test]
    public void GetChanges_MixedChanges()
    {
        var changes = CompareCollection<CdcCvxVaccineGroup>
                    .CompareLists(
                        _oldList,
                        _newList,
                        keySelector: c => (c.CdcCvxCode, c.VaccineGroupCvxCode),
                        propertyComparer: (oldItem, newItem) => oldItem.VaccineStatus == newItem.VaccineStatus && oldItem.VaccineGroupName == newItem.VaccineGroupName
                     );

        Assert.That(changes.Added, Has.Exactly(3).Items);
        Assert.That(changes.Added.Any(c => c.ShortDescription == "DTaP"));
        Assert.That(changes.Removed, Has.Exactly(2).Items);
        Assert.That(changes.Removed.Any(r => r.CdcCvxCode == "01"));
        Assert.That(changes.Unchanged, Has.Exactly(5).Items);
        Assert.That(changes.Unchanged.Where(u => u.VaccineStatus == "Active"), Has.Exactly(2).Items);
        Assert.That(changes.Unchanged.Where(u => u.VaccineStatus == "what"), Has.Exactly(0).Items);
        Assert.That(changes.Changed, Has.Exactly(2).Items);
        Assert.That(changes.Changed.FirstOrDefault(c => c.CdcCvxCode == "04")?.VaccineStatus, Is.EqualTo("Inactive") );
        Assert.That(changes.Changed.FirstOrDefault(c => c.CdcCvxCode == "344")?.VaccineStatus, Is.Null );

    }

}
