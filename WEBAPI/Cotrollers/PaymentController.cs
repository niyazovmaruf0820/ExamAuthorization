using Domain.DTOs.PaymentDto;
using Domain.Filters;
using Domain.Responses;
using Infrastructure.Services.PaymentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Cotrollers;
[ApiController]
[Route("[controller]")]
[Authorize]
public class PaymentController(IPaymentService paymentService)
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<Response<List<GetPaymentDto>>> GetPaymentsAsync([FromQuery]PaginationFilter PaymentFilter)
        => await paymentService.GetPaymentsAsync(PaymentFilter);

    [HttpGet("{PaymentId:int}")]
    public async Task<Response<GetPaymentDto>> GetPaymentByIdAsync(int PaymentId)
        => await paymentService.GetPaymentByIdAsync(PaymentId);

    [HttpPost("create")]
    public async Task<Response<string>> CreatePaymentAsync([FromBody]CreatePaymentDto Payment)
        => await paymentService.CreatePaymentAsync(Payment);


    [HttpPut("update")]
    public async Task<Response<string>> UpdatePaymentAsync([FromBody]UpdatePaymentDto Payment)
        => await paymentService.UpdatePaymentAsync(Payment);

    [HttpDelete("{PaymentId:int}")]
    public async Task<Response<bool>> DeletePaymentAsync(int PaymentId)
        => await paymentService.DeletePaymentAsync(PaymentId);
}
