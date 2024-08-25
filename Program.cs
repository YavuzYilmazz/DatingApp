using Microsoft.EntityFrameworkCore;
using APP.Data; // ApplicationDbContext sınıfının bulunduğu ad alanı
using Npgsql.EntityFrameworkCore.PostgreSQL; // Npgsql için gerekli direktif


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Controller'ları ekleyin
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();



// Swagger middleware'ini ekleyin
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    options.RoutePrefix = string.Empty; // Ana URL'de Swagger açılır
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers(); // Controller'ları haritalayın

app.Run();
