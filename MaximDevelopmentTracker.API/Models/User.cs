using System.ComponentModel.DataAnnotations;

namespace MaximDevelopmentTracker.API.Models;

public class User : BaseEntity
{
   

    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }

    public string Username { get; set; }

    public string PasswordHash { get; set; }

    public string? SocialProvider { get; set; }

    public string? SocialProviderId { get; set; }

    public string? ImageUrl { get; set; }
    public virtual ICollection<Goal> Goals { get; set; }

    public User()
    {
        Goals = new HashSet<Goal>();
    }
}
