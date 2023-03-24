using ConsumoAlimentario.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoAlimentario.AccesoDatos.Repository.IRepository
{
    public interface IAlimentoRepository : IRepositorio<Alimento> 
    {
        void Editar(Alimento entity);
        bool ExisteAlimento(string nombre);
        IEnumerable<SelectListItem> GetListaAlimentos(); 
    }
}
