namespace Application.Interface.Cdc
{
    public interface ICdcCvxCpt
    {
        /// <summary>
        /// Use GET to get data from this table
        /// Use FETCH to get data from external place to this table
        /// https://www2a.cdc.gov/vaccines/iis/iisstandards/downloads/cpt.txt
        /// </summary>
        /// <returns></returns>
        IEnumerable<CdcCvxCpt> GetAll();
        CdcCvxCpt GetByCvxCode(string cvxCode);
        void SaveChanges(List<string[]> data);

    }
}
