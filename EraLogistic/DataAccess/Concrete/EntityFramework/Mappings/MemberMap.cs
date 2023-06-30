using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class MemberMap : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(a => a.Name).HasMaxLength(150);
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Surname).HasMaxLength(200);
            builder.Property(a => a.Surname).IsRequired();
            builder.Property(a => a.Email).HasMaxLength(100);
            builder.Property(a => a.Email).IsRequired();
            builder.Property(a => a.Phone).HasMaxLength(100);
            builder.Property(a => a.Phone).IsRequired();
            builder.Property(a => a.CompanyName).HasMaxLength(200);
            builder.Property(a => a.CompanyName).IsRequired();
            builder.Property(a => a.CompanyEmail).HasMaxLength(100);
            builder.Property(a => a.CompanyEmail).IsRequired();
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
            builder.ToTable("Members");
        }
    }
}
