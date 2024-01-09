using AutoMapper;
using Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.Entities;
using ProductService.Models;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;
        public ProductController(ProductDbContext context, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _context = context;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAllProducts()
        {
            var products = await _context.Products
            .OrderBy(x => x.UpdatedAt)
            .ToListAsync();

            return _mapper.Map<List<ProductDto>>(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(Guid id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product == null) return NotFound();

            return _mapper.Map<ProductDto>(product);
        }
        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);

            _context.Products.Add(product);

            var newProduct = _mapper.Map<ProductDto>(product);

            await _publishEndpoint.Publish(_mapper.Map<ProductCreated>(newProduct));

            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return BadRequest("Could not save changes to the DB");

            return CreatedAtAction(nameof(GetProductById),
                new { product.Id }, newProduct);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(Guid id, UpdateProductDto updateProductDto)
        {

            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product == null) return NotFound();

            product.Description = updateProductDto.Description ?? product.Description;
            product.Name = updateProductDto.Name ?? product.Name;
            product.Price = updateProductDto.Price;
            product.Brand = updateProductDto.Brand ?? product.Brand;
            product.StockStatus = updateProductDto.StockStatus;
            product.ImageUrl = updateProductDto.ImageUrl ?? product.ImageUrl;
            product.UpdatedAt = DateTime.UtcNow;

            await _publishEndpoint.Publish(_mapper.Map<ProductUpdated>(product));

            var result = await _context.SaveChangesAsync() > 0;

            if (result) return Ok();

            return BadRequest("Problem saving changes");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null) return NotFound();

            _context.Products.Remove(product);

            await _publishEndpoint.Publish<ProductDeleted>(new { Id = product.Id.ToString() });

            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return BadRequest("Could not update DB");

            return Ok();
        }
    }
}
