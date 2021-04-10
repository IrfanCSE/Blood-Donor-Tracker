using BloodDonorTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonorTracker.Context.Configuration
{
    public class BloodGroupConfig : IEntityTypeConfiguration<BloodGroup>
    {
        public void Configure(EntityTypeBuilder<BloodGroup> builder)
        {
            builder.HasKey(x=>x.BloodGroupIdPk);

            builder.Property(x => x.BloodGroupIdPk)
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(x => x.BloodGroupName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();
        }
    }
}