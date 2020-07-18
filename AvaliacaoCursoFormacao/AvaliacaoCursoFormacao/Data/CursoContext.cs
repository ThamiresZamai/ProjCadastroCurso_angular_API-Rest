using AvaliacaoCursoFormacao.Model;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoCursoFormacao.Data
{
    public class CursoContext : DbContext
    {
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Password=2210;Persist Security Info=True;User ID=sa;Initial Catalog=Curso;Data Source=.\SQLEXPRESS");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>()
            .HasOne<Categoria>(a => a.categoria)
            .WithMany(b => b.cursos)
            .HasForeignKey(f => f.categoriaid);
        }

          


    }
} 
