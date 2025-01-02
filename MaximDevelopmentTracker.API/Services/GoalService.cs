using MaximDevelopmentTracker.API.DataContext;
using MaximDevelopmentTracker.API.Dtos;
using MaximDevelopmentTracker.API.Interfaces;
using MaximDevelopmentTracker.API.Models;
using Microsoft.EntityFrameworkCore;

namespace MaximDevelopmentTracker.API.Services;

public class GoalService : IGoalService
{
    private readonly ApplicationDbContext _context;
    public GoalService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GoalDto>> GetGoalsAsync()
    {
        var goals = await _context.Goals.ToListAsync();
        return goals.Select(goal => new GoalDto
        {
            Title = goal.Title,
            Description = goal.Description,
            StartDate = goal.StartDate,
            EndDate = goal.EndDate,
            Progress = goal.Progress,
            Notes = goal.Notes,
            UserId = goal.UserId,
            
        }).ToList();
    }

    public async Task<GoalDto> GetGoalByIdAsync(Guid id)
    {
        var goal = await _context.Goals.FirstOrDefaultAsync(g => g.Id == id);
        return new GoalDto
        {
            Title = goal.Title,
            Description = goal.Description,
            StartDate = goal.StartDate,
            EndDate = goal.EndDate,
            Progress = goal.Progress,
            Notes = goal.Notes,
            UserId = goal.UserId,
        };
    }

    public async Task<GoalDto> CreateGoalAsync(GoalDto goal)
    {
        //_context.Goals.Add(goal);
        await _context.SaveChangesAsync();
        return new GoalDto
        {
            Id = goal.Id,
            Title = goal.Title,
            Description = goal.Description,
            StartDate = goal.StartDate,
            EndDate = goal.EndDate,
            Progress = goal.Progress,
            Notes = goal.Notes,
            UserId = goal.UserId,
        };
    }

    public async Task<GoalDto> UpdateGoalAsync(Guid id, GoalDto goal)
    {
        var goalToUpdate = await _context.Goals.FirstOrDefaultAsync(g => g.Id == id);
        goalToUpdate.Title = goal.Title;
        goalToUpdate.Description = goal.Description;
        goalToUpdate.StartDate = goal.StartDate;
        goalToUpdate.EndDate = goal.EndDate;
        goalToUpdate.Progress = goal.Progress;
        goalToUpdate.Notes = goal.Notes;
        goalToUpdate.UserId = goal.UserId;
        await _context.SaveChangesAsync();
        return new GoalDto
        {
            Id = goalToUpdate.Id,
            Title = goalToUpdate.Title,
            Description = goalToUpdate.Description,
            StartDate = goalToUpdate.StartDate,
            EndDate = goalToUpdate.EndDate,
            Progress = goalToUpdate.Progress,
            Notes = goalToUpdate.Notes,
            UserId = goalToUpdate.UserId,
        };
    }

    public async Task<GoalDto> DeleteGoalAsync(Guid id)
    {
        var goal = await _context.Goals.FirstOrDefaultAsync(g => g.Id == id);
        _context.Goals.Remove(goal);
        await _context.SaveChangesAsync();
        return new GoalDto
        {
            Title = goal.Title,
            Description = goal.Description,
            StartDate = goal.StartDate,
            EndDate = goal.EndDate,
            Progress = goal.Progress,
            Notes = goal.Notes,
            UserId = goal.UserId,
        };
    }
}
