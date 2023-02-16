﻿using BethanysPieShop.Models;

namespace BethanysPieShop.Data
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();
    }
}
