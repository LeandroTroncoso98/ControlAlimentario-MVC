﻿using ConsumoAlimentario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoAlimentario.AccesoDatos.Repository.IRepository
{
    public interface IAlimentoCargadoRepository:IRepositorio<AlimentoCargado>
    {
        AlimentoCargado CalcularAlimentoCargado(Alimento alimento, double cantidad, int idConsumo);
        List<AlimentoCargado> GetListAlimentoCargadoFromId(int pagina, int cantidadDeRegistrosPorPaginas, int id);

    }
}
