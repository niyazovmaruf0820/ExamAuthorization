namespace Domain.DTOs.PaymentDto;

public class GetPaymentDto
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string? Status { get; set; }
    public int UserId { get; set; }
}