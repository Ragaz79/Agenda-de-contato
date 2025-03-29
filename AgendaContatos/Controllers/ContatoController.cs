using Microsoft.AspNetCore.Mvc;

namespace AgendaContatos.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
