using Microsoft.EntityFrameworkCore;
using ReportMicroservice.Entities;

#nullable disable

namespace ReportMicroservice.DBContext
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }
    }
}
