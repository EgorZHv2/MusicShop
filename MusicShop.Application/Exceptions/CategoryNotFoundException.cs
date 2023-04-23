using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.Exceptions
{
    public class CategoryNotFoundException:ApiException
    {
        public CategoryNotFoundException():base("Category not found",System.Net.HttpStatusCode.NotFound) { }
    }
}
