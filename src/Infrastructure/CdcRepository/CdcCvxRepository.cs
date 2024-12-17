
namespace Infrastructure.CdcRepository
{
    public class CdcCvxRepository : ICdcCvx
    {
        /// <summary>
        /// <inheritdoc />
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        /// 

        private readonly InventoryDbContext _dbContext;

        public CdcCvxRepository(InventoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CdcCvx> FetchAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CdcCvx> GetAll()
        {
            return _dbContext.CdcCvxes;
        }

        public CdcCvx GetByCvxCode(string cvxCode)
        {
            if (string.IsNullOrWhiteSpace(cvxCode)) { throw new ArgumentNullException(nameof(cvxCode)); }
            var _cdcCvx = _dbContext.CdcCvxes.FirstOrDefault(c => c.CdcCvxCode == cvxCode);
            if (_cdcCvx == null) { throw new NullReferenceException(nameof(cvxCode)); }
            return _cdcCvx;
        }
    }
}
