using Domain.DTOs.WorkoutDto;
using Domain.Filters;
using Domain.Responses;
using Infrastructure.Services.WorkoutService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Cotrollers;
[ApiController]
[Route("[controller]")]
[Authorize]
public class WorkoutController(IWorkoutService workoutService) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<Response<List<GetWorkoutDto>>> GetWorkoutsAsync([FromQuery]PaginationFilter WorkoutFilter)
        => await workoutService.GetWorkoutsAsync(WorkoutFilter);

    [HttpGet("{WorkoutId:int}")]
    public async Task<Response<GetWorkoutDto>> GetWorkoutByIdAsync(int WorkoutId)
        => await workoutService.GetWorkoutByIdAsync(WorkoutId);

    [HttpPost("create")]
    public async Task<Response<string>> CreateWorkoutAsync([FromBody]CreateWorkoutDto Workout)
        => await workoutService.CreateWorkoutAsync(Workout);


    [HttpPut("update")]
    public async Task<Response<string>> UpdateWorkoutAsync([FromBody]UpdateWorkoutDto Workout)
        => await workoutService.UpdateWorkoutAsync(Workout);

    [HttpDelete("{WorkoutId:int}")]
    public async Task<Response<bool>> DeleteWorkoutAsync(int WorkoutId)
        => await workoutService.DeleteWorkoutAsync(WorkoutId);
}
