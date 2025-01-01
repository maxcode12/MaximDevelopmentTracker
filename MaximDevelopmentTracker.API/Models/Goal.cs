using System.ComponentModel.DataAnnotations;

namespace MaximDevelopmentTracker.API.Models;

public class Goal : BaseEntity
{
    [Required]
    [StringLength(255)]
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Progress { get; set; }
    public string Notes { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    public virtual ICollection<ProgressLog> ProgressLogs { get; set; }

    public Goal()
    {
        ProgressLogs = new HashSet<ProgressLog>();
    }
}
