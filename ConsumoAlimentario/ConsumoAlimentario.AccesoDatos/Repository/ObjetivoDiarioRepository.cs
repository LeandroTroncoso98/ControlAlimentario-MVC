using ConsumoAlimentario.AccesoDatos.Repository.IRepository;
using ConsumoAlimentario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoAlimentario.AccesoDatos.Repository
{
    public class ObjetivoDiarioRepository : Repositorio<ObjetivoDiario>, IObjetivoDiarioRepository
    {
        private readonly ApplicationDbContext _context;
        public ObjetivoDiarioRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }
        public ObjetivoDiario GetObjetivo(int idUsuario)
        {
            var obj = _context.ObjetivoDiario.FirstOrDefault(c => c.Usuario_Id== idUsuario);
            return obj;
        }
    }
}
