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
        public override IEnumerable<ConsumoDiario> GetAll()
        {
            IEnumerable<ConsumoDiario> lista = _context.ConsumoDiario.ToList();
            foreach(var item in lista)
            {
                item.FechaString = item.Fecha.ToString("d");
            }
            return lista;
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
        public void QuitarAlimentoCargado(int consumoDiairoId,AlimentoCargado alimento)
        {
            var consumoDiario = _context.ConsumoDiario.FirstOrDefault(m => m.ConsumoDiario_Id == consumoDiairoId);
            consumoDiario.ListaAlimentos.Remove(alimento);
            consumoDiario.CaloriasTotales -= alimento.Calorias;
            consumoDiario.CarbohidratosTotales -= alimento.Carbohidratos;
            consumoDiario.ProteinasTotales -= alimento.Proteina;
            consumoDiario.GrasasTotales -= alimento.GrasasTotales;
            consumoDiario.SodioTotal -= alimento.Sodio;
            consumoDiario.PotasioTotal -= alimento.Potasio;
            consumoDiario.FibrasTotales -= alimento.Fibra;
            consumoDiario.AzucarTotal -= alimento.Azucar;
            consumoDiario.VitaminaATotal -= alimento.VitaminaA;
            consumoDiario.VitaminaCTotal -= alimento.VitaminaC;
            consumoDiario.CalcioTotal -= alimento.Calcio;
            consumoDiario.HierroTotal -= alimento.Hierro;
        }


        
        public override void Crear(ConsumoDiario entity)
        {
            _context.ConsumoDiario.Add(entity);
        }
        
    }
}
