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
        public double Calorias { get; set; }
        [Required(ErrorMessage = "Debe ingresar los carbohidratos.")]
        public double Carbohidratos { get; set; }
        [Required(ErrorMessage = "Debe ingresar las proteínas.")]
        public double Proteina { get; set; }
        [Required(ErrorMessage = "Debe ingresar las grasas totales.")]
        [Display(Name = "Grasas totales")]
        public double GrasasTotales { get; set; }
        public double Sodio { get; set; }
        public double Potasio { get; set; }

        public double Fibra { get; set; }
        public double Azucar { get; set; }
        [Display(Name = "Vitamina A")]
        public double VitaminaA { get; set; }
        [Display(Name = "Vitamina C")]
        public double VitaminaC { get; set; }
        public double Calcio { get; set; }
        public double Hierro { get; set; }
        [Required(ErrorMessage = "Debe ingresar una cantidad.")]
        [Display(Name = "Cantidad en gramos")]
        public double Cantidad { get; set; }
        public List<AlimentoCargado> AlimentoCargado { get; set; }
    }
}
