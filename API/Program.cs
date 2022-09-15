using StackExchange.Redis;
using Core.Entities.Identity;


var builder = WebApplication.CreateBuilder(args);
//add services to container

builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddControllers();  

builder.Services.AddDbContext<StoreContext>(x =>
    x.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<AppIdentityDbContext>(x => 
x.UseNpgsql(builder.Configuration.GetConnectionString("IdentityConnection")));   
builder.Services.AddSingleton<IConnectionMultiplexer>(c => {
    var configuration = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"), true);
    configuration.ClientName = "Text2CareApp-RedisCacheProvider";
    configuration.ReconnectRetryPolicy = new ExponentialRetry(5000, 10000);
    return ConnectionMultiplexer.Connect(configuration);
});

// try
// {
//     builder.Services.AddSingleton<IConnectionMultiplexer>(c => {
//         var configuration = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"), true);
//         configuration.ClientName = "Text2CareApp-RedisCacheProvider";
//         configuration.ReconnectRetryPolicy = new ExponentialRetry(5000, 10000);
//         return ConnectionMultiplexer.Connect(configuration);

//     });
// }catch (Exception e)
// {
//     // No connection (requires writable - not eligible for replica) is active/available to service this operation: SETEX /api/store, mc: 1/1/0, mgr: 10 of 10 available, clientName: Text2CareApp-RedisCacheProvider, IOCP: (>
//     // Sep 06 13:14:46 text2careDroplet text2care[1862]:       StackExchange.Redis.RedisConnectionException: No connection (requires writable - not eligible for replica) is active/available to service this operation: SETEX /api/store, mc: 1/1/0, mgr: 10 of 10 available, client    
//     Console.WriteLine("{0} Exception caught.", e);
// }

builder.Services.AddApplicationServices();
builder.Services.AddIdentityServices(builder.Configuration);

builder.Services.AddSwaggerDocumentation();
builder.Services.AddCors(opt => {
    opt.AddPolicy("CorsPolicy", policy => {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
    });
});

//Confiugure HTTP request pipeline
var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseSwaggerDocumentation();
app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.UseHttpsRedirection();

// app.UseRouting();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Content")), RequestPath="/content"
});
app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapFallbackToController("Index", "Fallback");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = services.GetRequiredService<StoreContext>();
        await context.Database.MigrateAsync();
        await StoreContextSeed.SeedAsync(context, loggerFactory);

        var userManager = services.GetRequiredService<UserManager<AppUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        var identityContext = services.GetRequiredService<AppIdentityDbContext>();
        await identityContext.Database.MigrateAsync();
        await AppIdentityDbContextSeed.SeedUsersAsync(userManager, roleManager);

    }catch(Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "An error occurred during migration.");
    }
}
await app.RunAsync();
