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
using Uniqlo.Models.RequestModels.Review;

namespace Uniqlo.DataAccess.Repositories.Implements
{
    public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
    {
        private readonly UniqloContext _context;
        public ReviewRepository(UniqloContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Review> FilterReviews(FilterReviewRequest filter)
        {
            var reviews = from r in _context.Reviews
                            where (filter.ProductId == null || r.ProductId == filter.ProductId)
                            && (filter.Star == null || r.Star == filter.Star)
                            orderby r.CreatedDate descending
                            select r;

            _context.ChangeTracker.LazyLoadingEnabled = false;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            reviews.Include(o => o.Product).Load();
            reviews.Include(o => o.User).Load();
            reviews.Include(o => o.Size).Load();

            return reviews;
        }

        public async Task<Review> GetReviewById(Guid id)
        {
            var review = _context.Reviews.Where(r => r.Id == id);
            _context.ChangeTracker.LazyLoadingEnabled = false;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            review.Include(o => o.Product).ThenInclude(p => p.ProductImages).Load();
            review.Include(o => o.User).Load();
            review.Include(o => o.Size).Load();
            return await review.SingleOrDefaultAsync();
        }
    }
}
