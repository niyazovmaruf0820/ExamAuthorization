using Domain.DTOs.WorkoutDto;
using Domain.Filters;
using Domain.Responses;

namespace Infrastructure.Services.WorkoutService;

public interface IWorkoutService
{
    Task<PagedResponse<List<GetWorkoutDto>>> GetWorkoutsAsync(PaginationFilter filter);
    Task<Response<GetWorkoutDto>> GetWorkoutByIdAsync(int id);
    Task<Response<string>> CreateWorkoutAsync(CreateWorkoutDto Workout);
    Task<Response<string>> UpdateWorkoutAsync(UpdateWorkoutDto Workout);
    Task<Response<bool>> DeleteWorkoutAsync(int id);
}
