using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Mappings;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PackageFeature> PackageFeatures { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: "Server=LAPTOP-8KCHFK1I\\SQLEXPRESS;Database=LogisticDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AboutUsMap());
            modelBuilder.ApplyConfiguration(new ContactMap());
            modelBuilder.ApplyConfiguration(new PackageMap());
            modelBuilder.ApplyConfiguration(new PackageFeatureMap());
            modelBuilder.ApplyConfiguration(new ProfessionMap());
            modelBuilder.ApplyConfiguration(new ServiceMap());
            modelBuilder.ApplyConfiguration(new SettingMap());
            modelBuilder.ApplyConfiguration(new SliderMap());
            modelBuilder.ApplyConfiguration(new TeamMap());
            modelBuilder.ApplyConfiguration(new MemberMap());
            modelBuilder.ApplyConfiguration(new CompanyMap());
        }
    }
}
