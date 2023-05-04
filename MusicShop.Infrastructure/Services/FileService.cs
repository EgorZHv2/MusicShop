using Microsoft.AspNetCore.Http;
using MusicShop.Application.DTO.File;
using MusicShop.Application.Interfaces.Repositories;
using MusicShop.Application.Interfaces.Services;
using MusicShop.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Infrastructure.Services
{
    public class FileService:IFileService
    {
        private readonly IFileInfoRepository _fileInfoRepository;
        public FileService(IFileInfoRepository fileInfoRepository)
        {
            _fileInfoRepository = fileInfoRepository;
        }
        public async Task Create(FileCreateDTO dto)
        {
            var filesInfosList = new List<FileInfoEntity>();
            await DeleteAllByParentEntityId(dto.ParentEntityId);
            foreach (var item in dto.FormFiles)
            {
                var fileExtension = item.FileName.Split(".").Last();
                var fileName = Guid.NewGuid().ToString();
                var folderName = "files" + "/" + dto.ParentEntityId.ToString();
                if (!Directory.Exists(folderName))
                {
                    Directory.CreateDirectory(folderName);
                }

                var filePath = folderName + "/" + fileName + "." + fileExtension;
                using (Stream stream = new FileStream(filePath, FileMode.Create))
                {

                    await item.CopyToAsync(stream);
                }
                var entity = new FileInfoEntity
                {
                    Extension = fileExtension,
                    Name = fileName,
                    ParentEntityId = dto.ParentEntityId
                };
                filesInfosList.Add(entity);
            }
            await _fileInfoRepository.CreateMany(filesInfosList);
        }
        public async Task DeleteAllByParentEntityId(Guid entityId)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "files", entityId.ToString());
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            await _fileInfoRepository.HardDeleteAllByParentId(entityId);     
        }
        public async Task<IEnumerable<string>> GetFilesUrisByParentId(Guid id)
        {
           
            var fileNames = await _fileInfoRepository.GetFilesNamesByParentId(id);
            var result = fileNames.Select(e => new String("https://localhost:7030" + "/static" + "/" + id.ToString() + "/" + e));
            return result;

        }
    }
}
