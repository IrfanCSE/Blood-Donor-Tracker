using BloodDonorTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonorTracker.Context.Configuration
{
    public class AlertConfig : IEntityTypeConfiguration<Alert>
    {
        public void Configure(EntityTypeBuilder<Alert> builder)
        {
            builder.HasKey(x=>x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(X => X.IsActive).IsRequired();

        }
    }
}