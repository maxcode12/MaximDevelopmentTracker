using MaximDevelopmentTracker.API.Dtos;
using MaximDevelopmentTracker.API.Interfaces;
using MaximDevelopmentTracker.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaximDevelopmentTracker.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GoalController : ControllerBase
{
    private readonly IGoalService _goalService;
    public GoalController(IGoalService goalService)
    {
        _goalService = goalService;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GoalDto>>> GetGoals()
    {
        var goals = await _goalService.GetGoalsAsync();
        return Ok(goals);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<GoalDto>> GetGoal(Guid id)
    {
        var goal = await _goalService.GetGoalByIdAsync(id);
        return Ok(goal);
    }
    [HttpPost]
    public async Task<ActionResult<GoalDto>> CreateGoal([FromBody] GoalDto goalDto)
    {
        var goal = await _goalService.CreateGoalAsync(goalDto);
        return CreatedAtAction(nameof(GetGoal), new { id = goal.Id }, goal);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<GoalDto>> UpdateGoal(Guid id, [FromBody] GoalDto goalDto)
    {
        var goal = await _goalService.UpdateGoalAsync(id, goalDto);
        return Ok(goal);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteGoal(Guid id)
    {
        await _goalService.DeleteGoalAsync(id);
        return NoContent();
    }
}
