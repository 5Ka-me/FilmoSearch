using AutoMapper;
using BLL.Exceptions;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using FluentValidation;

namespace BLL.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<ActorModel> _validator;

        public ActorService(IActorRepository actorRepository, IMapper mapper, IValidator<ActorModel> validator)
        {
            _actorRepository = actorRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<ActorModel> Create(ActorModel actorModel, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(actorModel, cancellationToken);

            var actor = _mapper.Map<Actor>(actorModel);

            await _actorRepository.Create(actor, cancellationToken);

            return actorModel;
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var actor = await _actorRepository.GetById(id, cancellationToken);

            if (actor == null)
            {
                throw new EntityNotFoundException("Entity actor not found");
            }

            await _actorRepository.Delete(actor, cancellationToken);
        }

        public async Task<IEnumerable<ActorModel>> GetAll(CancellationToken cancellationToken)
        {
            var actor = await _actorRepository.GetAll(cancellationToken);

            return _mapper.Map<IEnumerable<ActorModel>>(actor);
        }

        public async Task<ActorModel> GetById(int id, CancellationToken cancellationToken)
        {
            var actor = await _actorRepository.GetById(id, cancellationToken);

            if (actor == null)
            {
                throw new EntityNotFoundException("Entity actor not found");
            }

            return _mapper.Map<ActorModel>(actor);
        }

        public async Task<ActorModel> Update(ActorModel actorModel, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(actorModel, cancellationToken);

            var actor = await _actorRepository.GetById(actorModel.Id, cancellationToken);

            if (actor == null)
            {
                throw new EntityNotFoundException("Entity actor not found");
            }

            _mapper.Map(actorModel, actor);

            await _actorRepository.Update(actor, cancellationToken);

            return actorModel;
        }
    }
}
