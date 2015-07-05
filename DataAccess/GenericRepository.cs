using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions; 

namespace Sett.DataAccess
{
    public class GenericRepository<Model> : DbContext where Model : Sett.Models.Model
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

        public Model GetById(Guid id)
        {
            return Models.ToList().Single(model => ((Sett.Models.ModelWithId)(object)model).Id == id);
        }

        public void Remove(Model model)
        {
            Models.Remove(model);
            this.SaveChanges();
        }

        public void Add(Model model)
        {
            Models.Add(model);
            SaveChanges();
        }

        public void Update(Model model)
        {
            Models.Attach(model);
            Entry(model).State = EntityState.Modified;
            SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure Code First to ignore PluralizingTableName convention 
            // If you keep this convention then the generated tables will have pluralized names. 
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
