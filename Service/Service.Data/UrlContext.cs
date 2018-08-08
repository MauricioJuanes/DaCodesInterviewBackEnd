using MySql.Data.Entity;
using Service.Data.Entities;
using System.Data.Entity;

namespace Service.Data
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class UrlContext : DbContext
    {
        public UrlContext()
            : base("name=Database")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public virtual DbSet<UrlInfo> ShortUrls { get; set; }
    }
}
