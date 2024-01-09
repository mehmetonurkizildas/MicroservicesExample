using Events;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Consumers
{
    public class ProductDeletedConsumer : IConsumer<ProductDeleted>
    {
        public async Task Consume(ConsumeContext<ProductDeleted> productDeleted)
        {
            Console.WriteLine("Consuming product delete " + productDeleted.Message.Id);

            var result = await DB.DeleteAsync<Product>(productDeleted.Message.Id);

            if (!result.IsAcknowledged)
                throw new MessageException(typeof(ProductDeleted), "Problem deleting Course");
        }

    }
}
