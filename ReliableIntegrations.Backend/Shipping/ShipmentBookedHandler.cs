namespace ReliableIntegrations.Backend.Sales
{
    using Contracts;
    using NServiceBus;

    public class ShipmentBookedHandler : IHandleMessages<ShipmentBooked>
    {
        public void Handle(ShipmentBooked message)
        {
            var order = DB.Load<Order>(message.OrderId);

            order.TrackingCode = message.TrackingCode;
            order.Status = OrderStatus.PickupBooked;

            DB.Save(order);

        }
    }
}