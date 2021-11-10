using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.Dtos
{
   public class GrantDto
    {
     
        public int GrantId { get; set; }

        [Required]
        public string ProgramName { get; set; }

        [Required]
        public string ProgramCode { get; set; }
        [Required]
        public string StartDate { get; set; }
        [Required]
        public string EndDate { get; set; }
        [Required]
        public bool? Status { get; set; }


    }
}
