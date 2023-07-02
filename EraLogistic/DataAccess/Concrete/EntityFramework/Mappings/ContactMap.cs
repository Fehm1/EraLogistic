using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class ContactMap : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.Name).HasMaxLength(100);
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Surname).HasMaxLength(100);
            builder.Property(a => a.Surname).IsRequired();
            builder.Property(a => a.Messsage).HasMaxLength(400);
            builder.Property(a => a.Messsage).IsRequired();
            builder.Property(a => a.Email).HasMaxLength(150);
            builder.Property(a => a.Email).IsRequired();
            builder.Property(a => a.IsRead).HasDefaultValue(false);
            builder.Property(a => a.IsRead).IsRequired();

            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.ModifiedDate).IsRequired();
            builder.Property(a => a.CreatedByName).HasMaxLength(150);
            builder.Property(a => a.CreatedByName).IsRequired();
            builder.Property(a => a.ModifiedByName).HasMaxLength(150);
            builder.Property(a => a.ModifiedByName).IsRequired();
            builder.Property(a => a.IsDeleted).HasDefaultValue(false).IsRequired();
            builder.Property(a => a.IsActive).HasDefaultValue(true).IsRequired();
            builder.ToTable("Contacts");
        }
    }
}
