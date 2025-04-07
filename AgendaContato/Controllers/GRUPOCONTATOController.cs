using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AgendaContato.Models;
using AgendaContato.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgendaContato.Controllers
{
    public class GRUPOCONTATOController : Controller
    {
        private readonly ILogger<GRUPOCONTATOSController> _logger;

        private readonly AGENDACONTATOSContext _context;

        public GRUPOCONTATOController(ILogger<GRUPOCONTATOController> logger, AGENDACONTATOSContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //var grupos = _context.GRUPOCONTATOS.ToList();
            return View();
        }

    }
}
