
using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.Metadata;
using Core.Entities.OrderAggregate;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<StoreRecipient> StoreRecipients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Donator> Donators { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Token> Tokens { get; set; }
        
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TokenMessage> TokenMessages { get; set; }
        public DbSet<ApplicationUserStores> ApplicationUserStores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.SetTableName(entityType.DisplayName());
            }                             
            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach(var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties()
                        .Where(p => p.PropertyType == typeof(decimal));
                    //for sqllite
                    var dateTimeProperties = entityType.ClrType.GetProperties()
                        .Where(p => p.PropertyType == typeof(DateTimeOffset));
                    foreach(var property in properties)
                    { 
                        modelBuilder.Entity(entityType.Name).Property(property.Name)
                            .HasConversion<double>(); 
                    }
                    foreach(var property in dateTimeProperties)
                    { 
                        modelBuilder.Entity(entityType.Name).Property(property.Name)
                            .HasConversion(new DateTimeOffsetToBinaryConverter()); 
                    }                    
                }
            }
        }
    }
}
