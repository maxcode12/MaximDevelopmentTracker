using System.ComponentModel.DataAnnotations;

namespace MaximDevelopmentTracker.API.Dtos;

public class GoalDto
{
    public Guid Id { get; set; }
    [Required]
    [StringLength(255)]
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Progress { get; set; }
    public string Notes { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}


public class ProgressLogDto
{
    public Guid Id { get; set; }
    [Required]
    [StringLength(255)]
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public decimal Progress { get; set; }
    public Guid GoalId { get; set; }
   
}

public class UserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string SocialProvider { get; set; } = string.Empty;
    public string SocialProviderId { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}