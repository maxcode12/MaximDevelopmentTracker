using MaximDevelopmentTracker.API.DataContext;
using MaximDevelopmentTracker.API.Dtos;
using MaximDevelopmentTracker.API.Interfaces;
using MaximDevelopmentTracker.API.Models;

namespace MaximDevelopmentTracker.API.Services;

public class ProgressLogService : IProgressLogService
{
    private readonly ILogger _logger;
    private readonly ApplicationDbContext _context;
    public ProgressLogService(ApplicationDbContext context, ILogger<ProgressLogService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public Task<ProgressLogDto> CreateProgressAsync(ProgressLogDto progress)
    {
        var progressLog = new ProgressLog
        {
            ProgressDate = progress.ProgressDate,
            ProgressValue = progress.ProgressValue,
            Notes = progress.Notes,
            GoalId = progress.GoalId
        };

        _context.ProgressLogs.Add(progressLog);
        _context.SaveChanges();
        return Task.FromResult(new ProgressLogDto
        {
            Id = progressLog.Id,
            ProgressDate = progressLog.ProgressDate,
            ProgressValue = progressLog.ProgressValue,
            Notes = progressLog.Notes,
            GoalId = progressLog.GoalId
        });
    }

    public Task<ProgressLogDto> DeleteProgressAsync(Guid id)
    {
        var progressLog = _context.ProgressLogs.Find(id);
        if( progressLog == null )
        {
            return Task.FromResult<ProgressLogDto>(null);
        }
        _context.ProgressLogs.Remove(progressLog);
        _context.SaveChanges();
        return Task.FromResult(new ProgressLogDto
        {
            Id = progressLog.Id,
            ProgressDate = progressLog.ProgressDate,
            ProgressValue = progressLog.ProgressValue,
            Notes = progressLog.Notes,
            GoalId = progressLog.GoalId
        });
    }

    public Task<ProgressLogDto> GetProgressAsync(Guid id)
    {
        var progressLog = _context.ProgressLogs.Find(id);
        if( progressLog == null )
        {
            return Task.FromResult<ProgressLogDto>(null);
        }
        return Task.FromResult(new ProgressLogDto
        {
            Id = progressLog.Id,
            ProgressDate = progressLog.ProgressDate,
            ProgressValue = progressLog.ProgressValue,
            Notes = progressLog.Notes,
            GoalId = progressLog.GoalId
        });
    }

    public Task<ProgressLogDto> UpdateProgressAsync(Guid id, ProgressLogDto progress)
    {
        var progressLog = _context.ProgressLogs.Find(id);
        if( progressLog == null )
        {
            return Task.FromResult<ProgressLogDto>(null);
        }
        progressLog.ProgressDate = progress.ProgressDate;
        progressLog.ProgressValue = progress.ProgressValue;
        progressLog.Notes = progress.Notes;
        progressLog.GoalId = progress.GoalId;
        _context.SaveChanges();
        return Task.FromResult(new ProgressLogDto
        {
            Id = progressLog.Id,
            ProgressDate = progressLog.ProgressDate,
            ProgressValue = progressLog.ProgressValue,
            Notes = progressLog.Notes,
            GoalId = progressLog.GoalId
        });
    }

    public Task<IEnumerable<ProgressLogDto>> GetProgressesAsync()
    {
        var progresses = _context.ProgressLogs.ToList();
        return Task.FromResult(progresses.Select(progress => new ProgressLogDto
        {
            Id = progress.Id,
            ProgressDate = progress.ProgressDate,
            ProgressValue = progress.ProgressValue,
            Notes = progress.Notes,
            GoalId = progress.GoalId
        }));
    }
}
