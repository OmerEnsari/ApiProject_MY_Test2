using ApiProject.WebAPI.Context;
using ApiProject.WebAPI.Dtos.FeatureDtos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly APIContext _context;

        public FeaturesController(IMapper mapper, APIContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public IActionResult FeatureGetAll()
        {
            var values = _context.Features.ToList();
            return Ok(_mapper.Map<List<ResultFeatureDto>>(values));
        }

        [HttpGet("{id}")]
        public IActionResult FeatureGetById(int id)
        {
            var value = _mapper.Map<GetByIdFeatureDto>(_context.Features.Find(id));
            if (value == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GetByIdFeatureDto>(value));
        }
        [HttpPost]
        public IActionResult FeatureAdd(CreateFeatureDto createFeatureDto)
        {
            var value = _mapper.Map<Entities.Feature>(createFeatureDto);
            _context.Features.Add(value);
            _context.SaveChanges();
            return Ok("Feature is added");
        }
        [HttpPut]
        public IActionResult FeatureUpdate(UpdateFeatureDto updateFeatureDto)
        {
            var value = _mapper.Map<Entities.Feature>(updateFeatureDto);
            _context.Features.Update(value);
            _context.SaveChanges();
            return Ok("Feature is updated");
        }
        [HttpDelete("{id}")]
        public IActionResult FeatureDelete(int id)
        {
            var value = _context.Features.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            _context.Features.Remove(value);
            _context.SaveChanges();
            return Ok("Feature is deleted");
        }
    }
}
