using ApiProject.WebAPI.Context;
using ApiProject.WebAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly Context.APIContext _context;

        public CategoriesController(APIContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult CreateCategory(Entities.Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok("Category is added");
        }

        [HttpGet]
        public IActionResult ListCategory()
        {
            var values = _context.Categories.ToList();
            return Ok(values);
        }

        [HttpDelete]
        public IActionResult CategoryDelete(int id)
        {
            var values = _context.Categories.Find(id);
            _context.Categories.Remove(values);
            _context.SaveChanges();
            return Ok("Category is deleted");
        }

        [HttpGet("GetById")]
        public IActionResult CategoryGetById(int id)
        {
            var values = _context.Categories.Find(id);
            return Ok(values.Name);
        }

        [HttpPut]
        public IActionResult CategoryUpdate(int id, string name)
        {
            var values = _context.Categories.Find(id);
            values.Name = name;
            _context.SaveChanges();
            return Ok("Category is updated");
        }

    }
}
