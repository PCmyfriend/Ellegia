using Microsoft.AspNetCore.Mvc;

namespace Ellegia.WebApi.Controllers
{
    public class SpaController : Controller
    {
        public IActionResult Index()
        {
            return File("~/index.html", "text/html");
        }
    }
}