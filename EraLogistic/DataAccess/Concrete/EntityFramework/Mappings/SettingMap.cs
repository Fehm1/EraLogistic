using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class SettingMap : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.HeaderLogo).HasMaxLength(100);
            builder.Property(a => a.HeaderLogo).IsRequired();

            builder.Property(a => a.FooterLogo).HasMaxLength(100);
            builder.Property(a => a.FooterLogo).IsRequired();

            builder.Property(a => a.AboutUsYellowTitle).HasMaxLength(400);
            builder.Property(a => a.AboutUsYellowTitle).IsRequired();

            builder.Property(a => a.AboutUsWhiteTitle).HasMaxLength(400);
            builder.Property(a => a.AboutUsWhiteTitle).IsRequired();

            builder.Property(a => a.AboutUsDescription).HasMaxLength(400);
            builder.Property(a => a.AboutUsDescription).IsRequired();

            builder.Property(a => a.VideoYellowTitle).HasMaxLength(400);
            builder.Property(a => a.VideoYellowTitle).IsRequired();

            builder.Property(a => a.VideoWhiteTitle).HasMaxLength(400);
            builder.Property(a => a.VideoWhiteTitle).IsRequired();

            builder.Property(a => a.VideoLittleDescription).HasMaxLength(400);
            builder.Property(a => a.VideoLittleDescription).IsRequired();

            builder.Property(a => a.VideoDescription).HasMaxLength(400);
            builder.Property(a => a.VideoDescription).IsRequired();

            builder.Property(a => a.VideoLink).HasMaxLength(400);
            builder.Property(a => a.VideoLink).IsRequired();

            builder.Property(a => a.OurServiceYellowTitle).HasMaxLength(400);
            builder.Property(a => a.OurServiceYellowTitle).IsRequired();

            builder.Property(a => a.OurServiceWhiteTitle).HasMaxLength(400);
            builder.Property(a => a.OurServiceWhiteTitle).IsRequired();

            builder.Property(a => a.OurServiceDescription).HasMaxLength(400);
            builder.Property(a => a.OurServiceDescription).IsRequired();

            builder.Property(a => a.OurPackageYellowTitle).HasMaxLength(400);
            builder.Property(a => a.OurPackageYellowTitle).IsRequired();

            builder.Property(a => a.OurPackageWhiteTitle).HasMaxLength(400);
            builder.Property(a => a.OurPackageWhiteTitle).IsRequired();

            builder.Property(a => a.OurPackageDescription).HasMaxLength(400);
            builder.Property(a => a.OurPackageDescription).IsRequired();

            builder.Property(a => a.Email).HasMaxLength(400);
            builder.Property(a => a.Email).IsRequired();

            builder.Property(a => a.Phone).HasMaxLength(400);
            builder.Property(a => a.Phone).IsRequired();

            builder.Property(a => a.Address).HasMaxLength(400);
            builder.Property(a => a.Address).IsRequired();

            builder.Property(a => a.Instagram).HasMaxLength(400);
            builder.Property(a => a.Instagram).IsRequired();

            builder.Property(a => a.Facebook).HasMaxLength(400);
            builder.Property(a => a.Facebook).IsRequired();

            builder.Property(a => a.LinkedIn).HasMaxLength(400);
            builder.Property(a => a.LinkedIn).IsRequired();

            builder.Property(a => a.WhatsApp).HasMaxLength(400);
            builder.Property(a => a.WhatsApp).IsRequired();

            builder.Property(a => a.Youtube).HasMaxLength(400);
            builder.Property(a => a.Youtube).IsRequired();

            builder.Property(a => a.Twitter).HasMaxLength(400);
            builder.Property(a => a.Twitter).IsRequired();

            builder.Property(a => a.GoogleMapsLocation).HasMaxLength(400);
            builder.Property(a => a.GoogleMapsLocation).IsRequired();

            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.ModifiedDate).IsRequired();
            builder.Property(a => a.CreatedByName).HasMaxLength(150);
            builder.Property(a => a.CreatedByName).IsRequired();
            builder.Property(a => a.ModifiedByName).HasMaxLength(150);
            builder.Property(a => a.ModifiedByName).IsRequired();
            builder.Property(a => a.IsDeleted).HasDefaultValue(false).IsRequired();
            builder.Property(a => a.IsActive).HasDefaultValue(true).IsRequired();
            builder.ToTable("Settings");
        }
    }
}
