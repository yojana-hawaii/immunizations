using Infrastructure.Repository.Cdc;
using nunittest.seed;

namespace nunittest;

[TestFixture]
class InMemoryCdcCvxRepositoryTest : AppDbContextBase
{
    private CdcCvxRepository _cvxObj;

    [SetUp]
    public void Setup()
    {
        _cvxObj = new CdcCvxRepository(_context);
    }

    [Test]
    public void GetAllCvx_Valid_ReturnCvxList()
    {
        IEnumerable<CdcCvx> cvxes = _cvxObj.GetAll();

        Assert.IsNotNull(cvxes);
        Assert.That(4, Is.EqualTo(cvxes.Count()));
        CollectionAssert.AllItemsAreUnique(cvxes);
        CollectionAssert.AllItemsAreNotNull(cvxes);

        Assert.That(cvxes.Count( c => c.CdcCvxCode == "012"), Is.EqualTo(1));
        Assert.That(cvxes.Count( c => c.CdcCvxCode == "000"), Is.EqualTo(0));
        Assert.That(cvxes.Count( c => c.CdcCvxCode == "345"), Is.EqualTo(1));

        var cdccvx = cvxes.FirstOrDefault(c => c.CdcCvxCode == "012");
        Assert.That(cdccvx.FullVaccineName, Is.EqualTo("vaccine 012"));
    }
}
