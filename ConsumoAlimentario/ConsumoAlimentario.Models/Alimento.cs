using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoAlimentario.Models
{
    public class Alimento
    {
        [Key]
        public int Alimento_Id { get; set; }
        [Required(ErrorMessage = "Debe ingresar un nombre.")]
        [StringLength(70, ErrorMessage = "El nombre debe poseer de 2 hasta 70 caracteres.", MinimumLength = 2)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar las calorías.")]
        public float Calorias { get; set; }
        [Required(ErrorMessage = "Debe ingresar los carbohidratos.")]
        public float Carbohidratos { get; set; }
        [Required(ErrorMessage = "Debe ingresar las proteínas.")]
        public float Proteina { get; set; }
        [Required(ErrorMessage = "Debe ingresar las grasas totales.")]
        [Display(Name = "Grasas totales")]
        public float GrasasTotales { get; set; }
        public float Sodio { get; set; }
        public float Potasio { get; set; }

        public float Fibra { get; set; }
        public float Azucar { get; set; }
        [Display(Name = "Vitamina A")]
        public float VitaminaA { get; set; }
        [Display(Name = "Vitamina C")]
        public float VitaminaC { get; set; }
        public float Calcio { get; set; }
        public float Hierro { get; set; }
        [Required(ErrorMessage = "Debe ingresar una cantidad.")]
        [Display(Name = "Cantidad en gramos")]
        public float Cantidad { get; set; }
        public List<AlimentoCargado> AlimentoCargado { get; set; }
    }
}
