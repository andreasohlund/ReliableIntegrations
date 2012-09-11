namespace ReliableIntegrations.Backend.Fedex
{
    using System;
    using System.Collections.Generic;
    using NServiceBus;
    using NServiceBus.Config;

    public class DefaultFedexProxy : IFedexProxy,INeedInitialization
    {
        public string BookPickup(Guid orderId)
        {
            if (!shippingCodes.ContainsKey(orderId))
            {
                Console.Out.WriteLine("Fedex: Pickup booked for order {0}", orderId);
                shippingCodes[orderId] = Guid.NewGuid().ToString();
            }
            return shippingCodes[orderId];
       }

        public void Init()
        {
            Configure.Instance.Configurer.ConfigureComponent<DefaultFedexProxy>(DependencyLifecycle.InstancePerCall);
        }

        //to simulate idempotency
        static IDictionary<Guid, string> shippingCodes = new Dictionary<Guid, string>();
    }
}