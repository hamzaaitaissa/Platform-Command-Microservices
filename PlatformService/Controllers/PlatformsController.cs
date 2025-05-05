using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.DTOs;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _platformRepo;
        private readonly IMapper _mapper;
        public PlatformsController(IPlatformRepo platformRepo, IMapper mapper)
        {
            _mapper = mapper;
            _platformRepo = platformRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Platform>> GetAllPlatforms()
        {
            var platforms = _platformRepo.GetAllPlatforms();
            return Ok(platforms);
        }

        [HttpPost]
        public ActionResult<Platform> CreatePlatform(PlatformCreateDto platformCreateDto)
        {
            var platform = _mapper.Map<Platform>(platformCreateDto);
            _platformRepo.CreatPlatform(platform);
            _platformRepo.Savechanges();

            var platformReadDto = _mapper.Map<PlatformReadDto>(platform);
            return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformReadDto.Id },platformReadDto);

        }

        [HttpGet("{id}")]
        public ActionResult<Platform> GetPlatformById(int id)
        {
            var platform = _platformRepo.GetPlatformById(id);
            return Ok(platform);
        }

    }
}
