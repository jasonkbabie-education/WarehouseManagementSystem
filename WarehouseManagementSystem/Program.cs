using System.Net.NetworkInformation;
using System.Text.Json;
using WarehouseManagementSystem.Business;
using WarehouseManagementSystem.Domain;
using WarehouseManagementSystem.Domain.Extensions;

var payload = new byte[1024];
var validator = new PayloadValidator();
validator.Validate(payload);
 var first = payload[0];