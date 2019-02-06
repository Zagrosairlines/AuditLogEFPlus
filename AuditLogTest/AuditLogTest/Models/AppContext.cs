using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Z.EntityFramework.Plus;

namespace AuditLogTest.Models
{
    public class AppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public AppContext() : base("name=AppContext")
        {
        }


        static AppContext()
        {
            AuditManager.DefaultConfiguration.AutoSavePreAction = (context, audit) =>
               // ADD "Where(x => x.AuditEntryID == 0)" to allow multiple SaveChanges with same Audit
               (context as AppContext).AuditEntries.AddRange(audit.Entries);
        }


        public DbSet<AuditEntry> AuditEntries { get; set; }
        public DbSet<AuditEntryProperty> AuditEntryProperties { get; set; }

        public DbSet<Person> People { get; set; }
    }
}
