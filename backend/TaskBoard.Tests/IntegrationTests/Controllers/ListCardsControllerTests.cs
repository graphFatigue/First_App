using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using TaskBoard.Common.Models.ListCards;
using TaskBoard.Domain.Entities;
using Xunit;

namespace TaskBoard.Tests.IntegrationTests.Controllers
{
    public class ListCardsControllerTests
    {
        private readonly HttpClient _client;
        private readonly TaskBoardWebApplicationFactory _factory;

        public ListCardsControllerTests()
        {
            _factory = new TaskBoardWebApplicationFactory();
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task CreateAsync_ValidInput()
        {
            // Arrange
            CreateListCardsModel listCards = new CreateListCardsModel { Name = "New List Cards", BoardId = 1 };

            // Act
            var response = await _client.PostAsJsonAsync("/api/listCards", listCards);

            // Assert
            response.EnsureSuccessStatusCode();
            var createdListCards = await response.Content.ReadFromJsonAsync<ListCards>();
            createdListCards.Should().NotBeNull();
            createdListCards.Id.Should().BeGreaterThan(0);

            var locationHeader = response.Headers.Location;
            locationHeader.Should().NotBeNull();
            locationHeader!.ToString().Should().Contain("/api/listCards/");
        }

        [Fact]
        public async Task UpdateAsync_ValidInput()
        {
            // Arrange
            UpdateListCardsModel listCardsUpdate = new UpdateListCardsModel { Id = 1, Name = "Updated List Cards" };

            // Act
            var response = await _client.PutAsJsonAsync("/api/listCards", listCardsUpdate);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent); // Status Code 204
        }

        [Fact]
        public async Task DeleteAsync_ExistingListCards_DeletesSuccessfully()
        {
            // Arrange 
            CreateListCardsModel listCardsToCreate = new CreateListCardsModel { Name = "ListCardsToDelete", BoardId = 1 };
            var createResponse = await _client.PostAsJsonAsync("/api/listCards", listCardsToCreate);
            createResponse.EnsureSuccessStatusCode();
            var createdListCards = await createResponse.Content.ReadFromJsonAsync<ListCards>();

            // Act
            var deleteResponse = await _client.DeleteAsync($"/api/listCards/{createdListCards.Id}");

            // Assert
            deleteResponse.StatusCode.Should().Be(HttpStatusCode.NoContent); // Status Code 204

            var getResponse = await _client.GetAsync($"/api/listCards/{createdListCards.Id}");
            getResponse.StatusCode.Should().Be(HttpStatusCode.NotFound); // Status Code 404
        }

        [Fact]
        public async Task DeleteAsync_NonExistingListCards_ReturnsNotFound()
        {
            // Arrange 
            int nonExistentId = 999999;

            // Act
            var response = await _client.DeleteAsync($"/api/listCards/{nonExistentId}");

            // Assert 
            response.StatusCode.Should().Be(HttpStatusCode.NotFound); // Status Code 404
        }

        [Fact]
        public async Task CreateAsync_ListCardsAlreadyExists_BadRequest()
        {
            // Arrange
            CreateListCardsModel listCards = new CreateListCardsModel { Name = "Planned", BoardId = 1 };

            // Act
            var response = await _client.PostAsJsonAsync("/api/listCards", listCards);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest); // Status Code 400

            var errorContent = await response.Content.ReadAsStringAsync();
            errorContent.Should().NotBeNullOrEmpty();
            errorContent.Should().Contain("already exists");
        }

        [Fact]
        public async Task UpdateAsync_ListCardsAlreadyExists_BadRequest()
        {
            // Arrange
            UpdateListCardsModel listCardsUpdate = new UpdateListCardsModel { Id = 1, Name = "To Do" };

            // Act
            var response = await _client.PutAsJsonAsync("/api/listCards", listCardsUpdate);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest); // Status Code 400

            var errorContent = await response.Content.ReadAsStringAsync();
            errorContent.Should().NotBeNullOrEmpty();
            errorContent.Should().Contain("already exists");
        }
    }
}
