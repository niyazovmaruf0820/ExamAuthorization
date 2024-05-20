using Domain.DTOs.TrainerDto;
using Domain.Filters;
using Domain.Responses;
using Infrastructure.Services.TrainerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Cotrollers;
[ApiController]
[Route("[controller]")]
[Authorize]
public class TrainerController(ITrainerService trainerService) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<Response<List<GetTrainerDto>>> GetTrainersAsync([FromQuery]TrainerFilter TrainerFilter)
        => await trainerService.GetTrainersAsync(TrainerFilter);

    [HttpGet("{TrainerId:int}")]
    public async Task<Response<GetTrainerDto>> GetTrainerByIdAsync(int TrainerId)
        => await trainerService.GetTrainerByIdAsync(TrainerId);

    [HttpPost("create")]
    public async Task<Response<string>> CreateTrainerAsync([FromBody]CreateTrainerDto Trainer)
        => await trainerService.CreateTrainerAsync(Trainer);


    [HttpPut("update")]
    public async Task<Response<string>> UpdateTrainerAsync([FromBody]UpdateTrainerDto Trainer)
        => await trainerService.UpdateTrainerAsync(Trainer);

    [HttpDelete("{TrainerId:int}")]
    public async Task<Response<bool>> DeleteTrainerAsync(int TrainerId)
        => await trainerService.DeleteTrainerAsync(TrainerId);
}
