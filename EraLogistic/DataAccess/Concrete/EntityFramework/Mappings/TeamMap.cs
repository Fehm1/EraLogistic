using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class TeamMap : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.Image).HasMaxLength(100);
            builder.Property(a => a.Image).IsRequired();
            builder.Property(a => a.Fullname).HasMaxLength(200);
            builder.Property(a => a.Fullname).IsRequired();
            builder.Property(a => a.InstagramUrl).HasMaxLength(100);
            builder.Property(a => a.InstagramUrl).IsRequired();
            builder.Property(a => a.FacebookUrl).HasMaxLength(100);
            builder.Property(a => a.FacebookUrl).IsRequired();
            builder.Property(a => a.WhatsAppUrl).HasMaxLength(100);
            builder.Property(a => a.WhatsAppUrl).IsRequired();
            builder.Property(a => a.LinkedInUrl).HasMaxLength(100);
            builder.Property(a => a.LinkedInUrl).IsRequired();
            builder.Property(a => a.TwitterUrl).HasMaxLength(100);
            builder.Property(a => a.TwitterUrl).IsRequired();

            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.ModifiedDate).IsRequired();
            builder.Property(a => a.CreatedByName).HasMaxLength(150);
            builder.Property(a => a.CreatedByName).IsRequired();
            builder.Property(a => a.ModifiedByName).HasMaxLength(150);
            builder.Property(a => a.ModifiedByName).IsRequired();
            builder.Property(a => a.IsDeleted).HasDefaultValue(false).IsRequired();
            builder.Property(a => a.IsActive).HasDefaultValue(true).IsRequired();
            builder.HasOne<Profession>(a => a.Profession).WithMany(a => a.Teams).HasForeignKey(a => a.ProfessionId);
            builder.ToTable("Teams");
        }
    }
}
