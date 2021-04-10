using BloodDonorTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonorTracker.Context.Configuration
{
    public class DonorConfig : IEntityTypeConfiguration<Donor>
    {
        public void Configure(EntityTypeBuilder<Donor> builder)
        {
            builder.HasKey(x=>x.DonorIdPk);

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
                .IsRequired();

            builder.Property(x => x.Longitude)
                .IsRequired();

            builder.HasMany(x => x.Alerts)
                .WithOne(x => x.DonorNav)
                .HasForeignKey(x => x.DonorIdFk);

            builder.Property(X => X.IsActive).IsRequired();

        }
    }
}