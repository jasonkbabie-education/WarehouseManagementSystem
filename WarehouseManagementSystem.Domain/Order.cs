namespace WarehouseManagementSystem.Domain
{
    public class Order
    {
        public Guid OrderNumber { get; init; }
        public ShippingProvider ShippingProvider { get; init; }
        public int Total { get; }
        public bool IsReadyForShipment { get; set; } = true;
        public IEnumerable<Item> LineItems { get; set; }

        public Order()
        {
            OrderNumber = Guid.NewGuid();
        }

        public void Deconstruct(out int total, out bool isRead)
        {
            total = Total;
            isRead = IsReadyForShipment;
        }
    }

    public class PriorityOrder : Order { }

    public class ShippedOrder : Order {
        public DateTime ShippedDate { get; set; }
    }

    public class CancelledOrder : Order {
        public DateTime CancelledOrder { get; set; }
    }

    public class ProcessedOrder : Order { }

    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
    }
}