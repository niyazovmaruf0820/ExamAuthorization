using Domain.DTOs.MembershipDto;
using Domain.Filters;
using Domain.Responses;

namespace Infrastructure.Services.MembershipService;

public interface IMembershipService
{
    Task<PagedResponse<List<GetMembershipDto>>> GetMembershipsAsync(MembershipFilter filter);
    Task<Response<GetMembershipDto>> GetMembershipByIdAsync(int id);
    Task<Response<string>> CreateMembershipAsync(CreateMembershipDto Membership);
    Task<Response<string>> UpdateMembershipAsync(UpdateMembershipDto Membership);
    Task<Response<bool>> DeleteMembershipAsync(int id);
}
