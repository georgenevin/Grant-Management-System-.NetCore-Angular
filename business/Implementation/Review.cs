using AutoMapper;
using business.Interfaces;
using data.Interfaces;
using models.Dtos;
using models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.Implementation
{
    public class Review : IReview
    {

        private readonly IReviewRepository _reviewrepo;
        private readonly IMapper _mapper;

        public Review(IReviewRepository review)
        {
            _reviewrepo = review;
        }
        public async Task<IEnumerable<ReviewDto>> GetDetails()
        {
            var reviewDetails = await _reviewrepo.GetReviewDetails();
            return reviewDetails;

        }

     
        public async Task<bool> SaveReview(ReviewDto review)
        {

          
            var savedReview=await _reviewrepo.SaveReviewDetails(review);

            return true;
          


        }

        public async Task<List<ReviewDto>> GetAdminReviews(string userName)
        {
            var adminReview = await _reviewrepo.GetAdminReview(userName);
         
            return adminReview;
        }
    }
}
