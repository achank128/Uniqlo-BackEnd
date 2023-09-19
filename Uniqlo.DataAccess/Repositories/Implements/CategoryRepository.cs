using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.DataAccess.Repositories.Interfaces;
using Uniqlo.DataAccess.RepositoryBase;
using Uniqlo.Models.Context;
using Uniqlo.Models.EntityModels;

namespace Uniqlo.DataAccess.Repositories.Implements
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        private readonly UniqloContext _context;
        public CategoryRepository(UniqloContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetCategoriesByGenderType(int genderTypeId)
        {
            var categories = await _context.Categories
                .Where(c => c.GenderTypeId == genderTypeId && c.ParentId == null)
                .Select(c => new Category
                {
                    Id = c.Id,
                    Name = c.Name,
                    NameEn = c.NameEn,
                    NameVi = c.NameVi,
                    Description = c.Description,
                    DescriptionEn = c.DescriptionEn,
                    DescriptionVi = c.DescriptionVi,
                    Column = c.Column,
                    Position = c.Position,
                    GenderTypeId = genderTypeId,
                    ParentId = c.ParentId,
                    CreatedDate = c.CreatedDate,
                    UpdatedDate = c.UpdatedDate,
                    Children = _context.Categories.Where(ch => ch.ParentId == c.Id).ToList()
                })
                .ToListAsync();
            return categories;
        }

        public async Task<List<Category>> GetCategoriesByProduct(Guid productId)
        {
            var categories = (from c in _context.Categories
                             join pc in _context.ProductCategories on c.Id equals pc.CategoryId into c_pcLeftJoin
                             from c_pc in c_pcLeftJoin.DefaultIfEmpty()
                             where c_pc.ProductId == productId
                             select c).Distinct();
            return await categories.ToListAsync();
        }
    }
}
