using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class AboutUsMap : IEntityTypeConfiguration<AboutUs>
    {
        public void Configure(EntityTypeBuilder<AboutUs> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.Image).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Image).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Title).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Description).HasMaxLength(400).IsRequired();
            builder.Property(a => a.MissionDescription).HasMaxLength(400).IsRequired();
            builder.Property(a => a.AdvantagesDescription).HasMaxLength(400).IsRequired();
            builder.Property(a => a.GuaranteedDescription).HasMaxLength(400).IsRequired();
            builder.Property(a => a.RedirectUrl).HasMaxLength(200).IsRequired();
            builder.Property(a => a.Feature1).HasMaxLength(100);
            builder.Property(a => a.Feature2).HasMaxLength(100);
            builder.Property(a => a.Feature3).HasMaxLength(100);
            builder.Property(a => a.Feature4).HasMaxLength(100);
            builder.Property(a => a.Feature5).HasMaxLength(100);
            builder.Property(a => a.Feature6).HasMaxLength(100);

            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.ModifiedDate).IsRequired();
            builder.Property(a => a.CreatedByName).HasMaxLength(150);
            builder.Property(a => a.CreatedByName).IsRequired();
            builder.Property(a => a.ModifiedByName).HasMaxLength(150);
            builder.Property(a => a.ModifiedByName).IsRequired();
            builder.Property(a => a.IsDeleted).HasDefaultValue(false).IsRequired();
            builder.Property(a => a.IsActive).HasDefaultValue(true).IsRequired();
            builder.ToTable("AboutUs");
        }
    }
}
