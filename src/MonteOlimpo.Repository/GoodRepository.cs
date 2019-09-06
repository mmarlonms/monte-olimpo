using MonteOlimpo.Base.Core.Data.Repository;
using MonteOlimpo.Base.Core.Domain.UnitOfWork;
using MonteOlimpo.Domain.Models;
using MonteOlimpo.Domain.Repository;

namespace MonteOlimpo.Repository
{
    public class GoodRepository : BaseRepository<Good>, IGoodRepository
    {
        public GoodRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}