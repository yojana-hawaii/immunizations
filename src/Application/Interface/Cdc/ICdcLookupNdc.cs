namespace Application.Interface.Cdc;

public interface ICdcLookupNdc
{
    /// <summary>
    /// Use GET to get data from this table
    /// Use FETCH to get data from external place to this table
    /// https://www2a.cdc.gov/vaccines/iis/iisstandards/downloads/NDC/get_all_ndc_display2.txt
    /// </summary>
    /// <returns></returns>
    IEnumerable<CdcLookupNdc> GetAll();
    CdcLookupNdc GetByCvxCode(string cvxCode);
    void SaveChanges(List<string[]> data);

}

