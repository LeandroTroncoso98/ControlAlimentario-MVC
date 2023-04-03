using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoAlimentario.AccesoDatos.Repository.IRepository
{
    public interface IRepositorio<C> where C : class 
    {
        void Crear(C entity);
        void Eliminar(int id);
        void Eliminar(C entity);
        IEnumerable<C> GetAll();
        C Get(int id);
        void Save();

    }
}
