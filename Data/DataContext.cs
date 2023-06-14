using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trabalho.Models;

    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Curso> Curso { get; set; }
        public DbSet<CursoDisciplina> CursoDisciplina { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Disciplina> Disciplina { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CursoDisciplina>()
        .HasKey(x => new { x.DisciplinaId, x.CursoId });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlServer("Data Source=DESKTOP-8QCKAVP\\SQLEXPRESS;Initial Catalog=baco1;Integrated Security=True");
    }


}
