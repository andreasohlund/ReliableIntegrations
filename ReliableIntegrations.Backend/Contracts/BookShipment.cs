namespace ReliableIntegrations.Backend.Contracts
{
    using System;
    using NServiceBus;

    public class BookShipment:IMessage
    {
        public Guid OrderId { get; set; }
    }
}