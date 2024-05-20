using Domain.Responses;
using Domain.DTOs.LoginDto;

namespace Infrastructure.Services.AuthService;
public interface IAuthService
{
    public Task<Response<string>> Login(LoginDto loginDto);
}
