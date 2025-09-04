using ApiProject.WebAPI.Context;
using ApiProject.WebAPI.Dtos.ProductDtos;
using ApiProject.WebAPI.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IValidator<Product> _productValidator;
        private readonly APIContext _context;
        private readonly IMapper _mapper;
        public ProductController(IValidator<Product> productValidator, APIContext context, IMapper mapper)
        {
            _productValidator = productValidator;
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var validationResult = _productValidator.Validate(product);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }

            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok(new {message = "Product is added", data = product });
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound("Product not found");
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok("Product is deleted");
        }
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound("Product not found");
            }
            return Ok(product);
        }

        [HttpPut]
        public IActionResult PutProduct(Product product)
        {
            var validationResult = _productValidator.Validate(product);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }

            _context.Products.Update(product);
            _context.SaveChanges();
            return Ok(new { message = "Product is updated   ", data = product });
        }
        [HttpPost("CreateWithCategory")]
        public IActionResult CreateProductWithCategory(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            _context.Products.Add(value);
            _context.SaveChanges();
            return Ok(new { message = "Product is added", data = value });
        }
        [HttpGet("GetProductWithCategory")]
        public IActionResult GetProductWithCategory()
        {
            var products = _context.Products.Include(x => x.Category).ToList();
            return Ok(_mapper.Map<List<ResultProductWithCategory>>(products));
        }
    }
}
