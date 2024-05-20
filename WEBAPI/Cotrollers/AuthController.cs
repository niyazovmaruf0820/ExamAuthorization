using Domain.DTOs.LoginDto;
using Domain.Responses;
using Infrastructure.Services.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Cotrollers;
[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService)
{
    [HttpPost("Login")]
    public async Task<Response<string>> Login([FromBody] LoginDto loginDto)
    => await authService.Login(loginDto);
}
