using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.Models
{
    public  class CountryModel
    {
        [Key]
        public int Country_Id { get; set; }

        [Column(TypeName = "nvarchar(40)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string PhoneCode { get; set; }

        public string ShortName { get; set; }

        public ICollection<StateModel> States { get; set; }


    }
}
