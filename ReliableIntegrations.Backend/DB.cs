namespace ReliableIntegrations.Backend
{
    using System;
    using Sales;

    public class DB
    {
        public static void Save(Order order)
        {
            throw new Exception("Database rollback");
            Console.Out.WriteLine("Order with id {0} saved, status: {1}", order.Id, order.Status);
        }

        public static T Load<T>(Guid orderId) where T : class
        {
            return new Order { Id = orderId } as T;
        }
    }
}