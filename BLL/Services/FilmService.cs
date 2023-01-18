using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using FluentValidation;

namespace BLL.Services
{
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<FilmModel> _validator;

        public FilmService(IFilmRepository filmRepository, IMapper mapper, IValidator<FilmModel> validator)
        {
            _filmRepository = filmRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<FilmModel> Create(FilmModel filmModel, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(filmModel, cancellationToken);

            var film = _mapper.Map<Film>(filmModel);

            await _filmRepository.Create(film, cancellationToken);

            return _mapper.Map(film, filmModel);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var film = await _filmRepository.Get(id, cancellationToken);

            CheckNull(film);

            await _filmRepository.Delete(film, cancellationToken);
        }

        public async Task<IEnumerable<FilmModel>> Get(CancellationToken cancellationToken)
        {
            var films = await _filmRepository.Get(cancellationToken);

            return _mapper.Map<IEnumerable<FilmModel>>(films);
        }

        public async Task<FilmModel> Get(int id, CancellationToken cancellationToken)
        {
            var film = await _filmRepository.Get(id, cancellationToken);

            CheckNull(film);

            return _mapper.Map<FilmModel>(film);
        }

        public async Task<FilmModel> Update(FilmModel filmModel, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(filmModel, cancellationToken);

            var film = await _filmRepository.Get(filmModel.Id, cancellationToken);

            CheckNull(film);

            _mapper.Map(filmModel, film);

            await _filmRepository.Update(film, cancellationToken);

            return filmModel;
        }

        private void CheckNull(Film? film)
        {
            if (film == null)
            {
                throw new ArgumentNullException(nameof(film), "Film does not exist");
            }
        }
    }
}
