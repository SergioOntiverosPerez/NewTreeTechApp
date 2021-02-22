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
    [Route("api/Equipamentos")]
    [ApiController]
    public class EquipamentosController : ControllerBase
    {
        private readonly NewTreeTechContext _context;

        public EquipamentosController(NewTreeTechContext context)
        {
            _context = context;
        }

        // GET: api/equipamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipamento>>> GetEquipamentos()
        {
            return await _context.Equipamentos.ToListAsync();
        }

        // GET: api/equipamentos/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Equipamento>> GetEquipamento(int id)
        {
            var equipamento = await _context.Equipamentos.SingleOrDefaultAsync(e => e.Id == id);
            if (equipamento == null)
                return NotFound();

            return equipamento;
        }

        // POST api/equipamentos

        [HttpPost]
        public async Task<ActionResult<Equipamento>> PostEquipamento(Equipamento equipamento)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Equipamentos.Add(equipamento);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEquipamento), new { id = equipamento.Id }, equipamento);
        }
        
        // PUT api/equipamentos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEquipamento(int id, Equipamento equipamento)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var equipamentoInDb = _context.Equipamentos.SingleOrDefault(p => p.Id == id);

            if (equipamentoInDb == null)
                return NotFound();

            equipamentoInDb.NomeDoEquipamento = equipamento.NomeDoEquipamento;
            equipamentoInDb.NumeroDeSerie = equipamento.NumeroDeSerie;
            equipamentoInDb.Tipo = equipamento.Tipo;
            equipamentoInDb.DataDeCadastro = equipamento.DataDeCadastro;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!EquipamentoExists(id))
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE apiequipamentos/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var equipamentoInDb = _context.Equipamentos.SingleOrDefault(p => p.Id == id);
            if (equipamentoInDb == null)
                throw new ArgumentException("equipamento Not Found");

            _context.Equipamentos.Remove(equipamentoInDb);
            _context.SaveChanges();
        }

        private bool EquipamentoExists(int id) =>
            _context.Equipamentos.Any(p => p.Id == id);

    }
}
