using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using TaskBoard.Abstractions.Application;
using TaskBoard.Common.Models.ListCards;

namespace TaskBoard.API.Controllers
{
    [ApiController]
    [Route("api/listCards")]
    public class ListCardsController : ControllerBase
    {
        private readonly IListCardsService _listCardsService;

        public ListCardsController(IListCardsService listCardsService)
        {
            _listCardsService = listCardsService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            var listCards = await _listCardsService.GetAllAsync();
            return Ok(listCards);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWithFilter([FromQuery] SieveModel sieveModel)
        {
            var listCards = await _listCardsService.GetAllWithFilterAsync(sieveModel);
            return Ok(listCards);
        }

        [HttpGet("{id}", Name = nameof(GetByName))]
        public async Task<IActionResult> GetByName(string name)
        {
            var listCard = await _listCardsService.GetByNameAsync(name);
            return Ok(listCard);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateListCardsModel createCardModel)
        {
            var listCards = await _listCardsService.CreateAsync(createCardModel);
            return CreatedAtRoute(nameof(GetByName), new { id = listCards.Id }, listCards);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateListCardsModel updateListCardsModel)
        {
            await _listCardsService.UpdateAsync(id, updateListCardsModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _listCardsService.DeleteAsync(id);
            return NoContent();
        }
    }
}
