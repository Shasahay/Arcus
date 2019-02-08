using Arcus.DataAccess.Config.Common;
using Arcus.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcus.DataAccess
{
    public class DefaultDBContext : DbContext
    {
        public DefaultDBContext() : base("ArcusDB")
        {
            var objectContext = (this as IObjectContextAdapter).ObjectContext;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemContent> ItemContents { get; set; }
        public DbSet<CategoryHierarchy> CategoryHierarchies { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new CategoryMapping());
            modelBuilder.Configurations.Add(new ItemMapping());
            modelBuilder.Configurations.Add(new ItemContentMapping());
            modelBuilder.Configurations.Add(new CategoryHierarchyMapping());
        }

    }
}
