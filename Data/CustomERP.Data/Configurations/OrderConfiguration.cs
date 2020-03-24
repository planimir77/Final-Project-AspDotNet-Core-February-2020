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
                .HasMany(e => e.Sections)
                .WithOne(e => e.Order)
                .HasForeignKey(e => e.OrderId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
