using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsumoAlimentario.AccesoDatos.Repository.IRepository;
using ConsumoAlimentario.Models;

namespace ConsumoAlimentario.AccesoDatos.Repository
{
    public class ClienteRepository : Repositorio<Cliente>, IClienteRepository
    {
        private readonly ApplicationDbContext _context;
        public ClienteRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }
    }
}
