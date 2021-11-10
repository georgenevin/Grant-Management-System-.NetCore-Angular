using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.Models
{
   public  class AppUserModel
    {
        [Key]
        public int UserId { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string UserName { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string Password { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string UserType { get; set; }


        public DateTime CreatedDate { get; set; }





    }
}
