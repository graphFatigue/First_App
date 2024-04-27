using AutoMapper;
using Sieve.Models;
using TaskBoard.Abstractions.Application;
using TaskBoard.Abstractions.Infrastructure;
using TaskBoard.Common;
using TaskBoard.Common.Exceptions;
using TaskBoard.Common.Models.ListCards;
using TaskBoard.Domain.Entities;
using TaskBoard.Domain.Enum;
using TaskBoard.Infrastructure;
using TaskBoard.Infrastructure.Extensions;
using Action = TaskBoard.Domain.Entities.Action;

namespace TaskBoard.Application.Services
{
    public class ListCardsService : IListCardsService
    {
        private readonly AppDbContext _context;
        private readonly IListCardsRepository _listCardsRepository;
        private readonly IMapper _mapper;
        private readonly IActionRepository _actionRepository;

        public ListCardsService(
            AppDbContext context,
            IListCardsRepository listCardsRepository,
            IMapper mapper,
            IActionRepository actionRepository)
        {
            _context = context;
            _listCardsRepository = listCardsRepository;
            _mapper = mapper;
            _actionRepository = actionRepository;
        }
        public async Task<ListCardsModel> CreateAsync(CreateListCardsModel createListCardsModel)
        {
            var listCards = _mapper.Map<ListCards>(createListCardsModel);

            await _listCardsRepository.CreateAsync(listCards);

            Action action = new Action()
            {
                ActionTime = DateTime.Now.SetKindUtc(),
                ActionType = ActionType.Create,
                ListCards = listCards,
            };

            await _actionRepository.CreateAsync(action);

            await _context.SaveChangesAsync();

            return _mapper.Map<ListCardsModel>(listCards);
        }

        public async Task DeleteAsync(int id)
        {
            var listCards = await _listCardsRepository.GetByIdAsync(id)
           ?? throw new NotFoundException($"Cards' List with id {id} was not found");

            _listCardsRepository.Delete(listCards);

            Action action = new Action()
            {
                ActionTime = DateTime.Now.SetKindUtc(),
                ActionType = ActionType.Delete,
                ListCards = listCards,
            };

            await _actionRepository.CreateAsync(action);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ListCardsModel>> GetAllAsync()
        {
            var listCards = await _listCardsRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ListCardsModel>>(listCards);
        }

        public async Task<PagedList<ListCardsModel>> GetAllWithFilterAsync(SieveModel sieveModel)
        {
            var pagedList = await _listCardsRepository.GetAllWithFilterAsync(sieveModel);
            var listCardsModels = _mapper.Map<IEnumerable<ListCardsModel>>(pagedList.Items);

            var updatedPagedList = PagedList<ListCardsModel>.Copy(pagedList, listCardsModels);

            return updatedPagedList;
        }

        public async Task<ListCardsModel> GetByNameAsync(string name)
        {
            var listCards = await _listCardsRepository.GetByNameAsync(name)
           ?? throw new NotFoundException($"Cards' List with id {name} was not found");

            return _mapper.Map<ListCardsModel>(listCards);
        }

        public async Task UpdateAsync(int id, UpdateListCardsModel updateListCardsModel)
        {
            var listCards = await _listCardsRepository.GetByIdAsync(id)
           ?? throw new NotFoundException($"Cards' List with id {id} was not found");

            if (!string.IsNullOrWhiteSpace(updateListCardsModel.Name))
            {
                listCards.Name = updateListCardsModel.Name;
            }

            _listCardsRepository.Update(listCards);

            Action action = new Action()
            {
                ActionTime = DateTime.Now.SetKindUtc(),
                ActionType = ActionType.Update,
                ListCards = listCards,
            };

            await _actionRepository.CreateAsync(action);
            await _context.SaveChangesAsync();
        }
    }
}
