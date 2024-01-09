using AutoMapper;
using Events;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Consumers
{
    public class ProductUpdatedConsumer : IConsumer<ProductUpdated>
    {
        private readonly IMapper _mapper;

        public ProductUpdatedConsumer(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<ProductUpdated> productUpdated)
        {
            Console.WriteLine("Consuming product update " + productUpdated.Message.Id);

            var product = _mapper.Map<Product>(productUpdated.Message);

            var result = await DB.Update<Product>().Match(product => product.ID == productUpdated.Message.Id).ModifyOnly(
                product => new
                {
                    product.Name,
                    product.Description,
                    product.Price,
                    product.Brand,
                    product.ImageUrl,
                    product.UpdatedAt,

                }, product).ExecuteAsync();
            if (!result.IsAcknowledged)
                throw new MessageException(typeof(ProductUpdated), "Problem updating mongodb");
        }
    }
}