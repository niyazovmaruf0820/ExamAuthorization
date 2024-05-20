using Domain.Responses;
using Domain.DTOs.ClassSchduleDto;
using Domain.Filters;
using Infrastructure.Services.ClassSchduleService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WEBAPI.Cotrollers;
[ApiController]
[Route("[controller]")]
[Authorize]
public class ClassScheduleController(IClassSchduleService classSchduleService)
{
    [HttpGet]
    public async Task<Response<List<GetClassSchduleDto>>> GetClassSchedulesAsync([FromQuery]PaginationFilter filter)
        => await classSchduleService.GetClassSchdulesAsync(filter);

    [HttpGet("{ClassScheduleId:int}")]
    public async Task<Response<GetClassSchduleDto>> GetClassScheduleByIdAsync(int ClassScheduleId)
        => await classSchduleService.GetClassSchduleByIdAsync(ClassScheduleId);

    [HttpPost("create")]
    public async Task<Response<string>> CreateClassScheduleAsync([FromBody]CreateClassSchduleDto ClassSchedule)
        => await classSchduleService.CreateClassSchduleAsync(ClassSchedule);


    [HttpPut("update")]
    public async Task<Response<string>> UpdateClassScheduleAsync([FromBody]UpdateClassSchduleDto ClassSchedule)
        => await classSchduleService.UpdateClassSchduleAsync(ClassSchedule);

    [HttpDelete("{ClassScheduleId:int}")]
    public async Task<Response<bool>> DeleteClassScheduleAsync(int ClassScheduleId)
        => await classSchduleService.DeleteClassSchduleAsync(ClassScheduleId);
}
