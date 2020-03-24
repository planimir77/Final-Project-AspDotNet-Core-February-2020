namespace CustomERP.Data.Configurations
{
    using CustomERP.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder
                .Property(e => e.CreatedFrom)
                .IsUnicode()
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(e => e.ModifiedFrom)
                .IsUnicode()
                .IsRequired(false)
                .HasMaxLength(50);

            builder
                .Property(e => e.DeletedFrom)
                .IsUnicode()
                .IsRequired(false)
                .HasMaxLength(50);
        }
    }
}
