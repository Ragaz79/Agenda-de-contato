using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AgendaContato.Models;
using AgendaContato.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        ViewBag.Tipos = new SelectList(_context.TIPOCONTATOS.ToList(), "TIPO_COD", "NOME_TIPO");

        if (id != null)
        {
            var contatoInDb = _context.CONTATOS.SingleOrDefault(contato => contato.CONTATO_COD == id);
            return View(contatoInDb);
        }

        return View(new CONTATO());
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
        // Verificar se o TIPO_COD é válido (existe no banco)
        bool tipoExiste = _context.TIPOCONTATOS.Any(t => t.TIPO_COD == model.TIPO_COD);
        if (!tipoExiste)
        {
            ModelState.AddModelError("TIPO_COD", "Tipo de contato inválido.");
            return View("CriarContato", model);
        }

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
