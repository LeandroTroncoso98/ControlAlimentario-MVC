using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoAlimentario.Models.ViewModel
{
    public class ConsumoDiarioUsuarioVM
    {
        public IEnumerable<ConsumoDiario> ListaConsumo { get; set; }
        public Usuario Usuario { get; set; }
    }
}
