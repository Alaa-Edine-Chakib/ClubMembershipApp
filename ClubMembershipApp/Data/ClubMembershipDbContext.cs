using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApp.Data
{
    public class ClubMembershipDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ClubMembershipDb;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Models.User> Users { get; set; }


    }
}
