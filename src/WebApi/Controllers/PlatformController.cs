namespace ApiService.WepApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ApiService.Contracts.Commands;
    using ApiService.Contracts.Queries;
    using ApiService.Core.Abstraction;
    using ApiService.Core.Models;
    using ApiService.Infra;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    [Route("[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformServiceRepository _platformServiceRepository;
        private readonly IMapper _mapper;
        private readonly ICommandServiceClient _commandServiceClient;

        public PlatformController(
            IPlatformServiceRepository platformServiceRepository,
            IMapper mapper,
            ICommandServiceClient commandServiceClient)
        {
            _platformServiceRepository = platformServiceRepository;
            _mapper = mapper;
            _commandServiceClient = commandServiceClient;
        }

        [HttpGet("platforms")]
        public async Task<ActionResult<IEnumerable<PlatformReadQuery>>> GetPlatforms()
        {
            Console.WriteLine("GET platforms");

            var platformItem = await _platformServiceRepository.GetPlatformsAsync();

            return Ok(_mapper.Map<IEnumerable<PlatformReadQuery>>(platformItem));
        }

        [HttpGet("{id}", Name = nameof(GetPlatformById))]
        public async Task<ActionResult<PlatformReadQuery>> GetPlatformById([FromRoute] int id)
        {
            var platformItem = await _platformServiceRepository.GetPlatformIdAsync(id);

            if (platformItem != null)
            {
                return Ok(_mapper.Map<PlatformReadQuery>(platformItem));
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<PlatformReadQuery>> CreatePlatformDto([FromBody] PlatformCreateCommand createCommand)
        {
            var platformModel = _mapper.Map<PlatformModel>(createCommand);
            await _platformServiceRepository.CreatePlatformAsync(platformModel);
            await _platformServiceRepository.SaveChangesAsync();

            var platformDto = _mapper.Map<PlatformReadQuery>(platformModel);

            await _commandServiceClient.SendPlatformToCommand(platformDto);

            return CreatedAtRoute(nameof(GetPlatformById), new { platformDto.Id }, platformDto);
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
