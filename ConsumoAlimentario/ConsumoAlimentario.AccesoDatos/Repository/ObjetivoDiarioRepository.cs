using ConsumoAlimentario.AccesoDatos.Repository.IRepository;
using ConsumoAlimentario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoAlimentario.AccesoDatos.Repository
{
    public class ObjetivoDiarioRepository : Repositorio<ObjetivoDiario>, IObjetivoDiarioRepository
    {
        private readonly ApplicationDbContext _context;
        public ObjetivoDiarioRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }
        public ObjetivoDiario GetObjetivo(int idUsuario)
        {
            var obj = _context.ObjetivoDiario.FirstOrDefault(c => c.Usuario_Id== idUsuario);
            return obj;
        }
        public bool ExisteObjetivo(int idUsuario)
        {
            var existe = _context.ObjetivoDiario.Any(c => c.Usuario_Id == idUsuario);
            return existe;
        }
        public void Modificar(ObjetivoDiario objetivoDiario)
        {
            var objetivoDesdeDB = _context.ObjetivoDiario.FirstOrDefault(m => m.ObjetivoDiario_Id == objetivoDiario.ObjetivoDiario_Id);
            objetivoDesdeDB.CaloriasObjetivo = objetivoDiario.CaloriasObjetivo;
            objetivoDesdeDB.CarbohidratosObjetivo = objetivoDiario.CarbohidratosObjetivo;
            objetivoDesdeDB.ProteinasObjetivo = objetivoDiario.ProteinasObjetivo;
            objetivoDesdeDB.GrasasObjetivo = objetivoDiario.GrasasObjetivo;
            objetivoDesdeDB.SodioObjetivo = objetivoDiario.SodioObjetivo;
            objetivoDesdeDB.PotasioObjetivo = objetivoDiario.PotasioObjetivo;
            objetivoDesdeDB.FibrasObjetivo = objetivoDiario.FibrasObjetivo;
            objetivoDesdeDB.AzucarObjetivo = objetivoDiario.AzucarObjetivo;
            objetivoDesdeDB.VitaminaAObjetivo = objetivoDiario.VitaminaAObjetivo;
            objetivoDesdeDB.VitaminaCObjetivo = objetivoDiario.VitaminaCObjetivo;
            objetivoDesdeDB.CalcioObjetivo = objetivoDiario.CalcioObjetivo;
            objetivoDesdeDB.HierroObjetivo = objetivoDiario.HierroObjetivo;
            objetivoDesdeDB.Usuario_Id = objetivoDiario.Usuario_Id;
            _context.Update(objetivoDesdeDB);
            _context.SaveChanges();
        }
    }
}
