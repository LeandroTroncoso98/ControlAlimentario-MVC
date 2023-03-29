using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoAlimentario.Models
{
    public class AlimentoCargado
    {
        [Key]
        public int AlimentoCargado_Id { get; set; }
        public string Nombre { get; set; }
        [ForeignKey("Alimento")]
        public int Alimento_Id { get; set; }
        public Alimento Alimento { get; set; }
        [Required(ErrorMessage = "La cantidad es obligatoría.")]
        public double Cantidad { get; set; }
        public double Calorias { get; set; }
        public double Carbohidratos { get; set; }
        public double Proteina { get; set; }
        public double GrasasTotales { get; set; }
        public double Sodio { get; set; }
        public double Potasio { get; set; }
        public double Fibra { get; set; }
        public double Azucar { get; set; }
        public double VitaminaA { get; set; }
        public double VitaminaC { get; set; }
        public double Calcio { get; set; }
        public double Hierro { get; set; }
        [ForeignKey("ConsumoDiario")]
        public int ConsumoDiario_Id { get; set; }
        public ConsumoDiario ConsumoDiario { get; set; }
    }
}
