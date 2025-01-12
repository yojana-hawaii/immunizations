

namespace Application.Interface.Cdc;

public interface ICdcCvx
{
    /// <summary>
    /// Use GET to get data from this table
    /// Use FETCH to get data from external place to this table
    /// https://www2a.cdc.gov/vaccines/IIS/IISStandards/downloads/cvx.txt
    /// </summary>
    /// <returns></returns>
    /// 

    IEnumerable<CdcCvx> GetAll();
    CdcCvx GetByCvxCode(string cvxCode);
    void SaveChanges(List<string[]> data);
}
