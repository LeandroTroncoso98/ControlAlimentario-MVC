using ConsumoAlimentario.AccesoDatos.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoAlimentario.AccesoDatos.Repository
{
    public class Repositorio<C> : IRepositorio<C> where C : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<C> dbset;
        public Repositorio(ApplicationDbContext context)
        {
            _context = context;
            this.dbset = context.Set<C>();           
        }
        public virtual void Crear(C entity)
        {
            _context.Add(entity);
        }

        public void Eliminar(C entity)
        {
            _context.Remove(entity);
        }

        public void Eliminar(int id)
        {
            C entity = dbset.Find(id);
            Eliminar(entity);
        }

        public C Get(int id)
        {
            return dbset.Find(id);
        }

        public virtual IEnumerable<C> GetAll()
        {
            return dbset.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
