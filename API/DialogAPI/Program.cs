using DialogAPI.Data;
using DialogAPI.Services;
using DialogAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Config BDD
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Injection de d�pendances
builder.Services.AddScoped<IUserService, UserService>();

// Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger � la racine et auto-ouverture
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "DialogAPI V1");
        c.RoutePrefix = string.Empty; // <-- Swagger s�ouvre sur /
    });
}

app.UseAuthorization();
app.MapControllers();
app.Run();
