using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.DTO.File
{
    public class FileCreateDTO
    {
        public Guid ParentEntityId { get; set; }
        public IFormFileCollection FormFiles { get; set; } = new FormFileCollection();
    }
}
