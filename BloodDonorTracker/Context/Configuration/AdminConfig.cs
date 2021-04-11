using BloodDonorTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonorTracker.Context.Configuration
{
    public class AdminConfig : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.Property(x => x.AdminIdPk)
                .UseIdentityColumn()
                .IsRequired();

            builder.HasKey(x => x.AdminIdPk);

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(X => X.IsActive).IsRequired();

            builder.HasOne(x => x.AdminDonorNav)
                .WithOne(x => x.Admin)
                .HasForeignKey<Admin>(x => x.AdminDonorIdFk)
                .IsRequired(false);
        }
    }
}