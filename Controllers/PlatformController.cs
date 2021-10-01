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
        public async Task<ActionResult<IEnumerable<PlatformReadDto>>> Get()
        {
            Console.WriteLine("GET platforms");

            var platformItem = await _platformServiceRepository.GetPlatformsAsync();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItem));
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
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
