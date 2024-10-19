using BLL.Interface;
using BLL.Models;
using DAL.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jym_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseMuscleController : ControllerBase
    {
        private readonly IExerciseMuscleService _exerciseMuscleService;

        public ExerciseMuscleController(IExerciseMuscleService exerciseMuscleService)
        {
            this._exerciseMuscleService = exerciseMuscleService;
        }

        [HttpPost("{MuscleId}/{ExerciseId}")]
        public async Task<IActionResult> Add([FromRoute] int MuscleId, [FromRoute] int ExerciseId)
        {
            var mc=await _exerciseMuscleService.Add(ExerciseId, MuscleId);
            return Ok(mc);
        }

        [HttpPost("List/{MuscleId}")]
        public async Task<IActionResult> Add([FromRoute] int MuscleId, [FromBody] List<ExerciseModel> exerciseModels)
        {
            var mc = await _exerciseMuscleService.AddExercisesMuscle(exerciseModels, MuscleId);
            return Ok(mc);
        }

        [HttpDelete("{MuscleId}/{ExerciseId}")]
        public async Task<IActionResult> Delete([FromRoute] int MuscleId, [FromRoute] int ExerciseId)
        {
            var IsSucced = await _exerciseMuscleService.Delete(ExerciseId, MuscleId);
            return Ok(IsSucced);
        }


    }
}
