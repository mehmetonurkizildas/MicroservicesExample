using AutoMapper;
using Events;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Consumers
{
    public class ProductCreatedConsumer : IConsumer<ProductCreated>
    {
        private readonly IMapper _mapper;

        public ProductCreatedConsumer(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task Consume(ConsumeContext<ProductCreated> productCreated)
        {
            Console.WriteLine("Consuming product created " + productCreated.Message.Id);

            var product = _mapper.Map<Product>(productCreated.Message);

            await product.SaveAsync();
        }
    }
}
