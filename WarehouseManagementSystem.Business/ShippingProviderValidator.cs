using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Domain;

namespace WarehouseManagementSystem.Business
{
    public class ShippingProviderValidator
    {
        public static bool ValidateShippingProvider(
            [NotNullWhen(true)]
            ShippingProvider? provider)
        {
            return provider is { FreightCost: > 100 };
        }
    }
}
