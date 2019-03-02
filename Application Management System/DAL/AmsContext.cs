using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Application_Management_System.Models;



namespace Application_Management_System.DAL
{
    public class AmsContext: DbContext
    {

        public AmsContext() : base("AmsContext") { }
        
        public DbSet<Agent> Agents { get; set; }
        public DbSet<AgentRepresentative> AgentRepresentatives { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}