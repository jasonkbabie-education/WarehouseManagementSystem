using System.Net.NetworkInformation;
using System.Text.Json;
using WarehouseManagementSystem.Business;
using WarehouseManagementSystem.Domain;
using WarehouseManagementSystem.Domain.Extensions;


IEnumerable<Order> orders = JsonSerializer.Deserialize<Order[]>(File.ReadAllText("orders.json"));


//var order = new Order()
//{
//    LineItems = new[]
//    {
//        new Item { Name = "PS1", Price = 50 },
//        new Item { Name = "PS2", Price = 60 },
//        new Item { Name = "PS3", Price = 70 },
//        new Item { Name = "PS4", Price = 80 },
//    }
//};

//Console.WriteLine(order.GenerateReport("Jason Babie"));

//foreach (var item in order.LineItems.Find(null))
//{
//    Console.WriteLine(item.Price);
//}
//var processor = new OrderProcessor();
//processor.OnOrderInitialized = ourOrder =>
//{
//    Console.WriteLine($"Please pack the order {ourOrder.OrderNumber}");
//    return true;
//};

//processor.OrderCreated += (sender, arguments) =>
//{
//    Thread.Sleep(1000);
//    Console.WriteLine("1");
//};

//processor.OrderCreated += Log;

//void Log(object? sender, OrderCreatedEventArgs e)
//{
//    Console.WriteLine("Order created");
//}

//processor.Process(order, myOrder =>
//{
//    Console.WriteLine($"Order Confirmation Email for order {order.OrderNumber}");
//});