using Domain.DTOs.TrainerDto;
using Domain.Filters;
using Domain.Responses;

namespace Infrastructure.Services.TrainerService;

public interface ITrainerService
{
    Task<PagedResponse<List<GetTrainerDto>>> GetTrainersAsync(TrainerFilter filter);
    Task<Response<GetTrainerDto>> GetTrainerByIdAsync(int id);
    Task<Response<string>> CreateTrainerAsync(CreateTrainerDto Trainer);
    Task<Response<string>> UpdateTrainerAsync(UpdateTrainerDto Trainer);
    Task<Response<bool>> DeleteTrainerAsync(int id);
}
