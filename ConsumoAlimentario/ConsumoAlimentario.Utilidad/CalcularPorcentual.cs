using ConsumoAlimentario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoAlimentario.Utilidad
{
    public class CalcularPorcentual
    {
        public PorcentualObjetivoDiario Calcular(ObjetivoDiario objetivoDiario, ConsumoDiario consumoDiario)
        {
            PorcentualObjetivoDiario porcentualObjetivo = new PorcentualObjetivoDiario();
            Math.Round(porcentualObjetivo.CaloriasPorcentual = (consumoDiario.CaloriasTotales * 100) / objetivoDiario.CaloriasObjetivo,2);
            Math.Round(porcentualObjetivo.CarbohidratosPorcentual = (consumoDiario.CarbohidratosTotales * 100) / objetivoDiario.CarbohidratosObjetivo, 2);
            Math.Round(porcentualObjetivo.ProteinasPorcentual = (consumoDiario.ProteinasTotales * 100) / objetivoDiario.ProteinasObjetivo,2);
            Math.Round(porcentualObjetivo.GrasasPorcentual = (consumoDiario.GrasasTotales * 100) / objetivoDiario.GrasasObjetivo,2);
            Math.Round(porcentualObjetivo.SodioPorcentual = (consumoDiario.SodioTotal * 100) / objetivoDiario.SodioObjetivo,2);
            Math.Round(porcentualObjetivo.PotasioPorcentual = (consumoDiario.PotasioTotal * 100) / objetivoDiario.PotasioObjetivo,2);
            Math.Round(porcentualObjetivo.FibrasPorcentual = (consumoDiario.FibrasTotales * 100) / objetivoDiario.FibrasObjetivo,2);
            Math.Round(porcentualObjetivo.AzucarPorcentual = (consumoDiario.AzucarTotal * 100) / objetivoDiario.AzucarObjetivo,2);
            Math.Round(porcentualObjetivo.VitaminaAPorcentual = (consumoDiario.VitaminaATotal * 100) / objetivoDiario.VitaminaAObjetivo,2);
            Math.Round(porcentualObjetivo.VitaminaCPorcentual = (consumoDiario.VitaminaCTotal * 100) / objetivoDiario.VitaminaCObjetivo,2);
            Math.Round(porcentualObjetivo.CalcioPorcentual = (consumoDiario.CalcioTotal * 100) / objetivoDiario.CalcioObjetivo,2);
            Math.Round(porcentualObjetivo.HierroPorcentual = (consumoDiario.HierroTotal * 100) / objetivoDiario.HierroObjetivo,2);
            return porcentualObjetivo;
        }
       
    }
}
