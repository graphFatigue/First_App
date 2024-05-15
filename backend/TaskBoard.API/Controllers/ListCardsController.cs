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

        [HttpGet("allBy/{boardId}")]
        public async Task<IActionResult> GetAllByBoardId(int boardId)
        {
            var listCards = await _listCardsService.GetAllByBoardIdAsync(boardId);
            return Ok(listCards);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWithFilter([FromQuery] SieveModel sieveModel)
        {
            var listCards = await _listCardsService.GetAllWithFilterAsync(sieveModel);
            return Ok(listCards);
        }

        [HttpGet("{id}", Name = nameof(GetListById))]
        public async Task<IActionResult> GetListById(int id)
        {
            var listCard = await _listCardsService.GetByIdAsync(id);
            return Ok(listCard);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateListCardsModel createListCardsModel)
        {
            var listCards = await _listCardsService.CreateAsync(createListCardsModel);
            return CreatedAtRoute(nameof(GetListById), new { id = listCards.Id }, listCards);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateListCardsModel updateListCardsModel)
        {
            await _listCardsService.UpdateAsync(updateListCardsModel);
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
