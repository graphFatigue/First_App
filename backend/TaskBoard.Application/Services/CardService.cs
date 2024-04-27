using AutoMapper;
using Sieve.Models;
using TaskBoard.Abstractions.Application;
using TaskBoard.Abstractions.Infrastructure;
using TaskBoard.Common;
using TaskBoard.Common.Exceptions;
using TaskBoard.Common.Models.Card;
using TaskBoard.Domain.Entities;
using TaskBoard.Domain.Enum;
using TaskBoard.Infrastructure;
using TaskBoard.Infrastructure.Extensions;
using Action = TaskBoard.Domain.Entities.Action;

namespace TaskBoard.Application.Services
{
    public class CardService : ICardService
    {
        private readonly AppDbContext _context;
        private readonly ICardRepository _cardRepository;
        private readonly IMapper _mapper;
        private readonly IListCardsRepository _listCardsRepository;
        private readonly IActionRepository _actionRepository;

        public CardService(
            AppDbContext context,
            ICardRepository cardRepository,
            IMapper mapper,
            IListCardsRepository listCardsRepository,
            IActionRepository actionRepository)
        {
            _context = context;
            _cardRepository = cardRepository;
            _mapper = mapper;
            _listCardsRepository = listCardsRepository;
            _actionRepository = actionRepository;
        }

        public async Task<IEnumerable<CardModel>> GetAllAsync()
        {
            var cards = await _cardRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CardModel>>(cards);
        }

        public async Task<IEnumerable<CardModel>> GetAllWithoutParentListAsync()
        {
            var cards = await _cardRepository.GetAllWithoutParentListAsync();
            return _mapper.Map<IEnumerable<CardModel>>(cards);
        }

        public async Task<PagedList<CardModel>> GetAllWithFilterAsync(SieveModel sieveModel)
        {
            var pagedList = await _cardRepository.GetAllWithFilterAsync(sieveModel);
            var cardModels = _mapper.Map<IEnumerable<CardModel>>(pagedList.Items);

            var updatedPagedList = PagedList<CardModel>.Copy(pagedList, cardModels);

            return updatedPagedList;
        }

        public async Task<CardModel> GetByIdAsync(int id)
        {
            var card = await _cardRepository.GetByIdAsync(id)
                       ?? throw new NotFoundException($"Card with id {id} was not found");

            return _mapper.Map<CardModel>(card);
        }

        public async Task<CardModel> CreateAsync(CreateCardModel createCardModel)
        {
            var card = _mapper.Map<Card>(createCardModel);

            await _cardRepository.CreateAsync(card);

            Action action = new Action()
            {
                ActionTime = DateTime.Now.SetKindUtc(),
                ActionType = ActionType.Create,
                Card = card,   
            };

            await _actionRepository.CreateAsync(action);
            await _context.SaveChangesAsync();

            return _mapper.Map<CardModel>(card);
        }

        public async Task UpdateAsync(int id, UpdateCardModel updateCardModel)
        {
            var card = await _cardRepository.GetByIdAsync(id)
                       ?? throw new NotFoundException($"Card with id {id} was not found");

            if (!string.IsNullOrWhiteSpace(updateCardModel.Name))
            {
                card.Name = updateCardModel.Name;
            }

            if (!string.IsNullOrWhiteSpace(updateCardModel.Description))
            {
                card.Description = updateCardModel.Description;
            }

            if (!string.IsNullOrWhiteSpace(updateCardModel.Priority))
            {
                Enum.TryParse(updateCardModel.Priority, out Priority priority);
                card.Priority = priority;
            }

            if (updateCardModel.DueDate>=DateTime.Now&&updateCardModel.DueDate.Year<=DateTime.Now.Year+1)
            {
                card.DueDate = updateCardModel.DueDate;
            }

            if (!string.IsNullOrWhiteSpace(updateCardModel.ListCardsName))
            {
                var listCards = await _listCardsRepository.GetByNameAsync(updateCardModel.ListCardsName);
                card.ListCards = listCards;
                card.ListCardsId = listCards?.Id;
            }

            _cardRepository.Update(card);

            Action action = new Action()
            {
                ActionTime = DateTime.Now.SetKindUtc(),
                ActionType = ActionType.Update,
                Card = card,
            };

            await _actionRepository.CreateAsync(action);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var card = await _cardRepository.GetByIdAsync(id)
                       ?? throw new NotFoundException($"Card with id {id} was not found");

            _cardRepository.Delete(card);

            Action action = new Action()
            {
                ActionTime = DateTime.Now.SetKindUtc(),
                ActionType = ActionType.Delete,
                Card = card,
            };

            await _actionRepository.CreateAsync(action);
            await _context.SaveChangesAsync();
        }
    }
}
