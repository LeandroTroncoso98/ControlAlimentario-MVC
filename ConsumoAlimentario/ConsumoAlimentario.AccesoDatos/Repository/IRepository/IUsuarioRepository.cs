using ConsumoAlimentario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoAlimentario.AccesoDatos.Repository.IRepository
{
    public interface IUsuarioRepository
    {
        Usuario GetUsuario(string email, string clave);
        Usuario SaveUsuario(Usuario usuario);
    }
}
