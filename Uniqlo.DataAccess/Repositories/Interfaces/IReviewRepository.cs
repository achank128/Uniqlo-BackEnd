using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.DataAccess.RepositoryBase;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.RequestModels.Review;

namespace Uniqlo.DataAccess.Repositories.Interfaces
{
    public interface IReviewRepository : IRepositoryBase<Review>
    {
        IQueryable<Review> FilterReviews(FilterReviewRequest filter);
        Task<Review> GetReviewById(Guid id);
    }
}
