using BLL.Models;

namespace BLL.Interfaces
{
    public interface IActorService
    {
        Task<IEnumerable<ActorModel>> Get(CancellationToken cancellationToken);
        Task<ActorModel> Get(int id, CancellationToken cancellationToken);
        Task<ActorModel> Create(ActorModel actor, CancellationToken cancellationToken);
        Task<ActorModel> Update(ActorModel actor, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
    }
}
