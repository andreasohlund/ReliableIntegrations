namespace ReliableIntegrations.Tests
{
    using System;
    using Backend.Contracts;
    using NServiceBus;
    using NUnit.Framework;

    public class PlaceAFailingOrder : IntegrationTest
    {
        [Test]
        public void Test()
        {
            Bus.Send<PlaceOrder>(m =>
                {
                    m.OrderId = Guid.Empty;
                });
        }
    }

}