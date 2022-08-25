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
                    Id = "db0c9817-2988-416c-a40c-0a670520111b",
                    DisplayName = "Cecilia Mbatha",
                    Email = "mbathakedibone@gmail.com",
                    UserName = "mbathakedibone@gmail.com",
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
                userManager.AddToRoleAsync(user, "Store").Wait();

                user = new AppUser
                {
                    Id = "f0eb7005-e9b4-42fd-8187-e069dd3f9d02",
                    DisplayName = "Jenetta",
                    Email = "jenetta@text2care.com",
                    UserName = "jenetta@text2care.com",
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
                userManager.AddToRoleAsync(user, "Store").Wait();     

                user = new AppUser
                {
                    Id = "64e25c11-076c-4fe0-b9f7-98141a9cefe6",
                    DisplayName = "csharp",
                    Email = "kosalawije@hotmail.com",
                    UserName = "kosalawije@hotmail.com",
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
                userManager.AddToRoleAsync(user, "Store").Wait();                                    

   
                user = new AppUser
                {
                    DisplayName = "Sean Boettiger",
                    Email = "seanb2k14@gmail.com",
                    UserName = "seanb2k14@gmail.com",
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
                userManager.AddToRoleAsync(user, "User").Wait();   

                user = new AppUser
                {
                    DisplayName = "Jaydene",
                    Email = "jaydeneleigh@gmail.com",
                    UserName = "jaydeneleigh@gmail.com",
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
                userManager.AddToRoleAsync(user, "User").Wait();    

                user = new AppUser
                {
                    DisplayName = "Brad Davey",
                    Email = "jbaybrad@gmail.com",
                    UserName = "jbaybrad@gmail.com",
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
                userManager.AddToRoleAsync(user, "User").Wait();   

                user = new AppUser
                {
                    DisplayName = "Nadia Raciti",
                    Email = "nadiaraciti@yahoo.com",
                    UserName = "nadiaraciti@yahoo.com",
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
                userManager.AddToRoleAsync(user, "User").Wait();                    
            }
        }
    }
}
