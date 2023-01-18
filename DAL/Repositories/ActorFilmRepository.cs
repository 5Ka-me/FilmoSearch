using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ActorFilmRepository : IActorFilmRepository
    {
        protected Context _context;
        private readonly DbSet<ActorFilm> _dbSet;

        public ActorFilmRepository(Context context)
        {
            _context = context;
            _dbSet = _context.Set<ActorFilm>();
        }

        public async Task Create(ActorFilm actorFilm, CancellationToken cancellationToken)
        {
            _dbSet.Add(actorFilm);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(ActorFilm actorFilm, CancellationToken cancellationToken)
        {
            _dbSet.Remove(actorFilm);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<ActorFilm> Get(int ActorId, int FilmId, CancellationToken cancellationToken)
        {
            return await _dbSet.FindAsync(new object[] { ActorId, FilmId }, cancellationToken);
        }
    }
}
