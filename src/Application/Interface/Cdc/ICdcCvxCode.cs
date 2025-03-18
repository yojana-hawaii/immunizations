

using Domain.Models.Cdc;

namespace Application.Interface.Cdc;

public interface ICdcCvxCode
{
    /// <summary>
    /// Use GET to get data from this table
    /// Use FETCH to get data from external place to this table
    /// https://www2a.cdc.gov/vaccines/IIS/IISStandards/downloads/cvx.txt
    /// </summary>
    /// <returns></returns>
    /// 

    IEnumerable<CdcCvxCode> GetAll();
    CdcCvxCode GetByCvxCode(string cvxCode);
    void UpdateFetchedData(IEnumerable<CdcCvxCode> fetchedCvx);
}
