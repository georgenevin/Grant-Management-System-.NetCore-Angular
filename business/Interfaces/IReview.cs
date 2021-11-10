using models.Dtos;
using models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.Interfaces
{
   public interface IReview
    {
        Task<IEnumerable<ReviewDto>> GetDetails();

        Task<bool> SaveReview(ReviewDto review);
        Task<List<ReviewDto>> GetAdminReviews(string userName);
    }
}
