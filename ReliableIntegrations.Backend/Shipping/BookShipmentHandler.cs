namespace ReliableIntegrations.Backend.Sales
{
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

            Bus.Reply<ShipmentBooked>(m =>
                {
                    m.OrderId = message.OrderId;
                    m.TrackingCode = trackingCode;
                });
        }
    }
}