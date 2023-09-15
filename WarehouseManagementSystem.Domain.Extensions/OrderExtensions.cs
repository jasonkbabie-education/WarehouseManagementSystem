using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Domain;

namespace WarehouseManagementSystem.Domain.Extensions
{
    public static class OrderExtensions
    {
        public static string GenerateReport(this Order order)
        {
            return $"ORDER REPORT ({order.OrderNumber})" +
                $"{Environment.NewLine}" +
                $"Items: {order.LineItems.Count()}" +
                $"{Environment.NewLine}" +
                $"Total: {order.Total}" +
                $"{Environment.NewLine}";
        }

        public static string GenerateReport(this Order order, string recipient)
        {
            var status = order switch
            {
                ( > 100, true) match => "High Priority Order",
                ( var total, true) => $"Order is ready {total}",
                (_, false) => "Order is not ready",
                _ => "Order is null!"
            };

            var shippingProviderStatus =
                (order.ShippingProvider, order.LineItems.Count(), order.IsReadyForShipment)
                switch
                {
                    (_, >10, true) => "Multiple shipments!",
                    (SwedishPostalServiceShippingProvider, 1, _)
                    => "Manual pickup required",
                    (_, _, true) => "Ready for shipment",
                    (_, _, false) => "Not ready for shipment"
                };


            return $"ORDER REPORT ({order.OrderNumber})" +
                $"{Environment.NewLine}" +
                $"Items: {order.LineItems.Count()}" +
                $"{Environment.NewLine}" +
                $"Total: {order.Total}" +
                $"{Environment.NewLine}" +
                $"{status} {shippingProviderStatus}" +
                $"Send to: {recipient}";
        }
    }
}
