using Xunit;
using Moq;
using TaskBoard.Infrastructure;
using TaskBoard.Abstractions.Infrastructure;
using TaskBoard.Common.Models.ListCards;
using TaskBoard.Domain.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using TaskBoard.Application.Services;
using TaskBoard.Common.Exceptions;
using Npgsql;
using TaskBoard.Common.Mappings;

namespace TaskBoard.Tests.Services
{
    public class ListCardsServiceTests
    {
        private readonly AppDbContext _context;
        private readonly Mock<IListCardsRepository> _repositoryMock;
        private readonly Mock<IBoardRepository> _boardRepositoryMock;
        private readonly IMapper _mapper;
        private readonly ListCardsService _service;

        public ListCardsServiceTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _context = new AppDbContext(options);

            _repositoryMock = new Mock<IListCardsRepository>();
            _boardRepositoryMock = new Mock<IBoardRepository>();

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = mapperConfiguration.CreateMapper();

            _service = new ListCardsService(_context, _repositoryMock.Object, _mapper, _boardRepositoryMock.Object);
        }

        [Fact]
        public async Task UpdateAsync_UpdateListName_ShouldSucceed()
        {
            // Arrange
            var updateListCardsModel = new UpdateListCardsModel { Id = 1, Name = "Updated List Name" };
            var existingList = new ListCards { Id = 1, Name = "Existing List" };

            _repositoryMock.Setup(r => r.GetByIdAsync(updateListCardsModel.Id)).ReturnsAsync(existingList);

            // Act
            await _service.UpdateAsync(updateListCardsModel);
            await _context.SaveChangesAsync();

            // Assert
            Assert.Equal("Updated List Name", existingList.Name);
        }

        [Fact]
        public async Task UpdateAsync_ListNotFound_ThrowsNotFoundException()
        {
            // Arrange
            var updateListCardsModel = new UpdateListCardsModel { Id = 1, Name = "Updated List Name" };

            _repositoryMock.Setup(r => r.GetByIdAsync(updateListCardsModel.Id)).ReturnsAsync((ListCards)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.UpdateAsync(updateListCardsModel));
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllListCards()
        {
            // Arrange
            var listCards = new List<ListCards>
            {
                new ListCards { Id = 1, Name = "List 1" },
                new ListCards { Id = 2, Name = "List 2" },
                new ListCards { Id = 3, Name = "List 3" }
            };

            _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(listCards);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.Equal(listCards.Count, result.Count());
            Assert.Equal(listCards.Select(l => l.Name), result.Select(l => l.Name));
        }

        [Fact]
        public async Task GetByNameAsync_ListNotFound_ThrowsNotFoundException()
        {
            // Arrange
            var listName = "Non-existing List";

            _repositoryMock.Setup(r => r.GetByNameAsync(listName)).ReturnsAsync((ListCards)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.GetByNameAsync(listName));
        }

        [Fact]
        public async Task GetByNameAsync_ListFound_ReturnsListCardsModel()
        {
            // Arrange
            var listName = "Existing List";
            var listCards = new ListCards { Id = 1, Name = listName };

            _repositoryMock.Setup(r => r.GetByNameAsync(listName)).ReturnsAsync(listCards);

            // Act
            var result = await _service.GetByNameAsync(listName);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(listCards.Id, result.Id);
            Assert.Equal(listCards.Name, result.Name);
        }

        [Fact]
        public async Task CreateAsync_ValidModel_ShouldCreateListCards()
        {
            // Arrange
            var createListCardsModel = new CreateListCardsModel
            {
                Name = "Test List",
                BoardId = 1
            };

            var board = new Board { Id = 1, Name = "Test Board" };

            _boardRepositoryMock.Setup(r => r.GetByIdAsync(createListCardsModel.BoardId)).ReturnsAsync(board);

            // Act
            var result = await _service.CreateAsync(createListCardsModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(createListCardsModel.Name, result.Name);
            Assert.Equal(createListCardsModel.BoardId, result.BoardId);
        }

        [Fact]
        public async Task CreateAsync_InvalidBoardId_ThrowsNotFoundException()
        {
            // Arrange
            var createListCardsModel = new CreateListCardsModel
            {
                Name = "Test List",
                BoardId = 999 // Invalid board ID
            };

            _boardRepositoryMock.Setup(r => r.GetByIdAsync(createListCardsModel.BoardId)).ReturnsAsync((Board)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.CreateAsync(createListCardsModel));
        }

        [Fact]
        public async Task CreateAsync_DuplicateListName_ThrowsNpgsqlException()
        {
            // Arrange
            var createListCardsModel = new CreateListCardsModel
            {
                Name = "Existing List",
                BoardId = 1
            };

            var board = new Board { Id = 1, Name = "Test Board" };

            _boardRepositoryMock.Setup(r => r.GetByIdAsync(createListCardsModel.BoardId)).ReturnsAsync(board);

            _repositoryMock.Setup(r => r.CreateAsync(It.IsAny<ListCards>())).ThrowsAsync(new NpgsqlException());

            // Act & Assert
            await Assert.ThrowsAsync<NpgsqlException>(() => _service.CreateAsync(createListCardsModel));
        }
    }
}
