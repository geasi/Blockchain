using Blockchain.Hub;
using Microsoft.AspNetCore.Mvc;

namespace Blockchain.Hubs.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Ok("Hello!!!");
        }
    }
}