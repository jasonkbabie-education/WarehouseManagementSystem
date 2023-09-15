using System.Net.NetworkInformation;
using System.Text.Json;
using WarehouseManagementSystem.Business;
using WarehouseManagementSystem.Domain;
using WarehouseManagementSystem.Domain.Extensions;

var order = new Order();

var (total, isReady) = order;