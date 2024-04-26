using Microsoft.AspNetCore.Mvc;

namespace TaskBoard.API.Controllers
{
    public class ListCardsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
