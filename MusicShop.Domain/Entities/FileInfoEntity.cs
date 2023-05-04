using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Domain.Entities
{
    public class FileInfoEntity:BaseEntity
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public Guid ParentEntityId { get; set; }
    }
}
