using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.Dtos
{
   public class ApplicantDto
    {
        public ApplicantDetails applicationDetail { get; set; }

        public ContactDetail contactDetail { get; set; }

        public EducationDetail educationDetail { get; set; }





    }

    public class ApplicantDetails
    {

        public int Country { get; set; }

        public string DateofBirth { get; set; }

        public string Email { get; set; }


        public string FirstName  { get; set; }

        public string LastName { get; set; }

        public bool PhysicallyDisabled { get; set; } 
        public int State { get; set; }

        public int GrantProgram { get; set; }

    }


    public class ContactDetail
    {
        public string Address { get; set; }

        public string City { get; set; }

        public string Mobile { get; set; }

        public string Phone { get; set; }

        public string PostalCode { get; set; }
    }

    public class Education
    {
        public string  country { get; set; }

        public string courseName { get; set; }

        public string institutionName { get; set; }

        public string yearofCompleting { get; set; }
    }

    public class EducationDetail
    {
        public List<Education> education { get; set; }
    }

}
