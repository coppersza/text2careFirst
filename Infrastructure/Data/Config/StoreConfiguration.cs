using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.StoreName).IsRequired().HasMaxLength(100);
            
            builder.HasOne(b => b.Country).WithMany()
                .HasForeignKey(p => p.CountryId);
              
          
        }
    }    
}
