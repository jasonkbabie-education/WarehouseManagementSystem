using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Domain
{
    public record Customer(string Firstname, string Lastname)
    {
        public string Fullname => $"{Firstname} {Lastname}";
        public Address Address { get; init; }
    }

    public record Address(string street, string postalCode);
}
