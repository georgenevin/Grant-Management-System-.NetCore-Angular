using models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Interfaces
{
     public   interface ICountryRepository
    {

        Task<IEnumerable<CountryModel>> GetCountries();


    }
}
