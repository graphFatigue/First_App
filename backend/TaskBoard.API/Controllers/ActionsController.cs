using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using TaskBoard.Abstractions.Application;

namespace TaskBoard.API.Controllers
{
    [ApiController]
    [Route("api/actions")]
    public class ActionsController : ControllerBase
    {
        private readonly IActionService _actionService;

        public ActionsController(IActionService actionService)
        {
            _actionService = actionService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            var actions = await _actionService.GetAllAsync();
            return Ok(actions);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWithFilter([FromQuery] SieveModel sieveModel)
        {
            var actions = await _actionService.GetAllWithFilterAsync(sieveModel);
            return Ok(actions);
        }
    }
}
