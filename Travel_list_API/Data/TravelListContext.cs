using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel_list_API.Models;

namespace Travel_list_API.Data
{
    public class TravelListContext : DbContext
    {
        public DbSet<TravelList> TravelLists { get; set; }


        public TravelListContext(DbContextOptions<TravelListContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //necessary for supporting the Add-Migration command from Pack Man Console
            var connectionstring = @"Server=(localdb)\MSSQLLocalDB;Database=TravelListDB;Trusted_Connection=True;MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(connectionstring);
        } 
    }
}
