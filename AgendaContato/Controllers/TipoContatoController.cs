using Microsoft.AspNetCore.Mvc;
using AgendaContato.Data;
using AgendaContato.Models;

namespace AgendaContato.Controllers
{
    public class TipoContatoController : Controller
    {
        private readonly AGENDACONTATOSContext _context;

        public TipoContatoController(AGENDACONTATOSContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tipos = _context.TIPOCONTATOS.ToList();
            return View(tipos);
        }

        public IActionResult Criar(int? id)
        {
            if (id != null)
            {
                var tipo = _context.TIPOCONTATOS.Find(id);
                return View(tipo);
            }

            return View(new TIPOCONTATO());
        }

        [HttpPost]
        public IActionResult Criar(TIPOCONTATO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.TIPO_COD == 0)
            {
                _context.TIPOCONTATOS.Add(model);
            }
            else
            {
                _context.TIPOCONTATOS.Update(model);
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Deletar(int id)
        {
            var tipo = _context.TIPOCONTATOS.Find(id);
            if (tipo != null)
            {
                _context.TIPOCONTATOS.Remove(tipo);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}

