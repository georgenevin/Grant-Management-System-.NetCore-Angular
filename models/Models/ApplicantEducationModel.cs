using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.Models
{
   public class ApplicantEducationModel
    {
       
            [Key]
            public int EducationalDetailId { get; set; }

            [ForeignKey("ApplicationId")]
            public int?ApplicantModelApplicantId { get; set; }

            public string CourseName { get; set; }

            public string Country { get; set; }

            public string InstitutionName { get; set; }

            public int YearofCompletion { get; set; }





        
    }
}
