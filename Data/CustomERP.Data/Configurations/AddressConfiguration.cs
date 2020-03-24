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
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(e => e.City)
                .IsUnicode()
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(e => e.Street)
                .IsUnicode()
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(e => e.StreetNumber)
                .IsUnicode()
                .IsRequired()
                .HasMaxLength(4);

            builder
                .Property(e => e.PostCode)
                .HasMaxLength(20);

            builder
                .Property(e => e.Floor)
                .IsRequired(false)
                .HasMaxLength(50);

            builder
                .Property(e => e.Room)
                .IsUnicode()
                .IsRequired(false)
                .HasMaxLength(6);

            builder
                .Property(e => e.Note)
                .IsUnicode()
                .IsRequired(false)
                .HasMaxLength(300);

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
