using Domain.DTOs.ClassSchduleDto;
using Domain.Filters;
using Domain.Responses;

namespace Infrastructure.Services.ClassSchduleService;

public interface IClassSchduleService
{
    Task<PagedResponse<List<GetClassSchduleDto>>> GetClassSchdulesAsync(PaginationFilter filter);
    Task<Response<GetClassSchduleDto>> GetClassSchduleByIdAsync(int id);
    Task<Response<string>> CreateClassSchduleAsync(CreateClassSchduleDto ClassSchdule);
    Task<Response<string>> UpdateClassSchduleAsync(UpdateClassSchduleDto ClassSchdule);
    Task<Response<bool>> DeleteClassSchduleAsync(int id);
}
