using MaximDevelopmentTracker.API.Dtos;

namespace MaximDevelopmentTracker.API.Interfaces;

public interface IProgressLogService
{
    Task<ProgressLogDto> GetProgressAsync(Guid id);
    Task<ProgressLogDto> UpdateProgressAsync(Guid id, ProgressLogDto progress);
    Task<ProgressLogDto> DeleteProgressAsync(Guid id);
    Task<ProgressLogDto> CreateProgressAsync(ProgressLogDto progress);
}
