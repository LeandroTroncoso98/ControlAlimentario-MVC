using ConsumoAlimentario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoAlimentario.AccesoDatos.Repository.IRepository
{
    public interface IConsumoDiarioRepository : IRepositorio<ConsumoDiario> 
    {
        bool Existe(DateTime fecha);
        ConsumoDiario GetForDate(DateTime fecha);
        void ActulizarConsumoDiario(int id);
        IEnumerable<ConsumoDiario> GetForUserId(int id);
    }
}
