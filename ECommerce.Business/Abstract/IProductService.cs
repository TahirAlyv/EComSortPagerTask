﻿using ECommerce.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<List<Product>> GetAllCategoryAsync(int categoryId);
    }
}
