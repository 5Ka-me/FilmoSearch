using BLL.Models;

namespace BLL.Interfaces
{
    public interface IActorService
    {
        Task<IEnumerable<ActorModel>> GetAll(CancellationToken cancellationToken);
        Task<ActorModel> GetById(int id, CancellationToken cancellationToken);
        Task<ActorModel> Create(ActorModel actor, CancellationToken cancellationToken);
        Task<ActorModel> Update(ActorModel actor, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
    }
}
