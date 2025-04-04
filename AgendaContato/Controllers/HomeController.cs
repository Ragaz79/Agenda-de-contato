using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AgendaContato.Models;
using AgendaContato.Data;

namespace AgendaContato.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly AGENDACONTATOSContext _context;

    public HomeController(ILogger<HomeController> logger, AGENDACONTATOSContext context)
    {
        _logger = logger;
        _context = context;
    }

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Contato()
    {
        return View();
    }
    public IActionResult CriarContato()
    {
        return View();
    }


    public IActionResult TipoContato()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
