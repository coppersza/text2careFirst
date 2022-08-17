using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class TokenConfiguration : IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> builder)
        {
            builder.Property(t => t.Id).IsRequired();
            builder.Property(t => t.TokenName).IsRequired().HasMaxLength(25);
            builder.Property(t => t.CostPrice).HasColumnType("decimal(18,2)");
            builder.Property(t => t.SalesPrice).HasColumnType("decimal(18,2)");

            builder.HasOne(b => b.Donator).WithMany()
                .HasForeignKey(t => t.DonatorId);         
            builder.HasOne(b => b.Store).WithMany()
                .HasForeignKey(t => t.StoreId);      
            builder.HasOne(b => b.ProductType).WithMany()
                .HasForeignKey(t => t.ProductTypeId);       
            builder.HasOne(b => b.Recipient).WithMany()
                .HasForeignKey(t => t.RecipientId);                           
        }
    }    
}
