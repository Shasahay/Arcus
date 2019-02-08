using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Arcus.DataAccess
{
    public class DefaultDBInitializer : DbMigrationsConfiguration<DefaultDBContext>
    {
        public DefaultDBInitializer()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
        public static void Initialize(string databaseName, string sqlServerInstance)
        {
            var databaseAutoMigrationSettings = ConfigurationManager.AppSettings["IsDatabaseAutoMigrationEnabled"];
            if (databaseAutoMigrationSettings == null || !Convert.ToBoolean(databaseAutoMigrationSettings)) return;

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DefaultDBContext, DefaultDBInitializer>("ArcusDB"));
            using (var ctx = new DefaultDBContext())
            {
                ctx.Database.Initialize(true);
            }
        }      
    }
}
