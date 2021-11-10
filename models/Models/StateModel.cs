using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.Models
{
   public  class StateModel
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string Name { get; set; }
 

        public CountryModel Country { get; set; }


    }
}
