using System.Security.Cryptography;
using System.Text;

namespace SysSara.Data;

public class Encrypt
{
    /// <summary>
    /// Encriptar con sha256
    /// </summary>
    /// <param name="texto">Texto que se desea encriptar</param>
    /// <returns></returns>
    public static string GetSHA256(string texto)
    {                        
        ASCIIEncoding encoding = new ASCIIEncoding();
        
        byte[] stream = SHA256.HashData(encoding.GetBytes(texto));
        
        StringBuilder sb = new StringBuilder();
        
        for(int i = 0; i < stream.Length; i++)
            sb.AppendFormat("{0:x2}", stream[i]);
        
        return sb.ToString();
    }
}
