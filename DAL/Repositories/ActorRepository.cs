using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class ActorRepository : GenericRepository<Actor>, IActorRepository
    {
        public ActorRepository(ApplicationContext context)
            : base(context)
        { }
    }
}
