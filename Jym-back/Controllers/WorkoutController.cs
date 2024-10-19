using BLL.Interface;
using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jym_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly IWorkoutService _workoutService;

        public WorkoutController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkoutById([FromRoute] int id)
        {
            var workout=await _workoutService.Get(id);
            return Ok(workout);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddWorkout([FromBody] WorkoutModel workoutModel)
        {
            var workout= await _workoutService.Add(workoutModel);
            return Ok(workout); 
        }
        [HttpPut("")]
        public async Task<IActionResult> SetWorkout([FromBody] WorkoutModel workoutModel)
        {
            var workout=await _workoutService.Set(workoutModel);
            return Ok(workout);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkout([FromRoute] int id)
        {
            var w= await _workoutService.Delete(id);
            if(w) return Ok(w);
            return NoContent();
        } 
    }
}
