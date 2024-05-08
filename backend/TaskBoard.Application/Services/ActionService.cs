using AutoMapper;
using Sieve.Models;
using TaskBoard.Abstractions.Application;
using TaskBoard.Abstractions.Infrastructure;
using TaskBoard.Common;
using TaskBoard.Common.Exceptions;
using TaskBoard.Common.Models.Action;
using TaskBoard.Common.Models.Card;
using TaskBoard.Infrastructure;

namespace TaskBoard.Application.Services
{
    public class ActionService : IActionService
    {
        private readonly AppDbContext _context;
        private readonly IActionRepository _actionRepository;
        private readonly IMapper _mapper;

        public ActionService(
            AppDbContext context,
            IActionRepository actionRepository,
            IMapper mapper)
        {
            _context = context;
            _actionRepository = actionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ActionModel>> GetAllAsync()
        {
            var actions = await _actionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ActionModel>>(actions);
        }

        public async Task<IEnumerable<ActionModel>> GetAllByCardIdAsync(int cardId)
        {
            var actions = await _actionRepository.GetAllByCardIdAsync(cardId)
                ?? throw new NotFoundException($"Card with id {cardId} was not found");
            return _mapper.Map<IEnumerable<ActionModel>>(actions);
        }

        public async Task<PagedList<ActionModel>> GetAllWithFilterAsync(SieveModel sieveModel)
        {
            var pagedList = await _actionRepository.GetAllWithFilterAsync(sieveModel);
            var actionModels = _mapper.Map<IEnumerable<ActionModel>>(pagedList.Items);

            var updatedPagedList = PagedList<ActionModel>.Copy(pagedList, actionModels);

            return updatedPagedList;
        }
    }
}
