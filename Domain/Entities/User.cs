namespace Domain.Entities;

public class User : BaseEntity
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public DateTime RegistrationDate { get; set; }
    public string? Role { get; set; }
}
