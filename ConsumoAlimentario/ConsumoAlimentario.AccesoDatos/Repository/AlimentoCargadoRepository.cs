using ConsumoAlimentario.AccesoDatos.Repository.IRepository;
using ConsumoAlimentario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoAlimentario.AccesoDatos.Repository
{
    public class AlimentoCargadoRepository : Repositorio<AlimentoCargado>, IAlimentoCargadoRepository
    {
        public readonly ApplicationDbContext _context;
        public AlimentoCargadoRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public AlimentoCargado CalcularAlimentoCargado(Alimento alimento, float cantidad,int idConsumo)
        {
            AlimentoCargado alimentoCargado = new AlimentoCargado
            {
                Alimento_Id = alimento.Alimento_Id,
                Nombre= alimento.Nombre,
                Cantidad = cantidad,
                ConsumoDiario_Id = idConsumo,

                Calorias = Calcular(cantidad,alimento.Cantidad,alimento.Calorias),
                Carbohidratos = Calcular(cantidad,alimento.Cantidad,alimento.Carbohidratos),
                Proteina = Calcular(cantidad,alimento.Cantidad,alimento.Proteina),
                GrasasTotales = Calcular(cantidad, alimento.Cantidad, alimento.GrasasTotales),
                Sodio = Calcular(cantidad, alimento.Cantidad, alimento.Sodio),
                Potasio = Calcular(cantidad, alimento.Cantidad, alimento.Potasio),
                Fibra = Calcular(cantidad, alimento.Cantidad, alimento.Fibra),
                Azucar = Calcular(cantidad, alimento.Cantidad, alimento.Azucar),
                VitaminaA = Calcular(cantidad, alimento.Cantidad, alimento.VitaminaA),
                VitaminaC = Calcular(cantidad, alimento.Cantidad, alimento.VitaminaC),
                Calcio = Calcular(cantidad, alimento.Cantidad, alimento.Calcio),
                Hierro = Calcular(cantidad, alimento.Cantidad, alimento.Hierro)
            };
            return alimentoCargado;
        }
        private float Calcular(float cantidadPeso, float cantidadBase, float valorBase)
        {
            float resultado = (cantidadPeso * valorBase) / cantidadBase;
            return resultado;
        }
    }
}
