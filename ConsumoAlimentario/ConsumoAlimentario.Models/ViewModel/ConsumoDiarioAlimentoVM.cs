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
        public ConsumoDiario ConsumoDiario { get; set; }
        public IEnumerable<SelectListItem> Alimentos { get; set; }
        public IEnumerable<AlimentoCargado> AlimentoCargados { get; set; }
        public AlimentoCargado AlimentoCargado { get; set; }

    }
}
