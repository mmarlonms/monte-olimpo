using MonteOlimpo.Base.Core.Data.Repository;
using MonteOlimpo.Base.Core.Domain.UnitOfWork;
using MonteOlimpo.Domain.Models;
using MonteOlimpo.Domain.Repository;

namespace MonteOlimpo.Repository
{
    public class GodRepository : BaseRepository<God>, IGodRepository
    {
        public GodRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}