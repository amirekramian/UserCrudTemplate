using Core;
using Application.Interfaces;
using Application.Service;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
