using BLL.Models;

namespace BLL.Interfaces
{
    public interface IFilmService
    {
        Task<IEnumerable<FilmModel>> GetAll(CancellationToken cancellationToken);
        Task<FilmModel> GetById(int id, CancellationToken cancellationToken);
        Task<FilmModel> Create(FilmModel film, CancellationToken cancellationToken);
        Task<FilmModel> Update(FilmModel film, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
    }
}
