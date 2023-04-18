﻿using MusicShop.Application.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<Guid> Create(CreateProductDTO dto);
        Task Update(UpdateProductDTO dto);
    }
}
