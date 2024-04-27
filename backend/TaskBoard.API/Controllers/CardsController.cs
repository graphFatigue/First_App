using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using TaskBoard.Abstractions.Application;
using TaskBoard.Common.Models.Card;

namespace TaskBoard.API.Controllers
{
    [ApiController]
    [Route("api/cards")]
    public class CardsController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardsController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            var cards = await _cardService.GetAllAsync();
            return Ok(cards);
        }

        [HttpGet("allWithoutParentList")]
        public async Task<IActionResult> GetAllWithoutParentList()
        {
            var cards = await _cardService.GetAllWithoutParentListAsync();
            return Ok(cards);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWithFilter([FromQuery] SieveModel sieveModel)
        {
            var cards = await _cardService.GetAllWithFilterAsync(sieveModel);
            return Ok(cards);
        }

        [HttpGet("{id}", Name = nameof(GetById))]
        public async Task<IActionResult> GetById(int id)
        {
            var card = await _cardService.GetByIdAsync(id);
            return Ok(card);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCardModel createCardModel)
        {
            var card = await _cardService.CreateAsync(createCardModel);
            return CreatedAtRoute(nameof(GetById), new { id = card.Id }, card);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateCardModel updateCardModel)
        {
            await _cardService.UpdateAsync(id, updateCardModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _cardService.DeleteAsync(id);
            return NoContent();
        }
    }
}
