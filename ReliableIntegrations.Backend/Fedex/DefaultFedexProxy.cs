namespace ReliableIntegrations.Backend.Fedex
{
    using System;
    using NServiceBus;
    using NServiceBus.Config;

    public class DefaultFedexProxy : IFedexProxy,INeedInitialization
    {
        public string BookPickup(Guid orderId)
        {
            Console.Out.WriteLine("Fedex: Pickup booked for order {0}", orderId);
            return Guid.NewGuid().ToString();
        }

        public void Init()
        {
            Configure.Instance.Configurer.ConfigureComponent<DefaultFedexProxy>(DependencyLifecycle.InstancePerCall);
        }
    }
}