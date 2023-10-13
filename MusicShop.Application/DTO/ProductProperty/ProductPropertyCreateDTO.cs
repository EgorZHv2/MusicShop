using AutoMapper.Configuration.Annotations;
using MusicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.DTO.ProductProperty
{
    public class ProductPropertyCreateDTO
    {
       [Required]
       public string Name { get; set; }
       [Required]
       public PropertyValueType ValueType { get; set; }
     
       public List<string> Values { get; set; } = new List<string>();
    }
}
