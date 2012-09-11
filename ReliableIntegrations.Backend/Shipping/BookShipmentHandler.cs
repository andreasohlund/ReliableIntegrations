namespace ReliableIntegrations.Backend.Sales
{
    using System;
    using Contracts;
    using Fedex;
    using NServiceBus;

    public class BookShipmentHandler : IHandleMessages<BookShipment>
    {
        public IFedexProxy Fedex { get; set; }
        public IBus Bus { get; set; }

        public void Handle(BookShipment message)
        {
            var trackingCode = Fedex.BookPickup(message.OrderId);

            //if (message.GetHeader("NServiceBus.Retries") == null)
            //    throw new Exception("Http timeout");
            Bus.Reply<ShipmentBooked>(m =>
                {
                    m.OrderId = message.OrderId;
                    m.TrackingCode = trackingCode;
                });
        }
    }
}