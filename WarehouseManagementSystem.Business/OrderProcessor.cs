﻿using WarehouseManagementSystem.Domain;

namespace WarehouseManagementSystem.Business
{
    public class OrderProcessor
    {
        public Func<Order, bool>? OnOrderInitialized { get; set; }

        public event EventHandler<OrderCreatedEventArgs> OrderCreated;

        protected virtual void OnOrderCreated(OrderCreatedEventArgs args)
        {
            OrderCreated?.Invoke(this, args);
        }

        private void Initialize(Order order)
        {
            ArgumentNullException.ThrowIfNull(order);
            if (OnOrderInitialized?.Invoke(order) == false)
            {
                throw new Exception($"Couldn't initialize {order.OrderNumber}");
            }
        }

        public void Process(Order order, Action<Order> onCompleted = default)
        {
            // Run some code..

            Initialize(order);
            OnOrderCreated(new()
            {
                Order = order,
                OldTotal = 100,
                NewTotal = 80
            });
            onCompleted?.Invoke(order);
            // How do I produce a shipping label?
        }

        public (Guid orderNumber,
            int amountOfItems,
            decimal total,
            IEnumerable<Item> items)
            Process(IEnumerable<Order> orders)
        {
            var summaries = orders.Select(order =>
            {
                return
                (
                    Order : order.OrderNumber,
                    Items : order.LineItems.Count(),
                    Total : order.LineItems.Sum(item => item.Price),
                    order.LineItems
                );
            });

            var orderedSummaries = summaries.OrderBy(summary => summary.Total);

            var summary = orderedSummaries.FirstOrDefault();
            var summaryWithTax = summary with { Total = summary.Total * 1.25m};
            return summaryWithTax;
        }

        private decimal CalculateFrightCost(Order order)
        => order.ShippingProvider switch
            {
                SwedishPostalServiceShippingProvider { DeliverNextDay: true }
                provider => provider.FreightCost + 50m,

                SwedishPostalServiceShippingProvider
                provider => provider.FreightCost - 50m,
                var provider => provider?.FreightCost ?? 50m
            };
    }
}