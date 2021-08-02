using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Cryptoghraphy.Symmetric
{
    public interface ISymmetricEncryptor
    {
        string EncryptString(string plainText, string keyName);
        string DecryptString(string cipherText, string keyName);
    }
}
