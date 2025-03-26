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
    public class SoftwareController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SoftwareController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /software
        [HttpGet]
        public async Task<IEnumerable<Software>> Get()
        {
            return await _context.Softwares.ToListAsync();
        }

        // GET: /software/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Software>> Get(int id)
        {
            var software = await _context.Softwares.FindAsync(id);
            if (software == null)
            {
                return NotFound();
            }
            return software;
        }

        // POST: /software
        [HttpPost]
        public async Task<ActionResult<Software>> Post([FromBody] Software software)
        {
            if (software == null)
            {
                return BadRequest();
            }

            _context.Softwares.Add(software);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = software.Id }, software);
        }

        // PUT: /software/{id}
         [HttpPut("{id}")]
        public async Task<ActionResult<Software>> Put(int id, [FromBody] Software software)
        {
            // Verifica se o id do corpo da requisição corresponde ao id da URL
            if (id != software.Id)
            {
                return BadRequest();
            }

            // Verifica se o software existe no banco
            var existente = await _context.Softwares.Include(s => s.Maquina).FirstOrDefaultAsync(s => s.Id == id);
            if (existente == null)
            {
                return NotFound();
            }

            // Atualiza as propriedades do software
            existente.Produto = software.Produto;
            existente.HardDisk = software.HardDisk;
            existente.MemoriaRam = software.MemoriaRam;

            // Atualiza o relacionamento com a Maquina, se necessário
            if (software.FkMaquina != existente.FkMaquina)
            {
                existente.FkMaquina = software.FkMaquina;
                // Aqui você pode também querer atualizar a referência de `Maquina` se necessário
                existente.Maquina = await _context.Maquinas.FindAsync(software.FkMaquina);
            }

            // Salva as alterações no banco
            await _context.SaveChangesAsync();

            return Ok(existente);
        }

        // DELETE: /software/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var software = await _context.Softwares.FindAsync(id);
            if (software == null)
            {
                return NotFound();
            }

            _context.Softwares.Remove(software);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
