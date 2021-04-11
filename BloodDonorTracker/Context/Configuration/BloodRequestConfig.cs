using BloodDonorTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonorTracker.Context.Configuration
{
    public class BloodRequestConfig : IEntityTypeConfiguration<BloodRequest>
    {
        public void Configure(EntityTypeBuilder<BloodRequest> builder)
        {
            builder.HasKey(x => x.BloodRequestIdPk);

            builder.Property(x => x.BloodRequestIdPk)
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(x => x.Condition)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired(false);

            builder.HasOne(x => x.RequestDonorNav)
                .WithMany(x => x.BloodRequests)
                .HasForeignKey(x => x.RequestDonorFk)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.HasOne(x => x.ResponsedDonorNav)
                .WithMany(x => x.BloodResponsedRequests)
                .HasForeignKey(x => x.ResponsedDonorFk)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false); 
        }
    }
}