using ConsumoAlimentario.AccesoDatos.Repository.IRepository;
using ConsumoAlimentario.Models;
using Microsoft.AspNetCore.Authorization;
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
            foreach (var item in lista)
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
        public void ActulizarConsumoDiario(int id)
        {
            var consumoDiario = _context.ConsumoDiario.FirstOrDefault(m => m.ConsumoDiario_Id == id);
            List<AlimentoCargado> listaAlimentos = _context.AlimentoCargado.Where(m => m.ConsumoDiario_Id == id).ToList();
            ResetAtributos(consumoDiario);
            foreach(var item in listaAlimentos)
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
            _context.Update(consumoDiario); 
            _context.SaveChanges();
        }
        private void ResetAtributos(ConsumoDiario consumoDiario)
        {
            consumoDiario.CaloriasTotales =0;
            consumoDiario.CarbohidratosTotales = 0;
            consumoDiario.ProteinasTotales = 0;
            consumoDiario.GrasasTotales = 0;
            consumoDiario.SodioTotal = 0;
            consumoDiario.PotasioTotal = 0;
            consumoDiario.FibrasTotales = 0;
            consumoDiario.AzucarTotal = 0;
            consumoDiario.VitaminaATotal = 0;
            consumoDiario.VitaminaCTotal = 0;
            consumoDiario.CalcioTotal = 0;
            consumoDiario.HierroTotal = 0;
        }

        public override void Crear(ConsumoDiario entity)
        {
            _context.ConsumoDiario.Add(entity);
        }

    }
}
