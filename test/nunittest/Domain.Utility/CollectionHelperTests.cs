using Domain.Utility.CollectionHelper;

namespace nunittest;

[TestFixture]
public class CollectionHelperTests
{
    private List<CdcCvxVaccineGroup> _oldList;
    private List<CdcCvxVaccineGroup> _newList;

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


}
