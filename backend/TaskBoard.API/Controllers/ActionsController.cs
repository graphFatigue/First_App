using Microsoft.AspNetCore.Mvc;

namespace TaskBoard.API.Controllers
{
    public class ActionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
