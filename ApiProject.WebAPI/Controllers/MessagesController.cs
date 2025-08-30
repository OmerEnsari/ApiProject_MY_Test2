using ApiProject.WebAPI.Context;
using ApiProject.WebAPI.Dtos.MessageDtos;
using ApiProject.WebAPI.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly APIContext _context;
        public MessagesController(IMapper mapper, APIContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            var newMessage = _mapper.Map<ContactMessage>(createMessageDto);
            _context.ContactMessages.Add(newMessage);
            _context.SaveChanges();
            return Ok("Message is added");
        }
        [HttpGet]
        public IActionResult GetMessages()
        {
            var messages = _context.ContactMessages.ToList();
            return Ok(_mapper.Map<List<ResultMessageDto>>(messages));
        }
        [HttpGet("{id}")]
        public IActionResult GetMessageById(int id)
        {
            var message = _context.ContactMessages.Find(id);
            if (message == null)
            {
                return NotFound("Message not found");
            }
            return Ok(_mapper.Map<ResultMessageDto>(message));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var message = _context.ContactMessages.Find(id);
            if (message == null)
            {
                return NotFound("Message not found");
            }
            _context.ContactMessages.Remove(message);
            _context.SaveChanges();
            return Ok("Message is deleted");
        }
        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            var message = _mapper.Map<ContactMessage>(updateMessageDto);
            if (message == null)
            {
                return NotFound("Message not found");
            }
            _context.ContactMessages.Update(message);
            _context.SaveChanges();
            return Ok("Message is updated");
        }


    }
}
