using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Aula_3.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    senha = table.Column<string>(type: "text", nullable: false),
                    ramal = table.Column<int>(type: "integer", nullable: false),
                    especialidade = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "maquina",
                columns: table => new
                {
                    id_maquina = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipo = table.Column<string>(type: "text", nullable: false),
                    velocidade = table.Column<int>(type: "integer", nullable: false),
                    hard_disk = table.Column<int>(type: "integer", nullable: false),
                    placa_rede = table.Column<int>(type: "integer", nullable: false),
                    memoria_ram = table.Column<int>(type: "integer", nullable: false),
                    fk_usuario = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maquina", x => x.id_maquina);
                    table.ForeignKey(
                        name: "FK_maquina_usuario_fk_usuario",
                        column: x => x.fk_usuario,
                        principalTable: "usuario",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "software",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    produto = table.Column<string>(type: "text", nullable: false),
                    hard_disk = table.Column<int>(type: "integer", nullable: false),
                    memoria_ram = table.Column<int>(type: "integer", nullable: false),
                    fk_maquina = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_software", x => x.id);
                    table.ForeignKey(
                        name: "FK_software_maquina_fk_maquina",
                        column: x => x.fk_maquina,
                        principalTable: "maquina",
                        principalColumn: "id_maquina",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_maquina_fk_usuario",
                table: "maquina",
                column: "fk_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_software_fk_maquina",
                table: "software",
                column: "fk_maquina");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "software");

            migrationBuilder.DropTable(
                name: "maquina");

            migrationBuilder.DropTable(
                name: "usuario");
        }
    }
}
