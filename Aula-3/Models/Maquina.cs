using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aula_3.Models
{
    [Table("maquina")]
    public class Maquina
    {
        [Key]
        [Column("id_maquina")]
        public int IdMaquina { get; set; }

        [Column("tipo")]
        public string Tipo { get; set; } = string.Empty;

        [Column("velocidade")]
        public double Velocidade { get; set; }

        [Column("hard_disk")]
        public int HardDisk { get; set; }

        [Column("placa_rede")]
        public int PlacaRede { get; set; }

        [Column("memoria_ram")]
        public int MemoriaRam { get; set; }

        [ForeignKey("Usuario")]
        [Column("fk_usuario")]
        public int FkUsuario { get; set; }

        public Usuario? Usuario { get; set; }
    }
}
