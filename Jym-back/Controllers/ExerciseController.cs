using BLL.Interface;
using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jym_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllExercises()
        {
            var exercises = await _exerciseService.GetAll();
            return Ok(exercises);   
        }
        [HttpPost("")]
        public async Task<IActionResult> AddExercise([FromBody] List<ExerciseModel> exerciseModels)
        {
            var exercises=await _exerciseService.AddList(exerciseModels);
            return Ok(exercises);
        }
    }
}
