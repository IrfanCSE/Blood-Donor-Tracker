using BloodDonorTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonorTracker.Context.Configuration
{
    public class HealthReportConfig : IEntityTypeConfiguration<HealthReport>
    {
        public void Configure(EntityTypeBuilder<HealthReport> builder)
        {
            builder.HasKey(x=>x.HealthReportIdPk);

            builder.Property(x => x.HealthReportIdPk).UseIdentityColumn().IsRequired();

            builder.HasOne(x=>x.BloodGroupNav).WithMany(x=>x.HealthReports).HasForeignKey(x=>x.BloodGroupIdFk);

            builder.HasOne(x=>x.DonorNav).WithOne(x=>x.HealthReportNav).HasForeignKey<HealthReport>(x=>x.DonorIdFk);
        }
    }
}