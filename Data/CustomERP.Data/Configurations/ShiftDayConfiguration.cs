namespace CustomERP.Data.Configurations
{
    using CustomERP.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ShiftDayConfiguration : IEntityTypeConfiguration<ShiftDay>
    {
        public void Configure(EntityTypeBuilder<ShiftDay> builder)
        {
            builder
                .Property(e => e.WorkingMode)
                .IsRequired();
            builder
                .Property(e => e.Begins)
                .IsRequired();
            builder
                .Property(e => e.IncludingRest)
                .IsRequired()
                .HasMaxLength(12);
            builder
                .Property(e => e.Duration)
                .IsRequired()
                .HasMaxLength(12);
        }
    }
}
