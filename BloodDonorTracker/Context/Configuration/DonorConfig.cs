using BloodDonorTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonorTracker.Context.Configuration
{
    public class DonorConfig : IEntityTypeConfiguration<Donor>
    {
        public void Configure(EntityTypeBuilder<Donor> builder)
        {
            builder.Property(x => x.DonorIdPk)
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.Address)
                            .HasMaxLength(150)
                            .IsUnicode(false)
                            .IsRequired();

            builder.Property(x => x.NID)
                            .HasMaxLength(20)
                            .IsUnicode(false)
                            .IsRequired();

            builder.Property(x => x.Phone)
                            .HasMaxLength(20)
                            .IsUnicode(false)
                            .IsRequired();

            builder.Property(x => x.Latitude)
                .IsRequired(false);

            builder.Property(x => x.Longitude)
                .IsRequired(false);

            builder.Property(x => x.IsActive)
                .IsRequired(false);
        }
    }
}