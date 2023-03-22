﻿using ConsumoAlimentario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoAlimentario.AccesoDatos.Repository.IRepository
{
    public interface IAlimentoRepository : IRepositorio<Alimento> 
    {
        void Editar(Alimento entity);
        bool ExisteAlimento(string nombre);
    }
}
