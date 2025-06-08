using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AgendaContato.Models;
using AgendaContato.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using X.PagedList.Extensions;

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

    public IActionResult Index(int? page)
    {
        int pageSize = 3;
        int pageNumber = page ?? 1;

        var contatos = _context.CONTATOS
            .Include(c => c.TIPOCONTATO)
            .OrderBy(c => c.CONTATO_COD)
            .ToPagedList(pageNumber, pageSize);

        return View(contatos);
    }

    public IActionResult Contato()
    {
        var todoContatos = _context.CONTATOS.ToList();
        return View(todoContatos);
    }

    public IActionResult CriarContato(int? id)
    {
        ViewBag.Tipos = new SelectList(_context.TIPOCONTATOS.ToList(), "TIPO_COD", "TIPO_NOME");

        if (id != null)
        {
            var contatoInDb = _context.CONTATOS.SingleOrDefault(contato => contato.CONTATO_COD == id);
            return View(contatoInDb);
        }

        return View(new CONTATO());
    }

    public IActionResult DeletaContato(int id)
    {
        var contatoInDb = _context.CONTATOS.SingleOrDefault(contato => contato.CONTATO_COD == id);
        _context.CONTATOS.Remove(contatoInDb);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult CriarContatoForm(CONTATO model)
    {
        bool tipoExiste = _context.TIPOCONTATOS.Any(t => t.TIPO_COD == model.TIPO_COD);

        if (model.CONTATO_COD == 0)
        {
            _context.CONTATOS.Add(model);
        }
        else
        {
            _context.CONTATOS.Update(model);
        }

        _context.SaveChanges();
        return RedirectToAction("Index");
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


    private bool MarcarComoFavorito(int contatoCod)
    {
        var contato = _context.CONTATOS.FirstOrDefault(c => c.CONTATO_COD == contatoCod);
        if (contato == null) return false;

        contato.CONTATO_FAVORITO = true;
        _context.SaveChanges();
        return true;
    }

    [HttpPost]  // Certifique-se de que a ação aceita um POST, já que você está fazendo uma requisição para modificar o banco
    public IActionResult FavoritoContato(int id)
    {
        var contato = _context.CONTATOS.FirstOrDefault(c => c.CONTATO_COD == id);

        if (contato != null)
        {
            // Alterar o status do favorito
            contato.CONTATO_FAVORITO = !contato.CONTATO_FAVORITO;
            _context.SaveChanges();
        }

        return RedirectToAction("Index"); // ou a ação para onde você quer redirecionar
    }

    public IActionResult Favoritar(int id)
    {
        bool sucesso = MarcarComoFavorito(id);
        if (!sucesso)
        {
            TempData["MensagemErro"] = "Contato não encontrado!";
            return RedirectToAction("Favorito");
        }

        TempData["MensagemSucesso"] = "Contato marcado como favorito!";
        return RedirectToAction("Favorito");
        
    }

    public IActionResult Favorito(int? page)
    {
        int pageSize = 3;
        int pageNumber = page ?? 1;

        var contatos = _context.CONTATOS
            .Include(c => c.TIPOCONTATO)
            .OrderBy(c => c.CONTATO_COD)
            .ToPagedList(pageNumber, pageSize);

        return View(contatos);
    }
}
