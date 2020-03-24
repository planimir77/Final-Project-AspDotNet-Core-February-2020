namespace CustomERP.Data.Configurations
{
    using CustomERP.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder
                .Property(e => e.Name)
                .IsUnicode()
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasOne(e => e.CompanyAddress)
                .WithMany(e => e.Companies)
                .HasForeignKey(e => e.AddressId )
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.ApplicationUsers)
                .WithOne(e => e.Company)
                .HasForeignKey(e => e.CompanyId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
