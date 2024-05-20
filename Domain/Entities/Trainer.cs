using Microsoft.AspNetCore.Http;

namespace Domain.Entities;

public class Trainer : BaseEntity
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Specialization { get; set; }
    public string PathPhoto  { get; set; }=null!;
}
