namespace Application.Interface.Cdc;

public interface ICdcManufacturer
{
    /// <summary>
    /// Use GET to get data from this table
    /// Use FETCH to get data from external place to this table
    /// https://www2a.cdc.gov/vaccines/iis/iisstandards/downloads/mvx.txt
    /// </summary>
    /// <returns></returns>
    IEnumerable<CdcManufacturer> FetchAll();
    IEnumerable<CdcManufacturer> GetAll();
    CdcManufacturer GetByMvxCode(string mvxCode);
}
