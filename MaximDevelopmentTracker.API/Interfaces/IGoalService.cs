using MaximDevelopmentTracker.API.Dtos;
using MaximDevelopmentTracker.API.Models;

namespace MaximDevelopmentTracker.API.Interfaces;

public interface IGoalService
{
    Task<IEnumerable<GoalDto>> GetGoalsAsync();
    Task<GoalDto> GetGoalByIdAsync(Guid id);
    Task<GoalDto> CreateGoalAsync(Goal goal);
    Task<GoalDto> UpdateGoalAsync(Guid id, Goal goal);
    Task<GoalDto> DeleteGoalAsync(Guid id);
}
