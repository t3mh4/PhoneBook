using ContactMicroservice.Entities;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ContactMicroservice.DBContext
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            //modelBuilder.Entity<Contact>().Property(s => s.UUID).ValueGeneratedOnAdd().HasComputedColumnSql("gen_random_uuid()",false);
            base.OnModelCreating(modelBuilder);
        }
    }
}
