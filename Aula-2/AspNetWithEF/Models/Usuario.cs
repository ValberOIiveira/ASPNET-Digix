using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//To use EF, we need to do it before:
using System.ComponentModel.DataAnnotations.Schema;


namespace AspNetWithEF.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        public string Nome { get; set; } = string.Empty;
        [Column("email")]
        public string Email { get; set; } = string.Empty;
    }
}