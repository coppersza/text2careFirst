using System;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(
            UserManager<AppUser> userManager, 
            RoleManager<IdentityRole> roleManager)        
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Store").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Store";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }            

            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Rob",
                    Email = "robert.copley@gmail.com",
                    UserName = "robert.copley",
                    Address = new Address{
                        FirstName = "Rob",
                        LastName = "Copley",
                        Street = "Shuter Road",
                        City = "Durbam",
                        State = "KZN",
                        ZipCode = "3310"
                    },

                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
                userManager.AddToRoleAsync(user, "Admin").Wait();  

                user = new AppUser
                {
                    DisplayName = "Store",
                    Email = "store@gmail.com",
                    UserName = "store",
                    Address = new Address{
                        FirstName = "Rob",
                        LastName = "Copley",
                        Street = "Shuter Road",
                        City = "Durbam",
                        State = "KZN",
                        ZipCode = "3310"
                    }
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
                userManager.AddToRoleAsync(user, "Store").Wait();                  

                user = new AppUser
                {
                    DisplayName = "User",
                    Email = "user@gmail.com",
                    UserName = "user",
                    Address = new Address{
                        FirstName = "Rob",
                        LastName = "Copley",
                        Street = "Shuter Road",
                        City = "Durbam",
                        State = "KZN",
                        ZipCode = "3310"
                    }
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
                userManager.AddToRoleAsync(user, "User").Wait();      


            }
        }
    }
}
