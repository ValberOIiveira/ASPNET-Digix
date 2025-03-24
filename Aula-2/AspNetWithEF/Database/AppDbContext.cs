using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AspNetWithEF.Database
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        // Construtor para injeção de dependência
        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Usando a string de conexão a partir da configuração
            var connectionString = _configuration.GetConnectionString("PostgresConnection");
            optionsBuilder.UseNpgsql(connectionString);
        }

        public DbSet<Models.Usuario> Usuarios { get; set; }
    }
}
