using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Application.DTO.File;
using MusicShop.Application.Interfaces.Services;
using MusicShop.Domain.Enums;
using MusicShop.WebAPI.Filters;

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
        /// <summary>
        /// Добавление файла
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="404">Не найдено</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpPost]
        [CustomAuthorize]
        public async Task<IActionResult> Create([FromForm] FileCreateDTO dto)
        {
            await _fileService.Create(dto);
            return Ok();
        }
        /// <summary>
        /// Получение ссылок на файлы по Id родительской сущности
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="404">Не найдено</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpGet("{id}")]
        [CustomAuthorize]
        public async Task<IActionResult> GetFilesUrisByParentId(Guid id)
        {
            var result = await _fileService.GetFilesUrisByParentId(id);
            return Ok(result);
        }
        /// <summary>
        /// Удаление файлов по Id родительской сущности
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="404">Не найдено</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpDelete("{id}/by-parent-id")]
        [CustomAuthorize]
        public async Task<IActionResult> DeleteFilesByParentId(Guid id)
        {
            await _fileService.DeleteAllByParentEntityId(id);
            return Ok();
        }

         /// <summary>
        /// Удаление файла по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="404">Не найдено</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpDelete("{id}")]
        [CustomAuthorize]
        public async Task<IActionResult> DeleteFileById(Guid id)
        {
            await _fileService.DeleteFileById(id);
            return Ok();
        }
    }
}
