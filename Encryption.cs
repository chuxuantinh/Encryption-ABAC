using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace CT_ABAC_CORE.DomainFunction
{
    public class Encryption: IPluginDomain
    {
        public string Name
        {
            get
            {
                return "Encryption";
            }
        }
        
        public static string Mahoa(string s)
        {

            byte[] encrypted1;
            using (AesManaged aes1 = new AesManaged())
            {
                // Encrypt string    
                encrypted1 = Encrypt(s, aes1.Key, aes1.IV);
                // Print encrypted string    
                //Console.WriteLine( "Encrypted data: {System.Text.Encoding.UTF8.GetString(encrypted)}");
                // Decrypt the bytes to a string.    
            }
            return System.Text.Encoding.UTF8.GetString(encrypted1);
            //return "chu";
                 
        }

        public static byte[] Encrypt(string plainText, byte[] Key, byte[] IV)
        {
            byte[] encrypted;
            // Create a new AesManaged.    
            using (AesManaged aes = new AesManaged())
            {
                // Create encryptor    
                ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);
                // Create MemoryStream    
                using (MemoryStream ms = new MemoryStream())
                {
                    // Create crypto stream using the CryptoStream class. This class is the key to encryption    
                    // and encrypts and decrypts data from any given stream. In this case, we will pass a memory stream    
                    // to encrypt    
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        // Create StreamWriter and write data to a stream    
                        using (StreamWriter sw = new StreamWriter(cs))
                            sw.Write(plainText);
                        encrypted = ms.ToArray();
                    }
                }
            }
            // Return encrypted data    
            return encrypted;
        }

        
    }
}
