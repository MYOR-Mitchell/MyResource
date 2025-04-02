using Microsoft.EntityFrameworkCore;
using MyResource.API.DependencyInjection;
using MyResource.Core.Palettes.Interfaces;
using MyResource.Data;
using MyResource.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPaletteRepository, PaletteRepository>();
builder.Services.AddWordSearchDI();

builder.Services.AddDbContext<MyResourceContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options => {
    options.AddDefaultPolicy(policy => {
        policy.WithOrigins("https://localhost:7209")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
