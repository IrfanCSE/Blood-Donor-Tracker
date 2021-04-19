using BloodDonorTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonorTracker.Context.Configuration
{
    public class DonorRequestConfig : IEntityTypeConfiguration<DonorRequest>
    {
        public void Configure(EntityTypeBuilder<DonorRequest> builder)
        {
            builder.Property(x => x.DonorRequestIdPk)
                .UseIdentityColumn()
                .IsRequired();

            builder.HasKey(x => x.DonorRequestIdPk);

            builder.HasOne(x => x.BloodRequestIdNav)
                .WithMany(x => x.DonorRequests)
                .HasForeignKey(x => x.BloodRequestIdFk)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.RequestUserIdNav)
                .WithMany(x => x.RequestSend)
                .HasForeignKey(x => x.RequestUserIdFk)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.RequestDonorIdNav)
                .WithMany(x => x.RequestReceive)
                .HasForeignKey(x => x.RequestDonorIdFk)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}