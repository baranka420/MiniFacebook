using MiniFb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MiniFb.Database
{
    public class FacebookContext : DbContext
    {
        public FacebookContext() :base()
        {

        }

        public DbSet<PersonModel> Persons { get; set; }
    }
}