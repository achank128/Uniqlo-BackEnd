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
    public class CollectionRepository : RepositoryBase<Collection>, ICollectionRepository
    {
        private readonly UniqloContext _context;
        public CollectionRepository(UniqloContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Collection>> GetCollectionsShow()
        {
            var collections = await _context.Collections
                .Where(c => c.IsShow == true)
                .Include(c => c.CollectionPosts)
                .ToListAsync();

            return collections;
        }
    }
}
