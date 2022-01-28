using PlatformService.Models;

namespace PlatformService.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using PlatformService.Data;
    using PlatformService.Dto;

    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformServiceRepository _platformServiceRepository;
        private readonly IMapper _mapper;

        public PlatformController(IPlatformServiceRepository platformServiceRepository, IMapper mapper)
        {
            _platformServiceRepository = platformServiceRepository;
            _mapper = mapper;
        }

        [HttpGet("platforms")]
        public async Task<ActionResult<IEnumerable<PlatformReadDto>>> GetPlatforms()
        {
            Console.WriteLine("GET platforms");

            var platformItem = await _platformServiceRepository.GetPlatformsAsync();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItem));
        }

        [HttpGet("{id}", Name = nameof(GetPlatformById))]
        public async Task<ActionResult<PlatformReadDto>> GetPlatformById([FromRoute] int id)
        {
            var platformItem = await _platformServiceRepository.GetPlatformIdAsync(id);

            if (platformItem != null)
            {
                return Ok(_mapper.Map<PlatformReadDto>(platformItem));
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<PlatformReadDto>> CreatePlatformDto([FromBody] PlatformCreateDto createDto)
        {
            var platformModel = _mapper.Map<Platform>(createDto);
            await _platformServiceRepository.CreatePlatformAsync(platformModel);
            await _platformServiceRepository.SaveChangesAsync();

            var platformDto = _mapper.Map<PlatformReadDto>(platformModel);

            return CreatedAtRoute(nameof(GetPlatformById), new {Id = platformDto.Id}, platformDto);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
