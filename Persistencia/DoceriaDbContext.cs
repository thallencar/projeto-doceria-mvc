using Doceria.Models;
using Microsoft.EntityFrameworkCore;

namespace Doceria.Persistencia
{
    public class DoceriaDbContext : DbContext
    {
        public DoceriaDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Torta> Tortas { get; set; }
    }
}