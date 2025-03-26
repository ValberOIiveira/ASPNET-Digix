using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aula_3.Models
{
    [Table("software")]
    public class Software
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("produto")]
        public string Produto { get; set; } = string.Empty;

        [Column("hard_disk")]
        public int HardDisk { get; set; }

        [Column("memoria_ram")]
        public int MemoriaRam { get; set; }

        [ForeignKey("Maquina")]
        [Column("fk_maquina")]
        public int FkMaquina { get; set; }

        public Maquina? Maquina { get; set; }
    }
}
