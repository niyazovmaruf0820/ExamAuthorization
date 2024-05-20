using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace WEBAPI.ExtensionMethods;

public static class RegisterService
{
    public static void AddRegisterService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(configure =>
            configure.UseNpgsql(configuration.GetConnectionString("Connection")));

        // services.AddScoped<Seeder>();
        // services.AddScoped<IFileService, FileService>();
        // services.AddScoped<IAuthService, AuthService>();
        // services.AddScoped<IBookService, BookService>();
        // services.AddScoped<IUserService, UserService>();
        // services.AddScoped<IAuthorService, AuthorService>();
        // services.AddScoped<IAuthorBookService, AuthorBookService>();

    }
}
