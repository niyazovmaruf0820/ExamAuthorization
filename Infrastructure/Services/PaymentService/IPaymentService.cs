using Domain.DTOs.PaymentDto;
using Domain.Filters;
using Domain.Responses;

namespace Infrastructure.Services.PaymentService;

public interface IPaymentService
{
    Task<PagedResponse<List<GetPaymentDto>>> GetPaymentsAsync(PaginationFilter filter);
    Task<Response<GetPaymentDto>> GetPaymentByIdAsync(int id);
    Task<Response<string>> CreatePaymentAsync(CreatePaymentDto Payment);
    Task<Response<string>> UpdatePaymentAsync(UpdatePaymentDto Payment);
    Task<Response<bool>> DeletePaymentAsync(int id);
}
