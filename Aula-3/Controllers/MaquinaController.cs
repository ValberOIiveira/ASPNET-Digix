using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aula_3.Data;
using Aula_3.Models;


namespace Aula_3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaquinaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MaquinaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Maquina>> Get()
        {
            return await _context.Maquinas.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Maquina>> Post([FromBody] Maquina maquina)
        {
            _context.Maquinas.Add(maquina);
            await _context.SaveChangesAsync();
            return Ok(maquina);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Maquina>> Put(int id, [FromBody] Maquina maquina)
        {
            var existente = await _context.Maquinas.FindAsync(id);
            if (existente == null) return NotFound();
            existente.Tipo = maquina.Tipo;
            existente.Velocidade = maquina.Velocidade;
            existente.HardDisk = maquina.HardDisk;
            existente.PlacaRede = maquina.PlacaRede;
            existente.MemoriaRam = maquina.MemoriaRam;
            existente.FkUsuario = maquina.FkUsuario;

            await _context.SaveChangesAsync();

            return existente;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existente = await _context.Maquinas.FindAsync(id);
            if (existente == null) return NotFound();
            _context.Maquinas.Remove(existente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
