using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class MemberMap : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).HasMaxLength(200);
            builder.Property(a => a.Surname).HasMaxLength(200);
            builder.Property(a => a.Email).HasMaxLength(200);
            builder.Property(a => a.Phone).HasMaxLength(200);
            builder.Property(a => a.Image).HasMaxLength(100);
            builder.Property(a => a.CompanyName).HasMaxLength(200);
            builder.Property(a => a.CompanyEmail).HasMaxLength(100);
            builder.Property(a => a.City).HasMaxLength(100);
            builder.Property(a => a.Country).HasMaxLength(100);
            builder.Property(a => a.Address).HasMaxLength(300);
            builder.Property(a => a.ZipCode).HasMaxLength(100);
            builder.Property(a => a.IsDeleted).HasDefaultValue(false);
            builder.Property(a => a.IsActive).HasDefaultValue(true);
            builder.Property(a => a.IsAdmin).HasDefaultValue(false);
            builder.Property(a => a.IsSuperAdmin).HasDefaultValue(false);
        }
    }
}
