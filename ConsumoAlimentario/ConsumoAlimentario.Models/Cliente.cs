using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoAlimentario.Models
{
    public class Cliente
    {
        [Key]
        public int Cliente_Id { get; set; }
        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Campo obligatorio.")]
        public double Peso { get; set; }
        [Required(ErrorMessage = "Campo obligatorio.")]
        public double Altura { get; set; }
        [ForeignKey("Usuario")]
        public int Usuario_Id { get; set; }
        public Usuario Usuario { get; set; }
        public List<ConsumoDiario> ListaConsumoDiario { get; set; }
    }
}
