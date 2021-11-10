using business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using models.Dtos;
using models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GMS.Controllers
{
    public class ReviewController : BaseAPIController
    {

        private readonly IReview _review;
        public ReviewController(IReview review)
        {
            _review = review;
        }

        [HttpGet("GetReviews")]
        public async Task<IEnumerable<ReviewDto>> GetReviews()
        {

            var applicantReviews =await  _review.GetDetails();
            return applicantReviews;
        }

        [HttpPost("SaveReview")]
        public async Task<ActionResult>SaveReview(ReviewDto review)
        {
            var savedReview = await _review.SaveReview(review);
            return Ok();

        }


        [HttpGet("GetAdminReview{username}")]
        public async Task<List<ReviewDto>> GetReviewsByUser(string username)
        {
            var userReview = await _review.GetAdminReviews(username);
            return userReview;
        }
    }
}
