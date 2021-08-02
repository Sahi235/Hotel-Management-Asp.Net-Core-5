using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// ReSharper disable once IdentifierTypo
namespace DataAccess.Cryptoghraphy
{
    public interface ISecretStore
    {
        string GetKey(string keyName, int keyIndex);
        string GetSalt(string saltName);
    }
}
