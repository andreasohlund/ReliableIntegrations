namespace ReliableIntegrations.Backend
{
    using NServiceBus;
    using NServiceBus.Config;

    public class EndpointConfig:IConfigureThisEndpoint,AsA_Server
    {
    }

    class TurnOffAutoSubscribe:INeedInitialization
    {
        public void Init()
        {
            Configure.Instance.UnicastBus().DoNotAutoSubscribe();
        }
    }

}
