namespace CustomERP.Data.Configurations
{
    using CustomERP.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .HasIndex(e => e.FullName)
                .IsUnique();

            builder
                .HasMany(e => e.Claims)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(e => e.Logins)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(e => e.Roles)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();

            builder
                .Property(e => e.Position)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();

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
            builder
                .HasOne(e => e.UserAddress)
                .WithMany(e => e.ApplicationUsers)
                .HasForeignKey(e => e.AddressId )
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(e => e.Shift)
                .WithMany(e => e.Employees)
                .HasForeignKey(e => e.ShiftId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(e => e.Section)
                .WithMany(e => e.ApplicationUsers)
                .HasForeignKey(e => e.SectionId )
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(e => e.Company)
                .WithMany(e => e.ApplicationUsers)
                .HasForeignKey(e => e.CompanyId )
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(e => e.ApplicationUserManager)
                .WithMany(e => e.ApplicationUserManagers)
                .HasForeignKey(e => e.ManagerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
