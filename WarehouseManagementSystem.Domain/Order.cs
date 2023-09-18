using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json.Serialization;

namespace WarehouseManagementSystem.Domain
{
    public record Order (
        [property: JsonPropertyName("total")]
        decimal Total = 0,

        [property: JsonIgnore]
        IEnumerable<Item>? LineItems = default,

        [AllowNull]
        ShippingProvider ShippingProvider = default,

        bool IsReadyForShipment = true)
    {
        public Guid OrderNumber { get; init; } = Guid.NewGuid();

        [JsonIgnore]
        public ShippingProvider ShippingProvider { get; init; } = ShippingProvider ?? new();

        protected virtual bool PrintMembers(StringBuilder builder)
        {
            builder.Append("A custom implementation");
            return true;
        }

        public void Deconstruct(out decimal sum, out bool isRead)
        {
            sum = Total;
            isRead = IsReadyForShipment;
        }
    }

    public record PriorityOrder(
        decimal Total,
        ShippingProvider ShippingProvider,
        IEnumerable<Item> LineItems,
        bool IsReadyForShipment = true
        ) : Order(Total, LineItems, ShippingProvider, IsReadyForShipment) { }

    public record ShippedOrder(
                decimal Total,
        ShippingProvider ShippingProvider,
        IEnumerable<Item> LineItems,
        bool IsReadyForShipment = true
        ) : Order(Total, LineItems, ShippingProvider, IsReadyForShipment)
    {
        public DateTime ShippedDate { get; set; }
    }

    public record CancelledOrder(decimal Total,
        ShippingProvider ShippingProvider,
        IEnumerable<Item> LineItems,
        bool IsReadyForShipment = true
        )  : Order(Total, LineItems, ShippingProvider, IsReadyForShipment)
    {
        public DateTime CancelledDate { get; set; }
    }

    public record ProcessedOrder(decimal Total,
        ShippingProvider ShippingProvider,
        IEnumerable<Item> LineItems,
        bool IsReadyForShipment = true
        )  : Order(Total, LineItems, ShippingProvider, IsReadyForShipment)
    { }

    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
    }
}