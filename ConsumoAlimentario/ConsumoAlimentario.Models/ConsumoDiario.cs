using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoAlimentario.Models
{
    public class ConsumoDiario
    {
        [Key]
        public int ConsumoDiario_Id { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Fecha { get; set; }
        public float CaloriasTotales { get; set; }
        public float CarbohidratosTotales { get; set; }
        public float ProteinasTotales { get; set; }
        public float GrasasTotales { get; set; }
        public float SodioTotal { get; set; }
        public float PotasioTotal { get; set; }
        public float FibrasTotales { get; set; }
        public float AzucarTotal { get; set; }
        public float VitaminaATotal { get; set; }
        public float VitaminaCTotal { get; set; }
        public float CalcioTotal { get; set; }
        public float HierroTotal { get; set; }
        public List<AlimentoCargado> ListaAlimentos { get; set; }
    }
}
