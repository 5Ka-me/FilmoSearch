using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class FilmRepository : GenericRepository<Film>, IFilmRepository
    {
        public FilmRepository(Context context)
            : base(context)
        { }
    }
}
