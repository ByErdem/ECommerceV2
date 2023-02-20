using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceV2.Services.Abstract.Encryption
{
    public interface IEncryptionStrategy
    {
        string Encrypt(string data);
        string Decrypt(string data);
    }
}
