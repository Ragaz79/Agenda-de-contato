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

    //public HomeController(ILogger<HomeController> logger)
    //{
    //    _logger = logger;
    //}

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Contato()
    {
        var todoContatos = _context.CONTATOS.ToList();
        return View(todoContatos);
    }
    public IActionResult CriarContato(int? id)
    {
        if (id != null)
        {
            //editing -> load an expense by id
            var contatoInDb = _context.CONTATOS.SingleOrDefault(contato => contato.CONTATO_COD == id); //SingleOrDefault(expense => expense.Id == id) é um link query que vai na tabela é pega o primeira id que combina com o id passado que no caso é o primeiro expenseve demonstrado
            return View(contatoInDb);
        }
        return View();
    }

    public IActionResult DeletaContato(int id)
    {
        var contatoInDb = _context.CONTATOS.SingleOrDefault(expense => expense.CONTATO_COD == id);
        _context.CONTATOS.Remove(contatoInDb);
        _context.SaveChanges();
        return RedirectToAction("Contatos");
    }
    public IActionResult CriarContatoForm(CONTATO model)
    {
        if (model.CONTATO_COD == 0)
        {
            //Create
            _context.CONTATOS.Add(model);
        }
        else
        {
            //Editing
            _context.CONTATOS.Update(model);
        }

        _context.SaveChanges();
        return RedirectToAction("Contato");
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
