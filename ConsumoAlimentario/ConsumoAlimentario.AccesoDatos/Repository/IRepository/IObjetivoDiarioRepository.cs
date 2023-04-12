using ConsumoAlimentario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoAlimentario.AccesoDatos.Repository.IRepository
{
    public interface IObjetivoDiarioRepository : IRepositorio<ObjetivoDiario>
    {
        ObjetivoDiario GetObjetivo(int idUsuario);
        bool ExisteObjetivo(int idUsuario);
        void Modificar(ObjetivoDiario objetivoDiario);
    }
}
