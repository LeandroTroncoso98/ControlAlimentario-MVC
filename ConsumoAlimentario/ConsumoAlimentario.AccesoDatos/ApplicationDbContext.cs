using ConsumoAlimentario.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoAlimentario.AccesoDatos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
        }
        public DbSet<Alimento> Alimento { get; set; }
        public DbSet<AlimentoCargado> AlimentoCargado { get; set; }
        public DbSet<ConsumoDiario> ConsumoDiario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<ObjetivoDiario> ObjetivoDiario { get; set; }
    }
}
