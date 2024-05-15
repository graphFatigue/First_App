using Xunit;
using Moq;
using TaskBoard.Infrastructure;
using TaskBoard.Abstractions.Infrastructure;
using TaskBoard.Domain.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskBoard.Application.Services;
using TaskBoard.Common.Exceptions;
using TaskBoard.Common.Models.Card;
using TaskBoard.Domain.Enum;
using TaskBoard.Common.Mappings;

namespace TaskBoard.Tests.Services
{
    public class CardServiceTests
    {
        private readonly AppDbContext _context;
        private readonly Mock<ICardRepository> _repositoryMock;
        private readonly Mock<IListCardsRepository> _listCardsRepositoryMock;
        private readonly Mock<IActionRepository> _actionRepositoryMock;
        private readonly Mock<IBoardRepository> _boardRepositoryMock;
        private readonly IMapper _mapper;
        private readonly CardService _service;

        public CardServiceTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _context = new AppDbContext(options);

            _repositoryMock = new Mock<ICardRepository>();
            _listCardsRepositoryMock = new Mock<IListCardsRepository>();
            _actionRepositoryMock = new Mock<IActionRepository>();
            _boardRepositoryMock = new Mock<IBoardRepository>();

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = mapperConfiguration.CreateMapper();

            _service = new CardService(_context, _repositoryMock.Object, _mapper,
                _listCardsRepositoryMock.Object, _actionRepositoryMock.Object, _boardRepositoryMock.Object);
        }

        [Fact]
        public async Task UpdateAsync_UpdateCardName_ShouldSucceed()
        {
            // Arrange
            var updateCardModel = new UpdateCardModel { Id = 1, Name = "Updated Card Name" };
            var existingCard = new Card { Id = 1, Name = "Existing Card", ListCards = new ListCards() };

            _repositoryMock.Setup(r => r.GetByIdAsync(updateCardModel.Id)).ReturnsAsync(existingCard);

            // Act
            await _service.UpdateAsync(updateCardModel);
            await _context.SaveChangesAsync();

            // Assert
            Assert.Equal("Updated Card Name", existingCard.Name);
        }

        [Fact]
        public async Task UpdateAsync_UpdateCardDescription_ShouldSucceed()
        {
            // Arrange
            var updateCardModel = new UpdateCardModel { Id = 1, Description = "Updated Card Description" };
            var existingCard = new Card { Id = 1, Name = "Existing Card", ListCards = new ListCards() };

            _repositoryMock.Setup(r => r.GetByIdAsync(updateCardModel.Id)).ReturnsAsync(existingCard);

            // Act
            await _service.UpdateAsync(updateCardModel);
            await _context.SaveChangesAsync();

            // Assert
            Assert.Equal("Updated Card Description", existingCard.Description);
        }

        [Fact]
        public async Task UpdateAsync_MoveCardToListListNotFound_ThrowsException()
        {
            // Arrange
            var updateCardModel = new UpdateCardModel { Id = 1, ListCardsName = "Non-existing List" };
            var existingCard = new Card { Id = 1, Name = "Existing Card", ListCards = new ListCards() };

            _repositoryMock.Setup(r => r.GetByIdAsync(updateCardModel.Id)).ReturnsAsync(existingCard);
            _listCardsRepositoryMock.Setup(r => r.GetByNameAsync(updateCardModel.ListCardsName)).ReturnsAsync((ListCards)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.UpdateAsync(updateCardModel));
        }

        [Fact]
        public async Task UpdateAsync_UpdateDueDateAndPriority_ShouldSucceed()
        {
            // Arrange
            var updateCardModel = new UpdateCardModel
            {
                Id = 1,
                DueDate = DateTime.Now.AddDays(5), // New due date
                Priority = Priority.High.ToString() // New priority
            };
            var existingCard = new Card { Id = 1, Name = "Existing Card", DueDate = DateTime.Now, Priority = Priority.Low, ListCards = new ListCards() };

            _repositoryMock.Setup(r => r.GetByIdAsync(updateCardModel.Id)).ReturnsAsync(existingCard);

            // Act
            await _service.UpdateAsync(updateCardModel);
            await _context.SaveChangesAsync();

            // Assert
            Assert.Equal(updateCardModel.DueDate, existingCard.DueDate);
            Assert.Equal(Priority.High, existingCard.Priority);
        }

        [Fact]
        public async Task DeleteAsync_CardExists_ShouldDeleteSuccessfully()
        {
            // Arrange
            var cardId = 1;
            var existingCard = new Card { Id = cardId, Name = "Existing Card", ListCards = new ListCards() };

            _repositoryMock.Setup(r => r.GetByIdAsync(cardId)).ReturnsAsync(existingCard);

            // Act
            await _service.DeleteAsync(cardId);
            await _context.SaveChangesAsync();

            // Assert
            _repositoryMock.Verify(r => r.Delete(existingCard), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_CardNotFound_ThrowsNotFoundException()
        {
            // Arrange
            var cardId = 1;

            _repositoryMock.Setup(r => r.GetByIdAsync(cardId)).ReturnsAsync((Card)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.DeleteAsync(cardId));
        }

    }
}
