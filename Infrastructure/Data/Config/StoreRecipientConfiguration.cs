using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class StoreRecipientConfiguration : IEntityTypeConfiguration<StoreRecipient>
    {
        public void Configure(EntityTypeBuilder<StoreRecipient> builder)
        {
            builder.Property(p => p.Id).IsRequired();

            builder.HasOne(b => b.Store).WithMany()
                .HasPrincipalKey(p => p.StoreUid)
                .HasForeignKey(p => p.StoreUid);
            builder.HasOne(b => b.Recipient).WithMany()
                .HasPrincipalKey(p => p.RecipientUid)
                .HasForeignKey(p => p.RecipientUid);          
        }
    }    
}
