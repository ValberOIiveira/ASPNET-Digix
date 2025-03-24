using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Here we need to use MVC lib
using Microsoft.AspNetCore.Mvc;
// Ref to models and database
using AspNetWithEF.Database;
using AspNetWithEF.Models;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace AspNetWithEF.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Usuario>> Get()
        {
            return await _context.Usuarios.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Post([FromBody] Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> Put(int id, [FromBody] Usuario usuario)
        {
            var existente = await _context.Usuarios.FindAsync(id);
            if (existente == null) return NotFound();
            existente.Nome = usuario.Nome;
            existente.Email = usuario.Email;

            await _context.SaveChangesAsync();

            return existente;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existente = await _context.Usuarios.FindAsync(id);
            if (existente == null) return NotFound();
            _context.Usuarios.Remove(existente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
