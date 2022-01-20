﻿using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetSingleCateogryByWithProductAsync(int categoryId)
        {
            return await _context.Categories.Include(m => m.Products).SingleOrDefaultAsync(m => m.Id == categoryId);
        }
    }
}
