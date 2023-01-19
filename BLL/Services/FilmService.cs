using AutoMapper;
using BLL.Exceptions;
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
            var film = await _filmRepository.GetById(id, cancellationToken);

            if (film == null)
            {
                throw new EntityNotFoundException($"Film with Id: {id} not found");
            }

            await _filmRepository.Delete(film, cancellationToken);
        }

        public async Task<IEnumerable<FilmModel>> GetAll(CancellationToken cancellationToken)
        {
            var films = await _filmRepository.GetAll(cancellationToken);

            return _mapper.Map<IEnumerable<FilmModel>>(films);
        }

        public async Task<FilmModel> GetById(int id, CancellationToken cancellationToken)
        {
            var film = await _filmRepository.GetById(id, cancellationToken);

            if (film == null)
            {
                throw new EntityNotFoundException($"Film with Id: {id} not found");
            }

            return _mapper.Map<FilmModel>(film);
        }

        public async Task<FilmModel> Update(FilmModel filmModel, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(filmModel, cancellationToken);

            var film = await _filmRepository.GetById(filmModel.Id, cancellationToken);

            if (film == null)
            {
                throw new EntityNotFoundException($"Film with Id: {filmModel.Id} not found");
            }

            _mapper.Map(filmModel, film);

            await _filmRepository.Update(film, cancellationToken);

            return filmModel;
        }
    }
}
