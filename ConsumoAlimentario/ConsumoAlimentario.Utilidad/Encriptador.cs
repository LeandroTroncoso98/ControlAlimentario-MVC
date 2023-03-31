using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoAlimentario.Utilidad
{
    public class Encriptador
    {
        public static string EncriptarClave(string clave)
        {
            string hash = "x2";
            byte[] data = UTF8Encoding.UTF8.GetBytes(clave);
            MD5 mD5 = MD5.Create();
            TripleDES tripleDES = TripleDES.Create();
            tripleDES.Key = mD5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripleDES.Mode = CipherMode.ECB;
            ICryptoTransform transform = tripleDES.CreateEncryptor();
            //result
            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
            return Convert.ToBase64String(result);
        }
    }
}
