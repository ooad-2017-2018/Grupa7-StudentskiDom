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

        public StudentskiDomContext() : base("AzureConnection")
        {
            
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Blagajnik> Blagajnik { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Konobar> Konobar { get; set; }
        public DbSet<Kuhar> Kuhar { get; set; }
        public DbSet<Majstor> Majstor { get; set; }
        public DbSet<SefRestorana> SefRestorana { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}