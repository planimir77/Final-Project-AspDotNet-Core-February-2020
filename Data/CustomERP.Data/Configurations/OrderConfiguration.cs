namespace CustomERP.Data.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CustomERP.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .Property(e => e.Customer)
                .IsUnicode()
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(e => e.Recipe)
                .IsUnicode()
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(e => e.Quantity)
                .HasMaxLength(1000);
            builder
                .Property(e => e.ContentWeight)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(e => e.Progress)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(e => e.IsActive)
                .HasDefaultValue(false);
            builder
                .Property(e => e.CompletedOn)
                .IsRequired(false);
            builder
                .Property(e => e.Note)
                .IsUnicode()
                .IsRequired(false)
                .HasMaxLength(200);
            builder
                .HasMany(e => e.Sections)
                .WithOne(e => e.Order)
                .HasForeignKey(e => e.OrderId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
