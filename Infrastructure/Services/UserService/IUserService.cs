using Domain.DTOs.UserDto;
using Domain.Filters;
using Domain.Responses;

namespace Infrastructure.Services.UserService;

public interface IUserService
{
    Task<PagedResponse<List<GetUserDto>>> GetUsersAsync(PaginationFilter filter);
    Task<Response<GetUserDto>> GetUserByIdAsync(int id);
    Task<Response<string>> CreateUserAsync(CreateUserDto User);
    Task<Response<string>> UpdateUserAsync(UpdateUserDto User);
    Task<Response<bool>> DeleteUserAsync(int id);
}
