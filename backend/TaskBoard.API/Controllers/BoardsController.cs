using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using TaskBoard.Abstractions.Application;
using TaskBoard.Common.Models.Board;

namespace TaskBoard.API.Controllers
{
    [ApiController]
    [Route("api/boards")]
    public class BoardsController : ControllerBase
    {
        private readonly IBoardService _boardService;

        public BoardsController(IBoardService boardService)
        {
            _boardService = boardService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            var boards = await _boardService.GetAllAsync();
            return Ok(boards);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWithFilter([FromQuery] SieveModel sieveModel)
        {
            var boards = await _boardService.GetAllWithFilterAsync(sieveModel);
            return Ok(boards);
        }

        [HttpGet("{id}", Name = nameof(GetBoardById))]
        public async Task<IActionResult> GetBoardById(int id)
        {
            var board = await _boardService.GetByIdAsync(id);
            return Ok(board);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBoardModel createBoardModel)
        {
            var board = await _boardService.CreateAsync(createBoardModel);
            return CreatedAtRoute(nameof(GetBoardById), new { id = board.Id }, board);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateBoardModel updateBoardModel)
        {
            await _boardService.UpdateAsync(updateBoardModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _boardService.DeleteAsync(id);
            return NoContent();
        }
    }
}
