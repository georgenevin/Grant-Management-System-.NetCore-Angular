using models.Dtos;
using models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Interfaces
{
  public  interface IReviewRepository
    {
        Task<IEnumerable<ReviewDto>> GetReviewDetails();

        Task<ReviewModel> SaveReviewDetails(ReviewDto reviewModel);

        Task<List<ReviewDto>> GetAdminReview(string username);
    }
}
