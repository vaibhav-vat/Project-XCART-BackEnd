using System;
using System.Collections.Generic;
using System.Text;

namespace XCart.Common
{
    public class Hash
    {
        
      public static string Hashing(string input)
        {
            string hash = Convert.ToBase64String(
               System.Security.Cryptography.SHA256.Create()
               .ComputeHash(Encoding.UTF8.GetBytes(input)));

            return hash;
        }

    }
}
