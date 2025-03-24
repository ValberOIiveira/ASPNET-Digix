using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


//To make HTTP protocol, we need a controller from the ASP.NET lib,
// in this case, the MVC ControllerBase
//To do it, we need install the mvc by dotnet add package Microsoft.AspNetCore.Mvc
namespace Aula_2.Controller
{

    //Lets add the annotation to get our class reference to aspnet
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        //Store the values in a list
        private static List<Usuario> usuarios = new List<Usuario>()
        {
            new Usuario {Id = 1, Nome = "João", Email = "joao@email.com"},
            new Usuario {Id = 2, Nome = "Maria", Email = "maria@email.com"},
            new Usuario {Id = 3, Nome = "Jose", Email = "Jose@email.com"},
            new Usuario {Id = 4, Nome = "Ana", Email = "Ana@email.com"}
        };


        //Lets add annotation to define the route to access the method HTTP
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return usuarios;
        }


        [HttpPost]
        //frombody says to mvc read the data in body of the request
        public Usuario Post([FromBody] Usuario usuario)
        {
            usuarios.Add(usuario);
            return usuario;
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Usuario usuario)
        {
            var usuarioExistente = usuarios.Where(x => x.Id == id).FirstOrDefault();

            if(usuarioExistente != null)
            {
                usuarioExistente.Nome = usuario.Nome;
                usuarioExistente.Email = usuario.Email;
            }

            
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var usuarioExistente = usuarios.Where(x => x.Id == id).FirstOrDefault();

            if(usuarioExistente != null)
            {
                usuarios.Remove(usuarioExistente);
            }
        }

    }
}