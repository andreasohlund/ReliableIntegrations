namespace ReliableIntegrations.Backend
{
    using System;
    using Sales;

    public class DB
    {
        public static Guid GuidToSimulateDBRollback = new Guid("4e720d07-54d3-4deb-a228-c264890147d3");
       
        public static void Save(Order order)
        {
            //simulate failure
            if (order.Id == GuidToSimulateDBRollback)
                throw new Exception("Database rollback");

            Console.Out.WriteLine("Order with id {0} saved, status: {1}", order.Id, order.Status);
        }

        public static T Load<T>(Guid orderId) where T : class
        {
            return new Order { Id = orderId } as T;
        }
    }
}