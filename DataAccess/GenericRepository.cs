using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions; 

namespace Sett.DataAccess
{
    public class GenericRepository<Model> : DbContext where Model : class
    {
        public GenericRepository()
            : base("Repository")
        {
        }

        public DbSet<Model> Models { get; set; }

        public IQueryable<Model> GetAll()
        {
            return Models.AsQueryable();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure Code First to ignore PluralizingTableName convention 
            // If you keep this convention then the generated tables will have pluralized names. 
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
