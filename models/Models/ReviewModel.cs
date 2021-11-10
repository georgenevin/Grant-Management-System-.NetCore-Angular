using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.Models
{
   public class ReviewModel
    {

        public int Id { get; set; }

        public int GrantId { get; set; }

        public bool ReviewerStatus { get; set; }

        public string ApplicationStatus { get; set; }

        public int ApplicantsId { get; set; }

        public string UserId { get; set; }



    }
}
