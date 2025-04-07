using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AgendaContato.Models;
using AgendaContato.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgendaContato.Controllers;

public class GrupoContatoController : Controller
{
    private readonly ILogger<GrupoContatoController> _logger;
    private readonly AGENDACONTATOSContext _context;

    public GrupoContatoController(ILogger<GrupoContatoController> logger, AGENDACONTATOSContext context)
    {
        _logger = logger;
        _context = context;
    }

    // Lista todos os grupos de contato
    public IActionResult Index()
    {
        var grupos = _context.GRUPOCONTATOS.ToList();
        return View(grupos);
    }

    // Tela para criar ou editar grupo
    public IActionResult CriarGrupo(int? id)
    {
        if (id != null)
        {
            var grupoInDb = _context.GRUPOCONTATOS.SingleOrDefault(g => g.GRUPO_ID == id);
            return View(grupoInDb);
        }

        return View(new GRUPOCONTATO());
    }

    // Recebe o POST da criação/edição
    [HttpPost]
    public IActionResult CriarGrupoForm(GRUPOCONTATO model)
    {
        Debug.WriteLine("Chegou no método CriarGrupoForm");
        if (!ModelState.IsValid)
        {
            Debug.WriteLine("Chegou no método CriarGrupoForm2");
            return View("CriarGrupo", model);
        }

        if (model.GRUPO_ID == 0)

        {
            Debug.WriteLine("Chegou no método CriarGrupoForm3");
            _context.GRUPOCONTATOS.Add(model);
        }
        else
        {
            Debug.WriteLine("Chegou no método CriarGrupoForm4");
            _context.GRUPOCONTATOS.Update(model);
        }

        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    // Deletar grupo
    public IActionResult DeletaGrupo(int id)
    {
        var grupoInDb = _context.GRUPOCONTATOS.SingleOrDefault(g => g.GRUPO_ID == id);
        if (grupoInDb != null)
        {
            _context.GRUPOCONTATOS.Remove(grupoInDb);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    // Se quiser, pode adicionar uma view de detalhes
    public IActionResult Detalhes(int id)
    {
        var grupo = _context.GRUPOCONTATOS
            .Where(g => g.GRUPO_ID == id)
            .FirstOrDefault();

        return View(grupo);
    }

    public IActionResult ViewGrupoContatos()
    {
        //var grupos = _context.CONTATOGRUPO.ToList();
        return View();
    }

    public IActionResult GrupoFormView()
    {
        //var grupos = _context.CONTATOGRUPO.ToList();
        return View();
    }
}
