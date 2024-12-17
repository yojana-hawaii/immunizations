
namespace Infrastructure.CdcRepository
{
    public class CdcLookupNdcRepository : ICdcLookupNdc
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        /// 

        private readonly InventoryDbContext _dbContext;
        public CdcLookupNdcRepository(InventoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<CdcLookupNdc> FetchAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CdcLookupNdc> GetAll()
        {
            return _dbContext.CdcLookupNdcs;
        }

        public CdcLookupNdc GetByCvxCode(string cvxCode)
        {
            if (string.IsNullOrWhiteSpace(cvxCode)) { throw new ArgumentNullException(nameof(cvxCode)); }
            var _ndc = _dbContext.CdcLookupNdcs.FirstOrDefault( n => n.CdcCvxCode == cvxCode );
            if (_ndc == null) { throw new NullReferenceException(nameof(cvxCode)); }
            return _ndc;
        }
    }
}
