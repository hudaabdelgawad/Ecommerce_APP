using Ecom.Infrastructure;
using Microsoft.Extensions.FileProviders;
using System.Reflection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.InfrastructureConfiguration(builder.Configuration);
//configuration automapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
// configure ifile provider
builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider
(
    Path.Combine(Directory.GetCurrentDirectory(),"wwwroot")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
