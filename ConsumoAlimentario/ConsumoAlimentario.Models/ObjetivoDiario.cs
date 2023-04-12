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
        [Range(0, 99999, ErrorMessage = "Valores validos entre 0 y 99999")]
        [Required(ErrorMessage = "Campo obligatorío.")]
        public double CaloriasObjetivo { get; set; }
        [Range(0, 99999, ErrorMessage = "Valores validos entre 0 y 99999")]
        [Required(ErrorMessage = "Campo obligatorío.")]
        public double CarbohidratosObjetivo { get; set; }
        [Range(0, 99999, ErrorMessage = "Valores validos entre 0 y 99999")]
        [Required(ErrorMessage = "Campo obligatorío.")]
        public double ProteinasObjetivo { get; set; }
        [Range(0, 99999, ErrorMessage = "Valores validos entre 0 y 99999")]
        [Required(ErrorMessage = "Campo obligatorío.")]
        public double GrasasObjetivo { get; set; }
        [Range(0, 99999, ErrorMessage = "Valores validos entre 0 y 99999")]
        [Required(ErrorMessage = "Campo obligatorío.")]
        public double SodioObjetivo { get; set; }
        [Range(0, 99999, ErrorMessage = "Valores validos entre 0 y 99999")]
        [Required(ErrorMessage = "Campo obligatorío.")]
        public double PotasioObjetivo { get; set; }
        [Range(0, 99999, ErrorMessage = "Valores validos entre 0 y 99999")]
        [Required(ErrorMessage = "Campo obligatorío.")]
        public double FibrasObjetivo { get; set; }
        [Range(0, 99999, ErrorMessage = "Valores validos entre 0 y 99999")]
        [Required(ErrorMessage = "Campo obligatorío.")]
        public double AzucarObjetivo { get; set; }
        [Range(0, 99999, ErrorMessage = "Valores validos entre 0 y 99999")]
        [Required(ErrorMessage = "Campo obligatorío.")]
        public double VitaminaAObjetivo { get; set; }
        [Range(0, 99999, ErrorMessage = "Valores validos entre 0 y 99999")]
        [Required(ErrorMessage = "Campo obligatorío.")]
        public double VitaminaCObjetivo { get; set; }
        [Range(0, 99999, ErrorMessage = "Valores validos entre 0 y 99999")]
        [Required(ErrorMessage = "Campo obligatorío.")]
        public double CalcioObjetivo { get; set; }
        [Range(0, 99999, ErrorMessage = "Valores validos entre 0 y 99999")]
        [Required(ErrorMessage = "Campo obligatorío.")]
        public double HierroObjetivo { get; set; }
        [ForeignKey("Usuario")]
        public int Usuario_Id { get; set; }
    }
}
