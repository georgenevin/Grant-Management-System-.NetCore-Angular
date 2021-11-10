using data.Data;
using data.Interfaces;
using Microsoft.EntityFrameworkCore;
using models.Dtos;
using models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Implementation
{


    public class ReviewRepository : IReviewRepository
    {
        private DataContext _context;

        public ReviewRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<ReviewDto>> GetReviewDetails()
        {



            var reviews = _context.ApplicationDetail.Join(_context.GrantPrograms,
           app => app.GrantId, grant => grant.GrantId, (app, grant) =>
                          new { ApplicantName = app.FirstName, ProgramCode = grant.ProgramCode, Country = app.Country, ApplicantId = app.ApplicantId, GrantId = app.GrantId, CountryId = app.Country, UserId = app.Email }
                            ).Join(_context.Country, app => app.Country, cc => cc.Country_Id, (app, cc) => new
                            {
                                ApplicantName = app.ApplicantName,
                                ProgramCode = app.ProgramCode,
                                Country = cc.Name,
                                ApplicantsId = app.ApplicantId,
                                UserId = app.UserId


                            }).Join(_context.Reviews, app => app.ApplicantsId, rev => rev.ApplicantsId, (app, rev) => new ReviewDto
                            {

                                ApplicantName = app.ApplicantName,
                                ProgramCode = app.ProgramCode,
                                Country = app.Country,
                                ApplicantsId = app.ApplicantsId,
                                ReviewerStatus = rev.ReviewerStatus,
                                ApplicationStatus = rev.ApplicationStatus,
                                UserId = app.UserId


                            });



            var allreviews = await reviews.ToListAsync().ConfigureAwait(false);
            return allreviews;



        }






        public async Task<ReviewModel> SaveReviewDetails(ReviewDto reviewModel)
        {

            // var grantCode = _context.GrantPrograms?.Where(x => x.ProgramCode.ToLower().Equals(reviewModel.ProgramCode))?.FirstOrDefault();
            var currentReview = _context.Reviews?.Where(x => x.ApplicantsId == reviewModel.ApplicantsId)?.FirstOrDefault();

            var reviewStatus = false;

            if (reviewModel.ReviewerStatus)
            {
                reviewStatus = true;
            }
            currentReview.ApplicationStatus = "Completed";
            currentReview.ReviewerStatus = reviewStatus;
            _context.Reviews.Update(currentReview);
            await _context.SaveChangesAsync();
            return currentReview;
        }


        public async Task<List<ReviewDto>> GetAdminReview(string username)
        {

            var reviews = _context.ApplicationDetail.Join(_context.GrantPrograms,
                         app => app.GrantId, grant => grant.GrantId, (app, grant) =>
                       new { ApplicantName = app.FirstName, ProgramCode = grant.ProgramCode, Country = app.Country, ApplicantId = app.ApplicantId, GrantId = app.GrantId, CountryId = app.Country, UserId = app.Email }
                         ).Join(_context.Country, app => app.Country, cc => cc.Country_Id, (app, cc) => new
                         {
                             ApplicantName = app.ApplicantName,
                             ProgramCode = app.ProgramCode,
                             Country = cc.Name,
                             ApplicantsId = app.ApplicantId,
                             UserId = app.UserId


                         }).Join(_context.Reviews, app => app.ApplicantsId, rev => rev.ApplicantsId, (app, rev) => new ReviewDto
                         {

                             ApplicantName = app.ApplicantName,
                             ProgramCode = app.ProgramCode,
                             Country = app.Country,
                             ApplicantsId = app.ApplicantsId,
                             ReviewerStatus = rev.ReviewerStatus,
                             ApplicationStatus = rev.ApplicationStatus,
                             UserId = app.UserId


                         }).Where(x => x.UserId.ToLower() == username.ToLower());
            var allreviews = await reviews.ToListAsync().ConfigureAwait(false);
            return allreviews;
        }
    }
}
