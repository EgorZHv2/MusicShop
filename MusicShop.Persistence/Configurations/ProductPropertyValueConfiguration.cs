﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Persistance.Configurations
{
    public class ProductPropertyValueConfiguration:IEntityTypeConfiguration<ProductPropertyValueEntity>
    {
        public void Configure(EntityTypeBuilder<ProductPropertyValueEntity> entityTypeBuilder)
        {

        }
    }
}
