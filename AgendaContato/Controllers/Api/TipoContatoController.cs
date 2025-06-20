using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgendaContato.Data;
using AgendaContato.Models;

namespace AgendaContato.Controllers;

[ApiController]
[Route("api/TipoContato")]
public class TipoContatoControllerApi : ControllerBase
{
    private readonly AGENDACONTATOSContext _context;

    public TipoContatoControllerApi(AGENDACONTATOSContext context)
    {
        _context = context;
    }

    // GET: api/tipocontato
    [HttpGet("ListarTipo")]
    public async Task<IActionResult> GetTipos()
    {
        var tipos = await _context.TIPOCONTATOS.ToListAsync();
        return Ok(tipos);
    }

    // GET: api/tipocontato/5
    [HttpGet("SelecionarTipo/{id}")]
    public async Task<IActionResult> GetTipo(int id)
    {
        var tipo = await _context.TIPOCONTATOS.FindAsync(id);
        if (tipo == null)
            return NotFound();

        return Ok(tipo);
    }

    // POST: api/tipocontato
    [HttpPost("CadastrarTipo")]
    public async Task<IActionResult> CriarTipo([FromBody] TIPOCONTATO model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.TIPOCONTATOS.Add(model);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTipo), new { id = model.TIPO_COD }, model);
    }

    // PUT: api/tipocontato/5
    [HttpPut("AlterarTipo/{id}")]
    public async Task<IActionResult> AtualizarTipo(int id, [FromBody] TIPOCONTATO model)
    {
        if (id != model.TIPO_COD)
            return BadRequest("ID inconsistente.");

        _context.Entry(model).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.TIPOCONTATOS.Any(t => t.TIPO_COD == id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE: api/tipocontato/5
    [HttpDelete("DeletarTipo/{id}")]
    public async Task<IActionResult> DeletarTipo(int id)
    {
        var tipo = await _context.TIPOCONTATOS.FindAsync(id);
        if (tipo == null)
            return NotFound();

        _context.TIPOCONTATOS.Remove(tipo);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}