using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using TaskBoard.Common.Models.Board;
using TaskBoard.Domain.Entities;

namespace TaskBoard.Tests.IntegrationTests.Controllers
{
    public class BoardsControllerTests
    {
        private readonly HttpClient _client;
        private readonly TaskBoardWebApplicationFactory _factory;

        public BoardsControllerTests()
        {
            _factory = new TaskBoardWebApplicationFactory();
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task CreateAsync_ValidInput()
        {
            // Arrange
            CreateBoardModel board = new CreateBoardModel { Name = "New Board" };

            // Act
            var response = await _client.PostAsJsonAsync("/api/boards", board);

            // Assert
            response.EnsureSuccessStatusCode();
            var createdBoard = await response.Content.ReadFromJsonAsync<Board>();
            createdBoard.Should().NotBeNull();
            createdBoard.Id.Should().BeGreaterThan(0);

            var locationHeader = response.Headers.Location;
            locationHeader.Should().NotBeNull();
            locationHeader!.ToString().Should().Contain("/api/boards/");
        }

        [Fact]
        public async Task CreateAsync_BoardAlreadyExists_BadRequest()
        {
            // Arrange
            CreateBoardModel board = new CreateBoardModel { Name = "My board" };

            // Act
            var response = await _client.PostAsJsonAsync("/api/boards", board);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest); // Status Code 400

            var errorContent = await response.Content.ReadAsStringAsync();
            errorContent.Should().NotBeNullOrEmpty();

            errorContent.Should().Contain("already exists");
        }

        [Fact]
        public async Task UpdateAsync_ValidInput_BoardAlreadyExists_BadRequest()
        {
            // Arrange
            UpdateBoardModel boardUpdate = new UpdateBoardModel { Id = 1, Name = "My board" };

            // Act
            var response = await _client.PutAsJsonAsync("/api/boards", boardUpdate);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest); // Status Code 400

            var errorContent = await response.Content.ReadAsStringAsync();
            errorContent.Should().NotBeNullOrEmpty();

            errorContent.Should().Contain("already exists");
        }

        [Fact]
        public async Task UpdateAsync_ValidInput()
        {
            // Arrange
            UpdateBoardModel boardUpdate = new UpdateBoardModel { Id = 1, Name = "Updated Board Name" };

            // Act
            var response = await _client.PutAsJsonAsync("/api/boards", boardUpdate);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent); // Status Code 204
        }

        [Fact]
        public async Task DeleteAsync_ExistingBoard_DeletesSuccessfully()
        {
            // Arrange
            CreateBoardModel boardToCreate = new CreateBoardModel { Name = "BoardToDelete" };
            var createResponse = await _client.PostAsJsonAsync("/api/boards", boardToCreate);
            createResponse.EnsureSuccessStatusCode();
            var createdBoard = await createResponse.Content.ReadFromJsonAsync<Board>();

            // Act 
            var deleteResponse = await _client.DeleteAsync($"/api/boards/{createdBoard.Id}");

            // Assert
            deleteResponse.StatusCode.Should().Be(HttpStatusCode.NoContent); // Status Code 204

            var getResponse = await _client.GetAsync($"/api/boards/{createdBoard.Id}");
            getResponse.StatusCode.Should().Be(HttpStatusCode.NotFound); // Status Code 404
        }

        [Fact]
        public async Task DeleteAsync_NonExistingBoard_ReturnsNotFound()
        {
            // Arrange 
            int nonExistentId = 999999;

            // Act 
            var response = await _client.DeleteAsync($"/api/boards/{nonExistentId}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound); // Status Code 404
        }
    }
}
