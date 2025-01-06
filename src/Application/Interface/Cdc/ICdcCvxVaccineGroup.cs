namespace Application.Interface.Cdc;

public interface ICdcCvxVaccineGroup
{
    /// <summary>
    /// Use GET to get data from this table
    /// Use FETCH to get data from external place to this table
    /// https://www2a.cdc.gov/vaccines/iis/iisstandards/downloads/VG.txt
    /// </summary>
    /// <returns></returns>
    IEnumerable<CdcCvxVaccineGroup> FetchAll();
    IEnumerable<CdcCvxVaccineGroup> GetAll();
    CdcCvxVaccineGroup GetByCvxCode(string cvxCode);
}
