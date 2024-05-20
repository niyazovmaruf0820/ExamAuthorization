using Infrastructure.Data;
using Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;
using WEBAPI.ExtensionMethods;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddRegisterService(builder.Configuration);


builder.Services.SwaggerService();

builder.Services.AddAuthConfigureService(builder.Configuration);


builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseCors(
    build => build.WithOrigins( "http://localhost:3000","https://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod()
);

try {
    var serviceProvider = app.Services.CreateScope().ServiceProvider; 
    var dataContext = serviceProvider.GetRequiredService<DataContext>();
    await dataContext.Database.MigrateAsync();
    
    var seeder = serviceProvider.GetRequiredService<Seed>();
    await seeder.SeedUser();
}
catch (Exception)
{
    
}

if (app.Environment.IsDevelopment()|| app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();