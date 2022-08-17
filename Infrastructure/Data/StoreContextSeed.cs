using System;
using System.Reflection;
using System.Text.Json;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory){
            try
            {
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                if (!context.ProductType.Any()){
                    var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/InsertProductType.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                    foreach (var item in types)
                    {
                        context.ProductType.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.Country.Any()){
                    var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/InsertCountry.json");
                    var types = JsonSerializer.Deserialize<List<Country>>(typesData);
                    foreach (var item in types)
                    {
                        context.Country.Add(item);
                    }
                    await context.SaveChangesAsync();
                }                
                if (!context.Store.Any()){
                    var storeData = File.ReadAllText("../Infrastructure/Data/SeedData/InsertStore.json");
                    var stores = JsonSerializer.Deserialize<List<Store>>(storeData);
                    foreach (var item in stores)
                    {
                        context.Store.Add(item);
                    }
                    await context.SaveChangesAsync();
                }   
                if (!context.Product.Any()){
                    var productData = File.ReadAllText("../Infrastructure/Data/SeedData/InsertProduct.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productData);
                    foreach (var item in products)
                    {
                        context.Product.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.Recipient.Any()){
                    var jsonData = File.ReadAllText("../Infrastructure/Data/SeedData/InsertRecipient.json");
                    var data = JsonSerializer.Deserialize<List<Recipient>>(jsonData);
                    foreach (var item in data)
                    {
                        context.Recipient.Add(item);
                    }
                    await context.SaveChangesAsync();
                }   
                if (!context.Employee.Any()){
                    var jsonData = File.ReadAllText("../Infrastructure/Data/SeedData/InsertEmployee.json");
                    var data = JsonSerializer.Deserialize<List<Employee>>(jsonData);
                    foreach (var item in data)
                    {
                        context.Employee.Add(item);
                    }
                    await context.SaveChangesAsync();
                }  
                if (!context.Donator.Any()){
                    var jsonData = File.ReadAllText("../Infrastructure/Data/SeedData/InsertDonator.json");
                    var data = JsonSerializer.Deserialize<List<Donator>>(jsonData);
                    foreach (var item in data)
                    {
                        context.Donator.Add(item);
                    }
                    await context.SaveChangesAsync();
                }    
                if (!context.Token.Any()){
                    var jsonData = File.ReadAllText("../Infrastructure/Data/SeedData/InsertToken.json");
                    var data = JsonSerializer.Deserialize<List<Token>>(jsonData);
                    foreach (var item in data)
                    {
                        context.Token.Add(item);
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

