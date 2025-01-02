using MaximDevelopmentTracker.API.Dtos;
using MaximDevelopmentTracker.API.Models;

namespace MaximDevelopmentTracker.API.Interfaces;

public interface IGoalService
{
    Task<IEnumerable<GoalDto>> GetGoalsAsync();
    Task<GoalDto> GetGoalByIdAsync(Guid id);
    Task<GoalDto> CreateGoalAsync(GoalDto goal);
    Task<GoalDto> UpdateGoalAsync(Guid id, GoalDto goal);
    Task<GoalDto> DeleteGoalAsync(Guid id);
}
