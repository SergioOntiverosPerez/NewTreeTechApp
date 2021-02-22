using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewTreeTechApp.Data;
using NewTreeTechApp.Models;

namespace NewTreeTechApp.Controllers.Api
{
    [Route("api/alarme")]
    [ApiController]
    public class AlarmeController : ControllerBase
    {
        private readonly NewTreeTechContext _context;
        public AlarmeController(NewTreeTechContext context)
        {
            _context = context;
        }

        // GET: api/alarmes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alarme>>> GetAlarmes()
        {
            return await _context.Alarmes.Include(al => al.Equipamento).ToListAsync();
        }

        // GET: api/alarmes/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Alarme>> GetAlarme(int id)
        {
            var alarme = await _context.Alarmes.Include(al => al.Equipamento).SingleAsync(al => al.Id == id);
            if (alarme == null)
                return NotFound();

            return alarme;
        }

        // POST api/alarmes

        [HttpPost]
        public async Task<ActionResult<Alarme>> PostEquipamento(Alarme alarme)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Alarmes.Add(alarme);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAlarme), new { id = alarme.Id }, alarme);
        }

        // PUT api/alarmes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAlarme(int id, Alarme alarme)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var alarmeInDb = _context.Alarmes.SingleOrDefault(p => p.Id == id);

            if (alarmeInDb == null)
                return NotFound();

            alarmeInDb.Descricao = alarme.Descricao;
            alarmeInDb.Classificacao = alarme.Classificacao;
            alarmeInDb.DataDeCadastro = alarme.DataDeCadastro;
            alarmeInDb.EquipamentoId = alarme.EquipamentoId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!AlarmeExists(id))
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE apialarmes/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var alarmeInDb = _context.Alarmes.SingleOrDefault(p => p.Id == id);
            if (alarmeInDb == null)
                throw new ArgumentException("alarme Not Found");

            _context.Alarmes.Remove(alarmeInDb);
            _context.SaveChanges();
        }

        private bool AlarmeExists(int id) =>
            _context.Alarmes.Any(p => p.Id == id);
    }
}
