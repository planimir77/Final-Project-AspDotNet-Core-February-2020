namespace CustomERP.Data.Configurations
{
    using CustomERP.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder
                .Property(e => e.Name)
                .IsUnicode()
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasMany(e => e.ApplicationUsers)
                .WithOne(e => e.Section)
                .HasForeignKey(e => e.SectionId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.SectionParent)
                .WithMany(e => e.SectionParents)
                .HasForeignKey(e => e.SectionParentId);
        }
    }
}