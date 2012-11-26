namespace ReliableIntegrations.Backend.Sales
{
    using System;
    using Contracts;
    using Fedex;
    using NServiceBus;

    public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        public IFedexProxy Fedex { get; set; }

        // A first stab at the problem
        public void Handle(PlaceOrder message)
        {
            var order = new Order { Id = message.OrderId };

            order.TrackingCode = Fedex.BookPickup(order.Id);

            order.Status = OrderStatus.PickupBooked;

            DB.Save(order);
        }

        //the messaging way
        //public void Handle(PlaceOrder message)
        //{
        //    Bus.Send<BookShipment>(m => m.OrderId = message.OrderId);

        //    DB.Save(new Order
        //        {
        //            Id = message.OrderId,
        //            Status = OrderStatus.Accepted
        //        });
        //}

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