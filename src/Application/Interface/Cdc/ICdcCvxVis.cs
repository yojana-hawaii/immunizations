using Domain.Models.Cdc;
namespace Application.Interface.Cdc;

public interface ICdcCvxVis
{
    /// <summary>
    /// Use GET to get data from this table
    /// Use FETCH to get data from external place to this table
    /// https://www2a.cdc.gov/vaccines/iis/iisstandards/downloads/cvx_vis.txt
    /// </summary>
    /// <returns></returns>
    IEnumerable<CdcCvxVis> GetAll();
    CdcCvxVis GetByCvxCode(string cvxCode);
    void UpdateFetchedData(IEnumerable<CdcCvxVis> fetchedVis);

}
