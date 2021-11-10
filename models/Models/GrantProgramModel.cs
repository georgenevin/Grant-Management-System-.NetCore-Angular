using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.Models
{
    public  class GrantProgramModel
    {
        [Key]
        public int GrantId { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string ProgramName { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string ProgramCode { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public bool? Status { get; set; }

        public ICollection<ApplicantModel> Applicants { get; set; }
    }
}
