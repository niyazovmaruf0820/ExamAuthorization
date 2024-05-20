using Microsoft.AspNetCore.Http;

namespace Domain.DTOs.TrainerDto;

public class GetTrainerDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Specialization { get; set; }
    public IFormFile? Photo { get; set; }
}
