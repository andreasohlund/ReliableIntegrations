namespace ReliableIntegrations.Tests
{
    using System;
    using Backend.Contracts;
    using NUnit.Framework;

    public class PlaceANewOrder : IntegrationTest
    {
        [Test]
        public void Test()
        {
            Bus.Send<PlaceOrder>(m => m.OrderId = Guid.NewGuid());
        }
    }

}