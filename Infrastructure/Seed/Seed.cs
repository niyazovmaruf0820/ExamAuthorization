using System.Security.Cryptography;
using System.Text;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Seed;

public class Seed(DataContext context)
{
    public async Task SeedUser()
    {
        var existing = await context.Users.FirstOrDefaultAsync(x => x.Name == "admin" && x.Password == ConvertToHash("12345"));
        if (existing != null)
        {
            return;
        }

        var user = new Domain.Entities.User()
        {
            Id = 1,
            Name = "maruf",
            CreatedAt = DateTime.UtcNow,
            Password = ConvertToHash("2008"),
        };
        user.Email = $"{user.Name}@gmail.com";

        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }


    private static string ConvertToHash(string rawData)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
