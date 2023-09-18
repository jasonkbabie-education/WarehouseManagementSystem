using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Business
{
    public class PayloadValidator
    {
        public bool Validate(Span<byte> payload)
        {
            var signature = payload[^128..];
            payload[0] = 1;
            foreach (var b in signature)
                if (b == 1)
                    return false;
            return true;
        }
    }
}
