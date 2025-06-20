using AgendaContato.Data;
using AgendaContato.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaContato.Controllers.Api
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ContatoController : ControllerBase
        {
            private readonly AGENDACONTATOSContext _context;

            public ContatoController(AGENDACONTATOSContext context)
            {
                _context = context;
            }

            // Contact CRUD Operations
            [HttpGet("contacts")]
            public async Task<ActionResult<IEnumerable<CONTATO>>> GetContacts()
            {
                return await _context.CONTATOS
                    .Include(c => c.TIPOCONTATO)
                    .Include(c => c.CONTATOGRUPOS)
                    .ThenInclude(cg => cg.GRUPOCONTATO)
                    .ToListAsync();
            }

            [HttpGet("contacts/{id}")]
            public async Task<ActionResult<CONTATO>> GetContact(int id)
            {
                var contact = await _context.CONTATOS
                    .Include(c => c.TIPOCONTATO)
                    .Include(c => c.CONTATOGRUPOS)
                    .ThenInclude(cg => cg.GRUPOCONTATO)
                    .FirstOrDefaultAsync(c => c.CONTATO_COD == id);

                if (contact == null)
                {
                    return NotFound();
                }

                return contact;
            }

            [HttpPost("contacts")]
            public async Task<ActionResult<CONTATO>> CreateContact(CONTATO contact)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.CONTATOS.Add(contact);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetContact), new { id = contact.CONTATO_COD }, contact);
            }

            [HttpPut("contacts/{id}")]
            public async Task<IActionResult> UpdateContact(int id, CONTATO contact)
            {
                if (id != contact.CONTATO_COD)
                {
                    return BadRequest();
                }

                _context.Entry(contact).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(id))
                    {
                        return NotFound();
                    }
                    throw;
                }

                return NoContent();
            }

            [HttpDelete("contacts/{id}")]
            public async Task<IActionResult> DeleteContact(int id)
            {
                var contact = await _context.CONTATOS.FindAsync(id);
                if (contact == null)
                {
                    return NotFound();
                }

                _context.CONTATOS.Remove(contact);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            // Group CRUD Operations
            [HttpGet("groups")]
            public async Task<ActionResult<IEnumerable<GRUPOCONTATO>>> GetGroups()
            {
                return await _context.GRUPOCONTATOS
                    .Include(g => g.CONTATOGRUPOS)
                    .ThenInclude(cg => cg.CONTATO)
                    .ToListAsync();
            }

            [HttpGet("groups/{id}")]
            public async Task<ActionResult<GRUPOCONTATO>> GetGroup(int id)
            {
                var group = await _context.GRUPOCONTATOS
                    .Include(g => g.CONTATOGRUPOS)
                    .ThenInclude(cg => cg.CONTATO)
                    .FirstOrDefaultAsync(g => g.GRUPO_ID == id);

                if (group == null)
                {
                    return NotFound();
                }

                return group;
            }

            [HttpPost("groups")]
            public async Task<ActionResult<GRUPOCONTATO>> CreateGroup(GRUPOCONTATO group)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.GRUPOCONTATOS.Add(group);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetGroup), new { id = group.GRUPO_ID }, group);
            }

            [HttpPut("groups/{id}")]
            public async Task<IActionResult> UpdateGroup(int id, GRUPOCONTATO group)
            {
                if (id != group.GRUPO_ID)
                {
                    return BadRequest();
                }

                _context.Entry(group).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupExists(id))
                    {
                        return NotFound();
                    }
                    throw;
                }

                return NoContent();
            }

            [HttpDelete("groups/{id}")]
            public async Task<IActionResult> DeleteGroup(int id)
            {
                var group = await _context.GRUPOCONTATOS.FindAsync(id);
                if (group == null)
                {
                    return NotFound();
                }

                _context.GRUPOCONTATOS.Remove(group);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            // Contact-Group Relationship Operations
            [HttpPost("contacts/{contactId}/groups/{groupId}")]
            public async Task<IActionResult> AddContactToGroup(int contactId, int groupId)
            {
                var contact = await _context.CONTATOS.FindAsync(contactId);
                var group = await _context.GRUPOCONTATOS.FindAsync(groupId);

                if (contact == null || group == null)
                {
                    return NotFound();
                }

                var contactGroup = new CONTATOGRUPO
                {
                    CONTATO_ID = contactId,
                    GRUPO_ID = groupId,
                    CONTATO = contact,
                    GRUPOCONTATO = group
                };

                _context.CONTATOSGRUPOS.Add(contactGroup);
                await _context.SaveChangesAsync();

                return Ok();
            }

            [HttpDelete("contacts/{contactId}/groups/{groupId}")]
            public async Task<IActionResult> RemoveContactFromGroup(int contactId, int groupId)
            {
                var contactGroup = await _context.CONTATOSGRUPOS
                    .FirstOrDefaultAsync(cg => cg.CONTATO_ID == contactId && cg.GRUPO_ID == groupId);

                if (contactGroup == null)
                {
                    return NotFound();
                }

                _context.CONTATOSGRUPOS.Remove(contactGroup);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool ContactExists(int id)
            {
                return _context.CONTATOS.Any(e => e.CONTATO_COD == id);
            }

            private bool GroupExists(int id)
            {
                return _context.GRUPOCONTATOS.Any(e => e.GRUPO_ID == id);
            }
        }
    }