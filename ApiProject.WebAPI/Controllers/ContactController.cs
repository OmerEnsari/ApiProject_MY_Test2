using ApiProject.WebAPI.Context;
using ApiProject.WebAPI.Dtos.ContactDtos;
using ApiProject.WebAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly  APIContext _context;
        public ContactController(APIContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var contacts = _context.Contacts.ToList();
            return Ok(contacts);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            Contact contact = new Contact
            {
                MapLocation = createContactDto.MapLocation,
                Phone = createContactDto.Phone,
                Adress = createContactDto.Adress,
                Email = createContactDto.Email,
                OpenHours = createContactDto.OpenHours
            };
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok("Added");
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            return Ok("Deleted");
        }

        [HttpPut]
        public IActionResult UpdateContact(int id, UpdateContactDto updateContactDto)
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }
            contact.MapLocation = updateContactDto.MapLocation;
            contact.Phone = updateContactDto.Phone;
            contact.Adress = updateContactDto.Adress;
            contact.Email = updateContactDto.Email;
            contact.OpenHours = updateContactDto.OpenHours;
            _context.SaveChanges();
            return Ok("Updated");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

    }
}
