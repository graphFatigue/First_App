using Moq;
using TaskBoard.Infrastructure;
using TaskBoard.Abstractions.Infrastructure;
using TaskBoard.Common.Models.Board;
using TaskBoard.Domain.Entities;
using AutoMapper;
using TaskBoard.Application.Services;
using Microsoft.EntityFrameworkCore;
using TaskBoard.Common.Mappings;
using Npgsql;
using TaskBoard.Common.Exceptions;

namespace TaskBoard.Tests.Services
{
    public class BoardServiceTests
    {
        private readonly AppDbContext _context;
        private readonly Mock<IBoardRepository> _repositoryMock;
        private readonly IMapper _mapper;
        private readonly BoardService _service;

        public BoardServiceTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _context = new AppDbContext(options);

            _repositoryMock = new Mock<IBoardRepository>();

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile()); 
            });
            _mapper = mapperConfiguration.CreateMapper();

            _service = new BoardService(_context, _repositoryMock.Object, _mapper);
        }

        [Fact]
        public async Task CreateAsync_ValidInput_ReturnsCreatedBoard()
        {
            // Arrange
            var createBoardModel = new CreateBoardModel { Name = "Test Board" };
            var expectedBoard = new Board { Name = "Test Board" };

            _repositoryMock.Setup(r => r.CreateAsync(It.IsAny<Board>())).Verifiable();

            // Act
            var result = await _service.CreateAsync(createBoardModel);
            await _context.SaveChangesAsync();

            // Assert
            Assert.Equal("Test Board", result.Name);
        }

        [Fact]
        public async Task CreateAsync_BoardAlreadyExists_ThrowsException()
        {
            // Arrange
            var createBoardModel = new CreateBoardModel { Name = "Existing Board" };

            _repositoryMock.Setup(r => r.CreateAsync(It.IsAny<Board>())).ThrowsAsync(new NpgsqlException());

            // Act & Assert
            await Assert.ThrowsAsync<NpgsqlException>(() => _service.CreateAsync(createBoardModel));
        }

        [Fact]
        public async Task UpdateAsync_BoardExists_UpdateBoardName()
        {
            // Arrange
            var updateBoardModel = new UpdateBoardModel { Id = 1, Name = "Updated Board Name" };
            var existingBoard = new Board { Id = 1, Name = "Existing Board" };

            _repositoryMock.Setup(r => r.GetByIdAsync(updateBoardModel.Id)).ReturnsAsync(existingBoard);
            _repositoryMock.Setup(r => r.Update(It.IsAny<Board>())).Verifiable();

            // Act
            await _service.UpdateAsync(updateBoardModel);
            await _context.SaveChangesAsync();

            // Assert
            Assert.Equal("Updated Board Name", existingBoard.Name);
        }

        [Fact]
        public async Task UpdateAsync_BoardNotFound_ThrowsException()
        {
            // Arrange
            var updateBoardModel = new UpdateBoardModel { Id = 1, Name = "Updated Board Name" };

            _repositoryMock.Setup(r => r.GetByIdAsync(updateBoardModel.Id)).ReturnsAsync((Board)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.UpdateAsync(updateBoardModel));
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllBoards()
        {
            // Arrange
            var boards = new List<Board>
            {
                new Board { Id = 1, Name = "Board 1" },
                new Board { Id = 2, Name = "Board 2" },
                new Board { Id = 3, Name = "Board 3" }
            };

            _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(boards);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.Equal(boards.Count, result.Count());
            Assert.Equal(boards.Select(b => b.Name), result.Select(b => b.Name));
        }

        [Fact]
        public async Task GetByNameAsync_BoardNotFound_ThrowsNotFoundException()
        {
            // Arrange
            var boardName = "Non-existing Board";

            _repositoryMock.Setup(r => r.GetByNameAsync(boardName)).ReturnsAsync((Board)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.GetByNameAsync(boardName));
        }

        [Fact]
        public async Task GetByNameAsync_BoardFound_ReturnsBoardModel()
        {
            // Arrange
            var boardName = "Existing Board";
            var board = new Board { Id = 1, Name = boardName };

            _repositoryMock.Setup(r => r.GetByNameAsync(boardName)).ReturnsAsync(board);

            // Act
            var result = await _service.GetByNameAsync(boardName);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(board.Id, result.Id);
            Assert.Equal(board.Name, result.Name);
        }
    }
}
