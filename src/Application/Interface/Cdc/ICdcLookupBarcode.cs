using Domain.Models.Cdc;
namespace Application.Interface.Cdc;

public interface ICdcLookupBarcode
{
    /// <summary>
    /// Use GET to get data from this table
    /// Use FETCH to get data from external place to this table
    /// txt and xml not working https://www.cdc.gov/iis/code-sets/vis-barcode-lookup-table.
    /// pull excel file https://www.cdc.gov/iis/code-sets/downloads/vis-barcode-lookup-table.
    /// </summary>
    /// <returns></returns>
    IEnumerable<CdcLookupBarcode> GetAll();
    CdcLookupBarcode GetByCvxCode(string cvxCode);
    void UpdateFetchedData(IEnumerable<CdcLookupBarcode> fetchedBarcode);

}
