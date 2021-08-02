using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Cryptoghraphy.Hashing
{
    public interface IHasher
    {
        string CreateHash(string plainText, BaseCryptographyItem.HashAlgorithm algorithm);
        string CreateHash(string plainText, string salt, BaseCryptographyItem.HashAlgorithm algorithm);
        bool MatchesHash(string plainText, string hash);
    }
}
