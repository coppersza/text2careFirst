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

               
            builder.HasOne(b => b.Product).WithMany()
                .HasForeignKey(t => t.ProductId);    

            // builder.HasOne(b => b.Donator).WithMany()
            //     .HasForeignKey(p => p.DonatorId);
            // builder.HasOne(b => b.Recipient).WithMany()
            //     .HasForeignKey(p => p.RecipientId);  
            // builder.HasOne(b => b.Store).WithMany()
            //     .HasForeignKey(p => p.StoreId);

            builder.HasOne(b => b.Donator).WithMany()
                .HasPrincipalKey(p => p.DonatorUid)
                .HasForeignKey(p => p.DonatorUid);
            builder.HasOne(b => b.Recipient).WithMany()
                .HasPrincipalKey(p => p.RecipientUid)
                .HasForeignKey(p => p.RecipientUid);  
            builder.HasOne(b => b.Store).WithMany()
                .HasPrincipalKey(p => p.StoreUid)
                .HasForeignKey(p => p.StoreUid);                                                                            
        }
    }    
}
