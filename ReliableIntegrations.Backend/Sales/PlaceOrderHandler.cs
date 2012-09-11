namespace ReliableIntegrations.Backend.Sales
{
    using System;
    using Contracts;
    using Fedex;
    using NServiceBus;

    public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        public IFedexProxy Fedex { get; set; }

        //public void Handle(PlaceOrder message)
        //{
        //    var order = new Order { Id = message.OrderId };

        //    order.TrackingCode = Fedex.BookPickup(order.Id);

        //    order.Status = OrderStatus.PickupBooked;

        //    DB.Save(order);
        //}

        public void Handle(PlaceOrder message)
        {
            DB.Save(new Order
                {
                    Id = message.OrderId,
                    Status = OrderStatus.Accepted
                });
            Bus.Send<BookShipment>(m => m.OrderId = message.OrderId);
        }

        public IBus Bus { get; set; }
    }


    public class Order
    {
        public Guid Id { get; set; }

        public string TrackingCode { get; set; }

        public OrderStatus Status { get; set; }
    }

    public enum OrderStatus
    {
        PickupBooked = 2,
        Accepted = 1
    }
}