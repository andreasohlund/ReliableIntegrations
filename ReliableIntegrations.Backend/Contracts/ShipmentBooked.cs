namespace ReliableIntegrations.Backend.Contracts
{
    using System;
    using NServiceBus;

    public class ShipmentBooked:IMessage
    {
        public Guid OrderId { get; set; }

        public string TrackingCode { get; set; }
    }
}