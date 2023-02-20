using ECommerceV2.Services.Abstract.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceV2.Services.Concrete.Encryption
{
    public class EncryptionStrategy
    {
        IEncryptionStrategy _enc = null;

        public EncryptionStrategy(IEncryptionStrategy enc)
        {
            _enc = enc;
        }

        public string Encrypt(string obj)
        {
            return _enc.Encrypt(obj);
        }
        public string Decyrpt(string obj)
        {
            return _enc.Decrypt(obj);
        }
    }
}
