using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CodedHomes.Data.Configuration;
using CodedHomes.Models;

namespace CodedHomes.Data
{
   public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Home> Homes { get; set; }


        public DataContext() : base(nameOrConnectionString: DataContext.ConnectionStringName)
        {

        }


        public static string ConnectionStringName
        {
            get
            {
                if (ConfigurationManager.AppSettings["ConnectionStringName"] != null)
                {
                    return ConfigurationManager.AppSettings["ConnectionStringName"].ToString();
                }
                return "DefaultConnection";
            }

        }


        static DataContext()
        {
            Database.SetInitializer(new CustomDatabaseInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new HomeConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());

            //Add simplemembership tables
            modelBuilder.Configurations.Add(new OAuthMembershipConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new MembershipConfiguration());

            //base.OnModelCreating(modelBuilder);
        }


       
        private void ApplyRules()
        {
            //Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in this.ChangeTracker.Entries().Where(e=>e.Entity is IAudit && (e.State == EntityState.Added) || (e.State == EntityState.Modified)))
            {
                IAudit e = (IAudit)entry.Entity;
                if (entry.State == EntityState.Added)
                {
                    e.CreatedOn = DateTime.Now;
                }
                e.ModifiedOn = DateTime.Now;
            }
        }

        public override int SaveChanges()
        {
            this.ApplyRules();
            return base.SaveChanges();
        }
    }
}
