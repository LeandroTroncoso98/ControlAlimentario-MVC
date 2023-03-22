using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsumoAlimentario.Models.ViewModel
{
    public class ConsumoDiarioAlimentoVM
    {
        public ConsumoDiario ConsumoDiarios { get; set; }
        public IEnumerable<Alimento> Alimentos { get; set; }
    }
}
