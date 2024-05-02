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
            var listCards = await _listCardsRepository.GetByNameAsync(createCardModel.ListCardsName);

            var card = _mapper.Map<Card>(createCardModel);

            card.ListCards = listCards;

            await _cardRepository.CreateAsync(card);

            Action action = new Action()
            {
                ActionTime = DateTime.Now.SetKindUtc(),
                Message = new string($"You added {card.Name} to {card.ListCards.Name}"),
                Card = card,   
            };

            await _actionRepository.CreateAsync(action);
            await _context.SaveChangesAsync();

            return _mapper.Map<CardModel>(card);
        }

        public async Task UpdateAsync(UpdateCardModel updateCardModel)
        {
            var card = await _cardRepository.GetByIdAsync(updateCardModel.Id)
                       ?? throw new NotFoundException($"Card with id {updateCardModel.Id} was not found");

            if (!string.IsNullOrWhiteSpace(updateCardModel.Name)&&updateCardModel.Name!=card.Name)
            {
                Action action = new Action()
                {
                    ActionTime = DateTime.Now.SetKindUtc(),
                    Message = new string($"You renamed card {card.Name} to {updateCardModel.Name}"),
                    Card = card,
                };

                await _actionRepository.CreateAsync(action);

                card.Name = updateCardModel.Name;
            }

            if (!string.IsNullOrWhiteSpace(updateCardModel.Description)&&updateCardModel.Description!=card.Description)
            {
                Action action = new Action()
                {
                    ActionTime = DateTime.Now.SetKindUtc(),
                    Message = new string($"You changed {card.Name}'s description"),
                    Card = card,
                };

                await _actionRepository.CreateAsync(action);

                card.Description = updateCardModel.Description;
            }

            if (!string.IsNullOrWhiteSpace(updateCardModel.Priority)&&updateCardModel.Priority!=card.Priority.ToString())
            {
                Action action = new Action()
                {
                    ActionTime = DateTime.Now.SetKindUtc(),
                    Message = new string($"You changed the priority of {card.Name} from {card.Priority.ToString()} to {updateCardModel.Priority}"),
                    Card = card,
                };

                await _actionRepository.CreateAsync(action);

                Enum.TryParse(updateCardModel.Priority, out Priority priority);
                card.Priority = priority;
            }

            if (updateCardModel.DueDate>=DateTime.Now&&updateCardModel.DueDate.Year<=DateTime.Now.Year+1&&card.DueDate!=updateCardModel.DueDate)
            {
                Action action = new Action()
                {
                    ActionTime = DateTime.Now.SetKindUtc(),
                    Message = new string($"You changed the due date of {card.Name} from {card.DueDate.ToLongDateString()} to {updateCardModel.DueDate.ToLongDateString()}"),
                    Card = card,
                };

                await _actionRepository.CreateAsync(action);

                card.DueDate = updateCardModel.DueDate;
            }

            if (!string.IsNullOrWhiteSpace(updateCardModel.ListCardsName)&&updateCardModel.ListCardsName!=card?.ListCards?.Name)
            {
                var listCards = await _listCardsRepository.GetByNameAsync(updateCardModel.ListCardsName)
                    ?? throw new NotFoundException($"List with cards with name {updateCardModel.ListCardsName} was not found");

                Action action = new Action()
                {
                    ActionTime = DateTime.Now.SetKindUtc(),
                    Message = new string($"You moved {card.Name} from {card.ListCards?.Name} to {updateCardModel.ListCardsName}"),
                    Card = card,
                };

                await _actionRepository.CreateAsync(action);

                card.ListCards = listCards;
                card.ListCardsId = listCards.Id;
            }

            _cardRepository.Update(card);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var card = await _cardRepository.GetByIdAsync(id)
                       ?? throw new NotFoundException($"Card with id {id} was not found");

            Action action = new Action()
            {
                ActionTime = DateTime.Now.SetKindUtc(),
                Message = new string($"You deleted card {card.Name} from {card.ListCards.Name}" )
            };

            _cardRepository.Delete(card);

            await _actionRepository.CreateAsync(action);
            await _context.SaveChangesAsync();
        }
    }
}
