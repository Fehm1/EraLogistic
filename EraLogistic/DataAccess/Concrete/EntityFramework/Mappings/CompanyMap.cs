using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.CompanyName).HasMaxLength(200);
            builder.Property(a => a.CompanyName).IsRequired();
            builder.Property(a => a.CompanyEmail).HasMaxLength(100);
            builder.Property(a => a.CompanyEmail).IsRequired();
            builder.Property(a => a.CompanyPhone).HasMaxLength(100);
            builder.Property(a => a.CompanyPhone).IsRequired();
            builder.Property(a => a.CompanyWebsite).HasMaxLength(100);
            builder.Property(a => a.CompanyWebsite).IsRequired();
            builder.Property(a => a.CompanyDescription).HasMaxLength(100);
            builder.Property(a => a.CompanyDescription).IsRequired();
            builder.Property(a => a.StorageCount).IsRequired();
            builder.Property(a => a.City).HasMaxLength(100);
            builder.Property(a => a.City).IsRequired();
            builder.Property(a => a.Country).HasMaxLength(100);
            builder.Property(a => a.Country).IsRequired();
            builder.Property(a => a.Address).HasMaxLength(300);
            builder.Property(a => a.Address).IsRequired();
            builder.Property(a => a.ZipCode).HasMaxLength(100);
            builder.Property(a => a.ZipCode).IsRequired();
            builder.Property(a => a.IsDeleted).HasDefaultValue(false);
            builder.Property(a => a.IsDeleted).IsRequired();
            builder.ToTable("Companies");
        }
    }
}
