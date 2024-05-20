using Domain.Responses;
using Domain.DTOs.MembershipDto;
using Microsoft.AspNetCore.Mvc;
using Domain.Filters;
using Infrastructure.Services.MembershipService;
using Microsoft.AspNetCore.Authorization;

namespace WEBAPI.Cotrollers;
[ApiController]
[Route("[controller]")]
[Authorize]
public class MembershipController(IMembershipService membershipService) : ControllerBase
{
    [HttpGet]
    public async Task<Response<List<GetMembershipDto>>> GetMembershipsAsync([FromQuery]MembershipFilter MembershipFilter)
        => await membershipService.GetMembershipsAsync(MembershipFilter);

    [HttpGet("{MembershipId:int}")]
    public async Task<Response<GetMembershipDto>> GetMembershipByIdAsync(int MembershipId)
        => await membershipService.GetMembershipByIdAsync(MembershipId);

    [HttpPost("create")]
    public async Task<Response<string>> CreateMembershipAsync([FromBody]CreateMembershipDto Membership)
        => await membershipService.CreateMembershipAsync(Membership);


    [HttpPut("update")]
    public async Task<Response<string>> UpdateMembershipAsync([FromBody]UpdateMembershipDto Membership)
        => await membershipService.UpdateMembershipAsync(Membership);

    [HttpDelete("{MembershipId:int}")]
    public async Task<Response<bool>> DeleteMembershipAsync(int MembershipId)
        => await membershipService.DeleteMembershipAsync(MembershipId);
}
