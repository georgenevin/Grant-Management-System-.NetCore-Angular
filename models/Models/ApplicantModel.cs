using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.Models
{
   public class ApplicantModel
    {
        [Key]
        public int ApplicantId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public  DateTime DateofBirth { get; set; }

        public int Country { get; set; }

        public int State { get; set; }

        public bool PhysicallyDisabled { get; set; } 

        public string Address { get; set; }

        public string  City { get; set; }

        public string PostalCode { get; set; }

        public string Mobile { get; set; }

        public string Phone { get; set; }

        [ForeignKey("GrantId")]
        public int GrantId { get; set; }
        public GrantProgramModel Grant { get; set; }


        public ICollection<ApplicantEducationModel> EducationDetails { get; set; }
    }
}
