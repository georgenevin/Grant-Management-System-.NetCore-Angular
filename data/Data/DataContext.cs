using Microsoft.EntityFrameworkCore;
using models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<AppUserModel> Users { get; set; }

        public DbSet<GrantProgramModel> GrantPrograms { get; set; }

        public DbSet<CountryModel> Country { get; set; }

        public DbSet<StateModel>States { get; set; }

       public DbSet<ApplicantModel> ApplicationDetail { get; set; }

       public DbSet<ApplicantEducationModel> EducationDetails { get; set; }

       public DbSet<ReviewModel>Reviews { get; set; }
    }
}
