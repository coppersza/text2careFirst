using System;
using API.Dtos.Users;

namespace API.Dtos.Orders
{
    public class OrderDto
    {
        public string BasketId { get; set; }
        public int DeliveryMethodId { get; set; }

        public AddressDto ShipToAddress { get; set; }
    }
}
