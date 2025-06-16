using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgendaContato.Models;
using AgendaContato.Data;

namespace AgendaContato.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeControllerApi : ControllerBase
{
    private readonly AGENDACONTATOSContext _context;

    public HomeControllerApi(AGENDACONTATOSContext context)
    {
        _context = context;
    }

    // GET: api/contatos?page=1&pageSize=3
    [HttpGet("ListarContatos")]
    public async Task<IActionResult> GetContatos([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var contatos = await _context.CONTATOS
            .Include(c => c.TIPOCONTATO)
            .OrderBy(c => c.CONTATO_COD)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return Ok(contatos);
    }

    // GET: api/contatos/5
    [HttpGet("SelecionarContato/{id}")]
    public async Task<IActionResult> GetContato(int id)
    {
        var contato = await _context.CONTATOS
            .Include(c => c.TIPOCONTATO)
            .FirstOrDefaultAsync(c => c.CONTATO_COD == id);

        if (contato == null)
            return NotFound();

        return Ok(contato);
    }

    // POST: api/contatos
    [HttpPost("CadastrarContato")]
    public async Task<IActionResult> CriarContato([FromBody] CONTATO model)
    {
        if (!_context.TIPOCONTATOS.Any(t => t.TIPO_COD == model.TIPO_COD))
            return BadRequest("Tipo de contato inválido.");

        _context.CONTATOS.Add(model);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetContato), new { id = model.CONTATO_COD }, model);
    }

    // PUT: api/contatos/5
    [HttpPut("AlterarContato/{id}")]
    public async Task<IActionResult> AtualizarContato(int id, [FromBody] CONTATO model)
    {
        if (id != model.CONTATO_COD)
            return BadRequest("ID inconsistente.");

        if (!_context.TIPOCONTATOS.Any(t => t.TIPO_COD == model.TIPO_COD))
            return BadRequest("Tipo de contato inválido.");

        _context.Entry(model).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.CONTATOS.Any(c => c.CONTATO_COD == id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE: api/contatos/5
    [HttpDelete("DeletaContato/{id}")]
    public async Task<IActionResult> DeletarContato(int id)
    {
        var contato = await _context.CONTATOS.FindAsync(id);
        if (contato == null)
            return NotFound();

        _context.CONTATOS.Remove(contato);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // PATCH: api/contatos/5/favorito
    [HttpPatch("{id}/favorito")]
    public async Task<IActionResult> ToggleFavorito(int id)
    {
        var contato = await _context.CONTATOS.FindAsync(id);
        if (contato == null)
            return NotFound();

        contato.CONTATO_FAVORITO = !contato.CONTATO_FAVORITO;
        await _context.SaveChangesAsync();
        return Ok(contato);
    }

    // GET: api/contatos/favoritos
    [HttpGet("favoritos")]
    public async Task<IActionResult> GetFavoritos([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var favoritos = await _context.CONTATOS
            .Include(c => c.TIPOCONTATO)
            .Where(c => c.CONTATO_FAVORITO == true)
            .OrderBy(c => c.CONTATO_COD)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return Ok(favoritos);
    }
}