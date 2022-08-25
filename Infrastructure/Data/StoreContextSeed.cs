using System;
using System.Reflection;
using System.Text.Json;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory){
            try
            {
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                if (!context.ProductTypes.Any()){
                    var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/InsertProductType.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                    foreach (var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.Countries.Any()){
                    var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/InsertCountry.json");
                    var types = JsonSerializer.Deserialize<List<Country>>(typesData);
                    foreach (var item in types)
                    {
                        context.Countries.Add(item);
                    }
                    await context.SaveChangesAsync();
                }                
                if (!context.Stores.Any()){
                    var storeData = File.ReadAllText("../Infrastructure/Data/SeedData/InsertStore.json");
                    var stores = JsonSerializer.Deserialize<List<Store>>(storeData);
                    foreach (var item in stores)
                    {
                        context.Stores.Add(item);
                    }
                    await context.SaveChangesAsync();
                }   
                if (!context.Products.Any()){
                    var productData = File.ReadAllText("../Infrastructure/Data/SeedData/InsertProduct.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productData);
                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.Recipients.Any()){
                    var jsonData = File.ReadAllText("../Infrastructure/Data/SeedData/InsertRecipientFull.json");
                    var data = JsonSerializer.Deserialize<List<Recipient>>(jsonData);
                    foreach (var item in data)
                    {
                        context.Recipients.Add(item);
                    }
                    await context.SaveChangesAsync();
                }   
                if (!context.Employees.Any()){
                    var jsonData = File.ReadAllText("../Infrastructure/Data/SeedData/InsertEmployee.json");
                    var data = JsonSerializer.Deserialize<List<Employee>>(jsonData);
                    foreach (var item in data)
                    {
                        context.Employees.Add(item);
                    }
                    await context.SaveChangesAsync();
                }  
                if (!context.Donators.Any()){
                    var jsonData = File.ReadAllText("../Infrastructure/Data/SeedData/InsertDonator.json");
                    var data = JsonSerializer.Deserialize<List<Donator>>(jsonData);
                    foreach (var item in data)
                    {
                        context.Donators.Add(item);
                    }
                    await context.SaveChangesAsync();
                }    
                if (!context.Tokens.Any()){
                    var jsonData = File.ReadAllText("../Infrastructure/Data/SeedData/InsertTokenFull.json");
                    var data = JsonSerializer.Deserialize<List<Token>>(jsonData);
                    foreach (var item in data)
                    {
                        context.Tokens.Add(item);
                    }
                    await context.SaveChangesAsync();
                }        
                if (!context.DeliveryMethods.Any()){
                    var jsonData = File.ReadAllText("../Infrastructure/Data/SeedData/InsertDeliveryMethod.json");
                    var data = JsonSerializer.Deserialize<List<DeliveryMethod>>(jsonData);
                    foreach (var item in data)
                    {
                        context.DeliveryMethods.Add(item);
                    }
                    await context.SaveChangesAsync();
                }       
                if (!context.StoreRecipients.Any()){
                    var jsonData = File.ReadAllText("../Infrastructure/Data/SeedData/InsertStoreRecipientFull.json");
                    var data = JsonSerializer.Deserialize<List<StoreRecipient>>(jsonData);
                    foreach (var item in data)
                    {
                        context.StoreRecipients.Add(item);
                    }
                    await context.SaveChangesAsync();
                }        
                if (!context.TokenMessages.Any()){
                    var jsonData = File.ReadAllText("../Infrastructure/Data/SeedData/InsertTokenMessageFull.json");
                    var data = JsonSerializer.Deserialize<List<TokenMessage>>(jsonData);
                    foreach (var item in data)
                    {
                        context.TokenMessages.Add(item);
                    }
                    await context.SaveChangesAsync();
                }                                                                                            
                     
            }
            catch(Exception ex){
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }                    
        }
    }
}

