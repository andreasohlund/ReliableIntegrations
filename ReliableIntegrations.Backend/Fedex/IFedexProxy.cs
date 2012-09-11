namespace ReliableIntegrations.Backend.Fedex
{
    using System;

    public interface IFedexProxy
    {
        string BookPickup(Guid orderId);
    }

    public interface IFedexProxyV2
    {
        FedexTicket RequestPickupTicket(Guid orderId);

        string GetShipmentDetails(FedexTicket ticket);
    }

    public class FedexTicket
    {
        public Guid TicketId { get; set; }

        public DateTime AvailableAt { get; set; }
    }
}