using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoAlimentario.Models
{
    public class ObjetivoDiario
    {
        [Key]
        public int ObjetivoDiario_Id { get; set; }
        public double CaloriasObjetivo { get; set; }
        public double CarbohidratosObjetivo { get; set; }
        public double ProteinasObjetivo { get; set; }
        public double GrasasObjetivo { get; set; }
        public double SodioObjetivo { get; set; }
        public double PotasioObjetivo { get; set; }
        public double FibrasObjetivo { get; set; }
        public double AzucarObjetivo { get; set; }
        public double VitaminaAObjetivo { get; set; }
        public double VitaminaCObjetivo { get; set; }
        public double CalcioObjetivo { get; set; }
        public double HierroObjetivo { get; set; }
        [ForeignKey("Usuario")]
        public int Usuario_Id { get; set; }
    }
}
