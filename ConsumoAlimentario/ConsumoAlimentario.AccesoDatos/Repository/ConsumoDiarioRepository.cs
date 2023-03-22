using ConsumoAlimentario.AccesoDatos.Repository.IRepository;
using ConsumoAlimentario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoAlimentario.AccesoDatos.Repository
{
    public class ConsumoDiarioRepository : Repositorio<ConsumoDiario>, IConsumoDiarioRepository
    {
        private readonly ApplicationDbContext _context;
        public ConsumoDiarioRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }      
        public bool Existe(DateTime fecha)
        {
            return _context.ConsumoDiario.Any(c => c.Fecha == fecha);   
        }

        public ConsumoDiario GetForDate(DateTime fecha)
        {
            var consumoDiario = _context.ConsumoDiario.FirstOrDefault(c => c.Fecha == fecha);
            return consumoDiario;
        }
        public void AgregarAlimentoCargado(int consumoDiarioId, AlimentoCargado alimento)
        {
            var consumoDiario = _context.ConsumoDiario.FirstOrDefault(c => c.ConsumoDiario_Id == consumoDiarioId);
            consumoDiario.ListaAlimentos.Add(alimento);
            ResetNutrientes(consumoDiario);
            foreach(var item in consumoDiario.ListaAlimentos)
            {
                consumoDiario.CaloriasTotales += item.Calorias;
                consumoDiario.CarbohidratosTotales += item.Carbohidratos;
                consumoDiario.ProteinasTotales += item.Proteina;
                consumoDiario.GrasasTotales += item.GrasasTotales;
                consumoDiario.SodioTotal += item.Sodio;
                consumoDiario.PotasioTotal += item.Potasio;
                consumoDiario.FibrasTotales += item.Fibra;
                consumoDiario.AzucarTotal += item.Azucar;
                consumoDiario.VitaminaATotal += item.VitaminaA;
                consumoDiario.VitaminaCTotal += item.VitaminaC;
                consumoDiario.CalcioTotal += item.Calcio;
                consumoDiario.HierroTotal += item.Hierro;
            }

        }

        private void ResetNutrientes(ConsumoDiario consumo)
        {
            consumo.CaloriasTotales = 0;
            consumo.CarbohidratosTotales = 0;
            consumo.ProteinasTotales = 0;
            consumo.GrasasTotales = 0;
            consumo.SodioTotal = 0;
            consumo.PotasioTotal = 0;
            consumo.FibrasTotales = 0;
            consumo.AzucarTotal = 0;
            consumo.VitaminaATotal = 0;
            consumo.VitaminaCTotal = 0;
            consumo.CalcioTotal = 0;
            consumo.HierroTotal = 0;
        }
        public override void Crear(ConsumoDiario entity)
        {
            _context.ConsumoDiario.Add(entity);
        }
    }
}
