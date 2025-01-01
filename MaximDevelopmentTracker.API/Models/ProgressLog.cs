namespace MaximDevelopmentTracker.API.Models;

public class ProgressLog : BaseEntity
{
    public DateTime ProgressDate { get; set; }
    public decimal ProgressValue { get; set; }
    public string Notes { get; set; }
    public Guid GoalId { get; set; }
    public virtual Goal Goal { get; set; }
}