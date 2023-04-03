using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoAlimentario.Models
{
    public class Usuario
    {
        [Key]
        public int Usuario_Id { get; set; }
        [Required(ErrorMessage = "Debe completar el email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Contraseña oblígatoria.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Campo obligatorio.")]
        public double Peso { get; set; }
        [Required(ErrorMessage = "Campo obligatorio.")]
        public double Altura { get; set; }
        public List<ConsumoDiario> ListaConsumoDiario { get; set; }

    }
}
