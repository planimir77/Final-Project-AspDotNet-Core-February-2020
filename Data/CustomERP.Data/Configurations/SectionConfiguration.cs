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
                .HasIndex(e => e.Name)
                .IsUnique();
            builder
                .Property(e => e.Name)
                .IsUnicode()
                .IsRequired()
                .HasMaxLength(50);
            builder
                .HasOne(e => e.Order)
                .WithMany(e => e.Sections)
                .HasForeignKey(e => e.OrderId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(e => e.Department)
                .WithMany(e => e.Sections)
                .HasForeignKey(e => e.DepartmentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasMany(e => e.ApplicationUsers)
                .WithOne(e => e.Section)
                .HasForeignKey(e => e.SectionId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(e => e.SectionParent)
                .WithMany(e => e.SectionParents)
                .HasForeignKey(e => e.SectionParentId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .Property(e => e.CreatedFrom)
                .IsRequired()
                .HasMaxLength(40)
                .IsUnicode();
            builder
                .Property(e => e.ModifiedFrom)
                .IsRequired(false)
                .HasMaxLength(40)
                .IsUnicode();
            builder
                .Property(e => e.DeletedFrom)
                .IsRequired(false)
                .HasMaxLength(40)
                .IsUnicode();
        }
    }
}
