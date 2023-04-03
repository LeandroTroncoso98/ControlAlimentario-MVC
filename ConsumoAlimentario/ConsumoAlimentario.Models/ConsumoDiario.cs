using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;

namespace ConsumoAlimentario.Models
{
    public class ConsumoDiario
    {
        [Key]
        public int ConsumoDiario_Id { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Fecha { get; set; }
        public double CaloriasTotales { get; set; }
        public double CarbohidratosTotales { get; set; }
        public double ProteinasTotales { get; set; }
        public double GrasasTotales { get; set; }
        public double SodioTotal { get; set; }
        public double PotasioTotal { get; set; }
        public double FibrasTotales { get; set; }
        public double AzucarTotal { get; set; }
        public double VitaminaATotal { get; set; }
        public double VitaminaCTotal { get; set; }
        public double CalcioTotal { get; set; }
        public double HierroTotal { get; set; }
        public List<AlimentoCargado> ListaAlimentos { get; set; }
        [NotMapped]
        public string FechaString { get;set; }

        [ForeignKey("Usuario")]
        public int Usuario_Id { get; set; }
        public Usuario Usuario { get; set; }
    }
}
