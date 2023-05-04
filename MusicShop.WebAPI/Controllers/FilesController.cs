using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Application.DTO.File;
using MusicShop.Application.Interfaces.Services;

namespace MusicShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _fileService;
        public FilesController(IFileService fileService) 
        {
            _fileService = fileService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] FileCreateDTO dto)
        {
            await _fileService.Create(dto);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFilesUrisByParentId(Guid id)
        {
            var result = await _fileService.GetFilesUrisByParentId(id);
            return Ok(result);
        }
    }
}
