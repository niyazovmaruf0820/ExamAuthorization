namespace Domain.DTOs.WorkoutDto;

public class CreateWorkoutDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int Duration { get; set; } 
    public string? Intensity { get; set; }
}
