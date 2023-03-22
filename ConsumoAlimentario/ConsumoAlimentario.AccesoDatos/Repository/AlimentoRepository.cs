using ConsumoAlimentario.AccesoDatos.Repository.IRepository;
using ConsumoAlimentario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoAlimentario.AccesoDatos.Repository
{
    public class AlimentoRepository : Repositorio<Alimento>, IAlimentoRepository
    {
        private readonly ApplicationDbContext _context;
        public AlimentoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Editar(Alimento entity)
        {
            var alimentoDb = dbset.FirstOrDefault(a => a.Alimento_Id == entity.Alimento_Id);
            alimentoDb.Nombre = entity.Nombre;
            alimentoDb.Calorias = entity.Calorias;
            alimentoDb.Carbohidratos = entity.Carbohidratos;
            alimentoDb.Proteina = entity.Proteina;
            alimentoDb.GrasasTotales = entity.GrasasTotales;
            alimentoDb.Sodio = entity.Sodio;
            alimentoDb.Potasio = entity.Potasio;
            alimentoDb.Fibra = entity.Fibra;
            alimentoDb.Azucar = entity.Azucar;
            alimentoDb.VitaminaA = entity.VitaminaA;
            alimentoDb.VitaminaC = entity.VitaminaC;
            alimentoDb.Calcio = entity.Calcio;
            alimentoDb.Hierro = entity.Hierro;
            alimentoDb.Cantidad = entity.Cantidad;
            _context.SaveChanges();
        }

        public bool ExisteAlimento(string nombre)
        {
            bool existe = _context.Alimento.Any(c => c.Nombre.ToLower() == nombre.ToLower());
            return existe;
        }
    }
}
