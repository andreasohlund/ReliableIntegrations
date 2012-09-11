using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReliableIntegrations.Tests
{
    using NServiceBus;
    using NUnit.Framework;

    public class IntegrationTest
    {
        protected static IBus Bus { get; set; }

        [SetUp]
        public void SetUp()
        {
            if (Bus == null)
                Bus = Configure.With()
                    .DefineEndpointName("UnitTests")
                    .DefaultBuilder()
                    .XmlSerializer()
                    .MsmqTransport()
                    .UnicastBus()
                    .SendOnly();
        }
    }
}
