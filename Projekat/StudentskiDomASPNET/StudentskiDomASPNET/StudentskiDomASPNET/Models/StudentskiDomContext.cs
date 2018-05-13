using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace StudentskiDomASPNET.Models
{
    public class StudentskiDomContext : DbContext
    {

        public StudentskiDomContext() : base("MS_TableConnectionString")
        {
            
        }

        public DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}