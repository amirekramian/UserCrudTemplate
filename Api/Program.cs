using Core;
using Application.Interfaces;
using Application.Service;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using NLog;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;
using Microsoft.AspNetCore;
using Microsoft.OpenApi.Models;

var logger = NLogBuilder.ConfigureNLog("Nlog.config").GetCurrentClassLogger();

try
{
    logger.Debug("Init main");
    CreateWebHostBuilder(args).Build().Run();
}
catch (Exception e)
{
    logger.Error(e, "Program stopped because of an exception.");
    
}
finally
{
    LogManager.Shutdown();
}
    

     static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Program>()
            .ConfigureLogging(builder =>
            {
                
            }).UseNLog();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "User Crud Services",
        Version = "v1"
    });
    c.EnableAnnotations();
});

//register DbContext
string connectionstring = builder.Configuration.GetConnectionString("SqlConnection");

builder.Services.AddDbContext<UserCrudTemplateEntity>(option =>
{
    option.UseSqlServer(connectionstring,b => b.MigrationsAssembly("Api"));
});

//register app services
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
