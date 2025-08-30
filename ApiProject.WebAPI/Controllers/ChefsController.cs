using ApiProject.WebAPI.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly APIContext _context;

        public ChefsController(APIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetChefs()
        {
            var chefs = _context.Chefs.ToList();
            return Ok(chefs);
        }

        [HttpGet("id")]
        public IActionResult GetChefById(int id)
        {
            var chef = _context.Chefs.Find(id);
            if (chef == null)
            {
                return NotFound("Chef not found");
            }
            return Ok(chef);
        }


        [HttpPost]
        public IActionResult CreateChef(Entities.Chef chef)
        {
            _context.Chefs.Add(chef);
            _context.SaveChanges();
            return Ok("Chef is added");
        }
        [HttpDelete("{id}")]

        public IActionResult DeleteChef(int id)
        {
            var chef = _context.Chefs.Find(id);
            if (chef == null)
            {
                return NotFound("Chef not found");
            }
            _context.Chefs.Remove(chef);
            _context.SaveChanges();
            return Ok("Chef is deleted");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateChef(int id, Entities.Chef updatedChef)
        {
            var chef = _context.Chefs.Find(id);
            if (chef == null)
            {
                return NotFound("Chef not found");
            }
            chef.Name = updatedChef.Name;
            chef.Title = updatedChef.Title;
            chef.Description = updatedChef.Description;
            chef.PhotoURL = updatedChef.PhotoURL;
            _context.SaveChanges();
            return Ok("Chef is updated");
        }
    }
}
