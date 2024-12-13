using Microsoft.EntityFrameworkCore;
using Entidad.Models;

namespace MiMvcPostgres.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<EnfermedadCronica> EnfermedadesCronicas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnfermedadCronica>().ToTable("tc_enfermedad_cronica", "schemasye");
        }
    }
}
