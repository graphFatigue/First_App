using AutoMapper;
using Sieve.Models;
using TaskBoard.Abstractions.Application;
using TaskBoard.Abstractions.Infrastructure;
using TaskBoard.Common;
using TaskBoard.Common.Exceptions;
using TaskBoard.Common.Models.Card;
using TaskBoard.Domain.Entities;
using TaskBoard.Infrastructure;

namespace TaskBoard.Application.Services
{
    public class CardService : ICardService
    {
        private readonly AppDbContext _context;
        private readonly ICardRepository _cardRepository;
        private readonly IMapper _mapper;

        public CardService(
            AppDbContext context,
            ICardRepository cardRepository,
            IMapper mapper)
        {
            _context = context;
            _cardRepository = cardRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CardModel>> GetAllAsync()
        {
            var cards = await _cardRepository.GetAllAsync();
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
            await _context.SaveChangesAsync();

            return _mapper.Map<CardModel>(card);
        }

        public async Task UpdateAsync(int id, UpdateCardModel updateCardModel)
        {
            var card = await _cardRepository.GetByIdAsync(id)
                       ?? throw new NotFoundException($"Card with id {id} was not found");

            //if (!string.IsNullOrWhiteSpace(updateCardModel.Name))
            //{
            //    club.Name = updateCardModel.Name;
            //}

            _cardRepository.Update(card);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var card = await _cardRepository.GetByIdAsync(id)
                       ?? throw new NotFoundException($"Card with id {id} was not found");

            _cardRepository.Delete(card);
            await _context.SaveChangesAsync();
        }
    }
}
