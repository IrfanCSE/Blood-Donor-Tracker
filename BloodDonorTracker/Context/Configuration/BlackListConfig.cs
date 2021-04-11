using BloodDonorTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonorTracker.Context.Configuration
{
    public class BlackListConfig : IEntityTypeConfiguration<BlackList>
    {
        public void Configure(EntityTypeBuilder<BlackList> builder)
        {
            builder.HasKey(x => x.BlackListIdPk);

            builder.Property(x => x.BlackListIdPk)
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(X => X.IsActive).IsRequired();

            builder.HasOne(x => x.DonorIdNav).WithOne(x => x.BlackList).HasForeignKey<BlackList>(x => x.DonorIdFk).IsRequired(false);
        }
    }
}