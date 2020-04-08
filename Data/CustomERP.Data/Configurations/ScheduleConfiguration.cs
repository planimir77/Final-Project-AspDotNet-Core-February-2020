namespace CustomERP.Data.Configurations
{
    using CustomERP.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder
                .HasMany(e => e.CycleOfDays)
                .WithOne(e => e.Schedule)
                .HasForeignKey(e => e.ScheduleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasMany(e => e.Shifts)
                .WithOne(e => e.Schedule)
                .HasForeignKey(e => e.ScheduleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
