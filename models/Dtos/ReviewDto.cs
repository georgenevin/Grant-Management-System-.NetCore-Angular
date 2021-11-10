using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.Dtos
{
  public  class ReviewDto
    {

        public int ApplicantsId { get; set; }

        public string  ApplicantName { get; set; }

        public string ProgramCode { get; set; }

        public string Country { get; set; }

        public string  ApplicationStatus { get; set; }

        public bool ReviewerStatus { get; set; }

        public string UserId { get; set; }



    }
}
