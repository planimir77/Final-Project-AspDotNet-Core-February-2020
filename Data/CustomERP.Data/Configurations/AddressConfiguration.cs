namespace CustomERP.Data.Configurations
{
    using CustomERP.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder
                .Property(e => e.Country)
                .IsUnicode()
                .HasMaxLength(50);

            builder
                .Property(e => e.City)
                .IsUnicode()
                .HasMaxLength(50);

            builder
                .Property(e => e.Street)
                .IsUnicode()
                .HasMaxLength(50);

            builder
                .Property(e => e.PostCode)
                .HasMaxLength(20);

            builder
                .HasMany(e => e.ApplicationUsers)
                .WithOne(e => e.UserAddress)
                .HasForeignKey(e => e.AddressId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(e => e.Companies)
                .WithOne(e => e.CompanyAddress)
                .HasForeignKey(e => e.AddressId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
